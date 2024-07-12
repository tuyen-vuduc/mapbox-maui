﻿using MapboxMaui.Expressions;

namespace MapboxMaui.Annotations;

public class ClusterOptions
{
    /// The circle radius of the cluster items, 18 by default. Units in pixels.
    public PropertyValue<double> CircleRadius { get; set; }

    /// The circle color, black by default.
    public PropertyValue<Color> CircleColor { get; set; }

    /// The text color of cluster item, white by default
    public PropertyValue<Color> TextColor { get; set; }

    /// The text size of cluster item, 12 by default. Units in pixels.
    public PropertyValue<double> TextSize { get; set; }

    /// Value to use for a text label of the cluster. `get("point_count")` by default which
    /// will show the count of points in the cluster
    public PropertyValue<string> TextField { get; set; }

    /// Radius of each cluster if clustering is enabled. A value of 512 indicates a radius equal
    /// to the width of a tile, 50 by default. Value must be greater than or equal to 0.
    public double ClusterRadius { get; set; } = 50;

    /// Max zoom on which to cluster points if clustering is enabled. Defaults to one zoom less
    /// than maxzoom (so that last zoom features are not clustered). Clusters are re-evaluated at integer zoom
    /// levels so setting clusterMaxZoom to 14 means the clusters will be displayed until z15.
    public double ClusterMaxZoom { get; set; } = 14;

    /// Minimum number of points necessary to form a cluster if clustering is enabled. Defaults to `2`.
    public double ClusterMinPoints { get; set; } = 2;

    /// An object defining custom properties on the generated clusters if clustering is enabled, aggregating values from
    /// clustered points. Has the form `{"property_name": [operator, map_expression]}`.
    /// `operator` is any expression function that accepts at
    /// least 2 operands (e.g. `"+"` or `"max"`) — it accumulates the property value from clusters/points the
    /// cluster contains; `map_expression` produces the value of a single point. Example:
    ///
    /// ``Expression`` syntax:
    /// ```
    /// let expression = Exp(.sum) {
    ///     Exp(.get) { "scalerank" }
    /// }
    /// clusterProperties: ["sum": expression]
    /// ```
    ///
    /// JSON syntax:
    /// `{"sum": ["+", ["get", "scalerank"]]}`
    ///
    /// For more advanced use cases, in place of `operator`, you can use a custom reduce expression that references a special `["accumulated"]` value. Example:
    ///
    /// ``Expression`` syntax:
    /// ```
    /// let expression = Exp {
    ///     Exp(.sum) {
    ///         Exp(.accumulated)
    ///         Exp(.get) { "sum" }
    ///     }
    ///     Exp(.get) { "scalerank" }
    /// }
    /// clusterProperties: ["sum": expression]
    /// ```
    /// 
    /// JSON syntax:
    /// `{"sum": [["+", ["accumulated"], ["get", "sum"]], ["get", "scalerank"]]}`
    public IDictionary<string, DslExpression> ClusterProperties { get; set; }
}

