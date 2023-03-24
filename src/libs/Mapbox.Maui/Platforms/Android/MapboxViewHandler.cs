namespace Mapbox.Maui;

using Android.Views;
using Android.Widget;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers;
using PlatformView = Com.Mapbox.Maps.MapView;
using MapboxMapsStyle = Com.Mapbox.Maps.Style;
using Com.Mapbox.Maps;

public partial class MapboxViewHandler
{
    private static void HandleCameraOptionsChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var cameraOptionsBuilder = new CameraOptions.Builder();

        if (view.MapCenter.HasValue)
        {
            cameraOptionsBuilder.Center(
                Com.Mapbox.Geojson.Point.FromLngLat(
                view.MapCenter.Value.Y,
                view.MapCenter.Value.X
            ));
        }

        if (view.MapZoom.HasValue)
        {
            cameraOptionsBuilder.Zoom(new Java.Lang.Double(view.MapZoom.Value));
        }

        handler.PlatformView.MapboxMap.SetCamera(cameraOptionsBuilder.Build());
    }

    private static void HandleMapboxStyleChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var styleUri = view.MapboxStyle.ToStyleUri();

        if (string.IsNullOrWhiteSpace(styleUri))
        {
            styleUri = MapboxMapsStyle.MapboxStreets;
        }

        handler.PlatformView.MapboxMap.LoadStyleUri(styleUri);
    }

    protected override PlatformView CreatePlatformView()
    {
        return new PlatformView(Context);
    }
}

static class MapboxStyleExtensions
{
    public static string ToStyleUri(this MapboxStyle mapboxStyle)
    {
        return mapboxStyle.BuiltInStyle switch
        {
            MapboxBuiltInStyle.Dark => MapboxMapsStyle.Dark,
            MapboxBuiltInStyle.Light => MapboxMapsStyle.Light,
            MapboxBuiltInStyle.Outdoors => MapboxMapsStyle.Outdoors,
            MapboxBuiltInStyle.MapboxStreets => MapboxMapsStyle.MapboxStreets,
            MapboxBuiltInStyle.Satellite => MapboxMapsStyle.Satellite,
            MapboxBuiltInStyle.SatelliteStreets => MapboxMapsStyle.SatelliteStreets,
            MapboxBuiltInStyle.TrafficDay => MapboxMapsStyle.TrafficDay,
            MapboxBuiltInStyle.TrafficNight => MapboxMapsStyle.TrafficNight,
            _ => mapboxStyle.Uri,
        };
    }
}

