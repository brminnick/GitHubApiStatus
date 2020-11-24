using System.Threading.Tasks;
using GitHubApiStatus;

namespace GitStatus
{
    class GraphQLApiStatusViewModel : BaseStatusViewModel
    {
        readonly GitHubApiStatusService _gitHubApiStatusService;

        public GraphQLApiStatusViewModel(GitHubApiStatusService gitHubApiStatusService) => _gitHubApiStatusService = gitHubApiStatusService;

        protected override async Task ExecuteGetStatusCommand()
        {
            var apiRateLimitStatuses = await _gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);

            StatusLabelText = @$"Rate Limit: {apiRateLimitStatuses.GraphQLApi.RateLimit}
Remaining Request Count: {apiRateLimitStatuses.GraphQLApi.RemainingRequestCount}
Rate Limit Reset: {apiRateLimitStatuses.GraphQLApi.RateLimitReset_DateTime:dd MMMM @ HH:mm}
Reset Time Remainaing: {apiRateLimitStatuses.GraphQLApi.RateLimitReset_TimeRemaining}";
        }
    }
}
