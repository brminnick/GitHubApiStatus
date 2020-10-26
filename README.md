# GitHubApiStatus

[![NuGet](https://buildstats.info/nuget/GitHubApiStatus?includePreReleases=true)](https://www.nuget.org/packages/GitHubApiStatus/) 

![Unit Tests](https://github.com/brminnick/GitHubApiStatus/workflows/Run%20Unit%20Tests/badge.svg)

A .NET library to help understand the GitHub API Rate Limit.

Ever sent a request to the GitHub API, only to have it rejected? GitHubApiStatusService helps make it easy to understand GitHub's API Rate Limit!

- Available on NuGet: https://www.nuget.org/packages/GitHubApiStatus
- [Jump to the Setup](#Setup)
- [Jump to the API](#API)
- [Jump to Examples](#Examples)

### GitHub API Rate Limits


## Setup

- Available on NuGet: https://www.nuget.org/packages/GitHubApiStatus/ 
- Add to any project supporting .NET Standard 1.3

## API

- `public int GetRateLimit(HttpResponseHeaders httpResponseHeaders)`
  - Get the total number of GitHub API Requests available
  - Parses the `X-RateLimit-Limit` header and return its `int` value
  
- `public int GetRemainingRequestCount(HttpResponseHeaders httpResponseHeaders)`
  - Get the number of GitHub API Requests remaining
  - Parses the `X-RateLimit-Remaining` header and return its `int` value
  
- `public bool HasReachedMaximimApiCallLimit(HttpResponseHeaders httpResponseHeaders)`
  - Determines whether the maximum number of requests 
  - Parses the `X-RateLimit-Remaining` header and returns wether or not it is greater than 0
  
- `public TimeSpan GetRateLimitTimeRemaining(HttpResponseHeaders httpResponseHeaders)`
  - Get the time remaining until GitHub API rate limit resets
  - Parses the `X-RateLimit-Reset` header and returns the `TimeSpan` value from the current time
  
- `public bool IsAuthenticated(HttpResponseHeaders httpResponseHeaders)`
  - Determine whether the request was made using an authenticated bearer token
  - Determines whether or not the `Authorization` key exists in the `Vary` header 

- `public DateTimeOffset GetRateLimitResetDateTime(HttpResponseHeaders httpResponseHeaders)`
  - Get the Date Time when the GitHub API rate limit resets
  - Parses the `X-RateLimit-Reset` header and returns its `DateTimeOffset` value
  
- `public long GetRateLimitResetDateTime_UnixEpochSeconds(HttpResponseHeaders httpResponseHeaders)`
  - Get the Date Time when the GitHub API rate limit resets
  - Parses the `X-RateLimit-Reset` header and returns its `long` value in [Unix Epoch Seconds](https://www.epochconverter.com)
  
  ## Examples
