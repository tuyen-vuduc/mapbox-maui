namespace MapboxMauiQs;

public class CameraAnimationsExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;

    public CameraAnimationsExample()
	{
        iOSPage.SetUseSafeArea(this, false);

        var grid = new Grid();
		map = new MapboxView();
        grid.Children.Add(map);

        var btnFlyCamera = new Button()
        {
            Text = "Fly to Hanoi",
        };
        btnFlyCamera.Clicked += HandleCameraFlyTo;

        var btnEaseCamera = new Button()
        {
            Text = "Ease to HCMC",
        };
        btnEaseCamera.Clicked += HandleCameraEaseTo;

        var btns = new HorizontalStackLayout
        {
            Children = {
                btnFlyCamera,
                btnEaseCamera,
            },
            VerticalOptions = LayoutOptions.End,
            HorizontalOptions = LayoutOptions.Center,
            Margin = new Thickness(24),
            Spacing = 16,
        };

        grid.Children.Add(btns);

        map.MapReady += Map_MapReady;
        map.StyleLoaded += Map_StyleLoaded;
        map.MapLoaded += Map_MapLoaded;

        Content = grid;
	}

    private void HandleCameraFlyTo(object sender, EventArgs e)
    {
        var centerLocation = new MapPosition(21.028511, 105.804817);
        var cameraOptions = new CameraOptions
        {
            Center = centerLocation,
            Zoom = 9,
        };
        map.CameraController.FlyTo(
            cameraOptions, 
            new AnimationOptions(3000L));
    }

    private void HandleCameraEaseTo(object sender, EventArgs e)
    {
        var centerLocation = new MapPosition(10.762622, 106.660172);
        var cameraOptions = new CameraOptions
        {
            Center = centerLocation,
            Zoom = 12,
        };
        map.CameraController.EaseTo(
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