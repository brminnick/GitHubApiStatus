using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GitStatus.Shared;

namespace GitHubApiStatus.UnitTests
{
    abstract class BaseTest
    {
        const string _authorizationHeaderKey = "Authorization";

        static readonly HttpClient _client = new HttpClient
        {
            DefaultRequestHeaders =
            {
                { "User-Agent", nameof(GitHubApiStatus) },
                { _authorizationHeaderKey, "bearer " + GitHubConstants.PersonalAccessToken }
            }
        };

        protected GitHubApiStatusService GitHubApiStatus { get; } = GitHubApiStatusService.Instance;

        protected static HttpResponseHeaders CreateHttpResponseHeaders(in int rateLimit, in DateTimeOffset rateLimitResetTime, in int remainingRequestCount, in HttpStatusCode httpStatusCode = HttpStatusCode.OK, in bool isAuthenticated = true)
        {
            if (remainingRequestCount > rateLimit)
                throw new ArgumentOutOfRangeException(nameof(remainingRequestCount), $"{nameof(remainingRequestCount)} must be less than or equal to {nameof(rateLimit)}");

            var httpResponse = new HttpResponseMessage(httpStatusCode)
            {
                Headers =
                {
                    { GitHubApiStatusService.RateLimitHeader, rateLimit.ToString() },
                    { GitHubApiStatusService.RateLimitResetHeader,  GetTimeInUnixEpochSeconds(rateLimitResetTime).ToString() },
                    { GitHubApiStatusService.RateLimitRemainingHeader, remainingRequestCount.ToString() }
                }
            };

            if (isAuthenticated)
                httpResponse.Headers.Vary.Add(_authorizationHeaderKey);

            return httpResponse.Headers;
        }

        protected static Task<HttpResponseMessage> SendValidRestApiRequest() => _client.GetAsync($"{GitHubConstants.GitHubRestApiUrl}/repos/brminnick/GitHubApiStatus");
        protected static Task<HttpResponseMessage> SendValidGraphQLApiRequest() => _client.PostAsync($"{GitHubConstants.GitHubGraphQLApiUrl}", new StringContent("\"query\" : \"query { repository(owner: \"brminnick\" name: \"GitHubApiStatus\"){ name, description, url }}\""));

        static long GetTimeInUnixEpochSeconds(in DateTimeOffset dateTimeOffset) => dateTimeOffset.ToUnixTimeSeconds();
    }
}