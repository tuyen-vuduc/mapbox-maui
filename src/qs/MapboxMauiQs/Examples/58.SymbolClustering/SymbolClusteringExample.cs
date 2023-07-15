namespace MapboxMauiQs;

public class SymbolClusteringExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;

    public SymbolClusteringExample()
    {
        iOSPage.SetUseSafeArea(this, false);
        Content = map = new MapboxView();

        map.MapReady += Map_MapReady;
        map.MapLoaded += Map_MapLoaded;
    }

    private async void Map_MapLoaded(object sender, EventArgs e)
    {
        var geojson = await LoadGeojson().ConfigureAwait(true);

        var image = new ResolvedImage("fire-station-icon", "fire_station_11")
        {
            Sdf = true,
            IsTemplate = true,
        };

        map.Images = new[] { image };

        IGeoJSONObject geojsonObj = new RawGeoJSONObject(geojson);
        const string sourceID = "fire-hydrant-source";
        var source = new GeoJSONSource(sourceID)
        {
            Data = geojsonObj,
            Cluster = true,
            ClusterRadius = 75,
        };

        // Create expression to identify the max flow rate of one hydrant in the cluster
        // ["max", ["get", "FLOW"]]
        var maxExpression = DslExpression.Max(
            DslExpression.Get("FLOW"));

        // Create expression to determine if a hydrant with EngineID E-9 is in the cluster
        // ["any", ["==", ["get", "ENGINEID"], "E-9"]]
        var ine9Expression = DslExpression.Any(
            DslExpression.Eq(
                DslExpression.Get("ENGINEID"),
                "E-9"
                ));

        // Create expression to get the sum of all of the flow rates in the cluster
        // [["+",["accumulated"],["get", "sum"]],["get", "FLOW"]]
        var sumExpression = DslExpression.Args(
            DslExpression.Sum(
                DslExpression.Accumulated(),
                DslExpression.Get("sum")),
            DslExpression.Get("FLOW"));

        // Add the expressions to the cluster as ClusterProperties so they can be accessed below
        var clusterProperties = new Dictionary<string, object> {
            { "max", maxExpression },
            { "in_e9", ine9Expression },
            { "sum", sumExpression }
        };
        source.ClusterProperties = clusterProperties;

        map.Sources = new[] { source };

        var clusteredLayer = CreateClusteredLayer(sourceID);
        var unclusteredLayer = CreateUnclusteredLayer(sourceID, image);
        var clusterCountLayer = CreateNumberLayer(sourceID);
        unclusteredLayer.LayerPosition = LayerPosition.Below(clusteredLayer.Id);

        map.Layers = new MapboxLayer[] { clusteredLayer, unclusteredLayer, clusterCountLayer, };
    }

    static CircleLayer CreateClusteredLayer(string sourceId)
    {
        // Create a symbol layer to represent the clustered points.
        var clusteredLayer = new CircleLayer("clustered-circle-layer")
        {
            Source = sourceId,
            // Filter out unclustered features by checking for `point_count`. This
            // is added to clusters when the cluster is created. If your source
            // data includes a `point_count` property, consider checking
            // for `cluster_id`.
            Filter = DslExpression.Has("point_count"),

            // Set the color of the icons based on the number of points within
            // a given cluster. The first value is a default value.
            CircleColor = (PropertyValue<Color>)DslExpression.Step(
                DslExpression.Get("point_count"),
                Colors.Green,
                50,
                Colors.Blue,
                100,
                Colors.Red),

            CircleRadius = 25.0,
        };

        return clusteredLayer;
    }

    static SymbolLayer CreateUnclusteredLayer(string sourceId, ResolvedImage image)
    {
        // Create a symbol layer to represent the points that aren't clustered.
        var unclusteredLayer = new SymbolLayer("unclustered-point-layer")
        {
            Source = sourceId,
            // Filter out clusters by checking for `point_count`.
            Filter = DslExpression.Not(
                DslExpression.Has("point_count")),

            IconImage = image,
            IconColor = Colors.White,

            // Rotate the icon image based on the recorded water flow.
            // The `mod` operator allows you to use the remainder after dividing
            // the specified values.
            IconRotate = (PropertyValue<Double>)DslExpression.Mod(
                DslExpression.Get("FLOW"),
                360),
        };

        return unclusteredLayer;
    }

    static SymbolLayer CreateNumberLayer(string sourceId)
    {
        var numberLayer = new SymbolLayer("cluster-count-layer")
        {
            Source = sourceId,
            // check whether the point feature is clustered
            Filter = DslExpression.Has("point_count"),

            // Display the value for 'point_count' in the text field
            TextField = (PropertyValue<string>)DslExpression.Get("point_count"),
            TextSize = 12.0,
        };

        return numberLayer;
    }

    private void Map_MapReady(object sender, EventArgs e)
    {
        // Setup Map here
        var center = new Point(38.889215, -77.039354);
        var cameraOptions = new CameraOptions
        {
            Center = center,
            Zoom = 11,
        };

        map.CameraOptions = cameraOptions;
        map.MapboxStyle = MapboxStyle.DARK;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }

    async Task<string> LoadGeojson()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("Fire_Hydrants.geojson");
        using var reader = new StreamReader(stream);

        return reader.ReadToEnd();
    }
}