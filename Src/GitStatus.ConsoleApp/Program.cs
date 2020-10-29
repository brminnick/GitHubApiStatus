using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GitHubApiStatus;
using GitStatus.Shared;

namespace GitStatus.ConsoleApp
{
    class Program
    {
        static readonly HttpClient _client = new HttpClient
        {
            DefaultRequestHeaders =
            {
                { "User-Agent", nameof(GitStatus) },
            }
        };

        static async Task Main(string[] args)
        {
            if (!string.IsNullOrWhiteSpace(GitHubConstants.PersonalAccessToken))
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", GitHubConstants.PersonalAccessToken);

            var restApiRateLimitDataFromHeaders = await GetRestApiRateLimitDataFromHeaders();

            Console.WriteLine($"What is the GitHub API Rate Limit? {restApiRateLimitDataFromHeaders.RateLimit}");
            Console.WriteLine($"Have I reached the Maximum API Limit? {restApiRateLimitDataFromHeaders.HasReachedMaximumApiLimit}");
            Console.WriteLine($"How many API requests do I have remaining? {restApiRateLimitDataFromHeaders.RemainingRequestCount}");
            Console.WriteLine($"How long until the GitHub API Rate Limit resets? {restApiRateLimitDataFromHeaders.RateLimitTimeRemaining}");
            Console.WriteLine($"Did GitHub API Request include a Bearer Token? {restApiRateLimitDataFromHeaders.IsAuthenticated}");

            Console.WriteLine("");

            var apiRateLimits = await GetApiRateLimits();

            // REST API Results
            Console.WriteLine($"What is the GitHub REST API Rate Limit? {apiRateLimits.RestApi.RateLimit}");
            Console.WriteLine($"How many REST API requests do I have remaining? {apiRateLimits.RestApi.RemainingRequestCount}");
            Console.WriteLine($"How long until the GitHub REST API Rate Limit resets? {apiRateLimits.RestApi.RateLimitReset_TimeRemaining}");
            Console.WriteLine($"When does the GitHub REST API Rate Limit reset? {apiRateLimits.RestApi.RateLimitReset_DateTime}");

            Console.WriteLine("");

            // GraphQL API Results
            Console.WriteLine($"What is the GitHub GraphQL API Rate Limit? {apiRateLimits.GraphQLApi.RateLimit}");
            Console.WriteLine($"How many GraphQL API requests do I have remaining? {apiRateLimits.GraphQLApi.RemainingRequestCount}");
            Console.WriteLine($"How long until the GitHub GraphQL API Rate Limit resets? {apiRateLimits.GraphQLApi.RateLimitReset_TimeRemaining}");
            Console.WriteLine($"When does the GitHub GraphQL API Rate Limit reset? {apiRateLimits.GraphQLApi.RateLimitReset_DateTime}");

            Console.WriteLine("");

            // Search API Results
            Console.WriteLine($"What is the GitHub Search API Rate Limit? {apiRateLimits.SearchApi.RateLimit}");
            Console.WriteLine($"How many Search API requests do I have remaining? {apiRateLimits.SearchApi.RemainingRequestCount}");
            Console.WriteLine($"How long until the GitHub Search API Rate Limit resets? {apiRateLimits.SearchApi.RateLimitReset_TimeRemaining}");
            Console.WriteLine($"When does the GitHub Search API Rate Limit reset? {apiRateLimits.SearchApi.RateLimitReset_DateTime}");

            Console.WriteLine("");

            // Source Import API Results
            Console.WriteLine($"What is the GitHub Source Import API Rate Limit? {apiRateLimits.SourceImport.RateLimit}");
            Console.WriteLine($"How many Source Import API requests do I have remaining? {apiRateLimits.SourceImport.RemainingRequestCount}");
            Console.WriteLine($"How long until the GitHub Source Import API Rate Limit resets? {apiRateLimits.SourceImport.RateLimitReset_TimeRemaining}");
            Console.WriteLine($"When does the GitHub Source Import API Rate Limit reset? {apiRateLimits.SourceImport.RateLimitReset_DateTime}");

            Console.WriteLine("");

            // App Manifest Configuration API Results
            Console.WriteLine($"What is the GitHub App Manifest Configuration API Rate Limit? {apiRateLimits.AppManifestConfiguration.RateLimit}");
            Console.WriteLine($"How many App Manifest Configuration API requests do I have remaining? {apiRateLimits.AppManifestConfiguration.RemainingRequestCount}");
            Console.WriteLine($"How long until the GitHub App Manifest Configuration API Rate Limit resets? {apiRateLimits.AppManifestConfiguration.RateLimitReset_TimeRemaining}");
            Console.WriteLine($"When does the GitHub App Manifest Configuration API Rate Limit reset? {apiRateLimits.AppManifestConfiguration.RateLimitReset_DateTime}");

            Console.WriteLine("");

            // Code Scanning Upload API Results
            Console.WriteLine($"What is the GitHub Code Scanning Upload API Rate Limit? {apiRateLimits.CodeScanningUpload.RateLimit}");
            Console.WriteLine($"How many Code Scanning Upload API requests do I have remaining? {apiRateLimits.CodeScanningUpload.RemainingRequestCount}");
            Console.WriteLine($"How long until the GitHub Code Scanning Upload API Rate Limit resets? {apiRateLimits.CodeScanningUpload.RateLimitReset_TimeRemaining}");
            Console.WriteLine($"When does the GitHub Code Scanning Upload API Rate Limit reset? {apiRateLimits.CodeScanningUpload.RateLimitReset_DateTime}");

            Console.WriteLine("");
        }

        static async Task<(TimeSpan RateLimitTimeRemaining, int RateLimit, int RemainingRequestCount, bool IsAuthenticated, bool HasReachedMaximumApiLimit)> GetRestApiRateLimitDataFromHeaders()
        {
            HttpResponseMessage restApiResponse = await _client.GetAsync($"{GitHubConstants.GitHubRestApiUrl}/repos/brminnick/GitHubApiStatus");
            restApiResponse.EnsureSuccessStatusCode();

            TimeSpan rateLimitTimeRemaining = GitHubApiStatusService.Instance.GetRateLimitTimeRemaining(restApiResponse.Headers);

            int rateLimit = GitHubApiStatusService.Instance.GetRateLimit(restApiResponse.Headers);
            int remainingRequestCount = GitHubApiStatusService.Instance.GetRemainingRequestCount(restApiResponse.Headers);

            bool isAuthenticated = GitHubApiStatusService.Instance.IsAuthenticated(restApiResponse.Headers);

            bool hasReachedMaximumApiLimit = GitHubApiStatusService.Instance.HasReachedMaximimApiCallLimit(restApiResponse.Headers);

            return (rateLimitTimeRemaining, rateLimit, remainingRequestCount, isAuthenticated, hasReachedMaximumApiLimit);
        }

        static Task<GitHubApiRateLimits> GetApiRateLimits()
        {
            if (string.IsNullOrWhiteSpace(GitHubConstants.PersonalAccessToken))
                throw new ArgumentException("GitHubConstants.PersonalAccessToken Cannot be Empty");

            return GitHubApiStatusService.Instance.GetApiRateLimits(new AuthenticationHeaderValue("bearer", GitHubConstants.PersonalAccessToken));
        }
    }
}
