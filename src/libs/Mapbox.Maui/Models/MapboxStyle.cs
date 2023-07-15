using System.ComponentModel;

namespace MapboxMaui;

[TypeConverter(typeof(MapboxStyleTypeConverter))]
public struct MapboxStyle : INamedString
{
    public string Value { get; private set; }

    public MapboxStyle(string value)
    {
        Value = value;
    }

    public static implicit operator string(MapboxStyle mapboxStyle) => mapboxStyle.Value;

    public static explicit operator MapboxStyle(string uri) => new MapboxStyle(uri);

    public override string ToString() => $"Uri: {Value}";

    /**
     * Mapbox Streets: A complete base map, perfect for incorporating your own data. Using this
     * constant means your map style will always use the latest version and may change as we
     * improve the style.
     */
    public static readonly MapboxStyle MAPBOX_STREETS = (MapboxStyle)"mapbox://styles/mapbox/streets-v11";

    /**
     * Outdoors: A general-purpose style tailored to outdoor activities. Using this constant means
     * your map style will always use the latest version and may change as we improve the style.
     */
    public static readonly MapboxStyle OUTDOORS = (MapboxStyle)"mapbox://styles/mapbox/outdoors-v11";

    /**
     * Light: Subtle light backdrop for data visualizations. Using this constant means your map
     * style will always use the latest version and may change as we improve the style.
     */
    public static readonly MapboxStyle LIGHT = (MapboxStyle)"mapbox://styles/mapbox/light-v10";

    /**
     * Dark: Subtle dark backdrop for data visualizations. Using this constant means your map style
     * will always use the latest version and may change as we improve the style.
     */
    public static readonly MapboxStyle DARK = (MapboxStyle)"mapbox://styles/mapbox/dark-v10";

    /**
     * Satellite: A beautiful global satellite and aerial imagery layer. Using this constant means
     * your map style will always use the latest version and may change as we improve the style.
     */
    public static readonly MapboxStyle SATELLITE = (MapboxStyle)"mapbox://styles/mapbox/satellite-v9";

    /**
     * Satellite Streets: Global satellite and aerial imagery with unobtrusive labels. Using this
     * constant means your map style will always use the latest version and may change as we
     * improve the style.
     */
    public static readonly MapboxStyle SATELLITE_STREETS = (MapboxStyle)"mapbox://styles/mapbox/satellite-streets-v11";

    /**
     * Traffic Day: Color-coded roads based on live traffic congestion data. Traffic data is currently
     * available in [these select countries](https://www.mapbox.com/help/how-directions-work/#traffic-data).
     * Using this constant means your map style will always use the latest version and may change as we improve the style.
     */
    public static readonly MapboxStyle TRAFFIC_DAY = (MapboxStyle)"mapbox://styles/mapbox/traffic-day-v2";

    /**
     * Traffic Night: Color-coded roads based on live traffic congestion data, designed to maximize
     * legibility in low-light situations. Traffic data is currently available in
     * [these select countries](https://www.mapbox.com/help/how-directions-work/#traffic-data).
     * Using this constant means your map style will always use the latest version and may change as we improve the style.
     */
    public static readonly MapboxStyle TRAFFIC_NIGHT = (MapboxStyle)"mapbox://styles/mapbox/traffic-night-v2";
}

public interface INamedString
{
    string Value { get; }
}