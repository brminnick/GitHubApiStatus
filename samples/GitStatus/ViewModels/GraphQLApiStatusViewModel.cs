using System;
using System.Threading;
using System.Threading.Tasks;
using GitHubApiStatus;

namespace GitStatus
{
    public class GraphQLApiStatusViewModel : BaseStatusViewModel
    {
        readonly IGitHubApiStatusService _gitHubApiStatusService;

        public GraphQLApiStatusViewModel(IGitHubApiStatusService gitHubApiStatusService) => _gitHubApiStatusService = gitHubApiStatusService;

        protected override async Task ExecuteGetStatusCommand()
        {
            var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            var apiRateLimitStatuses = await _gitHubApiStatusService.GetApiRateLimits(cancellationTokenSource.Token).ConfigureAwait(false);

            StatusLabelText = apiRateLimitStatuses.GraphQLApi.ToString();
        }
    }
}
