![Unit Tests](https://github.com/brminnick/GitHubApiStatus/workflows/Run%20Unit%20Tests/badge.svg)

# GitHubApiStatus

[![NuGet](https://buildstats.info/nuget/GitHubApiStatus?includePreReleases=true)](https://www.nuget.org/packages/GitHubApiStatus/) 

GitHubApiStatus helps make it easy to understand GitHub's API Rate Limit!

- [Jump to the Setup](#Setup)
- [Jump to the API](#API)
- [Jump to Examples](#Examples)

## GitHub API Rate Limits

### REST API

(From the [GitHub REST API Docs](https://docs.github.com/en/free-pro-team@latest/rest/overview/resources-in-the-rest-api#rate-limiting))

[![GitHub RST API Limits](https://user-images.githubusercontent.com/13558917/97235854-066e5680-17a1-11eb-98f9-01fae7c02ac0.png)](https://docs.github.com/en/free-pro-team@latest/rest/overview/resources-in-the-rest-api#rate-limiting)

### GraphQL API

(From the [GitHub GraphQL API Docs](https://docs.github.com/en/free-pro-team@latest/graphql/overview/resource-limitations#rate-limit))

[![GitHub GraphQL API Limits](https://user-images.githubusercontent.com/13558917/97235806-ec347880-17a0-11eb-9637-fc1eb7f8dbc8.png)](https://docs.github.com/en/free-pro-team@latest/graphql/overview/resource-limitations#rate-limit)

### Rate Limit Headers

![Rate Limit Headers](https://user-images.githubusercontent.com/13558917/97235863-0e2dfb00-17a1-11eb-98f8-23c1065eb043.png)

## Setup

- Available on NuGet: https://www.nuget.org/packages/GitHubApiStatus/ 
- Add to any project supporting .NET Standard 1.3

## API

#### GetApiRateLimits

```csharp
public Task<GitHubApiRateLimits> GetApiRateLimits(AuthenticationHeaderValue authenticationHeaderValue)
```
- Get the current GitHub API Rate Limit status
- Returns `RateLimitData` for the following GitHub APIs:
  - REST API
  - Search API
  - GraphQL API
  - Source Import API
  - App Manifest Configuration API

#### GetRateLimit

```csharp
public int GetRateLimit(HttpResponseHeaders httpResponseHeaders)
```
- Get the total number of GitHub API Requests available
- Parses the `X-RateLimit-Limit` header and return its `int` value
  
#### GetRemainingRequestCount
  
```csharp
public int GetRemainingRequestCount(HttpResponseHeaders httpResponseHeaders)
```
- Get the number of GitHub API Requests remaining
- Parses the `X-RateLimit-Remaining` header and return its `int` value
  
#### HasReachedMaximimApiCallLimit
  
```csharp
public bool HasReachedMaximimApiCallLimit(HttpResponseHeaders httpResponseHeaders)
```
- Determines whether the maximum number of requests 
- Parses the `X-RateLimit-Remaining` header and returns wether or not it is greater than 0
  
#### GetRateLimitTimeRemaining
  
```csharp
public TimeSpan GetRateLimitTimeRemaining(HttpResponseHeaders httpResponseHeaders)
```
- Get the time remaining until GitHub API rate limit resets
- Parses the `X-RateLimit-Reset` header and returns the `TimeSpan` value from the current time
  
#### IsAuthenticated
  
```csharp
public bool IsAuthenticated(HttpResponseHeaders httpResponseHeaders)
```
- Determine whether the request was made using an authenticated bearer token
- Determines whether or not the `Authorization` key exists in the `Vary` header 

#### GetRateLimitResetDateTime

```csharp
public DateTimeOffset GetRateLimitResetDateTime(HttpResponseHeaders httpResponseHeaders)
```
- Get the Date Time when the GitHub API rate limit resets
- Parses the `X-RateLimit-Reset` header and returns its `DateTimeOffset` value
  
#### GetRateLimitResetDateTime_UnixEpochSeconds
  
```csharp
public long GetRateLimitResetDateTime_UnixEpochSeconds(HttpResponseHeaders httpResponseHeaders)
```
- Get the Date Time when the GitHub API rate limit resets
- Parses the `X-RateLimit-Reset` header and returns its `long` value in [Unix Epoch Seconds](https://www.epochconverter.com)
  
## Examples

### Get Current GitHub API Status

```csharp
static async Task Main(string[] args)
{
    //Generate Personal Access Token https://github.com/settings/tokens
    var apiRateLimits = await GitHubApiStatusService.Instance.GetApiRateLimits(new AuthenticationHeaderValue("bearer", "Your GitHub Personal Access Token, e.g. 123456789012345));

    // REST API Results
    Console.WriteLine($"What is the GitHub REST API Rate Limit? {apiRateLimits.RestApi.RateLimit}");
    Console.WriteLine($"How many REST API requests do I have remaining? {apiRateLimits.RestApi.RemainingRequestCount}");
    Console.WriteLine($"How long until the GitHub REST API Rate Limit resets? {apiRateLimits.RestApi.RateLimitReset_TimeRemaining}");
    Console.WriteLine($"When does the GitHub REST API Rate Limit reset? {apiRateLimits.RestApi.RateLimitReset_DateTime}");

    Console.WriteLine("");

    // GraphQL API Results
    Console.WriteLine($"What is the GitHub GraphQL API Rate Limit? {apiRateLimits.GraphQLApi.RateLimit}");
    Console.WriteLine($"How many GraphQL API requests do I have remaining? {apiRateLimits.GraphQLApi.RemainingRequestCount}");
    Console.WriteLine($"How long until the GitHub GraphQL API Rate Limit resets? {apiRateLimits.GraphQLApi.RateLimitReset_TimeRemaining}");
    Console.WriteLine($"When does the GitHub GraphQL API Rate Limit reset? {apiRateLimits.GraphQLApi.RateLimitReset_DateTime}");

    Console.WriteLine("");

    // Search API Results
    Console.WriteLine($"What is the GitHub Search API Rate Limit? {apiRateLimits.SearchApi.RateLimit}");
    Console.WriteLine($"How many Search API requests do I have remaining? {apiRateLimits.SearchApi.RemainingRequestCount}");
    Console.WriteLine($"How long until the GitHub Search API Rate Limit resets? {apiRateLimits.SearchApi.RateLimitReset_TimeRemaining}");
    Console.WriteLine($"When does the GitHub Search API Rate Limit reset? {apiRateLimits.SearchApi.RateLimitReset_DateTime}");

    Console.WriteLine("");

    // Source Import API Results
    Console.WriteLine($"What is the GitHub Source Import API Rate Limit? {apiRateLimits.SourceImport.RateLimit}");
    Console.WriteLine($"How many Source Import API requests do I have remaining? {apiRateLimits.SourceImport.RemainingRequestCount}");
    Console.WriteLine($"How long until the GitHub Source Import API Rate Limit resets? {apiRateLimits.SourceImport.RateLimitReset_TimeRemaining}");
    Console.WriteLine($"When does the GitHub Source Import API Rate Limit reset? {apiRateLimits.SourceImport.RateLimitReset_DateTime}");

    Console.WriteLine("");

    // App Manifest Configuration API Results
    Console.WriteLine($"What is the GitHub App Manifest Configuration API Rate Limit? {apiRateLimits.AppManifestConfiguration.RateLimit}");
    Console.WriteLine($"How many App Manifest Configuration API requests do I have remaining? {apiRateLimits.AppManifestConfiguration.RemainingRequestCount}");
    Console.WriteLine($"How long until the GitHub App Manifest Configuration API Rate Limit resets? {apiRateLimits.AppManifestConfiguration.RateLimitReset_TimeRemaining}");
    Console.WriteLine($"When does the GitHub App Manifest Configuration API Rate Limit reset? {apiRateLimits.AppManifestConfiguration.RateLimitReset_DateTime}");

    Console.WriteLine("");

    // Code Scanning Upload API Results
    Console.WriteLine($"What is the GitHub Code Scanning Upload API Rate Limit? {apiRateLimits.CodeScanningUpload.RateLimit}");
    Console.WriteLine($"How many Code Scanning Upload API requests do I have remaining? {apiRateLimits.CodeScanningUpload.RemainingRequestCount}");
    Console.WriteLine($"How long until the GitHub Code Scanning Upload API Rate Limit resets? {apiRateLimits.CodeScanningUpload.RateLimitReset_TimeRemaining}");
    Console.WriteLine($"When does the GitHub Code Scanning Upload API Rate Limit reset? {apiRateLimits.CodeScanningUpload.RateLimitReset_DateTime}");

    Console.WriteLine("");
}

static async Task<(TimeSpan RateLimitTimeRemaining, int RateLimit, int RemainingRequestCount, bool IsAuthenticated, bool HasReachedMaximumApiLimit)> GetRestApiRateLimitDataFromHeaders()
{
    HttpResponseMessage restApiResponse = await _client.GetAsync($"{GitHubConstants.GitHubRestApiUrl}/repos/brminnick/GitHubApiStatus");
    restApiResponse.EnsureSuccessStatusCode();

    TimeSpan rateLimitTimeRemaining = GitHubApiStatusService.Instance.GetRateLimitTimeRemaining(restApiResponse.Headers);

    int rateLimit = GitHubApiStatusService.Instance.GetRateLimit(restApiResponse.Headers);
    int remainingRequestCount = GitHubApiStatusService.Instance.GetRemainingRequestCount(restApiResponse.Headers);

    bool isAuthenticated = GitHubApiStatusService.Instance.IsAuthenticated(restApiResponse.Headers);

    bool hasReachedMaximumApiLimit = GitHubApiStatusService.Instance.HasReachedMaximimApiCallLimit(restApiResponse.Headers);

    return (rateLimitTimeRemaining, rateLimit, remainingRequestCount, isAuthenticated, hasReachedMaximumApiLimit);
}
```

### Parse API ststus from `HttpResponseHeaders`

```csharp
const string _gitHubRestApiUrl = "https://api.github.com";

static readonly HttpClient _client = new HttpClient
{
    DefaultRequestHeaders =
    {
        { "User-Agent", "GitHubApiStatus" }
    }
};

static async Task Main(string[] args)
{
    HttpResponseMessage restApiResponse = await _client.GetAsync($"{ _gitHubRestApiUrl}/repos/brminnick/GitHubApiStatus");
    restApiResponse.EnsureSuccessStatusCode();

    TimeSpan rateLimitTimeRemaining = GitHubApiStatusService.Instance.GetRateLimitTimeRemaining(restApiResponse.Headers);

    int rateLimit = GitHubApiStatusService.Instance.GetRateLimit(restApiResponse.Headers);
    int remainingRequestCount = GitHubApiStatusService.Instance.GetRemainingRequestCount(restApiResponse.Headers);

    bool isAuthenticated = GitHubApiStatusService.Instance.IsAuthenticated(restApiResponse.Headers);

    bool hasReachedMaximumApiLimit = GitHubApiStatusService.Instance.HasReachedMaximimApiCallLimit(restApiResponse.Headers);

    Debug.WriteLine($"What is the GitHub REST API Rate Limit? {rateLimit}");

    Debug.WriteLine($"Have I reached the Maximum REST API Limit? {hasReachedMaximumApiLimit}");
    Debug.WriteLine($"How many REST API requests do I have remaining? {remainingRequestCount}");

    Debug.WriteLine($"How long until the GitHub REST API Rate Limit resets? {rateLimitTimeRemaining}");

    Debug.WriteLine($"Did the GitHub REST API Request include a Bearer Token? {isAuthenticated}");
}
```

> What is the GitHub REST API Rate Limit? 60
>
> Have I reached the Maximum REST API Limit? False
>
> How many REST API requests do I have remaining? 56
>
> How long until the GitHub REST API Rate Limit resets? 00:29:12.4134330
>
> Did GitHub REST API Request include a Bearer Token? False
