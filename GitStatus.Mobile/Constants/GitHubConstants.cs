using System;
namespace GitStatus.Mobile
{
    static class GitHubConstants
    {
#error Missing Token, Follow these steps to create your Personal Access Token: https://help.github.com/articles/creating-a-personal-access-token-for-the-command-line/#creating-a-token
        public const string PersonalAccessToken = "";
        public const string GitHubRestApiUrl = "https://api.github.com";
        public const string GitHubGraphQLApiUrl = "https://api.github.com/graphql";
    }
}
