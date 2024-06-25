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
        // Setup Styles, Annotations, etc here
        pointAnnotationManager = map.AnnotationController.CreatePointAnnotationManager(
            "id", LayerPosition.Unknown()
            );
        pointAnnotationManager.IconPitchAlignment = IconPitchAlignment.Map;

        var noAnimateItems = new List<PointAnnotation>();
        for ( int i = 0; i< noAnimateCarNum; i++) {
            //noAnimateItems.Add(new PointAnnotation
            //{

            //});
        }
    }
}