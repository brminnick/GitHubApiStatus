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
                    new Label().Center().TextCenter(),
                    new Button { Text = "Get Status"}.Center(),
                    new ActivityIndicator().Center()
                }
            }.Center();
        }
    }
}
