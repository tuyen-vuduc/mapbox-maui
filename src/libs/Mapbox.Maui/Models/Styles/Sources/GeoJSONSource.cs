using GeoJSON.Text;

namespace MapboxMaui.Styles;

public class GeoJSONSource : MapboxSource
{
    public GeoJSONSource(string id)
        : base(id, "geojson")
    {
        SetProperty(GeoJSONSourceKey.data, "");
    }

    /// A URL to a GeoJSON file, or inline GeoJSON.
    public IGeoJSONObject Data
    {
        get;
        set;
    }

    /// Maximum zoom level at which to create vector tiles (higher means greater detail at high zoom levels).
    public double? Maxzoom
    {
        get => GetProperty<double?>(
            GeoJSONSourceKey.maxzoom,
            default
        );
        set => SetProperty(
            GeoJSONSourceKey.maxzoom,
            value
        );
    }

    /// Contains an attribution to be displayed when the map is shown to a user.
    public string Attribution
    {
        get => GetProperty<string>(
            GeoJSONSourceKey.attribution,
            default
        );
        set => SetProperty(
            GeoJSONSourceKey.attribution,
            value
        );
    }

    /// Size of the tile buffer on each side. A value of 0 produces no buffer. A value of 512 produces a buffer as wide as the tile itself. Larger values produce fewer rendering artifacts near tile edges and slower performance.
    public double? Buffer
    {
        get => GetProperty<double?>(
            GeoJSONSourceKey.buffer,
            default
        );
        set => SetProperty(
            GeoJSONSourceKey.buffer,
            value
        );
    }

    /// Douglas-Peucker simplification tolerance (higher means simpler geometries and faster performance).
    public double? Tolerance
    {
        get => GetProperty<double?>(
            GeoJSONSourceKey.tolerance,
            default
        );
        set => SetProperty(
            GeoJSONSourceKey.tolerance,
            value
        );
    }

    /// If the data is a collection of point features, setting this to true clusters the points by radius into groups. Cluster groups become new `Point` features in the source with additional properties:
    ///  * `cluster` Is `true` if the point is a cluster
    ///  * `cluster_id` A unqiue id for the cluster to be used in conjunction with the [cluster inspection methods](https://www.mapbox.com/mapbox-gl-js/api/#geojsonsource#getclusterexpansionzoom)
    ///  * `point_count` Number of original points grouped into this cluster
    ///  * `point_count_abbreviated` An abbreviated point count
    public bool? Cluster
    {
        get => GetProperty<bool?>(
            GeoJSONSourceKey.cluster,
            default
        );
        set => SetProperty(
            GeoJSONSourceKey.cluster,
            value
        );
    }

    /// Radius of each cluster if clustering is enabled. A value of 512 indicates a radius equal to the width of a tile.
    public double? ClusterRadius
    {
        get => GetProperty<double?>(
            GeoJSONSourceKey.clusterRadius,
            default
        );
        set => SetProperty(
            GeoJSONSourceKey.clusterRadius,
            value
        );
    }

    /// Max zoom on which to cluster points if clustering is enabled. Defaults to one zoom less than maxzoom (so that last zoom features are not clustered). Clusters are re-evaluated at integer zoom levels so setting clusterMaxZoom to 14 means the clusters will be displayed until z15.
    public double? ClusterMaxZoom
    {
        get => GetProperty<double?>(
            GeoJSONSourceKey.clusterMaxZoom,
            default
        );
        set => SetProperty(
            GeoJSONSourceKey.clusterMaxZoom,
            value
        );
    }

    /// An object defining custom properties on the generated clusters if clustering is enabled, aggregating values from clustered points. Has the form `{"property_name": [operator, map_expression]}`. `operator` is any expression function that accepts at least 2 operands (e.g. `"+"` or `"max"`) — it accumulates the property value from clusters/points the cluster contains; `map_expression` produces the value of a single point.
    ///
    /// Example: `{"sum": ["+", ["get", "scalerank"]]}`.
    ///
    /// For more advanced use cases, in place of `operator`, you can use a custom reduce expression that references a special `["accumulated"]` value, e.g.:
    /// `{"sum": [["+", ["accumulated"], ["get", "sum"]], ["get", "scalerank"]]}`
    public IDictionary<string, object> ClusterProperties
    {
        get => GetProperty<IDictionary<string, object>>(
            GeoJSONSourceKey.clusterProperties,
            default
        );
        set => SetProperty(
            GeoJSONSourceKey.clusterProperties,
            value
        );
    }

    /// Whether to calculate line distance metrics. This is required for line layers that specify `line-gradient` values.
    public bool? LineMetrics
    {
        get => GetProperty<bool?>(
            GeoJSONSourceKey.lineMetrics,
            default
        );
        set => SetProperty(
            GeoJSONSourceKey.lineMetrics,
            value
        );
    }

    /// Whether to generate ids for the geojson features. When enabled, the `feature.id` property will be auto assigned based on its index in the `features` array, over-writing any previous values.
    public bool? GenerateId
    {
        get => GetProperty<bool?>(
            GeoJSONSourceKey.generateId,
            default
        );
        set => SetProperty(
            GeoJSONSourceKey.generateId,
            value
        );
    }

    /// A property to use as a feature id (for feature state). Either a property name, or an object of the form `{<sourceLayer>: <propertyName>}`.
    public PromoteId PromoteId
    {
        get => GetProperty<PromoteId>(
            GeoJSONSourceKey.promoteId,
            default
        );
        set => SetProperty(
            GeoJSONSourceKey.promoteId,
            value
        );
    }

    /// When loading a map, if PrefetchZoomDelta is set to any number greater than 0, the map will first request a tile at zoom level lower than zoom - delta, but so that the zoom level is multiple of delta, in an attempt to display a full map at lower resolution as quick as possible. It will get clamped at the tile source minimum zoom. The default delta is 4.
    public double? PrefetchZoomDelta
    {
        get => GetProperty<double?>(
            GeoJSONSourceKey.prefetchZoomDelta,
            default
        );
        set => SetProperty(
            GeoJSONSourceKey.prefetchZoomDelta,
            value
        );
    }

    private static class GeoJSONSourceKey
    {
        public const string data = "data";
        public const string maxzoom = "maxzoom";
        public const string attribution = "attribution";
        public const string buffer = "buffer";
        public const string tolerance = "tolerance";
        public const string cluster = "cluster";
        public const string clusterRadius = "clusterRadius";
        public const string clusterMaxZoom = "clusterMaxZoom";
        public const string clusterProperties = "clusterProperties";
        public const string lineMetrics = "lineMetrics";
        public const string generateId = "generateId";
        public const string promoteId = "promoteId";
        public const string prefetchZoomDelta = "prefetch-zoom-delta";
    }
}

