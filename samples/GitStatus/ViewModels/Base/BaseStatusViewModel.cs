using System.Threading.Tasks;
using AsyncAwaitBestPractices.MVVM;
using GitHubApiStatus;
using Xamarin.Essentials;

namespace GitStatus
{
    public abstract class BaseStatusViewModel : BaseViewModel
    {
        string _statusLabelText = string.Empty;
        bool _isBusy;

        protected BaseStatusViewModel()
        {
            GetStatusCommand = new AsyncCommand(ExecuteGetStatusCommand, _ => !IsBusy);
        }

        public IAsyncCommand GetStatusCommand { get; }

        public RateLimitStatus? RestApiStatus { get; private set; }
        public RateLimitStatus? GraphQLApiStatus { get; private set; }

        public string StatusLabelText
        {
            get => _statusLabelText;
            set => SetProperty(ref _statusLabelText, value);
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value, () => MainThread.BeginInvokeOnMainThread(GetStatusCommand.RaiseCanExecuteChanged));
        }

        protected abstract Task ExecuteGetStatusCommand();
    }
}
