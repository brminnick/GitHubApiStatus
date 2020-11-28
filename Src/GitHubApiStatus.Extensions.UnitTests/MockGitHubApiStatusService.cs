using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace GitHubApiStatus.Extensions
{
    public class MockGitHubApiStatusService : IGitHubApiStatusService
    {
        public MockGitHubApiStatusService(HttpClient httpClient)
        {

        }

        public bool IsProductHeaderValueValid => true;
        public bool IsAuthenticationHeaderValueSet => true;

        public Task<GitHubApiRateLimits> GetApiRateLimits(CancellationToken cancellationToken)
        {
            var apiStatus = new RateLimitStatus(5000, 5000, DateTimeOffset.UtcNow.AddMinutes(1).ToUnixTimeSeconds());
            return Task.FromResult(new GitHubApiRateLimits(apiStatus, apiStatus, apiStatus, apiStatus, apiStatus, apiStatus));
        }

        public int GetRateLimit(in HttpResponseHeaders httpResponseHeaders) => 5000;
        public int GetRemainingRequestCount(in HttpResponseHeaders httpResponseHeaders) => 5000;
        public bool HasReachedMaximimApiCallLimit(in HttpResponseHeaders httpResponseHeaders) => false;
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
    }
}
