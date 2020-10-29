using System;
using GitHubApiStatus;
using Microsoft.Extensions.DependencyInjection;

namespace GitStatus
{
    public class ContainerService
    {
        readonly static Lazy<ServiceProvider> _serviceProviderHolder = new Lazy<ServiceProvider>(CreateContainer);

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
            services.AddSingleton<GitHubApiStatusService>();

            return services.BuildServiceProvider();
        }
    }
}
