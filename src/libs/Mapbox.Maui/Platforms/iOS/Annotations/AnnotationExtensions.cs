namespace MapboxMaui.Annotations;

using CoreLocation;
using Foundation;
using MapboxMapsObjC;
using Microsoft.Maui.Platform;

public static class AnnotationExtensions
{
    internal static TMBPointAnnotation ToPlatformValue(
        this PointAnnotation xvalue)
    {
        var result = new TMBPointAnnotation(
            xvalue.Id, 
            new CLLocationCoordinate2D(
                xvalue.GeometryValue.Coordinates.Latitude,
                xvalue.GeometryValue.Coordinates.Longitude), 
            xvalue.IsSelected, 
            xvalue.IsDraggable);

        result.IconAnchor = xvalue.IconAnchor?.ToPlatform();
        result.IconImage = xvalue.IconImage;
        result.IconOffset = xvalue.IconOffset?.ToPlatform();
        result.IconRotate = xvalue.IconRotate;
        result.IconSize = xvalue.IconSize;
        result.SymbolSortKey = xvalue.SymbolSortKey;
        result.TextAnchor = xvalue.TextAnchor?.ToPlatform();
        result.TextField = xvalue.TextField;
        result.TextJustify = xvalue.TextJustify?.ToPlatform();
        result.TextLetterSpacing = xvalue.TextLetterSpacing;
        result.TextLineHeight = xvalue.TextLineHeight;
        result.TextMaxWidth = xvalue.TextMaxWidth;
        result.TextOffset = xvalue.TextOffset?.ToPlatform();
        result.TextRadialOffset = xvalue.TextRadialOffset;
        result.TextRotate = xvalue.TextRotate;
        result.TextSize = xvalue.TextSize;
        result.TextTransform = xvalue.TextTransform?.ToPlatform();
        result.IconColor = xvalue.IconColor?.ToPlatform();
        result.IconHaloBlur = xvalue.IconHaloBlur;
        result.IconHaloColor = xvalue.IconHaloColor?.ToPlatform();
        result.IconHaloWidth = xvalue.IconHaloWidth;
        result.IconOpacity = xvalue.IconOpacity;
        result.TextColor = xvalue.TextColor?.ToPlatform();
        result.TextHaloBlur = xvalue.TextHaloBlur;
        result.TextHaloColor = xvalue.TextHaloColor?.ToPlatform();
        result.TextHaloWidth = xvalue.TextHaloWidth;
        result.TextOpacity = xvalue.TextOpacity;

        return result;
    }

    internal static TMBCircleAnnotation ToPlatformValue(
        this CircleAnnotation xvalue)
    {
        var result = new TMBCircleAnnotation(
            xvalue.Id,
            new CLLocationCoordinate2D(
                xvalue.GeometryValue.Coordinates.Latitude,
                xvalue.GeometryValue.Coordinates.Longitude),
            xvalue.IsSelected,
            xvalue.IsDraggable);

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
        // TODO Create TMBPolygonAnnotation
        throw new NotImplementedException();
        //var coordinates = NSArray.FromNSObjects(xvalue
        //        .GeometryValue
        //        .Coordinates
        //        .Select(
        //            x => NSArray.FromObjects(
        //                x.Coordinates
        //                .Select(
        //                    y => NSValue.FromMKCoordinate(
        //                        new CLLocationCoordinate2D(y.Latitude, y.Longitude)
        //                    )
        //                )
        //                .ToArray()
        //            )
        //        ).ToArray()
        //    );
        //var polygon = new TMBPolygon(coordinates);
        //var result = TMBPolygonAnnotation.Polygon(
        //    polygon
        //);
        //result.FillColor = xvalue.FillColor?.ToPlatform();
        //result.FillOpacity = xvalue.FillOpacity.HasValue
        //    ? NSNumber.FromDouble(xvalue.FillOpacity.Value)
        //    : null;
        //result.FillOutlineColor = xvalue.FillOutlineColor?.ToPlatform();
        //result.FillPattern = xvalue.FillPattern;
        //result.FillSortKey = xvalue.FillSortKey;

        //return result;
    }

    internal static TMBPolylineAnnotation ToPlatformValue(
        this PolylineAnnotation xvalue
    )
    {
        var coordinates = NSArray.FromNSObjects(xvalue
                .GeometryValue
                .Coordinates
                .Select(
                    y => NSValue.FromMKCoordinate(
                        new CLLocationCoordinate2D(y.Latitude, y.Longitude)
                    )
                ).ToArray()
            )
            .Cast<NSValue>()
            .ToArray();
        var result = new TMBPolylineAnnotation(
            xvalue.Id,
            coordinates,
            xvalue.IsSelected,
            xvalue.IsDraggable
        );

        result.LineBlur = xvalue.LineBlur.ToPlatform();
        result.LineColor = xvalue.LineColor.ToPlatform();
        result.LineGapWidth = xvalue.LineGapWidth.ToPlatform();
        result.LineJoin = xvalue.LineJoin?.ToPlatform();
        result.LineOffset = xvalue.LineOffset.ToPlatform();
        result.LineOpacity = xvalue.LineOpacity.ToPlatform();
        result.LinePattern = xvalue.LinePattern;
        result.LineSortKey = xvalue.LineSortKey.ToPlatform();
        result.LineWidth = xvalue.LineWidth.ToPlatform();

        return result;
    }
}

