using System;
using System.Threading;
using System.Threading.Tasks;

namespace GitStatus
{
    class GraphQLApiStatusViewModel : BaseStatusViewModel
    {
        public GraphQLApiStatusViewModel(GitHubStatusService gitHubStatusService) : base(gitHubStatusService)
        {
        }

        protected override Task<GitHubApiStatusModel> GetStatus()
        {
            var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(3));
            return GitHubStatusService.GetGitHubGraphQlApiStatus(GitHubConstants.PersonalAccessToken, cancellationTokenSource.Token);
        }
    }
}
