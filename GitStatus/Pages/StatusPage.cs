using Xamarin.Forms;
using Xamarin.Forms.Markup;

namespace GitStatus
{
    class StatusPage : BaseContentPage<StatusViewModel>
    {
        public StatusPage(StatusViewModel statusViewModel) : base(statusViewModel, "GitHub Api Stats")
        {
            Content = new StackLayout
            {
                Children =
                {
                    new Label().Center().TextCenter()
                        .Bind(Label.TextProperty, nameof(StatusViewModel.StatusLabelText)),

                    new Button { Text = "Get Status"}.Center()
                        .Bind(Button.CommandProperty, nameof(StatusViewModel.GetStatusCommand)),

                    new ActivityIndicator().Center()
                        .Bind(IsVisibleProperty, nameof(StatusViewModel.IsBusy))
                        .Bind(ActivityIndicator.IsRunningProperty, nameof(StatusViewModel.IsBusy))
                }
            }.Center();
        }
    }
}
