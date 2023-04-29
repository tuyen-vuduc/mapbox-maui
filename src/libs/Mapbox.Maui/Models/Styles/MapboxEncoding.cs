namespace MapboxMaui.Styles;

public struct MapboxEncoding : INamedString
{
    public string Value { get; }

    private MapboxEncoding(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator string(MapboxEncoding encoding) => encoding.Value;

    /// <summary>
    /// Terrarium format PNG tiles. See https://aws.amazon.com/es/public-datasets/terrain/ for more info.
    /// </summary>
    public static readonly MapboxEncoding Terrarium = new MapboxEncoding("terrarium");

    /// <summary>
    /// Mapbox Terrain RGB tiles. See https://www.mapbox.com/help/access-elevation-data/#mapbox-terrain-rgb for more info.
    /// </summary>
    public static readonly MapboxEncoding Mapbox = new MapboxEncoding("mapbox");
}

