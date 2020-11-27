using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;

namespace GitHubApiStatus.Extensions
{
    public static class GitHubApiStatusServiceExtensions
    {
        public static IServiceCollection AddGitHubApiClient(this IServiceCollection services, AuthenticationHeaderValue authenticationHeaderValue, ProductHeaderValue productHeaderValue)
        {
            return services.AddSingleton(new GitHubApiClient(authenticationHeaderValue, productHeaderValue));
        }
    }
}
