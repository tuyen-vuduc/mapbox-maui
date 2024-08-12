using MapboxMapsObjC;
using MapboxMaui.Locations;

namespace MapboxMaui;
using PlatformView = MapViewContainer;

partial class MapboxViewHandler : ILocationComponentPlugin
{
    private TMBLocationManager Plugin
    {
        get
        {
            var mapView = PlatformView.MapView;
            if (mapView is null) return null;

            return mapView.Location();
        }
    }

    public bool Enabled
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    public bool PulsingEnabled
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }
    public bool ShowAccuracyRing
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }
    public float PulsingMaxRadius
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }
}
