
namespace Mapbox.Maui;

using System;
using Foundation;
using MapboxMaps;
using MapboxMapsObjC;
using Microsoft.Maui.Handlers;
using PlatformView = MapViewContainer;

public partial class MapboxViewHandler
{
    private static void HandleRasterDemSourceBuilderChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.PlatformView.MapView;
        if (mapView == null) return;

        var rasterDemSourceBuilder = view.RasterDemSourceBuilder;
        if (rasterDemSourceBuilder == null) return;

        var platformValue = rasterDemSourceBuilder.ToPlatformValue();

        mapView.AddSource(rasterDemSourceBuilder.Id, platformValue);
    }

    private static void HandleCameraOptionsChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.PlatformView.MapView;
        if (mapView == null) return;

        var cameraOptions = view.CameraOptions.ToNative();
        if (cameraOptions == null) return;

        mapView.SetCameraTo(cameraOptions);
    }

    private static void HandleDebugOptionsChanged(MapboxViewHandler handler, IMapboxView view)
    {
        if (view.DebugOptions == null) return;

        var mapView = handler.PlatformView.MapView;
        if (mapView == null) return;

        var debugOptions = view.DebugOptions.ToNative();

        mapView.MapboxMapDebugOptions(
            debugOptions
                .Select(x => NSNumber.FromInt32((int)x))
                .ToArray()
        );
    }

    private static void HandleScaleBarVisibilityChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.PlatformView.MapView;
        if (mapView == null) return;

        mapView.OrnamentsOptionsScaleBarVisibility(view.ScaleBarVisibility.ToNative());
    }

    private static void HandleMapboxStyleChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.PlatformView.MapView;
        if (mapView == null) return;

        var styleUri = view.MapboxStyle.ToNative();
        if (string.IsNullOrWhiteSpace(styleUri)) return;

        mapView.SetStyle(styleUri);
    }

    protected override PlatformView CreatePlatformView()
    {
        var accessToken = string.IsNullOrWhiteSpace(ACCESS_TOKEN)
            ? MapInitOptionsBuilder.DefaultResourceOptions.AccessToken
            : ACCESS_TOKEN;

        return new PlatformView(accessToken);
    }

    protected override void ConnectHandler(PlatformView platformView)
    {
        base.ConnectHandler(platformView);

        (VirtualView as MapboxView)?.InvokeMapReady();
    }
}