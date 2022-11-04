using System;
using NUnit.Framework;


/* Unmerged change from project 'GitHubApiStatus.UnitTests(netcoreapp2.1)'
Before:
namespace GitHubApiStatus.UnitTests
{
    class IsAbuseRateLimitTest : BaseTest
    {
        [Test]
        public void IsAbuseRateLimit()
        {
            //Arrange
            var httpResponseHeaders = CreateHttpResponseHeaders(500, DateTimeOffset.UtcNow, 0, isAbuseRateLimit: true);

            //Act
            var isAbuseRateLimit = GitHubApiStatusService.IsAbuseRateLimit(httpResponseHeaders, out var delta);

            //Assert
            Assert.IsTrue(isAbuseRateLimit);
            Assert.IsNotNull(delta);
        }

        [Test]
        public void IsNotAbuseRateLimit()
        {
            //Arrange
            var httpResponseHeaders = CreateHttpResponseHeaders(500, DateTimeOffset.UtcNow, 0);

            //Act
            var isAbuseRateLimit = GitHubApiStatusService.IsAbuseRateLimit(httpResponseHeaders, out TimeSpan? delta);

            //Assert
            Assert.IsFalse(isAbuseRateLimit);
            Assert.IsNull(delta);
        }

        [Test]
        public void NullHttpResponseHeaders()
        {
            //Arrange

            //Act

            //Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.IsAbuseRateLimit(null, out _));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }
    }
}
After:
namespace GitHubApiStatus.UnitTests;

    class IsAbuseRateLimitTest : BaseTest
    {
        [Test]
        public void IsAbuseRateLimit()
        {
            //Arrange
            var httpResponseHeaders = CreateHttpResponseHeaders(500, DateTimeOffset.UtcNow, 0, isAbuseRateLimit: true);

            //Act
            var isAbuseRateLimit = GitHubApiStatusService.IsAbuseRateLimit(httpResponseHeaders, out var delta);

            //Assert
            Assert.IsTrue(isAbuseRateLimit);
            Assert.IsNotNull(delta);
        }

        [Test]
        public void IsNotAbuseRateLimit()
        {
            //Arrange
            var httpResponseHeaders = CreateHttpResponseHeaders(500, DateTimeOffset.UtcNow, 0);

            //Act
            var isAbuseRateLimit = GitHubApiStatusService.IsAbuseRateLimit(httpResponseHeaders, out TimeSpan? delta);

            //Assert
            Assert.IsFalse(isAbuseRateLimit);
            Assert.IsNull(delta);
        }

        [Test]
        public void NullHttpResponseHeaders()
        {
            //Arrange

            //Act

            //Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.IsAbuseRateLimit(null, out _));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }
    }
*/

/* Unmerged change from project 'GitHubApiStatus.UnitTests(netcoreapp3.1)'
Before:
namespace GitHubApiStatus.UnitTests
{
    class IsAbuseRateLimitTest : BaseTest
    {
        [Test]
        public void IsAbuseRateLimit()
        {
            //Arrange
            var httpResponseHeaders = CreateHttpResponseHeaders(500, DateTimeOffset.UtcNow, 0, isAbuseRateLimit: true);

            //Act
            var isAbuseRateLimit = GitHubApiStatusService.IsAbuseRateLimit(httpResponseHeaders, out var delta);

            //Assert
            Assert.IsTrue(isAbuseRateLimit);
            Assert.IsNotNull(delta);
        }

        [Test]
        public void IsNotAbuseRateLimit()
        {
            //Arrange
            var httpResponseHeaders = CreateHttpResponseHeaders(500, DateTimeOffset.UtcNow, 0);

            //Act
            var isAbuseRateLimit = GitHubApiStatusService.IsAbuseRateLimit(httpResponseHeaders, out TimeSpan? delta);

            //Assert
            Assert.IsFalse(isAbuseRateLimit);
            Assert.IsNull(delta);
        }

        [Test]
        public void NullHttpResponseHeaders()
        {
            //Arrange

            //Act

            //Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.IsAbuseRateLimit(null, out _));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }
    }
}
After:
namespace GitHubApiStatus.UnitTests;

    class IsAbuseRateLimitTest : BaseTest
    {
        [Test]
        public void IsAbuseRateLimit()
        {
            //Arrange
            var httpResponseHeaders = CreateHttpResponseHeaders(500, DateTimeOffset.UtcNow, 0, isAbuseRateLimit: true);

            //Act
            var isAbuseRateLimit = GitHubApiStatusService.IsAbuseRateLimit(httpResponseHeaders, out var delta);

            //Assert
            Assert.IsTrue(isAbuseRateLimit);
            Assert.IsNotNull(delta);
        }

        [Test]
        public void IsNotAbuseRateLimit()
        {
            //Arrange
            var httpResponseHeaders = CreateHttpResponseHeaders(500, DateTimeOffset.UtcNow, 0);

            //Act
            var isAbuseRateLimit = GitHubApiStatusService.IsAbuseRateLimit(httpResponseHeaders, out TimeSpan? delta);

            //Assert
            Assert.IsFalse(isAbuseRateLimit);
            Assert.IsNull(delta);
        }

        [Test]
        public void NullHttpResponseHeaders()
        {
            //Arrange

            //Act

            //Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.IsAbuseRateLimit(null, out _));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }
    }
*/

/* Unmerged change from project 'GitHubApiStatus.UnitTests(net5.0)'
Before:
namespace GitHubApiStatus.UnitTests
{
    class IsAbuseRateLimitTest : BaseTest
    {
        [Test]
        public void IsAbuseRateLimit()
        {
            //Arrange
            var httpResponseHeaders = CreateHttpResponseHeaders(500, DateTimeOffset.UtcNow, 0, isAbuseRateLimit: true);

            //Act
            var isAbuseRateLimit = GitHubApiStatusService.IsAbuseRateLimit(httpResponseHeaders, out var delta);

            //Assert
            Assert.IsTrue(isAbuseRateLimit);
            Assert.IsNotNull(delta);
        }

        [Test]
        public void IsNotAbuseRateLimit()
        {
            //Arrange
            var httpResponseHeaders = CreateHttpResponseHeaders(500, DateTimeOffset.UtcNow, 0);

            //Act
            var isAbuseRateLimit = GitHubApiStatusService.IsAbuseRateLimit(httpResponseHeaders, out TimeSpan? delta);

            //Assert
            Assert.IsFalse(isAbuseRateLimit);
            Assert.IsNull(delta);
        }

        [Test]
        public void NullHttpResponseHeaders()
        {
            //Arrange

            //Act

            //Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.IsAbuseRateLimit(null, out _));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }
    }
}
After:
namespace GitHubApiStatus.UnitTests;

    class IsAbuseRateLimitTest : BaseTest
    {
        [Test]
        public void IsAbuseRateLimit()
        {
            //Arrange
            var httpResponseHeaders = CreateHttpResponseHeaders(500, DateTimeOffset.UtcNow, 0, isAbuseRateLimit: true);

            //Act
            var isAbuseRateLimit = GitHubApiStatusService.IsAbuseRateLimit(httpResponseHeaders, out var delta);

            //Assert
            Assert.IsTrue(isAbuseRateLimit);
            Assert.IsNotNull(delta);
        }

        [Test]
        public void IsNotAbuseRateLimit()
        {
            //Arrange
            var httpResponseHeaders = CreateHttpResponseHeaders(500, DateTimeOffset.UtcNow, 0);

            //Act
            var isAbuseRateLimit = GitHubApiStatusService.IsAbuseRateLimit(httpResponseHeaders, out TimeSpan? delta);

            //Assert
            Assert.IsFalse(isAbuseRateLimit);
            Assert.IsNull(delta);
        }

        [Test]
        public void NullHttpResponseHeaders()
        {
            //Arrange

            //Act

            //Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.IsAbuseRateLimit(null, out _));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }
    }
*/
namespace GitHubApiStatus.UnitTests
{
	class IsAbuseRateLimitTest : BaseTest
	{
		[Test]
		public void IsAbuseRateLimit()
		{
			//Arrange
			var httpResponseHeaders = CreateHttpResponseHeaders(500, DateTimeOffset.UtcNow, 0, isAbuseRateLimit: true);

			//Act
			var isAbuseRateLimit = GitHubApiStatusService.IsAbuseRateLimit(httpResponseHeaders, out var delta);

			//Assert
			Assert.IsTrue(isAbuseRateLimit);
			Assert.IsNotNull(delta);
		}

		[Test]
		public void IsNotAbuseRateLimit()
		{
			//Arrange
			var httpResponseHeaders = CreateHttpResponseHeaders(500, DateTimeOffset.UtcNow, 0);

			//Act
			var isAbuseRateLimit = GitHubApiStatusService.IsAbuseRateLimit(httpResponseHeaders, out TimeSpan? delta);

			//Assert
			Assert.IsFalse(isAbuseRateLimit);
			Assert.IsNull(delta);
		}

		[Test]
		public void NullHttpResponseHeaders()
		{
			//Arrange

			//Act

			//Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
			Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.IsAbuseRateLimit(null, out _));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
		}
	}
}