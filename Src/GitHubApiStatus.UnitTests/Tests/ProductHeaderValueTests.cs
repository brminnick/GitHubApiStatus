using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GitStatus.Shared;
using NUnit.Framework;

namespace GitHubApiStatus.UnitTests
{
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
            Assert.Throws<GitHubApiStatusException>(() => gitHubApiStatusService.AddProductHeaderValue(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.IsFalse(gitHubApiStatusService.IsProductHeaderValueValid);
        }

        [Test]
        public void NullNameTest()
        {
            //Arrange
            var gitHubApiStatusService = new GitHubApiStatusService();

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => gitHubApiStatusService.AddProductHeaderValue(new ProductHeaderValue(null)));
            Assert.IsFalse(gitHubApiStatusService.IsProductHeaderValueValid);
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
            Assert.IsNotNull(gitHubApiStatusService);
            Assert.IsTrue(gitHubApiStatusService.IsProductHeaderValueValid);

            Assert.IsNotNull(apiRateLimits);
            Assert.IsNotNull(apiRateLimits.AppManifestConfiguration);
            Assert.IsNotNull(apiRateLimits.CodeScanningUpload);
            Assert.IsNotNull(apiRateLimits.GraphQLApi);
            Assert.IsNotNull(apiRateLimits.RestApi);
            Assert.IsNotNull(apiRateLimits.SearchApi);
            Assert.IsNotNull(apiRateLimits.SourceImport);
        }
    }
}
