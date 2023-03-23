namespace MapboxMauiQs;

using Android.Views;
using Android.Widget;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers;
using PlatformView = Com.Mapbox.Maps.MapView;
using MapboxMapsStyle = Com.Mapbox.Maps.Style;

public partial class MapboxViewHandler
{
    private static void HandleCenterChanged(MapboxViewHandler handler, IMapboxView view)
    {
        //handler.PlatformView.
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

