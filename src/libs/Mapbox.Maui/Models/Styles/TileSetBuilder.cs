using System;
using System.Collections.Generic;

namespace Mapbox.Maui.Styles;

public class TileSetBuilder
{
    public IDictionary<string, object> Parameters { get; init; }
    public TileSetBuilder(
        string tilejson,
        List<string> tiles
        )
    {
        Parameters = new Dictionary<string, object>()
        {
            { nameof(tilejson), tilejson },
            { nameof(tiles), tiles },
        };
    }


    /**
     * A name describing the tileset. The name can
     * contain any legal character. Implementations SHOULD NOT interpret the
     * name as HTML.
     * "name": "compositing",
     *
     * @param value the name to be set
     */
    TileSetBuilder Name(string value)
    {
        Parameters["name"] = value;
        return this;
    }

    /**
     * A text description of the tileset. The
     * description can contain any legal character.
     * Implementations SHOULD NOT
     * interpret the description as HTML.
     * "description": "A simple, light grey world."
     *
     * @param value the description to set
     */
    TileSetBuilder Description(string value)
    {
        Parameters["description"] = value;
        return this;
    }

    /**
     *  Default: "1.0.0". A semver.org style version number. When
     *  changes across tiles are introduced, the minor version MUST change.
     *  This may lead to cut off labels. Therefore, implementors can decide to
     *  clean their cache when the minor version changes. Changes to the patch
     *  level MUST only have changes to tiles that are contained within one tile.
     *  When tiles change significantly, the major version MUST be increased.
     *  Implementations MUST NOT use tiles with different major versions.
     *
     *  @param value the version to set
     */
    TileSetBuilder Version(string value = "1.0.0")
    {
        Parameters["version"] = value; return this;
    }

    /**
     * Default: null. Contains an attribution to be displayed
     * when the map is shown to a user. Implementations MAY decide to treat this
     * as HTML or literal text. For security reasons, make absolutely sure that
     * this field can't be abused as a vector for XSS or beacon tracking.
     * "attribution": "[OSM contributors](http:openstreetmap.org)",
     *
     * @param value the attribution to set
     */
    TileSetBuilder Attribution(String value)
    {
        Parameters["attribution"] = value; return this;
    }

    /**
     * Contains a mustache template to be used to
     * format data from grids for interaction.
     * See https:github.com/mapbox/utfgrid-spec/tree/master/1.2
     * for the interactivity specification.
     * "template": "{{#__teaser__}}{{NAME}}{{/__teaser__}}"
     *
     * @param value the template to set
     */
    TileSetBuilder Template(String value)
    {
        Parameters["template"] = value; return this;
    }

    /**
     * Contains a legend to be displayed with the map.
     * Implementations MAY decide to treat this as HTML or literal text.
     * For security reasons, make absolutely sure that this field can't be
     * abused as a vector for XSS or beacon tracking.
     * "legend": "Dangerous zones are red, safe zones are green"
     *
     * @param value the legend to set
     */
    TileSetBuilder Legend(String value)
    {
        Parameters["legend"] = value; return this;
    }

    /**
     * Default: "xyz". Either "xyz" or "tms". Influences the y
     * direction of the tile coordinates.
     * The global-mercator (aka Spherical Mercator) profile is assumed.
     * "scheme": "xyz"
     *
     * @param value the scheme to set
     */
    TileSetBuilder Scheme(MapboxScheme value)
    {
        Parameters["scheme"] = value; return this;
    }

    /**
     * An array of interactivity endpoints. {z}, {x}
     * and {y}, if present, are replaced with the corresponding integers. If multiple
     * endpoints are specified, clients may use any combination of endpoints.
     * All endpoints MUST return the same content for the same URL.
     * If the array doesn't contain any entries, interactivity is not supported
     * for this tileset.     See https:github.com/mapbox/utfgrid-spec/tree/master/1.2
     * for the interactivity specification.
     *
     *
     * Example: "http:localhost:8888/admin/1.0.0/broadband/{z}/{x}/{y}.grid.json"
     *
     * @param value the grids to set
     */
    TileSetBuilder Grids(List<String> value)
    {
        Parameters["grids"] = value; return this;
    }

    /**
     * An array of data files in GeoJSON format.
     * {z}, {x} and {y}, if present,
     * are replaced with the corresponding integers. If multiple
     * endpoints are specified, clients may use any combination of endpoints.
     * All endpoints MUST return the same content for the same URL.
     * If the array doesn't contain any entries, then no data is present in
     * the map.
     *
     *
     * "http:localhost:8888/admin/data.geojson"
     *
     * @param value the data array to set
     */
    TileSetBuilder Data(List<String> value)
    {
        Parameters["data"] = value; return this;
    }

    /**
     * Default to 0. &gt;= 0, &lt; 22. An integer specifying the minimum zoom level.
     *
     * @param value the minZoom level to set
     */
    TileSetBuilder minZoom(int value = 0)
    {
        Parameters["minzoom"] = value; return this;
    }

    /**
     * Default to 30. &gt;= 0, &lt;= 22. An integer specifying the maximum zoom level.
     *
     * @param value the maxZoom level to set
     */
    TileSetBuilder maxZoom(int value = 30)
    {
        Parameters["maxzoom"] = value; return this;
    }

    /**
     * Default: [-180, -90, 180, 90]. The maximum extent of available map tiles. Bounds MUST define an area
     * covered by all zoom levels. The bounds are represented in WGS:84
     * latitude and longitude values, in the order left, bottom, right, top.
     * Values may be integers or floating point numbers.
     *
     * @param value the Double list to set
     */
    TileSetBuilder bounds(List<double> value = default)
    {
        if (value == null)
        {
            value = new List<double>
            {
                -180.0, -90.0, 180.0, 90.0
            };
        }

        Parameters["bounds"] = value; return this;
    }

    /**
     * The first value is the longitude, the second is latitude (both in
     * WGS:84 values), the third value is the zoom level as an integer.
     * Longitude and latitude MUST be within the specified bounds.
     * The zoom level MUST be between minzoom and maxzoom.
     * Implementations can use this value to set the default location. If the
     * value is null, implementations may use their own algorithm for
     * determining a default location.
     *
     * @param value the Double array to set
     */
    TileSetBuilder Center(List<double> value)
    {
        Parameters["center"] = value; return this;
    }
}

public class RasterDemBuilder : TileSetBuilder
{
    public RasterDemBuilder(
        string tilejson,
        List<string> tiles)
        : base(tilejson, tiles)
    {

    }

    /**
     * Default: "mapbox". The encoding formula for a raster-dem tileset.
     * Supported values are "mapbox" and "terrarium".
     *
     * @param value the String to set
     */
    RasterDemBuilder Encoding(MapboxEncoding value)
    {
        Parameters["encoding"] = value; return this;
    }
}

