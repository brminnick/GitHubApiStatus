using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GitHubApiStatus.Extensions;
using GitStatus.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GitStatus.API;

class Program
{
	static Task Main(string[] args)
	{
		var host = new HostBuilder()
			.ConfigureAppConfiguration(configurationBuilder => configurationBuilder.AddCommandLine(args))
			.ConfigureFunctionsWorkerDefaults()
			.ConfigureServices(services =>
			{
				services.AddGitHubApiStatusService(new AuthenticationHeaderValue(GitHubConstants.AuthScheme, GitHubConstants.PersonalAccessToken), new ProductHeaderValue(nameof(GitStatus)))
					.ConfigurePrimaryHttpMessageHandler(config => new HttpClientHandler { AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate });
			})
			.Build();

		return host.RunAsync();
	}
}