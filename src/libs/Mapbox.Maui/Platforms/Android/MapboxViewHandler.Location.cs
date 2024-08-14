using Com.Mapbox.Maps.Plugins.Locationcomponent;
using PlatformView = AndroidX.Fragment.App.FragmentContainerView;

namespace MapboxMaui;

public partial class MapboxViewHandler : Locations.ILocationComponentPlugin
{
    private ILocationComponentPlugin GetPlugin()
    {
        var mapView = PlatformView.GetMapView();
        if (mapView is null) return null;

        return LocationComponentUtils.GetLocationComponent(mapView);
    }

    public bool Enabled
    {
        get => GetPlugin()?.Enabled ?? false;
        set => GetPlugin().Enabled = value;
	}

	public bool PulsingEnabled
	{
		get => GetPlugin()?.PulsingEnabled ?? false;
		set => GetPlugin().PulsingEnabled = value;
	}
    public bool ShowAccuracyRing
	{
		get => GetPlugin()?.ShowAccuracyRing ?? false;
		set => GetPlugin().ShowAccuracyRing = value;
	}
	public float PulsingMaxRadius
	{
		get => GetPlugin()?.PulsingMaxRadius ?? 0;
		set => GetPlugin().PulsingMaxRadius = value;
	}
}
