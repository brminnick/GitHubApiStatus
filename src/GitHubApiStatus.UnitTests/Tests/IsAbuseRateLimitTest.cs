using System;
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