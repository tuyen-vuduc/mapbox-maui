namespace MapboxMauiQs;

public class AnimatePointAnnotationExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;

    IPointAnnotationManager pointAnnotationManager;

    private int noAnimateCarNum = 10;
    private int animateCarNum = 10;
    private long animateDuration = 5000L;


    public AnimatePointAnnotationExample()
	{
        iOSPage.SetUseSafeArea(this, false);
		Content = map = new MapboxView();

        map.MapReady += Map_MapReady;
        map.MapLoaded += Map_MapLoaded;
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }

    private void Map_MapReady(object sender, EventArgs e)
    {
        var centerLocation = new MapPosition(55.665957, 12.550343);
        var cameraOptions = new CameraOptions
        {
            Center = centerLocation,
            Zoom = 12,
        };

        map.CameraOptions = cameraOptions;
        map.MapboxStyle = MapboxStyle.STANDARD;
    }

    private void Map_MapLoaded(object sender, EventArgs e)
    {
        var image = new ResolvedImage("ic_car_top", "ic_car_top");
        map.Images = new[] { image };
        // Setup Styles, Annotations, etc here
        pointAnnotationManager = map.AnnotationController.CreatePointAnnotationManager(
            "id", LayerPosition.Unknown()
            );
        pointAnnotationManager.IconPitchAlignment = IconPitchAlignment.Map;

        var noAnimateItems = new List<PointAnnotation>();
        for ( int i = 0; i< noAnimateCarNum; i++) {
            var point = RandomizePoint();
            noAnimateItems.Add(new PointAnnotation(point, Guid.NewGuid().ToString()) { 
                IconImage = "ic_car_top",
            });
        }
        pointAnnotationManager.AddAnnotations(noAnimateItems.ToArray());
    }

    private GeoJSON.Text.Geometry.Point RandomizePoint()
    {
        CoordinateBounds bounds = map.MapboxController.GetCoordinateBoundsForCamera(map.CameraOptions);
        var generator = new Random();
        var lat = bounds.Southwest.Latitude + (bounds.Northeast.Latitude - bounds.Southwest.Latitude) * generator.NextDouble();
        var lon = bounds.Southwest.Longitude + (bounds.Northeast.Longitude - bounds.Southwest.Longitude) * generator.NextDouble();
        var position = new MapPosition(lat, lon);
        return new GeoJSON.Text.Geometry.Point(position);
    }
}