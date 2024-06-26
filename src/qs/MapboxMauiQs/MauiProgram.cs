using Microsoft.Extensions.Logging;
using MapboxMaui;

namespace MapboxMauiQs;

public static partial class MauiProgram
{
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
                Routing.RegisterRoute(examplePageType.FullName, examplePageType);
            }
		}
    }
}

