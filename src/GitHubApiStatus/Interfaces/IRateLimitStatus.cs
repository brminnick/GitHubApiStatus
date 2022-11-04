using System;

/* Unmerged change from project 'GitHubApiStatus(netstandard2.0)'
Before:
namespace GitHubApiStatus
{
    /// <summary>
    /// Interface for GitHub API Raite Limit Status
    /// </summary>
    public interface IRateLimitStatus
    {
        /// <summary>
        /// Time Remaining until Rate Limit Reset
        /// </summary>
        public TimeSpan RateLimitReset_TimeRemaining { get; }

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
After:
namespace GitHubApiStatus;

    /// <summary>
    /// Interface for GitHub API Raite Limit Status
    /// </summary>
    public interface IRateLimitStatus
    {
        /// <summary>
        /// Time Remaining until Rate Limit Reset
        /// </summary>
        public TimeSpan RateLimitReset_TimeRemaining { get; }

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
*/

/* Unmerged change from project 'GitHubApiStatus(netstandard2.1)'
Before:
namespace GitHubApiStatus
{
    /// <summary>
    /// Interface for GitHub API Raite Limit Status
    /// </summary>
    public interface IRateLimitStatus
    {
        /// <summary>
        /// Time Remaining until Rate Limit Reset
        /// </summary>
        public TimeSpan RateLimitReset_TimeRemaining { get; }

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
After:
namespace GitHubApiStatus;

    /// <summary>
    /// Interface for GitHub API Raite Limit Status
    /// </summary>
    public interface IRateLimitStatus
    {
        /// <summary>
        /// Time Remaining until Rate Limit Reset
        /// </summary>
        public TimeSpan RateLimitReset_TimeRemaining { get; }

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
*/

/* Unmerged change from project 'GitHubApiStatus(netcoreapp3.0)'
Before:
namespace GitHubApiStatus
{
    /// <summary>
    /// Interface for GitHub API Raite Limit Status
    /// </summary>
    public interface IRateLimitStatus
    {
        /// <summary>
        /// Time Remaining until Rate Limit Reset
        /// </summary>
        public TimeSpan RateLimitReset_TimeRemaining { get; }

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
After:
namespace GitHubApiStatus;

    /// <summary>
    /// Interface for GitHub API Raite Limit Status
    /// </summary>
    public interface IRateLimitStatus
    {
        /// <summary>
        /// Time Remaining until Rate Limit Reset
        /// </summary>
        public TimeSpan RateLimitReset_TimeRemaining { get; }

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
*/

/* Unmerged change from project 'GitHubApiStatus(net5.0)'
Before:
namespace GitHubApiStatus
{
    /// <summary>
    /// Interface for GitHub API Raite Limit Status
    /// </summary>
    public interface IRateLimitStatus
    {
        /// <summary>
        /// Time Remaining until Rate Limit Reset
        /// </summary>
        public TimeSpan RateLimitReset_TimeRemaining { get; }

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
After:
namespace GitHubApiStatus;

    /// <summary>
    /// Interface for GitHub API Raite Limit Status
    /// </summary>
    public interface IRateLimitStatus
    {
        /// <summary>
        /// Time Remaining until Rate Limit Reset
        /// </summary>
        public TimeSpan RateLimitReset_TimeRemaining { get; }

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
*/

/* Unmerged change from project 'GitHubApiStatus(net6.0)'
Before:
namespace GitHubApiStatus
{
    /// <summary>
    /// Interface for GitHub API Raite Limit Status
    /// </summary>
    public interface IRateLimitStatus
    {
        /// <summary>
        /// Time Remaining until Rate Limit Reset
        /// </summary>
        public TimeSpan RateLimitReset_TimeRemaining { get; }

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
After:
namespace GitHubApiStatus;

    /// <summary>
    /// Interface for GitHub API Raite Limit Status
    /// </summary>
    public interface IRateLimitStatus
    {
        /// <summary>
        /// Time Remaining until Rate Limit Reset
        /// </summary>
        public TimeSpan RateLimitReset_TimeRemaining { get; }

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
*/
namespace GitHubApiStatus
{
	/// <summary>
	/// Interface for GitHub API Raite Limit Status
	/// </summary>
	public interface IRateLimitStatus
	{
		/// <summary>
		/// Time Remaining until Rate Limit Reset
		/// </summary>
		public TimeSpan RateLimitReset_TimeRemaining { get; }

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