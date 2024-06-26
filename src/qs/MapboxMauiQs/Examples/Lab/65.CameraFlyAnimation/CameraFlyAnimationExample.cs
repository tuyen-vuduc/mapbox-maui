namespace MapboxMauiQs;

public class CameraFlyAnimationExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;

    public CameraFlyAnimationExample()
	{
        iOSPage.SetUseSafeArea(this, false);

        var grid = new Grid();
		map = new MapboxView();
        grid.Children.Add(map);

        var btnMoveCamera = new Button()
        {
            Text = "Move Camera",
            VerticalOptions = LayoutOptions.End,
            HorizontalOptions = LayoutOptions.Center,
            Margin = new Thickness(24),
        };
        btnMoveCamera.Clicked += HandleMoveCamera;
        grid.Children.Add(btnMoveCamera);

        map.MapReady += Map_MapReady;
        map.StyleLoaded += Map_StyleLoaded;
        map.MapLoaded += Map_MapLoaded;

        Content = grid;
	}

    private void HandleMoveCamera(object sender, EventArgs e)
    {
        var centerLocation = new MapPosition(21.0278, 105.8342);
        var cameraOptions = new CameraOptions
        {
            Center = centerLocation,
            Zoom = 9,
        };
        map.CameraController.FlyTo(
            cameraOptions, 
            new AnimationOptions(3000L));
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }

    private void Map_MapReady(object sender, EventArgs e)
    {
        var centerLocation = new MapPosition(60.1699, 24.9384);
        var cameraOptions = new CameraOptions
        {
            Center = centerLocation,
            Zoom = 9,
        };
        map.CameraOptions = cameraOptions;
        map.MapboxStyle = MapboxStyle.STANDARD;
    }

    private void Map_MapLoaded(object sender, EventArgs e)
    {
        // Setup Styles, Annotations, etc here
    }
    private void Map_StyleLoaded(object sender, EventArgs e)
    {
    }

}