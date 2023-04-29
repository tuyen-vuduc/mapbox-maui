namespace MapboxMaui.Styles;

public class RasterDem : TileSet
{
    public RasterDem(
        string tilejson,
        List<string> tiles)
        : base(tilejson, tiles)
    {

    }

    private static class RasterDemKey
    {
        public const string encoding = nameof(encoding);
    }

    /**
     * Default: "mapbox". The encoding formula for a raster-dem tileset.
     * Supported values are "mapbox" and "terrarium".
     *
     * @param value the String to set
     */
    public MapboxEncoding Encoding
    {
        get => GetProperty<MapboxEncoding>(RasterDemKey.encoding, default);
        set => SetProperty(RasterDemKey.encoding, value);
    }
}

