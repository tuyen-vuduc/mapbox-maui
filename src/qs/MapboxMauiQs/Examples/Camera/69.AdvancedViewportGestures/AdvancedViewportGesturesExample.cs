namespace MapboxMauiQs;

public class AdvancedViewportGesturesExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;

    public AdvancedViewportGesturesExample()
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
        var centerLocation = new MapPosition(21.0278, 105.8342);
        var cameraOptions = new CameraOptions
        {
            Center = centerLocation,
            Zoom = 14,
        };

        map.CameraOptions = cameraOptions;
        map.MapboxStyle = MapboxStyle.TRAFFIC_DAY;
    }

    private void Map_MapLoaded(object sender, EventArgs e)
    {
        // Setup Styles, Annotations, etc here
    }
}