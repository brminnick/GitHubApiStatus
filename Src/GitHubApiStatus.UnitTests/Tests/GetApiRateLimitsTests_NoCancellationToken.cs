using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GitStatus.Shared;
using NUnit.Framework;

namespace GitHubApiStatus.UnitTests
{
    class GetApiRateLimitsTests_NoCancellationToken : BaseTest
    {
        [Test]
        public void GetApiRateLimits_NullAuthenticationHeaderValue()
        {
            //Arrange
            AuthenticationHeaderValue? authenticationHeaderValue = null;

            //Act

            //Assert
#pragma warning disable CS8604 // Possible null reference argument.
            Assert.ThrowsAsync<ArgumentNullException>(() => GitHubApiStatusService.Instance.GetApiRateLimits(authenticationHeaderValue));
#pragma warning restore CS8604 // Possible null reference argument.
        }

        [TestCase("Basic")]
        [TestCase("Oauth")]
        [TestCase("Digest")]
        public void GetApiRateLimits_InvalidScheme(string scheme)
        {
            //Arrange
            var authenticationHeaderValue = new AuthenticationHeaderValue(scheme, GitHubConstants.PersonalAccessToken);

            //Act

            //Assert
            Assert.ThrowsAsync<ArgumentException>(() => GitHubApiStatusService.Instance.GetApiRateLimits(authenticationHeaderValue));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void GetApiRateLimits_InvalidParameter(string parameter)
        {
            //Arrange
            var authenticationHeaderValue = new AuthenticationHeaderValue("bearer", parameter);

            //Act

            //Assert
            Assert.ThrowsAsync<ArgumentException>(() => GitHubApiStatusService.Instance.GetApiRateLimits(authenticationHeaderValue));
        }

        [Test]
        public async Task GetApiRateLimits_ValidRestApiRequest()
        {
            //Arrange
            RateLimitStatus restApiStatus_Initial, restApiStatus_Final;
            GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

            var startTime = DateTimeOffset.UtcNow;
            var authenticationHeaderValue = new AuthenticationHeaderValue("bearer", GitHubConstants.PersonalAccessToken);

            //Act
            gitHubApiRateLimits_Initial = await GitHubApiStatusService.Instance.GetApiRateLimits(authenticationHeaderValue).ConfigureAwait(false);
            restApiStatus_Initial = gitHubApiRateLimits_Initial.RestApi;

            await SendValidRestApiRequest().ConfigureAwait(false);

            gitHubApiRateLimits_Final = await GitHubApiStatusService.Instance.GetApiRateLimits(authenticationHeaderValue).ConfigureAwait(false);
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
            Assert.AreEqual(restApiStatus_Initial.RateLimitReset_DateTime, restApiStatus_Final.RateLimitReset_DateTime);
            Assert.Greater(restApiStatus_Initial.RateLimitReset_TimeRemaining, restApiStatus_Final.RateLimitReset_TimeRemaining);
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
            var authenticationHeaderValue = new AuthenticationHeaderValue("bearer", GitHubConstants.PersonalAccessToken);

            //Act
            gitHubApiRateLimits_Initial = await GitHubApiStatusService.Instance.GetApiRateLimits(authenticationHeaderValue).ConfigureAwait(false);
            graphQLApiStatus_Initial = gitHubApiRateLimits_Initial.GraphQLApi;

            await SendValidGraphQLApiRequest().ConfigureAwait(false);

            gitHubApiRateLimits_Final = await GitHubApiStatusService.Instance.GetApiRateLimits(authenticationHeaderValue).ConfigureAwait(false);
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
            Assert.AreEqual(graphQLApiStatus_Initial.RateLimitReset_DateTime, graphQLApiStatus_Final.RateLimitReset_DateTime);
            Assert.Greater(graphQLApiStatus_Initial.RateLimitReset_TimeRemaining, graphQLApiStatus_Final.RateLimitReset_TimeRemaining);
            Assert.AreEqual(graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds, graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.Greater(graphQLApiStatus_Initial.RemainingRequestCount, graphQLApiStatus_Final.RemainingRequestCount);
        }

        [Test]
        public async Task GetApiRateLimits_ValidSearchApiRequest()
        {
            //Arrange
            RateLimitStatus searchApiStatus_Initial, codeScanningApiStatus_Final;
            GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

            var startTime = DateTimeOffset.UtcNow;
            var authenticationHeaderValue = new AuthenticationHeaderValue("bearer", GitHubConstants.PersonalAccessToken);

            //Act
            gitHubApiRateLimits_Initial = await GitHubApiStatusService.Instance.GetApiRateLimits(authenticationHeaderValue).ConfigureAwait(false);
            searchApiStatus_Initial = gitHubApiRateLimits_Initial.SearchApi;

            await SendValidSearchApiRequest().ConfigureAwait(false);

            gitHubApiRateLimits_Final = await GitHubApiStatusService.Instance.GetApiRateLimits(authenticationHeaderValue).ConfigureAwait(false);
            codeScanningApiStatus_Final = gitHubApiRateLimits_Final.SearchApi;

            //Assert
            Assert.IsNotNull(searchApiStatus_Initial);
            Assert.AreEqual(30, searchApiStatus_Initial.RateLimit);
            Assert.GreaterOrEqual(searchApiStatus_Initial.RemainingRequestCount, 0);
            Assert.LessOrEqual(searchApiStatus_Initial.RemainingRequestCount, searchApiStatus_Initial.RateLimit);
            Assert.AreEqual(searchApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(searchApiStatus_Initial.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.IsNotNull(codeScanningApiStatus_Final);
            Assert.AreEqual(30, codeScanningApiStatus_Final.RateLimit);
            Assert.GreaterOrEqual(codeScanningApiStatus_Final.RemainingRequestCount, 0);
            Assert.LessOrEqual(codeScanningApiStatus_Final.RemainingRequestCount, codeScanningApiStatus_Final.RateLimit);
            Assert.AreEqual(codeScanningApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), codeScanningApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.GreaterOrEqual(codeScanningApiStatus_Final.RateLimitReset_DateTime, startTime);
            Assert.GreaterOrEqual(codeScanningApiStatus_Final.RateLimitReset_UnixEpochSeconds, startTime.ToUnixTimeSeconds());

            Assert.AreEqual(searchApiStatus_Initial.RateLimit, codeScanningApiStatus_Final.RateLimit);
            Assert.AreEqual(searchApiStatus_Initial.RateLimitReset_DateTime, codeScanningApiStatus_Final.RateLimitReset_DateTime);
            Assert.Greater(searchApiStatus_Initial.RateLimitReset_TimeRemaining, codeScanningApiStatus_Final.RateLimitReset_TimeRemaining);
            Assert.AreEqual(searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds, codeScanningApiStatus_Final.RateLimitReset_UnixEpochSeconds);
            Assert.Greater(searchApiStatus_Initial.RemainingRequestCount, codeScanningApiStatus_Final.RemainingRequestCount);
        }
    }
}
