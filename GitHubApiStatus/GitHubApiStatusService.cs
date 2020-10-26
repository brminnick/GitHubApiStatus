using System;
using System.Linq;
using System.Net.Http.Headers;

namespace GitHubApiStatus
{
    /// <summary>
    /// GitHub API Status Service
    /// </summary>
    public class GitHubApiStatusService
    {
        static readonly Lazy<GitHubApiStatusService> _instanceHolder = new Lazy<GitHubApiStatusService>(() => new GitHubApiStatusService());

        /// <summary>
        /// GitHub Http Response Rate Limit Header Key
        /// </summary>
        public const string RateLimitHeader = "X-RateLimit-Limit";

        /// <summary>
        /// GitHub Http Response Rate Limit Reset Header Key
        /// </summary>
        public const string RateLimitResetHeader = "X-RateLimit-Reset";

        /// <summary>
        /// GitHub Http Response Rate Limit Remaining Reset Header Key
        /// </summary>
        public const string RateLimitRemainingHeader = "X-RateLimit-Remaining";


        /// <summary>
        /// Static Instance of GitHubApiStatusService 
        /// </summary>
        public static GitHubApiStatusService Instance => _instanceHolder.Value;

        /// <summary>
        /// Get GitHub API Rate Limit
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>GitHub Api Rate Limit </returns>
        public int GetRateLimit(in HttpResponseHeaders httpResponseHeaders)
        {
            var rateLimitRemainingHeader = httpResponseHeaders?.Single(x => x.Key.Equals(RateLimitHeader, StringComparison.OrdinalIgnoreCase)) ?? throw new ArgumentNullException(nameof(httpResponseHeaders));
            var rateLimit = int.Parse(rateLimitRemainingHeader.Value.First());

            return rateLimit;
        }

        /// <summary>
        /// Get Number of GitHub API Requests Remaining
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>Number of GitHub API Requests Remaining</returns>
        public int GetRemainingRequestCount(in HttpResponseHeaders httpResponseHeaders)
        {
            var rateLimitRemainingHeader = httpResponseHeaders?.Single(x => x.Key.Equals(RateLimitRemainingHeader, StringComparison.OrdinalIgnoreCase)) ?? throw new ArgumentNullException(nameof(httpResponseHeaders));
            var remainingApiRequests = int.Parse(rateLimitRemainingHeader.Value.First());

            return remainingApiRequests;
        }

        /// <summary>
        /// Determines Whether GitHub's Maximum API Limit Has Been Reached
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>Whether GitHub's Maximum API Limit Has Been Reached</returns>
        public bool HasReachedMaximimApiCallLimit(in HttpResponseHeaders httpResponseHeaders)
        {
            var remainingApiRequests = GetRemainingRequestCount(httpResponseHeaders);
            return remainingApiRequests <= 0;
        }

        /// <summary>
        /// Get Time Remaining Until GitHub API Rate Limit Resets
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>Time Remaining Until GitHub API Rate Limit Resets</returns>
        public TimeSpan GetRateLimitTimeRemaining(in HttpResponseHeaders httpResponseHeaders) => GetRateLimitResetDateTime(httpResponseHeaders).Subtract(DateTimeOffset.UtcNow);

        /// <summary>
        /// Determines Whether the Http Response Was From an Authenticated Http Request
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>Whether the Http Response Was From an Authenticated Http Request</returns>
        public bool IsAuthenticated(in HttpResponseHeaders httpResponseHeaders) => httpResponseHeaders?.Vary.Any(x => x is "Authorization") ?? throw new ArgumentNullException(nameof(httpResponseHeaders));

        /// <summary>
        /// Get the DateTimeOffset When the GitHub API Rate Limit Will Reset
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>DateTimeOffset When the GitHub API Rate Limit Will Reset</returns>
        public DateTimeOffset GetRateLimitResetDateTime(in HttpResponseHeaders httpResponseHeaders) =>
            DateTimeOffset.FromUnixTimeSeconds(GetRateLimitResetDateTime_UnixEpochSeconds(httpResponseHeaders));

        /// <summary>
        /// Get the Unix Epoch Seconds When the GitHub API Rate Limit Will Reset
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>Unix Epoch Seconds When the GitHub API Rate Limit Will Reset</returns>
        public long GetRateLimitResetDateTime_UnixEpochSeconds(in HttpResponseHeaders httpResponseHeaders)
        {
            var rateLimitResetHeader = httpResponseHeaders?.Single(x => x.Key.Equals(RateLimitResetHeader, StringComparison.OrdinalIgnoreCase)) ?? throw new ArgumentNullException(nameof(httpResponseHeaders));
            return long.Parse(rateLimitResetHeader.Value.First());
        }
    }
}
