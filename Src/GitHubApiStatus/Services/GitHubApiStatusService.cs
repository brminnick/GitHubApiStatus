using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

#if NETSTANDARD
using Newtonsoft.Json;
#else
using System.Text.Json;
#endif

namespace GitHubApiStatus
{
    /// <summary>
    /// GitHub API Status Service
    /// </summary>
    public class GitHubApiStatusService
    {
        readonly static Lazy<SemaphoreSlim> _semaphoreSlimHolder = new Lazy<SemaphoreSlim>(() => new SemaphoreSlim(1, 1));
        readonly static Lazy<GitHubApiStatusService> _instanceHolder = new Lazy<GitHubApiStatusService>(() => new GitHubApiStatusService());

#if NETSTANDARD
        readonly static Lazy<JsonSerializer> _serializerHolder = new Lazy<JsonSerializer>(() => new JsonSerializer());
#endif

        readonly static Lazy<HttpClient> _clientHolder = new Lazy<HttpClient>(() => new HttpClient
        {
            DefaultRequestHeaders =
            {
                { "User-Agent", nameof(GitHubApiStatus) },
            }
        });

        /// <summary>
        /// GitHub Http Response Rate Limit Header Key
        /// </summary>
        public const string RateLimitHeader = "X-RateLimit-Limit";

        /// <summary>
        /// GitHub Http Response Rate Limit Reset Header Key
        /// </summary>
        public const string RateLimitResetHeader = "X-RateLimit-Reset";

        /// <summary>
        /// GitHub Http Response Rate Limit Remaining Reset Header Key
        /// </summary>
        public const string RateLimitRemainingHeader = "X-RateLimit-Remaining";


        /// <summary>
        /// Static Instance of GitHubApiStatusService 
        /// </summary>
        public static GitHubApiStatusService Instance => _instanceHolder.Value;

        static HttpClient Client => _clientHolder.Value;

#if NETSTANDARD
        static JsonSerializer Serializer => _serializerHolder.Value;
#endif
        static SemaphoreSlim SemaphoreSlim => _semaphoreSlimHolder.Value;

        /// <summary>
        /// Get the API Rate Limits for the GitHub REST API, GraphQL API, Search API, Code Scanning API and App Manifest Configuration API
        /// </summary>
        /// <param name="authenticationHeaderValue">Authentication Header, e.g. `new AuthenticationHeaderValue(bearer, 91820398037201212)`</param>
        /// <returns>The API Status for each GitHub API</returns>
        public Task<GitHubApiRateLimits> GetApiRateLimits(AuthenticationHeaderValue authenticationHeaderValue) => GetApiRateLimits(authenticationHeaderValue, CancellationToken.None);

        /// <summary>
        /// Get the API Rate Limits for the GitHub REST API, GraphQL API, Search API, Code Scanning API and App Manifest Configuration API
        /// </summary>
        /// <param name="authenticationHeaderValue">Authentication Header, e.g. `new AuthenticationHeaderValue(bearer, 91820398037201212)`</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        public async Task<GitHubApiRateLimits> GetApiRateLimits(AuthenticationHeaderValue authenticationHeaderValue, CancellationToken cancellationToken)
        {
            if (authenticationHeaderValue is null)
                throw new ArgumentNullException(nameof(authenticationHeaderValue));

            if (!authenticationHeaderValue.Scheme.Equals("bearer", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException($"{nameof(AuthenticationHeaderValue)}.{nameof(AuthenticationHeaderValue.Scheme)} must be `bearer`");

            if (string.IsNullOrWhiteSpace(authenticationHeaderValue.Parameter))
                throw new ArgumentException($"{nameof(AuthenticationHeaderValue)}.{nameof(AuthenticationHeaderValue.Parameter)} cannot be null or empty");

            try
            {
                await SemaphoreSlim.WaitAsync().ConfigureAwait(false);

                Client.DefaultRequestHeaders.Authorization = authenticationHeaderValue;

                var response = await GetGitHubApiRateLimitResponse(cancellationToken);

                Client.DefaultRequestHeaders.Authorization = null;

                return response.Results;
            }
            finally
            {
                SemaphoreSlim.Release();
            }
        }

        /// <summary>
        /// Get GitHub API Rate Limit
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>GitHub Api Rate Limit </returns>
        public int GetRateLimit(in HttpResponseHeaders httpResponseHeaders)
        {
            var rateLimitRemainingHeader = httpResponseHeaders?.Single(x => x.Key.Equals(RateLimitHeader, StringComparison.OrdinalIgnoreCase)) ?? throw new ArgumentNullException(nameof(httpResponseHeaders));
            var rateLimit = int.Parse(rateLimitRemainingHeader.Value.First());

            return rateLimit;
        }

        /// <summary>
        /// Get Number of GitHub API Requests Remaining
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>Number of GitHub API Requests Remaining</returns>
        public int GetRemainingRequestCount(in HttpResponseHeaders httpResponseHeaders)
        {
            var rateLimitRemainingHeader = httpResponseHeaders?.Single(x => x.Key.Equals(RateLimitRemainingHeader, StringComparison.OrdinalIgnoreCase)) ?? throw new ArgumentNullException(nameof(httpResponseHeaders));
            var remainingApiRequests = int.Parse(rateLimitRemainingHeader.Value.First());

            return remainingApiRequests;
        }

        /// <summary>
        /// Determines Whether GitHub's Maximum API Limit Has Been Reached
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>Whether GitHub's Maximum API Limit Has Been Reached</returns>
        public bool HasReachedMaximimApiCallLimit(in HttpResponseHeaders httpResponseHeaders)
        {
            var remainingApiRequests = GetRemainingRequestCount(httpResponseHeaders);
            return remainingApiRequests <= 0;
        }

        /// <summary>
        /// Get Time Remaining Until GitHub API Rate Limit Resets
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>Time Remaining Until GitHub API Rate Limit Resets</returns>
        public TimeSpan GetRateLimitTimeRemaining(in HttpResponseHeaders httpResponseHeaders) => GetRateLimitResetDateTime(httpResponseHeaders).Subtract(DateTimeOffset.UtcNow);

        /// <summary>
        /// Determines Whether the Http Response Was From an Authenticated Http Request
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>Whether the Http Response Was From an Authenticated Http Request</returns>
        public bool IsAuthenticated(in HttpResponseHeaders httpResponseHeaders) => httpResponseHeaders?.Vary.Any(x => x is "Authorization") ?? throw new ArgumentNullException(nameof(httpResponseHeaders));

        /// <summary>
        /// Get the DateTimeOffset When the GitHub API Rate Limit Will Reset
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>DateTimeOffset When the GitHub API Rate Limit Will Reset</returns>
        public DateTimeOffset GetRateLimitResetDateTime(in HttpResponseHeaders httpResponseHeaders) =>
            DateTimeOffset.FromUnixTimeSeconds(GetRateLimitResetDateTime_UnixEpochSeconds(httpResponseHeaders));

        /// <summary>
        /// Get the Unix Epoch Seconds When the GitHub API Rate Limit Will Reset
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>Unix Epoch Seconds When the GitHub API Rate Limit Will Reset</returns>
        public long GetRateLimitResetDateTime_UnixEpochSeconds(in HttpResponseHeaders httpResponseHeaders)
        {
            var rateLimitResetHeader = httpResponseHeaders?.Single(x => x.Key.Equals(RateLimitResetHeader, StringComparison.OrdinalIgnoreCase)) ?? throw new ArgumentNullException(nameof(httpResponseHeaders));
            return long.Parse(rateLimitResetHeader.Value.First());
        }

        // Use Streams to optimize performance: https://www.newtonsoft.com/json/help/html/Performance.htm
        static async Task<GitHubApiRateLimitResponse> GetGitHubApiRateLimitResponse(CancellationToken cancellationToken)
        {
            using var response = await Client.GetAsync("https://api.github.com/rate_limit", cancellationToken).ConfigureAwait(false);
            using var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

#if NETSTANDARD
            using var streamReader = new StreamReader(stream);
            using var jsonTextReader = new JsonTextReader(streamReader);

            return Serializer.Deserialize<GitHubApiRateLimitResponse>(jsonTextReader) ?? throw new NullReferenceException();
#else
            var gitHubApiRateLimitResponse_Mutable = await JsonSerializer.DeserializeAsync<GitHubApiRateLimitResponseMutable>(stream).ConfigureAwait(false) ?? throw new JsonException();

            return gitHubApiRateLimitResponse_Mutable?.ToGitHubApiRateLimitResponse() ?? throw new NullReferenceException();
#endif
        }
    }
}
