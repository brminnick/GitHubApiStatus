using System;
using System.Net.Http;
using System.Net.Http.Headers;
using NUnit.Framework;

namespace GitHubApiStatus.UnitTests
{
    class GetRemainingRequestCountTests : BaseTest
    {
        [Test]
        public void GetRemainingRequestCount_ValidHttpResponseHeaders()
        {
            //Act
            const int rateLimit = 5000;
            const int remainingRequestCount_Expected = 100;

            int remainingRequestCount_Actual;

            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, DateTimeOffset.UtcNow, remainingRequestCount_Expected);

            //Act
            remainingRequestCount_Actual = GitHubApiStatus.GetRemainingRequestCount(validHttpResponseHeaders);

            //Assert
            Assert.AreEqual(remainingRequestCount_Expected, remainingRequestCount_Actual);
        }

        [Test]
        public void GetRemainingRequestCount_InvalidHttpResponseHeaders()
        {
            //Arrange
            var invalidHttpResponseMessage = new HttpResponseMessage();

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => GitHubApiStatus.GetRemainingRequestCount(invalidHttpResponseMessage.Headers));
        }

        [Test]
        public void GetRemainingRequestCount_NullHttpResponseHeaders()
        {
            //Arrange
            HttpResponseHeaders? nullHttpResponseHeaders = null;

            //Act

            //Assert
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<ArgumentNullException>(() => GitHubApiStatus.GetRemainingRequestCount(nullHttpResponseHeaders));
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
