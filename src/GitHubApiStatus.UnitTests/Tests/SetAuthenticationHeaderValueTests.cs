using System.Net.Http.Headers;
using GitStatus.Shared;
using NUnit.Framework;

namespace GitHubApiStatus.UnitTests;

class SetAuthenticationHeaderValueTests
{
	[Test]
	public void NullAuthenticationHeaderValue()
	{
		//Arrange
		var gitHubApiStatusService = new GitHubApiStatusService();

		//Act

		//Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
		Assert.Throws<GitHubApiStatusException>(() => gitHubApiStatusService.SetAuthenticationHeaderValue(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
		Assert.IsFalse(gitHubApiStatusService.IsAuthenticationHeaderValueSet);
	}

	[TestCase("Basic")]
	[TestCase("Oauth")]
	[TestCase("Digest")]
	public void InvalidSchemeAuthenticationHeaderValue(string scheme)
	{
		//Arrange
		var gitHubApiStatusService = new GitHubApiStatusService();
		var authenticationHeaderValue = new AuthenticationHeaderValue(scheme, GitHubConstants.PersonalAccessToken);

		//Act

		//Assert
		Assert.Throws<GitHubApiStatusException>(() => gitHubApiStatusService.SetAuthenticationHeaderValue(authenticationHeaderValue));
	}

	[TestCase(null)]
	[TestCase("")]
	[TestCase(" ")]
	public void InvalidParameterAuthenticationHeaderValue(string parameter)
	{
		//Arrange
		var gitHubApiStatusService = new GitHubApiStatusService();
		var authenticationHeaderValue = new AuthenticationHeaderValue(GitHubConstants.AuthScheme, parameter);

		//Act

		//Assert
		Assert.Throws<GitHubApiStatusException>(() => gitHubApiStatusService.SetAuthenticationHeaderValue(authenticationHeaderValue));
	}

	[Test]
	public async Task BEARERSchemeAuthenticationHeaderValue()
	{
		//Arrange
		var productHeaderValue = new ProductHeaderValue(nameof(GitHubApiStatus));
		var authenticationHeaderValue = new AuthenticationHeaderValue(GitHubConstants.AuthScheme.ToUpper(), GitHubConstants.PersonalAccessToken);
		var gitHubApiStatusService = new GitHubApiStatusService();

		//Act
		gitHubApiStatusService.SetAuthenticationHeaderValue(authenticationHeaderValue);
		gitHubApiStatusService.AddProductHeaderValue(productHeaderValue);

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