using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Polly;
using Refit;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GitStatus
{
    class GitHubStatusService
    {
        readonly static Lazy<IGitHubApiV3> _gitHubClientHolder = new Lazy<IGitHubApiV3>(() => RestService.For<IGitHubApiV3>(new HttpClient { BaseAddress = new Uri(GitHubConstants.GitHubApiUrl) }));

        static int _networkIndicatorCount;

        static IGitHubApiV3 GitHubClient => _gitHubClientHolder.Value;

        public async Task<GitHubApiStatus> GetGitHubApiStatus(string authorizationToken, CancellationToken cancellationToken)
        {
            try
            {
                var response = await AttemptAndRetry(() => GitHubClient.GetGitHubApiResponse("bearer " + authorizationToken), cancellationToken).ConfigureAwait(false);
                return new GitHubApiStatus(response.Headers);
            }
            catch (ApiException e)
            {
                return new GitHubApiStatus(e);
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
