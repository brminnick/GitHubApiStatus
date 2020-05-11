using System;
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
            services.AddTransient<StatusPage>();

            //ViewModels
            services.AddTransient<StatusViewModel>();

            //Services
            services.AddSingleton<GitHubStatusService>();

            return services.BuildServiceProvider();
        }
    }
}
