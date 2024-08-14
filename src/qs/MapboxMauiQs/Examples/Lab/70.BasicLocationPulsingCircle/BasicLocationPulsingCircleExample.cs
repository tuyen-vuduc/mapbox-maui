using MapboxMaui;

namespace MapboxMauiQs;

public class BasicLocationPulsingCircleExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;

    public BasicLocationPulsingCircleExample()
	{
        iOSPage.SetUseSafeArea(this, false);
		Content = map = new MapboxView();

        Title = "X";
        var openSettingsItem = new ToolbarItem
        {
            IconImageSource = "ic_settings",
            Text = "Actions",
            Command = new Command(OpenSettings),
            Order = ToolbarItemOrder.Secondary,
        };
        ToolbarItems.Add(openSettingsItem);

        map.MapReady += Map_MapReadyAsync;
        map.MapLoaded += Map_MapLoaded;
        map.IndicatorPositionChanged += Map_IndicatorPositionChanged;
	}

    private async void OpenSettings(object obj)
    {
        var action = await DisplayActionSheet(
            "Action", "Cancel", null,
            map.LocationComponent.Enabled
                ? "Hide user location" : "Show user location",
            map.LocationComponent.PulsingEnabled
                ? "Hide pulsing" : "Show pulsing",
            "Show accuracy ring",
            "Change map style"
        );

        switch (action) { 
            case "Hide user location":
            case "Show user location":
                ToggleComponent(action);
                break;
            case "Hide pulsing":
            case "Show pulsing":
                TogglePulsing(action);
                break;
            case "Show accuracy ring":
                ShowPulsingAccuracyRing(action);
                break;
            case "Change map style":
                ToggleMapboxStyle(action);
                break;
        }
    }

    private void ShowPulsingAccuracyRing(object obj)
    {
        map.LocationComponent.Enabled = true;
        map.LocationComponent.PulsingEnabled = true;
        map.LocationComponent.ShowAccuracyRing = true;
        map.LocationComponent.PulsingMaxRadius = -1;
    }

    private void TogglePulsing(object obj)
    {
        map.LocationComponent.PulsingMaxRadius = (float)(10 * DeviceDisplay.Current.MainDisplayInfo.Density);
        map.LocationComponent.PulsingEnabled = !map.LocationComponent.PulsingEnabled;
    }

    private void ToggleComponent(object obj)
    {
        map.LocationComponent.Enabled = !map.LocationComponent.Enabled;
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

        // var bounds = map.MapboxController.GetCoordinateBoundsForCamera(map.CameraController.CameraState);
        // IEnumerable<IPosition> coords = new IPosition[] {
        //         bounds.Southwest.ToPoint().Coordinates,
        //         bounds.Northeast.ToPoint().Coordinates
        //     };
        // map.MapboxController.CameraForCoordinates(
        //     coords
        //     , completion: (x) =>
        //     {

        //     });
    }
}