using System.Net.Http;
using System.Net.Http.Headers;
using NUnit.Framework;

namespace GitHubApiStatus.UnitTests;

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
		remainingRequestCount_Actual = GitHubApiStatusService.GetRemainingRequestCount(validHttpResponseHeaders);

		//Assert
		Assert.That(remainingRequestCount_Actual, Is.EqualTo(remainingRequestCount_Expected));
	}

	[Test]
	public void GetRemainingRequestCount_InvalidHttpResponseHeaders()
	{
		//Arrange
		var invalidHttpResponseMessage = new HttpResponseMessage();

		//Act

		//Assert
		Assert.That(() => GitHubApiStatusService.GetRemainingRequestCount(invalidHttpResponseMessage.Headers), Throws.TypeOf<GitHubApiStatusException>());
	}

	[Test]
	public void GetRemainingRequestCount_NullHttpResponseHeaders()
	{
		//Arrange
		HttpResponseHeaders? nullHttpResponseHeaders = null;

		//Act

		//Assert
#pragma warning disable CS8604 // Possible null reference argument.
		Assert.That(() => GitHubApiStatusService.GetRemainingRequestCount(nullHttpResponseHeaders), Throws.TypeOf<GitHubApiStatusException>());
#pragma warning restore CS8604 // Possible null reference argument.
	}
}


