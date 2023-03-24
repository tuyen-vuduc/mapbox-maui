
namespace Mapbox.Maui;

using System;
using CoreLocation;
using Foundation;
using MapboxMaps;
using MapboxMapsObjC;
using Microsoft.Maui.Handlers;
using PlatformView = MapboxMaps.MapView;

public partial class MapboxViewHandler
{
    private static void HandleCameraOptionsChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var center = view.MapCenter.HasValue
            ? new CLLocation(view.MapCenter.Value.X, view.MapCenter.Value.Y)
            : null;
        var zoom = view.MapZoom.HasValue
            ? NSNumber.FromFloat(view.MapZoom.Value)
            : null;

        var cameraOptions = new MapboxCoreMaps.MBMCameraOptions(center, null, null, zoom, null, null);
        handler.PlatformView.SetCameraTo(cameraOptions);
    }

    private static void HandleMapboxStyleChanged(MapboxViewHandler handler, IMapboxView view)
    {
        //handler.PlatformView;
    }

    protected override PlatformView CreatePlatformView()
    {
        MapInitOptions options = MapInitOptionsBuilder
                .Create()
                .Build();

        // Perform any additional setup after loading the view, typically from a nib.
        var mapView = MapViewFactory.CreateWithFrame(
            CoreGraphics.CGRect.Empty,
            options
        );

        return mapView;
    }
}

