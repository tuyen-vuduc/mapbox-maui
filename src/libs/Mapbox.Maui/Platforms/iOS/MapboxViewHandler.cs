
namespace Mapbox.Maui;

using System;
using CoreLocation;
using Foundation;
using MapboxCoreMaps;
using MapboxMaps;
using MapboxMapsObjC;
using Microsoft.Maui.Handlers;
using PlatformView = MapboxMaps.MapView;

public partial class MapboxViewHandler
{
    private static void HandleCameraOptionsChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var cameraOptions = view.CameraOptions.ToNative();
        handler.PlatformView.SetCameraTo(cameraOptions);
    }

    private static void HandleMapboxStyleChanged(MapboxViewHandler handler, IMapboxView view)
    {
        //handler.PlatformView;
    }

    protected override PlatformView CreatePlatformView()
    {
        var accessToken = string.IsNullOrWhiteSpace(ACCESS_TOKEN)
            ? MapInitOptionsBuilder.DefaultResourceOptions.AccessToken
            : ACCESS_TOKEN;

        MapInitOptions options = MapInitOptionsBuilder
                .Create()
                .AccessToken(accessToken)
                .Build();

        // Perform any additional setup after loading the view, typically from a nib.
        var mapView = MapViewFactory.CreateWithFrame(
            CoreGraphics.CGRect.Empty,
            options
        );

        return mapView;
    }
}

public static class AdditionalExtensions
{
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

