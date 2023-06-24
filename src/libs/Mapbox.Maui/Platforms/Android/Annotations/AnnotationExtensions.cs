namespace MapboxMaui.Annotations;

using PlatformPolygonAnnotationOptions = Com.Mapbox.Maps.Plugin.Annotation.Generated.PolygonAnnotationOptions;
using PlatformCircleAnnotationOptions = Com.Mapbox.Maps.Plugin.Annotation.Generated.CircleAnnotationOptions;
using PlatformPointAnnotationOptions = Com.Mapbox.Maps.Plugin.Annotation.Generated.PointAnnotationOptions;
using PlatformPolylineAnnotationOptions = Com.Mapbox.Maps.Plugin.Annotation.Generated.PolylineAnnotationOptions;

public static class AnnotationExtensions
{
    internal static PlatformPointAnnotationOptions ToPlatformValue(this PointAnnotation annotation)
    {
        var result = new PlatformPointAnnotationOptions
        {
            IconAnchor = annotation.IconAnchor?.ToPlatform(),
            IconImage = annotation.IconImage,
            IconOffset = annotation.IconOffset?.ToPlatform(),
            IconRotate = annotation.IconRotate?.AsDouble(),
            IconSize = annotation.IconSize?.AsDouble(),
            SymbolSortKey = annotation.SymbolSortKey?.AsDouble(),
            TextAnchor = annotation.TextAnchor?.ToPlatform(),
            TextField = annotation.TextField,
            TextJustify = annotation.TextJustify?.ToPlatform(),
            TextLetterSpacing = annotation.TextLetterSpacing?.AsDouble(),
            TextLineHeight = annotation.TextLineHeight?.AsDouble(),
            TextMaxWidth = annotation.TextMaxWidth?.AsDouble(),
            TextOffset = annotation.TextOffset?.ToPlatform(),
            TextRadialOffset = annotation.TextRadialOffset?.AsDouble(),
            TextRotate = annotation.TextRotate?.AsDouble(),
            TextSize = annotation.TextSize?.AsDouble(),
            TextTransform = annotation.TextTransform?.ToPlatform(),
            IconColor = annotation.IconColor?.ToRgbaString(),
            IconHaloBlur = annotation.IconHaloBlur?.AsDouble(),
            IconHaloColor = annotation.IconHaloColor?.ToRgbaString(),
            IconHaloWidth = annotation.IconHaloWidth?.AsDouble(),
            IconOpacity = annotation.IconOpacity?.AsDouble(),
            TextColor = annotation.TextColor?.ToRgbaString(),
            TextHaloBlur = annotation.TextHaloBlur?.AsDouble(),
            TextHaloColor = annotation.TextHaloColor?.ToRgbaString(),
            TextHaloWidth = annotation.TextHaloWidth?.AsDouble(),
            TextOpacity = annotation.TextOpacity?.AsDouble(),
        }
            .WithDraggable(annotation.IsDraggable)
            .WithPoint((Com.Mapbox.Geojson.Point)annotation.GeometryValue.ToNative());

        return result;
    }

    internal static PlatformCircleAnnotationOptions ToPlatformValue(this CircleAnnotation annotation)
    {
        var result = new PlatformCircleAnnotationOptions
        {
            CircleBlur = annotation.CircleBlur?.AsDouble(),
            CircleColor = annotation.CircleColor?.ToRgbaString(),
            CircleOpacity = annotation.CircleOpacity?.AsDouble(),
            CircleRadius = annotation.CircleRadius?.AsDouble(),
            CircleSortKey = annotation.CircleSortKey?.AsDouble(),
            CircleStrokeColor = annotation.CircleStrokeColor?.ToRgbaString(),
            CircleStrokeOpacity = annotation.CircleStrokeOpacity?.AsDouble(),
            CircleStrokeWidth = annotation.CircleStrokeWidth?.AsDouble(),
        }
            .WithDraggable(annotation.IsDraggable)
            .WithPoint((Com.Mapbox.Geojson.Point)annotation.GeometryValue.ToNative());

        return result;
    }

    internal static Java.Lang.Double AsDouble(this double value)
    {
        return new Java.Lang.Double(value);
    }

    internal static PlatformPolygonAnnotationOptions ToPlatformValue(this PolygonAnnotation annotation)
    {
        var points = annotation
            .GeometryValue
            .Coordinates
            .Select(
                x => new Android.Runtime.JavaList<Com.Mapbox.Geojson.Point>(
                    x.Coordinates.Select(
                    y => Com.Mapbox.Geojson.Point.FromLngLat(y.Longitude, y.Latitude)
                )) as IList<Com.Mapbox.Geojson.Point>
            )
            .ToList();

        var result = new PlatformPolygonAnnotationOptions
        {
            FillColor = annotation.FillColor?.ToRgbaString(),
            FillOpacity = annotation.FillOpacity?.AsDouble(),
            FillOutlineColor = annotation.FillOutlineColor?.ToRgbaString(),
            FillPattern = annotation.FillPattern,
            FillSortKey = annotation.FillSortKey?.AsDouble()
        }
        .WithDraggable(annotation.IsDraggable)
        .WithPoints(points);

        return result;
    }

    internal static PlatformPolylineAnnotationOptions ToPlatformValue(this PolylineAnnotation annotation)
    {
        var points = annotation
            .GeometryValue
            .Coordinates
            .Select(
                y => Com.Mapbox.Geojson.Point.FromLngLat(y.Longitude, y.Latitude)
            )
            .ToList();

        var result = new PlatformPolylineAnnotationOptions
        {
            LineBlur = annotation.LineBlur?.ToPlatform(),
            LineColor = annotation.LineColor?.ToRgbaString(),
            LineGapWidth = annotation.LineGapWidth?.ToPlatform(),
            LineJoin = annotation.LineJoin?.ToPlatform(),
            LineOffset = annotation.LineOffset?.ToPlatform(),
            LineOpacity = annotation.LineOpacity?.ToPlatform(),
            LinePattern = annotation.LinePattern,
            LineSortKey = annotation.LineSortKey?.ToPlatform(),
            LineWidth = annotation.LineWidth?.ToPlatform(),
        }
        .WithDraggable(annotation.IsDraggable)
        .WithPoints(points);

        return result;
    }
}

