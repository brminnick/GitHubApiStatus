using System;
using System.Net.Http;
using System.Net.Http.Headers;
using NUnit.Framework;

namespace GitHubApiStatus.UnitTests
{
    class IsAuthenticatedTests : BaseTest
    {
        [Test]
        public void IsUserAuthenticated_ValidHttpResponseHeaders_True()
        {
            //Act
            bool isUserAuthenticated_Actual;

            const int rateLimit = 5000;
            const int rateLimitRemaining = 0;
            const bool isUserAuthenticated_Expected = true;


            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, DateTimeOffset.UtcNow, rateLimitRemaining, isAuthenticated: isUserAuthenticated_Expected);

            //Act
            isUserAuthenticated_Actual = GitHubApiStatusService.IsAuthenticated(validHttpResponseHeaders);

            //Assert
            Assert.AreEqual(isUserAuthenticated_Expected, isUserAuthenticated_Actual);
        }

        [Test]
        public void IsUserAuthenticated_ValidHttpResponseHeaders_False()
        {
            //Act
            bool isUserAuthenticated_Actual;

            const int rateLimit = 5000;
            const int rateLimitRemaining = 10;
            const bool isUserAuthenticated_Expected = false;


            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, DateTimeOffset.UtcNow, rateLimitRemaining, isAuthenticated: isUserAuthenticated_Expected);

            //Act
            isUserAuthenticated_Actual = GitHubApiStatusService.IsAuthenticated(validHttpResponseHeaders);

            //Assert
            Assert.AreEqual(isUserAuthenticated_Expected, isUserAuthenticated_Actual);
        }

        [Test]
        public void IsUserAuthenticated_InvalidHttpResponseHeaders()
        {
            //Arrange
            var invalidHttpResponseMessage = new HttpResponseMessage();

            //Act
            var isUserAuthenticated = GitHubApiStatusService.IsAuthenticated(invalidHttpResponseMessage.Headers);

            //Assert
            Assert.IsFalse(isUserAuthenticated);
        }

        [Test]
        public void IsUserAuthenticated_NullHttpResponseHeaders()
        {
            //Arrange
            HttpResponseHeaders? nullHttpResponseHeaders = null;

            //Act

            //Assert
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.IsAuthenticated(nullHttpResponseHeaders));
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
