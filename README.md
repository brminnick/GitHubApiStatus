# GitHubApiStatus

[![NuGet](https://buildstats.info/nuget/GitHubApiStatus?includePreReleases=true)](https://www.nuget.org/packages/GitHubApiStatus/) 

![Unit Tests](https://github.com/brminnick/GitHubApiStatus/workflows/Run%20Unit%20Tests/badge.svg)

A .NET library to help understand the GitHub API Rate Limit.

Ever sent a request to the GitHub API, only to have it rejected? GitHubApiStatusService helps make it easy to understand GitHub's API Rate Limit!

- [Jump to the Setup](#Setup)
- [Jump to the API](#API)
- [Jump to Examples](#Examples)

### GitHub API Rate Limits

#### REST API

[![GitHub RST API Limits](https://user-images.githubusercontent.com/13558917/97235854-066e5680-17a1-11eb-98f9-01fae7c02ac0.png)](https://docs.github.com/en/free-pro-team@latest/rest/overview/resources-in-the-rest-api#rate-limiting)

Learn More: https://docs.github.com/en/free-pro-team@latest/rest/overview/resources-in-the-rest-api#rate-limiting

#### GraphQL API

[![GitHub GraphQL API Limits](https://user-images.githubusercontent.com/13558917/97235806-ec347880-17a0-11eb-9637-fc1eb7f8dbc8.png)](https://docs.github.com/en/free-pro-team@latest/graphql/overview/resource-limitations#rate-limit)

Learn More: https://docs.github.com/en/free-pro-team@latest/graphql/overview/resource-limitations#rate-limit

### Rate Limit Headers

![Rate Limit Headers](https://user-images.githubusercontent.com/13558917/97235863-0e2dfb00-17a1-11eb-98f8-23c1065eb043.png)

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


