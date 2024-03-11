namespace MapboxMaui;

using Microsoft.Maui.Handlers;

#if IOS
using PlatformView = MapboxMaui.MapViewContainer;
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
            [nameof(MapboxView.Layers)] = HandleLayersChanged,
            [nameof(MapboxView.Images)] = HandleImagesChanged,
            [nameof(MapboxView.Terrain)] = HandleTerrainChanged,
            [nameof(MapboxView.Light)] = HandleLightChanged
        };

    public MapboxViewHandler() : base(PropertyMapper)
    {

    }
}

#if !__ANDROID__ && !IOS
public partial class MapboxViewHandler
{
    protected override PlatformView CreatePlatformView() => throw new NotSupportedException();

    private static void HandleCameraOptionsChanged(MapboxViewHandler arg1, IMapboxView arg2) => throw new NotSupportedException();

    private static void HandleMapboxStyleChanged(MapboxViewHandler arg1, IMapboxView arg2) => throw new NotSupportedException();

    private static void HandleScaleBarVisibilityChanged(MapboxViewHandler arg1, IMapboxView arg2) => throw new NotSupportedException();

    private static void HandleDebugOptionsChanged(MapboxViewHandler arg1, IMapboxView arg2) => throw new NotSupportedException();

    private static void HandleSourcesChanged(MapboxViewHandler arg1, IMapboxView arg2) => throw new NotSupportedException();

    private static void HandleLayersChanged(MapboxViewHandler arg1, IMapboxView arg2) => throw new NotSupportedException();

    private static void HandleImagesChanged(MapboxViewHandler arg1, IMapboxView arg2) => throw new NotSupportedException();

    private static void HandleTerrainChanged(MapboxViewHandler arg1, IMapboxView arg2) => throw new NotSupportedException();

    private static void HandleLightChanged(MapboxViewHandler arg1, IMapboxView arg2) => throw new NotSupportedException();
}
#endif