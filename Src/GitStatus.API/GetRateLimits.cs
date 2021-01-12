using System.Threading;
using System.Threading.Tasks;
using GitHubApiStatus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace GitStatus.API
{
    class GitHubApiStatus
    {
        readonly IGitHubApiStatusService _gitHubApiStatusService;

        public GitHubApiStatus(IGitHubApiStatusService gitHubApiStatusService) => _gitHubApiStatusService = gitHubApiStatusService;

        [FunctionName(nameof(GitHubApiStatus))]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("Retrieving Api Rate Limits");

            var apiStatus = await _gitHubApiStatusService.GetApiRateLimits(CancellationToken.None).ConfigureAwait(false);

            return new OkObjectResult(apiStatus);
        }
    }
}
