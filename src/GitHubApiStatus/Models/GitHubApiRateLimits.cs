namespace GitHubApiStatus;

/// <summary>
/// Rate Limit data for each GitHub API
/// </summary>
public class GitHubApiRateLimits : IGitHubApiRateLimits
{
	/// <summary>
	/// Create GitHubApiRateLimits
	/// </summary>
	/// <param name="core">REST API</param>
	/// <param name="search">Search API</param>
	/// <param name="graphql">GraphQL API</param>
	/// <param name="source_import">Source Import API</param>
	/// <param name="integration_manifest">Integration Manifest API</param>
	/// <param name="code_scanning_upload">Code Scanning API</param>
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

	/// <summary>
	/// REST API Rate Limit Status
	/// </summary>
	public RateLimitStatus RestApi { get; }

	/// <summary>
	/// Search API Rate Limit Status
	/// </summary>
	public RateLimitStatus SearchApi { get; }

	/// <summary>
	/// GraphQL API Rate Limit Status
	/// </summary>
	public RateLimitStatus GraphQLApi { get; }

	/// <summary>
	/// Source Import API Rate Limit Status
	/// </summary>
	public RateLimitStatus SourceImport { get; }

	/// <summary>
	/// Code Scanning API Rate Limit Status
	/// </summary>
	public RateLimitStatus CodeScanningUpload { get; }

	/// <summary>
	/// App Manifest Configuration API Rate Limit Status
	/// </summary>
	public RateLimitStatus AppManifestConfiguration { get; }

	IRateLimitStatus IGitHubApiRateLimits.RestApi => RestApi;
	IRateLimitStatus IGitHubApiRateLimits.SearchApi => SearchApi;
	IRateLimitStatus IGitHubApiRateLimits.GraphQLApi => GraphQLApi;
	IRateLimitStatus IGitHubApiRateLimits.SourceImport => SourceImport;
	IRateLimitStatus IGitHubApiRateLimits.CodeScanningUpload => CodeScanningUpload;
	IRateLimitStatus IGitHubApiRateLimits.AppManifestConfiguration => AppManifestConfiguration;
}

class GitHubApiRateLimitResponse : IGitHubApiRateLimitResponse
{
	public GitHubApiRateLimitResponse(GitHubApiRateLimits resources) => Results = resources;

	public GitHubApiRateLimits Results { get; }

	IGitHubApiRateLimits IGitHubApiRateLimitResponse.Results => Results;
}