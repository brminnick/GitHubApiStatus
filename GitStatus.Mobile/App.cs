using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace GitStatus.Mobile
{
    public class App : Xamarin.Forms.Application
    {
        public App()
        {
            Device.SetFlags(new[] { "Markup_Experimental" });

            var restApiStatusPage = ContainerService.Container.GetService<RestApiStatusPage>();
            var graphQLApiStatusPage = ContainerService.Container.GetService<GraphQLApiStatusPage>();

            var restStatusNavigationPage = new Xamarin.Forms.NavigationPage(restApiStatusPage);
            restStatusNavigationPage.On<iOS>().SetPrefersLargeTitles(true);

            var graphQLStatusNavigationPage = new Xamarin.Forms.NavigationPage(graphQLApiStatusPage);
            graphQLStatusNavigationPage.On<iOS>().SetPrefersLargeTitles(true);

            MainPage = new Xamarin.Forms.TabbedPage
            {
                Children =
                {
                    restApiStatusPage,
                    graphQLApiStatusPage
                }
            };
        }
    }
}
