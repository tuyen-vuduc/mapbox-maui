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

            GeoJSON.Text.Geometry.LineString line => Com.Mapbox.Geojson.LineString.FromLngLats(
                Com.Mapbox.Geojson.MultiPoint.FromLngLats(
                    line.Coordinates.Select(ToGeoPoint).ToList()
                    )
                ),

            GeoJSON.Text.Geometry.Polygon polygon => Com.Mapbox.Geojson.Polygon.FromLngLats(
                polygon.Coordinates
                    .Select(
                        x => x.Coordinates.Select(ToGeoPoint).ToList()
                            as IList<Com.Mapbox.Geojson.Point>)
                    .ToList()
                ),

            GeoJSON.Text.Geometry.MultiPoint multiPoint => Com.Mapbox.Geojson.MultiPoint.FromLngLats(
                   multiPoint.Coordinates
                       .Select(x => x.Coordinates.ToGeoPoint())
                       .ToList()
                   ),

            GeoJSON.Text.Geometry.MultiLineString multiLineString => Com.Mapbox.Geojson.Polygon.FromLngLats(
                multiLineString.Coordinates
                    .Select(
                        x => x.Coordinates.Select(ToGeoPoint).ToList()
                            as IList<Com.Mapbox.Geojson.Point>)
                    .ToList()
                ),

            GeoJSON.Text.Geometry.MultiPolygon multiPolygon => Com.Mapbox.Geojson.Polygon.FromLngLats(
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
}

