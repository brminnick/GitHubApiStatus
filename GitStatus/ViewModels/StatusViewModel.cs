using System;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices.MVVM;

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

            GetStatusCommand = new AsyncCommand(ExecuteGetStatusCommand);
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
            set => SetProperty(ref _isBusy, value);
        }

        async Task ExecuteGetStatusCommand()
        {
            IsBusy = true;

            try
            {
                var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(3));
                var status = await _gitHubStatusService.GetGitHubApiStatus(cancellationTokenSource.Token).ConfigureAwait(false);

                StatusLabelText = status.ToString();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
