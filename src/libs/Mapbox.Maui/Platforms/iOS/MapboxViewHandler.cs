
namespace Mapbox.Maui;

using System;
using CoreLocation;
using Foundation;
using MapboxCoreMaps;
using MapboxMaps;
using MapboxMapsObjC;
using Microsoft.Maui.Handlers;
using PlatformView = MapViewContainer;

public partial class MapboxViewHandler
{
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

public static class AdditionalExtensions
{
    public static TMBOrnamentVisibility ToNative(this OrnamentVisibility value)
    {
        return value switch
        {
            OrnamentVisibility.Adaptive => TMBOrnamentVisibility.Adaptive,
            OrnamentVisibility.Visible => TMBOrnamentVisibility.Visible,
            _ => TMBOrnamentVisibility.Hidden,
        };
    }

    public static string ToNative(this MapboxStyle mapboxStyle)
    {
        return mapboxStyle.BuiltInStyle switch
        {
            MapboxBuiltInStyle.Dark => BuiltInStyles.Dark,
            MapboxBuiltInStyle.Light => BuiltInStyles.Light,
            MapboxBuiltInStyle.Outdoors => BuiltInStyles.Outdoors,
            MapboxBuiltInStyle.MapboxStreets => BuiltInStyles.Streets,
            MapboxBuiltInStyle.Satellite => BuiltInStyles.Satellite,
            MapboxBuiltInStyle.SatelliteStreets => BuiltInStyles.SatelliteStreets,
            MapboxBuiltInStyle.TrafficDay => "mapbox://styles/mapbox/traffic-day-v2",
            MapboxBuiltInStyle.TrafficNight => "mapbox://styles/mapbox/traffic-night-v2",
            _ => mapboxStyle.Uri,
        };
    }

    public static MBMMapDebugOptions ToNative(this DebugOption option)
    {
        return option switch
        {
            DebugOption.TileBorders => MBMMapDebugOptions.TileBorders,
            DebugOption.ParseStatus => MBMMapDebugOptions.ParseStatus,
            DebugOption.Timestamps => MBMMapDebugOptions.Timestamps,
            DebugOption.Collision => MBMMapDebugOptions.Collision,
            DebugOption.StencilClip => MBMMapDebugOptions.StencilClip,
            DebugOption.DepthBuffer => MBMMapDebugOptions.DepthBuffer,
            _ => MBMMapDebugOptions.ModelBounds,
        };
    }

    public static IList<MBMMapDebugOptions> ToNative(this IEnumerable<DebugOption> options)
    {
        return options
            .Select(x => x.ToNative())
            .ToList();
    }

    public static MBMCameraOptions ToNative(this CameraOptions cameraOptions)
    {
        var center = cameraOptions.Center.HasValue
            ? new CLLocation(cameraOptions.Center.Value.X, cameraOptions.Center.Value.Y)
            : null;
        var padding = cameraOptions.Padding.HasValue
            ? new MBMEdgeInsets(
                cameraOptions.Padding.Value.Top,
                cameraOptions.Padding.Value.Left,
                cameraOptions.Padding.Value.Bottom,
                cameraOptions.Padding.Value.Right)
            : null;
        var anchor = cameraOptions.Anchor.HasValue
            ? new MBMScreenCoordinate(
                cameraOptions.Anchor.Value.X,
                cameraOptions.Anchor.Value.Y
                )
            : null;
        var zoom = cameraOptions.Zoom.HasValue
            ? NSNumber.FromFloat(cameraOptions.Zoom.Value)
            : null;
        var bearing = cameraOptions.Bearing.HasValue
            ? NSNumber.FromFloat(cameraOptions.Bearing.Value)
            : null;
        var pitch = cameraOptions.Pitch.HasValue
            ? NSNumber.FromFloat(cameraOptions.Pitch.Value)
            : null;

        if (center == null &&
            padding == null &&
            anchor == null &&
            zoom == null &&
            pitch == null) return null;

        return new MBMCameraOptions(
            center,
            padding,
            anchor,
            zoom,
            bearing,
            pitch
        );
    }
}

