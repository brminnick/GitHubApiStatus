using System.Net.Http;
using System.Net.Http.Headers;
using NUnit.Framework;

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

		//Assert
		Assert.Multiple(() =>
		{
			Assert.That(rateLimitResetDateTime_Expected.Second, Is.EqualTo(rateLimitResetDateTime_Actual.Second));
			Assert.That(rateLimitResetDateTime_Expected.Minute, Is.EqualTo(rateLimitResetDateTime_Actual.Minute));
			Assert.That(rateLimitResetDateTime_Expected.Hour, Is.EqualTo(rateLimitResetDateTime_Actual.Hour));
			Assert.That(rateLimitResetDateTime_Expected.DayOfYear, Is.EqualTo(rateLimitResetDateTime_Actual.DayOfYear));
			Assert.That(rateLimitResetDateTime_Expected.Year, Is.EqualTo(rateLimitResetDateTime_Actual.Year));
		});
	}

	[Test]
	public void GetRateLimitResetDateTime_InvalidHttpResponseHeaders()
	{
		//Arrange
		var invalidHttpResponseMessage = new HttpResponseMessage();

		//Act

		//Assert
		Assert.That(() => GitHubApiStatusService.GetRateLimitResetDateTime(invalidHttpResponseMessage.Headers), Throws.TypeOf<GitHubApiStatusException>());
	}

	[Test]
	public void GetRateLimitResetDateTime_NullHttpResponseHeaders()
	{
		//Arrange
		HttpResponseHeaders? nullHttpResponseHeaders = null;

		//Act

		//Assert
#pragma warning disable CS8604 // Possible null reference argument.
		Assert.That(() => GitHubApiStatusService.GetRateLimitResetDateTime(nullHttpResponseHeaders), Throws.TypeOf<GitHubApiStatusException>());
#pragma warning restore CS8604 // Possible null reference argument.
	}
}

