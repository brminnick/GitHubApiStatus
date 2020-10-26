using System;
using System.Linq;
using System.Net.Http.Headers;

namespace GitHubApiStatus
{
    public class GitHubApiStatusService
    {
        static readonly Lazy<GitHubApiStatusService> _instanceHolder = new Lazy<GitHubApiStatusService>(() => new GitHubApiStatusService());

        public const string RateLimitHeader = "X-RateLimit-Limit";
        public const string RateLimitResetHeader = "X-RateLimit-Reset";
        public const string RateLimitRemainingHeader = "X-RateLimit-Remaining";

        public static GitHubApiStatusService Instance => _instanceHolder.Value;

        public int GetRateLimit(in HttpResponseHeaders httpResponseHeaders)
        {
            var rateLimitRemainingHeader = httpResponseHeaders?.Single(x => x.Key.Equals(RateLimitHeader, StringComparison.OrdinalIgnoreCase)) ?? throw new ArgumentNullException(nameof(httpResponseHeaders));
            var rateLimit = int.Parse(rateLimitRemainingHeader.Value.First());

            return rateLimit;
        }

        public int GetRemainingRequestCount(in HttpResponseHeaders httpResponseHeaders)
        {
            var rateLimitRemainingHeader = httpResponseHeaders?.Single(x => x.Key.Equals(RateLimitRemainingHeader, StringComparison.OrdinalIgnoreCase)) ?? throw new ArgumentNullException(nameof(httpResponseHeaders));
            var remainingApiRequests = int.Parse(rateLimitRemainingHeader.Value.First());

            return remainingApiRequests;
        }

        public bool HasReachedMaximimApiCallLimit(in HttpResponseHeaders httpResponseHeaders)
        {
            var remainingApiRequests = GetRemainingRequestCount(httpResponseHeaders);
            return remainingApiRequests <= 0;
        }

        public TimeSpan GetRateLimitTimeRemaining(in HttpResponseHeaders httpResponseHeaders) => GetRateLimitResetDateTime(httpResponseHeaders).Subtract(DateTimeOffset.UtcNow);

        public bool IsUserAuthenticated(in HttpResponseHeaders httpResponseHeaders) => httpResponseHeaders?.Vary.Any(x => x is "Authorization") ?? throw new ArgumentNullException(nameof(httpResponseHeaders));

        public DateTimeOffset GetRateLimitResetDateTime(in HttpResponseHeaders httpResponseHeaders) =>
            DateTimeOffset.FromUnixTimeSeconds(GetRateLimitResetDateTime_UnixEpochSeconds(httpResponseHeaders));

        public long GetRateLimitResetDateTime_UnixEpochSeconds(in HttpResponseHeaders httpResponseHeaders)
        {
            var rateLimitResetHeader = httpResponseHeaders?.Single(x => x.Key.Equals(RateLimitResetHeader, StringComparison.OrdinalIgnoreCase)) ?? throw new ArgumentNullException(nameof(httpResponseHeaders));
            return long.Parse(rateLimitResetHeader.Value.First());
        }
    }
}
