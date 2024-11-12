﻿using System.Net.Http;
using System.Net.Http.Headers;
using GitStatus.Common;
using NUnit.Framework;

namespace GitHubApiStatus.UnitTests;

class GetApiRateLimitsTests_WithCancellationToken : BaseTest
{
	[Test]
	public async Task GetApiRateLimits_ValidRestApiRequest()
	{
		//Arrange
		RateLimitStatus restApiStatus_Initial, restApiStatus_Final;
		GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

		var startTime = DateTimeOffset.UtcNow;
		var cancellationTokenSource = new CancellationTokenSource();

		//Act
		gitHubApiRateLimits_Initial = await GitHubApiStatusService.GetApiRateLimits(cancellationTokenSource.Token).ConfigureAwait(false);
		restApiStatus_Initial = gitHubApiRateLimits_Initial.RestApi;

		await SendValidRestApiRequest().ConfigureAwait(false);

		gitHubApiRateLimits_Final = await GitHubApiStatusService.GetApiRateLimits(cancellationTokenSource.Token).ConfigureAwait(false);
		restApiStatus_Final = gitHubApiRateLimits_Final.RestApi;

		//Assert
		Assert.Multiple(() =>
		{
			Assert.That(restApiStatus_Initial, Is.Not.Null);
			Assert.That(restApiStatus_Initial.RateLimit, Is.EqualTo(5000));
			Assert.That(restApiStatus_Initial.RemainingRequestCount, Is.GreaterThanOrEqualTo(0));
			Assert.That(restApiStatus_Initial.RemainingRequestCount, Is.LessThanOrEqualTo(restApiStatus_Initial.RateLimit));
			Assert.That(restApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), Is.EqualTo(restApiStatus_Initial.RateLimitReset_UnixEpochSeconds));
			Assert.That(restApiStatus_Initial.RateLimitReset_DateTime, Is.GreaterThanOrEqualTo(startTime));
			Assert.That(restApiStatus_Initial.RateLimitReset_UnixEpochSeconds, Is.GreaterThanOrEqualTo(startTime.ToUnixTimeSeconds()));

			Assert.That(restApiStatus_Final, Is.Not.Null);
			Assert.That(restApiStatus_Final.RateLimit, Is.EqualTo(5000));
			Assert.That(restApiStatus_Final.RemainingRequestCount, Is.GreaterThanOrEqualTo(0));
			Assert.That(restApiStatus_Final.RemainingRequestCount, Is.LessThanOrEqualTo(restApiStatus_Final.RateLimit));
			Assert.That(restApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), Is.EqualTo(restApiStatus_Final.RateLimitReset_UnixEpochSeconds));
			Assert.That(restApiStatus_Final.RateLimitReset_DateTime, Is.GreaterThanOrEqualTo(startTime));
			Assert.That(restApiStatus_Final.RateLimitReset_UnixEpochSeconds, Is.GreaterThanOrEqualTo(startTime.ToUnixTimeSeconds()));

			Assert.That(restApiStatus_Initial.RateLimit, Is.EqualTo(restApiStatus_Final.RateLimit));
			Assert.That(restApiStatus_Initial.RateLimitReset_DateTime, Is.EqualTo(restApiStatus_Final.RateLimitReset_DateTime));
			Assert.That(restApiStatus_Initial.RateLimitReset_TimeRemaining, Is.GreaterThanOrEqualTo(restApiStatus_Final.RateLimitReset_TimeRemaining));
			Assert.That(restApiStatus_Initial.RateLimitReset_UnixEpochSeconds, Is.EqualTo(restApiStatus_Final.RateLimitReset_UnixEpochSeconds));
			Assert.That(restApiStatus_Initial.RemainingRequestCount, Is.GreaterThan(restApiStatus_Final.RemainingRequestCount));
		});
	}

	[Test]
	public async Task GetApiRateLimits_ValidGraphQLApiRequest()
	{
		//Arrange
		RateLimitStatus graphQLApiStatus_Initial, graphQLApiStatus_Final;
		GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

		var startTime = DateTimeOffset.UtcNow;
		var cancellationTokenSource = new CancellationTokenSource();

		//Act
		gitHubApiRateLimits_Initial = await GitHubApiStatusService.GetApiRateLimits(cancellationTokenSource.Token).ConfigureAwait(false);
		graphQLApiStatus_Initial = gitHubApiRateLimits_Initial.GraphQLApi;

		await SendValidGraphQLApiRequest().ConfigureAwait(false);

		gitHubApiRateLimits_Final = await GitHubApiStatusService.GetApiRateLimits(cancellationTokenSource.Token).ConfigureAwait(false);
		graphQLApiStatus_Final = gitHubApiRateLimits_Final.GraphQLApi;

		//Assert
		Assert.Multiple(() =>
		{
			Assert.That(graphQLApiStatus_Initial, Is.Not.Null);
			Assert.That(graphQLApiStatus_Initial.RateLimit, Is.EqualTo(5000));
			Assert.That(graphQLApiStatus_Initial.RemainingRequestCount, Is.GreaterThanOrEqualTo(0));
			Assert.That(graphQLApiStatus_Initial.RemainingRequestCount, Is.LessThanOrEqualTo(graphQLApiStatus_Initial.RateLimit));
			Assert.That(graphQLApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), Is.EqualTo(graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds));
			Assert.That(graphQLApiStatus_Initial.RateLimitReset_DateTime, Is.GreaterThanOrEqualTo(startTime));
			Assert.That(graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds, Is.GreaterThanOrEqualTo(startTime.ToUnixTimeSeconds()));

			Assert.That(graphQLApiStatus_Final, Is.Not.Null);
			Assert.That(graphQLApiStatus_Final.RateLimit, Is.EqualTo(5000));
			Assert.That(graphQLApiStatus_Final.RemainingRequestCount, Is.GreaterThanOrEqualTo(0));
			Assert.That(graphQLApiStatus_Final.RemainingRequestCount, Is.LessThanOrEqualTo(graphQLApiStatus_Final.RateLimit));
			Assert.That(graphQLApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), Is.EqualTo(graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds));
			Assert.That(graphQLApiStatus_Final.RateLimitReset_DateTime, Is.GreaterThanOrEqualTo(startTime));
			Assert.That(graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds, Is.GreaterThanOrEqualTo(startTime.ToUnixTimeSeconds()));

			Assert.That(graphQLApiStatus_Initial.RateLimit, Is.EqualTo(graphQLApiStatus_Final.RateLimit));
			Assert.That(graphQLApiStatus_Initial.RateLimitReset_DateTime, Is.EqualTo(graphQLApiStatus_Final.RateLimitReset_DateTime));
			Assert.That(graphQLApiStatus_Initial.RateLimitReset_TimeRemaining, Is.GreaterThanOrEqualTo(graphQLApiStatus_Final.RateLimitReset_TimeRemaining));
			Assert.That(graphQLApiStatus_Initial.RateLimitReset_UnixEpochSeconds, Is.EqualTo(graphQLApiStatus_Final.RateLimitReset_UnixEpochSeconds));
			Assert.That(graphQLApiStatus_Initial.RemainingRequestCount, Is.GreaterThan(graphQLApiStatus_Final.RemainingRequestCount));
		});
	}

	[Test]
	public async Task GetApiRateLimits_ValidSearchApiRequest()
	{
		//Arrange
		RateLimitStatus searchApiStatus_Initial, searchApiStatus_Final;
		GitHubApiRateLimits gitHubApiRateLimits_Initial, gitHubApiRateLimits_Final;

		var startTime = DateTimeOffset.UtcNow;
		var cancellationTokenSource = new CancellationTokenSource();

		//Act
		gitHubApiRateLimits_Initial = await GitHubApiStatusService.GetApiRateLimits(cancellationTokenSource.Token).ConfigureAwait(false);
		searchApiStatus_Initial = gitHubApiRateLimits_Initial.SearchApi;

		await SendValidSearchApiRequest().ConfigureAwait(false);

		gitHubApiRateLimits_Final = await GitHubApiStatusService.GetApiRateLimits(cancellationTokenSource.Token).ConfigureAwait(false);
		searchApiStatus_Final = gitHubApiRateLimits_Final.SearchApi;

		//Assert
		Assert.Multiple(() =>
		{
			Assert.That(searchApiStatus_Initial, Is.Not.Null);
			Assert.That(searchApiStatus_Initial.RateLimit, Is.EqualTo(30));
			Assert.That(searchApiStatus_Initial.RemainingRequestCount, Is.GreaterThanOrEqualTo(0));
			Assert.That(searchApiStatus_Initial.RemainingRequestCount, Is.LessThanOrEqualTo(searchApiStatus_Initial.RateLimit));
			Assert.That(searchApiStatus_Initial.RateLimitReset_DateTime.ToUnixTimeSeconds(), Is.EqualTo(searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds));
			Assert.That(searchApiStatus_Initial.RateLimitReset_DateTime, Is.GreaterThanOrEqualTo(startTime));
			Assert.That(searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds, Is.GreaterThanOrEqualTo(startTime.ToUnixTimeSeconds()));

			Assert.That(searchApiStatus_Final, Is.Not.Null);
			Assert.That(searchApiStatus_Final.RateLimit, Is.EqualTo(30));
			Assert.That(searchApiStatus_Final.RemainingRequestCount, Is.GreaterThanOrEqualTo(0));
			Assert.That(searchApiStatus_Final.RemainingRequestCount, Is.LessThanOrEqualTo(searchApiStatus_Final.RateLimit));
			Assert.That(searchApiStatus_Final.RateLimitReset_DateTime.ToUnixTimeSeconds(), Is.EqualTo(searchApiStatus_Final.RateLimitReset_UnixEpochSeconds));
			Assert.That(searchApiStatus_Final.RateLimitReset_DateTime, Is.GreaterThanOrEqualTo(startTime));
			Assert.That(searchApiStatus_Final.RateLimitReset_UnixEpochSeconds, Is.GreaterThanOrEqualTo(startTime.ToUnixTimeSeconds()));

			if (searchApiStatus_Final.RateLimitReset_DateTime == searchApiStatus_Initial.RateLimitReset_DateTime)
			{
				Assert.That(searchApiStatus_Initial.RateLimit, Is.EqualTo(searchApiStatus_Final.RateLimit));
				Assert.That(searchApiStatus_Initial.RateLimitReset_DateTime, Is.EqualTo(searchApiStatus_Final.RateLimitReset_DateTime));
				Assert.That(searchApiStatus_Initial.RateLimitReset_TimeRemaining, Is.GreaterThanOrEqualTo(searchApiStatus_Final.RateLimitReset_TimeRemaining));
				Assert.That(searchApiStatus_Initial.RateLimitReset_UnixEpochSeconds, Is.EqualTo(searchApiStatus_Final.RateLimitReset_UnixEpochSeconds));
				Assert.That(searchApiStatus_Initial.RemainingRequestCount, Is.GreaterThanOrEqualTo(searchApiStatus_Final.RemainingRequestCount));
			}
		});
	}

	[Test]
	public void GetApiRateLimits_CancelledRequest()
	{
		//Arrange
		var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMilliseconds(1));
		var authenticationHeaderValue = new AuthenticationHeaderValue(GitHubConstants.AuthScheme, GitHubConstants.PersonalAccessToken);

		//Act

		//Assert
		Assert.That(() => GitHubApiStatusService.GetApiRateLimits(cancellationTokenSource.Token), Throws.TypeOf<TaskCanceledException>());
	}

	[Test]
	public void GetApiRateLimits_InvalidBearerToken()
	{
		//Arrange
		var cancellationTokenSource = new CancellationTokenSource();
		GitHubApiStatusService.SetAuthenticationHeaderValue(new AuthenticationHeaderValue(GitHubConstants.AuthScheme, "abc 123"));

		//Act

		//Assert
		var httpRequestException = Assert.ThrowsAsync<HttpRequestException>(() => GitHubApiStatusService.GetApiRateLimits(cancellationTokenSource.Token));
		Assert.That(httpRequestException?.Message, Does.Contain("Unauthorized"));
	}
}
