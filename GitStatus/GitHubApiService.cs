using System;
using System.Linq;
using System.Net.Http.Headers;

namespace GitStatus
{
    public class GitHubApiStatus
    {
        static readonly Lazy<GitHubApiStatus> _instanceHolder = new Lazy<GitHubApiStatus>(() => new GitHubApiStatus());

        public const string RateLimitHeader = "X-RateLimit-Limit";
        public const string RateLimitResetHeader = "X-RateLimit-Reset";
        public const string RateLimitRemainingHeader = "X-RateLimit-Remaining";

        public static GitHubApiStatus Instance => _instanceHolder.Value;

        public int GetRateLimit(in HttpResponseHeaders responseHeaders)
        {
            var rateLimitRemainingHeader = responseHeaders.SingleOrDefault(x => x.Key is RateLimitHeader);
            var rateLimit = int.Parse(rateLimitRemainingHeader.Value.First());

            return rateLimit;
        }

        public int GetRateLimitRemainingRequests(in HttpResponseHeaders httpResponseHeaders)
        {
            var rateLimitRemainingHeader = httpResponseHeaders.First(x => x.Key.Equals(RateLimitRemainingHeader, StringComparison.OrdinalIgnoreCase));
            var remainingApiRequests = int.Parse(rateLimitRemainingHeader.Value.First());

            return remainingApiRequests;
        }

        public bool HasReachedMaximimApiCallLimit(in HttpResponseHeaders httpResponseHeaders)
        {
            var remainingApiRequests = GetRateLimitRemainingRequests(httpResponseHeaders);
            return remainingApiRequests <= 0;
        }

        public TimeSpan GetRateLimitTimeRemaining(in HttpResponseHeaders httpResponseHeaders) => GetRateLimitResetDateTime(httpResponseHeaders).Subtract(DateTimeOffset.UtcNow);

        public bool IsUserAuthenticated(in HttpResponseHeaders httpResponseHeaders) => httpResponseHeaders.Vary.Any(x => x is "Authorization");

        public DateTimeOffset GetRateLimitResetDateTime(in HttpResponseHeaders httpResponseHeaders) =>
            DateTimeOffset.FromUnixTimeSeconds(GetRateLimitResetDateTime_UnixEpochSeconds(httpResponseHeaders));

        public long GetRateLimitResetDateTime_UnixEpochSeconds(in HttpResponseHeaders httpResponseHeaders)
        {
            var rateLimitResetHeader = httpResponseHeaders.First(x => x.Key.Equals(RateLimitResetHeader, StringComparison.OrdinalIgnoreCase));
            return long.Parse(rateLimitResetHeader.Value.First());
        }
    }
}
