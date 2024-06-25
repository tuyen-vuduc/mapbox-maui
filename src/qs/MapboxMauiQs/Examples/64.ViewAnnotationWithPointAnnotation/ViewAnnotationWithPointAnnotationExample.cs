namespace MapboxMauiQs;

public class ViewAnnotationWithPointAnnotationExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;
    IPointAnnotationManager pointAnnotationManager;
    float markerHeight = 24;

    private class Constants
    {
        public const string blueIconId = "blue";
        public const float selectedAddCoefPX = 50;
        public static readonly string markerId = Guid.NewGuid().ToString();
    }

    public ViewAnnotationWithPointAnnotationExample()
    {
        iOSPage.SetUseSafeArea(this, false);
        Content = map = new MapboxView();

        map.MapReady += Map_MapReady;
        map.MapLoaded += Map_MapLoaded;
        map.MapTapped += Map_MapTapped;
    }

    private void Map_MapTapped(object sender, MapTappedEventArgs e)
    {

    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }

    private void Map_MapReady(object sender, EventArgs e)
    {
        var centerLocation = new Position(39.7128, -75.0060);
        var cameraOptions = new CameraOptions
        {
            Center = centerLocation,
            Zoom = 7,
        };

        map.CameraOptions = cameraOptions;
        map.MapboxStyle = MapboxStyle.MAPBOX_STREETS;

        pointAnnotationManager = map.AnnotationController.CreatePointAnnotationManager(
            nameof(pointAnnotationManager),
            LayerPosition.Unknown());
    }

    private void Map_MapLoaded(object sender, EventArgs e)
    {
        var image = new ResolvedImage(Constants.blueIconId, "blue_marker_view");

        map.Images = new[] { image };


        AddPointAndViewAnnotationAt(map.CameraOptions.Center);
    }

    private void AddPointAndViewAnnotationAt(IPosition coordinate)
    {
        if (coordinate is null) return;

        AddPointAnnotationAt(coordinate);
        AddViewAnnotationAt(coordinate);
    }

    private void AddViewAnnotationAt(IPosition value)
    {
        var options = new ViewAnnotationOptions
        {
            Geometry = new GeoJSON.Text.Geometry.Point(value),
            Width = 128,
            Height = 64,
            AssociatedFeatureId = Constants.markerId,
            AllowOverlap = false,
            Anchor = ViewAnnotationAnchor.Bottom,
            OffsetY = markerHeight,
            Title = $"Lat={value.Latitude}, Lng={value.Longitude}",
        };

        map.ViewAnnotations = new[] { options };
    }

    private void AddPointAnnotationAt(IPosition value)
    {
        var pointAnnotation = new PointAnnotation(
            new GeoJSON.Text.Geometry.Point(value),
            id: Constants.markerId)
        {
            IconImage = Constants.blueIconId,
            IconAnchor = IconAnchor.Bottom,
        };

        pointAnnotationManager.AddAnnotations(pointAnnotation);
    }
}