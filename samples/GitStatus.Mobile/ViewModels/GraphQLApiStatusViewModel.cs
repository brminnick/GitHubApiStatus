using GitHubApiStatus;

namespace GitStatus;

class GraphQLApiStatusViewModel : BaseStatusViewModel
{
	readonly IGitHubApiStatusService _gitHubApiStatusService;

	public GraphQLApiStatusViewModel(IGitHubApiStatusService gitHubApiStatusService) => _gitHubApiStatusService = gitHubApiStatusService;

	protected override async Task GetStatus()
	{
		var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
		var apiRateLimitStatuses = await _gitHubApiStatusService.GetApiRateLimits(cancellationTokenSource.Token).ConfigureAwait(false);

		StatusLabelText = apiRateLimitStatuses.GraphQLApi.ToString();
	}
}