using System;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;


/* Unmerged change from project 'GitHubApiStatus(netstandard2.0)'
Before:
namespace GitHubApiStatus
{
    /// <summary>
    /// Interface for GitHubApiStatusService
    /// </summary>
    public interface IGitHubApiStatusService
    {
        /// <summary>
        /// Determines if GitHubApiClient.DefaultRequestHeaders.UserAgent is Valid
        /// </summary>
        bool IsProductHeaderValueValid { get; }

        /// <summary>
        /// Determines if GitHubApiClient.DefaultRequestHeaders.Authorization is Valid
        /// </summary>
        bool IsAuthenticationHeaderValueSet { get; }

        /// <summary>
        /// Add ProductHeaderValue to HttpClient.DefaultRequestHeaders.UserAgent
        /// </summary>
        /// <param name="productHeaderValue"></param>
        void AddProductHeaderValue(ProductHeaderValue productHeaderValue);

        /// <summary>
        /// Set HttpClient.DefaultRequestHeaders.Authorization
        /// </summary>
        /// <param name="authenticationHeaderValue"></param>
        void SetAuthenticationHeaderValue(AuthenticationHeaderValue authenticationHeaderValue);

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
        /// Determines Whether GitHub's Abuse Rate Limit Has Been Reached
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <param name="delta">Time Remaining in Retry-After Header</param>
        /// <returns></returns>
        bool IsAbuseRateLimit(in HttpResponseHeaders httpResponseHeaders, out TimeSpan? delta);

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
After:
namespace GitHubApiStatus;

    /// <summary>
    /// Interface for GitHubApiStatusService
    /// </summary>
    public interface IGitHubApiStatusService
    {
        /// <summary>
        /// Determines if GitHubApiClient.DefaultRequestHeaders.UserAgent is Valid
        /// </summary>
        bool IsProductHeaderValueValid { get; }

        /// <summary>
        /// Determines if GitHubApiClient.DefaultRequestHeaders.Authorization is Valid
        /// </summary>
        bool IsAuthenticationHeaderValueSet { get; }

        /// <summary>
        /// Add ProductHeaderValue to HttpClient.DefaultRequestHeaders.UserAgent
        /// </summary>
        /// <param name="productHeaderValue"></param>
        void AddProductHeaderValue(ProductHeaderValue productHeaderValue);

        /// <summary>
        /// Set HttpClient.DefaultRequestHeaders.Authorization
        /// </summary>
        /// <param name="authenticationHeaderValue"></param>
        void SetAuthenticationHeaderValue(AuthenticationHeaderValue authenticationHeaderValue);

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
        /// Determines Whether GitHub's Abuse Rate Limit Has Been Reached
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <param name="delta">Time Remaining in Retry-After Header</param>
        /// <returns></returns>
        bool IsAbuseRateLimit(in HttpResponseHeaders httpResponseHeaders, out TimeSpan? delta);

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
*/

/* Unmerged change from project 'GitHubApiStatus(netstandard2.1)'
Before:
namespace GitHubApiStatus
{
    /// <summary>
    /// Interface for GitHubApiStatusService
    /// </summary>
    public interface IGitHubApiStatusService
    {
        /// <summary>
        /// Determines if GitHubApiClient.DefaultRequestHeaders.UserAgent is Valid
        /// </summary>
        bool IsProductHeaderValueValid { get; }

        /// <summary>
        /// Determines if GitHubApiClient.DefaultRequestHeaders.Authorization is Valid
        /// </summary>
        bool IsAuthenticationHeaderValueSet { get; }

        /// <summary>
        /// Add ProductHeaderValue to HttpClient.DefaultRequestHeaders.UserAgent
        /// </summary>
        /// <param name="productHeaderValue"></param>
        void AddProductHeaderValue(ProductHeaderValue productHeaderValue);

        /// <summary>
        /// Set HttpClient.DefaultRequestHeaders.Authorization
        /// </summary>
        /// <param name="authenticationHeaderValue"></param>
        void SetAuthenticationHeaderValue(AuthenticationHeaderValue authenticationHeaderValue);

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
        /// Determines Whether GitHub's Abuse Rate Limit Has Been Reached
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <param name="delta">Time Remaining in Retry-After Header</param>
        /// <returns></returns>
        bool IsAbuseRateLimit(in HttpResponseHeaders httpResponseHeaders, out TimeSpan? delta);

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
After:
namespace GitHubApiStatus;

    /// <summary>
    /// Interface for GitHubApiStatusService
    /// </summary>
    public interface IGitHubApiStatusService
    {
        /// <summary>
        /// Determines if GitHubApiClient.DefaultRequestHeaders.UserAgent is Valid
        /// </summary>
        bool IsProductHeaderValueValid { get; }

        /// <summary>
        /// Determines if GitHubApiClient.DefaultRequestHeaders.Authorization is Valid
        /// </summary>
        bool IsAuthenticationHeaderValueSet { get; }

        /// <summary>
        /// Add ProductHeaderValue to HttpClient.DefaultRequestHeaders.UserAgent
        /// </summary>
        /// <param name="productHeaderValue"></param>
        void AddProductHeaderValue(ProductHeaderValue productHeaderValue);

        /// <summary>
        /// Set HttpClient.DefaultRequestHeaders.Authorization
        /// </summary>
        /// <param name="authenticationHeaderValue"></param>
        void SetAuthenticationHeaderValue(AuthenticationHeaderValue authenticationHeaderValue);

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
        /// Determines Whether GitHub's Abuse Rate Limit Has Been Reached
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <param name="delta">Time Remaining in Retry-After Header</param>
        /// <returns></returns>
        bool IsAbuseRateLimit(in HttpResponseHeaders httpResponseHeaders, out TimeSpan? delta);

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
*/

/* Unmerged change from project 'GitHubApiStatus(netcoreapp3.0)'
Before:
namespace GitHubApiStatus
{
    /// <summary>
    /// Interface for GitHubApiStatusService
    /// </summary>
    public interface IGitHubApiStatusService
    {
        /// <summary>
        /// Determines if GitHubApiClient.DefaultRequestHeaders.UserAgent is Valid
        /// </summary>
        bool IsProductHeaderValueValid { get; }

        /// <summary>
        /// Determines if GitHubApiClient.DefaultRequestHeaders.Authorization is Valid
        /// </summary>
        bool IsAuthenticationHeaderValueSet { get; }

        /// <summary>
        /// Add ProductHeaderValue to HttpClient.DefaultRequestHeaders.UserAgent
        /// </summary>
        /// <param name="productHeaderValue"></param>
        void AddProductHeaderValue(ProductHeaderValue productHeaderValue);

        /// <summary>
        /// Set HttpClient.DefaultRequestHeaders.Authorization
        /// </summary>
        /// <param name="authenticationHeaderValue"></param>
        void SetAuthenticationHeaderValue(AuthenticationHeaderValue authenticationHeaderValue);

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
        /// Determines Whether GitHub's Abuse Rate Limit Has Been Reached
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <param name="delta">Time Remaining in Retry-After Header</param>
        /// <returns></returns>
        bool IsAbuseRateLimit(in HttpResponseHeaders httpResponseHeaders, out TimeSpan? delta);

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
After:
namespace GitHubApiStatus;

    /// <summary>
    /// Interface for GitHubApiStatusService
    /// </summary>
    public interface IGitHubApiStatusService
    {
        /// <summary>
        /// Determines if GitHubApiClient.DefaultRequestHeaders.UserAgent is Valid
        /// </summary>
        bool IsProductHeaderValueValid { get; }

        /// <summary>
        /// Determines if GitHubApiClient.DefaultRequestHeaders.Authorization is Valid
        /// </summary>
        bool IsAuthenticationHeaderValueSet { get; }

        /// <summary>
        /// Add ProductHeaderValue to HttpClient.DefaultRequestHeaders.UserAgent
        /// </summary>
        /// <param name="productHeaderValue"></param>
        void AddProductHeaderValue(ProductHeaderValue productHeaderValue);

        /// <summary>
        /// Set HttpClient.DefaultRequestHeaders.Authorization
        /// </summary>
        /// <param name="authenticationHeaderValue"></param>
        void SetAuthenticationHeaderValue(AuthenticationHeaderValue authenticationHeaderValue);

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
        /// Determines Whether GitHub's Abuse Rate Limit Has Been Reached
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <param name="delta">Time Remaining in Retry-After Header</param>
        /// <returns></returns>
        bool IsAbuseRateLimit(in HttpResponseHeaders httpResponseHeaders, out TimeSpan? delta);

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
*/

/* Unmerged change from project 'GitHubApiStatus(net5.0)'
Before:
namespace GitHubApiStatus
{
    /// <summary>
    /// Interface for GitHubApiStatusService
    /// </summary>
    public interface IGitHubApiStatusService
    {
        /// <summary>
        /// Determines if GitHubApiClient.DefaultRequestHeaders.UserAgent is Valid
        /// </summary>
        bool IsProductHeaderValueValid { get; }

        /// <summary>
        /// Determines if GitHubApiClient.DefaultRequestHeaders.Authorization is Valid
        /// </summary>
        bool IsAuthenticationHeaderValueSet { get; }

        /// <summary>
        /// Add ProductHeaderValue to HttpClient.DefaultRequestHeaders.UserAgent
        /// </summary>
        /// <param name="productHeaderValue"></param>
        void AddProductHeaderValue(ProductHeaderValue productHeaderValue);

        /// <summary>
        /// Set HttpClient.DefaultRequestHeaders.Authorization
        /// </summary>
        /// <param name="authenticationHeaderValue"></param>
        void SetAuthenticationHeaderValue(AuthenticationHeaderValue authenticationHeaderValue);

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
        /// Determines Whether GitHub's Abuse Rate Limit Has Been Reached
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <param name="delta">Time Remaining in Retry-After Header</param>
        /// <returns></returns>
        bool IsAbuseRateLimit(in HttpResponseHeaders httpResponseHeaders, out TimeSpan? delta);

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
After:
namespace GitHubApiStatus;

    /// <summary>
    /// Interface for GitHubApiStatusService
    /// </summary>
    public interface IGitHubApiStatusService
    {
        /// <summary>
        /// Determines if GitHubApiClient.DefaultRequestHeaders.UserAgent is Valid
        /// </summary>
        bool IsProductHeaderValueValid { get; }

        /// <summary>
        /// Determines if GitHubApiClient.DefaultRequestHeaders.Authorization is Valid
        /// </summary>
        bool IsAuthenticationHeaderValueSet { get; }

        /// <summary>
        /// Add ProductHeaderValue to HttpClient.DefaultRequestHeaders.UserAgent
        /// </summary>
        /// <param name="productHeaderValue"></param>
        void AddProductHeaderValue(ProductHeaderValue productHeaderValue);

        /// <summary>
        /// Set HttpClient.DefaultRequestHeaders.Authorization
        /// </summary>
        /// <param name="authenticationHeaderValue"></param>
        void SetAuthenticationHeaderValue(AuthenticationHeaderValue authenticationHeaderValue);

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
        /// Determines Whether GitHub's Abuse Rate Limit Has Been Reached
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <param name="delta">Time Remaining in Retry-After Header</param>
        /// <returns></returns>
        bool IsAbuseRateLimit(in HttpResponseHeaders httpResponseHeaders, out TimeSpan? delta);

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
*/

/* Unmerged change from project 'GitHubApiStatus(net6.0)'
Before:
namespace GitHubApiStatus
{
    /// <summary>
    /// Interface for GitHubApiStatusService
    /// </summary>
    public interface IGitHubApiStatusService
    {
        /// <summary>
        /// Determines if GitHubApiClient.DefaultRequestHeaders.UserAgent is Valid
        /// </summary>
        bool IsProductHeaderValueValid { get; }

        /// <summary>
        /// Determines if GitHubApiClient.DefaultRequestHeaders.Authorization is Valid
        /// </summary>
        bool IsAuthenticationHeaderValueSet { get; }

        /// <summary>
        /// Add ProductHeaderValue to HttpClient.DefaultRequestHeaders.UserAgent
        /// </summary>
        /// <param name="productHeaderValue"></param>
        void AddProductHeaderValue(ProductHeaderValue productHeaderValue);

        /// <summary>
        /// Set HttpClient.DefaultRequestHeaders.Authorization
        /// </summary>
        /// <param name="authenticationHeaderValue"></param>
        void SetAuthenticationHeaderValue(AuthenticationHeaderValue authenticationHeaderValue);

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
        /// Determines Whether GitHub's Abuse Rate Limit Has Been Reached
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <param name="delta">Time Remaining in Retry-After Header</param>
        /// <returns></returns>
        bool IsAbuseRateLimit(in HttpResponseHeaders httpResponseHeaders, out TimeSpan? delta);

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
After:
namespace GitHubApiStatus;

    /// <summary>
    /// Interface for GitHubApiStatusService
    /// </summary>
    public interface IGitHubApiStatusService
    {
        /// <summary>
        /// Determines if GitHubApiClient.DefaultRequestHeaders.UserAgent is Valid
        /// </summary>
        bool IsProductHeaderValueValid { get; }

        /// <summary>
        /// Determines if GitHubApiClient.DefaultRequestHeaders.Authorization is Valid
        /// </summary>
        bool IsAuthenticationHeaderValueSet { get; }

        /// <summary>
        /// Add ProductHeaderValue to HttpClient.DefaultRequestHeaders.UserAgent
        /// </summary>
        /// <param name="productHeaderValue"></param>
        void AddProductHeaderValue(ProductHeaderValue productHeaderValue);

        /// <summary>
        /// Set HttpClient.DefaultRequestHeaders.Authorization
        /// </summary>
        /// <param name="authenticationHeaderValue"></param>
        void SetAuthenticationHeaderValue(AuthenticationHeaderValue authenticationHeaderValue);

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
        /// Determines Whether GitHub's Abuse Rate Limit Has Been Reached
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <param name="delta">Time Remaining in Retry-After Header</param>
        /// <returns></returns>
        bool IsAbuseRateLimit(in HttpResponseHeaders httpResponseHeaders, out TimeSpan? delta);

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
*/
namespace GitHubApiStatus
{
	/// <summary>
	/// Interface for GitHubApiStatusService
	/// </summary>
	public interface IGitHubApiStatusService
	{
		/// <summary>
		/// Determines if GitHubApiClient.DefaultRequestHeaders.UserAgent is Valid
		/// </summary>
		bool IsProductHeaderValueValid { get; }

		/// <summary>
		/// Determines if GitHubApiClient.DefaultRequestHeaders.Authorization is Valid
		/// </summary>
		bool IsAuthenticationHeaderValueSet { get; }

		/// <summary>
		/// Add ProductHeaderValue to HttpClient.DefaultRequestHeaders.UserAgent
		/// </summary>
		/// <param name="productHeaderValue"></param>
		void AddProductHeaderValue(ProductHeaderValue productHeaderValue);

		/// <summary>
		/// Set HttpClient.DefaultRequestHeaders.Authorization
		/// </summary>
		/// <param name="authenticationHeaderValue"></param>
		void SetAuthenticationHeaderValue(AuthenticationHeaderValue authenticationHeaderValue);

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
		/// Determines Whether GitHub's Abuse Rate Limit Has Been Reached
		/// </summary>
		/// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
		/// <param name="delta">Time Remaining in Retry-After Header</param>
		/// <returns></returns>
		bool IsAbuseRateLimit(in HttpResponseHeaders httpResponseHeaders, out TimeSpan? delta);

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