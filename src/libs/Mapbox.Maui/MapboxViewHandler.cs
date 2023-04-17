namespace Mapbox.Maui;

using Microsoft.Maui.Handlers;

#if IOS 
using PlatformView = Mapbox.Maui.MapViewContainer;
#elif __ANDROID__
using PlatformView = AndroidX.Fragment.App.FragmentContainerView;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !__ANDROID__)
using PlatformView = System.Object;
#endif

public partial class MapboxViewHandler : ViewHandler<IMapboxView, PlatformView>
{
    internal static string ACCESS_TOKEN;

    public static IPropertyMapper<IMapboxView, MapboxViewHandler> PropertyMapper
        = new PropertyMapper<IMapboxView, MapboxViewHandler>(ViewHandler.ViewMapper)
        {
            [nameof(MapboxView.CameraOptions)] = HandleCameraOptionsChanged,
            [nameof(MapboxView.MapboxStyle)] = HandleMapboxStyleChanged,
            [nameof(MapboxView.ScaleBarVisibility)] = HandleScaleBarVisibilityChanged,
            [nameof(MapboxView.DebugOptions)] = HandleDebugOptionsChanged,
            [nameof(MapboxView.Sources)] = HandleSourcesChanged,
            [nameof(MapboxView.Terrain)] = HandleTerrainChanged,
            [nameof(MapboxView.Layers)] = HandleLayersChanged,
            [nameof(MapboxView.Light)] = HandleLightChanged,
            [nameof(MapboxView.Annotations)] = HandleAnnotationsChanged,
        };

    public MapboxViewHandler() : base(PropertyMapper)
    {

    }
}
