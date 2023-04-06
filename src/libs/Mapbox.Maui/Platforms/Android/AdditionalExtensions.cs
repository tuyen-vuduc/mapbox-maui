namespace Mapbox.Maui;
using MapboxMapsStyle = Com.Mapbox.Maps.Style;
using MapboxMapsCameraOptions = Com.Mapbox.Maps.CameraOptions;
using PlatformValue = Com.Mapbox.Bindgen.Value;
using Com.Mapbox.Maps;
using Microsoft.Maui.Platform;
using Mapbox.Maui.Styles;
using System.Collections;

static class AdditionalExtensions
{
    internal static PlatformValue Wrap(this object xvalue)
    {
        if (xvalue is IEnumerable objects)
        {
            var list = new List<PlatformValue>();
            foreach (var item in objects)
            {
                list.Add(item.Wrap());
            }
            return new PlatformValue(list);
        }

        return xvalue switch
        {
            bool value => new PlatformValue(value),
            long value => new PlatformValue(value),
            double value => new PlatformValue(value),
            string value => new PlatformValue(value),
            _ => throw new NotSupportedException($"Invalue property type: {xvalue?.GetType()} | {xvalue}")
        };
    }


    internal static PlatformValue ToPlatformValue(this RasterDemSource xbuilder)
    {
        var properties = new Dictionary<string, PlatformValue>()
        {
            { "type", xbuilder.Type.Wrap() },
        };
        foreach (var property in xbuilder.Properties)
        {
            var xvalue = property.Value.Value.Wrap();
            properties[property.Key] = xvalue;
        }

        var result = new PlatformValue(properties);
        return result;
    }

    internal static MapView GetMapView(this MapboxViewHandler handler)
    {
        var mainActivity = (MauiAppCompatActivity)handler.Context.GetActivity();
        var tag = $"mapbox-maui-{handler.PlatformView.Id}";
        var fragnent = mainActivity.SupportFragmentManager.FindFragmentByTag(tag);
        return (fragnent as MapboxFragment)?.MapView;
    }

    public static MapDebugOptions ToNative(this DebugOption option)
    {
        return option switch
        {
            DebugOption.TileBorders => MapDebugOptions.TileBorders,
            DebugOption.ParseStatus => MapDebugOptions.ParseStatus,
            DebugOption.Timestamps => MapDebugOptions.Timestamps,
            DebugOption.Collision => MapDebugOptions.Collision,
            DebugOption.StencilClip => MapDebugOptions.StencilClip,
            DebugOption.DepthBuffer => MapDebugOptions.DepthBuffer,
            _ => MapDebugOptions.ModelBounds,
        };
    }

    public static IList<MapDebugOptions> ToNative(this IEnumerable<DebugOption> options)
    {
        return options
            .Select(x => x.ToNative())
            .ToList();
    }

    public static string ToNative(this MapboxStyle mapboxStyle)
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

    public static MapboxMapsCameraOptions ToNative(this CameraOptions cameraOptions)
    {
        var cameraOptionsBuilder = new MapboxMapsCameraOptions.Builder();

        if (cameraOptions.Center.HasValue)
        {
            cameraOptionsBuilder.Center(
                Com.Mapbox.Geojson.Point.FromLngLat(
            cameraOptions.Center.Value.Y,
                cameraOptions.Center.Value.X
            ));
        }

        if (cameraOptions.Zoom.HasValue)
        {
            cameraOptionsBuilder.Zoom(new Java.Lang.Double(cameraOptions.Zoom.Value));
        }

        if (cameraOptions.Bearing.HasValue)
        {
            cameraOptionsBuilder.Bearing(new Java.Lang.Double(cameraOptions.Bearing.Value));
        }

        if (cameraOptions.Pitch.HasValue)
        {
            cameraOptionsBuilder.Pitch(new Java.Lang.Double(cameraOptions.Pitch.Value));
        }

        if (cameraOptions.Padding.HasValue)
        {
            cameraOptionsBuilder.Padding(new EdgeInsets(
                cameraOptions.Padding.Value.Top,
                cameraOptions.Padding.Value.Left,
                cameraOptions.Padding.Value.Bottom,
                cameraOptions.Padding.Value.Right
                ));
        }

        if (cameraOptions.Anchor.HasValue)
        {
            cameraOptionsBuilder.Anchor(new ScreenCoordinate(
                cameraOptions.Anchor.Value.X,
                cameraOptions.Anchor.Value.Y
                ));
        }

        return cameraOptionsBuilder.Build();
    }
}

