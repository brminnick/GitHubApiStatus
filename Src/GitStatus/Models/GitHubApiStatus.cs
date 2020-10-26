using System;
using System.Net.Http;
using System.Net.Http.Headers;
using GitHubApiStatus;
using Refit;

namespace GitStatus
{
    class GitHubApiStatusModel
    {
        public GitHubApiStatusModel(ApiException exception) : this(exception.Headers)
        {

        }

        public GitHubApiStatusModel(HttpResponseMessage response) : this(response.Headers)
        {

        }

        public GitHubApiStatusModel(HttpResponseHeaders responseHeaders)
        {
            RateLimit = GitHubApiStatusService.Instance.GetRateLimit(responseHeaders);
            ResetDateTime = GitHubApiStatusService.Instance.GetRateLimitResetDateTime(responseHeaders);
            TimeRemaining = GitHubApiStatusService.Instance.GetRateLimitTimeRemaining(responseHeaders);
            RemainingRequests = GitHubApiStatusService.Instance.GetRemainingRequestCount(responseHeaders);
        }


        public int RateLimit { get; }
        public int RemainingRequests { get; }
        public TimeSpan TimeRemaining { get; }
        public DateTimeOffset ResetDateTime { get; }

        public override string ToString() => $"API Requests Remaining: {RemainingRequests}\nAPI Rate Limit: {RateLimit}\n\nMinutes Remaining: {Math.Round(TimeRemaining.TotalMinutes, MidpointRounding.AwayFromZero)}\nReset Time: {ResetDateTime.ToLocalTime():dd MMMM @ HH:mm}";
    }
}
