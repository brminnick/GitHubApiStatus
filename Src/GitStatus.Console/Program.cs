using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using GitHubApiStatus;
using GitStatus.Shared;

namespace GitStatus.Console
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
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", GitHubConstants.PersonalAccessToken);

            HttpResponseMessage restApiResponse = await _client.GetAsync($"{GitHubConstants.GitHubRestApiUrl}/repos/brminnick/GitHubApiStatus");
            restApiResponse.EnsureSuccessStatusCode();

            TimeSpan rateLimitTimeRemaining = GitHubApiStatusService.Instance.GetRateLimitTimeRemaining(restApiResponse.Headers);

            int rateLimit = GitHubApiStatusService.Instance.GetRateLimit(restApiResponse.Headers);
            int remainingRequestCount = GitHubApiStatusService.Instance.GetRemainingRequestCount(restApiResponse.Headers);

            bool isAuthenticated = GitHubApiStatusService.Instance.IsAuthenticated(restApiResponse.Headers);

            bool hasReachedMaximumApiLimit = GitHubApiStatusService.Instance.HasReachedMaximimApiCallLimit(restApiResponse.Headers);

            Debug.WriteLine($"What is the GitHub API Rate Limit? {rateLimit}");

            Debug.WriteLine($"Have I reached the Maximum API Limit? {hasReachedMaximumApiLimit}");
            Debug.WriteLine($"How many API requests do I have remaining? {remainingRequestCount}");

            Debug.WriteLine($"How long until the GitHub API Rate Limit resets? {rateLimitTimeRemaining}");

            Debug.WriteLine($"Did GitHub API Request include a Bearer Token? {isAuthenticated}");
        }
    }
}
