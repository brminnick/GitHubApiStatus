using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using GitStatus.Common;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GitHubApiStatus.UnitTests;

abstract class BaseTest
{
	const string _authorizationHeaderKey = "Authorization";

	static readonly HttpClient _client = CreateGitHubHttpClient(new AuthenticationHeaderValue(GitHubConstants.AuthScheme, GitHubConstants.PersonalAccessToken), new ProductHeaderValue(nameof(GitHubApiStatus)));

	protected IGitHubApiStatusService GitHubApiStatusService { get; } = new GitHubApiStatusService(_client);

	[SetUp]
	protected virtual Task BeforeEachTest() => Task.CompletedTask;

	[TearDown]
	protected virtual Task AfterEachTest()
	{
		GitHubApiStatusService.SetAuthenticationHeaderValue(new AuthenticationHeaderValue(GitHubConstants.AuthScheme, GitHubConstants.PersonalAccessToken));
		return Task.CompletedTask;
	}

	[OneTimeTearDown]
	protected virtual Task AfterAllTests()
	{
		_client.Dispose();
		GitHubApiStatusService.Dispose();
		return Task.CompletedTask;
	}

	protected static HttpResponseHeaders CreateHttpResponseHeaders(in int rateLimit, in DateTimeOffset rateLimitResetTime, in int remainingRequestCount, in HttpStatusCode httpStatusCode = HttpStatusCode.OK, in bool isAuthenticated = true, in bool isAbuseRateLimit = false)
	{
		if (remainingRequestCount > rateLimit)
			throw new ArgumentOutOfRangeException(nameof(remainingRequestCount), $"{nameof(remainingRequestCount)} must be less than or equal to {nameof(rateLimit)}");

		var httpResponse = new HttpResponseMessage(httpStatusCode)
		{
			Headers =
				{
					{ GitHubApiStatus.GitHubApiStatusService.RateLimitHeader, rateLimit.ToString() },
					{ GitHubApiStatus.GitHubApiStatusService.RateLimitResetHeader,  GetTimeInUnixEpochSeconds(rateLimitResetTime).ToString() },
					{ GitHubApiStatus.GitHubApiStatusService.RateLimitRemainingHeader, remainingRequestCount.ToString() }
				}
		};

		if (isAbuseRateLimit)
			httpResponse.Headers.RetryAfter = new RetryConditionHeaderValue(TimeSpan.FromMinutes(1));

		if (isAuthenticated)
			httpResponse.Headers.Vary.Add(_authorizationHeaderKey);

		return httpResponse.Headers;
	}

	protected static HttpClient CreateGitHubHttpClient(in AuthenticationHeaderValue authenticationHeaderValue, in ProductHeaderValue productHeaderValue)
	{
		var client = new HttpClient();
		client.DefaultRequestHeaders.Authorization = authenticationHeaderValue;
		client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(productHeaderValue));

		return client;
	}

	protected static Task<HttpResponseMessage> SendValidRestApiRequest() => _client.GetAsync($"{GitHubConstants.GitHubRestApiUrl}/repos/brminnick/GitHubApiStatus");

	protected static Task<HttpResponseMessage> SendValidSearchApiRequest() => _client.GetAsync($"{GitHubConstants.GitHubRestApiUrl}/search/code");

	protected static Task<HttpResponseMessage> SendValidCodeScanningApiRequest() => _client.GetAsync($"{GitHubConstants.GitHubRestApiUrl}/repos/brminnick/GitHubApiStatus/code-scanning/alerts");

	protected static Task SendValidGraphQLApiRequest()
	{
		var graphQLRequest = new GraphQLRequest("query { user(login: \"brminnick\"){ name, company, createdAt}}");
		var serializedGraphQLRequest = JsonConvert.SerializeObject(graphQLRequest);

		return _client.PostAsync(GitHubConstants.GitHubGraphQLApiUrl, new StringContent(serializedGraphQLRequest));
	}

	static long GetTimeInUnixEpochSeconds(in DateTimeOffset dateTimeOffset) => dateTimeOffset.ToUnixTimeSeconds();
}