namespace MapboxMauiQs;

public partial class BasicMapExample : ContentPage, IExamplePage, IQueryAttributable
{
    IExampleInfo info;

    public BasicMapExample()
	{
		InitializeComponent();
        iOSPage.SetUseSafeArea(this, false);

        map.MapReady += Map_MapReady;
	}

    private void Map_MapReady(object sender, EventArgs e)
    {
        map.ScaleBarVisibility = MapboxMaui.OrnamentVisibility.Visible;
        map.MapboxStyle = MapboxStyle.MAPBOX_STREETS;
        map.CameraOptions = new CameraOptions
        {
            Center = new Point(21.028511, 105.804817),
            Zoom = 12,
        };
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }
}