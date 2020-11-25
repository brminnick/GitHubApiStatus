using System.Net.Http;
using System.Net.Http.Headers;

namespace GitHubApiStatus
{
    public class GitHubApiClient : HttpClient
    {
        public GitHubApiClient(AuthenticationHeaderValue authenticationHeaderValue, ProductHeaderValue productHeaderValue)
        {
            GitHubApiStatusService.ValidateAuthenticationHeaderValue(authenticationHeaderValue);
            GitHubApiStatusService.ValidateProductHeaderValue(productHeaderValue);

            DefaultRequestHeaders.Authorization = authenticationHeaderValue;
            DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(productHeaderValue));
        }

        internal GitHubApiClient()
        {

        }
    }
}
