using System;
using System.Threading;
using System.Threading.Tasks;

namespace GitStatus.Mobile
{
    class RestApiStatusViewModel : BaseStatusViewModel
    {
        public RestApiStatusViewModel(GitHubStatusService gitHubStatusService) : base(gitHubStatusService)
        {
        }

        protected override Task<GitHubApiStatusModel> GetStatus()
        {
            var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(3));
            return GitHubStatusService.GetGitHubRestApiStatus(GitHubConstants.PersonalAccessToken, cancellationTokenSource.Token);
        }
    }
}
