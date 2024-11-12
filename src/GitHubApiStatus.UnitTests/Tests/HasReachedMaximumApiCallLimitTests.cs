using System.Net.Http;
using System.Net.Http.Headers;
using NUnit.Framework;

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
		hasReachedMaximumApiCallLimit_Actual = GitHubApiStatusService.HasReachedMaximumApiCallLimit(validHttpResponseHeaders);

		//Assert
		Assert.That(hasReachedMaximumApiCallLimit_Actual, Is.EqualTo(hasReachedMaximumApiCallLimit_Expected));
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
		hasReachedMaximumApiCallLimit_Actual = GitHubApiStatusService.HasReachedMaximumApiCallLimit(validHttpResponseHeaders);

		//Assert
		Assert.That(hasReachedMaximumApiCallLimit_Actual, Is.EqualTo(hasReachedMaximumApiCallLimit_Expected));
	}

	[Test]
	public void HasReachedMaximumApiCallLimitTests_InvalidHttpResponseHeaders()
	{
		//Arrange
		var invalidHttpResponseMessage = new HttpResponseMessage();

		//Act

		//Assert
		Assert.That(() => GitHubApiStatusService.HasReachedMaximumApiCallLimit(invalidHttpResponseMessage.Headers), Throws.TypeOf<GitHubApiStatusException>());
	}

	[Test]
	public void HasReachedMaximumApiCallLimitTests_NullHttpResponseHeaders()
	{
		//Arrange
		HttpResponseHeaders? nullHttpResponseHeaders = null;

		//Act

		//Assert
#pragma warning disable CS8604 // Possible null reference argument.
		Assert.That(() => GitHubApiStatusService.HasReachedMaximumApiCallLimit(nullHttpResponseHeaders), Throws.TypeOf<GitHubApiStatusException>());
#pragma warning restore CS8604 // Possible null reference argument.
	}
}



