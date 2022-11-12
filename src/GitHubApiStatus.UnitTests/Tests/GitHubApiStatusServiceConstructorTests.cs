using System.Net.Http.Headers;
using System.Threading.Tasks;
using GitStatus.Shared;
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
		Assert.ThrowsAsync<GitHubApiStatusException>(() => githubApiStatusService.GetApiRateLimits());
	}

	[Test]
	public void NullAuthenticationHeaderValue()
	{
		//Arrange
		var productHeaderValue = new ProductHeaderValue(nameof(GitHubApiStatus));

		//Act

		//Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
		Assert.Throws<GitHubApiStatusException>(() => new GitHubApiStatusService(null, productHeaderValue));
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
		Assert.Throws<GitHubApiStatusException>(() => new GitHubApiStatusService(authenticationHeaderValue, null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
	}

	[Test]
	public void NullHttpClient()
	{
		//Arrange

		//Act

		//Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
		Assert.Throws<GitHubApiStatusException>(() => new GitHubApiStatusService(null));
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
		Assert.Throws<GitHubApiStatusException>(() => new GitHubApiStatusService(authenticationHeaderValue, productHeaderValue));
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
		Assert.IsNotNull(gitHubApiStatusService);
		Assert.IsNotNull(apiRateLimits);
		Assert.IsNotNull(apiRateLimits.AppManifestConfiguration);
		Assert.IsNotNull(apiRateLimits.CodeScanningUpload);
		Assert.IsNotNull(apiRateLimits.GraphQLApi);
		Assert.IsNotNull(apiRateLimits.RestApi);
		Assert.IsNotNull(apiRateLimits.SearchApi);
		Assert.IsNotNull(apiRateLimits.SourceImport);
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
		Assert.IsNotNull(gitHubApiStatusService);
		Assert.IsNotNull(apiRateLimits);
		Assert.IsNotNull(apiRateLimits.AppManifestConfiguration);
		Assert.IsNotNull(apiRateLimits.CodeScanningUpload);
		Assert.IsNotNull(apiRateLimits.GraphQLApi);
		Assert.IsNotNull(apiRateLimits.RestApi);
		Assert.IsNotNull(apiRateLimits.SearchApi);
		Assert.IsNotNull(apiRateLimits.SourceImport);
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
		Assert.IsNotNull(gitHubApiStatusService);
		Assert.IsNotNull(apiRateLimits);
		Assert.IsNotNull(apiRateLimits.AppManifestConfiguration);
		Assert.IsNotNull(apiRateLimits.CodeScanningUpload);
		Assert.IsNotNull(apiRateLimits.GraphQLApi);
		Assert.IsNotNull(apiRateLimits.RestApi);
		Assert.IsNotNull(apiRateLimits.SearchApi);
		Assert.IsNotNull(apiRateLimits.SourceImport);
	}
}