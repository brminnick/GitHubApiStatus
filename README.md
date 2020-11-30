![Unit Tests](https://github.com/brminnick/GitHubApiStatus/workflows/Run%20Unit%20Tests/badge.svg)


# GitHubApiStatus

| GitHubApiStatus | GitHubApiStatus.Extensions |
| --------------- | -------------------------- |
| [![NuGet](https://buildstats.info/nuget/GitHubApiStatus?includePreReleases=true)](https://www.nuget.org/packages/GitHubApiStatus/) | [![NuGet](https://buildstats.info/nuget/GitHubApiStatus.Extensions?includePreReleases=true)](https://www.nuget.org/packages/GitHubApiStatus.Extensions/) |

GitHubApiStatus makes it easy to understand GitHub's API Rate Limit!

- [Jump to the Setup](#Setup)
- [Jump to the GitHubApiStatus API](#GitHubApiStatus-API)
- [Jump to the GitHubApiStatus.Extensions API](#GitHubApiStatus.Extensions-API)
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

### GitHubApiStatus

- Available on NuGet: https://www.nuget.org/packages/GitHubApiStatus/ 
- Add to any project supporting .NET Standard 1.3

### GitHubApiStatus.Extensions

- Available on NuGet: https://www.nuget.org/packages/GitHubApiStatus/ 
- Add to any project supporting .NET Standard 2.0
- Leverages [Microsoft.Extensions.Http](https://www.nuget.org/packages/Microsoft.Extensions.Http/)

## GitHubApiStatus API

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
- Leverage's [GitHub Rate Limit API](https://docs.github.com/en/free-pro-team@latest/rest/reference/rate-limit) which does not count against your rate limit totals

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

## GitHubApiStatus.Extensions API

#### AddGitHubApiStatusService

```csharp
public static IHttpClientBuilder AddGitHubApiStatusService(this IServiceCollection services, AuthenticationHeaderValue authenticationHeaderValue, ProductHeaderValue productHeaderValue)
```
- Adds GitHubApiStatus.GitHubApiStatusService to `Microsoft.Extensions.DependencyInjection.IServiceCollection`

```csharp
public static IHttpClientBuilder AddGitHubApiStatusService<T>(this IServiceCollection services, AuthenticationHeaderValue authenticationHeaderValue, ProductHeaderValue productHeaderValue) where T : IGitHubApiStatusService
```
- Adds a custom implementation of IGitHubApiStatusService to `Microsoft.Extensions.DependencyInjection.IServiceCollection`
  
## Examples

- [Jump to Get Current GitHub API Status](#Get-Current-GitHub-API-Status)
- [Jump to Parse API Status from HttpResponseHeaders](#parse-api-status-from-httpresponseheaders)
- [Jump to Dependency Injection](#Dependency-Injection)

### Get Current GitHub API Status

```csharp
static async Task Main(string[] args)
{
    var gitHubApiStatusService = new GitHubApiStatusService(new AuthenticationHeaderValue("bearer", "Your GitHub Personal Access Token, e.g. 123456789012345"));

    //Generate Personal Access Token https://github.com/settings/tokens
    var apiRateLimits = await gitHubApiStatusService.GetApiRateLimits();

    // REST API Results
    Console.WriteLine($"What is the GitHub REST API Rate Limit? {apiRateLimits.RestApi.RateLimit}"); // What is the GitHub REST API Rate Limit? 5000
    Console.WriteLine($"How many REST API requests do I have remaining? {apiRateLimits.RestApi.RemainingRequestCount}"); // How many REST API requests do I have remaining? 4983
    Console.WriteLine($"How long until the GitHub REST API Rate Limit resets? {apiRateLimits.RestApi.RateLimitReset_TimeRemaining}"); // How long until the GitHub REST API Rate Limit resets? 00:40:13.8035515
    Console.WriteLine($"When does the GitHub REST API Rate Limit reset? {apiRateLimits.RestApi.RateLimitReset_DateTime}"); // When does the GitHub REST API Rate Limit reset? 10/29/2020 3:28:58 AM +00:00

    Console.WriteLine();

    // GraphQL API Results
    Console.WriteLine($"What is the GitHub GraphQL API Rate Limit? {apiRateLimits.GraphQLApi.RateLimit}"); // What is the GitHub GraphQL API Rate Limit? 5000
    Console.WriteLine($"How many GraphQL API requests do I have remaining? {apiRateLimits.GraphQLApi.RemainingRequestCount}"); // How many GraphQL API requests do I have remaining? 5000
    Console.WriteLine($"How long until the GitHub GraphQL API Rate Limit resets? {apiRateLimits.GraphQLApi.RateLimitReset_TimeRemaining}"); // How long until the GitHub GraphQL API Rate Limit resets? 00:59:59.8034526
    Console.WriteLine($"When does the GitHub GraphQL API Rate Limit reset? {apiRateLimits.GraphQLApi.RateLimitReset_DateTime}"); // When does the GitHub GraphQL API Rate Limit reset? 10/29/2020 3:48:44 AM +00:00

    Console.WriteLine();

    // Search API Results
    Console.WriteLine($"What is the GitHub Search API Rate Limit? {apiRateLimits.SearchApi.RateLimit}"); // What is the GitHub Search API Rate Limit? 30
    Console.WriteLine($"How many Search API requests do I have remaining? {apiRateLimits.SearchApi.RemainingRequestCount}"); // How many Search API requests do I have remaining? 30
    Console.WriteLine($"How long until the GitHub Search API Rate Limit resets? {apiRateLimits.SearchApi.RateLimitReset_TimeRemaining}"); // How long until the GitHub Search API Rate Limit resets? 00:00:59.8034988
    Console.WriteLine($"When does the GitHub Search API Rate Limit reset? {apiRateLimits.SearchApi.RateLimitReset_DateTime}"); // When does the GitHub Search API Rate Limit reset? 10/29/2020 2:49:44 AM +00:00
    
    Console.WriteLine();

    // Source Import API Results
    Console.WriteLine($"What is the GitHub Source Import API Rate Limit? {apiRateLimits.SourceImport.RateLimit}"); // What is the GitHub Source Import API Rate Limit? 100
    Console.WriteLine($"How many Source Import API requests do I have remaining? {apiRateLimits.SourceImport.RemainingRequestCount}"); // How many Source Import API requests do I have remaining? 100
    Console.WriteLine($"How long until the GitHub Source Import API Rate Limit resets? {apiRateLimits.SourceImport.RateLimitReset_TimeRemaining}"); // How long until the GitHub Source Import API Rate Limit resets? 00:00:59.8034154
    Console.WriteLine($"When does the GitHub Source Import API Rate Limit reset? {apiRateLimits.SourceImport.RateLimitReset_DateTime}"); // When does the GitHub Source Import API Rate Limit reset? 10/29/2020 2:49:44 AM +00:00

    Console.WriteLine();

    // App Manifest Configuration API Results
    Console.WriteLine($"What is the GitHub App Manifest Configuration API Rate Limit? {apiRateLimits.AppManifestConfiguration.RateLimit}"); // What is the GitHub App Manifest Configuration API Rate Limit? 5000
    Console.WriteLine($"How many App Manifest Configuration API requests do I have remaining? {apiRateLimits.AppManifestConfiguration.RemainingRequestCount}"); // How many App Manifest Configuration API requests do I have remaining? 5000
    Console.WriteLine($"How long until the GitHub App Manifest Configuration API Rate Limit resets? {apiRateLimits.AppManifestConfiguration.RateLimitReset_TimeRemaining}"); // How long until the GitHub App Manifest Configuration API Rate Limit resets? 00:59:59.8033802
    Console.WriteLine($"When does the GitHub App Manifest Configuration API Rate Limit reset? {apiRateLimits.AppManifestConfiguration.RateLimitReset_DateTime}"); // When does the GitHub App Manifest Configuration API Rate Limit reset? 10/29/2020 3:48:44 AM +00:00

    Console.WriteLine();

    // Code Scanning Upload API Results
    Console.WriteLine($"What is the GitHub Code Scanning Upload API Rate Limit? {apiRateLimits.CodeScanningUpload.RateLimit}"); // What is the GitHub Code Scanning Upload API Rate Limit? 500
    Console.WriteLine($"How many Code Scanning Upload API requests do I have remaining? {apiRateLimits.CodeScanningUpload.RemainingRequestCount}"); // How many Code Scanning Upload API requests do I have remaining? 500
    Console.WriteLine($"How long until the GitHub Code Scanning Upload API Rate Limit resets? {apiRateLimits.CodeScanningUpload.RateLimitReset_TimeRemaining}"); // How long until the GitHub Code Scanning Upload API Rate Limit resets? 00:59:59.8033455
    Console.WriteLine($"When does the GitHub Code Scanning Upload API Rate Limit reset? {apiRateLimits.CodeScanningUpload.RateLimitReset_DateTime}"); // When does the GitHub Code Scanning Upload API Rate Limit reset? 10/29/2020 3:48:44 AM +00:00
}
```

### Parse API status from `HttpResponseHeaders`

```csharp
const string _gitHubRestApiUrl = "https://api.github.com";

static readonly HttpClient _client = new HttpClient
{
    DefaultRequestHeaders =
    {
        { "Authorization", "bearer [Your GitHub Personal Access Token, e.g. 123456789012345]" }
        { "User-Agent", "GitHubApiStatus" }
    }
};

static async Task Main(string[] args)
{
    var gitHubApiStatusService = new GitHubApiStatusService(_client);

    HttpResponseMessage restApiResponse = await _client.GetAsync($"{ _gitHubRestApiUrl}/repos/brminnick/GitHubApiStatus");
    restApiResponse.EnsureSuccessStatusCode();

    TimeSpan rateLimitTimeRemaining = gitHubApiStatusService.GetRateLimitTimeRemaining(restApiResponse.Headers);

    int rateLimit = gitHubApiStatusService.GetRateLimit(restApiResponse.Headers);
    int remainingRequestCount = gitHubApiStatusService.GetRemainingRequestCount(restApiResponse.Headers);

    bool isAuthenticated = gitHubApiStatusService.IsAuthenticated(restApiResponse.Headers);

    bool hasReachedMaximumApiLimit = gitHubApiStatusService.HasReachedMaximimApiCallLimit(restApiResponse.Headers);

    Console.WriteLine($"What is the GitHub REST API Rate Limit? {rateLimit}"); // What is the GitHub REST API Rate Limit? 60

    Console.WriteLine($"Have I reached the Maximum REST API Limit? {hasReachedMaximumApiLimit}"); // Have I reached the Maximum REST API Limit? False
    Console.WriteLine($"How many REST API requests do I have remaining? {remainingRequestCount}"); // How many REST API requests do I have remaining? 56

    Console.WriteLine($"How long until the GitHub REST API Rate Limit resets? {rateLimitTimeRemaining}"); // How long until the GitHub REST API Rate Limit resets? 00:29:12.4134330

    Console.WriteLine($"Did the GitHub REST API Request include a Bearer Token? {isAuthenticated}"); // Did GitHub REST API Request include a Bearer Token? False
}
```

### Dependency Injection

- [Jump to Blazor Example](#blazor-example)
- [Jump to ASP.NET Core Example](#aspnet-core-example)
- [Jump to Azure Functions Example](#azure-functions-example)

#### Blazor Example

```csharp
public class Program
{
    public static Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        // AddGitHubApiStatusService 
        builder.Services.AddGitHubApiStatusService(new AuthenticationHeaderValue(GitHubConstants.AuthScheme, GitHubConstants.PersonalAccessToken), new ProductHeaderValue("MyApp"))
            .ConfigurePrimaryHttpMessageHandler(config => new HttpClientHandler { AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate });

        return builder.Build().RunAsync();
    }
}
```

```csharp
@page "/graphql"
@using GitHubApiStatus
@inject IGitHubApiStatusService GitHubApiStatusService

<h1>GitHub REST Api Status</h1>

<p>@_graphQLApiStatus</p>

<button class="btn btn-primary" @onclick="GetGraphQLApiStatus">Get Status</button>

@code {
    string _graphQLApiStatus = string.Empty;

    async Task GetGraphQLApiStatus()
    {
        var apiRateLimitStatuses = await GitHubApiStatusService.GetApiRateLimits(System.Threading.CancellationToken.None).ConfigureAwait(false);
        _graphQLApiStatus = apiRateLimitStatuses.GraphQLApi.ToString();
    }
}
```

#### ASP.NET Core Example

- Learn more about [Dependency Injection in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-5.0&WT.mc_id=mobile-11370-bramin)

```csharp
public class Startup
{
    // ...

    public void ConfigureServices(IServiceCollection services)
    {
        builder.Services.AddGitHubApiStatusService(new AuthenticationHeaderValue(GitHubConstants.AuthScheme, GitHubConstants.PersonalAccessToken), new ProductHeaderValue("MyApp"))
            .ConfigurePrimaryHttpMessageHandler(config => new HttpClientHandler { AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate });

        services.AddRazorPages();
    }

    /// ...

}
```

```csharp
class MyPageModel : PageModel
{
    readonly ILogger<IndexModel> _logger;
    readonly IGitHubApiStatusService _gitHubApiStatusService;

    public MyPageModel(IGitHubApiStatusService gitHubApiStatusService, ILogger<IndexModel> logger)
    {
        _logger = logger;
        _gitHubApiStatusService = gitHubApiStatusService;
    }

    // ...
}
```

### Azure Functions Example

- Requires [Microsoft.Azure.Functions.Extensions NuGet Package](https://www.nuget.org/packages/Microsoft.Azure.Functions.Extensions/)
- Learn More about [Azure Functions Dependency Injection](https://docs.microsoft.com/azure/azure-functions/functions-dotnet-dependency-injection?WT.mc_id=mobile-11370-bramin)

```csharp
[assembly: FunctionsStartup(typeof(MyApp.Functions.Startup))]
namespace MyApp.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddGitHubApiStatusService(new AuthenticationHeaderValue(GitHubConstants.AuthScheme, GitHubConstants.PersonalAccessToken), new ProductHeaderValue("MyApp"))
                .ConfigurePrimaryHttpMessageHandler(config => new HttpClientHandler { AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate });
        }
    }
}
```

```csharp
class GitHubApiStatusFunction
{
    readonly IGitHubApiStatusService _gitHubApiStatusService;

    public MyHttpTriggerFunction(IGitHubApiStatusService gitHubApiStatusService) => _gitHubApiStatusService = gitHubApiStatusService

    [FunctionName("GitHubApiStatus")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req, ILogger log)
    {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var apiStatus = await _gitHubApiStatusService.GetApiRateLimits(CancellationToken.None).ConfigureAwait(false);

            return new OkObjectResult(apiStatus);
    }
}
```