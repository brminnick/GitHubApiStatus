using System;

namespace GitHubApiStatus
{
    public class RateLimitStatus
    {
        public RateLimitStatus(int limit, int remaining, long reset)
        {
            RateLimit = limit;
            RemainingRequestCount = remaining;
            RateLimitReset_UnixEpochSeconds = reset;

            RateLimitReset_DateTime = DateTimeOffset.FromUnixTimeSeconds(reset);
            RateLimitReset_TimeRemaining = RateLimitReset_DateTime.Subtract(DateTimeOffset.UtcNow);
        }

        public int RateLimit { get; }
        public int RemainingRequestCount { get; }
        public long RateLimitReset_UnixEpochSeconds { get; }
        public TimeSpan RateLimitReset_TimeRemaining { get; }
        public DateTimeOffset RateLimitReset_DateTime { get; }
    }
}
