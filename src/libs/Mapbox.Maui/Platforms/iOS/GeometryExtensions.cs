using CoreGraphics;
using Foundation;
using GeoJSON.Text.Feature;
using GeoJSON.Text.Geometry;
using MapboxCommon;
using MapboxMapsObjC;

namespace MapboxMaui;

public static class GeometryExtensions
{
    internal static MBXGeometry ToNative(this IGeometryObject xobj)
    {
        switch (xobj)
        {
            case GeoJSON.Text.Geometry.Point point:
                return GeometryHelper.CreatePoint(
                    point.Coordinates.ToNSValue());

            case LineString line:
                return GeometryHelper.CreateLine(
                    line.Coordinates
                    .Select(x => x.ToNSValue())
                    .ToArray());

            case Polygon polygon:
                return GeometryHelper.CreatePolygon(
                    NSArray.FromNSObjects(
                        polygon.Coordinates
                            .Select(
                                x => NSArray.FromNSObjects(
                                    x.Coordinates
                                        .Select(
                                            y => y.ToNSValue())
                                        .ToArray()))
                            .ToArray()));

            case MultiPoint multiPoint:
                return GeometryHelper.CreateMultiPoint(
                    multiPoint.Coordinates
                    .Select(x => x.Coordinates.ToNSValue())
                    .ToArray());

            case MultiLineString multiLineString:
                return GeometryHelper.CreateMultiLine(
                    NSArray.FromNSObjects(
                        multiLineString.Coordinates
                            .Select(
                                x => NSArray.FromNSObjects(
                                    x.Coordinates
                                        .Select(
                                            y => y.ToNSValue())
                                        .ToArray()))
                            .ToArray()));

            case MultiPolygon multiPolygon:
                return GeometryHelper.CreateMultiPolygon(
                    NSArray.FromNSObjects(
                        multiPolygon.Coordinates
                            .Select(
                                x => NSArray.FromNSObjects(
                                    x.Coordinates
                                        .Select(
                                            y => NSArray.FromNSObjects(
                                                y.Coordinates
                                                .Select(
                                                    z => z.ToNSValue())
                                                .ToArray()))
                                        .ToArray()))
                            .ToArray()));

                //case FeatureCollection featureCollection:
                //return GeometryHelper.CreateMultiPolygon(
                //    NSArray.FromNSObjects(
                //        multiPolygon.Coordinates
                //            .Select(
                //                x => NSArray.FromNSObjects(
                //                    x.Coordinates
                //                        .Select(
                //                            y => NSArray.FromNSObjects(
                //                                y.Coordinates
                //                                .Select(
                //                                    z => z.ToNSValue())
                //                                .ToArray()))
                //                        .ToArray()))
                //            .ToArray()));
        }

        return null;
    }

    internal static CGPoint ToCGPoint(this IPosition xobj)
    {
        return new CGPoint(
            xobj.Latitude,
            xobj.Longitude
        );
    }

    internal static NSValue ToNSValue(this IPosition xobj)
    {
        return NSValue.FromCGPoint(
            xobj.ToCGPoint()
        );
    }
}

