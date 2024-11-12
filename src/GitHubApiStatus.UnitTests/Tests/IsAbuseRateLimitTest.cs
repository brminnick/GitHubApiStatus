using NUnit.Framework;

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
		Assert.Multiple(() =>
		{
			Assert.That(isAbuseRateLimit, Is.True);
			Assert.That(delta, Is.Not.Null);
		});
	}

	[Test]
	public void IsNotAbuseRateLimit()
	{
		//Arrange
		var httpResponseHeaders = CreateHttpResponseHeaders(500, DateTimeOffset.UtcNow, 0);

		//Act
		var isAbuseRateLimit = GitHubApiStatusService.IsAbuseRateLimit(httpResponseHeaders, out TimeSpan? delta);

		//Assert
		Assert.Multiple(() =>
		{
			Assert.That(isAbuseRateLimit, Is.False);
			Assert.That(delta, Is.Null);
		});
	}

	[Test]
	public void NullHttpResponseHeaders()
	{
		//Arrange

		//Act

		//Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
		Assert.That(() => GitHubApiStatusService.IsAbuseRateLimit(null, out _), Throws.TypeOf<GitHubApiStatusException>());
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
	}
}




