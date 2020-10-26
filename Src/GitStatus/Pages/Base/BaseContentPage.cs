using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace GitStatus
{
    abstract class BaseContentPage : ContentPage
    {
        protected BaseContentPage(in string title = "", bool shouldUseSafeArea = true)
        {
            Title = title;

            On<iOS>().SetUseSafeArea(shouldUseSafeArea);
            On<iOS>().SetModalPresentationStyle(UIModalPresentationStyle.FormSheet);
        }
    }

    abstract class BaseContentPage<T> : BaseContentPage where T : BaseViewModel
    {
        protected BaseContentPage(in T viewModel, in string title = "", bool shouldUseSafeArea = false)
            : base(title, shouldUseSafeArea)
        {
            BindingContext = ViewModel = viewModel;
        }

        protected T ViewModel { get; }
    }
}
