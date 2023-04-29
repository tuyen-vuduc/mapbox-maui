namespace MapboxMaui.Styles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

    /// A URL to a TileJSON resource. Supported protocols are `http:`, `https:`, and `mapbox://<Tileset ID>`.
    public string Url
    {
        get => GetProperty<string>(RasterDemSourceKey.url, default);
        set => SetProperty(RasterDemSourceKey.url, value);
    }

    /// An array of one or more tile source URLs, as in the TileJSON spec.
    public List<string> Tiles
    {
        get => GetProperty<List<string>>(RasterDemSourceKey.tiles, default);
        set => SetProperty(RasterDemSourceKey.tiles, value);
    }

    /// An array containing the longitude and latitude of the southwest and northeast corners of the source's bounding box in the following order: `[sw.lng, sw.lat, ne.lng, ne.lat]`. When this property is included in a source, no tiles outside of the given bounds are requested by Mapbox GL.
    public List<double> Bounds
    {
        get => GetProperty<List<double>>(RasterDemSourceKey.bounds, default);
        set => SetProperty(RasterDemSourceKey.bounds, value);
    }

    /// Minimum zoom level for which tiles are available, as in the TileJSON spec.
    public double MinZoom
    {
        get => GetProperty<double>(RasterDemSourceKey.minzoom, default);
        set => SetProperty(RasterDemSourceKey.minzoom, value);
    }

    /// Maximum zoom level for which tiles are available, as in the TileJSON spec. Data from tiles at the maxzoom are used when displaying the map at higher zoom levels.
    public double MaxZoom
    {
        get => GetProperty<double>(RasterDemSourceKey.maxzoom, default);
        set => SetProperty(RasterDemSourceKey.maxzoom, value);
    }

    /// The minimum visual size to display tiles for this layer. Only configurable for raster layers.
    public double TileSize
    {
        get => GetProperty<double>(RasterDemSourceKey.tileSize, default);
        set => SetProperty(RasterDemSourceKey.tileSize, value);
    }

    /// Contains an attribution to be displayed when the map is shown to a user.
    public string Attribution
    {
        get => GetProperty<string>(RasterDemSourceKey.attribution, default);
        set => SetProperty(RasterDemSourceKey.attribution, value);
    }

    /// The encoding used by this source. Mapbox Terrain RGB is used by default
    public MapboxEncoding Encoding
    {
        get => GetProperty<MapboxEncoding>(RasterDemSourceKey.encoding, default);
        set => SetProperty(RasterDemSourceKey.encoding, value);
    }

    /// A setting to determine whether a source's tiles are cached locally.
    public bool Volatile
    {
        get => GetProperty<bool>(RasterDemSourceKey.@volatile, default);
        set => SetProperty(RasterDemSourceKey.@volatile, value);
    }

    /// When loading a map, if PrefetchZoomDelta is set to any number greater than 0, the map will first request a tile at zoom level lower than zoom - delta, but so that the zoom level is multiple of delta, in an attempt to display a full map at lower resolution as quick as possible. It will get clamped at the tile source minimum zoom. The default delta is 4.
    public double PrefetchZoomDelta
    {
        get => GetVolatileProperty<double>(RasterDemSourceKey.prefetchZoomDelta, default);
        set => SetVolatileProperty<double>(RasterDemSourceKey.prefetchZoomDelta, value);
    }

    /// Minimum tile update interval in seconds, which is used to throttle the tile update network requests. If the given source supports loading tiles from a server, sets the minimum tile update interval. Update network requests that are more frequent than the minimum tile update interval are suppressed.
    public double MinimumTileUpdateInterval
    {
        get => GetVolatileProperty<double>(RasterDemSourceKey.minimumTileUpdateInterval, default);
        set => SetVolatileProperty<double>(RasterDemSourceKey.minimumTileUpdateInterval, value);
    }

    /// When a set of tiles for a current zoom level is being rendered and some of the ideal tiles that cover the screen are not yet loaded, parent tile could be used instead. This might introduce unwanted rendering side-effects, especially for raster tiles that are overscaled multiple times. This property sets the maximum limit for how much a parent tile can be overscaled.
    public double MaxOverscaleFactorForParentTiles
    {
        get => GetVolatileProperty<double>(RasterDemSourceKey.maxOverscaleFactorForParentTiles, default);
        set => SetVolatileProperty<double>(RasterDemSourceKey.maxOverscaleFactorForParentTiles, value);
    }

    /// For the tiled sources, this property sets the tile requests delay. The given delay comes in action only during an ongoing animation or gestures. It helps to avoid loading, parsing and rendering of the transient tiles and thus to improve the rendering performance, especially on low-end devices.
    public double TileRequestsDelay
    {
        get => GetVolatileProperty<double>(RasterDemSourceKey.tileRequestsDelay, default);
        set => SetVolatileProperty<double>(RasterDemSourceKey.tileRequestsDelay, value);
    }

    /// For the tiled sources, this property sets the tile network requests delay. The given delay comes in action only during an ongoing animation or gestures. It helps to avoid loading the transient tiles from the network and thus to avoid redundant network requests. Note that tile-network-requests-delay value is superseded with tile-requests-delay property value, if both are provided.
    public double TileNetworkRequestsDelay
    {
        get => GetVolatileProperty<double>(RasterDemSourceKey.tileNetworkRequestsDelay, default);
        set => SetVolatileProperty<double>(RasterDemSourceKey.tileNetworkRequestsDelay, value);
    }

    public void AddTileSet(TileSet tileSet)
    {
        foreach (var kv in tileSet.Properties)
        {
            SetProperty(kv.Key, kv.Value);
        }
    }

    public void AddTileSet(string tilejson, List<string> tiles)
    {
        var tileSet = new TileSet(tilejson, tiles);

        foreach (var kv in tileSet.Properties)
        {
            SetProperty(kv.Key, kv.Value);
        }
    }
}

