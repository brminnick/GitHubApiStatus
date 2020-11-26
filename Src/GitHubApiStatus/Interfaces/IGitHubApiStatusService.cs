using System;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace GitHubApiStatus
{
    /// <summary>
    /// Interface for GitHubApiStatusService
    /// </summary>
    public interface IGitHubApiStatusService
    {
        /// <summary>
        /// Get the API Rate Limits for the GitHub REST API, GraphQL API, Search API, Code Scanning API and App Manifest Configuration API
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<GitHubApiRateLimits> GetApiRateLimits(CancellationToken cancellationToken);

        /// <summary>
        /// Get GitHub API Rate Limit
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>GitHub Api Rate Limit </returns>
        int GetRateLimit(in HttpResponseHeaders httpResponseHeaders);

        /// <summary>
        /// Get Number of GitHub API Requests Remaining
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>Number of GitHub API Requests Remaining</returns>
        int GetRemainingRequestCount(in HttpResponseHeaders httpResponseHeaders);

        /// <summary>
        /// Determines Whether GitHub's Maximum API Limit Has Been Reached
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>Whether GitHub's Maximum API Limit Has Been Reached</returns>
        bool HasReachedMaximimApiCallLimit(in HttpResponseHeaders httpResponseHeaders);

        /// <summary>
        /// Get Time Remaining Until GitHub API Rate Limit Resets
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>Time Remaining Until GitHub API Rate Limit Resets</returns>
        TimeSpan GetRateLimitTimeRemaining(in HttpResponseHeaders httpResponseHeaders);

        /// <summary>
        /// Determines Whether the Http Response Was From an Authenticated Http Request
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>Whether the Http Response Was From an Authenticated Http Request</returns>
        bool IsResponseFromAuthenticatedRequest(in HttpResponseHeaders httpResponseHeaders);

        /// <summary>
        /// Get the DateTimeOffset When the GitHub API Rate Limit Will Reset
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>DateTimeOffset When the GitHub API Rate Limit Will Reset</returns>
        DateTimeOffset GetRateLimitResetDateTime(in HttpResponseHeaders httpResponseHeaders);

        /// <summary>
        /// Get the Unix Epoch Seconds When the GitHub API Rate Limit Will Reset
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>Unix Epoch Seconds When the GitHub API Rate Limit Will Reset</returns>
        long GetRateLimitResetDateTime_UnixEpochSeconds(in HttpResponseHeaders httpResponseHeaders);
    }
}
