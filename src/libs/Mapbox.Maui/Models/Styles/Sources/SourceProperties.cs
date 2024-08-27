namespace MapboxMaui;

/// Influences the y direction of the tile coordinates. The global-mercator (aka Spherical Mercator) profile is assumed.
public readonly struct Scheme : INamedString
{
    public string Value { get; }

    private Scheme(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(Scheme value) => value.Value;
    public static implicit operator Scheme(string value) => new (value);

    public static readonly Scheme Xyz = new ("xyz");

    /// OSGeo spec scheme.
    public static readonly Scheme Tms = new ("tms");

}

/// The encoding used by this source. Mapbox Terrain RGB is used by default
public readonly struct Encoding : INamedString
{
    public string Value { get; }

    private Encoding(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(Encoding value) => value.Value;
    public static implicit operator Encoding(string value) => new (value);

    public static readonly Encoding Terrarium = new ("terrarium");

    /// Mapbox Terrain RGB tiles. See https://www.mapbox.com/help/access-elevation-data/#mapbox-terrain-rgb for more info.
    public static readonly Encoding Mapbox = new ("mapbox");

}