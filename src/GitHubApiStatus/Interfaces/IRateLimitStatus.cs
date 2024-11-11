namespace GitHubApiStatus;

/// <summary>
/// Interface for GitHub API Raite Limit Status
/// </summary>
public interface IRateLimitStatus
{
	/// <summary>
	/// Time Remaining until Rate Limit Reset
	/// </summary>
	TimeSpan RateLimitReset_TimeRemaining { get; }

	/// <summary>
	/// GitHub API Rate Limit
	/// </summary>
	int RateLimit { get; }

	/// <summary>
	/// Remaining Request Count to GitHub API 
	/// </summary>
	int RemainingRequestCount { get; }

	/// <summary>
	/// Rate Limit Reset Time Stamp in Unix Epoch Seconds
	/// </summary>
	long RateLimitReset_UnixEpochSeconds { get; }

	/// <summary>
	/// Rate Limit Reset Time Stamp
	/// </summary>
	DateTimeOffset RateLimitReset_DateTime { get; }
}