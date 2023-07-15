namespace MapboxMauiQs;

public class PointAnnotationClusteringExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;
    const string clusterLayerID = "fireHydrantClusters";

    public PointAnnotationClusteringExample()
    {
        iOSPage.SetUseSafeArea(this, false);
        Content = map = new MapboxView();

        map.MapReady += Map_MapReady;
        map.MapLoaded += Map_MapLoaded;
    }

    private void Map_MapLoaded(object sender, EventArgs e)
    {
        AddPointAnnotations();
    }

    private void Map_MapReady(object sender, EventArgs e)
    {
        // Center the map over Washington, D.C.
        var centerLocation = new Microsoft.Maui.Graphics.Point(38.889215, -77.039354);
        var cameraOptions = new CameraOptions
        {
            Center = centerLocation,
            Zoom = 11,
        };

        map.CameraOptions = cameraOptions;
        map.MapboxStyle = MapboxStyle.LIGHT;

        //// Add an additional target to the single tap gesture recognizer for when users click on a cluster
        //mapView.gestures.singleTapGestureRecognizer.addTarget(self, action: #selector(handleTap(gestureRecognizer:)))
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

    async void AddPointAnnotations()
    {
        // The image named `fire-station-11` is included in the app's Assets.xcassets bundle.
        var image = new ResolvedImage("fire-station-icon", "fire_station_11")
        {
            Sdf = true,
            IsTemplate = true,
        };

        map.Images = new[] { image };

        // Fire_Hydrants.geojson contains information about fire hydrants in Washington, D.C.
        // It was downloaded on 6/10/21 from https://opendata.dc.gov/datasets/DCGIS::fire-hydrants/about
        // Decode the GeoJSON into a feature collection on a background thread

        var geojson = await LoadGeojson().ConfigureAwait(true);
        var featureCollection = System.Text.Json.JsonSerializer.Deserialize<FeatureCollection>(geojson);

        // Create an array of annotations for each fire hydrant
        var annotations = featureCollection.Features
            .Where(x => x.Geometry is GeoJSON.Text.Geometry.Point)
            .Select(x => (GeoJSON.Text.Geometry.Point)x.Geometry)
            .Cast<GeoJSON.Text.Geometry.Point>()
            .Select(
                x => new PointAnnotation(x)
                {
                    IconImage = image.Id,
                })
            .ToArray();

        MainThread.BeginInvokeOnMainThread(() => CreateClusters(annotations));
    }

    void CreateClusters(PointAnnotation[] annotations)
    {
        // Use a step expressions (https://docs.mapbox.com/mapbox-gl-js/style-spec/#expressions-step)
        // with three steps to implement three sizes of circles:
        //   * 25 when point count is less than 50
        //   * 30 when point count is between 50 and 100
        //   * 35 when point count is greater than or equal to 100
        var circleRadiusExpression = DslExpression.Step(
            DslExpression.Get("point_count"),
            25,
            50,
            30,
            100,
            35);

        // Use a similar expression to get different colors of circles:
        //   * yellow when point count is less than 10
        //   * green when point count is between 10 and 50
        //   * cyan when point count is between 50 and 100
        //   * red when point count is between 100 and 150
        //   * orange when point count is between 150 and 250
        //   * light pink when point count is greater than or equal to 250
        var circleColorExpression = DslExpression.Step(
            DslExpression.Get("point_count"),
            Colors.Yellow,
            10,
            Colors.Green,
            50,
            Colors.Cyan,
            100,
            Colors.Red,
            150,
            Colors.Orange,
            250,
            Colors.LightPink);

        var textFieldExpression = DslExpression.Concat(
            DslExpression.String("Count:\n"),
            DslExpression.Get("sum"));

        // Create expression to get the total count of hydrants in a cluster
        var sumExpression = DslExpression.Args(
            DslExpression.Sum(
                DslExpression.Accumulated(),
                DslExpression.Get("sum")
            ),
            1
        );

        // Create a cluster property to add to each cluster
        var clusterProperties = new Dictionary<string, DslExpression> {
                { "sum", sumExpression },
            };

        // Select the options for clustering and pass them to the PointAnnotationManager to display
        var clusterOptions = new ClusterOptions
        {
            CircleRadius = (PropertyValue<double>)circleRadiusExpression,
            CircleColor = (PropertyValue<Color>)circleColorExpression,
            TextColor = Colors.Black,
            TextSize = (PropertyValue<double>)12,
            TextField = (PropertyValue<string>)textFieldExpression,
            ClusterRadius = 75,
            ClusterMaxZoom = 14,
            ClusterProperties = clusterProperties,
        };

        var pointAnnotationManager = map.AnnotationController.CreatePointAnnotationManager(
            clusterLayerID,
            LayerPosition.Unknown(),
            clusterOptions
        );

        pointAnnotationManager.AddAnnotations(annotations);

        var layerId = DeviceInfo.Current.Platform == DevicePlatform.Android
            ? clusterLayerID
            : $"mapbox-iOS-cluster-circle-layer-manager-{clusterLayerID}";
        var circleLayer = new CircleLayer(layerId)
        {
            CircleStrokeColor = Colors.Black,
            CircleStrokeWidth = 3.0,
        };
        map.Layers = new[] { circleLayer };

        //    let pointAnnotationManager = mapView.annotations.makePointAnnotationManager(id: clusterLayerID, clusterOptions: clusterOptions)
        //    pointAnnotationManager.annotations = annotations
        //    pointAnnotationManager.delegate = self

        //    // Additional properties on the text and circle layers can be modified like this below
        //    // To modify the text layer use: "mapbox-iOS-cluster-text-layer-manager-" and SymbolLayer.self
        //    do
        //            {
        //                try mapView.mapboxMap.style.updateLayer(withId: "mapbox-iOS-cluster-circle-layer-manager-" + clusterLayerID, type: CircleLayer.self) {
        //                    layer in
        //            layer.circleStrokeColor = .constant(StyleColor(.black))
        //                    layer.circleStrokeWidth = .constant(3)
        //                }
        //                }
        //                catch
        //                {
        //                    print("Updating the layer failed: \(error.localizedDescription)")
        //                }
        //                finish()
    }

    //// When a user taps on a point, query if it is a cluster.
    //// If it is a cluster get the center and zoom level it expands at
    //// then move the camera there
    //@objc func handleTap(gestureRecognizer: UITapGestureRecognizer) {
    //                let point = gestureRecognizer.location(in: mapView)

    //    mapView.mapboxMap.queryRenderedFeatures(with: point,
    //                options: RenderedQueryOptions(layerIds: ["mapbox-iOS-cluster-circle-layer-manager-" + clusterLayerID],
    //                                                                          filter: nil)) {
    //                    [weak self] result in
    //        switch result {
    //                        case .success(let queriedFeatures):
    //                            if let cluster = queriedFeatures.first?.feature,
    //               let sourceID = self?.clusterLayerID,
    //               case let.point(clusterCenter) = cluster.geometry {
    //                                self?.mapView.mapboxMap.getGeoJsonClusterExpansionZoom(forSourceId: sourceID, feature: cluster) {
    //                                    result in
    //                    switch result {
    //                                        case .success(let zoomLevel):
    //                                            let cameraOptions = CameraOptions(center: clusterCenter.coordinates, zoom: zoomLevel.value as? CGFloat)
    //                        self?.mapView.camera.ease(to: cameraOptions, duration: 1)
    //                    case .failure(let error):
    //                                            print("An error occurred: \(error.localizedDescription). Please try another cluster.")
    //                    }
    //                                }
    //                            }
    //                        case .failure(let error):
    //                            print("An error occurred: \(error.localizedDescription). Please try another cluster.")
    //        }
    //                }
    //            }

    //            // Load GeoJSON file from local bundle and decode into a `FeatureCollection`.
    //            func decodeGeoJSON(from fileName: String) throws->FeatureCollection ? {
    //                guard let path = Bundle.main.path(forResource: fileName, ofType: "geojson") else
    //                {
    //                    preconditionFailure("File '\(fileName)' not found.")
    //                }
    //                let filePath = URL(fileURLWithPath: path)
    //                var featureCollection: FeatureCollection ?
    //                do
    //                {
    //                    let data = try Data(contentsOf: filePath)
    //                    featureCollection = try JSONDecoder().decode(FeatureCollection.self, from: data)
    //    }
    //                    catch
    //                    {
    //                        print("Error parsing data: \(error)")
    //    }
    //                    return featureCollection
    //            }
}