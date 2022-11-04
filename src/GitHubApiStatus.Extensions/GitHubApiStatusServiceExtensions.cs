using System;
using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;

namespace GitHubApiStatus.Extensions;

/// <summary>
/// Extension Methods for GitHubApiStatusService
/// </summary>
public static class GitHubApiStatusServiceExtensions
{
	/// <summary>
	/// Adds IGitHubApiStatusService to IServiceCollection
	/// </summary>
	/// <param name="services">Microsoft.Extensions.DependencyInjection.IServiceCollection</param>
	/// <param name="authenticationHeaderValue">GitHub API Personal Access Token</param>
	/// <param name="productHeaderValue">UserAgent</param>
	/// <returns>IHttpClientBuilder</returns>
	public static IHttpClientBuilder AddGitHubApiStatusService(this IServiceCollection services, AuthenticationHeaderValue authenticationHeaderValue, ProductHeaderValue productHeaderValue) =>
		services.AddGitHubApiStatusService<GitHubApiStatusService>(authenticationHeaderValue, productHeaderValue);

	/// <summary>
	/// Adds IGitHubApiStatusService to IServiceCollection using custom implementation of IGitHubApiStatusService
	/// </summary>
	/// <typeparam name="TGitHubApiStatusService">Implementation of IGitHubApiStatusService</typeparam>
	/// <param name="services">Microsoft.Extensions.DependencyInjection.IServiceCollection</param>
	/// <param name="authenticationHeaderValue">GitHub API Personal Access Token</param>
	/// <param name="productHeaderValue">UserAgent</param>
	/// <returns>IHttpClientBuilder</returns>
	public static IHttpClientBuilder AddGitHubApiStatusService<TGitHubApiStatusService>(this IServiceCollection services, AuthenticationHeaderValue authenticationHeaderValue, ProductHeaderValue productHeaderValue) where TGitHubApiStatusService : class, IGitHubApiStatusService
	{
		if (productHeaderValue is null)
			throw new ArgumentNullException(nameof(productHeaderValue));

		if (string.IsNullOrWhiteSpace(productHeaderValue?.Name))
			throw new ArgumentException($"{nameof(ProductHeaderValue)}.{nameof(ProductHeaderValue.Name)} cannot be null or whitespace", nameof(productHeaderValue));

		if (authenticationHeaderValue is null)
			throw new ArgumentNullException(nameof(authenticationHeaderValue));

		if (!authenticationHeaderValue.Scheme.Equals("bearer", StringComparison.OrdinalIgnoreCase))
			throw new ArgumentException($"{nameof(AuthenticationHeaderValue)}.{nameof(AuthenticationHeaderValue.Scheme)} must be `bearer`", nameof(authenticationHeaderValue));

		if (string.IsNullOrWhiteSpace(authenticationHeaderValue.Parameter))
			throw new ArgumentException($"{nameof(AuthenticationHeaderValue)}.{nameof(AuthenticationHeaderValue.Parameter)} cannot be blank", nameof(authenticationHeaderValue));

		return services.AddHttpClient<IGitHubApiStatusService, TGitHubApiStatusService>(client =>
		{
			client.DefaultRequestHeaders.Authorization = authenticationHeaderValue;
			client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(productHeaderValue));
		});
	}
}