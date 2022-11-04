using System;
using System.Net.Http;
using System.Net.Http.Headers;
using NUnit.Framework;


/* Unmerged change from project 'GitHubApiStatus.UnitTests(netcoreapp2.1)'
Before:
namespace GitHubApiStatus.UnitTests
{
    class GetRateLimitTimeRemainingTests : BaseTest
    {
        [Test]
        public void GetRemainingRequestCount_ValidHttpResponseHeaders()
        {
            //Act
            const int rateLimit = 5000;
            TimeSpan rateLimitTimeRemaining_Actual;

            var rateLimitTimeRemaining_Expected = TimeSpan.FromMinutes(45);
            var rateLimitResetDateTime = DateTimeOffset.UtcNow.Add(rateLimitTimeRemaining_Expected);


            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, rateLimitResetDateTime, rateLimit - 5);

            //Act
            rateLimitTimeRemaining_Actual = GitHubApiStatusService.GetRateLimitTimeRemaining(validHttpResponseHeaders);

            //Assert
            Assert.Greater(rateLimitTimeRemaining_Expected, rateLimitTimeRemaining_Actual);
            Assert.Less(rateLimitTimeRemaining_Expected.Subtract(TimeSpan.FromSeconds(2)), rateLimitTimeRemaining_Actual);
        }

        [Test]
        public void GetRemainingRequestCount_InvalidHttpResponseHeaders()
        {
            //Arrange
            var invalidHttpResponseMessage = new HttpResponseMessage();

            //Act

            //Assert
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitTimeRemaining(invalidHttpResponseMessage.Headers));
        }

        [Test]
        public void GetRemainingRequestCount_NullHttpResponseHeaders()
        {
            //Arrange
            HttpResponseHeaders? nullHttpResponseHeaders = null;

            //Act

            //Assert
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitTimeRemaining(nullHttpResponseHeaders));
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
After:
namespace GitHubApiStatus.UnitTests;

    class GetRateLimitTimeRemainingTests : BaseTest
    {
        [Test]
        public void GetRemainingRequestCount_ValidHttpResponseHeaders()
        {
            //Act
            const int rateLimit = 5000;
            TimeSpan rateLimitTimeRemaining_Actual;

            var rateLimitTimeRemaining_Expected = TimeSpan.FromMinutes(45);
            var rateLimitResetDateTime = DateTimeOffset.UtcNow.Add(rateLimitTimeRemaining_Expected);


            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, rateLimitResetDateTime, rateLimit - 5);

            //Act
            rateLimitTimeRemaining_Actual = GitHubApiStatusService.GetRateLimitTimeRemaining(validHttpResponseHeaders);

            //Assert
            Assert.Greater(rateLimitTimeRemaining_Expected, rateLimitTimeRemaining_Actual);
            Assert.Less(rateLimitTimeRemaining_Expected.Subtract(TimeSpan.FromSeconds(2)), rateLimitTimeRemaining_Actual);
        }

        [Test]
        public void GetRemainingRequestCount_InvalidHttpResponseHeaders()
        {
            //Arrange
            var invalidHttpResponseMessage = new HttpResponseMessage();

            //Act

            //Assert
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitTimeRemaining(invalidHttpResponseMessage.Headers));
        }

        [Test]
        public void GetRemainingRequestCount_NullHttpResponseHeaders()
        {
            //Arrange
            HttpResponseHeaders? nullHttpResponseHeaders = null;

            //Act

            //Assert
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitTimeRemaining(nullHttpResponseHeaders));
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
*/

/* Unmerged change from project 'GitHubApiStatus.UnitTests(netcoreapp3.1)'
Before:
namespace GitHubApiStatus.UnitTests
{
    class GetRateLimitTimeRemainingTests : BaseTest
    {
        [Test]
        public void GetRemainingRequestCount_ValidHttpResponseHeaders()
        {
            //Act
            const int rateLimit = 5000;
            TimeSpan rateLimitTimeRemaining_Actual;

            var rateLimitTimeRemaining_Expected = TimeSpan.FromMinutes(45);
            var rateLimitResetDateTime = DateTimeOffset.UtcNow.Add(rateLimitTimeRemaining_Expected);


            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, rateLimitResetDateTime, rateLimit - 5);

            //Act
            rateLimitTimeRemaining_Actual = GitHubApiStatusService.GetRateLimitTimeRemaining(validHttpResponseHeaders);

            //Assert
            Assert.Greater(rateLimitTimeRemaining_Expected, rateLimitTimeRemaining_Actual);
            Assert.Less(rateLimitTimeRemaining_Expected.Subtract(TimeSpan.FromSeconds(2)), rateLimitTimeRemaining_Actual);
        }

        [Test]
        public void GetRemainingRequestCount_InvalidHttpResponseHeaders()
        {
            //Arrange
            var invalidHttpResponseMessage = new HttpResponseMessage();

            //Act

            //Assert
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitTimeRemaining(invalidHttpResponseMessage.Headers));
        }

        [Test]
        public void GetRemainingRequestCount_NullHttpResponseHeaders()
        {
            //Arrange
            HttpResponseHeaders? nullHttpResponseHeaders = null;

            //Act

            //Assert
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitTimeRemaining(nullHttpResponseHeaders));
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
After:
namespace GitHubApiStatus.UnitTests;

    class GetRateLimitTimeRemainingTests : BaseTest
    {
        [Test]
        public void GetRemainingRequestCount_ValidHttpResponseHeaders()
        {
            //Act
            const int rateLimit = 5000;
            TimeSpan rateLimitTimeRemaining_Actual;

            var rateLimitTimeRemaining_Expected = TimeSpan.FromMinutes(45);
            var rateLimitResetDateTime = DateTimeOffset.UtcNow.Add(rateLimitTimeRemaining_Expected);


            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, rateLimitResetDateTime, rateLimit - 5);

            //Act
            rateLimitTimeRemaining_Actual = GitHubApiStatusService.GetRateLimitTimeRemaining(validHttpResponseHeaders);

            //Assert
            Assert.Greater(rateLimitTimeRemaining_Expected, rateLimitTimeRemaining_Actual);
            Assert.Less(rateLimitTimeRemaining_Expected.Subtract(TimeSpan.FromSeconds(2)), rateLimitTimeRemaining_Actual);
        }

        [Test]
        public void GetRemainingRequestCount_InvalidHttpResponseHeaders()
        {
            //Arrange
            var invalidHttpResponseMessage = new HttpResponseMessage();

            //Act

            //Assert
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitTimeRemaining(invalidHttpResponseMessage.Headers));
        }

        [Test]
        public void GetRemainingRequestCount_NullHttpResponseHeaders()
        {
            //Arrange
            HttpResponseHeaders? nullHttpResponseHeaders = null;

            //Act

            //Assert
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitTimeRemaining(nullHttpResponseHeaders));
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
*/

/* Unmerged change from project 'GitHubApiStatus.UnitTests(net5.0)'
Before:
namespace GitHubApiStatus.UnitTests
{
    class GetRateLimitTimeRemainingTests : BaseTest
    {
        [Test]
        public void GetRemainingRequestCount_ValidHttpResponseHeaders()
        {
            //Act
            const int rateLimit = 5000;
            TimeSpan rateLimitTimeRemaining_Actual;

            var rateLimitTimeRemaining_Expected = TimeSpan.FromMinutes(45);
            var rateLimitResetDateTime = DateTimeOffset.UtcNow.Add(rateLimitTimeRemaining_Expected);


            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, rateLimitResetDateTime, rateLimit - 5);

            //Act
            rateLimitTimeRemaining_Actual = GitHubApiStatusService.GetRateLimitTimeRemaining(validHttpResponseHeaders);

            //Assert
            Assert.Greater(rateLimitTimeRemaining_Expected, rateLimitTimeRemaining_Actual);
            Assert.Less(rateLimitTimeRemaining_Expected.Subtract(TimeSpan.FromSeconds(2)), rateLimitTimeRemaining_Actual);
        }

        [Test]
        public void GetRemainingRequestCount_InvalidHttpResponseHeaders()
        {
            //Arrange
            var invalidHttpResponseMessage = new HttpResponseMessage();

            //Act

            //Assert
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitTimeRemaining(invalidHttpResponseMessage.Headers));
        }

        [Test]
        public void GetRemainingRequestCount_NullHttpResponseHeaders()
        {
            //Arrange
            HttpResponseHeaders? nullHttpResponseHeaders = null;

            //Act

            //Assert
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitTimeRemaining(nullHttpResponseHeaders));
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
After:
namespace GitHubApiStatus.UnitTests;

    class GetRateLimitTimeRemainingTests : BaseTest
    {
        [Test]
        public void GetRemainingRequestCount_ValidHttpResponseHeaders()
        {
            //Act
            const int rateLimit = 5000;
            TimeSpan rateLimitTimeRemaining_Actual;

            var rateLimitTimeRemaining_Expected = TimeSpan.FromMinutes(45);
            var rateLimitResetDateTime = DateTimeOffset.UtcNow.Add(rateLimitTimeRemaining_Expected);


            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, rateLimitResetDateTime, rateLimit - 5);

            //Act
            rateLimitTimeRemaining_Actual = GitHubApiStatusService.GetRateLimitTimeRemaining(validHttpResponseHeaders);

            //Assert
            Assert.Greater(rateLimitTimeRemaining_Expected, rateLimitTimeRemaining_Actual);
            Assert.Less(rateLimitTimeRemaining_Expected.Subtract(TimeSpan.FromSeconds(2)), rateLimitTimeRemaining_Actual);
        }

        [Test]
        public void GetRemainingRequestCount_InvalidHttpResponseHeaders()
        {
            //Arrange
            var invalidHttpResponseMessage = new HttpResponseMessage();

            //Act

            //Assert
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitTimeRemaining(invalidHttpResponseMessage.Headers));
        }

        [Test]
        public void GetRemainingRequestCount_NullHttpResponseHeaders()
        {
            //Arrange
            HttpResponseHeaders? nullHttpResponseHeaders = null;

            //Act

            //Assert
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitTimeRemaining(nullHttpResponseHeaders));
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
*/
namespace GitHubApiStatus.UnitTests
{
	class GetRateLimitTimeRemainingTests : BaseTest
	{
		[Test]
		public void GetRemainingRequestCount_ValidHttpResponseHeaders()
		{
			//Act
			const int rateLimit = 5000;
			TimeSpan rateLimitTimeRemaining_Actual;

			var rateLimitTimeRemaining_Expected = TimeSpan.FromMinutes(45);
			var rateLimitResetDateTime = DateTimeOffset.UtcNow.Add(rateLimitTimeRemaining_Expected);


			var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, rateLimitResetDateTime, rateLimit - 5);

			//Act
			rateLimitTimeRemaining_Actual = GitHubApiStatusService.GetRateLimitTimeRemaining(validHttpResponseHeaders);

			//Assert
			Assert.Greater(rateLimitTimeRemaining_Expected, rateLimitTimeRemaining_Actual);
			Assert.Less(rateLimitTimeRemaining_Expected.Subtract(TimeSpan.FromSeconds(2)), rateLimitTimeRemaining_Actual);
		}

		[Test]
		public void GetRemainingRequestCount_InvalidHttpResponseHeaders()
		{
			//Arrange
			var invalidHttpResponseMessage = new HttpResponseMessage();

			//Act

			//Assert
			Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitTimeRemaining(invalidHttpResponseMessage.Headers));
		}

		[Test]
		public void GetRemainingRequestCount_NullHttpResponseHeaders()
		{
			//Arrange
			HttpResponseHeaders? nullHttpResponseHeaders = null;

			//Act

			//Assert
#pragma warning disable CS8604 // Possible null reference argument.
			Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitTimeRemaining(nullHttpResponseHeaders));
#pragma warning restore CS8604 // Possible null reference argument.
		}
	}
}