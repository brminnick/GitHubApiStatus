using System.Net.Http.Headers;
using GitStatus.Common;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace GitHubApiStatus.Extensions.UnitTests;

class GitHubApiStatusServiceExtensionsTests
{
	[Test]
	public void NullProductHeaderValue()
	{
		//Arrange
		var services = new ServiceCollection();
		ProductHeaderValue? productHeaderValue = null;
		var authenticationHeaderValue = GetAuthenticationHeaderValue();

		//Act

		//Assert
#pragma warning disable CS8604 // Possible null reference argument.
		Assert.That(() => services.AddGitHubApiStatusService(authenticationHeaderValue, productHeaderValue), Throws.TypeOf<ArgumentNullException>());
#pragma warning restore CS8604 // Possible null reference argument.
	}

	[Test]
	public void EmptyProductHeaderValue()
	{
		//Arrange

		//Act

		//Assert
		Assert.That(() => new ProductHeaderValue(""), Throws.TypeOf<ArgumentException>());
	}

	[Test]
	public void WhiteSpaceProductHeaderValue()
	{
		//Arrange

		//Act

		//Assert
		Assert.That(() => new ProductHeaderValue(" "), Throws.TypeOf<FormatException>());
	}

	[Test]
	public void NullAuthenticationHeaderValue()
	{
		//Arrange
		var services = new ServiceCollection();
		var productHeaderValue = GetProductHeaderValue();
		AuthenticationHeaderValue? authenticationHeaderValue = null;

		//Act

		//Assert
#pragma warning disable CS8604 // Possible null reference argument.
		Assert.That(() => services.AddGitHubApiStatusService(authenticationHeaderValue, productHeaderValue), Throws.TypeOf<ArgumentNullException>());
#pragma warning restore CS8604 // Possible null reference argument.
	}

	[TestCase("Basic")]
	[TestCase("Oauth")]
	[TestCase("Digest")]
	public void InvalidSchemeAuthenticationHeaderValue(string scheme)
	{
		//Arrange
		var services = new ServiceCollection();
		var productHeaderValue = GetProductHeaderValue();
		var authenticationHeaderValue = new AuthenticationHeaderValue(scheme, GitHubConstants.PersonalAccessToken);

		//Act

		//Assert
		Assert.That(() => services.AddGitHubApiStatusService(authenticationHeaderValue, productHeaderValue), Throws.TypeOf<ArgumentException>());
	}

	[TestCase(null)]
	[TestCase("")]
	[TestCase(" ")]
	public void InvalidParameterAuthenticationHeaderValue(string? parameter)
	{
		//Arrange
		var services = new ServiceCollection();
		var productHeaderValue = GetProductHeaderValue();
		var authenticationHeaderValue = new AuthenticationHeaderValue(GitHubConstants.AuthScheme, parameter);

		//Act

		//Assert
		Assert.That(() => services.AddGitHubApiStatusService(authenticationHeaderValue, productHeaderValue), Throws.TypeOf<ArgumentException>());
	}

	[Test]
	public async Task AddGitHubApiStatusService()
	{
		//Arrange
		var services = new ServiceCollection();
		var productHeaderValue = GetProductHeaderValue();
		var authenticationHeaderValue = GetAuthenticationHeaderValue();

		services.AddGitHubApiStatusService(authenticationHeaderValue, productHeaderValue);

		var container = services.BuildServiceProvider();

		//Act
		var gitHubApiStatusService = container.GetRequiredService<IGitHubApiStatusService>();

		var apiRateLimits = await gitHubApiStatusService.GetApiRateLimits(CancellationToken.None).ConfigureAwait(false);

		//Assert
		Assert.Multiple(() =>
		{
			Assert.That(gitHubApiStatusService, Is.Not.Null);
			Assert.That(apiRateLimits, Is.Not.Null);
			Assert.That(apiRateLimits.AppManifestConfiguration, Is.Not.Null);
			Assert.That(apiRateLimits.CodeScanningUpload, Is.Not.Null);
			Assert.That(apiRateLimits.GraphQLApi, Is.Not.Null);
			Assert.That(apiRateLimits.RestApi, Is.Not.Null);
			Assert.That(apiRateLimits.SearchApi, Is.Not.Null);
			Assert.That(apiRateLimits.SourceImport, Is.Not.Null);
		});
	}

	[Test]
	public async Task AddMockGitHubApiStatusService()
	{
		//Arrange
		var services = new ServiceCollection();
		var productHeaderValue = GetProductHeaderValue();
		var authenticationHeaderValue = GetAuthenticationHeaderValue();

		services.AddGitHubApiStatusService<MockGitHubApiStatusService>(authenticationHeaderValue, productHeaderValue);

		var container = services.BuildServiceProvider();

		//Act
		var gitHubApiStatusServce = container.GetRequiredService<IGitHubApiStatusService>();

		var apiRateLimits = await gitHubApiStatusServce.GetApiRateLimits(CancellationToken.None).ConfigureAwait(false);

		//Assert
		Assert.Multiple(() =>
		{
			Assert.That(gitHubApiStatusServce, Is.Not.Null);
			Assert.That(apiRateLimits, Is.Not.Null);
			Assert.That(apiRateLimits.AppManifestConfiguration, Is.Not.Null);
			Assert.That(apiRateLimits.CodeScanningUpload, Is.Not.Null);
			Assert.That(apiRateLimits.GraphQLApi, Is.Not.Null);
			Assert.That(apiRateLimits.RestApi, Is.Not.Null);
			Assert.That(apiRateLimits.SearchApi, Is.Not.Null);
			Assert.That(apiRateLimits.SourceImport, Is.Not.Null);
		});
	}

	static AuthenticationHeaderValue GetAuthenticationHeaderValue() => new(GitHubConstants.AuthScheme, GitHubConstants.PersonalAccessToken);
	static ProductHeaderValue GetProductHeaderValue() => new(nameof(GitHubApiStatus));
}
