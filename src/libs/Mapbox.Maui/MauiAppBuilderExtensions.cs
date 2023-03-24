#if IOS 
using PlatformView = MapboxMaps.MapView;
#elif __ANDROID__
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !__ANDROID__)
using PlatformView = System.Object;
#endif

namespace Mapbox.Maui;

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
