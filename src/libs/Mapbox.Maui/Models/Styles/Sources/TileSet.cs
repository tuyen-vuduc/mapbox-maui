namespace MapboxMaui.Styles;

public class TileSet : BaseKVContainer
{
    public TileSet(
        string tilejson,
        List<string> tiles
        ) : base()
    {
        base.SetProperty(TileSetKey.tilejson, tilejson);
        base.SetProperty(TileSetKey.tiles, tiles);
    }

    private static class TileSetKey
    {
        public const string tilejson = nameof(tilejson);
        public const string tiles = nameof(tiles);
        public const string name = nameof(name);
        public const string center = nameof(center);
        public const string bounds = nameof(bounds);
        public const string maxzoom = nameof(maxzoom);
        public const string data = nameof(data);
        public const string minzoom = nameof(minzoom);
        public const string grids = nameof(grids);
        public const string scheme = nameof(scheme);
        public const string legend = nameof(legend);
        public const string template = nameof(template);
        public const string attribution = nameof(attribution);
        public const string version = nameof(version);
        public const string description = nameof(description);
    }

    protected override BaseKVContainer SetProperty<T>(string name, T value, string group = null)
    {
        // Not allow to use empty string as a name
        if (string.IsNullOrWhiteSpace(name)) return this;

        name = name.Trim();

        // Not allow to change tilejson and/or tiles
        if (string.Equals(name, TileSetKey.tilejson, StringComparison.OrdinalIgnoreCase)) return this;
        if (string.Equals(name, TileSetKey.tiles, StringComparison.OrdinalIgnoreCase)) return this;

        return base.SetProperty(name, value, group);
    }

    /**
     * A name describing the tileset. The name can
     * contain any legal character. Implementations SHOULD NOT interpret the
     * name as HTML.
     * "name": "compositing",
     *
     * @param value the name to be set
     */
    public string Name
    {
        get => GetProperty<string>(TileSetKey.name, default);
        set => SetProperty(TileSetKey.name, value);
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
    public string Description
    {
        get => GetProperty<string>(TileSetKey.description, default);
        set => SetProperty(TileSetKey.description, value);
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
    public string Version
    {
        get => GetProperty<string>(TileSetKey.version, default);
        set => SetProperty(TileSetKey.version, value);
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
    public string Attribution
    {
        get => GetProperty<string>(TileSetKey.attribution, default);
        set => SetProperty(TileSetKey.attribution, value);
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
    public string Template
    {
        get => GetProperty<string>(TileSetKey.template, default);
        set => SetProperty(TileSetKey.template, value);
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
    public string Legend
    {
        get => GetProperty<string>(TileSetKey.legend, default);
        set => SetProperty(TileSetKey.legend, value);
    }

    /**
     * Default: "xyz". Either "xyz" or "tms". Influences the y
     * direction of the tile coordinates.
     * The global-mercator (aka Spherical Mercator) profile is assumed.
     * "scheme": "xyz"
     *
     * @param value the scheme to set
     */
    public MapboxScheme Scheme
    {
        get => GetProperty<MapboxScheme>(TileSetKey.scheme, default);
        set => SetProperty(TileSetKey.scheme, value);
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
    public List<String> Grids
    {
        get => GetProperty<List<String>>(TileSetKey.grids, default);
        set => SetProperty(TileSetKey.grids, value);
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
    public List<String> Data
    {
        get => GetProperty<List<String>>(TileSetKey.data, default);
        set => SetProperty(TileSetKey.data, value);
    }

    /**
     * Default to 0. &gt;= 0, &lt; 22. An integer specifying the minimum zoom level.
     *
     * @param value the minZoom level to set
     */
    public int MinZoom
    {
        get => GetProperty<int>(TileSetKey.minzoom, default);
        set => SetProperty(TileSetKey.minzoom, value);
    }

    /**
     * Default to 30. &gt;= 0, &lt;= 22. An integer specifying the maximum zoom level.
     *
     * @param value the maxZoom level to set
     */
    public int MaxZoom
    {
        get => GetProperty<int>(TileSetKey.maxzoom, default);
        set => SetProperty(TileSetKey.maxzoom, value);
    }

    /**
     * Default: [-180, -90, 180, 90]. The maximum extent of available map tiles. Bounds MUST define an area
     * covered by all zoom levels. The bounds are represented in WGS:84
     * latitude and longitude values, in the order left, bottom, right, top.
     * Values may be integers or floating point numbers.
     *
     * @param value the Double list to set
     */
    public int Bounds
    {
        get => GetProperty<int>(TileSetKey.bounds, default);
        set => SetProperty(TileSetKey.bounds, value);
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
    public List<double> Center
    {
        get => GetProperty<List<double>>(TileSetKey.center, default);
        set => SetProperty(TileSetKey.center, value);
    }
}