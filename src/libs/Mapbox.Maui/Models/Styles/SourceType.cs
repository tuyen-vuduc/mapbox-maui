namespace MapboxMaui;
#if IOS
using MapboxMapsObjC;
#endif

/// Enum of Source Types
/// Docs : https://docs.mapbox.com/mapbox-gl-js/style-spec/sources/
public readonly struct SourceType : INamedString
{
    /// A vector tile source.
    public static readonly SourceType Vector = new ("vector");

    /// A raster tile source.
    public static readonly SourceType Raster = new ("raster");

    /// A raster DEM source.
    public static readonly SourceType RasterDem = new ("raster-dem");

    /// A GeoJSON source.
    public static readonly SourceType GeoJson = new ("geojson");

    /// An image source.
    public static readonly SourceType Image = new ("image");

    /// A model source
    public static readonly SourceType Model = new ("model");


    public string Value { get; }

    private SourceType(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(SourceType value) => value.Value;
    public static implicit operator SourceType(string value) => new (value);
}
public static partial class SourceTypeExtensions {}
#if IOS    
partial class SourceTypeExtensions
{
    public static MapboxMapsObjC.TMBSourceType ToPlatform(this SourceType value)
    {
        return new(value.Value);
    }

    public static SourceType ToPlatform(this MapboxMapsObjC.TMBSourceType value)
    {
        return value.RawValue;
    }
}
#endif


    /// The associated Swift struct type
