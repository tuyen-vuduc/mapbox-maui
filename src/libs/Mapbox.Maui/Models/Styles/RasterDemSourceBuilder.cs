namespace Mapbox.Maui.Styles;
using System;
using System.Collections.Generic;


public abstract class BaseSourceBuilder
{
    public string Id { get; init; }

    protected BaseSourceBuilder(string id)
    {
        Id = id;
    }
}

public class RasterDemSourceBuilder : BaseSourceBuilder
{
    public RasterDemSourceBuilder(string id)
        : base(id)
    {
        Properties = new Dictionary<string, PropertyValue<object>>();
        VolatileProperties = new Dictionary<string, PropertyValue<object>>();
    }

    public IDictionary<string, PropertyValue<object>> Properties { get; private set; }
    // Properties that only settable after the source is added to the style.
    public IDictionary<string, PropertyValue<object>> VolatileProperties { get; private set; }

    /**
     * A URL to a TileJSON resource. Supported protocols are `http:`, `https:`, and `mapbox://<Tileset ID>`.
     */
    RasterDemSourceBuilder Url(string value)
    {
        var propertyValue = new PropertyValue<object>("url", value);
        Properties[propertyValue.Name] = propertyValue;

        return this;
    }

    /**
     * An array of one or more tile source URLs, as in the TileJSON spec.
     */
    RasterDemSourceBuilder Tiles(List<string> value)
    {
        var propertyValue = new PropertyValue<object>("tiles", value);
        Properties[propertyValue.Name] = propertyValue;

        return this;
    }

    /**
     * An array containing the longitude and latitude of the southwest and northeast corners of the source's
     * bounding box in the following order: `[sw.lng, sw.lat, ne.lng, ne.lat]`. When this property is included in
     * a source, no tiles outside of the given bounds are requested by Mapbox GL.
     */
    RasterDemSourceBuilder Bounds(List<double> value = default)
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

        var propertyValue = new PropertyValue<object>("bounds", value);
        Properties[propertyValue.Name] = propertyValue;

        return this;
    }

    /**
     * Minimum zoom level for which tiles are available, as in the TileJSON spec.
     */
    RasterDemSourceBuilder MinZoom(long value = 0)
    {
        var propertyValue = new PropertyValue<object>("minzoom", value);
        Properties[propertyValue.Name] = propertyValue;

        return this;
    }

    /**
     * Maximum zoom level for which tiles are available, as in the TileJSON spec. Data from tiles
     * at the maxzoom are used when displaying the map at higher zoom levels.
     */
    RasterDemSourceBuilder MaxZoom(long value = 22L)
    {
        var propertyValue = new PropertyValue<object>("maxzoom", value);
        Properties[propertyValue.Name] = propertyValue;

        return this;
    }

    /**
     * The minimum visual size to display tiles for this layer. Only configurable for raster layers.
     */
    RasterDemSourceBuilder TileSize(long value = 512L)
    {
        var propertyValue = new PropertyValue<object>("tileSize", value);
        Properties[propertyValue.Name] = propertyValue;

        return this;
    }

    /**
     * Contains an attribution to be displayed when the map is shown to a user.
     */
    RasterDemSourceBuilder Attribution(string value)
    {
        var propertyValue = new PropertyValue<object>("attribution", value);
        Properties[propertyValue.Name] = propertyValue;

        return this;
    }

    /**
     * The encoding used by this source. Mapbox Terrain RGB is used by default
     */
    RasterDemSourceBuilder Encoding(MapboxEncoding value)
    {
        var propertyValue = new PropertyValue<object>("encoding", value);
        Properties[propertyValue.Name] = propertyValue;

        return this;
    }

    /**
     * A setting to determine whether a source's tiles are cached locally.
     */
    RasterDemSourceBuilder Volatile(bool value)
    {
        var propertyValue = new PropertyValue<object>("volatile", value);
        Properties[propertyValue.Name] = propertyValue;

        return this;
    }

    /**
     * When loading a map, if PrefetchZoomDelta is set to any number greater than 0, the map
     * will first request a tile at zoom level lower than zoom - delta, but so that
     * the zoom level is multiple of delta, in an attempt to display a full map at
     * lower resolution as quick as possible. It will get clamped at the tile source minimum zoom.
     * The default delta is 4.
     */
    RasterDemSourceBuilder PrefetchZoomDelta(long value = 4L)
    {
        var propertyValue = new PropertyValue<object>("prefetch-zoom-delta", value);
        VolatileProperties[propertyValue.Name] = propertyValue;

        return this;
    }

    /**
     * Minimum tile update interval in seconds, which is used to throttle the tile update network requests.
     * If the given source supports loading tiles from a server, sets the minimum tile update interval.
     * Update network requests that are more frequent than the minimum tile update interval are suppressed.
     */
    RasterDemSourceBuilder MinimumTileUpdateInterval(double value = 0.0)
    {
        var propertyValue = new PropertyValue<object>("minimum-tile-update-interval", value);
        VolatileProperties[propertyValue.Name] = propertyValue;

        return this;
    }

    /**
     * When a set of tiles for a current zoom level is being rendered and some of
     * the ideal tiles that cover the screen are not yet loaded, parent tile could be used
     * instead. This might introduce unwanted rendering side-effects, especially for raster tiles that are overscaled multiple times.
     * This property sets the maximum limit for how much a parent tile can be overscaled.
     */
    RasterDemSourceBuilder MaxOverscaleFactorForParentTiles(long value)
    {
        var propertyValue = new PropertyValue<object>("max-overscale-factor-for-parent-tiles", value);
        VolatileProperties[propertyValue.Name] = propertyValue;

        return this;
    }

    /**
     * For the tiled sources, this property sets the tile requests delay. The given delay comes in
     * action only during an ongoing animation or gestures. It helps to avoid loading, parsing and rendering
     * of the transient tiles and thus to improve the rendering performance, especially on low-end devices.
     */
    RasterDemSourceBuilder TileRequestsDelay(double value = 0.0)
    {
        var propertyValue = new PropertyValue<object>("tile-requests-delay", value);
        VolatileProperties[propertyValue.Name] = propertyValue;

        return this;
    }

    /**
     * For the tiled sources, this property sets the tile network requests delay. The given delay comes
     * in action only during an ongoing animation or gestures. It helps to avoid loading the transient
     * tiles from the network and thus to avoid redundant network requests. Note that tile-network-requests-delay value is
     * superseded with tile-requests-delay property value, if both are provided.
     */
    RasterDemSourceBuilder TileNetworkRequestsDelay(double value = 0.0)
    {
        var propertyValue = new PropertyValue<object>("tile-network-requests-delay", value);
        VolatileProperties[propertyValue.Name] = propertyValue;

        return this;
    }

    /**
     * Add a TileSet to the Source.
     *
     * @param tileSet
     */
    RasterDemSourceBuilder TileSet(TileSetBuilder value)
    {
        var propertyValue = new PropertyValue<object>(nameof(TileSetBuilder), value);
        Properties[propertyValue.Name] = propertyValue;

        return this;
    }
}

