using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Refit;

namespace GitStatus.Mobile
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
            RateLimit = GitHubApiStatus.Instance.GetRateLimit(responseHeaders);
            ResetDateTime = GitHubApiStatus.Instance.GetRateLimitResetDateTime(responseHeaders);
            TimeRemaining = GitHubApiStatus.Instance.GetRateLimitTimeRemaining(responseHeaders);
            RemainingRequests = GitHubApiStatus.Instance.GetRateLimitRemainingRequests(responseHeaders);
        }


        public int RateLimit { get; }
        public int RemainingRequests { get; }
        public TimeSpan TimeRemaining { get; }
        public DateTimeOffset ResetDateTime { get; }

        public override string ToString() => $"API Requests Remaining: {RemainingRequests}\nAPI Rate Limit: {RateLimit}\n\nMinutes Remaining: {Math.Round(TimeRemaining.TotalMinutes, MidpointRounding.AwayFromZero)}\nReset Time: {ResetDateTime.ToLocalTime():dd MMMM @ HH:mm}";
    }
}
