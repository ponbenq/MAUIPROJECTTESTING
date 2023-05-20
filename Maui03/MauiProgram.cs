using Microsoft.Extensions.Logging;
using Maui03.ViewModels;
using Maui03.Views;

namespace Maui03;

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

#if DEBUG
		builder.Logging.AddDebug();

		builder.Services.AddSingleton<ProductPage>();
		builder.Services.AddTransient<DetailsPageViewModel>();
		builder.Services.AddTransient<PurchasePageViewModel>();

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<DetailsPage>();
		builder.Services.AddTransient<PurchasePage>();
#endif

		return builder.Build();
	}
}

