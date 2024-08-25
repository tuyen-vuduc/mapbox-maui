namespace MapboxMaui.Styles;

public class RasterSource : MapboxSource
{
    public RasterSource(string id)
        : base(id, "raster")
    {
    }

    private static class RasterSourceKey
    {
        public const string url = "url";
        public const string tiles = "tiles";
        public const string bounds = "bounds";
        public const string minzoom = "minzoom";
        public const string maxzoom = "maxzoom";
        public const string tileSize = "tileSize";
        public const string scheme = "scheme";
        public const string attribution = "attribution";
        public const string @volatile = "volatile";
        public const string prefetchZoomDelta = "prefetch-zoom-delta";
        public const string tileCacheBudget = "tile-cache-budget";
        public const string minimumTileUpdateInterval = "minimum-tile-update-interval";
        public const string maxOverscaleFactorForParentTiles = "max-overscale-factor-for-parent-tiles";
        public const string tileRequestsDelay = "tile-requests-delay";
        public const string tileNetworkRequestsDelay = "tile-network-requests-delay";
    }

    /// A URL to a TileJSON resource. Supported protocols are `http:`, `https:`, and `mapbox://<Tileset ID>`. Required if `tiles` is not provided.
    public string Url
    {
        get => GetProperty<string>(
            RasterSourceKey.url,
            default
        );
        set => SetProperty(
            RasterSourceKey.url,
            value
        );
    }

    /// An array of one or more tile source URLs, as in the TileJSON spec. Required if `url` is not provided.
    public string[] Tiles
    {
        get => GetProperty<string[]>(
            RasterSourceKey.tiles,
            default
        );
        set => SetProperty(
            RasterSourceKey.tiles,
            value
        );
    }

    /// An array containing the longitude and latitude of the southwest and northeast corners of the source's bounding box in the following order: `[sw.lng, sw.lat, ne.lng, ne.lat]`. When this property is included in a source, no tiles outside of the given bounds are requested by Mapbox GL.
    /// Default value: [-180,-85.051129,180,85.051129].
    public double?[] Bounds
    {
        get => GetProperty<double?[]>(
            RasterSourceKey.bounds,
            default
        );
        set => SetProperty(
            RasterSourceKey.bounds,
            value
        );
    }

    /// Minimum zoom level for which tiles are available, as in the TileJSON spec.
    /// Default value: 0.
    public double? Minzoom
    {
        get => GetProperty<double?>(
            RasterSourceKey.minzoom,
            default
        );
        set => SetProperty(
            RasterSourceKey.minzoom,
            value
        );
    }

    /// Maximum zoom level for which tiles are available, as in the TileJSON spec. Data from tiles at the maxzoom are used when displaying the map at higher zoom levels.
    /// Default value: 22.
    public double? Maxzoom
    {
        get => GetProperty<double?>(
            RasterSourceKey.maxzoom,
            default
        );
        set => SetProperty(
            RasterSourceKey.maxzoom,
            value
        );
    }

    /// The minimum visual size to display tiles for this layer. Only configurable for raster layers.
    /// Default value: 512.
    public double? TileSize
    {
        get => GetProperty<double?>(
            RasterSourceKey.tileSize,
            default
        );
        set => SetProperty(
            RasterSourceKey.tileSize,
            value
        );
    }

    /// Influences the y direction of the tile coordinates. The global-mercator (aka Spherical Mercator) profile is assumed.
    /// Default value: "xyz".
    public Scheme? Scheme
    {
        get => GetProperty<Scheme?>(
            RasterSourceKey.scheme,
            default
        );
        set => SetProperty(
            RasterSourceKey.scheme,
            value
        );
    }

    /// Contains an attribution to be displayed when the map is shown to a user.
    public string Attribution
    {
        get => GetProperty<string>(
            RasterSourceKey.attribution,
            default
        );
        set => SetProperty(
            RasterSourceKey.attribution,
            value
        );
    }

    /// A setting to determine whether a source's tiles are cached locally.
    /// Default value: false.
    public bool? Volatile
    {
        get => GetProperty<bool?>(
            RasterSourceKey.@volatile,
                    default
                );
        set => SetProperty(
            RasterSourceKey.@volatile,
            value
        );
    }

    /// When loading a map, if PrefetchZoomDelta is set to any number greater than 0, the map will first request a tile at zoom level lower than zoom - delta, but so that the zoom level is multiple of delta, in an attempt to display a full map at lower resolution as quick as possible. It will get clamped at the tile source minimum zoom.
    /// Default value: 4.
    public double? PrefetchZoomDelta
    {
        get => GetProperty<double?>(
            RasterSourceKey.prefetchZoomDelta,
            default
        );
        set => SetProperty(
            RasterSourceKey.prefetchZoomDelta,
            value
        );
    }

    /// This property defines a source-specific resource budget, either in tile units or in megabytes. Whenever the tile cache goes over the defined limit, the least recently used tile will be evicted from the in-memory cache. Note that the current implementation does not take into account resources allocated by the visible tiles.
    public TileCacheBudgetSize TileCacheBudget
    {
        get => GetProperty<TileCacheBudgetSize>(
            RasterSourceKey.tileCacheBudget,
            default
        );
        set => SetProperty(
            RasterSourceKey.tileCacheBudget,
            value
        );
    }

    /// Minimum tile update interval in seconds, which is used to throttle the tile update network requests. If the given source supports loading tiles from a server, sets the minimum tile update interval. Update network requests that are more frequent than the minimum tile update interval are suppressed.
    /// Default value: 0.
    public double? MinimumTileUpdateInterval
    {
        get => GetProperty<double?>(
            RasterSourceKey.minimumTileUpdateInterval,
            default
        );
        set => SetProperty(
            RasterSourceKey.minimumTileUpdateInterval,
            value
        );
    }

    /// When a set of tiles for a current zoom level is being rendered and some of the ideal tiles that cover the screen are not yet loaded, parent tile could be used instead. This might introduce unwanted rendering side-effects, especially for raster tiles that are overscaled multiple times. This property sets the maximum limit for how much a parent tile can be overscaled.
    public double? MaxOverscaleFactorForParentTiles
    {
        get => GetProperty<double?>(
            RasterSourceKey.maxOverscaleFactorForParentTiles,
            default
        );
        set => SetProperty(
            RasterSourceKey.maxOverscaleFactorForParentTiles,
            value
        );
    }

    /// For the tiled sources, this property sets the tile requests delay. The given delay comes in action only during an ongoing animation or gestures. It helps to avoid loading, parsing and rendering of the transient tiles and thus to improve the rendering performance, especially on low-end devices.
    /// Default value: 0.
    public double? TileRequestsDelay
    {
        get => GetProperty<double?>(
            RasterSourceKey.tileRequestsDelay,
            default
        );
        set => SetProperty(
            RasterSourceKey.tileRequestsDelay,
            value
        );
    }

    /// For the tiled sources, this property sets the tile network requests delay. The given delay comes in action only during an ongoing animation or gestures. It helps to avoid loading the transient tiles from the network and thus to avoid redundant network requests. Note that tile-network-requests-delay value is superseded with tile-requests-delay property value, if both are provided.
    /// Default value: 0.
    public double? TileNetworkRequestsDelay
    {
        get => GetProperty<double?>(
            RasterSourceKey.tileNetworkRequestsDelay,
            default
        );
        set => SetProperty(
            RasterSourceKey.tileNetworkRequestsDelay,
            value
        );
    }
}