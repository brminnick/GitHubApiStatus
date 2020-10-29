using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GitStatus.Shared;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

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

        static readonly GraphQLHttpClient _graphQLClient = CreateGitHubGraphQLClient();

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

        protected static Task<HttpResponseMessage> SendValidSearchApiRequest() => _client.GetAsync($"{GitHubConstants.GitHubRestApiUrl}/search/code");

        protected static Task<HttpResponseMessage> SendValidCodeScanningApiRequest() => _client.GetAsync($"{GitHubConstants.GitHubRestApiUrl}/repos/brminnick/GitHubApiStatus/code-scanning/alerts");

        protected static Task SendValidGraphQLApiRequest()
        {
            var graphQLRequest = new GraphQLRequest
            {
                Query = "query { user(login: \"brminnick\"){ name, company, createdAt}}"
            };

            return _graphQLClient.SendQueryAsync<GitHubUserGraphQLResponse>(graphQLRequest);
        }

        static GraphQLHttpClient CreateGitHubGraphQLClient()
        {
            var graphQLOptions = new GraphQLHttpClientOptions
            {
                EndPoint = new Uri(GitHubConstants.GitHubGraphQLApiUrl),
            };

            var client = new GraphQLHttpClient(graphQLOptions, new NewtonsoftJsonSerializer());
            client.HttpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(new ProductHeaderValue(nameof(GitHubApiStatus))));
            client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", GitHubConstants.PersonalAccessToken);

            return client;
        }

        static long GetTimeInUnixEpochSeconds(in DateTimeOffset dateTimeOffset) => dateTimeOffset.ToUnixTimeSeconds();

        class GitHubUserGraphQLResponse
        {
            public GitHubUserGraphQLResponse(GitHubUser user) => User = user;

            public GitHubUser User { get; }
        }

        class GitHubUser
        {
            public GitHubUser(string name, string company, DateTimeOffset createdAt) =>
                (Name, Company, CreatedAt) = (name, company, createdAt);

            public string Name { get; }

            public string Company { get; }

            public DateTimeOffset CreatedAt { get; }
        }
    }
}