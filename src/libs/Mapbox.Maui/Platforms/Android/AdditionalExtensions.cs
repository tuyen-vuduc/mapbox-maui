namespace MapboxMaui;
using MapboxMapsCameraOptions = Com.Mapbox.Maps.CameraOptions;
using PlatformValue = Com.Mapbox.Bindgen.Value;
using MapboxTerrain = Com.Mapbox.Maps.Extension.Style.Terrain.Generated.Terrain;
using StyleTransitionBuilder = Com.Mapbox.Maps.Extension.Style.Types.StyleTransition.Builder;
using PlatformStyleTransition = Com.Mapbox.Maps.Extension.Style.Types.StyleTransition;
using XTilesetDescriptorOptions = Offline.TilesetDescriptorOptions;
using Com.Mapbox.Maps;
using Microsoft.Maui.Platform;
using MapboxMaui.Styles;
using System.Collections;
using MapboxMaui.Expressions;
using AndroidX.Fragment.App;

static class AdditionalExtensions
{
    internal static Java.Lang.Boolean ToPlatform(this bool xvalue)
    {
        return new Java.Lang.Boolean(xvalue);
    }

    internal static Java.Lang.Double ToPlatform(this double xvalue)
    {
        return new Java.Lang.Double(xvalue);
    }

    internal static double[] GetValue(this IList<Java.Lang.Double> xvalue, bool defaultToEmpty = false)
    {
        if (xvalue == null && defaultToEmpty)
        {
            return Array.Empty<double>();
        }

        return xvalue?
            .Select(x => x.DoubleValue())
            .ToArray();
    }

    internal static IList<Java.Lang.Double> ToPlatform(this IEnumerable<double> xvalue)
    {
        return xvalue?
            .Select(x => new Java.Lang.Double(x))
            .ToList();
    }

    internal static IList<Java.Lang.String> ToPlatform(this IEnumerable<string> xvalue)
    {
        return xvalue?
            .Select(x => new Java.Lang.String(x))
            .ToList();
    }

    internal static Com.Mapbox.Common.NetworkRestriction ToNative(this Offline.NetworkRestriction xvalue)
    {
        return xvalue switch
        {
            Offline.NetworkRestriction.None => Com.Mapbox.Common.NetworkRestriction.None,
            Offline.NetworkRestriction.DisallowExpensive => Com.Mapbox.Common.NetworkRestriction.DisallowExpensive,
            Offline.NetworkRestriction.DisallowAll => Com.Mapbox.Common.NetworkRestriction.DisallowAll,
            _ => null,
        };
    }

    internal static TilesetDescriptorOptions ToNative(this XTilesetDescriptorOptions xoptions)
    {
        return new TilesetDescriptorOptions.Builder()
            .MinZoom(xoptions.MinZoom)
            .MaxZoom(xoptions.MaxZoom)
            .StyleURI(xoptions.StyleUri)
            .PixelRatio(xoptions.PixelRatio)
            .StylePackOptions(xoptions.StylePackLoadOptions?.ToNative())
            .Build();
    }

    internal static StylePackLoadOptions ToNative(this Offline.StylePackLoadOptions xoptions)
    {
        return new StylePackLoadOptions.Builder()
                .GlyphsRasterizationMode(xoptions.Mode.HasValue
                    ? GetGlyphsRasterizationMode(xoptions.Mode.Value)
                    : null
                )
                .Metadata(xoptions.Metadata.Wrap())
                .AcceptExpired(xoptions.AcceptsExpired)
            .Build();
    }

    private static GlyphsRasterizationMode GetGlyphsRasterizationMode(Offline.GlyphsRasterizationMode mode)
    {
        return mode switch
        {
            Offline.GlyphsRasterizationMode.NoGlyphsRasterizedLocally => GlyphsRasterizationMode.NoGlyphsRasterizedLocally,
            Offline.GlyphsRasterizationMode.IdeographsRasterizedLocally => GlyphsRasterizationMode.IdeographsRasterizedLocally,
            Offline.GlyphsRasterizationMode.AllGlyphsRasterizedLocally => GlyphsRasterizationMode.AllGlyphsRasterizedLocally,
            _ => null,
        };
    }

    internal static PlatformValue ToPlatformValue(this BaseKVContainer xvalue, bool rgba = false)
    {
        var properties = new Dictionary<string, PlatformValue>();

        foreach (var property in xvalue.Properties)
        {
            var propertyValue = property.Value.Wrap(rgba);
            properties[property.Key] = propertyValue;
        }

        var result = new PlatformValue(properties);
        return result;
    }

    internal static Com.Mapbox.Maps.LayerPosition ToPlatformValue(this Styles.LayerPosition xvalue)
    {
        return xvalue.Enum switch
        {
            LayerPositionEnum.Above => new Com.Mapbox.Maps.LayerPosition(
                xvalue.Parameter as string, null, null
            ),
            LayerPositionEnum.At => new Com.Mapbox.Maps.LayerPosition(
                null, null, new Java.Lang.Integer((int)xvalue.Parameter)
            ),
            LayerPositionEnum.Below => new Com.Mapbox.Maps.LayerPosition(
                null, xvalue.Parameter as string, null
            ),
            _ => null,
        };
    }

    internal static PlatformValue Wrap(this object xvalue, bool rgba = false)
    {
        var platformValue = xvalue switch
        {
            bool value => new PlatformValue(value),
            byte value => new PlatformValue(value),
            short value => new PlatformValue(value),
            int value => new PlatformValue(value),
            long value => new PlatformValue(value),
            ushort value => new PlatformValue(value),
            uint value => new PlatformValue(value),
            ulong value => new PlatformValue(value),
            float value => new PlatformValue(value),
            double value => new PlatformValue(value),
            string value => new PlatformValue(value),
            Color value => rgba
                ? new PlatformValue(value.ToRgbaString())
                : new PlatformValue(value.ToInt()),
            INamedString value => new PlatformValue(value.Value),
            IPropertyValue value => value.Value is DslExpression expression1
                    ? new PlatformValue(expression1
                                .ToObjects()
                                .Select(x => x.Wrap(rgba))
                                .ToList()
                            )
                    : value.Value.Wrap(rgba),
            _ => null
        };

        if (platformValue != null) return platformValue;

        if (xvalue is DslExpression expression)
        {
            return new PlatformValue(expression
                            .ToObjects()
                            .Select(x => x.Wrap(rgba))
                            .ToList()
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
            var list = new Dictionary<string, PlatformValue>();
            foreach (var item in dict)
            {
                list[item.Key] = item.Value.Wrap(rgba);
            }
            return new PlatformValue(list);
        }

        if (xvalue is IReadOnlyDictionary<string, object> rodict)
        {
            var list = new Dictionary<string, PlatformValue>();
            foreach (var item in rodict)
            {
                list[item.Key] = item.Value.Wrap(rgba);
            }
            return new PlatformValue(list);
        }

        if (xvalue is IEnumerable objects)
        {
            var list = new List<PlatformValue>();
            foreach (var item in objects)
            {
                list.Add(item.Wrap(rgba));
            }
            return new PlatformValue(list);
        }

        throw new NotSupportedException($"Invalue property type: {xvalue?.GetType()} | {xvalue}");
    }

    internal static MapboxTerrain ToPlatformValue(this Terrain terrain)
    {
        var result = new MapboxTerrain(terrain.SourceId);

        if (terrain.Exaggeration != null)
        {
            if (terrain.Exaggeration.Expression != null)
            {
                result.Exaggeration(terrain.Exaggeration.Expression.ToPlatformValue());
            }
            else
            {
                result.Exaggeration(terrain.Exaggeration.Constant);
            }
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

    internal static PlatformValue GetVolatileProperties(this MapboxSource source)
    {
        var properties = new Dictionary<string, PlatformValue>();

        foreach (var property in source.VolatileProperties)
        {
            var xvalue = property.Value.Wrap();
            properties[property.Key] = xvalue;
        }

        var result = new PlatformValue(properties);
        return result;
    }

    internal static MapView GetMapView(this MapboxViewHandler handler)
        => handler.PlatformView.GetMapView();

    internal static MapView GetMapView(this FragmentContainerView container)
    {
        var mainActivity = (MauiAppCompatActivity)container.Context.GetActivity();
        var tag = $"mapbox-maui-{container.Id}";
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
        return mapboxStyle.Value;
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

