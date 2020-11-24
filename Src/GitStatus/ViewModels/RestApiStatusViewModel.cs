using System.Net.Http.Headers;
using System.Threading.Tasks;
using GitHubApiStatus;
using GitStatus.Shared;

namespace GitStatus
{
    class RestApiStatusViewModel : BaseStatusViewModel
    {
        readonly GitHubApiStatusService _gitHubApiStatusService;

        public RestApiStatusViewModel(GitHubApiStatusService gitHubApiStatusService) => _gitHubApiStatusService = gitHubApiStatusService;

        protected override async Task ExecuteGetStatusCommand()
        {
            var apiRateLimitStatuses = await _gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);

            StatusLabelText = @$"Rate Limit: {apiRateLimitStatuses.RestApi.RateLimit}
Remaining Request Count: {apiRateLimitStatuses.RestApi.RemainingRequestCount}
Rate Limit Reset: {apiRateLimitStatuses.RestApi.RateLimitReset_DateTime:dd MMMM @ HH:mm}
Reset Time Remainaing: {apiRateLimitStatuses.RestApi.RateLimitReset_TimeRemaining}";
        }
    }
}
