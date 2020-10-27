using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GitStatus.Shared;
using NUnit.Framework;

namespace GitHubApiStatus.UnitTests
{
    class GetApiRateLimitsTests
    {
        [Test]
        public void GetApiRateLimits_NullAuthenticationHeaderValue()
        {
            //Arrange
            AuthenticationHeaderValue? authenticationHeaderValue = null;

            //Act

            //Assert
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.ThrowsAsync<ArgumentNullException>(() => GitHubApiStatusService.Instance.GetApiRateLimits(authenticationHeaderValue));
#pragma warning restore CS8604 // Possible null reference argument.
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("Basic")]
        [TestCase("Oauth")]
        [TestCase("Digest")]
        public void GetApiRateLimits_InvalidScheme(string? scheme)
        {
            //Arrange
#pragma warning disable CS8604 // Possible null reference argument.
            var authenticationHeaderValue = new AuthenticationHeaderValue(scheme, GitHubConstants.PersonalAccessToken);
#pragma warning restore CS8604 // Possible null reference argument.

            //Act

            //Assert
            Assert.ThrowsAsync<ArgumentException>(() => GitHubApiStatusService.Instance.GetApiRateLimits(authenticationHeaderValue));
        }


    }
}
