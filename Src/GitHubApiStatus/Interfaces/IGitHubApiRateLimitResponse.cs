namespace GitHubApiStatus
{
    interface IGitHubApiRateLimitResponse
    {
        public IGitHubApiRateLimits Results { get; }
    }
}
