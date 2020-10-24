using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using GraphQL;
using Polly;
using Refit;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GitStatus
{
    class GitHubStatusService
    {
        readonly static Lazy<IGitHubApiV3> _gitHubRestApiClientHolder = new Lazy<IGitHubApiV3>(() => RestService.For<IGitHubApiV3>(new HttpClient { BaseAddress = new Uri(GitHubConstants.GitHubRestApiUrl) }));
        readonly static Lazy<IGitHubGraphQLApi> _gitHubGraphQLClientHolder = new Lazy<IGitHubGraphQLApi>(() => RestService.For<IGitHubGraphQLApi>(new HttpClient { BaseAddress = new Uri(GitHubConstants.GitHubGraphQLApiUrl) }));

        static int _networkIndicatorCount;

        static IGitHubApiV3 GitHubRestApiClient => _gitHubRestApiClientHolder.Value;
        static IGitHubGraphQLApi GitHubGraphQlApiClient => _gitHubGraphQLClientHolder.Value;

        public async Task<GitHubApiStatus> GetGitHubApiStatus(string authorizationToken, CancellationToken cancellationToken)
        {
            try
            {
                var restApiResponse = await AttemptAndRetry(() => GitHubRestApiClient.GetGitHubApiResponse("bearer " + authorizationToken), cancellationToken).ConfigureAwait(false);
                var graphQLApiResponse = await ExecuteGraphQLRequest(() => GitHubGraphQlApiClient.ViewerLoginQuery(new ViewerLoginQueryContent(), "bearer " + authorizationToken), cancellationToken).ConfigureAwait(false);

                var restApiStatus = new GitHubApiStatus(restApiResponse);
                var graphQLApiStatus = new GitHubApiStatus(graphQLApiResponse.Headers);

                return restApiStatus.RemainingRequests < graphQLApiStatus.RemainingRequests ? restApiStatus : graphQLApiStatus;
            }
            catch (ApiException e)
            {
                return new GitHubApiStatus(e);
            }
            catch (GraphQLException e)
            {
                return new GitHubApiStatus(e.ResponseHeaders);
            }
        }

        static async Task<T> AttemptAndRetry<T>(Func<Task<T>> action, CancellationToken cancellationToken, int numRetries = 3)
        {
            await UpdateActivityIndicatorStatus(true).ConfigureAwait(false);

            try
            {
                return await Policy.Handle<Exception>().WaitAndRetryAsync(numRetries, retryAttempt).ExecuteAsync(token => action(), cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                await UpdateActivityIndicatorStatus(false).ConfigureAwait(false);
            }

            static TimeSpan retryAttempt(int attemptNumber) => TimeSpan.FromSeconds(Math.Pow(2, attemptNumber));
        }

        async Task<ApiResponse<GraphQLResponse<T>>> ExecuteGraphQLRequest<T>(Func<Task<ApiResponse<GraphQLResponse<T>>>> action, CancellationToken cancellationToken)
        {
            var response = await AttemptAndRetry(action, cancellationToken).ConfigureAwait(false);

            await response.EnsureSuccessStatusCodeAsync().ConfigureAwait(false);

            if (response.Content.Errors != null)
                throw new GraphQLException(response.Content.Errors, response.Headers, response.StatusCode);

            return response;
        }

        static async ValueTask UpdateActivityIndicatorStatus(bool isActivityIndicatorDisplayed)
        {
            if (isActivityIndicatorDisplayed)
            {
                _networkIndicatorCount++;

                await MainThread.InvokeOnMainThreadAsync(() => setIsBusy(true)).ConfigureAwait(false);
            }
            else if (--_networkIndicatorCount <= 0)
            {
                _networkIndicatorCount = 0;

                await MainThread.InvokeOnMainThreadAsync(() => setIsBusy(false)).ConfigureAwait(false);
            }

            static void setIsBusy(bool isBusy)
            {
                if (Application.Current?.MainPage != null)
                    Application.Current.MainPage.IsBusy = isBusy;
            }
        }
    }
}
