using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;

namespace GitHubApiStatus.Extensions;

public sealed class MockGitHubApiStatusService(HttpClient httpClient) : IGitHubApiStatusService
{
	public bool IsProductHeaderValueValid => true;
	public bool IsAuthenticationHeaderValueSet => true;

	public Task<GitHubApiRateLimits> GetApiRateLimits(CancellationToken cancellationToken)
	{
		var apiStatus = new RateLimitStatus(5000, 5000, DateTimeOffset.UtcNow.AddMinutes(1).ToUnixTimeSeconds());
		return Task.FromResult(new GitHubApiRateLimits(apiStatus, apiStatus, apiStatus, apiStatus, apiStatus, apiStatus));
	}

	public int GetRateLimit(in HttpResponseHeaders httpResponseHeaders) => 5000;
	public int GetRemainingRequestCount(in HttpResponseHeaders httpResponseHeaders) => 5000;
	public bool HasReachedMaximumApiCallLimit(in HttpResponseHeaders httpResponseHeaders) => false;
	public bool IsResponseFromAuthenticatedRequest(in HttpResponseHeaders httpResponseHeaders) => true;
	public TimeSpan GetRateLimitTimeRemaining(in HttpResponseHeaders httpResponseHeaders) => new(1, 0, 0);
	public DateTimeOffset GetRateLimitResetDateTime(in HttpResponseHeaders httpResponseHeaders) => DateTimeOffset.UtcNow;
	public long GetRateLimitResetDateTime_UnixEpochSeconds(in HttpResponseHeaders httpResponseHeaders) => DateTimeOffset.UtcNow.AddMinutes(1).ToUnixTimeSeconds();

	public void AddProductHeaderValue(ProductHeaderValue productHeaderValue)
	{

	}

	public void SetAuthenticationHeaderValue(AuthenticationHeaderValue authenticationHeaderValue)
	{

	}

	public bool IsAbuseRateLimit(in HttpResponseHeaders httpResponseHeaders, [NotNullWhen(true)] out TimeSpan? delta)
	{
		delta = null;
		return false;
	}

	public void Dispose()
	{
		httpClient.Dispose();
	}
}