using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GitStatus.Shared;
using NUnit.Framework;

namespace GitHubApiStatus.UnitTests
{
    class GitHubApiStatusServiceConstructorTests : BaseTest
    {
        [Test]
        public void DefaultConstructorTest()
        {
            //Arrange
            const int rateLimit = 5000;

            var rateLimitResettime = DateTimeOffset.UtcNow;

            var githubApiStatusService = new GitHubApiStatusService();
            var httpResponseHeaders = CreateHttpResponseHeaders(rateLimit, rateLimitResettime, rateLimit - 5);

            //Act

            //Assert

            Assert.ThrowsAsync<GitHubApiStatusException>(() => githubApiStatusService.GetApiRateLimits());
        }

        [Test]
        public void NullAuthenticationHeaderValue()
        {
            //Arrange
            var productHeaderValue = new ProductHeaderValue(nameof(GitHubApiClient));

            //Act

            //Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.Throws<ArgumentNullException>(() => new GitHubApiStatusService(null, productHeaderValue));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        [Test]
        public void NullProductHeaderValue()
        {
            //Arrange
            var authenticationHeaderValue = new AuthenticationHeaderValue("bearer", GitHubConstants.PersonalAccessToken);

            //Act

            //Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.Throws<ArgumentNullException>(() => new GitHubApiStatusService(authenticationHeaderValue, null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        [Test]
        public void NullHttpClient()
        {
            //Arrange

            //Act

            //Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.Throws<ArgumentNullException>(() => new GitHubApiStatusService(null));
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
            Assert.Throws<ArgumentException>(() => new GitHubApiStatusService(authenticationHeaderValue, productHeaderValue));
        }

        [TestCase("Basic")]
        [TestCase("Oauth")]
        [TestCase("Digest")]
        public void InvalidSchemeHttpClient(string scheme)
        {
            //Arrange
            var client = new HttpClient
            {
                DefaultRequestHeaders =
                {
                    { "Authorization", $"{scheme} abc123" },
                }
            };

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => new GitHubApiStatusService(client));
        }

        [Test]
        public void MissingAuthenticationHeaderValueHttpClient()
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => new GitHubApiStatusService(new HttpClient()));
        }

        [Test]
        public void EmptySchemeHttpClient()
        {
            //Arrange
            var client = new HttpClient
            {
                DefaultRequestHeaders =
                {
                    { "Authorization", "abc123" },
                }
            };

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => new GitHubApiStatusService(client));
        }

        [Test]
        public async Task BEARERSchemeAuthenticationHeaderValue()
        {
            //Arrange
            var productHeaderValue = new ProductHeaderValue(nameof(GitHubApiStatus));
            var authenticationHeaderValue = new AuthenticationHeaderValue("BEARER", GitHubConstants.PersonalAccessToken);
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
            var httpClient = new HttpClient
            {
                DefaultRequestHeaders =
                {
                    { "Authorization", "BEARER " + GitHubConstants.PersonalAccessToken },
                    { "User-Agent", nameof(GitHubApiStatus) }
                }
            };
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

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void InvalidParameterAuthenticationHeaderValue(string parameter)
        {
            //Arrange
            var productHeaderValue = new ProductHeaderValue(nameof(GitHubApiStatus));
            var authenticationHeaderValue = new AuthenticationHeaderValue("bearer", parameter);

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => new GitHubApiStatusService(authenticationHeaderValue, productHeaderValue));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void InvalidParameterHttpClient(string parameter)
        {
            //Arrange
            var client = new HttpClient
            {
                DefaultRequestHeaders =
                {
                    { "Authorization", "bearer" + parameter },
                }
            };

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => new GitHubApiStatusService(client));
        }

        [Test]
        public async Task ValidProductHeaderValue()
        {
            //Arrange
            var authenticationHeaderValue = new AuthenticationHeaderValue("bearer", GitHubConstants.PersonalAccessToken);
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

        [Test]
        public async Task MissingProductHeaderValueHttpClient()
        {
            //Arrange
            var authenticationHeaderValue = new AuthenticationHeaderValue("bearer", GitHubConstants.PersonalAccessToken);

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = authenticationHeaderValue;

            var gitHubApiStatusService = new GitHubApiStatusService(client);

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
        public async Task CustomProductHeaderValueHttpClient()
        {
            //Arrange
            var authenticationHeaderValue = new AuthenticationHeaderValue("bearer", GitHubConstants.PersonalAccessToken);
            var productHeaderValue = new ProductHeaderValue(nameof(GitStatus));

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
}
