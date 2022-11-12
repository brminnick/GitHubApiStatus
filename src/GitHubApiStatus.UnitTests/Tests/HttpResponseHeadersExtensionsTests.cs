using System;
using System.Net.Http;
using NUnit.Framework;

namespace GitHubApiStatus.UnitTests;

class HttpResponseHeadersExtensionsTests : BaseTest
{
	[Test]
	public void DoesContainGitHubRateLimitHeaderTest()
	{
		//Arrange
		bool doesContainGitHubRateLimitHeader_true, doesContainGitHubRateLimitHeader_false;

		var validHttpResponseHeaders = CreateHttpResponseHeaders(500, DateTimeOffset.UtcNow.AddHours(1), 450);
		var invalidHttpResponseHeaders = new HttpResponseMessage().Headers;

		//Act
		doesContainGitHubRateLimitHeader_true = validHttpResponseHeaders.DoesContainGitHubRateLimitHeader();
		doesContainGitHubRateLimitHeader_false = invalidHttpResponseHeaders.DoesContainGitHubRateLimitHeader();

		//Assert
		Assert.IsTrue(doesContainGitHubRateLimitHeader_true);
		Assert.IsFalse(doesContainGitHubRateLimitHeader_false);
	}

	[Test]
	public void DoesContainGitHubRateLimitResetHeaderTest()
	{
		//Arrange
		bool doesContainGitHubRateLimitResetHeader_true, doesContainGitHubRateLimitResetHeader_false;

		var validHttpResponseHeaders = CreateHttpResponseHeaders(500, DateTimeOffset.UtcNow.AddHours(1), 450);
		var invalidHttpResponseHeaders = new HttpResponseMessage().Headers;

		//Act
		doesContainGitHubRateLimitResetHeader_true = validHttpResponseHeaders.DoesContainGitHubRateLimitResetHeader();
		doesContainGitHubRateLimitResetHeader_false = invalidHttpResponseHeaders.DoesContainGitHubRateLimitResetHeader();

		//Assert
		Assert.IsTrue(doesContainGitHubRateLimitResetHeader_true);
		Assert.IsFalse(doesContainGitHubRateLimitResetHeader_false);
	}

	[Test]
	public void DoesContainGitHubRateLimitRemainingHeaderTest()
	{
		//Arrange
		bool doesContainGitHubRateLimitRemainingHeader_true, doesContainGitHubRateLimitRemainingHeader_false;

		var validHttpResponseHeaders = CreateHttpResponseHeaders(500, DateTimeOffset.UtcNow.AddHours(1), 450);
		var invalidHttpResponseHeaders = new HttpResponseMessage().Headers;

		//Act
		doesContainGitHubRateLimitRemainingHeader_true = validHttpResponseHeaders.DoesContainGitHubRateLimitRemainingHeader();
		doesContainGitHubRateLimitRemainingHeader_false = invalidHttpResponseHeaders.DoesContainGitHubRateLimitRemainingHeader();

		//Assert
		Assert.IsTrue(doesContainGitHubRateLimitRemainingHeader_true);
		Assert.IsFalse(doesContainGitHubRateLimitRemainingHeader_false);
	}
}