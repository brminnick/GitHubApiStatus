using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

#if NETSTANDARD
using System.IO;
using Newtonsoft.Json;
#else
using System.Text.Json;
#endif

namespace GitHubApiStatus
{
    /// <summary>
    /// GitHub API Status Service
    /// </summary>
    public class GitHubApiStatusService : IGitHubApiStatusService
    {
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

#if NETSTANDARD
        readonly static Lazy<JsonSerializer> _serializerHolder = new(() => new JsonSerializer());
#endif

        /// <summary>
        /// Initializes GitHubApiStatusService
        /// </summary>
        public GitHubApiStatusService()
        {
            Client = new GitHubApiClient();
        }

        /// <summary>
        /// Initializes GitHubApiStatusService
        /// </summary>
        /// <param name="authenticationHeaderValue">GitHub Authentication Bearer Token</param>
        /// <param name="productHeaderValue">User-Agent Name</param>
        public GitHubApiStatusService(AuthenticationHeaderValue authenticationHeaderValue, ProductHeaderValue productHeaderValue)
        {
            Client = new GitHubApiClient(authenticationHeaderValue, productHeaderValue);
        }

        /// <summary>
        /// Initializes GitHubApiStatusService
        /// </summary>
        /// <param name="client">GitHub API requires the following Headers: Authorization and User-Agent</param>
        public GitHubApiStatusService(GitHubApiClient client)
        {
            if (client is null)
                throw new GitHubApiStatusException($"{nameof(client)} cannot be null");

            ValidateAuthenticationHeaderValue(client.DefaultRequestHeaders.Authorization);
            ValidateProductHeaderValue(client.DefaultRequestHeaders.UserAgent);

            Client = client;
        }

        GitHubApiClient Client { get; }

#if NETSTANDARD
        static JsonSerializer Serializer => _serializerHolder.Value;
#endif

        /// <summary>
        /// Adds ProductHeaderValue to 
        /// </summary>
        /// <param name="productHeaderValue"></param>
        public void AddProductHeaderValue(ProductHeaderValue productHeaderValue)
        {
            ValidateProductHeaderValue(productHeaderValue);

            Client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(productHeaderValue));
        }

        public void SetAuthenticationHeaderValue(AuthenticationHeaderValue authenticationHeaderValue)
        {
            ValidateAuthenticationHeaderValue(authenticationHeaderValue);

            Client.DefaultRequestHeaders.Authorization = authenticationHeaderValue;
        }

        /// <summary>
        /// Get the API Rate Limits for the GitHub REST API, GraphQL API, Search API, Code Scanning API and App Manifest Configuration API
        /// </summary>
        /// <returns>The API Status for each GitHub API</returns>
        public Task<GitHubApiRateLimits> GetApiRateLimits() => GetApiRateLimits(CancellationToken.None);

        /// <summary>
        /// Get the API Rate Limits for the GitHub REST API, GraphQL API, Search API, Code Scanning API and App Manifest Configuration API
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        public async Task<GitHubApiRateLimits> GetApiRateLimits(CancellationToken cancellationToken)
        {
            var response = await GetGitHubApiRateLimitResponse(Client, cancellationToken).ConfigureAwait(false);
            return response.Results;
        }

        /// <summary>
        /// Get GitHub API Rate Limit
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>GitHub Api Rate Limit </returns>
        public int GetRateLimit(in HttpResponseHeaders httpResponseHeaders)
        {
            ValidateHttpResponseHeaders(httpResponseHeaders);

            var rateLimitRemainingHeader = httpResponseHeaders?.Single(x => x.Key.Equals(RateLimitHeader, StringComparison.OrdinalIgnoreCase)) ?? throw new ArgumentNullException(nameof(httpResponseHeaders));
            var rateLimit = int.Parse(rateLimitRemainingHeader.Value.First());

            return rateLimit;
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
        /// Get Number of GitHub API Requests Remaining
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>Number of GitHub API Requests Remaining</returns>
        public int GetRemainingRequestCount(in HttpResponseHeaders httpResponseHeaders)
        {
            ValidateHttpResponseHeaders(httpResponseHeaders);

            var rateLimitRemainingHeader = httpResponseHeaders?.Single(x => x.Key.Equals(RateLimitRemainingHeader, StringComparison.OrdinalIgnoreCase)) ?? throw new ArgumentNullException(nameof(httpResponseHeaders));
            var remainingApiRequests = int.Parse(rateLimitRemainingHeader.Value.First());

            return remainingApiRequests;
        }

        /// <summary>
        /// Determines Whether the Http Response Was From an Authenticated Http Request
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>Whether the Http Response Was From an Authenticated Http Request</returns>
        public bool IsAuthenticated(in HttpResponseHeaders httpResponseHeaders)
        {
            ValidateHttpResponseHeaders(httpResponseHeaders);
            return httpResponseHeaders?.Vary.Any(x => x is "Authorization") ?? throw new ArgumentNullException(nameof(httpResponseHeaders));
        }

        /// <summary>
        /// Get Time Remaining Until GitHub API Rate Limit Resets
        /// </summary>
        /// <param name="httpResponseHeaders">HttpResponseHeaders from GitHub API Response</param>
        /// <returns>Time Remaining Until GitHub API Rate Limit Resets</returns>
        public TimeSpan GetRateLimitTimeRemaining(in HttpResponseHeaders httpResponseHeaders) => GetRateLimitResetDateTime(httpResponseHeaders).Subtract(DateTimeOffset.UtcNow);

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
            ValidateHttpResponseHeaders(httpResponseHeaders);

            var rateLimitResetHeader = httpResponseHeaders?.Single(x => x.Key.Equals(RateLimitResetHeader, StringComparison.OrdinalIgnoreCase)) ?? throw new ArgumentNullException(nameof(httpResponseHeaders));
            return long.Parse(rateLimitResetHeader.Value.First());
        }

        // Use Streams to optimize performance: https://www.newtonsoft.com/json/help/html/Performance.htm
        static async Task<GitHubApiRateLimitResponse> GetGitHubApiRateLimitResponse(GitHubApiClient client, CancellationToken cancellationToken)
        {
            ValidateProductHeaderValue(client.DefaultRequestHeaders.UserAgent);
            ValidateAuthenticationHeaderValue(client.DefaultRequestHeaders.Authorization);

            using var response = await client.GetAsync("https://api.github.com/rate_limit", cancellationToken).ConfigureAwait(false);

#if NET5_0
            using var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
#else
            using var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
#endif


#if NETSTANDARD
            using var streamReader = new StreamReader(stream);
            using var jsonTextReader = new JsonTextReader(streamReader);

            return Serializer.Deserialize<GitHubApiRateLimitResponse>(jsonTextReader) ?? throw new NullReferenceException();
#else
            var gitHubApiRateLimitResponse_Mutable = await JsonSerializer.DeserializeAsync<GitHubApiRateLimitResponseMutable>(stream, cancellationToken: cancellationToken).ConfigureAwait(false) ?? throw new JsonException();

            return gitHubApiRateLimitResponse_Mutable?.ToGitHubApiRateLimitResponse() ?? throw new NullReferenceException();
#endif
        }

        internal static void ValidateHttpResponseHeaders(in HttpResponseHeaders? httpResponseHeaders)
        {
            if (httpResponseHeaders is null)
                throw new GitHubApiStatusException($"{nameof(HttpResponseHeaders)} cannot be null or whitespace");
        }

        internal static void ValidateProductHeaderValue(in HttpHeaderValueCollection<ProductInfoHeaderValue>? productInfoHeaderValues)
        {
            if (productInfoHeaderValues is null)
                throw new GitHubApiStatusException($"{nameof(ProductHeaderValue)} cannot be null or whitespace");

            if (!productInfoHeaderValues.Any(x => !string.IsNullOrWhiteSpace(x?.Product?.Name)))
                throw new GitHubApiStatusException($"{nameof(ProductHeaderValue)}.{nameof(ProductHeaderValue.Name)} cannot be null or whitespace");
        }

        internal static void ValidateProductHeaderValue(in ProductHeaderValue? productHeaderValue)
        {
            if (productHeaderValue is null)
                throw new GitHubApiStatusException($"{nameof(ProductHeaderValue)} cannot be null");

            ValidateProductHeaderValue(new ProductInfoHeaderValue(productHeaderValue));
        }

        internal static void ValidateProductHeaderValue(in ProductInfoHeaderValue? productInfoHeaderValue)
        {
            if (string.IsNullOrWhiteSpace(productInfoHeaderValue?.Product?.Name))
                throw new GitHubApiStatusException($"{nameof(ProductHeaderValue)}.{nameof(ProductHeaderValue.Name)} cannot be null or whitespace");
        }

        internal static void ValidateAuthenticationHeaderValue(in AuthenticationHeaderValue? authenticationHeaderValue)
        {
            if (authenticationHeaderValue is null)
                throw new GitHubApiStatusException($"{nameof(AuthenticationHeaderValue)} cannot be null");

            if (!authenticationHeaderValue.Scheme.Equals("bearer", StringComparison.OrdinalIgnoreCase))
                throw new GitHubApiStatusException($"{nameof(AuthenticationHeaderValue)}.{nameof(AuthenticationHeaderValue.Scheme)} must be `bearer`");

            if (string.IsNullOrWhiteSpace(authenticationHeaderValue.Parameter))
                throw new GitHubApiStatusException($"{nameof(AuthenticationHeaderValue)}.{nameof(AuthenticationHeaderValue.Parameter)} cannot be blank");
        }
    }
}
