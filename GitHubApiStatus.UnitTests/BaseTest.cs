using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GitHubApiStatus.UnitTests
{
    abstract class BaseTest
    {
        protected GitHubApiStatusService GitHubApiStatus { get; } = GitHubApiStatusService.Instance;

        protected HttpResponseHeaders CreateHttpResponseHeaders(in int rateLimit, in DateTimeOffset rateLimitResetTime, in int remainingRequestCount, in HttpStatusCode httpStatusCode = HttpStatusCode.OK, in bool isAuthenticated = true)
        {
            if (remainingRequestCount > rateLimit)
                throw new ArgumentOutOfRangeException(nameof(remainingRequestCount), $"{nameof(remainingRequestCount)} must be less than or equal to {nameof(rateLimit)}");

            var httpResponse = new HttpResponseMessage(httpStatusCode)
            {
                Headers =
                {
                    { GitHubApiStatusService.RateLimitHeader, rateLimit.ToString() },
                    { GitHubApiStatusService.RateLimitResetHeader,  GetTimeInUnixEpochSeconds(rateLimitResetTime).ToString() },
                    { GitHubApiStatusService.RateLimitRemainingHeader, remainingRequestCount.ToString() }
                }
            };

            if (isAuthenticated)
                httpResponse.Headers.Vary.Add("Authorization");

            return httpResponse.Headers;
        }


        static long GetTimeInUnixEpochSeconds(in DateTimeOffset dateTimeOffset) => dateTimeOffset.ToUnixTimeSeconds();
    }
}