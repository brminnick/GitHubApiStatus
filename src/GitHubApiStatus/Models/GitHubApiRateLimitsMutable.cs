#if !NETSTANDARD1_3
using System;
using System.Text.Json.Serialization;

namespace GitHubApiStatus;

class GitHubApiRateLimitsMutable : IGitHubApiRateLimits
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

	IRateLimitStatus IGitHubApiRateLimits.RestApi => RestApi ?? throw new NullReferenceException();
	IRateLimitStatus IGitHubApiRateLimits.SearchApi => SearchApi ?? throw new NullReferenceException();
	IRateLimitStatus IGitHubApiRateLimits.GraphQLApi => GraphQLApi ?? throw new NullReferenceException();
	IRateLimitStatus IGitHubApiRateLimits.SourceImport => SourceImport ?? throw new NullReferenceException();
	IRateLimitStatus IGitHubApiRateLimits.CodeScanningUpload => CodeScanningUpload ?? throw new NullReferenceException();
	IRateLimitStatus IGitHubApiRateLimits.AppManifestConfiguration => AppManifestConfiguration ?? throw new NullReferenceException();

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

class RateLimitStatusMutable : IRateLimitStatus
{
	public RateLimitStatusMutable()
	{
		RateLimitReset_DateTime = DateTimeOffset.FromUnixTimeSeconds(RateLimitReset_UnixEpochSeconds);
	}

	public TimeSpan RateLimitReset_TimeRemaining => RateLimitReset_DateTime.Subtract(DateTimeOffset.UtcNow);

	public DateTimeOffset RateLimitReset_DateTime { get; }

	[JsonPropertyName("limit")]
	public int RateLimit { get; set; }

	[JsonPropertyName("remaining")]
	public int RemainingRequestCount { get; set; }

	[JsonPropertyName("reset")]
	public long RateLimitReset_UnixEpochSeconds { get; set; }

	public RateLimitStatus ToRateLimitStatus() => new(RateLimit, RemainingRequestCount, RateLimitReset_UnixEpochSeconds);

}

class GitHubApiRateLimitResponseMutable : IGitHubApiRateLimitResponse
{
	[JsonPropertyName("resources")]
	public GitHubApiRateLimitsMutable? Results { get; set; }

	IGitHubApiRateLimits IGitHubApiRateLimitResponse.Results => Results ?? throw new NullReferenceException();

	public GitHubApiRateLimitResponse ToGitHubApiRateLimitResponse() => new GitHubApiRateLimitResponse(Results?.ToGitHubApiRateLimits() ?? throw new NullReferenceException());
}
#endif