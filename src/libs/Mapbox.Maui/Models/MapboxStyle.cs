using System.ComponentModel;

namespace Mapbox.Maui;

[TypeConverter(typeof(MapboxStyleTypeConverter))]
public struct MapboxStyle
{
    public string Uri { get; private set; }
    public MapboxBuiltInStyle BuiltInStyle { get; private set; }

    public MapboxStyle(string uri)
    {
        Uri = uri;
        BuiltInStyle = MapboxBuiltInStyle.None;
    }

    public MapboxStyle(MapboxBuiltInStyle builtInStyle)
    {
        BuiltInStyle = builtInStyle;
        Uri = null;
    }

    public static implicit operator string(MapboxStyle mapboxStyle) => mapboxStyle.BuiltInStyle != MapboxBuiltInStyle.None
        && !string.IsNullOrWhiteSpace(mapboxStyle.Uri)
        ? mapboxStyle.Uri
        : mapboxStyle.BuiltInStyle.ToString();

    public static explicit operator MapboxBuiltInStyle(MapboxStyle mapboxStyle) => mapboxStyle.BuiltInStyle;

    public static explicit operator MapboxStyle(MapboxBuiltInStyle builtInStyle) => new MapboxStyle
    {
        BuiltInStyle = builtInStyle,
    };

    public static explicit operator MapboxStyle(string uri) => new MapboxStyle
    {
        Uri = uri,
    };

    public override string ToString() => $"BuiltinStyle: {BuiltInStyle}, Uri: {Uri}";
}
