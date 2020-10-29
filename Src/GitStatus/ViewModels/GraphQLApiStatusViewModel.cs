using System.Net.Http.Headers;
using System.Threading.Tasks;
using GitHubApiStatus;
using GitStatus.Shared;

namespace GitStatus
{
    class GraphQLApiStatusViewModel : BaseStatusViewModel
    {
        readonly GitHubApiStatusService _gitHubApiStatusService;

        public GraphQLApiStatusViewModel(GitHubApiStatusService gitHubApiStatusService) => _gitHubApiStatusService = gitHubApiStatusService;

        protected override async Task ExecuteGetStatusCommand()
        {
            var authHeader = new AuthenticationHeaderValue("bearer", GitHubConstants.PersonalAccessToken);

            var apiRateLimitStatuses = await _gitHubApiStatusService.GetApiRateLimits(authHeader).ConfigureAwait(false);

            StatusLabelText = @$"Rate Limit: {apiRateLimitStatuses.GraphQLApi.RateLimit}
Remaining Request Count: {apiRateLimitStatuses.GraphQLApi.RemainingRequestCount}
Rate Limit Reset: {apiRateLimitStatuses.GraphQLApi.RateLimitReset_DateTime:dd MMMM @ HH:mm}
Reset Time Remainaing: {apiRateLimitStatuses.GraphQLApi.RateLimitReset_TimeRemaining}";
        }
    }
}
