using System.Linq;
using System.Net.Http.Headers;

namespace GitHubApiStatus
{
    /// <summary>
    /// Extension Methods for HttpResponseHeaders
    /// </summary>
    public static class HttpResponseHeadersExtensions
    {
        /// <summary>
        /// Returns whether HttpResponseHeaders Contain X-RateLimit-Limit
        /// </summary>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static bool DoesContainGitHubRateLimitHeader(this HttpResponseHeaders headers) => headers.Any(x => x.Key is GitHubApiStatusService.RateLimitHeader);

        /// <summary>
        /// Returns whether HttpResponseHeaders Contain X-RateLimit-Reset
        /// </summary>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static bool DoesContainGitHubRateLimitResetHeader(this HttpResponseHeaders headers) => headers.Any(x => x.Key is GitHubApiStatusService.RateLimitResetHeader);

        /// <summary>
        /// Returns whether HttpResponseHeaders Contain X-RateLimit-Remaining
        /// </summary>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static bool DoesContainGitHubRateLimitRemainingHeader(this HttpResponseHeaders headers) => headers.Any(x => x.Key is GitHubApiStatusService.RateLimitRemainingHeader);
    }
}
