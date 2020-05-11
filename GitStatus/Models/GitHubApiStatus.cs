using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Refit;

namespace GitStatus
{
    class GitHubApiStatus
    {
        public GitHubApiStatus(ApiException exception) : this(exception.Headers)
        {

        }

        public GitHubApiStatus(HttpResponseMessage response) : this(response.Headers)
        {

        }

        public GitHubApiStatus(HttpResponseHeaders responseHeaders)
        {
            RateLimit = GetRateLimit(responseHeaders);
            RemainingRequests = GetRemainingRequests(responseHeaders);
            ResetDateTime = GetRateLimitResetDateTime(responseHeaders);
        }

        public TimeSpan ResetTimeRemaining => GetTimeRemaining(ResetDateTime);

        public int RateLimit { get; }
        public int RemainingRequests { get; }
        public DateTimeOffset ResetDateTime { get; }

        public override string ToString() => $"API Requests Remaining: {RemainingRequests}\nAPI Rate Limit: {RateLimit}\n\nMinutes Remaining: {Math.Round(ResetTimeRemaining.TotalMinutes, MidpointRounding.AwayFromZero)}\nReset Time: {ResetDateTime.ToLocalTime():dd MMMM @ HH:mm}";

        static int GetRateLimit(HttpResponseHeaders responseHeaders)
        {
            var rateLimitRemainingHeader = responseHeaders.SingleOrDefault(x => x.Key is "X-RateLimit-Limit");
            var rateLimit = int.Parse(rateLimitRemainingHeader.Value.First());

            return rateLimit;
        }

        static int GetRemainingRequests(HttpResponseHeaders responseHeaders)
        {
            var rateLimitRemainingHeader = responseHeaders.SingleOrDefault(x => x.Key is "X-RateLimit-Remaining");
            var remainingApiRequests = int.Parse(rateLimitRemainingHeader.Value.First());

            return remainingApiRequests;
        }

        static DateTimeOffset GetRateLimitResetDateTime(HttpResponseHeaders responseHeaders) =>
            DateTimeOffset.FromUnixTimeSeconds(GetRateLimitResetDateTime_UnixEpochSeconds(responseHeaders));

        static long GetRateLimitResetDateTime_UnixEpochSeconds(HttpResponseHeaders responseHeaders)
        {
            var rateLimitResetHeader = responseHeaders.Single(x => x.Key is "X-RateLimit-Reset");
            return long.Parse(rateLimitResetHeader.Value.First());
        }

        static TimeSpan GetTimeRemaining(DateTimeOffset resetDateTime) => resetDateTime.Subtract(DateTimeOffset.UtcNow);

    }
}
