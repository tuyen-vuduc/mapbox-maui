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
        var centerLocation = new Point(39.7128, -75.0060);
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

    private void AddPointAndViewAnnotationAt(Point? coordinate)
    {
        if (coordinate is null) return;

        AddPointAnnotationAt(coordinate.Value);
        AddViewAnnotationAt(coordinate.Value);
    }

    private void AddViewAnnotationAt(Point value)
    {
        var options = new ViewAnnotationOptions
        {
            Geometry = new GeoJSON.Text.Geometry.Point(
                new Position(value.X, value.Y)),
            Width = 128,
            Height = 64,
            AssociatedFeatureId = Constants.markerId,
            AllowOverlap = false,
            Anchor = ViewAnnotationAnchor.Bottom,
            OffsetY = markerHeight,
            Title = $"Lat={value.X}, Lng={value.Y}",
        };

        map.ViewAnnotations = new[] { options };
    }

    private void AddPointAnnotationAt(Point value)
    {
        var pointAnnotation = new PointAnnotation(
            new GeoJSON.Text.Geometry.Point(
                new Position(value.X, value.Y)),
            id: Constants.markerId)
        {
            IconImage = Constants.blueIconId,
            IconAnchor = IconAnchor.Bottom,
        };

        pointAnnotationManager.AddAnnotations(pointAnnotation);
    }
}