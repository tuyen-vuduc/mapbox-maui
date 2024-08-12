
using Microsoft.Maui.ApplicationModel;

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
            Order = ToolbarItemOrder.Secondary,
        };
        ToolbarItems.Add(toggleMapStyleToolbarItem);

        var toggleComponentToolbarItem = new ToolbarItem
        {
            Text = "Toggle Component",
            Command = new Command(ToggleComponent),
            Order = ToolbarItemOrder.Secondary,
        };
        ToolbarItems.Add(toggleComponentToolbarItem);

        var togglePulsingToolbarItem = new ToolbarItem
        {
            Text = "Toggle Pulsing",
            Command = new Command(TogglePulsing),
            Order = ToolbarItemOrder.Secondary,
        };
        ToolbarItems.Add(togglePulsingToolbarItem);

        var pulsingRingToolbarItem = new ToolbarItem
        {
            Text = "Pulsing follow accuracy Ring",
            Command = new Command(ShowPulsingAccuracyRing),
            Order = ToolbarItemOrder.Secondary,
        };
        ToolbarItems.Add(pulsingRingToolbarItem);

        map.MapReady += Map_MapReadyAsync;
        map.MapLoaded += Map_MapLoaded;
        map.IndicatorPositionChanged += Map_IndicatorPositionChanged;
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
    }
}