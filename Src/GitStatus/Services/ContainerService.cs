using System;
using System.Net.Http;
using GitHubApiStatus;
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

            //ContentPage
            services.AddTransient<RestApiStatusPage>();
            services.AddTransient<GraphQLApiStatusPage>();

            //ViewModels
            services.AddTransient<RestApiStatusViewModel>();
            services.AddTransient<GraphQLApiStatusViewModel>();

            //Services
            services.AddSingleton(new HttpClient
            {
                DefaultRequestHeaders =
                {
                    { "User-Agent", nameof(GitStatus) },
                    { "Authorization", "bearer " + GitHubConstants.PersonalAccessToken }
                }
            });
            services.AddSingleton<GitHubApiStatusService>();

            return services.BuildServiceProvider();
        }
    }
}
