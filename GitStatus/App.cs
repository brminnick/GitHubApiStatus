using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace GitStatus
{
    public class App : Xamarin.Forms.Application
    {
        public App()
        {
            Device.SetFlags(new[] { "Markup_Experimental" });

            var statusPage = ContainerService.Container.GetService<StatusPage>();

            var navigationPage = new Xamarin.Forms.NavigationPage(statusPage);
            navigationPage.On<iOS>().SetPrefersLargeTitles(true);

            MainPage = navigationPage;
        }
    }
}
