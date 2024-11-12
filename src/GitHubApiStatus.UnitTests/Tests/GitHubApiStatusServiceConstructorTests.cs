using System.Net.Http.Headers;
using GitStatus.Common;
using NUnit.Framework;

namespace GitHubApiStatus.UnitTests;

class GitHubApiStatusServiceConstructorTests : BaseTest
{
	[Test]
	public void DefaultConstructorTest()
	{
		//Arrange
		var githubApiStatusService = new GitHubApiStatusService();

		//Act

		//Assert
		Assert.That(() => githubApiStatusService.GetApiRateLimits(), Throws.TypeOf<GitHubApiStatusException>());
	}

	[Test]
	public void NullAuthenticationHeaderValue()
	{
		//Arrange
		var productHeaderValue = new ProductHeaderValue(nameof(GitHubApiStatus));

		//Act

		//Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
		Assert.That(() => new GitHubApiStatusService(null, productHeaderValue), Throws.TypeOf<GitHubApiStatusException>());
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
	}

	[Test]
	public void NullProductHeaderValue()
	{
		//Arrange
		var authenticationHeaderValue = new AuthenticationHeaderValue(GitHubConstants.AuthScheme, GitHubConstants.PersonalAccessToken);

		//Act

		//Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
		Assert.That(() => new GitHubApiStatusService(authenticationHeaderValue, null), Throws.TypeOf<GitHubApiStatusException>());
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
	}

	[Test]
	public void NullHttpClient()
	{
		//Arrange

		//Act

		//Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
		Assert.That(() => new GitHubApiStatusService(null), Throws.TypeOf<GitHubApiStatusException>());
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
	}

	[TestCase("Basic")]
	[TestCase("Oauth")]
	[TestCase("Digest")]
	public void InvalidSchemeAuthenticationHeaderValue(string scheme)
	{
		//Arrange
		var productHeaderValue = new ProductHeaderValue(nameof(GitHubApiStatus));
		var authenticationHeaderValue = new AuthenticationHeaderValue(scheme, GitHubConstants.PersonalAccessToken);

		//Act

		//Assert
		Assert.That(() => new GitHubApiStatusService(authenticationHeaderValue, productHeaderValue), Throws.TypeOf<GitHubApiStatusException>());
	}

	[Test]
	public async Task BEARERSchemeAuthenticationHeaderValue()
	{
		//Arrange
		var productHeaderValue = new ProductHeaderValue(nameof(GitHubApiStatus));
		var authenticationHeaderValue = new AuthenticationHeaderValue(GitHubConstants.AuthScheme.ToUpper(), GitHubConstants.PersonalAccessToken);
		var gitHubApiStatusService = new GitHubApiStatusService(authenticationHeaderValue, productHeaderValue);

		//Act
		var apiRateLimits = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);

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
	public async Task BEARERSchemeHttpClient()
	{
		//Arrange
		var httpClient = CreateGitHubHttpClient(new AuthenticationHeaderValue(GitHubConstants.AuthScheme.ToUpper(), GitHubConstants.PersonalAccessToken), new ProductHeaderValue(nameof(GitHubApiStatus)));
		var gitHubApiStatusService = new GitHubApiStatusService(httpClient);

		//Act
		var apiRateLimits = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);

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
	public async Task ValidProductHeaderValue()
	{
		//Arrange
		var authenticationHeaderValue = new AuthenticationHeaderValue(GitHubConstants.AuthScheme, GitHubConstants.PersonalAccessToken);
		var productHeaderValue = new ProductHeaderValue(nameof(GitHubApiStatus));

		var gitHubApiStatusService = new GitHubApiStatusService(authenticationHeaderValue, productHeaderValue);

		//Act
		var apiRateLimits = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);

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
}



