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

    internal static IPosition ToPosition(this NSValue src)
        => new Position(
            src.CoordinateValue.Latitude,
            src.CoordinateValue.Longitude
        );

    internal static IGeometryObject ToX(this MBXGeometry src)
    {
        switch (src.GeometryType) {
            case MBXGeometryType.Point:
                var pointPosition = src
                    .ExtractLocations()
                    .ToPosition();
                return new GeoJSON.Text.Geometry.Point(
                    pointPosition
                );
            case MBXGeometryType.Line:
                var linePoints = src
                    .ExtractLocationsArray()
                    .Select(y => y.ToPosition());
                return new LineString(
                    linePoints
                );
            case MBXGeometryType.Polygon:
                var polygonPoints = src
                    .ExtractLocations2DArray()
                    .Cast<NSArray>()
                    .Select(
                    z => z
                        .Cast<NSValue>()
                        .Select(                        
                        y => new[] {
                            y.CoordinateValue.Longitude,
                            y.CoordinateValue.Latitude
                        })
                    );
                return new Polygon(
                    polygonPoints
                );
            case MBXGeometryType.MultiPoint:
                var multiPoints = src
                    .ExtractLocationsArray()
                    .Select(
                    y => new[] {
                        y.CoordinateValue.Longitude,
                        y.CoordinateValue.Latitude
                    });
                return new MultiPoint(
                    multiPoints
                );
            case MBXGeometryType.MultiLine:
                var multiLinePoints = src
                    .ExtractLocations2DArray()
                    .Cast<NSArray>()
                    .Select(
                    z => z
                        .Cast<NSValue>()
                        .Select(
                        y => new[] {
                            y.CoordinateValue.Longitude,
                            y.CoordinateValue.Latitude
                        })
                    );
                return new MultiLineString(
                    multiLinePoints
                );
            case MBXGeometryType.MultiPolygon:
                var multiPolygonPoints = src
                    .ExtractLocations3DArray()
                    .Cast<NSArray>()
                    .Select(
                    x => x
                        .Cast<NSArray>()
                        .Select(
                        z => z
                            .Cast<NSValue>()
                            .Select(
                            y => new[] {
                                y.CoordinateValue.Longitude,
                                y.CoordinateValue.Latitude
                            })
                        )
                    );
                return new MultiPolygon(
                    multiPolygonPoints
                );
            case MBXGeometryType.GeometryCollection:
                var geometries = src
                    .ExtractGeometriesArray()
                    .Select(x => x.ToX());
                return new GeometryCollection(geometries);
        }

        throw new NotSupportedException("Invalid geometry type");
    }

    internal static Feature ToX(this MBXFeature src)
    {
        var geometry = src.Geometry.ToX();

        var properties = new Dictionary<string, object>();
        // TODO Convert to C# obj
        // properties = src.Properties;

        return new Feature(geometry, properties, src.Identifier?.ToString());
    }
}

