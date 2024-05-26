using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GitHubApiStatus;
using GitStatus.Shared;

namespace GitStatus.ConsoleApp;

class Program
{
	static readonly HttpClient _client = CreateGitHubHttpClient(new AuthenticationHeaderValue(GitHubConstants.AuthScheme, GitHubConstants.PersonalAccessToken), new ProductHeaderValue(nameof(GitStatus)));
	static readonly GitHubApiStatusService _gitHubApiStatusService = new(_client);

	static async Task Main(string[] args)
	{
		var restApiRateLimitDataFromHeaders = await GetRestApiRateLimitDataFromHeaders();

		Console.WriteLine($"What is the GitHub REST API Rate Limit? {restApiRateLimitDataFromHeaders.RateLimit}"); // What is the GitHub REST API Rate Limit? 5000
		Console.WriteLine($"Have I reached the Maximum REST API Limit? {restApiRateLimitDataFromHeaders.HasReachedMaximumApiLimit}"); // Have I reached the Maximum REST API Limit? False
		Console.WriteLine($"How many REST API requests do I have remaining? {restApiRateLimitDataFromHeaders.RemainingRequestCount}"); // How many REST API requests do I have remaining? 4956
		Console.WriteLine($"How long until the GitHub REST API Rate Limit resets? {restApiRateLimitDataFromHeaders.RateLimitTimeRemaining}"); // How long until the GitHub REST API Rate Limit resets? 00:29:12.4134330
		Console.WriteLine($"Did the GitHub REST API Request include a Bearer Token? {restApiRateLimitDataFromHeaders.IsResponseFromAuthenticatedRequest}"); // Did GitHub REST API Request include a Bearer Token? True

		Console.WriteLine();

		var apiRateLimits = await GetApiRateLimits();

		// REST API Results
		Console.WriteLine($"What is the GitHub REST API Rate Limit? {apiRateLimits.RestApi.RateLimit}"); // What is the GitHub REST API Rate Limit? 5000
		Console.WriteLine($"How many REST API requests do I have remaining? {apiRateLimits.RestApi.RemainingRequestCount}"); // How many REST API requests do I have remaining? 4983
		Console.WriteLine($"How long until the GitHub REST API Rate Limit resets? {apiRateLimits.RestApi.RateLimitReset_TimeRemaining}"); // How long until the GitHub REST API Rate Limit resets? 00:40:13.8035515
		Console.WriteLine($"When does the GitHub REST API Rate Limit reset? {apiRateLimits.RestApi.RateLimitReset_DateTime}"); // When does the GitHub REST API Rate Limit reset? 10/29/2020 3:28:58 AM +00:00

		Console.WriteLine();

		// GraphQL API Results
		Console.WriteLine($"What is the GitHub GraphQL API Rate Limit? {apiRateLimits.GraphQLApi.RateLimit}"); // What is the GitHub GraphQL API Rate Limit? 5000
		Console.WriteLine($"How many GraphQL API requests do I have remaining? {apiRateLimits.GraphQLApi.RemainingRequestCount}"); // How many GraphQL API requests do I have remaining? 5000
		Console.WriteLine($"How long until the GitHub GraphQL API Rate Limit resets? {apiRateLimits.GraphQLApi.RateLimitReset_TimeRemaining}"); // How long until the GitHub GraphQL API Rate Limit resets? 00:59:59.8034526
		Console.WriteLine($"When does the GitHub GraphQL API Rate Limit reset? {apiRateLimits.GraphQLApi.RateLimitReset_DateTime}"); // When does the GitHub GraphQL API Rate Limit reset? 10/29/2020 3:48:44 AM +00:00

		Console.WriteLine();

		// Search API Results
		Console.WriteLine($"What is the GitHub Search API Rate Limit? {apiRateLimits.SearchApi.RateLimit}"); // What is the GitHub Search API Rate Limit? 30
		Console.WriteLine($"How many Search API requests do I have remaining? {apiRateLimits.SearchApi.RemainingRequestCount}"); // How many Search API requests do I have remaining? 30
		Console.WriteLine($"How long until the GitHub Search API Rate Limit resets? {apiRateLimits.SearchApi.RateLimitReset_TimeRemaining}"); // How long until the GitHub Search API Rate Limit resets? 00:00:59.8034988
		Console.WriteLine($"When does the GitHub Search API Rate Limit reset? {apiRateLimits.SearchApi.RateLimitReset_DateTime}"); // When does the GitHub Search API Rate Limit reset? 10/29/2020 2:49:44 AM +00:00

		Console.WriteLine();

		// Source Import API Results
		Console.WriteLine($"What is the GitHub Source Import API Rate Limit? {apiRateLimits.SourceImport.RateLimit}"); // What is the GitHub Source Import API Rate Limit? 100
		Console.WriteLine($"How many Source Import API requests do I have remaining? {apiRateLimits.SourceImport.RemainingRequestCount}"); // How many Source Import API requests do I have remaining? 100
		Console.WriteLine($"How long until the GitHub Source Import API Rate Limit resets? {apiRateLimits.SourceImport.RateLimitReset_TimeRemaining}"); // How long until the GitHub Source Import API Rate Limit resets? 00:00:59.8034154
		Console.WriteLine($"When does the GitHub Source Import API Rate Limit reset? {apiRateLimits.SourceImport.RateLimitReset_DateTime}"); // When does the GitHub Source Import API Rate Limit reset? 10/29/2020 2:49:44 AM +00:00

		Console.WriteLine();

		// App Manifest Configuration API Results
		Console.WriteLine($"What is the GitHub App Manifest Configuration API Rate Limit? {apiRateLimits.AppManifestConfiguration.RateLimit}"); // What is the GitHub App Manifest Configuration API Rate Limit? 5000
		Console.WriteLine($"How many App Manifest Configuration API requests do I have remaining? {apiRateLimits.AppManifestConfiguration.RemainingRequestCount}"); // How many App Manifest Configuration API requests do I have remaining? 5000
		Console.WriteLine($"How long until the GitHub App Manifest Configuration API Rate Limit resets? {apiRateLimits.AppManifestConfiguration.RateLimitReset_TimeRemaining}"); // How long until the GitHub App Manifest Configuration API Rate Limit resets? 00:59:59.8033802
		Console.WriteLine($"When does the GitHub App Manifest Configuration API Rate Limit reset? {apiRateLimits.AppManifestConfiguration.RateLimitReset_DateTime}"); // When does the GitHub App Manifest Configuration API Rate Limit reset? 10/29/2020 3:48:44 AM +00:00

		Console.WriteLine();

		// Code Scanning Upload API Results
		Console.WriteLine($"What is the GitHub Code Scanning Upload API Rate Limit? {apiRateLimits.CodeScanningUpload.RateLimit}"); // What is the GitHub Code Scanning Upload API Rate Limit? 500
		Console.WriteLine($"How many Code Scanning Upload API requests do I have remaining? {apiRateLimits.CodeScanningUpload.RemainingRequestCount}"); // How many Code Scanning Upload API requests do I have remaining? 500
		Console.WriteLine($"How long until the GitHub Code Scanning Upload API Rate Limit resets? {apiRateLimits.CodeScanningUpload.RateLimitReset_TimeRemaining}"); // How long until the GitHub Code Scanning Upload API Rate Limit resets? 00:59:59.8033455
		Console.WriteLine($"When does the GitHub Code Scanning Upload API Rate Limit reset? {apiRateLimits.CodeScanningUpload.RateLimitReset_DateTime}"); // When does the GitHub Code Scanning Upload API Rate Limit reset? 10/29/2020 3:48:44 AM +00:00

		Console.WriteLine();
	}

	static async Task<(TimeSpan RateLimitTimeRemaining, int RateLimit, int RemainingRequestCount, bool IsResponseFromAuthenticatedRequest, bool HasReachedMaximumApiLimit)> GetRestApiRateLimitDataFromHeaders()
	{
		HttpResponseMessage restApiResponse = await _client.GetAsync($"{GitHubConstants.GitHubRestApiUrl}/repos/brminnick/GitHubApiStatus");
		restApiResponse.EnsureSuccessStatusCode();

		TimeSpan rateLimitTimeRemaining = _gitHubApiStatusService.GetRateLimitTimeRemaining(restApiResponse.Headers);

		int rateLimit = _gitHubApiStatusService.GetRateLimit(restApiResponse.Headers);
		int remainingRequestCount = _gitHubApiStatusService.GetRemainingRequestCount(restApiResponse.Headers);

		bool isResponseFromAuthenticatedRequest = _gitHubApiStatusService.IsResponseFromAuthenticatedRequest(restApiResponse.Headers);

		bool hasReachedMaximumApiLimit = _gitHubApiStatusService.HasReachedMaximumApiCallLimit(restApiResponse.Headers);

		return (rateLimitTimeRemaining, rateLimit, remainingRequestCount, isResponseFromAuthenticatedRequest, hasReachedMaximumApiLimit);
	}

	static Task<GitHubApiRateLimits> GetApiRateLimits()
	{
		if (string.IsNullOrWhiteSpace(GitHubConstants.PersonalAccessToken))
			throw new ArgumentException("GitHubConstants.PersonalAccessToken Cannot be Empty");

		return _gitHubApiStatusService.GetApiRateLimits();
	}

	static HttpClient CreateGitHubHttpClient(in AuthenticationHeaderValue authenticationHeaderValue, in ProductHeaderValue productHeaderValue)
	{
		var client = new HttpClient();
		client.DefaultRequestHeaders.Authorization = authenticationHeaderValue;
		client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(productHeaderValue));

		return client;
	}
}