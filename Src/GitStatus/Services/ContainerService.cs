using System;
using System.Net.Http.Headers;
using GitHubApiStatus.Extensions;
using GitStatus.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace GitStatus
{
    public class ContainerService
    {
        readonly static Lazy<ServiceProvider> _serviceProviderHolder = new(CreateContainer);

        public static ServiceProvider Container => _serviceProviderHolder.Value;

        static ServiceProvider CreateContainer()
        {
            var services = new ServiceCollection();

            services.AddSingleton<App>();

            //ContentPage
            services.AddTransient<RestApiStatusPage>();
            services.AddTransient<GraphQLApiStatusPage>();

            //ViewModels
            services.AddTransient<RestApiStatusViewModel>();
            services.AddTransient<GraphQLApiStatusViewModel>();

            //Services
            services.AddGitHubApiStatusService(new AuthenticationHeaderValue(GitHubConstants.AuthScheme, GitHubConstants.PersonalAccessToken), new ProductHeaderValue(nameof(GitStatus)));

            return services.BuildServiceProvider();
        }
    }
}
