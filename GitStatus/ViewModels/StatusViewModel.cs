using System;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices.MVVM;
using Xamarin.Essentials;

namespace GitStatus
{
    class StatusViewModel : BaseViewModel
    {
        readonly GitHubStatusService _gitHubStatusService;

        string _statusLabelText = string.Empty;
        bool _isBusy;

        public StatusViewModel(GitHubStatusService gitHubStatusService)
        {
            _gitHubStatusService = gitHubStatusService;

            GetStatusCommand = new AsyncCommand(ExecuteGetStatusCommand, _ => !IsBusy);
        }

        public IAsyncCommand GetStatusCommand { get; }

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

        async Task ExecuteGetStatusCommand()
        {
            IsBusy = true;

            try
            {
                var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(3));
                var status = await _gitHubStatusService.GetGitHubApiStatus(GitHubConstants.PersonalAccessToken, cancellationTokenSource.Token).ConfigureAwait(false);

                StatusLabelText = status.ToString();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
