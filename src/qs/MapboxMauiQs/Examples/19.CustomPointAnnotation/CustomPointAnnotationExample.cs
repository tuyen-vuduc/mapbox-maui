namespace MapboxMauiQs;

public class CustomPointAnnotationExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;

    public CustomPointAnnotationExample()
    {
        iOSPage.SetUseSafeArea(this, false);
        Content = map = new MapboxView();

        map.MapReady += Map_MapReady;
        map.MapLoaded += Map_MapLoaded;
    }

    private void Map_MapLoaded(object sender, EventArgs e)
    {
        var image = new ResolvedImage("my-custom-image-name", "star");
        map.Images = new[] { image };

        // We want to display the annotation at the center of the map's current viewport
        var centerCoordinate = map.CameraOptions.Center;

        // Make a `PointAnnotationManager` which will be responsible for managing
        // a collection of `PointAnnotion`s.
        // Annotation managers are kept alive by `AnnotationOrchestrator`
        // (`mapView.annotations`) until you explicitly destroy them
        // by calling `mapView.annotations.removeAnnotationManager(withId:)`
        var pointAnnotationManager = map.AnnotationController.CreatePointAnnotationManager(
            "pointAnnotationManager",
            LayerPosition.Unknown()
        );

        // Initialize a point annotation with a geometry ("coordinate" in this case)
        // and configure it with a custom image (sourced from the asset catalogue)
        var customPointAnnotation = new PointAnnotation(
            new GeoJSON.Text.Geometry.Point(
                new Position(centerCoordinate.Latitude, centerCoordinate.Longitude)
            )
        )
        {
            IsDraggable = true,
            IconImage = "my-custom-image-name"
        };
        //customPointAnnotation.Image = .init(image: customImage, name: "my-custom-image-name")

        // Add the annotation to the manager in order to render it on the map.
        pointAnnotationManager.AddAnnotations(customPointAnnotation);
    }

    private void Map_MapReady(object sender, EventArgs e)
    {
        var centerLocation = new Position(40.7128, -74.0060);
        var cameraOptions = new CameraOptions
        {
            Center = centerLocation,
            Zoom = 9,
        };

        map.CameraOptions = cameraOptions;
        map.MapboxStyle = MapboxStyle.MAPBOX_STREETS;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }
}