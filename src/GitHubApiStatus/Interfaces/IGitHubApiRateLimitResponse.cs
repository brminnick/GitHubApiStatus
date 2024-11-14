namespace GitHubApiStatus;

interface IGitHubApiRateLimitResponse
{
	IGitHubApiRateLimits Results { get; }
}