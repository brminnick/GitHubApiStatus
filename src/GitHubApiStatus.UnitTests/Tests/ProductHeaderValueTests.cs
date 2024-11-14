using System.Net.Http.Headers;
using GitStatus.Common;
using NUnit.Framework;

namespace GitHubApiStatus.UnitTests;

class AddProductHeaderValueTests : BaseTest
{
	[Test]
	public void NullProductHeaderValueTest()
	{
		//Arrange
		var gitHubApiStatusService = new GitHubApiStatusService();

		//Act

		//Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
		Assert.Multiple(() =>
		{
			Assert.That(() => gitHubApiStatusService.AddProductHeaderValue(null), Throws.TypeOf<GitHubApiStatusException>());
			Assert.That(gitHubApiStatusService.IsProductHeaderValueValid, Is.False);
		});
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
	}

	[Test]
	public void NullNameTest()
	{
		//Arrange
		var gitHubApiStatusService = new GitHubApiStatusService();

		//Act

		//Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#if NET8_0_OR_GREATER
		Assert.Multiple(() =>
		{
			Assert.That(() => gitHubApiStatusService.AddProductHeaderValue(new ProductHeaderValue(null)), Throws.TypeOf<ArgumentNullException>());
			Assert.That(gitHubApiStatusService.IsProductHeaderValueValid, Is.False);
		});
#else
		Assert.Multiple(() =>
		{
			Assert.That(() => gitHubApiStatusService.AddProductHeaderValue(new ProductHeaderValue(null)), Throws.TypeOf<ArgumentException>());
			Assert.That(gitHubApiStatusService.IsProductHeaderValueValid, Is.False);
		});
#endif
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
	}

	[Test]
	public async Task ValidProductHeaderValueTest()
	{
		//Arrange
		var gitHubApiStatusService = new GitHubApiStatusService();
		gitHubApiStatusService.AddProductHeaderValue(new ProductHeaderValue(nameof(GitHubApiStatus)));
		gitHubApiStatusService.SetAuthenticationHeaderValue(new AuthenticationHeaderValue(GitHubConstants.AuthScheme, GitHubConstants.PersonalAccessToken));

		//Act
		var apiRateLimits = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);

		//Assert
		Assert.Multiple(() =>
		{
			Assert.That(gitHubApiStatusService, Is.Not.Null);
			Assert.That(gitHubApiStatusService.IsProductHeaderValueValid, Is.True);

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





