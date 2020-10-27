namespace GitHubApiStatus
{
    public class GitHubApiRateLimits
    {
        public GitHubApiRateLimits(RateLimitStatus core,
                                        RateLimitStatus search,
                                        RateLimitStatus graphql,
                                        RateLimitStatus source_import,
                                        RateLimitStatus integration_manifest,
                                        RateLimitStatus code_scanning_upload)
        {
            RestApi = core;
            SearchApi = search;
            GraphQLApi = graphql;
            SourceImport = source_import;
            CodeScanningUpload = code_scanning_upload;
            AppManifestConfiguration = integration_manifest;
        }

        public RateLimitStatus RestApi { get; }
        public RateLimitStatus SearchApi { get; }
        public RateLimitStatus GraphQLApi { get; }
        public RateLimitStatus SourceImport { get; }
        public RateLimitStatus CodeScanningUpload { get; }
        public RateLimitStatus AppManifestConfiguration { get; }
    }

    class GitHubApiRateLimitResponse
    {
        public GitHubApiRateLimitResponse(GitHubApiRateLimits resources) => Results = resources;

        public GitHubApiRateLimits Results { get; }
    }
}
