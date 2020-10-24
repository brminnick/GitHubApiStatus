using Xamarin.Forms;
using Xamarin.Forms.Markup;

namespace GitStatus
{
    class StatusPage : BaseContentPage<StatusViewModel>
    {
        public StatusPage(StatusViewModel statusViewModel) : base(statusViewModel, "GitHub Api Status")
        {
            BackgroundColor = Color.White;

            Content = new StackLayout
            {
                Children =
                {
                    new Label { TextColor = Color.Black }.Center().TextCenter()
                        .Bind(Label.TextProperty, nameof(StatusViewModel.StatusLabelText)),

                    new Button { Text = "Get Status"}.Center()
                        .Bind(Button.CommandProperty, nameof(StatusViewModel.GetStatusCommand)),

                    new ActivityIndicator { Color = Color.Black }.Center()
                        .Bind(IsVisibleProperty, nameof(StatusViewModel.IsBusy))
                        .Bind(ActivityIndicator.IsRunningProperty, nameof(StatusViewModel.IsBusy))
                }
            }.Center();
        }
    }
}
