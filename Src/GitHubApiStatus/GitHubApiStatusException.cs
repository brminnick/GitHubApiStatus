using System;
namespace GitHubApiStatus
{
    public class GitHubApiStatusException : Exception
    {
        public GitHubApiStatusException(string message) : base(message)
        {
        }
    }
}
