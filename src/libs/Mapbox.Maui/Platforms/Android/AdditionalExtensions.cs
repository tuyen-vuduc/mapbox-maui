namespace Mapbox.Maui;
using MapboxMapsStyle = Com.Mapbox.Maps.Style;
using MapboxMapsCameraOptions = Com.Mapbox.Maps.CameraOptions;
using PlatformValue = Com.Mapbox.Bindgen.Value;
using MapboxTerrain = Com.Mapbox.Maps.Extension.Style.Terrain.Generated.Terrain;
using StyleTransitionBuilder = Com.Mapbox.Maps.Extension.Style.Types.StyleTransition.Builder;
using PlatformStyleTransition = Com.Mapbox.Maps.Extension.Style.Types.StyleTransition;
using Com.Mapbox.Maps;
using Microsoft.Maui.Platform;
using Mapbox.Maui.Styles;
using System.Collections;
using Mapbox.Maui.Expressions;
using Com.Mapbox.Maps.Extension.Style.Expressions.Generated;
using System.Collections.Immutable;

static class AdditionalExtensions
{
    internal static PlatformValue ToPlatformValue(this MapboxLayer xvalue)
    {
        var properties = new Dictionary<string, PlatformValue>();

        foreach (var property in xvalue.Properties)
        {
            var propertyValue = property.Value.Wrap();
            properties[property.Key] = propertyValue;
        }

        var result = new PlatformValue(properties);
        return result;
    }

    internal static Com.Mapbox.Maps.LayerPosition ToPlatformValue(this Styles.LayerPosition xvalue)
    {
        return xvalue.Enum switch
        {
            Styles.LayerPositionEnum.Above => new Com.Mapbox.Maps.LayerPosition(
                xvalue.Parameter as string, null, null
            ),
            Styles.LayerPositionEnum.At => new Com.Mapbox.Maps.LayerPosition(
                null, null, new Java.Lang.Integer((int)xvalue.Parameter)
            ),
            Styles.LayerPositionEnum.Below => new Com.Mapbox.Maps.LayerPosition(
                null, xvalue.Parameter as string, null
            ),
            _ => null,
        };
    }

    internal static PlatformValue Wrap(this object xvalue)
    {
        var platformValue = xvalue switch
        {
            bool value => new PlatformValue(value),
            long value => new PlatformValue(value),
            double value => new PlatformValue(value),
            string value => new PlatformValue(value),
            IStringEnum value => new PlatformValue(value.Value),
            PropertyValue value => value.Expression != null
                    ? value.Expression.ToPlatformValue()
                    : value.Constant.Wrap(),
            _ => null
        };

        if (platformValue != null) return platformValue;

        if (xvalue is IDictionary<string, object> dict)
        {
            var list = new Dictionary<string, PlatformValue>();
            foreach (var item in dict)
            {
                list[item.Key] = item.Value.Wrap();
            }
            return new PlatformValue(list);
        }

        if (xvalue is IEnumerable objects)
        {
            var list = new List<PlatformValue>();
            foreach (var item in objects)
            {
                list.Add(item.Wrap());
            }
            return new PlatformValue(list);
        }

        throw new NotSupportedException($"Invalue property type: {xvalue?.GetType()} | {xvalue}");
    }

    internal static Expression ToPlatformValue(
        this DslExpression xvalue
    )
    {
        // TODO Convert to native expression
        return null;
    }

    internal static MapboxTerrain ToPlatformValue(this Terrain terrain)
    {
        var result = new MapboxTerrain(terrain.SourceId);

        switch (terrain.Exaggeration)
        {
            case Expressions.DslExpression expression:
                result.Exaggeration(expression.ToPlatformValue());
                break;
            case double doubleValue:
                result.Exaggeration(doubleValue);
                break;
        }

        if (terrain.ExaggerationTransition != null)
        {
            result.ExaggerationTransition(terrain.ExaggerationTransition.ToPlatformValue());
        }

        return result;
    }

    internal static PlatformStyleTransition ToPlatformValue(this StyleTransition xvalue)
    {
        var styleTransitionBuilder = new StyleTransitionBuilder();
        styleTransitionBuilder.InvokeDelay(xvalue.Delay);
        styleTransitionBuilder.InvokeDuration(xvalue.Duration);

        return styleTransitionBuilder.Build();
    }

    internal static PlatformValue ToPlatformValue(this MapboxSource source)
    {
        // TODO Add volatile properties

        var properties = new Dictionary<string, PlatformValue>();

        foreach (var property in source.Properties)
        {
            var xvalue = property.Value.Wrap();
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

