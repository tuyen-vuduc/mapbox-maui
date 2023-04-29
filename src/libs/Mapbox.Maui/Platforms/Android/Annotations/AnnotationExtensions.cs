namespace MapboxMaui.Annotations;

using PlatformPolygonAnnotationOptions = Com.Mapbox.Maps.Plugin.Annotation.Generated.PolygonAnnotationOptions;
using PlatformCircleAnnotationOptions = Com.Mapbox.Maps.Plugin.Annotation.Generated.CircleAnnotationOptions;

public static class AnnotationExtensions
{
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
}

