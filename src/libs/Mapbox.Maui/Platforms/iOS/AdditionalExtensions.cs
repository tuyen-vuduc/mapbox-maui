
namespace MapboxMaui;

using System.Collections;
using CoreLocation;
using Foundation;
using MapboxMaui.Expressions;
using MapboxMaui.Offline;
using MapboxMaui.Styles;
using MapboxCoreMaps;
using MapboxMapsObjC;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Platform;

public static partial class AdditionalExtensions
{
    internal static NSDictionary<NSString, TMBExpression> ToNative(this IDictionary<string, DslExpression> dictionary)
    {
        var list = new NSMutableDictionary<NSString, TMBExpression>();
        foreach (var item in dictionary)
        {
            list[item.Key] = item.Value.ToPlatformValue();
        }
        return new NSDictionary<NSString, TMBExpression>(list.Keys, list.Values);
    }

    internal static TMBValue ToTMBValue<T>(this PropertyValue<T> propertyValue)
    {
        if (propertyValue.Expression != null)
        {
            var nativeExpression = propertyValue.Expression.ToPlatformValue();
            return TMBValue.Expression(nativeExpression);
        }

        if (propertyValue.Value is Color color)
        {
            return TMBValue.Constant(color.ToPlatform());
        }

        return TMBValue.Constant(propertyValue.Value.Wrap());
    }

    internal static NSNumber[] ToPlatform(this double[] values, bool defaultToEmpty = false)
    {
        if (defaultToEmpty && values == null)
        {
            return Array.Empty<NSNumber>();
        }

        return values.Select(NSNumber.FromDouble).ToArray();
    }

    internal static NSNumber ToPlatform(this double? value)
        => value.HasValue
        ? NSNumber.FromDouble(value.Value)
        : null;

    internal static double[] ToDoubles(this NSNumber[] values, bool defaultToEmpty = false)
    {
        if (defaultToEmpty && values == null)
        {
            return Array.Empty<double>();
        }

        return values.Select(x => x.DoubleValue).ToArray();
    }

    internal static MBMStylePackLoadOptions ToNative(this StylePackLoadOptions options)
    {
        var metadata = new NSMutableDictionary();
        if (options.Metadata != null)
        {
            foreach (var item in options.Metadata)
            {
                metadata[new NSString(item.Key)] = item.Value.Wrap();
            }
        }

        return new MBMStylePackLoadOptions(
            options.Mode.HasValue
            ? NSNumber.FromInt32((int)options.Mode)
            : null,
            metadata,
            options.AcceptsExpired
        );
    }

    internal static TMBTerrain ToPlatformValue(
        this Terrain xvalue
    )
    {
        var result = new TMBTerrain(xvalue.SourceId);

        switch (xvalue.Exaggeration.Value)
        {
            case DslExpression expression:
                result.Exaggeration = TMBValue.Expression(expression.ToPlatformValue());
                break;
            case double doubleValue:
                result.Exaggeration = TMBValue.Constant(doubleValue.Wrap());
                break;
        }

        return result;
    }

    internal static TMBLayerPosition ToPlatformValue(
        this LayerPosition xvalue,
        NSObject arg
    )
    {
        var layerPositionType = xvalue.Enum switch
        {
            LayerPositionEnum.Above => TMBLayerPositionType.Above,
            LayerPositionEnum.Below => TMBLayerPositionType.Below,
            LayerPositionEnum.At => TMBLayerPositionType.At,
            _ => (TMBLayerPositionType?)null
        };

        return layerPositionType.HasValue
            ? new TMBLayerPosition(layerPositionType.Value, arg)
            : null;
    }

    internal static TMBStyleTransition ToPlatformValue(this StyleTransition xvalue)
    {
        return new TMBStyleTransition(xvalue.Duration, xvalue.Delay);
    }

    internal static NSObject Wrap(this object xvalue)
    {
        var result = xvalue switch
        {
            bool value => NSNumber.FromBoolean(value),
            int value => NSNumber.FromLong(value),
            long value => NSNumber.FromLong((nint)value),
            float value => NSNumber.FromDouble(value),
            double value => NSNumber.FromDouble(value),
            string value => new NSString(value),
            Color value => new NSString(value.ToRgbaString()),
            INamedString value => new NSString(value.Value),
            IPropertyValue value => value.Value is DslExpression expression1
                    ? expression1.Wrap()
                    : value.Value.Wrap(),
            _ => (NSObject)null
        };

        if (result != null) return result;

        if (xvalue is DslExpression expression)
        {
            return NSArray.FromNSObjects(
                expression
                    .ToObjects()
                    .Select(x => x.Wrap())
                    .ToArray()
                );
        }

        if (xvalue is PromoteId promoteId)
        {
            return string.IsNullOrWhiteSpace(promoteId.StringValue)
                ? promoteId.KeyValues.Wrap()
                : promoteId.StringValue.Wrap();
        }

        if (xvalue is ResolvedImage resolvedImage)
        {
            return resolvedImage.Id.Wrap();
        }

        if (xvalue is IDictionary<string, object> dict)
        {
            var list = new NSMutableDictionary<NSString, NSObject>();
            foreach (var item in dict)
            {
                list[item.Key] = item.Value.Wrap();
            }
            return new NSDictionary<NSString, NSObject>(list.Keys, list.Values);
        }

        if (xvalue is IEnumerable objects)
        {
            var list = new List<NSObject>();
            foreach (var item in objects)
            {
                list.Add(item.Wrap());
            }
            return NSArray.FromNSObjects(list.ToArray());
        }

        throw new NotSupportedException($"Invalue property type: {xvalue?.GetType()} | {xvalue}");
    }

    internal static NSDictionary<NSString, NSObject> ToPlatformValue(
        this MapboxLayer xvalue
    )
    {
        var properties = new NSMutableDictionary<NSString, NSObject>();
        foreach (var property in xvalue.Properties)
        {
            var propertyValue = property.Value.Wrap();
            properties[property.Key] = propertyValue;
        }

        return new NSDictionary<NSString, NSObject>(
            properties.Keys,
            properties.Values
        );
    }

    internal static NSDictionary<NSString, NSObject> ToPlatformValue(
        this MapboxSource source
    )
    {
        // TODO Add volatile properties
        var properties = new NSMutableDictionary<NSString, NSObject>();
        foreach (var property in source.Properties)
        {
            var xvalue = property.Value.Wrap();
            properties[property.Key] = xvalue;
        }

        return new NSDictionary<NSString, NSObject>(
            properties.Keys,
            properties.Values
        );
    }

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
        return mapboxStyle.Value;
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

