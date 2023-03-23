using Microsoft.Maui.Handlers;

#if IOS 
using PlatformView = MapboxMaps.MapView;
#elif __ANDROID__
using PlatformView = Com.Mapbox.Maps.MapView;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !__ANDROID__)
using PlatformView = System.Object;
#endif

namespace Mapbox.Maui;

public partial class MapboxViewHandler : ViewHandler<IMapboxView, PlatformView>
{
    public static IPropertyMapper<IMapboxView, MapboxViewHandler> PropertyMapper
        = new PropertyMapper<IMapboxView, MapboxViewHandler>(ViewHandler.ViewMapper)
        {
            [nameof(MapboxView.Center)] = HandleCenterChanged,
            [nameof(MapboxView.MapboxStyle)] = HandleMapboxStyleChanged,
        };

    public MapboxViewHandler() : base(PropertyMapper)
    {

    }
}

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder UseMapbox(this MauiAppBuilder builder)
    {
        builder.ConfigureMauiHandlers(collection =>
        {
            collection.AddHandler(typeof(MapboxView), typeof(MapboxViewHandler));
        });

        return builder;
    }
}
