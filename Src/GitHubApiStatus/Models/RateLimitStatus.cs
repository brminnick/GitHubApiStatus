using System;

namespace GitHubApiStatus
{
    /// <summary>
    /// GitHub API Rate Limit Status
    /// </summary>
    public class RateLimitStatus
    {

        /// <summary>
        /// Create GitHub Rate Limit Status
        /// </summary>
        /// <param name="limit">Maximum API Requests</param>
        /// <param name="remaining">Remaining API Requests</param>
        /// <param name="reset">Rate Limit Reset Time Stamp in Unix Epoch Seconds</param>
        public RateLimitStatus(int limit, int remaining, long reset)
        {
            RateLimit = limit;
            RemainingRequestCount = remaining;
            RateLimitReset_UnixEpochSeconds = reset;

            RateLimitReset_DateTime = DateTimeOffset.FromUnixTimeSeconds(reset);
        }

        /// <summary>
        /// Time Remaining until Rate Limit Reset
        /// </summary>
        public TimeSpan RateLimitReset_TimeRemaining => RateLimitReset_DateTime.Subtract(DateTimeOffset.UtcNow);    

        /// <summary>
        /// GitHub API Rate Limit
        /// </summary>
        public int RateLimit { get; }

        /// <summary>
        /// Remaining Request Count to GitHub API 
        /// </summary>
        public int RemainingRequestCount { get; }

        /// <summary>
        /// Rate Limit Reset Time Stamp in Unix Epoch Seconds
        /// </summary>
        public long RateLimitReset_UnixEpochSeconds { get; }

        /// <summary>
        /// Rate Limit Reset Time Stamp
        /// </summary>
        public DateTimeOffset RateLimitReset_DateTime { get; }
    }
}
