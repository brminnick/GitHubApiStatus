using System;

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