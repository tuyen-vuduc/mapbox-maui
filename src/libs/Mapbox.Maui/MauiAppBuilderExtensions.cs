namespace MapboxMaui;

#if IOS 
using PlatformView = MapboxMaps.MapView;
#elif __ANDROID__
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !__ANDROID__)
using PlatformView = System.Object;
#endif

using System.Globalization;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder UseMapbox(
        this MauiAppBuilder builder,
        string accessToken = default)
    {
        MapboxViewHandler.ACCESS_TOKEN = accessToken;

        builder.ConfigureMauiHandlers(collection =>
        {
            collection.AddHandler(
                typeof(MapboxView),
                typeof(MapboxViewHandler)
            );
        });

        return builder;
    }
}

public static class ColorExtensions
{
    public static string ToRgbaString(this Color value)
    {
        return $"rgba({
            (value.Red * 255).ToString(CultureInfo.InvariantCulture)
        }, {
            (value.Green * 255).ToString(CultureInfo.InvariantCulture)
        }, {
            (value.Blue * 255).ToString(CultureInfo.InvariantCulture)
        }, {
            value.Alpha.ToString(CultureInfo.InvariantCulture)
        })";

    }
}