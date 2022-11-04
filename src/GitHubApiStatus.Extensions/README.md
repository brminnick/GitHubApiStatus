# GitHubApiStatus.Extensions

[![NuGet](https://buildstats.info/nuget/GitHubApiStatus.Extensions?includePreReleases=true)](https://www.nuget.org/packages/GitHubApiStatus.Extensions/)

- Available on NuGet: https://www.nuget.org/packages/GitHubApiStatus.Extensions/ 
- Add to any project supporting .NET Standard 2.0
- Leverages [Microsoft.Extensions.Http](https://www.nuget.org/packages/Microsoft.Extensions.Http/)

## API

### AddGitHubApiStatusService

```csharp
public static IHttpClientBuilder AddGitHubApiStatusService(this IServiceCollection services, AuthenticationHeaderValue authenticationHeaderValue, ProductHeaderValue productHeaderValue)
```
- Adds GitHubApiStatus.GitHubApiStatusService to `Microsoft.Extensions.DependencyInjection.IServiceCollection`

### AddGitHubApiStatusService&lt;TGitHubApiStatusService&gt;

```csharp
public static IHttpClientBuilder AddGitHubApiStatusService<TGitHubApiStatusService>(this IServiceCollection services, AuthenticationHeaderValue authenticationHeaderValue, ProductHeaderValue productHeaderValue) where TGitHubApiStatusService : IGitHubApiStatusService
```
- Adds a custom implementation of IGitHubApiStatusService to `Microsoft.Extensions.DependencyInjection.IServiceCollection`
  
## Dependency Injection

- [Jump to Blazor Example](#blazor-example)
- [Jump to ASP.NET Core Example](#aspnet-core-example)
- [Jump to Azure Functions Example](#azure-functions-example)

### Blazor Example

```csharp
public class Program
{
    public static Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        // AddGitHubApiStatusService 
        builder.Services.AddGitHubApiStatusService(new AuthenticationHeaderValue("bearer", "[Your GitHub Personal Access Token, e.g. 123456789012345]"), new ProductHeaderValue("MyApp"))
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

### ASP.NET Core Example

- Learn more about [Dependency Injection in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-5.0&WT.mc_id=mobile-11370-bramin)

```csharp
public class Startup
{
    // ...

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddGitHubApiStatusService(new AuthenticationHeaderValue("bearer", "[Your GitHub Personal Access Token, e.g. 123456789012345]"), new ProductHeaderValue("MyApp"))
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

    public MyPageModel(IGitHubApiStatusService gitHubApiStatusService, ILogger<MyPageModel> logger)
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
            builder.Services.AddGitHubApiStatusService(new AuthenticationHeaderValue("bearer", "[Your GitHub Personal Access Token, e.g. 123456789012345]"), new ProductHeaderValue("MyApp"))
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

        var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(2));
        var apiStatus = await _gitHubApiStatusService.GetApiRateLimits(cancellationTokenSource.Token).ConfigureAwait(false);

        return new OkObjectResult(apiStatus);
    }
}
```
