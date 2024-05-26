using System.Net.Http;
using System.Net.Http.Headers;
using NUnit.Framework;

namespace GitHubApiStatus.UnitTests;

class GetRateLimitTests : BaseTest
{
	[Test]
	public void GetRateLimit_ValidHttpResponseHeaders()
	{
		//Act
		const int rateLimit_Expected = 5000;
		int rateLimit_Actual;

		var validHttpResponseHeaders = CreateHttpResponseHeaders(rateLimit_Expected, DateTimeOffset.UtcNow, rateLimit_Expected - 5);

		//Act
		rateLimit_Actual = GitHubApiStatusService.GetRateLimit(validHttpResponseHeaders);

		//Assert
		Assert.AreEqual(rateLimit_Expected, rateLimit_Actual);
	}

	[Test]
	public void GetRateLimit_InvalidHttpResponseHeaders()
	{
		//Arrange
		var invalidHttpResponseMessage = new HttpResponseMessage();

		//Act

		//Assert
		Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimit(invalidHttpResponseMessage.Headers));
	}

	[Test]
	public void GetRateLimit_NullHttpResponseHeaders()
	{
		//Arrange
		HttpResponseHeaders? nullHttpResponseHeaders = null;

		//Act

		//Assert
#pragma warning disable CS8604 // Possible null reference argument.
		Assert.Throws<GitHubApiStatusException>(() => GitHubApiStatusService.GetRateLimit(nullHttpResponseHeaders));
#pragma warning restore CS8604 // Possible null reference argument.
	}
}