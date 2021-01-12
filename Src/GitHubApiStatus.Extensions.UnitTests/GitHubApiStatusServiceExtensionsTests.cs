using System;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using GitStatus.Shared;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace GitHubApiStatus.Extensions.UnitTests
{
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

            //Assett
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<ArgumentNullException>(() => services.AddGitHubApiStatusService(authenticationHeaderValue, productHeaderValue));
#pragma warning restore CS8604 // Possible null reference argument.
        }

        [Test]
        public void EmptyProductHeaderValue()
        {
            //Arrange

            //Act

            //Assett
            Assert.Throws<ArgumentException>(() => new ProductHeaderValue(""));
        }

        public void WhiteSpaceProductHeaderValue()
        {
            //Arrange

            //Act

            //Assett
            Assert.Throws<ArgumentException>(() => new ProductHeaderValue(" "));
        }

        [Test]
        public void NullAuthenticationHeaderValue()
        {
            //Arrange
            var services = new ServiceCollection();
            var productHeaderValue = GetProductHeaderValue();
            AuthenticationHeaderValue? authenticationHeaderValue = null;

            //Act

            //Assett
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<ArgumentNullException>(() => services.AddGitHubApiStatusService(authenticationHeaderValue, productHeaderValue));
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

            //Assett
            Assert.Throws<ArgumentException>(() => services.AddGitHubApiStatusService(authenticationHeaderValue, productHeaderValue));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void InvalidParameterAuthenticationHeaderValue(string parameter)
        {
            //Arrange
            var services = new ServiceCollection();
            var productHeaderValue = GetProductHeaderValue();
            var authenticationHeaderValue = new AuthenticationHeaderValue(GitHubConstants.AuthScheme, parameter);

            //Act

            //Assett
            Assert.Throws<ArgumentException>(() => services.AddGitHubApiStatusService(authenticationHeaderValue, productHeaderValue));
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
            var gitHubApiStatusServce = container.GetRequiredService<IGitHubApiStatusService>();

            var apiRateLimits = await gitHubApiStatusServce.GetApiRateLimits(CancellationToken.None).ConfigureAwait(false);

            //Assert
            Assert.IsNotNull(gitHubApiStatusServce);
            Assert.IsNotNull(apiRateLimits);
            Assert.IsNotNull(apiRateLimits.AppManifestConfiguration);
            Assert.IsNotNull(apiRateLimits.CodeScanningUpload);
            Assert.IsNotNull(apiRateLimits.GraphQLApi);
            Assert.IsNotNull(apiRateLimits.RestApi);
            Assert.IsNotNull(apiRateLimits.SearchApi);
            Assert.IsNotNull(apiRateLimits.SourceImport);
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
            Assert.IsNotNull(gitHubApiStatusServce);
            Assert.IsNotNull(apiRateLimits);
            Assert.IsNotNull(apiRateLimits.AppManifestConfiguration);
            Assert.IsNotNull(apiRateLimits.CodeScanningUpload);
            Assert.IsNotNull(apiRateLimits.GraphQLApi);
            Assert.IsNotNull(apiRateLimits.RestApi);
            Assert.IsNotNull(apiRateLimits.SearchApi);
            Assert.IsNotNull(apiRateLimits.SourceImport);
        }

        static AuthenticationHeaderValue GetAuthenticationHeaderValue() => new(GitHubConstants.AuthScheme, GitHubConstants.PersonalAccessToken);
        static ProductHeaderValue GetProductHeaderValue() => new(nameof(GitHubApiStatus));
    }
}