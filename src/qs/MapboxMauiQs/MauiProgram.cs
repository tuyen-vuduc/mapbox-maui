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

		AddPages(builder);
        AddExampleInfos(builder);

        return builder.Build();
	}

    private static void AddExampleInfos(MauiAppBuilder builder)
    {
        var exampleTypes = typeof(MainPage).Assembly.GetTypes()
            .Where(x =>
                !x.IsAbstract &&
                x.IsAssignableTo(typeof(IExampleInfo)))
            .ToList();

        foreach (var exampleType in exampleTypes)
        {
			builder.Services.AddTransient(typeof(IExampleInfo), exampleType);
        }
    }

    private static void AddPages(MauiAppBuilder builder)
    {
		var contentPageType = typeof(MainPage).Assembly.GetTypes()
			.Where(x =>
				!x.IsAbstract &&
				x.IsAssignableTo(typeof(ContentPage)))
			.ToList();

		foreach (var examplePageType in contentPageType)
        {
            builder.Services.AddTransient(examplePageType);
			
			if (examplePageType.IsAssignableTo(typeof(IExamplePage)))
			{
                Routing.RegisterRoute(examplePageType.Name, examplePageType);
            }
		}
    }
}

