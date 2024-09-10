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
        map.MapboxStyle = MapboxStyle.STANDARD;
        map.CameraOptions = new CameraOptions
        {
            Center = new MapPosition(41.879, -87.635),
            Zoom = 16,
            Bearing = 12,
            Pitch = 60,
        };
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }
}