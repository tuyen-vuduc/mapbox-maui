
namespace MapboxMauiQs;

public class BasicLocationPulsingCircleExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;

    public BasicLocationPulsingCircleExample()
	{
        iOSPage.SetUseSafeArea(this, false);
		Content = map = new MapboxView();

        var toggleMapStyleToolbarItem = new ToolbarItem
        {
            Text = "Toggle Map Style",
            Command = new Command(ToggleMapboxStyle),
        };
        ToolbarItems.Add(toggleMapStyleToolbarItem);

        map.MapReady += Map_MapReadyAsync;
        map.MapLoaded += Map_MapLoaded;
        map.IndicatorPositionChanged += Map_IndicatorPositionChanged;
	}

    private void ToggleMapboxStyle(object obj)
    {
        map.MapboxStyle = map.MapboxStyle == MapboxStyle.LIGHT
            ? MapboxStyle.DARK
            : MapboxStyle.LIGHT;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }

    private async void Map_MapReadyAsync(object sender, EventArgs e)
    {
        map.LocationComponent.Enabled = true;
        map.LocationComponent.PulsingEnabled = true;

        var permissionStatus = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
        if (permissionStatus == PermissionStatus.Unknown)
        {
            permissionStatus = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        }

        if (permissionStatus != PermissionStatus.Granted) {
            await DisplayAlert("Warning", "Please grant location permission to use this functionality", "Try again");
            return;
        }

        map.MapboxStyle = MapboxStyle.STANDARD;
    }

    private void Map_MapLoaded(object sender, EventArgs e)
    {
        // Setup Styles, Annotations, etc here
    }

    private void Map_IndicatorPositionChanged(object sender, IndicatorPositionChangedEventArgs e)
    {
        map.CameraController.FlyTo(
            new CameraOptions { Center = e.Position },
            new AnimationOptions(Duration: 1000)
        );
        map.GestureSettings = map.GestureSettings with
        {
            FocalPoint = map.MapboxController.GetScreenPosition(e.Position),
        };
    }
}