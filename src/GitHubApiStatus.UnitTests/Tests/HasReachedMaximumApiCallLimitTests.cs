using System;
using System.Net.Http;
using System.Net.Http.Headers;
using NUnit.Framework;


/* Unmerged change from project 'GitHubApiStatus.UnitTests(netcoreapp2.1)'
Before:
namespace GitHubApiStatus.UnitTests
{
    class HasReachedMaximumApiCallLimitTests : BaseTest
    {
        [Test]
        public void HasReachedMaximumApiCallLimitTests_ValidHttpResponseHeaders_True()
        {
            //Act
            const int rateLimit = 5000;
            const int rateLimitRemaining = 0;
            const bool hasReachedMaximumApiCallLimit_Expected = true;

            bool hasReachedMaximumApiCallLimit_Actual;

            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, DateTimeOffset.UtcNow, rateLimitRemaining);

            //Act
            hasReachedMaximumApiCallLimit_Actual = GitHubApiStatusService.HasReachedMaximimApiCallLimit(validHttpResponseHeaders);

            //Assert
            Assert.AreEqual(hasReachedMaximumApiCallLimit_Expected, hasReachedMaximumApiCallLimit_Actual);
        }

        [Test]
        public void HasReachedMaximumApiCallLimitTests_ValidHttpResponseHeaders_False()
        {
            //Act
            const int rateLimit = 5000;
            const int rateLimitRemaining = 10;
            const bool hasReachedMaximumApiCallLimit_Expected = false;

            bool hasReachedMaximumApiCallLimit_Actual;

            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, DateTimeOffset.UtcNow, rateLimitRemaining);

            //Act
            hasReachedMaximumApiCallLimit_Actual = GitHubApiStatusService.HasReachedMaximimApiCallLimit(validHttpResponseHeaders);

            //Assert
            Assert.AreEqual(hasReachedMaximumApiCallLimit_Expected, hasReachedMaximumApiCallLimit_Actual);
        }

        [Test]
        public void HasReachedMaximumApiCallLimitTests_InvalidHttpResponseHeaders()
        {
            //Arrange
            var invalidHttpResponseMessage = new HttpResponseMessage();

            //Act

            //Assert
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.HasReachedMaximimApiCallLimit(invalidHttpResponseMessage.Headers));
        }

        [Test]
        public void HasReachedMaximumApiCallLimitTests_NullHttpResponseHeaders()
        {
            //Arrange
            HttpResponseHeaders? nullHttpResponseHeaders = null;

            //Act

            //Assert
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.HasReachedMaximimApiCallLimit(nullHttpResponseHeaders));
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
After:
namespace GitHubApiStatus.UnitTests;

    class HasReachedMaximumApiCallLimitTests : BaseTest
    {
        [Test]
        public void HasReachedMaximumApiCallLimitTests_ValidHttpResponseHeaders_True()
        {
            //Act
            const int rateLimit = 5000;
            const int rateLimitRemaining = 0;
            const bool hasReachedMaximumApiCallLimit_Expected = true;

            bool hasReachedMaximumApiCallLimit_Actual;

            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, DateTimeOffset.UtcNow, rateLimitRemaining);

            //Act
            hasReachedMaximumApiCallLimit_Actual = GitHubApiStatusService.HasReachedMaximimApiCallLimit(validHttpResponseHeaders);

            //Assert
            Assert.AreEqual(hasReachedMaximumApiCallLimit_Expected, hasReachedMaximumApiCallLimit_Actual);
        }

        [Test]
        public void HasReachedMaximumApiCallLimitTests_ValidHttpResponseHeaders_False()
        {
            //Act
            const int rateLimit = 5000;
            const int rateLimitRemaining = 10;
            const bool hasReachedMaximumApiCallLimit_Expected = false;

            bool hasReachedMaximumApiCallLimit_Actual;

            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, DateTimeOffset.UtcNow, rateLimitRemaining);

            //Act
            hasReachedMaximumApiCallLimit_Actual = GitHubApiStatusService.HasReachedMaximimApiCallLimit(validHttpResponseHeaders);

            //Assert
            Assert.AreEqual(hasReachedMaximumApiCallLimit_Expected, hasReachedMaximumApiCallLimit_Actual);
        }

        [Test]
        public void HasReachedMaximumApiCallLimitTests_InvalidHttpResponseHeaders()
        {
            //Arrange
            var invalidHttpResponseMessage = new HttpResponseMessage();

            //Act

            //Assert
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.HasReachedMaximimApiCallLimit(invalidHttpResponseMessage.Headers));
        }

        [Test]
        public void HasReachedMaximumApiCallLimitTests_NullHttpResponseHeaders()
        {
            //Arrange
            HttpResponseHeaders? nullHttpResponseHeaders = null;

            //Act

            //Assert
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.HasReachedMaximimApiCallLimit(nullHttpResponseHeaders));
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
*/

/* Unmerged change from project 'GitHubApiStatus.UnitTests(netcoreapp3.1)'
Before:
namespace GitHubApiStatus.UnitTests
{
    class HasReachedMaximumApiCallLimitTests : BaseTest
    {
        [Test]
        public void HasReachedMaximumApiCallLimitTests_ValidHttpResponseHeaders_True()
        {
            //Act
            const int rateLimit = 5000;
            const int rateLimitRemaining = 0;
            const bool hasReachedMaximumApiCallLimit_Expected = true;

            bool hasReachedMaximumApiCallLimit_Actual;

            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, DateTimeOffset.UtcNow, rateLimitRemaining);

            //Act
            hasReachedMaximumApiCallLimit_Actual = GitHubApiStatusService.HasReachedMaximimApiCallLimit(validHttpResponseHeaders);

            //Assert
            Assert.AreEqual(hasReachedMaximumApiCallLimit_Expected, hasReachedMaximumApiCallLimit_Actual);
        }

        [Test]
        public void HasReachedMaximumApiCallLimitTests_ValidHttpResponseHeaders_False()
        {
            //Act
            const int rateLimit = 5000;
            const int rateLimitRemaining = 10;
            const bool hasReachedMaximumApiCallLimit_Expected = false;

            bool hasReachedMaximumApiCallLimit_Actual;

            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, DateTimeOffset.UtcNow, rateLimitRemaining);

            //Act
            hasReachedMaximumApiCallLimit_Actual = GitHubApiStatusService.HasReachedMaximimApiCallLimit(validHttpResponseHeaders);

            //Assert
            Assert.AreEqual(hasReachedMaximumApiCallLimit_Expected, hasReachedMaximumApiCallLimit_Actual);
        }

        [Test]
        public void HasReachedMaximumApiCallLimitTests_InvalidHttpResponseHeaders()
        {
            //Arrange
            var invalidHttpResponseMessage = new HttpResponseMessage();

            //Act

            //Assert
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.HasReachedMaximimApiCallLimit(invalidHttpResponseMessage.Headers));
        }

        [Test]
        public void HasReachedMaximumApiCallLimitTests_NullHttpResponseHeaders()
        {
            //Arrange
            HttpResponseHeaders? nullHttpResponseHeaders = null;

            //Act

            //Assert
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.HasReachedMaximimApiCallLimit(nullHttpResponseHeaders));
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
After:
namespace GitHubApiStatus.UnitTests;

    class HasReachedMaximumApiCallLimitTests : BaseTest
    {
        [Test]
        public void HasReachedMaximumApiCallLimitTests_ValidHttpResponseHeaders_True()
        {
            //Act
            const int rateLimit = 5000;
            const int rateLimitRemaining = 0;
            const bool hasReachedMaximumApiCallLimit_Expected = true;

            bool hasReachedMaximumApiCallLimit_Actual;

            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, DateTimeOffset.UtcNow, rateLimitRemaining);

            //Act
            hasReachedMaximumApiCallLimit_Actual = GitHubApiStatusService.HasReachedMaximimApiCallLimit(validHttpResponseHeaders);

            //Assert
            Assert.AreEqual(hasReachedMaximumApiCallLimit_Expected, hasReachedMaximumApiCallLimit_Actual);
        }

        [Test]
        public void HasReachedMaximumApiCallLimitTests_ValidHttpResponseHeaders_False()
        {
            //Act
            const int rateLimit = 5000;
            const int rateLimitRemaining = 10;
            const bool hasReachedMaximumApiCallLimit_Expected = false;

            bool hasReachedMaximumApiCallLimit_Actual;

            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, DateTimeOffset.UtcNow, rateLimitRemaining);

            //Act
            hasReachedMaximumApiCallLimit_Actual = GitHubApiStatusService.HasReachedMaximimApiCallLimit(validHttpResponseHeaders);

            //Assert
            Assert.AreEqual(hasReachedMaximumApiCallLimit_Expected, hasReachedMaximumApiCallLimit_Actual);
        }

        [Test]
        public void HasReachedMaximumApiCallLimitTests_InvalidHttpResponseHeaders()
        {
            //Arrange
            var invalidHttpResponseMessage = new HttpResponseMessage();

            //Act

            //Assert
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.HasReachedMaximimApiCallLimit(invalidHttpResponseMessage.Headers));
        }

        [Test]
        public void HasReachedMaximumApiCallLimitTests_NullHttpResponseHeaders()
        {
            //Arrange
            HttpResponseHeaders? nullHttpResponseHeaders = null;

            //Act

            //Assert
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.HasReachedMaximimApiCallLimit(nullHttpResponseHeaders));
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
*/

/* Unmerged change from project 'GitHubApiStatus.UnitTests(net5.0)'
Before:
namespace GitHubApiStatus.UnitTests
{
    class HasReachedMaximumApiCallLimitTests : BaseTest
    {
        [Test]
        public void HasReachedMaximumApiCallLimitTests_ValidHttpResponseHeaders_True()
        {
            //Act
            const int rateLimit = 5000;
            const int rateLimitRemaining = 0;
            const bool hasReachedMaximumApiCallLimit_Expected = true;

            bool hasReachedMaximumApiCallLimit_Actual;

            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, DateTimeOffset.UtcNow, rateLimitRemaining);

            //Act
            hasReachedMaximumApiCallLimit_Actual = GitHubApiStatusService.HasReachedMaximimApiCallLimit(validHttpResponseHeaders);

            //Assert
            Assert.AreEqual(hasReachedMaximumApiCallLimit_Expected, hasReachedMaximumApiCallLimit_Actual);
        }

        [Test]
        public void HasReachedMaximumApiCallLimitTests_ValidHttpResponseHeaders_False()
        {
            //Act
            const int rateLimit = 5000;
            const int rateLimitRemaining = 10;
            const bool hasReachedMaximumApiCallLimit_Expected = false;

            bool hasReachedMaximumApiCallLimit_Actual;

            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, DateTimeOffset.UtcNow, rateLimitRemaining);

            //Act
            hasReachedMaximumApiCallLimit_Actual = GitHubApiStatusService.HasReachedMaximimApiCallLimit(validHttpResponseHeaders);

            //Assert
            Assert.AreEqual(hasReachedMaximumApiCallLimit_Expected, hasReachedMaximumApiCallLimit_Actual);
        }

        [Test]
        public void HasReachedMaximumApiCallLimitTests_InvalidHttpResponseHeaders()
        {
            //Arrange
            var invalidHttpResponseMessage = new HttpResponseMessage();

            //Act

            //Assert
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.HasReachedMaximimApiCallLimit(invalidHttpResponseMessage.Headers));
        }

        [Test]
        public void HasReachedMaximumApiCallLimitTests_NullHttpResponseHeaders()
        {
            //Arrange
            HttpResponseHeaders? nullHttpResponseHeaders = null;

            //Act

            //Assert
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.HasReachedMaximimApiCallLimit(nullHttpResponseHeaders));
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
After:
namespace GitHubApiStatus.UnitTests;

    class HasReachedMaximumApiCallLimitTests : BaseTest
    {
        [Test]
        public void HasReachedMaximumApiCallLimitTests_ValidHttpResponseHeaders_True()
        {
            //Act
            const int rateLimit = 5000;
            const int rateLimitRemaining = 0;
            const bool hasReachedMaximumApiCallLimit_Expected = true;

            bool hasReachedMaximumApiCallLimit_Actual;

            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, DateTimeOffset.UtcNow, rateLimitRemaining);

            //Act
            hasReachedMaximumApiCallLimit_Actual = GitHubApiStatusService.HasReachedMaximimApiCallLimit(validHttpResponseHeaders);

            //Assert
            Assert.AreEqual(hasReachedMaximumApiCallLimit_Expected, hasReachedMaximumApiCallLimit_Actual);
        }

        [Test]
        public void HasReachedMaximumApiCallLimitTests_ValidHttpResponseHeaders_False()
        {
            //Act
            const int rateLimit = 5000;
            const int rateLimitRemaining = 10;
            const bool hasReachedMaximumApiCallLimit_Expected = false;

            bool hasReachedMaximumApiCallLimit_Actual;

            var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, DateTimeOffset.UtcNow, rateLimitRemaining);

            //Act
            hasReachedMaximumApiCallLimit_Actual = GitHubApiStatusService.HasReachedMaximimApiCallLimit(validHttpResponseHeaders);

            //Assert
            Assert.AreEqual(hasReachedMaximumApiCallLimit_Expected, hasReachedMaximumApiCallLimit_Actual);
        }

        [Test]
        public void HasReachedMaximumApiCallLimitTests_InvalidHttpResponseHeaders()
        {
            //Arrange
            var invalidHttpResponseMessage = new HttpResponseMessage();

            //Act

            //Assert
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.HasReachedMaximimApiCallLimit(invalidHttpResponseMessage.Headers));
        }

        [Test]
        public void HasReachedMaximumApiCallLimitTests_NullHttpResponseHeaders()
        {
            //Arrange
            HttpResponseHeaders? nullHttpResponseHeaders = null;

            //Act

            //Assert
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.HasReachedMaximimApiCallLimit(nullHttpResponseHeaders));
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
*/
namespace GitHubApiStatus.UnitTests
{
	class HasReachedMaximumApiCallLimitTests : BaseTest
	{
		[Test]
		public void HasReachedMaximumApiCallLimitTests_ValidHttpResponseHeaders_True()
		{
			//Act
			const int rateLimit = 5000;
			const int rateLimitRemaining = 0;
			const bool hasReachedMaximumApiCallLimit_Expected = true;

			bool hasReachedMaximumApiCallLimit_Actual;

			var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, DateTimeOffset.UtcNow, rateLimitRemaining);

			//Act
			hasReachedMaximumApiCallLimit_Actual = GitHubApiStatusService.HasReachedMaximimApiCallLimit(validHttpResponseHeaders);

			//Assert
			Assert.AreEqual(hasReachedMaximumApiCallLimit_Expected, hasReachedMaximumApiCallLimit_Actual);
		}

		[Test]
		public void HasReachedMaximumApiCallLimitTests_ValidHttpResponseHeaders_False()
		{
			//Act
			const int rateLimit = 5000;
			const int rateLimitRemaining = 10;
			const bool hasReachedMaximumApiCallLimit_Expected = false;

			bool hasReachedMaximumApiCallLimit_Actual;

			var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit, DateTimeOffset.UtcNow, rateLimitRemaining);

			//Act
			hasReachedMaximumApiCallLimit_Actual = GitHubApiStatusService.HasReachedMaximimApiCallLimit(validHttpResponseHeaders);

			//Assert
			Assert.AreEqual(hasReachedMaximumApiCallLimit_Expected, hasReachedMaximumApiCallLimit_Actual);
		}

		[Test]
		public void HasReachedMaximumApiCallLimitTests_InvalidHttpResponseHeaders()
		{
			//Arrange
			var invalidHttpResponseMessage = new HttpResponseMessage();

			//Act

			//Assert
			Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.HasReachedMaximimApiCallLimit(invalidHttpResponseMessage.Headers));
		}

		[Test]
		public void HasReachedMaximumApiCallLimitTests_NullHttpResponseHeaders()
		{
			//Arrange
			HttpResponseHeaders? nullHttpResponseHeaders = null;

			//Act

			//Assert
#pragma warning disable CS8604 // Possible null reference argument.
			Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.HasReachedMaximimApiCallLimit(nullHttpResponseHeaders));
#pragma warning restore CS8604 // Possible null reference argument.
		}
	}
}