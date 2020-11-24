using Xamarin.Forms;
using Xamarin.CommunityToolkit.Markup;

namespace GitStatus
{
    abstract class BaseStatusPage<T> : BaseContentPage<T> where T : BaseStatusViewModel
    {
        protected BaseStatusPage(T statusViewModel, string title) : base(statusViewModel, title)
        {
            BackgroundColor = Color.White;

            Content = new StackLayout
            {
                Children =
                {
                    new Label { TextColor = Color.Black }.Center().TextCenter()
                        .Bind(Label.TextProperty, nameof(BaseStatusViewModel.StatusLabelText)),

                    new Button { Text = "Get Status"}.Center()
                        .Bind(Button.CommandProperty, nameof(BaseStatusViewModel.GetStatusCommand)),

                    new ActivityIndicator { Color = Color.Black }.Center()
                        .Bind(IsVisibleProperty, nameof(BaseStatusViewModel.IsBusy))
                        .Bind(ActivityIndicator.IsRunningProperty, nameof(BaseStatusViewModel.IsBusy))
                }
            }.Center();
        }
    }
}
