using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;

namespace GitHubApiStatus.HttpExtensions
{
    public static class GitHubApiStatusServiceExtensions
    {
        public static IHttpClientBuilder AddGitHubApiClient(this IServiceCollection services, AuthenticationHeaderValue authenticationHeaderValue, ProductHeaderValue productHeaderValue)
        {
            return services.AddHttpClient<GitHubApiClientExtension>(client =>
            {
                client.DefaultRequestHeaders.Authorization = authenticationHeaderValue;
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(productHeaderValue));
            });
        }
    }
}
