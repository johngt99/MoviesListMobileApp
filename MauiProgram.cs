using Microsoft.Extensions.Logging;
using MobileAppDevelopment.Services;
using MobileAppDevelopment.ViewModels;
using MobileAppDevelopment.Views;

namespace MobileAppDevelopment;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});


        builder.Services.AddSingleton<LoginPage>();

        builder.Services.AddSingleton<MovieService>();
		builder.Services.AddSingleton<MoviesViewModel>();
        builder.Services.AddSingleton<LoginPageViewModel>();
		builder.Services.AddTransient<MovieDetailsViewModel>();

        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddTransient<DetailsPage>();
        builder.Services.AddSingleton<ListPage>();
        builder.Services.AddSingleton<ContactPage>();
        builder.Services.AddSingleton<AboutPage>();

        

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
