using PlatformView = AndroidX.Fragment.App.FragmentContainerView;
using MapboxMapsStyle = Com.Mapbox.Maps.Style;
using Com.Mapbox.Maps;
using Com.Mapbox.Maps.Plugins.Scalebar;
using Microsoft.Maui.Platform;
using Android.Content;
using Android.Graphics;
using GeoJSON.Text;
using Com.Mapbox.Maps.Plugins.Gestures;
using MapboxMaui.Locations;
using Com.Mapbox.Maps.Plugins.Locationcomponent;

namespace MapboxMaui;

public partial class MapboxViewHandler : Locations.ILocationComponentPlugin
{
	private Com.Mapbox.Maps.Plugins.Locationcomponent.ILocationComponentPlugin Plugin
	{
		get
		{
			var mapView = PlatformView.GetMapView();
			if (mapView is null) return null;

			return LocationComponentUtils.GetLocationComponent(mapView);
		}
	}

	public bool Enabled
    {
        get => Plugin?.Enabled ?? false;
        set => Plugin.Enabled = value;
	}

	public bool PulsingEnabled
	{
		get => Plugin?.PulsingEnabled ?? false;
		set => Plugin.PulsingEnabled = value;
	}
}
