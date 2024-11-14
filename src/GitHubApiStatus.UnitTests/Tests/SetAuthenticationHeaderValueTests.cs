using System.Net.Http.Headers;
using GitStatus.Common;
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
		Assert.Multiple(() =>
		{
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
			Assert.That(() => gitHubApiStatusService.SetAuthenticationHeaderValue(null), Throws.TypeOf<GitHubApiStatusException>());
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
			Assert.That(gitHubApiStatusService.IsAuthenticationHeaderValueSet, Is.False);
		});
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
		Assert.That(() => gitHubApiStatusService.SetAuthenticationHeaderValue(authenticationHeaderValue), Throws.TypeOf<GitHubApiStatusException>());
	}

	[TestCase(null)]
	[TestCase("")]
	[TestCase(" ")]
	public void InvalidParameterAuthenticationHeaderValue(string? parameter)
	{
		//Arrange
		var gitHubApiStatusService = new GitHubApiStatusService();
		var authenticationHeaderValue = new AuthenticationHeaderValue(GitHubConstants.AuthScheme, parameter);

		//Act

		//Assert
		Assert.That(() => gitHubApiStatusService.SetAuthenticationHeaderValue(authenticationHeaderValue), Throws.TypeOf<GitHubApiStatusException>());
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





