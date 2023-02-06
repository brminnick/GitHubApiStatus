using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace GitStatus;

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
	protected BaseContentPage(in T viewModel, in string title, bool shouldUseSafeArea = false)
		: base(title, shouldUseSafeArea)
	{
		base.BindingContext = viewModel;
	}

	protected new T BindingContext => (T)base.BindingContext;
}