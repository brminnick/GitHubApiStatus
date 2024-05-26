using System.Net;
using GitHubApiStatus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace GitStatus.API;

class GitHubApiStatus
{
	readonly IGitHubApiStatusService _gitHubApiStatusService;

	public GitHubApiStatus(IGitHubApiStatusService gitHubApiStatusService) => _gitHubApiStatusService = gitHubApiStatusService;

	[Function(nameof(GitHubApiStatus))]
	public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequestData req, FunctionContext context)
	{
		context.GetLogger<GitHubApiStatus>().LogInformation("Retrieving Api Rate Limits");

		var apiStatus = await _gitHubApiStatusService.GetApiRateLimits(CancellationToken.None).ConfigureAwait(false);

		var response = req.CreateResponse(HttpStatusCode.OK);
		await response.WriteAsJsonAsync(apiStatus).ConfigureAwait(false);

		return response;
	}
}