using System.Net.Http.Headers;
using GitHubApiStatus.Extensions;
using GitStatus.Common;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace GitStatus.Web;

public class Program
{
	public static Task Main(string[] args)
	{
		var builder = WebAssemblyHostBuilder.CreateDefault(args);
		builder.RootComponents.Add<App>("#app");
		builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

		builder.Services.AddGitHubApiStatusService(new AuthenticationHeaderValue(GitHubConstants.AuthScheme, GitHubConstants.PersonalAccessToken), new ProductHeaderValue(nameof(GitStatus)));

		return builder.Build().RunAsync();
	}
}