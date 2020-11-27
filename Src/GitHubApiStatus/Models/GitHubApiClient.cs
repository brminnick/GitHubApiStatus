using System.Net.Http;
using System.Net.Http.Headers;

namespace GitHubApiStatus
{
    /// <summary>
    /// HttpClient for GitHub's API
    /// </summary>
    public class GitHubApiClient : HttpClient
    {
        /// <summary>
        /// Initialize GitHubApiClient
        /// </summary>
        /// <param name="authenticationHeaderValue">GitHub Personal Access Token, aka Bearer Token</param>
        /// <param name="productHeaderValue">User Agent</param>
        public GitHubApiClient(AuthenticationHeaderValue authenticationHeaderValue, ProductHeaderValue productHeaderValue)
        {
            GitHubApiStatusService.ValidateAuthenticationHeaderValue(authenticationHeaderValue);
            GitHubApiStatusService.ValidateProductHeaderValue(productHeaderValue);

            DefaultRequestHeaders.Authorization = authenticationHeaderValue;
            DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(productHeaderValue));
        }

        protected internal GitHubApiClient()
        {

        }
    }
}
