namespace MapboxMaui;

using Microsoft.Maui.Handlers;

#if __IOS__ 
using PlatformView = MapboxMaui.MapViewContainer;
#elif __ANDROID__
using PlatformView = AndroidX.Fragment.App.FragmentContainerView;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !__ANDROID__)
using PlatformView = System.Object;
#endif

public partial class MapboxViewHandler : ViewHandler<IMapboxView, PlatformView>
{
    internal static string ACCESS_TOKEN;

    public static IPropertyMapper<IMapboxView, MapboxViewHandler> Mapper
        = new PropertyMapper<IMapboxView, MapboxViewHandler>(ViewHandler.ViewMapper)
        {
            [nameof(MapboxView.CameraOptions)] = HandleCameraOptionsChanged,
            [nameof(MapboxView.GestureSettings)] = HandleGestureSettingsChanged,
            [nameof(MapboxView.MapboxStyle)] = HandleMapboxStyleChanged,
            [nameof(MapboxView.ScaleBarVisibility)] = HandleScaleBarVisibilityChanged,
            [nameof(MapboxView.DebugOptions)] = HandleDebugOptionsChanged,
            [nameof(MapboxView.Sources)] = HandleSourcesChanged,
            [nameof(MapboxView.Layers)] = HandleLayersChanged,
            [nameof(MapboxView.Images)] = HandleImagesChanged,
            [nameof(MapboxView.Terrain)] = HandleTerrainChanged,
            [nameof(MapboxView.Light)] = HandleLightChanged
        };
    public static CommandMapper<IMapboxView, MapboxViewHandler> CommandMapper
        = new (ViewHandler.ViewCommandMapper)
        {
        };

    public MapboxViewHandler() : base(Mapper, CommandMapper)
    {
        
    }

#if __ANDROID__
#elif __IOS__
#else
    protected override  PlatformView CreatePlatformView()
    {
        return new PlatformView();
    }
    private static void HandleGestureSettingsChanged(MapboxViewHandler handler, IMapboxView view)
    {
        throw new NotImplementedException();
    }

    private static void HandleLightChanged(MapboxViewHandler handler, IMapboxView view)
    {
        throw new NotImplementedException();
    }

    private static void HandleImagesChanged(MapboxViewHandler handler, IMapboxView view)
    {
        throw new NotImplementedException();
    }

    private static void HandleLayersChanged(MapboxViewHandler handler, IMapboxView view)
    {
        throw new NotImplementedException();
    }

    private static void HandleTerrainChanged(MapboxViewHandler handler, IMapboxView view)
    {
        throw new NotImplementedException();
    }

    private static void HandleSourcesChanged(MapboxViewHandler handler, IMapboxView view)
    {
        throw new NotImplementedException();
    }

    private static void HandleCameraOptionsChanged(MapboxViewHandler handler, IMapboxView view)
    {
        throw new NotImplementedException();
    }

    private static void HandleDebugOptionsChanged(MapboxViewHandler handler, IMapboxView view)
    {
        throw new NotImplementedException();
    }

    private static void HandleScaleBarVisibilityChanged(MapboxViewHandler handler, IMapboxView view)
    {
        throw new NotImplementedException();
    }

    private static void HandleMapboxStyleChanged(MapboxViewHandler handler, IMapboxView view)
    {
        throw new NotImplementedException();
    }
#endif
}
