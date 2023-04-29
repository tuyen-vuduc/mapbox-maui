namespace MapboxMaui.Annotations;

using CoreLocation;
using Foundation;
using MapboxMapsObjC;
using Microsoft.Maui.Platform;

public static class AnnotationExtensions
{
    internal static TMBCircleAnnotation ToPlatformValue(
        this CircleAnnotation xvalue)
    {
        var result = TMBCircleAnnotation.FromCenter(
            new CLLocationCoordinate2D(
                xvalue.GeometryValue.Coordinates.Latitude,
                xvalue.GeometryValue.Coordinates.Longitude));

        result.CircleBlur = xvalue.CircleBlur;
        result.CircleColor = xvalue.CircleColor?.ToPlatform();
        result.CircleOpacity = xvalue.CircleOpacity;
        result.CircleRadius = xvalue.CircleRadius;
        result.CircleSortKey = xvalue.CircleSortKey;
        result.CircleStrokeColor = xvalue.CircleStrokeColor?.ToPlatform();
        result.CircleStrokeOpacity = xvalue.CircleStrokeOpacity;
        result.CircleStrokeWidth = xvalue.CircleStrokeWidth;

        return result;
    }

    internal static TMBPolygonAnnotation ToPlatformValue(
        this PolygonAnnotation xvalue
    )
    {
        var coordinates = NSArray.FromNSObjects(xvalue
                .GeometryValue
                .Coordinates
                .Select(
                    x => NSArray.FromObjects(
                        x.Coordinates
                        .Select(
                            y => NSValue.FromMKCoordinate(
                                new CLLocationCoordinate2D(y.Latitude, y.Longitude)
                            )
                        )
                        .ToArray()
                    )
                ).ToArray()
            );
        var polygon = TMBPolygon.FromCoordinates(
            coordinates
        );
        var result = TMBPolygonAnnotation.Polygon(
            polygon
        );
        result.FillColor = xvalue.FillColor?.ToPlatform();
        result.FillOpacity = xvalue.FillOpacity.HasValue
            ? NSNumber.FromDouble(xvalue.FillOpacity.Value)
            : null;
        result.FillOutlineColor = xvalue.FillOutlineColor?.ToPlatform();
        result.FillPattern = xvalue.FillPattern;
        result.FillSortKey = xvalue.FillSortKey;

        return result;
    }

}

