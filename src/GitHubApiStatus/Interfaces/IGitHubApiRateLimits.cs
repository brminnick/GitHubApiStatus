namespace GitHubApiStatus
{
    /// <summary>
    /// Interface for GitHub API Rate Limits
    /// </summary>
    public interface IGitHubApiRateLimits
    {
        /// <summary>
        /// REST API Rate Limit Status
        /// </summary>
        public IRateLimitStatus RestApi { get; }

        /// <summary>
        /// Search API Rate Limit Status
        /// </summary>
        public IRateLimitStatus SearchApi { get; }

        /// <summary>
        /// GraphQL API Rate Limit Status
        /// </summary>
        public IRateLimitStatus GraphQLApi { get; }

        /// <summary>
        /// Source Import API Rate Limit Status
        /// </summary>
        public IRateLimitStatus SourceImport { get; }

        /// <summary>
        /// Code Scanning API Rate Limit Status
        /// </summary>
        public IRateLimitStatus CodeScanningUpload { get; }

        /// <summary>
        /// App Manifest Configuration API Rate Limit Status
        /// </summary>
        public IRateLimitStatus AppManifestConfiguration { get; }
    }
}
