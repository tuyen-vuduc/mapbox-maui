namespace MapboxMaui;


/// Struct of supported Source Types
/// Docs : https://docs.mapbox.com/mapbox-gl-js/style-spec/sources/
public readonly struct SourceType : INamedString
{
    public string Value { get; }

    private SourceType(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(SourceType value) => value.Value;
    public static implicit operator SourceType(string value) => new (value);

    public static readonly SourceType Vector = new ("vector");

    /// A raster tile source.
    public static readonly SourceType Raster = new ("raster");

    /// A raster DEM source.
    public static readonly SourceType RasterDem = new ("raster-dem");

    /// A GeoJSON source.
    public static readonly SourceType GeoJson = new ("geojson");

    /// An image source.
    public static readonly SourceType Image = new ("image");

    /// A model source.
    public static readonly SourceType Model = new ("model");

    /// A raster array tile source.
    // @_spi(Experimental)
    public static readonly SourceType RasterArray = new ("raster-array");

    /// A custom geometry source.
    public static readonly SourceType CustomGeometry = new ("custom-geometry");

    /// A custom raster source.
    // @_spi(Experimental)
    public static readonly SourceType CustomRaster = new ("custom-raster");

}