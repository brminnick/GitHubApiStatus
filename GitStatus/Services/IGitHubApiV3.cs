using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace GitStatus
{
    [Headers("User-Agent: " + nameof(GitStatus), "Accept-Encoding: gzip", "Accept: application/json")]
    interface IGitHubApiV3
    {
        [Get("/repos/xamarin/xamarin.forms")]
        Task<HttpResponseMessage> GetGitHubApiResponse();

        [Get("/repos/xamarin/xamarin.forms")]
        Task<HttpResponseMessage> GetGitHubApiResponse([Header("Authorization")] string authorization);
    }
}
