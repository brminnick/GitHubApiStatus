using System.Threading.Tasks;
using GraphQL;
using Refit;

namespace GitStatus.Mobile
{
    [Headers("User-Agent: " + nameof(GitStatus))]
    interface IGitHubGraphQLApi
    {
        [Post("")]
        Task<ApiResponse<GraphQLResponse<GitHubViewerResponse>>> ViewerLoginQuery([Body] ViewerLoginQueryContent request, [Header("Authorization")] string authorization);
    }

    class ViewerLoginQueryContent : GraphQLRequest
    {
        public ViewerLoginQueryContent() : base("query { viewer{ login, name, avatarUrl }}")
        {

        }
    }
}
