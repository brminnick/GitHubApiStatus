using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace GitStatus
{
    public class App : Xamarin.Forms.Application
    {
        public App()
        {
            var restApiStatusPage = ContainerService.Container.GetService<RestApiStatusPage>();
            var graphQLApiStatusPage = ContainerService.Container.GetService<GraphQLApiStatusPage>();

            var restStatusNavigationPage = new Xamarin.Forms.NavigationPage(restApiStatusPage);
            restStatusNavigationPage.On<iOS>().SetPrefersLargeTitles(true);

            var graphQLStatusNavigationPage = new Xamarin.Forms.NavigationPage(graphQLApiStatusPage);
            graphQLStatusNavigationPage.On<iOS>().SetPrefersLargeTitles(true);

            var tabbedPage = new Xamarin.Forms.TabbedPage
            {
                Children =
                {
                    restApiStatusPage,
                    graphQLApiStatusPage
                }
            };

            tabbedPage.On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            MainPage = tabbedPage;
        }
    }
}
