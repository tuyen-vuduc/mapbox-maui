namespace MapboxMaui;
#if IOS
using MapboxMapsObjC;
#endif
// This file is generated.

/// Influences the y direction of the tile coordinates. The global-mercator (aka Spherical Mercator) profile is assumed.
public readonly struct Scheme : INamedString
{

    /// Slippy map tilenames scheme.
    public static readonly Scheme Xyz = new ("xyz");

    /// OSGeo spec scheme.
    public static readonly Scheme Tms = new ("tms");


    public string Value { get; }

    private Scheme(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(Scheme value) => value.Value;
    public static implicit operator Scheme(string value) => new (value);
}
public static partial class SchemeExtensions {}
#if IOS    
partial class SchemeExtensions
{
    public static MapboxMapsObjC.TMBScheme ToPlatform(this Scheme value)
    {
        return new (value.Value);
    }

    public static Scheme ToPlatform(this MapboxMapsObjC.TMBScheme value)
    {
        return value.RawValue;
    }
}
#endif
#if ANDROID    
partial class SchemeExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Sources.Generated.Scheme ToPlatform(this Scheme value)
    {
        return Com.Mapbox.Maps.Extension.Style.Sources.Generated.Scheme.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

/// The encoding used by this source. Mapbox Terrain RGB is used by default
public readonly struct Encoding : INamedString
{

    /// Terrarium format PNG tiles. See https://aws.amazon.com/es/public-datasets/terrain/ for more info.
    public static readonly Encoding Terrarium = new ("terrarium");

    /// Mapbox Terrain RGB tiles. See https://www.mapbox.com/help/access-elevation-data/#mapbox-terrain-rgb for more info.
    public static readonly Encoding Mapbox = new ("mapbox");


    public string Value { get; }

    private Encoding(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(Encoding value) => value.Value;
    public static implicit operator Encoding(string value) => new (value);
}
public static partial class EncodingExtensions {}
#if IOS    
partial class EncodingExtensions
{
    public static MapboxMapsObjC.TMBEncoding ToPlatform(this Encoding value)
    {
        return new(value.Value);
    }

    public static Encoding ToPlatform(this MapboxMapsObjC.TMBEncoding value)
    {
        return value.RawValue;
    }
}
#endif
#if ANDROID    
partial class EncodingExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Sources.Generated.Encoding ToPlatform(this Encoding value)
    {
        return Com.Mapbox.Maps.Extension.Style.Sources.Generated.Encoding.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// End of generated file.
