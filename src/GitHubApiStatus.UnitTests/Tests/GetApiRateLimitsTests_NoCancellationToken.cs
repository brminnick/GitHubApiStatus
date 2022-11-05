using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using GitStatus.Shared;
using NUnit.Framework;


/* Unmerged change from project 'GitHubApiStatus.UnitTests(netcoreapp2.1)'
Before:
namespace GitHubApiStatus.UnitTests
{
    class GetApiRateLimitsTests_NoCancellationToken : BaseTest
    {
        [Test]
        public async Task GetApiRateLimits_ValidRestApiRequest()
        {
            //Arrange
            RateLimitStatus restApiStatus_Initial, restApiStatus_Final;
            GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

            var startTime = DateTimeOffset.UtcNow;
            var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;

            //Act
            gitHubApiRateLimits_Initial = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            restApiStatus_Initial = gitHubApiRateLimits_Initial.RestApi;

            await SendValidRestApiRequest().ConfigureAwait(false);

            gitHubApiRateLimits_Final = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            restApiStatus_Final = gitHubApiRateLimits_Final.RestApi;

            //Assert
            Assert.IsNotNull(restApiStatus_Initial);
            Assert.AreEqual(5000, restApiStatus_Initial.RateLimit);
            Assert.GreaterOrEqual(restApiStatus_Initial.RemainingRequestCount, 0);
            Assert.LessOrEqual(restApiStatus_Initial.RemainingRequestCount, restApiStatus_Initial.RateLimit);
            Assert.AreEqual(restApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), restApiStatus_Initial.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(restApiStatus_Initial.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(restApiStatus_Initial.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.IsNotNull(restApiStatus_Final);
            Assert.AreEqual(5000, restApiStatus_Final.RateLimit);
            Assert.GreaterOrEqual(restApiStatus_Final.RemainingRequestCount, 0);
            Assert.LessOrEqual(restApiStatus_Final.RemainingRequestCount, restApiStatus_Final.RateLimit);
            Assert.AreEqual(restApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), restApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(restApiStatus_Final.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(restApiStatus_Final.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.AreEqual(restApiStatus_Initial.RateLimit, restApiStatus_Final.RateLimit);
            Assert.IsTrue(restApiStatus_Initial.RateLimitReset_DateTime == restApiStatus_Final.RateLimitReset_DateTime || restApiStatus_Initial.RateLimitReset_DateTime == restApiStatus_Final.RateLimitReset_DateTime.Subtract(TimeSpan.FromSeconds(1)));
            Assert.GreaterOrEqual(restApiStatus_Initial.RateLimitReset_TimeRemaining.TotalMilliseconds, restApiStatus_Final.RateLimitReset_TimeRemaining.TotalMilliseconds);
            Assert.AreEqual(restApiStatus_Initial.RateLimitReset_UnixEpochSeconds, restApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.Greater(restApiStatus_Initial.RemainingRequestCount, restApiStatus_Final.RemainingRequestCount);

        }

        [Test]
        public async Task GetApiRateLimits_ValidGraphQLApiRequest()
        {
            //Arrange
            RateLimitStatus graphQLApiStatus_Initial, graphQLApiStatus_Final;
            GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

            var startTime = DateTimeOffset.UtcNow;
            var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;

            //Act
            gitHubApiRateLimits_Initial = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            graphQLApiStatus_Initial = gitHubApiRateLimits_Initial.GraphQLApi;

            await SendValidGraphQLApiRequest().ConfigureAwait(false);

            gitHubApiRateLimits_Final = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            graphQLApiStatus_Final = gitHubApiRateLimits_Final.GraphQLApi;

            //Assert
            Assert.IsNotNull(graphQLApiStatus_Initial);
            Assert.AreEqual(5000, graphQLApiStatus_Initial.RateLimit);
            Assert.GreaterOrEqual(graphQLApiStatus_Initial.RemainingRequestCount, 0);
            Assert.LessOrEqual(graphQLApiStatus_Initial.RemainingRequestCount, graphQLApiStatus_Initial.RateLimit);
            Assert.AreEqual(graphQLApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(graphQLApiStatus_Initial.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.IsNotNull(graphQLApiStatus_Final);
            Assert.AreEqual(5000, graphQLApiStatus_Final.RateLimit);
            Assert.GreaterOrEqual(graphQLApiStatus_Final.RemainingRequestCount, 0);
            Assert.LessOrEqual(graphQLApiStatus_Final.RemainingRequestCount, graphQLApiStatus_Final.RateLimit);
            Assert.AreEqual(graphQLApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(graphQLApiStatus_Final.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.AreEqual(graphQLApiStatus_Initial.RateLimit, graphQLApiStatus_Final.RateLimit);
            Assert.IsTrue(graphQLApiStatus_Initial.RateLimitReset_DateTime == graphQLApiStatus_Final.RateLimitReset_DateTime || graphQLApiStatus_Initial.RateLimitReset_DateTime == graphQLApiStatus_Final.RateLimitReset_DateTime.Subtract(TimeSpan.FromSeconds(1)));
            Assert.GreaterOrEqual(graphQLApiStatus_Initial.RateLimitReset_TimeRemaining.TotalMilliseconds, graphQLApiStatus_Final.RateLimitReset_TimeRemaining.TotalMilliseconds);
            Assert.AreEqual(graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds, graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.Greater(graphQLApiStatus_Initial.RemainingRequestCount, graphQLApiStatus_Final.RemainingRequestCount);
        }

        [Test]
        public async Task GetApiRateLimits_ValidSearchApiRequest()
        {
            //Arrange
            RateLimitStatus searchApiStatus_Initial, searchApiStatus_Final;
            GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

            var startTime = DateTimeOffset.UtcNow;
            var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;

            //Act
            gitHubApiRateLimits_Initial = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            searchApiStatus_Initial = gitHubApiRateLimits_Initial.SearchApi;

            await SendValidSearchApiRequest().ConfigureAwait(false);

            gitHubApiRateLimits_Final = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            searchApiStatus_Final = gitHubApiRateLimits_Final.SearchApi;

            //Assert
            Assert.IsNotNull(searchApiStatus_Initial);
            Assert.AreEqual(30, searchApiStatus_Initial.RateLimit);
            Assert.GreaterOrEqual(searchApiStatus_Initial.RemainingRequestCount, 0);
            Assert.LessOrEqual(searchApiStatus_Initial.RemainingRequestCount, searchApiStatus_Initial.RateLimit);
            Assert.AreEqual(searchApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(searchApiStatus_Initial.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.IsNotNull(searchApiStatus_Final);
            Assert.AreEqual(30, searchApiStatus_Final.RateLimit);
            Assert.GreaterOrEqual(searchApiStatus_Final.RemainingRequestCount, 0);
            Assert.LessOrEqual(searchApiStatus_Final.RemainingRequestCount, searchApiStatus_Final.RateLimit);
            Assert.AreEqual(searchApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), searchApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(searchApiStatus_Final.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(searchApiStatus_Final.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.AreEqual(searchApiStatus_Initial.RateLimit, searchApiStatus_Final.RateLimit);
            Assert.IsTrue(searchApiStatus_Initial.RateLimitReset_DateTime == searchApiStatus_Final.RateLimitReset_DateTime || searchApiStatus_Initial.RateLimitReset_DateTime == searchApiStatus_Final.RateLimitReset_DateTime.Subtract(TimeSpan.FromSeconds(1)));
            Assert.GreaterOrEqual(searchApiStatus_Initial.RateLimitReset_TimeRemaining.TotalMilliseconds, searchApiStatus_Final.RateLimitReset_TimeRemaining.TotalMilliseconds);
            Assert.AreEqual(searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds, searchApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.Greater(searchApiStatus_Initial.RemainingRequestCount, searchApiStatus_Final.RemainingRequestCount);
        }

        [Test]
        public void GetApiRateLimits_InvalidBearerToken()
        {
            //Arrange
            var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;
            gitHubApiStatusService.SetAuthenticationHeaderValue(new AuthenticationHeaderValue(GitHubConstants.AuthScheme, "abc 123"));

            //Act

            //Assert
            var httpRequestException = Assert.ThrowsAsync<HttpRequestException>(() => gitHubApiStatusService.GetApiRateLimits());
#if NET5_0
            Assert.AreEqual(HttpStatusCode.Unauthorized, httpRequestException?.StatusCode);
#else
            Assert.IsTrue(httpRequestException?.Message.Contains("Unauthorized"));
#endif
        }
    }
}
After:
namespace GitHubApiStatus.UnitTests;

    class GetApiRateLimitsTests_NoCancellationToken : BaseTest
    {
        [Test]
        public async Task GetApiRateLimits_ValidRestApiRequest()
        {
            //Arrange
            RateLimitStatus restApiStatus_Initial, restApiStatus_Final;
            GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

            var startTime = DateTimeOffset.UtcNow;
            var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;

            //Act
            gitHubApiRateLimits_Initial = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            restApiStatus_Initial = gitHubApiRateLimits_Initial.RestApi;

            await SendValidRestApiRequest().ConfigureAwait(false);

            gitHubApiRateLimits_Final = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            restApiStatus_Final = gitHubApiRateLimits_Final.RestApi;

            //Assert
            Assert.IsNotNull(restApiStatus_Initial);
            Assert.AreEqual(5000, restApiStatus_Initial.RateLimit);
            Assert.GreaterOrEqual(restApiStatus_Initial.RemainingRequestCount, 0);
            Assert.LessOrEqual(restApiStatus_Initial.RemainingRequestCount, restApiStatus_Initial.RateLimit);
            Assert.AreEqual(restApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), restApiStatus_Initial.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(restApiStatus_Initial.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(restApiStatus_Initial.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.IsNotNull(restApiStatus_Final);
            Assert.AreEqual(5000, restApiStatus_Final.RateLimit);
            Assert.GreaterOrEqual(restApiStatus_Final.RemainingRequestCount, 0);
            Assert.LessOrEqual(restApiStatus_Final.RemainingRequestCount, restApiStatus_Final.RateLimit);
            Assert.AreEqual(restApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), restApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(restApiStatus_Final.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(restApiStatus_Final.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.AreEqual(restApiStatus_Initial.RateLimit, restApiStatus_Final.RateLimit);
            Assert.IsTrue(restApiStatus_Initial.RateLimitReset_DateTime == restApiStatus_Final.RateLimitReset_DateTime || restApiStatus_Initial.RateLimitReset_DateTime == restApiStatus_Final.RateLimitReset_DateTime.Subtract(TimeSpan.FromSeconds(1)));
            Assert.GreaterOrEqual(restApiStatus_Initial.RateLimitReset_TimeRemaining.TotalMilliseconds, restApiStatus_Final.RateLimitReset_TimeRemaining.TotalMilliseconds);
            Assert.AreEqual(restApiStatus_Initial.RateLimitReset_UnixEpochSeconds, restApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.Greater(restApiStatus_Initial.RemainingRequestCount, restApiStatus_Final.RemainingRequestCount);

        }

        [Test]
        public async Task GetApiRateLimits_ValidGraphQLApiRequest()
        {
            //Arrange
            RateLimitStatus graphQLApiStatus_Initial, graphQLApiStatus_Final;
            GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

            var startTime = DateTimeOffset.UtcNow;
            var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;

            //Act
            gitHubApiRateLimits_Initial = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            graphQLApiStatus_Initial = gitHubApiRateLimits_Initial.GraphQLApi;

            await SendValidGraphQLApiRequest().ConfigureAwait(false);

            gitHubApiRateLimits_Final = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            graphQLApiStatus_Final = gitHubApiRateLimits_Final.GraphQLApi;

            //Assert
            Assert.IsNotNull(graphQLApiStatus_Initial);
            Assert.AreEqual(5000, graphQLApiStatus_Initial.RateLimit);
            Assert.GreaterOrEqual(graphQLApiStatus_Initial.RemainingRequestCount, 0);
            Assert.LessOrEqual(graphQLApiStatus_Initial.RemainingRequestCount, graphQLApiStatus_Initial.RateLimit);
            Assert.AreEqual(graphQLApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(graphQLApiStatus_Initial.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.IsNotNull(graphQLApiStatus_Final);
            Assert.AreEqual(5000, graphQLApiStatus_Final.RateLimit);
            Assert.GreaterOrEqual(graphQLApiStatus_Final.RemainingRequestCount, 0);
            Assert.LessOrEqual(graphQLApiStatus_Final.RemainingRequestCount, graphQLApiStatus_Final.RateLimit);
            Assert.AreEqual(graphQLApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(graphQLApiStatus_Final.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.AreEqual(graphQLApiStatus_Initial.RateLimit, graphQLApiStatus_Final.RateLimit);
            Assert.IsTrue(graphQLApiStatus_Initial.RateLimitReset_DateTime == graphQLApiStatus_Final.RateLimitReset_DateTime || graphQLApiStatus_Initial.RateLimitReset_DateTime == graphQLApiStatus_Final.RateLimitReset_DateTime.Subtract(TimeSpan.FromSeconds(1)));
            Assert.GreaterOrEqual(graphQLApiStatus_Initial.RateLimitReset_TimeRemaining.TotalMilliseconds, graphQLApiStatus_Final.RateLimitReset_TimeRemaining.TotalMilliseconds);
            Assert.AreEqual(graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds, graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.Greater(graphQLApiStatus_Initial.RemainingRequestCount, graphQLApiStatus_Final.RemainingRequestCount);
        }

        [Test]
        public async Task GetApiRateLimits_ValidSearchApiRequest()
        {
            //Arrange
            RateLimitStatus searchApiStatus_Initial, searchApiStatus_Final;
            GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

            var startTime = DateTimeOffset.UtcNow;
            var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;

            //Act
            gitHubApiRateLimits_Initial = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            searchApiStatus_Initial = gitHubApiRateLimits_Initial.SearchApi;

            await SendValidSearchApiRequest().ConfigureAwait(false);

            gitHubApiRateLimits_Final = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            searchApiStatus_Final = gitHubApiRateLimits_Final.SearchApi;

            //Assert
            Assert.IsNotNull(searchApiStatus_Initial);
            Assert.AreEqual(30, searchApiStatus_Initial.RateLimit);
            Assert.GreaterOrEqual(searchApiStatus_Initial.RemainingRequestCount, 0);
            Assert.LessOrEqual(searchApiStatus_Initial.RemainingRequestCount, searchApiStatus_Initial.RateLimit);
            Assert.AreEqual(searchApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(searchApiStatus_Initial.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.IsNotNull(searchApiStatus_Final);
            Assert.AreEqual(30, searchApiStatus_Final.RateLimit);
            Assert.GreaterOrEqual(searchApiStatus_Final.RemainingRequestCount, 0);
            Assert.LessOrEqual(searchApiStatus_Final.RemainingRequestCount, searchApiStatus_Final.RateLimit);
            Assert.AreEqual(searchApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), searchApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(searchApiStatus_Final.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(searchApiStatus_Final.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.AreEqual(searchApiStatus_Initial.RateLimit, searchApiStatus_Final.RateLimit);
            Assert.IsTrue(searchApiStatus_Initial.RateLimitReset_DateTime == searchApiStatus_Final.RateLimitReset_DateTime || searchApiStatus_Initial.RateLimitReset_DateTime == searchApiStatus_Final.RateLimitReset_DateTime.Subtract(TimeSpan.FromSeconds(1)));
            Assert.GreaterOrEqual(searchApiStatus_Initial.RateLimitReset_TimeRemaining.TotalMilliseconds, searchApiStatus_Final.RateLimitReset_TimeRemaining.TotalMilliseconds);
            Assert.AreEqual(searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds, searchApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.Greater(searchApiStatus_Initial.RemainingRequestCount, searchApiStatus_Final.RemainingRequestCount);
        }

        [Test]
        public void GetApiRateLimits_InvalidBearerToken()
        {
            //Arrange
            var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;
            gitHubApiStatusService.SetAuthenticationHeaderValue(new AuthenticationHeaderValue(GitHubConstants.AuthScheme, "abc 123"));

            //Act

            //Assert
            var httpRequestException = Assert.ThrowsAsync<HttpRequestException>(() => gitHubApiStatusService.GetApiRateLimits());
#if NET5_0
            Assert.AreEqual(HttpStatusCode.Unauthorized, httpRequestException?.StatusCode);
#else
            Assert.IsTrue(httpRequestException?.Message.Contains("Unauthorized"));
#endif
        }
    }
*/

/* Unmerged change from project 'GitHubApiStatus.UnitTests(netcoreapp3.1)'
Before:
namespace GitHubApiStatus.UnitTests
{
    class GetApiRateLimitsTests_NoCancellationToken : BaseTest
    {
        [Test]
        public async Task GetApiRateLimits_ValidRestApiRequest()
        {
            //Arrange
            RateLimitStatus restApiStatus_Initial, restApiStatus_Final;
            GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

            var startTime = DateTimeOffset.UtcNow;
            var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;

            //Act
            gitHubApiRateLimits_Initial = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            restApiStatus_Initial = gitHubApiRateLimits_Initial.RestApi;

            await SendValidRestApiRequest().ConfigureAwait(false);

            gitHubApiRateLimits_Final = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            restApiStatus_Final = gitHubApiRateLimits_Final.RestApi;

            //Assert
            Assert.IsNotNull(restApiStatus_Initial);
            Assert.AreEqual(5000, restApiStatus_Initial.RateLimit);
            Assert.GreaterOrEqual(restApiStatus_Initial.RemainingRequestCount, 0);
            Assert.LessOrEqual(restApiStatus_Initial.RemainingRequestCount, restApiStatus_Initial.RateLimit);
            Assert.AreEqual(restApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), restApiStatus_Initial.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(restApiStatus_Initial.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(restApiStatus_Initial.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.IsNotNull(restApiStatus_Final);
            Assert.AreEqual(5000, restApiStatus_Final.RateLimit);
            Assert.GreaterOrEqual(restApiStatus_Final.RemainingRequestCount, 0);
            Assert.LessOrEqual(restApiStatus_Final.RemainingRequestCount, restApiStatus_Final.RateLimit);
            Assert.AreEqual(restApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), restApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(restApiStatus_Final.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(restApiStatus_Final.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.AreEqual(restApiStatus_Initial.RateLimit, restApiStatus_Final.RateLimit);
            Assert.IsTrue(restApiStatus_Initial.RateLimitReset_DateTime == restApiStatus_Final.RateLimitReset_DateTime || restApiStatus_Initial.RateLimitReset_DateTime == restApiStatus_Final.RateLimitReset_DateTime.Subtract(TimeSpan.FromSeconds(1)));
            Assert.GreaterOrEqual(restApiStatus_Initial.RateLimitReset_TimeRemaining.TotalMilliseconds, restApiStatus_Final.RateLimitReset_TimeRemaining.TotalMilliseconds);
            Assert.AreEqual(restApiStatus_Initial.RateLimitReset_UnixEpochSeconds, restApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.Greater(restApiStatus_Initial.RemainingRequestCount, restApiStatus_Final.RemainingRequestCount);

        }

        [Test]
        public async Task GetApiRateLimits_ValidGraphQLApiRequest()
        {
            //Arrange
            RateLimitStatus graphQLApiStatus_Initial, graphQLApiStatus_Final;
            GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

            var startTime = DateTimeOffset.UtcNow;
            var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;

            //Act
            gitHubApiRateLimits_Initial = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            graphQLApiStatus_Initial = gitHubApiRateLimits_Initial.GraphQLApi;

            await SendValidGraphQLApiRequest().ConfigureAwait(false);

            gitHubApiRateLimits_Final = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            graphQLApiStatus_Final = gitHubApiRateLimits_Final.GraphQLApi;

            //Assert
            Assert.IsNotNull(graphQLApiStatus_Initial);
            Assert.AreEqual(5000, graphQLApiStatus_Initial.RateLimit);
            Assert.GreaterOrEqual(graphQLApiStatus_Initial.RemainingRequestCount, 0);
            Assert.LessOrEqual(graphQLApiStatus_Initial.RemainingRequestCount, graphQLApiStatus_Initial.RateLimit);
            Assert.AreEqual(graphQLApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(graphQLApiStatus_Initial.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.IsNotNull(graphQLApiStatus_Final);
            Assert.AreEqual(5000, graphQLApiStatus_Final.RateLimit);
            Assert.GreaterOrEqual(graphQLApiStatus_Final.RemainingRequestCount, 0);
            Assert.LessOrEqual(graphQLApiStatus_Final.RemainingRequestCount, graphQLApiStatus_Final.RateLimit);
            Assert.AreEqual(graphQLApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(graphQLApiStatus_Final.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.AreEqual(graphQLApiStatus_Initial.RateLimit, graphQLApiStatus_Final.RateLimit);
            Assert.IsTrue(graphQLApiStatus_Initial.RateLimitReset_DateTime == graphQLApiStatus_Final.RateLimitReset_DateTime || graphQLApiStatus_Initial.RateLimitReset_DateTime == graphQLApiStatus_Final.RateLimitReset_DateTime.Subtract(TimeSpan.FromSeconds(1)));
            Assert.GreaterOrEqual(graphQLApiStatus_Initial.RateLimitReset_TimeRemaining.TotalMilliseconds, graphQLApiStatus_Final.RateLimitReset_TimeRemaining.TotalMilliseconds);
            Assert.AreEqual(graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds, graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.Greater(graphQLApiStatus_Initial.RemainingRequestCount, graphQLApiStatus_Final.RemainingRequestCount);
        }

        [Test]
        public async Task GetApiRateLimits_ValidSearchApiRequest()
        {
            //Arrange
            RateLimitStatus searchApiStatus_Initial, searchApiStatus_Final;
            GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

            var startTime = DateTimeOffset.UtcNow;
            var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;

            //Act
            gitHubApiRateLimits_Initial = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            searchApiStatus_Initial = gitHubApiRateLimits_Initial.SearchApi;

            await SendValidSearchApiRequest().ConfigureAwait(false);

            gitHubApiRateLimits_Final = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            searchApiStatus_Final = gitHubApiRateLimits_Final.SearchApi;

            //Assert
            Assert.IsNotNull(searchApiStatus_Initial);
            Assert.AreEqual(30, searchApiStatus_Initial.RateLimit);
            Assert.GreaterOrEqual(searchApiStatus_Initial.RemainingRequestCount, 0);
            Assert.LessOrEqual(searchApiStatus_Initial.RemainingRequestCount, searchApiStatus_Initial.RateLimit);
            Assert.AreEqual(searchApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(searchApiStatus_Initial.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.IsNotNull(searchApiStatus_Final);
            Assert.AreEqual(30, searchApiStatus_Final.RateLimit);
            Assert.GreaterOrEqual(searchApiStatus_Final.RemainingRequestCount, 0);
            Assert.LessOrEqual(searchApiStatus_Final.RemainingRequestCount, searchApiStatus_Final.RateLimit);
            Assert.AreEqual(searchApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), searchApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(searchApiStatus_Final.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(searchApiStatus_Final.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.AreEqual(searchApiStatus_Initial.RateLimit, searchApiStatus_Final.RateLimit);
            Assert.IsTrue(searchApiStatus_Initial.RateLimitReset_DateTime == searchApiStatus_Final.RateLimitReset_DateTime || searchApiStatus_Initial.RateLimitReset_DateTime == searchApiStatus_Final.RateLimitReset_DateTime.Subtract(TimeSpan.FromSeconds(1)));
            Assert.GreaterOrEqual(searchApiStatus_Initial.RateLimitReset_TimeRemaining.TotalMilliseconds, searchApiStatus_Final.RateLimitReset_TimeRemaining.TotalMilliseconds);
            Assert.AreEqual(searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds, searchApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.Greater(searchApiStatus_Initial.RemainingRequestCount, searchApiStatus_Final.RemainingRequestCount);
        }

        [Test]
        public void GetApiRateLimits_InvalidBearerToken()
        {
            //Arrange
            var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;
            gitHubApiStatusService.SetAuthenticationHeaderValue(new AuthenticationHeaderValue(GitHubConstants.AuthScheme, "abc 123"));

            //Act

            //Assert
            var httpRequestException = Assert.ThrowsAsync<HttpRequestException>(() => gitHubApiStatusService.GetApiRateLimits());
#if NET5_0
            Assert.AreEqual(HttpStatusCode.Unauthorized, httpRequestException?.StatusCode);
#else
            Assert.IsTrue(httpRequestException?.Message.Contains("Unauthorized"));
#endif
        }
    }
}
After:
namespace GitHubApiStatus.UnitTests;

    class GetApiRateLimitsTests_NoCancellationToken : BaseTest
    {
        [Test]
        public async Task GetApiRateLimits_ValidRestApiRequest()
        {
            //Arrange
            RateLimitStatus restApiStatus_Initial, restApiStatus_Final;
            GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

            var startTime = DateTimeOffset.UtcNow;
            var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;

            //Act
            gitHubApiRateLimits_Initial = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            restApiStatus_Initial = gitHubApiRateLimits_Initial.RestApi;

            await SendValidRestApiRequest().ConfigureAwait(false);

            gitHubApiRateLimits_Final = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            restApiStatus_Final = gitHubApiRateLimits_Final.RestApi;

            //Assert
            Assert.IsNotNull(restApiStatus_Initial);
            Assert.AreEqual(5000, restApiStatus_Initial.RateLimit);
            Assert.GreaterOrEqual(restApiStatus_Initial.RemainingRequestCount, 0);
            Assert.LessOrEqual(restApiStatus_Initial.RemainingRequestCount, restApiStatus_Initial.RateLimit);
            Assert.AreEqual(restApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), restApiStatus_Initial.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(restApiStatus_Initial.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(restApiStatus_Initial.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.IsNotNull(restApiStatus_Final);
            Assert.AreEqual(5000, restApiStatus_Final.RateLimit);
            Assert.GreaterOrEqual(restApiStatus_Final.RemainingRequestCount, 0);
            Assert.LessOrEqual(restApiStatus_Final.RemainingRequestCount, restApiStatus_Final.RateLimit);
            Assert.AreEqual(restApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), restApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(restApiStatus_Final.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(restApiStatus_Final.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.AreEqual(restApiStatus_Initial.RateLimit, restApiStatus_Final.RateLimit);
            Assert.IsTrue(restApiStatus_Initial.RateLimitReset_DateTime == restApiStatus_Final.RateLimitReset_DateTime || restApiStatus_Initial.RateLimitReset_DateTime == restApiStatus_Final.RateLimitReset_DateTime.Subtract(TimeSpan.FromSeconds(1)));
            Assert.GreaterOrEqual(restApiStatus_Initial.RateLimitReset_TimeRemaining.TotalMilliseconds, restApiStatus_Final.RateLimitReset_TimeRemaining.TotalMilliseconds);
            Assert.AreEqual(restApiStatus_Initial.RateLimitReset_UnixEpochSeconds, restApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.Greater(restApiStatus_Initial.RemainingRequestCount, restApiStatus_Final.RemainingRequestCount);

        }

        [Test]
        public async Task GetApiRateLimits_ValidGraphQLApiRequest()
        {
            //Arrange
            RateLimitStatus graphQLApiStatus_Initial, graphQLApiStatus_Final;
            GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

            var startTime = DateTimeOffset.UtcNow;
            var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;

            //Act
            gitHubApiRateLimits_Initial = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            graphQLApiStatus_Initial = gitHubApiRateLimits_Initial.GraphQLApi;

            await SendValidGraphQLApiRequest().ConfigureAwait(false);

            gitHubApiRateLimits_Final = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            graphQLApiStatus_Final = gitHubApiRateLimits_Final.GraphQLApi;

            //Assert
            Assert.IsNotNull(graphQLApiStatus_Initial);
            Assert.AreEqual(5000, graphQLApiStatus_Initial.RateLimit);
            Assert.GreaterOrEqual(graphQLApiStatus_Initial.RemainingRequestCount, 0);
            Assert.LessOrEqual(graphQLApiStatus_Initial.RemainingRequestCount, graphQLApiStatus_Initial.RateLimit);
            Assert.AreEqual(graphQLApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(graphQLApiStatus_Initial.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.IsNotNull(graphQLApiStatus_Final);
            Assert.AreEqual(5000, graphQLApiStatus_Final.RateLimit);
            Assert.GreaterOrEqual(graphQLApiStatus_Final.RemainingRequestCount, 0);
            Assert.LessOrEqual(graphQLApiStatus_Final.RemainingRequestCount, graphQLApiStatus_Final.RateLimit);
            Assert.AreEqual(graphQLApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(graphQLApiStatus_Final.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.AreEqual(graphQLApiStatus_Initial.RateLimit, graphQLApiStatus_Final.RateLimit);
            Assert.IsTrue(graphQLApiStatus_Initial.RateLimitReset_DateTime == graphQLApiStatus_Final.RateLimitReset_DateTime || graphQLApiStatus_Initial.RateLimitReset_DateTime == graphQLApiStatus_Final.RateLimitReset_DateTime.Subtract(TimeSpan.FromSeconds(1)));
            Assert.GreaterOrEqual(graphQLApiStatus_Initial.RateLimitReset_TimeRemaining.TotalMilliseconds, graphQLApiStatus_Final.RateLimitReset_TimeRemaining.TotalMilliseconds);
            Assert.AreEqual(graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds, graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.Greater(graphQLApiStatus_Initial.RemainingRequestCount, graphQLApiStatus_Final.RemainingRequestCount);
        }

        [Test]
        public async Task GetApiRateLimits_ValidSearchApiRequest()
        {
            //Arrange
            RateLimitStatus searchApiStatus_Initial, searchApiStatus_Final;
            GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

            var startTime = DateTimeOffset.UtcNow;
            var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;

            //Act
            gitHubApiRateLimits_Initial = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            searchApiStatus_Initial = gitHubApiRateLimits_Initial.SearchApi;

            await SendValidSearchApiRequest().ConfigureAwait(false);

            gitHubApiRateLimits_Final = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            searchApiStatus_Final = gitHubApiRateLimits_Final.SearchApi;

            //Assert
            Assert.IsNotNull(searchApiStatus_Initial);
            Assert.AreEqual(30, searchApiStatus_Initial.RateLimit);
            Assert.GreaterOrEqual(searchApiStatus_Initial.RemainingRequestCount, 0);
            Assert.LessOrEqual(searchApiStatus_Initial.RemainingRequestCount, searchApiStatus_Initial.RateLimit);
            Assert.AreEqual(searchApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(searchApiStatus_Initial.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.IsNotNull(searchApiStatus_Final);
            Assert.AreEqual(30, searchApiStatus_Final.RateLimit);
            Assert.GreaterOrEqual(searchApiStatus_Final.RemainingRequestCount, 0);
            Assert.LessOrEqual(searchApiStatus_Final.RemainingRequestCount, searchApiStatus_Final.RateLimit);
            Assert.AreEqual(searchApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), searchApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(searchApiStatus_Final.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(searchApiStatus_Final.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.AreEqual(searchApiStatus_Initial.RateLimit, searchApiStatus_Final.RateLimit);
            Assert.IsTrue(searchApiStatus_Initial.RateLimitReset_DateTime == searchApiStatus_Final.RateLimitReset_DateTime || searchApiStatus_Initial.RateLimitReset_DateTime == searchApiStatus_Final.RateLimitReset_DateTime.Subtract(TimeSpan.FromSeconds(1)));
            Assert.GreaterOrEqual(searchApiStatus_Initial.RateLimitReset_TimeRemaining.TotalMilliseconds, searchApiStatus_Final.RateLimitReset_TimeRemaining.TotalMilliseconds);
            Assert.AreEqual(searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds, searchApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.Greater(searchApiStatus_Initial.RemainingRequestCount, searchApiStatus_Final.RemainingRequestCount);
        }

        [Test]
        public void GetApiRateLimits_InvalidBearerToken()
        {
            //Arrange
            var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;
            gitHubApiStatusService.SetAuthenticationHeaderValue(new AuthenticationHeaderValue(GitHubConstants.AuthScheme, "abc 123"));

            //Act

            //Assert
            var httpRequestException = Assert.ThrowsAsync<HttpRequestException>(() => gitHubApiStatusService.GetApiRateLimits());
#if NET5_0
            Assert.AreEqual(HttpStatusCode.Unauthorized, httpRequestException?.StatusCode);
#else
            Assert.IsTrue(httpRequestException?.Message.Contains("Unauthorized"));
#endif
        }
    }
*/

/* Unmerged change from project 'GitHubApiStatus.UnitTests(net5.0)'
Before:
namespace GitHubApiStatus.UnitTests
{
    class GetApiRateLimitsTests_NoCancellationToken : BaseTest
    {
        [Test]
        public async Task GetApiRateLimits_ValidRestApiRequest()
        {
            //Arrange
            RateLimitStatus restApiStatus_Initial, restApiStatus_Final;
            GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

            var startTime = DateTimeOffset.UtcNow;
            var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;

            //Act
            gitHubApiRateLimits_Initial = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            restApiStatus_Initial = gitHubApiRateLimits_Initial.RestApi;

            await SendValidRestApiRequest().ConfigureAwait(false);

            gitHubApiRateLimits_Final = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            restApiStatus_Final = gitHubApiRateLimits_Final.RestApi;

            //Assert
            Assert.IsNotNull(restApiStatus_Initial);
            Assert.AreEqual(5000, restApiStatus_Initial.RateLimit);
            Assert.GreaterOrEqual(restApiStatus_Initial.RemainingRequestCount, 0);
            Assert.LessOrEqual(restApiStatus_Initial.RemainingRequestCount, restApiStatus_Initial.RateLimit);
            Assert.AreEqual(restApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), restApiStatus_Initial.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(restApiStatus_Initial.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(restApiStatus_Initial.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.IsNotNull(restApiStatus_Final);
            Assert.AreEqual(5000, restApiStatus_Final.RateLimit);
            Assert.GreaterOrEqual(restApiStatus_Final.RemainingRequestCount, 0);
            Assert.LessOrEqual(restApiStatus_Final.RemainingRequestCount, restApiStatus_Final.RateLimit);
            Assert.AreEqual(restApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), restApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(restApiStatus_Final.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(restApiStatus_Final.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.AreEqual(restApiStatus_Initial.RateLimit, restApiStatus_Final.RateLimit);
            Assert.IsTrue(restApiStatus_Initial.RateLimitReset_DateTime == restApiStatus_Final.RateLimitReset_DateTime || restApiStatus_Initial.RateLimitReset_DateTime == restApiStatus_Final.RateLimitReset_DateTime.Subtract(TimeSpan.FromSeconds(1)));
            Assert.GreaterOrEqual(restApiStatus_Initial.RateLimitReset_TimeRemaining.TotalMilliseconds, restApiStatus_Final.RateLimitReset_TimeRemaining.TotalMilliseconds);
            Assert.AreEqual(restApiStatus_Initial.RateLimitReset_UnixEpochSeconds, restApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.Greater(restApiStatus_Initial.RemainingRequestCount, restApiStatus_Final.RemainingRequestCount);

        }

        [Test]
        public async Task GetApiRateLimits_ValidGraphQLApiRequest()
        {
            //Arrange
            RateLimitStatus graphQLApiStatus_Initial, graphQLApiStatus_Final;
            GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

            var startTime = DateTimeOffset.UtcNow;
            var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;

            //Act
            gitHubApiRateLimits_Initial = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            graphQLApiStatus_Initial = gitHubApiRateLimits_Initial.GraphQLApi;

            await SendValidGraphQLApiRequest().ConfigureAwait(false);

            gitHubApiRateLimits_Final = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            graphQLApiStatus_Final = gitHubApiRateLimits_Final.GraphQLApi;

            //Assert
            Assert.IsNotNull(graphQLApiStatus_Initial);
            Assert.AreEqual(5000, graphQLApiStatus_Initial.RateLimit);
            Assert.GreaterOrEqual(graphQLApiStatus_Initial.RemainingRequestCount, 0);
            Assert.LessOrEqual(graphQLApiStatus_Initial.RemainingRequestCount, graphQLApiStatus_Initial.RateLimit);
            Assert.AreEqual(graphQLApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(graphQLApiStatus_Initial.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.IsNotNull(graphQLApiStatus_Final);
            Assert.AreEqual(5000, graphQLApiStatus_Final.RateLimit);
            Assert.GreaterOrEqual(graphQLApiStatus_Final.RemainingRequestCount, 0);
            Assert.LessOrEqual(graphQLApiStatus_Final.RemainingRequestCount, graphQLApiStatus_Final.RateLimit);
            Assert.AreEqual(graphQLApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(graphQLApiStatus_Final.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.AreEqual(graphQLApiStatus_Initial.RateLimit, graphQLApiStatus_Final.RateLimit);
            Assert.IsTrue(graphQLApiStatus_Initial.RateLimitReset_DateTime == graphQLApiStatus_Final.RateLimitReset_DateTime || graphQLApiStatus_Initial.RateLimitReset_DateTime == graphQLApiStatus_Final.RateLimitReset_DateTime.Subtract(TimeSpan.FromSeconds(1)));
            Assert.GreaterOrEqual(graphQLApiStatus_Initial.RateLimitReset_TimeRemaining.TotalMilliseconds, graphQLApiStatus_Final.RateLimitReset_TimeRemaining.TotalMilliseconds);
            Assert.AreEqual(graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds, graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.Greater(graphQLApiStatus_Initial.RemainingRequestCount, graphQLApiStatus_Final.RemainingRequestCount);
        }

        [Test]
        public async Task GetApiRateLimits_ValidSearchApiRequest()
        {
            //Arrange
            RateLimitStatus searchApiStatus_Initial, searchApiStatus_Final;
            GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

            var startTime = DateTimeOffset.UtcNow;
            var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;

            //Act
            gitHubApiRateLimits_Initial = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            searchApiStatus_Initial = gitHubApiRateLimits_Initial.SearchApi;

            await SendValidSearchApiRequest().ConfigureAwait(false);

            gitHubApiRateLimits_Final = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            searchApiStatus_Final = gitHubApiRateLimits_Final.SearchApi;

            //Assert
            Assert.IsNotNull(searchApiStatus_Initial);
            Assert.AreEqual(30, searchApiStatus_Initial.RateLimit);
            Assert.GreaterOrEqual(searchApiStatus_Initial.RemainingRequestCount, 0);
            Assert.LessOrEqual(searchApiStatus_Initial.RemainingRequestCount, searchApiStatus_Initial.RateLimit);
            Assert.AreEqual(searchApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(searchApiStatus_Initial.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.IsNotNull(searchApiStatus_Final);
            Assert.AreEqual(30, searchApiStatus_Final.RateLimit);
            Assert.GreaterOrEqual(searchApiStatus_Final.RemainingRequestCount, 0);
            Assert.LessOrEqual(searchApiStatus_Final.RemainingRequestCount, searchApiStatus_Final.RateLimit);
            Assert.AreEqual(searchApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), searchApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(searchApiStatus_Final.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(searchApiStatus_Final.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.AreEqual(searchApiStatus_Initial.RateLimit, searchApiStatus_Final.RateLimit);
            Assert.IsTrue(searchApiStatus_Initial.RateLimitReset_DateTime == searchApiStatus_Final.RateLimitReset_DateTime || searchApiStatus_Initial.RateLimitReset_DateTime == searchApiStatus_Final.RateLimitReset_DateTime.Subtract(TimeSpan.FromSeconds(1)));
            Assert.GreaterOrEqual(searchApiStatus_Initial.RateLimitReset_TimeRemaining.TotalMilliseconds, searchApiStatus_Final.RateLimitReset_TimeRemaining.TotalMilliseconds);
            Assert.AreEqual(searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds, searchApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.Greater(searchApiStatus_Initial.RemainingRequestCount, searchApiStatus_Final.RemainingRequestCount);
        }

        [Test]
        public void GetApiRateLimits_InvalidBearerToken()
        {
            //Arrange
            var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;
            gitHubApiStatusService.SetAuthenticationHeaderValue(new AuthenticationHeaderValue(GitHubConstants.AuthScheme, "abc 123"));

            //Act

            //Assert
            var httpRequestException = Assert.ThrowsAsync<HttpRequestException>(() => gitHubApiStatusService.GetApiRateLimits());
#if NET5_0
            Assert.AreEqual(HttpStatusCode.Unauthorized, httpRequestException?.StatusCode);
#else
            Assert.IsTrue(httpRequestException?.Message.Contains("Unauthorized"));
#endif
        }
    }
}
After:
namespace GitHubApiStatus.UnitTests;

    class GetApiRateLimitsTests_NoCancellationToken : BaseTest
    {
        [Test]
        public async Task GetApiRateLimits_ValidRestApiRequest()
        {
            //Arrange
            RateLimitStatus restApiStatus_Initial, restApiStatus_Final;
            GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

            var startTime = DateTimeOffset.UtcNow;
            var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;

            //Act
            gitHubApiRateLimits_Initial = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            restApiStatus_Initial = gitHubApiRateLimits_Initial.RestApi;

            await SendValidRestApiRequest().ConfigureAwait(false);

            gitHubApiRateLimits_Final = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            restApiStatus_Final = gitHubApiRateLimits_Final.RestApi;

            //Assert
            Assert.IsNotNull(restApiStatus_Initial);
            Assert.AreEqual(5000, restApiStatus_Initial.RateLimit);
            Assert.GreaterOrEqual(restApiStatus_Initial.RemainingRequestCount, 0);
            Assert.LessOrEqual(restApiStatus_Initial.RemainingRequestCount, restApiStatus_Initial.RateLimit);
            Assert.AreEqual(restApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), restApiStatus_Initial.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(restApiStatus_Initial.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(restApiStatus_Initial.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.IsNotNull(restApiStatus_Final);
            Assert.AreEqual(5000, restApiStatus_Final.RateLimit);
            Assert.GreaterOrEqual(restApiStatus_Final.RemainingRequestCount, 0);
            Assert.LessOrEqual(restApiStatus_Final.RemainingRequestCount, restApiStatus_Final.RateLimit);
            Assert.AreEqual(restApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), restApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(restApiStatus_Final.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(restApiStatus_Final.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.AreEqual(restApiStatus_Initial.RateLimit, restApiStatus_Final.RateLimit);
            Assert.IsTrue(restApiStatus_Initial.RateLimitReset_DateTime == restApiStatus_Final.RateLimitReset_DateTime || restApiStatus_Initial.RateLimitReset_DateTime == restApiStatus_Final.RateLimitReset_DateTime.Subtract(TimeSpan.FromSeconds(1)));
            Assert.GreaterOrEqual(restApiStatus_Initial.RateLimitReset_TimeRemaining.TotalMilliseconds, restApiStatus_Final.RateLimitReset_TimeRemaining.TotalMilliseconds);
            Assert.AreEqual(restApiStatus_Initial.RateLimitReset_UnixEpochSeconds, restApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.Greater(restApiStatus_Initial.RemainingRequestCount, restApiStatus_Final.RemainingRequestCount);

        }

        [Test]
        public async Task GetApiRateLimits_ValidGraphQLApiRequest()
        {
            //Arrange
            RateLimitStatus graphQLApiStatus_Initial, graphQLApiStatus_Final;
            GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

            var startTime = DateTimeOffset.UtcNow;
            var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;

            //Act
            gitHubApiRateLimits_Initial = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            graphQLApiStatus_Initial = gitHubApiRateLimits_Initial.GraphQLApi;

            await SendValidGraphQLApiRequest().ConfigureAwait(false);

            gitHubApiRateLimits_Final = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            graphQLApiStatus_Final = gitHubApiRateLimits_Final.GraphQLApi;

            //Assert
            Assert.IsNotNull(graphQLApiStatus_Initial);
            Assert.AreEqual(5000, graphQLApiStatus_Initial.RateLimit);
            Assert.GreaterOrEqual(graphQLApiStatus_Initial.RemainingRequestCount, 0);
            Assert.LessOrEqual(graphQLApiStatus_Initial.RemainingRequestCount, graphQLApiStatus_Initial.RateLimit);
            Assert.AreEqual(graphQLApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(graphQLApiStatus_Initial.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.IsNotNull(graphQLApiStatus_Final);
            Assert.AreEqual(5000, graphQLApiStatus_Final.RateLimit);
            Assert.GreaterOrEqual(graphQLApiStatus_Final.RemainingRequestCount, 0);
            Assert.LessOrEqual(graphQLApiStatus_Final.RemainingRequestCount, graphQLApiStatus_Final.RateLimit);
            Assert.AreEqual(graphQLApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(graphQLApiStatus_Final.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.AreEqual(graphQLApiStatus_Initial.RateLimit, graphQLApiStatus_Final.RateLimit);
            Assert.IsTrue(graphQLApiStatus_Initial.RateLimitReset_DateTime == graphQLApiStatus_Final.RateLimitReset_DateTime || graphQLApiStatus_Initial.RateLimitReset_DateTime == graphQLApiStatus_Final.RateLimitReset_DateTime.Subtract(TimeSpan.FromSeconds(1)));
            Assert.GreaterOrEqual(graphQLApiStatus_Initial.RateLimitReset_TimeRemaining.TotalMilliseconds, graphQLApiStatus_Final.RateLimitReset_TimeRemaining.TotalMilliseconds);
            Assert.AreEqual(graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds, graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.Greater(graphQLApiStatus_Initial.RemainingRequestCount, graphQLApiStatus_Final.RemainingRequestCount);
        }

        [Test]
        public async Task GetApiRateLimits_ValidSearchApiRequest()
        {
            //Arrange
            RateLimitStatus searchApiStatus_Initial, searchApiStatus_Final;
            GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

            var startTime = DateTimeOffset.UtcNow;
            var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;

            //Act
            gitHubApiRateLimits_Initial = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            searchApiStatus_Initial = gitHubApiRateLimits_Initial.SearchApi;

            await SendValidSearchApiRequest().ConfigureAwait(false);

            gitHubApiRateLimits_Final = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
            searchApiStatus_Final = gitHubApiRateLimits_Final.SearchApi;

            //Assert
            Assert.IsNotNull(searchApiStatus_Initial);
            Assert.AreEqual(30, searchApiStatus_Initial.RateLimit);
            Assert.GreaterOrEqual(searchApiStatus_Initial.RemainingRequestCount, 0);
            Assert.LessOrEqual(searchApiStatus_Initial.RemainingRequestCount, searchApiStatus_Initial.RateLimit);
            Assert.AreEqual(searchApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(searchApiStatus_Initial.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.IsNotNull(searchApiStatus_Final);
            Assert.AreEqual(30, searchApiStatus_Final.RateLimit);
            Assert.GreaterOrEqual(searchApiStatus_Final.RemainingRequestCount, 0);
            Assert.LessOrEqual(searchApiStatus_Final.RemainingRequestCount, searchApiStatus_Final.RateLimit);
            Assert.AreEqual(searchApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), searchApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(searchApiStatus_Final.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(searchApiStatus_Final.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.AreEqual(searchApiStatus_Initial.RateLimit, searchApiStatus_Final.RateLimit);
            Assert.IsTrue(searchApiStatus_Initial.RateLimitReset_DateTime == searchApiStatus_Final.RateLimitReset_DateTime || searchApiStatus_Initial.RateLimitReset_DateTime == searchApiStatus_Final.RateLimitReset_DateTime.Subtract(TimeSpan.FromSeconds(1)));
            Assert.GreaterOrEqual(searchApiStatus_Initial.RateLimitReset_TimeRemaining.TotalMilliseconds, searchApiStatus_Final.RateLimitReset_TimeRemaining.TotalMilliseconds);
            Assert.AreEqual(searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds, searchApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.Greater(searchApiStatus_Initial.RemainingRequestCount, searchApiStatus_Final.RemainingRequestCount);
        }

        [Test]
        public void GetApiRateLimits_InvalidBearerToken()
        {
            //Arrange
            var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;
            gitHubApiStatusService.SetAuthenticationHeaderValue(new AuthenticationHeaderValue(GitHubConstants.AuthScheme, "abc 123"));

            //Act

            //Assert
            var httpRequestException = Assert.ThrowsAsync<HttpRequestException>(() => gitHubApiStatusService.GetApiRateLimits());
#if NET5_0
            Assert.AreEqual(HttpStatusCode.Unauthorized, httpRequestException?.StatusCode);
#else
            Assert.IsTrue(httpRequestException?.Message.Contains("Unauthorized"));
#endif
        }
    }
*/
namespace GitHubApiStatus.UnitTests
{
	class GetApiRateLimitsTests_NoCancellationToken : BaseTest
	{
		[Test]
		public async Task GetApiRateLimits_ValidRestApiRequest()
		{
			//Arrange
			RateLimitStatus restApiStatus_Initial, restApiStatus_Final;
			GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

			var startTime = DateTimeOffset.UtcNow;
			var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;

			//Act
			gitHubApiRateLimits_Initial = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
			restApiStatus_Initial = gitHubApiRateLimits_Initial.RestApi;

			await SendValidRestApiRequest().ConfigureAwait(false);

			gitHubApiRateLimits_Final = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
			restApiStatus_Final = gitHubApiRateLimits_Final.RestApi;

			//Assert
			Assert.IsNotNull(restApiStatus_Initial);
			Assert.AreEqual(5000, restApiStatus_Initial.RateLimit);
			Assert.GreaterOrEqual(restApiStatus_Initial.RemainingRequestCount, 0);
			Assert.LessOrEqual(restApiStatus_Initial.RemainingRequestCount, restApiStatus_Initial.RateLimit);
			Assert.AreEqual(restApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), restApiStatus_Initial.RateLimitReset_UnixEpochSeconds);
			Assert.GreaterOrEqual(restApiStatus_Initial.RateLimitReset_DateTime, startTime);
			Assert.GreaterOrEqual(restApiStatus_Initial.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

			Assert.IsNotNull(restApiStatus_Final);
			Assert.AreEqual(5000, restApiStatus_Final.RateLimit);
			Assert.GreaterOrEqual(restApiStatus_Final.RemainingRequestCount, 0);
			Assert.LessOrEqual(restApiStatus_Final.RemainingRequestCount, restApiStatus_Final.RateLimit);
			Assert.AreEqual(restApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), restApiStatus_Final.RateLimitReset_UnixEpochSeconds);
			Assert.GreaterOrEqual(restApiStatus_Final.RateLimitReset_DateTime, startTime);
			Assert.GreaterOrEqual(restApiStatus_Final.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

			Assert.AreEqual(restApiStatus_Initial.RateLimit, restApiStatus_Final.RateLimit);
			Assert.IsTrue(restApiStatus_Initial.RateLimitReset_DateTime == restApiStatus_Final.RateLimitReset_DateTime || restApiStatus_Initial.RateLimitReset_DateTime == restApiStatus_Final.RateLimitReset_DateTime.Subtract(TimeSpan.FromSeconds(1)));
			Assert.GreaterOrEqual(restApiStatus_Initial.RateLimitReset_TimeRemaining.TotalMilliseconds, restApiStatus_Final.RateLimitReset_TimeRemaining.TotalMilliseconds);
			Assert.AreEqual(restApiStatus_Initial.RateLimitReset_UnixEpochSeconds, restApiStatus_Final.RateLimitReset_UnixEpochSeconds);
			Assert.Greater(restApiStatus_Initial.RemainingRequestCount, restApiStatus_Final.RemainingRequestCount);

		}

		[Test]
		public async Task GetApiRateLimits_ValidGraphQLApiRequest()
		{
			//Arrange
			RateLimitStatus graphQLApiStatus_Initial, graphQLApiStatus_Final;
			GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

			var startTime = DateTimeOffset.UtcNow;
			var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;

			//Act
			gitHubApiRateLimits_Initial = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
			graphQLApiStatus_Initial = gitHubApiRateLimits_Initial.GraphQLApi;

			await SendValidGraphQLApiRequest().ConfigureAwait(false);

			gitHubApiRateLimits_Final = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
			graphQLApiStatus_Final = gitHubApiRateLimits_Final.GraphQLApi;

			//Assert
			Assert.IsNotNull(graphQLApiStatus_Initial);
			Assert.AreEqual(5000, graphQLApiStatus_Initial.RateLimit);
			Assert.GreaterOrEqual(graphQLApiStatus_Initial.RemainingRequestCount, 0);
			Assert.LessOrEqual(graphQLApiStatus_Initial.RemainingRequestCount, graphQLApiStatus_Initial.RateLimit);
			Assert.AreEqual(graphQLApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds);
			Assert.GreaterOrEqual(graphQLApiStatus_Initial.RateLimitReset_DateTime, startTime);
			Assert.GreaterOrEqual(graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

			Assert.IsNotNull(graphQLApiStatus_Final);
			Assert.AreEqual(5000, graphQLApiStatus_Final.RateLimit);
			Assert.GreaterOrEqual(graphQLApiStatus_Final.RemainingRequestCount, 0);
			Assert.LessOrEqual(graphQLApiStatus_Final.RemainingRequestCount, graphQLApiStatus_Final.RateLimit);
			Assert.AreEqual(graphQLApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds);
			Assert.GreaterOrEqual(graphQLApiStatus_Final.RateLimitReset_DateTime, startTime);
			Assert.GreaterOrEqual(graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

			Assert.AreEqual(graphQLApiStatus_Initial.RateLimit, graphQLApiStatus_Final.RateLimit);
			Assert.IsTrue(graphQLApiStatus_Initial.RateLimitReset_DateTime == graphQLApiStatus_Final.RateLimitReset_DateTime || graphQLApiStatus_Initial.RateLimitReset_DateTime == graphQLApiStatus_Final.RateLimitReset_DateTime.Subtract(TimeSpan.FromSeconds(1)));
			Assert.GreaterOrEqual(graphQLApiStatus_Initial.RateLimitReset_TimeRemaining.TotalMilliseconds, graphQLApiStatus_Final.RateLimitReset_TimeRemaining.TotalMilliseconds);
			Assert.AreEqual(graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds, graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds);
			Assert.Greater(graphQLApiStatus_Initial.RemainingRequestCount, graphQLApiStatus_Final.RemainingRequestCount);
		}

		[Test]
		public async Task GetApiRateLimits_ValidSearchApiRequest()
		{
			//Arrange
			RateLimitStatus searchApiStatus_Initial, searchApiStatus_Final;
			GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

			var startTime = DateTimeOffset.UtcNow;
			var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;

			//Act
			gitHubApiRateLimits_Initial = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
			searchApiStatus_Initial = gitHubApiRateLimits_Initial.SearchApi;

			await SendValidSearchApiRequest().ConfigureAwait(false);

			gitHubApiRateLimits_Final = await gitHubApiStatusService.GetApiRateLimits().ConfigureAwait(false);
			searchApiStatus_Final = gitHubApiRateLimits_Final.SearchApi;

			//Assert
			Assert.IsNotNull(searchApiStatus_Initial);
			Assert.AreEqual(30, searchApiStatus_Initial.RateLimit);
			Assert.GreaterOrEqual(searchApiStatus_Initial.RemainingRequestCount, 0);
			Assert.LessOrEqual(searchApiStatus_Initial.RemainingRequestCount, searchApiStatus_Initial.RateLimit);
			Assert.AreEqual(searchApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds);
			Assert.GreaterOrEqual(searchApiStatus_Initial.RateLimitReset_DateTime, startTime);
			Assert.GreaterOrEqual(searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

			Assert.IsNotNull(searchApiStatus_Final);
			Assert.AreEqual(30, searchApiStatus_Final.RateLimit);
			Assert.GreaterOrEqual(searchApiStatus_Final.RemainingRequestCount, 0);
			Assert.LessOrEqual(searchApiStatus_Final.RemainingRequestCount, searchApiStatus_Final.RateLimit);
			Assert.AreEqual(searchApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), searchApiStatus_Final.RateLimitReset_UnixEpochSeconds);
			Assert.GreaterOrEqual(searchApiStatus_Final.RateLimitReset_DateTime, startTime);
			Assert.GreaterOrEqual(searchApiStatus_Final.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

			Assert.AreEqual(searchApiStatus_Initial.RateLimit, searchApiStatus_Final.RateLimit);
			Assert.IsTrue(searchApiStatus_Initial.RateLimitReset_DateTime == searchApiStatus_Final.RateLimitReset_DateTime || searchApiStatus_Initial.RateLimitReset_DateTime == searchApiStatus_Final.RateLimitReset_DateTime.Subtract(TimeSpan.FromSeconds(1)));
			Assert.GreaterOrEqual(searchApiStatus_Initial.RateLimitReset_TimeRemaining.TotalMilliseconds, searchApiStatus_Final.RateLimitReset_TimeRemaining.TotalMilliseconds);
			Assert.AreEqual(searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds, searchApiStatus_Final.RateLimitReset_UnixEpochSeconds);
			Assert.Greater(searchApiStatus_Initial.RemainingRequestCount, searchApiStatus_Final.RemainingRequestCount);
		}

		[Test]
		public void GetApiRateLimits_InvalidBearerToken()
		{
			//Arrange
			var gitHubApiStatusService = (GitHubApiStatusService)GitHubApiStatusService;
			gitHubApiStatusService.SetAuthenticationHeaderValue(new AuthenticationHeaderValue(GitHubConstants.AuthScheme, "abc 123"));

			//Act

			//Assert
			var httpRequestException = Assert.ThrowsAsync<HttpRequestException>(() => gitHubApiStatusService.GetApiRateLimits());
#if NET5_0
            Assert.AreEqual(HttpStatusCode.Unauthorized, httpRequestException?.StatusCode);
#else
			Assert.IsTrue(httpRequestException?.Message.Contains("Unauthorized"));
#endif
		}
	}
}