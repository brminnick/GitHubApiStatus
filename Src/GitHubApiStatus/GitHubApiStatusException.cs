using System;
namespace GitHubApiStatus
{
    /// <summary>
    /// Exception thrown by GitHubApiStatus
    /// </summary>
    public sealed class GitHubApiStatusException : Exception
    {
        /// <summary>
        /// Initialize GitHubApiStatusException
        /// </summary>
        /// <param name="message"></param>
        internal GitHubApiStatusException(string message) : base(message)
        {
        }
    }
}
