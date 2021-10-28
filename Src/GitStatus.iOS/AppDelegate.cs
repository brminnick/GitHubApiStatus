using Foundation;
using Microsoft.Extensions.DependencyInjection;
using UIKit;

namespace GitStatus.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(ContainerService.Container.GetRequiredService<App>());

            return base.FinishedLaunching(app, options);
        }
    }
}
