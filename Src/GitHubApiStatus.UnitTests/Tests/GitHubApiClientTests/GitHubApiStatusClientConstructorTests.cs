using System;
using System.Linq;
using System.Net.Http.Headers;
using GitStatus.Shared;
using NUnit.Framework;

namespace GitHubApiStatus.UnitTests
{
    class GitHubApiClientConstructorTests : BaseTest
    {
        [Test]
        public void ValidConstructor()
        {
            //Arrange
            var authenticationHeaderValue = new AuthenticationHeaderValue("bearer", GitHubConstants.PersonalAccessToken);
            var productHeaderValue = new ProductHeaderValue(nameof(GitHubApiStatus));

            var client = new GitHubApiClient(authenticationHeaderValue, productHeaderValue);

            //Act

            //Assert
            Assert.NotNull(client);
            Assert.NotNull(client.DefaultRequestHeaders.Authorization);
            Assert.IsTrue(client.DefaultRequestHeaders.UserAgent.Any(x => !string.IsNullOrWhiteSpace(x.Product.Name)));
        }

        [Test]
        public void NullAuthenticationHeaderValue()
        {
            //Arrange
            var productHeaderValue = new ProductHeaderValue(nameof(GitHubApiStatus));

            //Act

            //Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.Throws<GitHubApiStatusException>(() => new GitHubApiClient(null, productHeaderValue));
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
            Assert.Throws<GitHubApiStatusException>(() => new GitHubApiClient(authenticationHeaderValue, productHeaderValue));
        }

        [Test]
        public void BEARERSchemeAuthenticationHeaderValue()
        {
            //Arrange
            var productHeaderValue = new ProductHeaderValue(nameof(GitHubApiStatus));
            var authenticationHeaderValue = new AuthenticationHeaderValue("BEARER", GitHubConstants.PersonalAccessToken);

            var client = new GitHubApiClient(authenticationHeaderValue, productHeaderValue);

            //Act

            //Assert
            Assert.NotNull(client);
            Assert.NotNull(client.DefaultRequestHeaders.Authorization);
            Assert.IsTrue(client.DefaultRequestHeaders.UserAgent.Any(x => !string.IsNullOrWhiteSpace(x.Product.Name)));
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
            Assert.Throws<GitHubApiStatusException>(() => new GitHubApiClient(authenticationHeaderValue, productHeaderValue));
        }

        [Test]
        public void NullProductHeaderValue()
        {
            //Arrange
            var authenticationHeaderValue = new AuthenticationHeaderValue("bearer", GitHubConstants.PersonalAccessToken);

            //Act

            //Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.Throws<GitHubApiStatusException>(() => new GitHubApiClient(authenticationHeaderValue, null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        [TestCase(null)]
        [TestCase("")]
        public void InvalidProductHeaderValue(string productHeaderValueName)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => new ProductHeaderValue(productHeaderValueName));
        }

        public void EmptyProductHeaderValue(string productHeaderValueName)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => new ProductHeaderValue(" "));
        }
    }
}
