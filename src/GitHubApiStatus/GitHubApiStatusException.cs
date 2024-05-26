namespace GitHubApiStatus;

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

	/// <summary>
	/// Initialize GitHubApiStatusException
	/// </summary>
	/// <param name="message"></param>
	/// <param name="innerException"></param>
	internal GitHubApiStatusException(string message, Exception innerException) : base(message, innerException)
	{
	}
}