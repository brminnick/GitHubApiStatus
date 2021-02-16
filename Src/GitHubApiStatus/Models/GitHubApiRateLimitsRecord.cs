#if !NETSTANDARD1_3
using System;

namespace GitHubApiStatus
{
    record GitHubApiRateLimitsRecord(RateLimitStatusRecord Core,
                                        RateLimitStatusRecord Search,
                                        RateLimitStatusRecord GraphQL,
                                        RateLimitStatusRecord Source_Import,
                                        RateLimitStatusRecord Code_Scanning_Upload,
                                        RateLimitStatusRecord Integration_Manifest) : IGitHubApiRateLimits
    {
        IRateLimitStatus IGitHubApiRateLimits.RestApi => Core;
        IRateLimitStatus IGitHubApiRateLimits.SearchApi => Search;
        IRateLimitStatus IGitHubApiRateLimits.GraphQLApi => GraphQL;
        IRateLimitStatus IGitHubApiRateLimits.SourceImport => Source_Import;
        IRateLimitStatus IGitHubApiRateLimits.CodeScanningUpload => Code_Scanning_Upload;
        IRateLimitStatus IGitHubApiRateLimits.AppManifestConfiguration => Integration_Manifest;

        public GitHubApiRateLimits ToGitHubApiRateLimits()
        {
            return new GitHubApiRateLimits(Core.ToRateLimitStatus(),
                                            Search.ToRateLimitStatus(),
                                            GraphQL.ToRateLimitStatus(),
                                            Source_Import.ToRateLimitStatus(),
                                            Code_Scanning_Upload.ToRateLimitStatus(),
                                            Integration_Manifest.ToRateLimitStatus());
        }
    }

    record RateLimitStatusRecord(int Limit, int Remaining, long Reset) : IRateLimitStatus
    {
        public TimeSpan RateLimitReset_TimeRemaining => RateLimitReset_DateTime.Subtract(DateTimeOffset.UtcNow);

        public DateTimeOffset RateLimitReset_DateTime => DateTimeOffset.FromUnixTimeSeconds(Reset);

        int IRateLimitStatus.RateLimit => Limit;
        int IRateLimitStatus.RemainingRequestCount => Remaining;
        long IRateLimitStatus.RateLimitReset_UnixEpochSeconds => Reset;

        public RateLimitStatus ToRateLimitStatus() => new(Limit, Remaining, Reset);

    }

    record GitHubApiRateLimitResponseRecord(GitHubApiRateLimitsRecord Resources) : IGitHubApiRateLimitResponse
    {
        IGitHubApiRateLimits IGitHubApiRateLimitResponse.Results => Resources;

        public GitHubApiRateLimitResponse ToGitHubApiRateLimitResponse() => new(Resources.ToGitHubApiRateLimits());
    }
}

namespace System.Runtime.CompilerServices
{
    [ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)]
    public record IsExternalInit;
}
#endif