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
		Assert.Multiple(() =>
		{
			Assert.That(doesContainGitHubRateLimitHeader_true, Is.True);
			Assert.That(doesContainGitHubRateLimitHeader_false, Is.False);
		});
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
		Assert.Multiple(() =>
		{
			Assert.That(doesContainGitHubRateLimitResetHeader_true, Is.True);
			Assert.That(doesContainGitHubRateLimitResetHeader_false, Is.False);
		});
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
		Assert.Multiple(() =>
		{
			Assert.That(doesContainGitHubRateLimitRemainingHeader_true, Is.True);
			Assert.That(doesContainGitHubRateLimitRemainingHeader_false, Is.False);
		});
	}
}



