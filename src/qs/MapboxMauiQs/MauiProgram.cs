using Microsoft.Extensions.Logging;
using Mapbox.Maui;

namespace MapboxMauiQs;

public static class MauiProgram
{
	private const string ACCESS_TOKEN = "pk.eyJ1IjoidHV5ZW52IiwiYSI6ImNsMnpzNzh4NjBnNG0zZHBzYTFmYmxhOWUifQ.Az2oICdp9k0Hb5tu_M8b-g";

    public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMapbox(ACCESS_TOKEN)
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

