#if !NETSTANDARD
using System;
using System.Text.Json.Serialization;

namespace GitHubApiStatus
{
    class GitHubApiRateLimitsMutable
    {
        [JsonPropertyName("core")]
        public RateLimitStatusMutable? RestApi { get; set; }

        [JsonPropertyName("search")]
        public RateLimitStatusMutable? SearchApi { get; set; }

        [JsonPropertyName("graphql")]
        public RateLimitStatusMutable? GraphQLApi { get; set; }

        [JsonPropertyName("source_import")]
        public RateLimitStatusMutable? SourceImport { get; set; }

        [JsonPropertyName("code_scanning_upload")]
        public RateLimitStatusMutable? CodeScanningUpload { get; set; }

        [JsonPropertyName("integration_manifest")]
        public RateLimitStatusMutable? AppManifestConfiguration { get; set; }

        public GitHubApiRateLimits ToGitHubApiRateLimits()
        {
            return new GitHubApiRateLimits(RestApi?.ToRateLimitStatus() ?? throw new NullReferenceException(),
                                            SearchApi?.ToRateLimitStatus() ?? throw new NullReferenceException(),
                                            GraphQLApi?.ToRateLimitStatus() ?? throw new NullReferenceException(),
                                            SourceImport?.ToRateLimitStatus() ?? throw new NullReferenceException(),
                                            AppManifestConfiguration?.ToRateLimitStatus() ?? throw new NullReferenceException(),
                                            CodeScanningUpload?.ToRateLimitStatus() ?? throw new NullReferenceException());
        }
    }

    class RateLimitStatusMutable
    {
        [JsonPropertyName("limit")]
        public int RateLimit { get; set; }

        [JsonPropertyName("remaining")]
        public int RemainingRequestCount { get; set; }

        [JsonPropertyName("reset")]
        public long RateLimitReset_UnixEpochSeconds { get; set; }

        public RateLimitStatus ToRateLimitStatus() => new RateLimitStatus(RateLimit, RemainingRequestCount, RateLimitReset_UnixEpochSeconds);

    }

    class GitHubApiRateLimitResponseMutable
    {
        [JsonPropertyName("resources")]
        public GitHubApiRateLimitsMutable? Results { get; set; }

        public GitHubApiRateLimitResponse ToGitHubApiRateLimitResponse() => new GitHubApiRateLimitResponse(Results?.ToGitHubApiRateLimits() ?? throw new NullReferenceException());
    }
}
#endif