using System;
using System.Threading;
using System.Threading.Tasks;
using GitHubApiStatus;

namespace GitStatus;

class RestApiStatusViewModel : BaseStatusViewModel
{
	readonly IGitHubApiStatusService _gitHubApiStatusService;

	public RestApiStatusViewModel(IGitHubApiStatusService gitHubApiStatusService) => _gitHubApiStatusService = gitHubApiStatusService;

	protected override async Task GetStatus()
	{
		var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
		var apiRateLimitStatuses = await _gitHubApiStatusService.GetApiRateLimits(cancellationTokenSource.Token).ConfigureAwait(false);

		StatusLabelText = apiRateLimitStatuses.RestApi.ToString();
	}
}