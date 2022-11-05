using System.Net.Http.Headers;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using GitHubApiStatus.Extensions;
using GitStatus.Shared;

namespace GitStatus;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder()
								.UseMauiApp<App>()
								.UseMauiCommunityToolkit()
								.UseMauiCommunityToolkitMarkup()
								.ConfigureFonts(fonts =>
								{
									fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
									fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
								});

		// Add Pages + ViewModels
		builder.Services.AddTransient<AppShell>();
		builder.Services.AddTransientWithShellRoute<GraphQLApiStatusPage, GraphQLApiStatusViewModel>();
		builder.Services.AddTransientWithShellRoute<RestApiStatusPage, RestApiStatusViewModel>();

		// Add Services
		builder.Services.AddGitHubApiStatusService(new AuthenticationHeaderValue(GitHubConstants.AuthScheme, GitHubConstants.PersonalAccessToken), new ProductHeaderValue(nameof(GitStatus)));

		return builder.Build();
	}

	static IServiceCollection AddTransientWithShellRoute<TPage, TViewModel>(this IServiceCollection services)
		where TPage : BaseContentPage<TViewModel>
		where TViewModel : BaseViewModel
	{
		return services.AddTransientWithShellRoute<TPage, TViewModel>($"//{typeof(TPage).Name}");
	}
}