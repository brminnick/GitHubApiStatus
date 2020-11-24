using System;
using System.Threading;
using System.Threading.Tasks;
using GitHubApiStatus;

namespace GitStatus
{
    class RestApiStatusViewModel : BaseStatusViewModel
    {
        readonly IGitHubApiStatusService _gitHubApiStatusService;

        public RestApiStatusViewModel(IGitHubApiStatusService gitHubApiStatusService) => _gitHubApiStatusService = gitHubApiStatusService;

        protected override async Task ExecuteGetStatusCommand()
        {
            var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            var apiRateLimitStatuses = await _gitHubApiStatusService.GetApiRateLimits(cancellationTokenSource.Token).ConfigureAwait(false);

            StatusLabelText = @$"Rate Limit: {apiRateLimitStatuses.RestApi.RateLimit}
Remaining Request Count: {apiRateLimitStatuses.RestApi.RemainingRequestCount}
Rate Limit Reset: {apiRateLimitStatuses.RestApi.RateLimitReset_DateTime:dd MMMM @ HH:mm}
Reset Time Remainaing: {apiRateLimitStatuses.RestApi.RateLimitReset_TimeRemaining}";
        }
    }
}
