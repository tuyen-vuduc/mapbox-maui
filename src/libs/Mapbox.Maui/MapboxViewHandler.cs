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
            [nameof(MapboxView.MapCenter)] = HandleCameraOptionsChanged,
            [nameof(MapboxView.MapZoom)] = HandleCameraOptionsChanged,
            [nameof(MapboxView.MapboxStyle)] = HandleMapboxStyleChanged,
        };

    public MapboxViewHandler() : base(PropertyMapper)
    {

    }
}
