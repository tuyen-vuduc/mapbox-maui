using Mapbox.Maui;

namespace MapboxMauiQs;

public partial class BasicMapExample : ContentPage, IExamplePage
{
	public BasicMapExample()
	{
		InitializeComponent();

        map.MapReady += Map_MapReady;
	}

    private void Map_MapReady(object sender, EventArgs e)
    {
        map.ScaleBarVisibility = Mapbox.Maui.OrnamentVisibility.Visible;
        map.MapboxStyle = (MapboxStyle)MapboxBuiltInStyle.MapboxStreets;
        map.CameraOptions = new CameraOptions
        {
            Center = new Point(21.028511, 105.804817),
            Zoom = 12,
        };
    }
}