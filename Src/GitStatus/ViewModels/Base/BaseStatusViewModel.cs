using System.Threading.Tasks;
using AsyncAwaitBestPractices.MVVM;
using Xamarin.Essentials;

namespace GitStatus
{
    abstract class BaseStatusViewModel : BaseViewModel
    {
        string _statusLabelText = string.Empty;
        bool _isBusy;

        public BaseStatusViewModel(GitHubStatusService gitHubStatusService)
        {
            GitHubStatusService = gitHubStatusService;
            GetStatusCommand = new AsyncCommand(ExecuteGetStatusCommand, _ => !IsBusy);
        }

        public IAsyncCommand GetStatusCommand { get; }
        protected GitHubStatusService GitHubStatusService { get; }

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

        protected abstract Task<GitHubApiStatusModel> GetStatus();

        async Task ExecuteGetStatusCommand()
        {
            IsBusy = true;

            try
            {
                var status = await GetStatus().ConfigureAwait(false);
                StatusLabelText = status.ToString();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
