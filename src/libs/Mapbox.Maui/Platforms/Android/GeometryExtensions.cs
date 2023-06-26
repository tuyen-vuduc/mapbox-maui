using GeoJSON.Text.Geometry;
using Point = Microsoft.Maui.Graphics.Point;

namespace MapboxMaui;

public static class GeometryExtensions
{
    internal static Com.Mapbox.Geojson.Point ToGeoPoint(this GeoJSON.Text.Geometry.IPosition xvalue)
    {
        return Com.Mapbox.Geojson.Point.FromLngLat(
                xvalue.Longitude,
                xvalue.Latitude);
    }

    internal static Com.Mapbox.Geojson.IGeometry ToNative(this GeoJSON.Text.Geometry.IGeometryObject xvalue)
    {
        return xvalue switch
        {
            GeoJSON.Text.Geometry.Point point => Com.Mapbox.Geojson.Point.FromLngLat(
                point.Coordinates.Longitude,
                point.Coordinates.Latitude),

            LineString line => Com.Mapbox.Geojson.LineString.FromLngLats(
                Com.Mapbox.Geojson.MultiPoint.FromLngLats(
                    line.Coordinates.Select(ToGeoPoint).ToList()
                    )
                ),

            Polygon polygon => Com.Mapbox.Geojson.Polygon.FromLngLats(
                polygon.Coordinates
                    .Select(
                        x => x.Coordinates.Select(ToGeoPoint).ToList()
                            as IList<Com.Mapbox.Geojson.Point>)
                    .ToList()
                ),

            MultiPoint multiPoint => Com.Mapbox.Geojson.MultiPoint.FromLngLats(
                   multiPoint.Coordinates
                       .Select(x => x.Coordinates.ToGeoPoint())
                       .ToList()
                   ),

            MultiLineString multiLineString => Com.Mapbox.Geojson.Polygon.FromLngLats(
                multiLineString.Coordinates
                    .Select(
                        x => x.Coordinates.Select(ToGeoPoint).ToList()
                            as IList<Com.Mapbox.Geojson.Point>)
                    .ToList()
                ),

            MultiPolygon multiPolygon => Com.Mapbox.Geojson.Polygon.FromLngLats(
                multiPolygon.Coordinates
                    .Select(
                        x => x.Coordinates
                                .Select(
                                    y => y.Coordinates.Select(ToGeoPoint))
                                .ToList()
                            as IList<Com.Mapbox.Geojson.Point>)
                    .ToList()
                ),
            _ => null,
        };
    }

    internal static Com.Mapbox.Geojson.Point ToNative(this Point xvalue)
    {
        return Com.Mapbox.Geojson.Point.FromLngLat(xvalue.Y, xvalue.X);
    }

    internal static GeoJSON.Text.Feature.Feature ToX(this Com.Mapbox.Geojson.Feature src)
        => new GeoJSON.Text.Feature.Feature(
            src.Geometry().ToX(),
            null, // TODO Convert to C# obj: src.Properties(),
            src.Id());

    internal static IGeometryObject ToX(this Com.Mapbox.Geojson.IGeometry src)
    {
        switch(src)
        {
            case Com.Mapbox.Geojson.Point point:
                return new GeoJSON.Text.Geometry.Point(
                    new Position(
                        point.Latitude(), point.Longitude(),
                        point.HasAltitude ? point.Altitude() : null
                    )
                );
            case Com.Mapbox.Geojson.LineString lineString:
                return new LineString(
                    lineString
                    .Coordinates()
                    .Select(x => new [] { x.Longitude(), x.Latitude() })
                    .ToList()
                );
            case Com.Mapbox.Geojson.Polygon polygon:
                return new Polygon(
                    polygon
                    .Coordinates()
                    .Select(
                    y => y.Select(
                        x => new[] { x.Longitude(), x.Latitude() }
                        ))
                    .ToList()
                );
            case Com.Mapbox.Geojson.MultiPoint multiPoint:
                return new MultiPoint(
                    multiPoint
                    .Coordinates()
                    .Select(x => new[] { x.Longitude(), x.Latitude() })
                    .ToList()
                );
            case Com.Mapbox.Geojson.MultiLineString multiLineString:
                return new MultiLineString(
                    multiLineString
                    .Coordinates()
                    .Select(
                    y => y.Select(
                        x => new[] { x.Longitude(), x.Latitude() }
                        ))
                    .ToList()
                );
            case Com.Mapbox.Geojson.MultiPolygon multiPolygon:
                return new MultiPolygon(
                    multiPolygon
                    .Coordinates()
                    .Select(
                    z => z.Select(
                        y => y.Select(
                            x => new[] { x.Longitude(), x.Latitude() }
                            )
                        )
                    )
                    .ToList()
                );
            case Com.Mapbox.Geojson.GeometryCollection geometryCollection:
                return new GeometryCollection(
                    geometryCollection
                    .Geometries()
                    .Select(x => x.ToX())
                    .ToList()
                );
        }
        throw new NotSupportedException("Invalid geometry type");
    }
}

