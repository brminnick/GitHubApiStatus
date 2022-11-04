using System;
using System.Net.Http;
using System.Net.Http.Headers;
using NUnit.Framework;


/* Unmerged change from project 'GitHubApiStatus.UnitTests(netcoreapp2.1)'
Before:
namespace GitHubApiStatus.UnitTests
{
    class GetRateLimitRestDateTimeTests : BaseTest
    {
        [Test]
        public void GetRateLimitResetDateTime_ValidHttpResponseHeaders()
        {
            //Act
            DateTimeOffset rateLimitResetDateTime_Actual;

            const int rateLimit = 5000;
            var rateLimitResetDateTime_Expected = DateTime.UtcNow.Add(TimeSpan.FromMinutes(20));

            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, rateLimitResetDateTime_Expected, rateLimit - 5);

            //Act
            rateLimitResetDateTime_Actual = GitHubApiStatusService.GetRateLimitResetDateTime(validHttpResponseHeaders);

            //Assert Test all values except Milliseconds, because GitHub API 
            Assert.AreEqual(rateLimitResetDateTime_Expected.Second, rateLimitResetDateTime_Actual.Second);
            Assert.AreEqual(rateLimitResetDateTime_Expected.Minute, rateLimitResetDateTime_Actual.Minute);
            Assert.AreEqual(rateLimitResetDateTime_Expected.Hour, rateLimitResetDateTime_Actual.Hour);
            Assert.AreEqual(rateLimitResetDateTime_Expected.DayOfYear, rateLimitResetDateTime_Actual.DayOfYear);
            Assert.AreEqual(rateLimitResetDateTime_Expected.Year, rateLimitResetDateTime_Actual.Year);
        }

        [Test]
        public void GetRateLimitResetDateTime_InvalidHttpResponseHeaders()
        {
            //Arrange
            var invalidHttpResponseMessage = new HttpResponseMessage();

            //Act

            //Assert
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitResetDateTime(invalidHttpResponseMessage.Headers));
        }

        [Test]
        public void GetRateLimitResetDateTime_NullHttpResponseHeaders()
        {
            //Arrange
            HttpResponseHeaders? nullHttpResponseHeaders = null;

            //Act

            //Assert
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitResetDateTime(nullHttpResponseHeaders));
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
After:
namespace GitHubApiStatus.UnitTests;

    class GetRateLimitRestDateTimeTests : BaseTest
    {
        [Test]
        public void GetRateLimitResetDateTime_ValidHttpResponseHeaders()
        {
            //Act
            DateTimeOffset rateLimitResetDateTime_Actual;

            const int rateLimit = 5000;
            var rateLimitResetDateTime_Expected = DateTime.UtcNow.Add(TimeSpan.FromMinutes(20));

            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, rateLimitResetDateTime_Expected, rateLimit - 5);

            //Act
            rateLimitResetDateTime_Actual = GitHubApiStatusService.GetRateLimitResetDateTime(validHttpResponseHeaders);

            //Assert Test all values except Milliseconds, because GitHub API 
            Assert.AreEqual(rateLimitResetDateTime_Expected.Second, rateLimitResetDateTime_Actual.Second);
            Assert.AreEqual(rateLimitResetDateTime_Expected.Minute, rateLimitResetDateTime_Actual.Minute);
            Assert.AreEqual(rateLimitResetDateTime_Expected.Hour, rateLimitResetDateTime_Actual.Hour);
            Assert.AreEqual(rateLimitResetDateTime_Expected.DayOfYear, rateLimitResetDateTime_Actual.DayOfYear);
            Assert.AreEqual(rateLimitResetDateTime_Expected.Year, rateLimitResetDateTime_Actual.Year);
        }

        [Test]
        public void GetRateLimitResetDateTime_InvalidHttpResponseHeaders()
        {
            //Arrange
            var invalidHttpResponseMessage = new HttpResponseMessage();

            //Act

            //Assert
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitResetDateTime(invalidHttpResponseMessage.Headers));
        }

        [Test]
        public void GetRateLimitResetDateTime_NullHttpResponseHeaders()
        {
            //Arrange
            HttpResponseHeaders? nullHttpResponseHeaders = null;

            //Act

            //Assert
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitResetDateTime(nullHttpResponseHeaders));
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
*/

/* Unmerged change from project 'GitHubApiStatus.UnitTests(netcoreapp3.1)'
Before:
namespace GitHubApiStatus.UnitTests
{
    class GetRateLimitRestDateTimeTests : BaseTest
    {
        [Test]
        public void GetRateLimitResetDateTime_ValidHttpResponseHeaders()
        {
            //Act
            DateTimeOffset rateLimitResetDateTime_Actual;

            const int rateLimit = 5000;
            var rateLimitResetDateTime_Expected = DateTime.UtcNow.Add(TimeSpan.FromMinutes(20));

            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, rateLimitResetDateTime_Expected, rateLimit - 5);

            //Act
            rateLimitResetDateTime_Actual = GitHubApiStatusService.GetRateLimitResetDateTime(validHttpResponseHeaders);

            //Assert Test all values except Milliseconds, because GitHub API 
            Assert.AreEqual(rateLimitResetDateTime_Expected.Second, rateLimitResetDateTime_Actual.Second);
            Assert.AreEqual(rateLimitResetDateTime_Expected.Minute, rateLimitResetDateTime_Actual.Minute);
            Assert.AreEqual(rateLimitResetDateTime_Expected.Hour, rateLimitResetDateTime_Actual.Hour);
            Assert.AreEqual(rateLimitResetDateTime_Expected.DayOfYear, rateLimitResetDateTime_Actual.DayOfYear);
            Assert.AreEqual(rateLimitResetDateTime_Expected.Year, rateLimitResetDateTime_Actual.Year);
        }

        [Test]
        public void GetRateLimitResetDateTime_InvalidHttpResponseHeaders()
        {
            //Arrange
            var invalidHttpResponseMessage = new HttpResponseMessage();

            //Act

            //Assert
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitResetDateTime(invalidHttpResponseMessage.Headers));
        }

        [Test]
        public void GetRateLimitResetDateTime_NullHttpResponseHeaders()
        {
            //Arrange
            HttpResponseHeaders? nullHttpResponseHeaders = null;

            //Act

            //Assert
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitResetDateTime(nullHttpResponseHeaders));
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
After:
namespace GitHubApiStatus.UnitTests;

    class GetRateLimitRestDateTimeTests : BaseTest
    {
        [Test]
        public void GetRateLimitResetDateTime_ValidHttpResponseHeaders()
        {
            //Act
            DateTimeOffset rateLimitResetDateTime_Actual;

            const int rateLimit = 5000;
            var rateLimitResetDateTime_Expected = DateTime.UtcNow.Add(TimeSpan.FromMinutes(20));

            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, rateLimitResetDateTime_Expected, rateLimit - 5);

            //Act
            rateLimitResetDateTime_Actual = GitHubApiStatusService.GetRateLimitResetDateTime(validHttpResponseHeaders);

            //Assert Test all values except Milliseconds, because GitHub API 
            Assert.AreEqual(rateLimitResetDateTime_Expected.Second, rateLimitResetDateTime_Actual.Second);
            Assert.AreEqual(rateLimitResetDateTime_Expected.Minute, rateLimitResetDateTime_Actual.Minute);
            Assert.AreEqual(rateLimitResetDateTime_Expected.Hour, rateLimitResetDateTime_Actual.Hour);
            Assert.AreEqual(rateLimitResetDateTime_Expected.DayOfYear, rateLimitResetDateTime_Actual.DayOfYear);
            Assert.AreEqual(rateLimitResetDateTime_Expected.Year, rateLimitResetDateTime_Actual.Year);
        }

        [Test]
        public void GetRateLimitResetDateTime_InvalidHttpResponseHeaders()
        {
            //Arrange
            var invalidHttpResponseMessage = new HttpResponseMessage();

            //Act

            //Assert
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitResetDateTime(invalidHttpResponseMessage.Headers));
        }

        [Test]
        public void GetRateLimitResetDateTime_NullHttpResponseHeaders()
        {
            //Arrange
            HttpResponseHeaders? nullHttpResponseHeaders = null;

            //Act

            //Assert
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitResetDateTime(nullHttpResponseHeaders));
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
*/

/* Unmerged change from project 'GitHubApiStatus.UnitTests(net5.0)'
Before:
namespace GitHubApiStatus.UnitTests
{
    class GetRateLimitRestDateTimeTests : BaseTest
    {
        [Test]
        public void GetRateLimitResetDateTime_ValidHttpResponseHeaders()
        {
            //Act
            DateTimeOffset rateLimitResetDateTime_Actual;

            const int rateLimit = 5000;
            var rateLimitResetDateTime_Expected = DateTime.UtcNow.Add(TimeSpan.FromMinutes(20));

            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, rateLimitResetDateTime_Expected, rateLimit - 5);

            //Act
            rateLimitResetDateTime_Actual = GitHubApiStatusService.GetRateLimitResetDateTime(validHttpResponseHeaders);

            //Assert Test all values except Milliseconds, because GitHub API 
            Assert.AreEqual(rateLimitResetDateTime_Expected.Second, rateLimitResetDateTime_Actual.Second);
            Assert.AreEqual(rateLimitResetDateTime_Expected.Minute, rateLimitResetDateTime_Actual.Minute);
            Assert.AreEqual(rateLimitResetDateTime_Expected.Hour, rateLimitResetDateTime_Actual.Hour);
            Assert.AreEqual(rateLimitResetDateTime_Expected.DayOfYear, rateLimitResetDateTime_Actual.DayOfYear);
            Assert.AreEqual(rateLimitResetDateTime_Expected.Year, rateLimitResetDateTime_Actual.Year);
        }

        [Test]
        public void GetRateLimitResetDateTime_InvalidHttpResponseHeaders()
        {
            //Arrange
            var invalidHttpResponseMessage = new HttpResponseMessage();

            //Act

            //Assert
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitResetDateTime(invalidHttpResponseMessage.Headers));
        }

        [Test]
        public void GetRateLimitResetDateTime_NullHttpResponseHeaders()
        {
            //Arrange
            HttpResponseHeaders? nullHttpResponseHeaders = null;

            //Act

            //Assert
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitResetDateTime(nullHttpResponseHeaders));
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
After:
namespace GitHubApiStatus.UnitTests;

    class GetRateLimitRestDateTimeTests : BaseTest
    {
        [Test]
        public void GetRateLimitResetDateTime_ValidHttpResponseHeaders()
        {
            //Act
            DateTimeOffset rateLimitResetDateTime_Actual;

            const int rateLimit = 5000;
            var rateLimitResetDateTime_Expected = DateTime.UtcNow.Add(TimeSpan.FromMinutes(20));

            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, rateLimitResetDateTime_Expected, rateLimit - 5);

            //Act
            rateLimitResetDateTime_Actual = GitHubApiStatusService.GetRateLimitResetDateTime(validHttpResponseHeaders);

            //Assert Test all values except Milliseconds, because GitHub API 
            Assert.AreEqual(rateLimitResetDateTime_Expected.Second, rateLimitResetDateTime_Actual.Second);
            Assert.AreEqual(rateLimitResetDateTime_Expected.Minute, rateLimitResetDateTime_Actual.Minute);
            Assert.AreEqual(rateLimitResetDateTime_Expected.Hour, rateLimitResetDateTime_Actual.Hour);
            Assert.AreEqual(rateLimitResetDateTime_Expected.DayOfYear, rateLimitResetDateTime_Actual.DayOfYear);
            Assert.AreEqual(rateLimitResetDateTime_Expected.Year, rateLimitResetDateTime_Actual.Year);
        }

        [Test]
        public void GetRateLimitResetDateTime_InvalidHttpResponseHeaders()
        {
            //Arrange
            var invalidHttpResponseMessage = new HttpResponseMessage();

            //Act

            //Assert
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitResetDateTime(invalidHttpResponseMessage.Headers));
        }

        [Test]
        public void GetRateLimitResetDateTime_NullHttpResponseHeaders()
        {
            //Arrange
            HttpResponseHeaders? nullHttpResponseHeaders = null;

            //Act

            //Assert
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitResetDateTime(nullHttpResponseHeaders));
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
*/
namespace GitHubApiStatus.UnitTests
{
	class GetRateLimitRestDateTimeTests : BaseTest
	{
		[Test]
		public void GetRateLimitResetDateTime_ValidHttpResponseHeaders()
		{
			//Act
			DateTimeOffset rateLimitResetDateTime_Actual;

			const int rateLimit = 5000;
			var rateLimitResetDateTime_Expected = DateTime.UtcNow.Add(TimeSpan.FromMinutes(20));

			var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, rateLimitResetDateTime_Expected, rateLimit - 5);

			//Act
			rateLimitResetDateTime_Actual = GitHubApiStatusService.GetRateLimitResetDateTime(validHttpResponseHeaders);

			//Assert Test all values except Milliseconds, because GitHub API 
			Assert.AreEqual(rateLimitResetDateTime_Expected.Second, rateLimitResetDateTime_Actual.Second);
			Assert.AreEqual(rateLimitResetDateTime_Expected.Minute, rateLimitResetDateTime_Actual.Minute);
			Assert.AreEqual(rateLimitResetDateTime_Expected.Hour, rateLimitResetDateTime_Actual.Hour);
			Assert.AreEqual(rateLimitResetDateTime_Expected.DayOfYear, rateLimitResetDateTime_Actual.DayOfYear);
			Assert.AreEqual(rateLimitResetDateTime_Expected.Year, rateLimitResetDateTime_Actual.Year);
		}

		[Test]
		public void GetRateLimitResetDateTime_InvalidHttpResponseHeaders()
		{
			//Arrange
			var invalidHttpResponseMessage = new HttpResponseMessage();

			//Act

			//Assert
			Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitResetDateTime(invalidHttpResponseMessage.Headers));
		}

		[Test]
		public void GetRateLimitResetDateTime_NullHttpResponseHeaders()
		{
			//Arrange
			HttpResponseHeaders? nullHttpResponseHeaders = null;

			//Act

			//Assert
#pragma warning disable CS8604 // Possible null reference argument.
			Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimitResetDateTime(nullHttpResponseHeaders));
#pragma warning restore CS8604 // Possible null reference argument.
		}
	}
}