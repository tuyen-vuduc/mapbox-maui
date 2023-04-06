namespace Mapbox.Maui.Styles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class MapboxSource
{
    public MapboxSource(string id)
    {
        properties = new Dictionary<string, object>()
        {
            { "id", id },
        };
        volatileProperties = new Dictionary<string, object>();
    }

    public MapboxSource(string id, string type)
    {
        properties = new Dictionary<string, object>()
        {
            { MapboxSourceKey.id, id },
            { MapboxSourceKey.type, type },
        };
        volatileProperties = new Dictionary<string, object>();
    }

    private readonly Dictionary<string, object> properties;
    private readonly Dictionary<string, object> volatileProperties;

    private static class MapboxSourceKey
    {
        public const string id = nameof(id);
        public const string type = nameof(type);
    }

    public string Id => properties[MapboxSourceKey.id] as string;

    public string Type => properties.TryGetValue(MapboxSourceKey.type, out var value) &&
        value is string stringValue
        ? stringValue : (string)null;

    public MapboxSource SetProperty<T>(string name, T value)
    {
        // Not allow to use empty string as a name
        if (string.IsNullOrWhiteSpace(name)) return this;

        name = name.Trim();

        // Not allow to change id and/or type
        if (string.Equals(name, MapboxSourceKey.id, StringComparison.OrdinalIgnoreCase)) return this;
        if (string.Equals(name, MapboxSourceKey.type, StringComparison.OrdinalIgnoreCase)) return this;

        if (value == null)
        {
            properties.Remove(name);
        }
        else
        {
            properties[name] = value;
        }

        return this;
    }

    public MapboxSource SetVolatileProperty<T>(string name, T value)
    {
        // Not allow to use empty string as a name
        if (string.IsNullOrWhiteSpace(name)) return this;

        name = name.Trim();

        // Not allow to change id and/or type
        if (string.Equals(name, MapboxSourceKey.id, StringComparison.OrdinalIgnoreCase)) return this;
        if (string.Equals(name, MapboxSourceKey.type, StringComparison.OrdinalIgnoreCase)) return this;

        if (value == null)
        {
            volatileProperties.Remove(name);
        }
        else
        {
            volatileProperties[name] = value;
        }

        return this;
    }

    public T GetProperty<T>(string name, T defaultValue)
    {
        // Not allow to use empty string as a name
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid property name");

        name = name.Trim();

        if (properties.TryGetValue(name, out var value) && value is T result)
        {
            return result;
        }

        return defaultValue;
    }

    public T GetVolatileProperty<T>(string name, T defaultValue)
    {
        // Not allow to use empty string as a name
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid property name");

        name = name.Trim();

        if (volatileProperties.TryGetValue(name, out var value) && value is T result)
        {
            return result;
        }

        return defaultValue;
    }

    public ReadOnlyDictionary<string, object> Properties => new ReadOnlyDictionary<string, object>(properties);
    // Properties that only settable after the source is added to the style.
    public ReadOnlyDictionary<string, object> VolatileProperties => new ReadOnlyDictionary<string, object>(volatileProperties);
}

public class RasterDemSource : MapboxSource
{
    public RasterDemSource(string id)
        : base(id, "raster-dem")
    {
    }

    private static class RasterDemSourceKey
    {
        public const string url = nameof(url);
        public const string tiles = nameof(tiles);
        public const string bounds = nameof(bounds);
        public const string minzoom = nameof(minzoom);
        public const string maxzoom = nameof(maxzoom);
        public const string tileSize = nameof(tileSize);
        public const string attribution = nameof(attribution);
        public const string encoding = nameof(encoding);
        public const string @volatile = nameof(@volatile);
        public const string prefetchZoomDelta = "prefetch-zoom-delta";
        public const string minimumTileUpdateInterval = "minimum-tile-update-interval";
        public const string maxOverscaleFactorForParentTiles = "max-overscale-factor-for-parent-tiles";
        public const string tileRequestsDelay = "tile-requests-delay";
        public const string tileNetworkRequestsDelay = "tile-network-requests-delay";
    }

    /// <summary>
    /// A URL to a TileJSON resource. Supported protocols are `http:`, `https:`, and `mapbox://<Tileset ID>`.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public string Url
    {
        get => GetProperty<string>(RasterDemSourceKey.url, default);
        set => SetProperty<string>(RasterDemSourceKey.url, value);
    }
    RasterDemSource Url(string value)
    {
        AddProperty("url", value);
        return this;
    }

    /**
     * An array of one or more tile source URLs, as in the TileJSON spec.
     */
    RasterDemSource Tiles(List<string> value)
    {
        AddProperty("tiles", value);
        return this;
    }

    /**
     * An array containing the longitude and latitude of the southwest and northeast corners of the source's
     * bounding box in the following order: `[sw.lng, sw.lat, ne.lng, ne.lat]`. When this property is included in
     * a source, no tiles outside of the given bounds are requested by Mapbox GL.
     */
    RasterDemSource Bounds(List<double> value = default)
    {
        if (value == null)
        {
            value = new List<double>
            {
                -180.0,
                -85.051129,
                180.0,
                85.051129
            };
        }

        AddProperty("bounds", value);
        return this;
    }

    /**
     * Minimum zoom level for which tiles are available, as in the TileJSON spec.
     */
    RasterDemSource MinZoom(long value = 0)
    {
        AddProperty("minzoom", value);
        return this;
    }

    /**
     * Maximum zoom level for which tiles are available, as in the TileJSON spec. Data from tiles
     * at the maxzoom are used when displaying the map at higher zoom levels.
     */
    RasterDemSource MaxZoom(long value = 22L)
    {
        AddProperty("maxzoom", value);
        return this;
    }

    /**
     * The minimum visual size to display tiles for this layer. Only configurable for raster layers.
     */
    RasterDemSource TileSize(long value = 512L)
    {
        AddProperty("tileSize", value);
        return this;
    }

    /**
     * Contains an attribution to be displayed when the map is shown to a user.
     */
    RasterDemSource Attribution(string value)
    {
        AddProperty("attribution", value);
        return this;
    }

    /**
     * The encoding used by this source. Mapbox Terrain RGB is used by default
     */
    RasterDemSource Encoding(MapboxEncoding value)
    {
        AddProperty("encoding", value);
        return this;
    }

    /**
     * A setting to determine whether a source's tiles are cached locally.
     */
    RasterDemSource Volatile(bool value)
    {
        AddProperty("volatile", value);
        return this;
    }

    /**
     * When loading a map, if PrefetchZoomDelta is set to any number greater than 0, the map
     * will first request a tile at zoom level lower than zoom - delta, but so that
     * the zoom level is multiple of delta, in an attempt to display a full map at
     * lower resolution as quick as possible. It will get clamped at the tile source minimum zoom.
     * The default delta is 4.
     */
    RasterDemSource PrefetchZoomDelta(long value = 4L)
    {
        AddVolatileProperty("prefetch-zoom-delta", value);
        return this;
    }

    /**
     * Minimum tile update interval in seconds, which is used to throttle the tile update network requests.
     * If the given source supports loading tiles from a server, sets the minimum tile update interval.
     * Update network requests that are more frequent than the minimum tile update interval are suppressed.
     */
    RasterDemSource MinimumTileUpdateInterval(double value = 0.0)
    {
        AddVolatileProperty("minimum-tile-update-interval", value);
        return this;
    }

    /**
     * When a set of tiles for a current zoom level is being rendered and some of
     * the ideal tiles that cover the screen are not yet loaded, parent tile could be used
     * instead. This might introduce unwanted rendering side-effects, especially for raster tiles that are overscaled multiple times.
     * This property sets the maximum limit for how much a parent tile can be overscaled.
     */
    RasterDemSource MaxOverscaleFactorForParentTiles(long value)
    {
        AddVolatileProperty("max-overscale-factor-for-parent-tiles", value);
        return this;
    }

    /**
     * For the tiled sources, this property sets the tile requests delay. The given delay comes in
     * action only during an ongoing animation or gestures. It helps to avoid loading, parsing and rendering
     * of the transient tiles and thus to improve the rendering performance, especially on low-end devices.
     */
    RasterDemSource TileRequestsDelay(double value = 0.0)
    {
        AddVolatileProperty("tile-requests-delay", value);
        return this;
    }

    /**
     * For the tiled sources, this property sets the tile network requests delay. The given delay comes
     * in action only during an ongoing animation or gestures. It helps to avoid loading the transient
     * tiles from the network and thus to avoid redundant network requests. Note that tile-network-requests-delay value is
     * superseded with tile-requests-delay property value, if both are provided.
     */
    RasterDemSource TileNetworkRequestsDelay(double value = 0.0)
    {
        AddVolatileProperty("tile-network-requests-delay", value);
        return this;
    }

    /**
     * Add a TileSet to the Source.
     *
     * @param tileSet
     */
    RasterDemSource TileSet(TileSetBuilder value)
    {
        var propertyValue = new PropertyValue<object>(nameof(TileSetBuilder), value);
        Properties[propertyValue.Name] = propertyValue;

        return this;
    }
}

