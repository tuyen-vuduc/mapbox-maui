using Com.Mapbox.Maps;

namespace MapboxMaui;

public partial class MapboxViewHandler
{
    private void RegisterEvents(MapboxFragment mapboxFragment)
    {
        mapboxFragment.CameraChanged += HandleCameraChanged;
        mapboxFragment.IndicatorAccuracyRadiusChanged += HandleIndicatorAccuracyRadiusChanged;
        mapboxFragment.IndicatorBearingChanged += HandleIndicatorBearingChanged;
        mapboxFragment.IndicatorPositionChanged += HandleIndicatorPositionChanged;
        mapboxFragment.MapLoaded += HandleMapLoaded;
        mapboxFragment.MapLoadingError += HandleMapLoadingError;
        mapboxFragment.MapViewReady += HandleMapViewReady;
        mapboxFragment.MapClicked += HandleMapClicked;
        mapboxFragment.MapLongClicked += HandleMapLongClicked;
        mapboxFragment.StyleLoaded += HandleStyleLoaded;
    }

    private void UnregisterEvents(MapboxFragment mapboxFragment)
    {
        mapboxFragment.CameraChanged -= HandleCameraChanged;
        mapboxFragment.IndicatorAccuracyRadiusChanged -= HandleIndicatorAccuracyRadiusChanged;
        mapboxFragment.IndicatorBearingChanged -= HandleIndicatorBearingChanged;
        mapboxFragment.IndicatorPositionChanged -= HandleIndicatorPositionChanged;
        mapboxFragment.MapLoaded -= HandleMapLoaded;
        mapboxFragment.MapLoadingError -= HandleMapLoadingError;
        mapboxFragment.MapViewReady -= HandleMapViewReady;
        mapboxFragment.MapClicked -= HandleMapClicked;
        mapboxFragment.MapLongClicked -= HandleMapLongClicked;
        mapboxFragment.StyleLoaded -= HandleStyleLoaded;
    }

    private void HandleCameraChanged(CameraOptions options)
        => (VirtualView as MapboxView)?.InvokeCameraChanged(options);
    private void HandleIndicatorAccuracyRadiusChanged(double obj)
        => (VirtualView as MapboxView)?.InvokeIndicatorAccuracyRadiusChanged(obj);
    private void HandleIndicatorPositionChanged(IPosition position)
        => (VirtualView as MapboxView)?.InvokeIndicatorPositionChanged(position);
    private void HandleIndicatorBearingChanged(double obj)
        => (VirtualView as MapboxView)?.InvokeIndicatorBearingChanged(obj);
    private void HandleMapClicked(MapTappedPosition point)
        => (VirtualView as MapboxView)?.InvokeMapTapped(point);
    private void HandleMapLoaded(MapView view)
        => (VirtualView as MapboxView)?.InvokeMapLoaded();
    private void HandleMapLoadingError(MapView view)
        => (VirtualView as MapboxView)?.InvokeMapReady();
    private void HandleMapLongClicked(MapTappedPosition point)
        => (VirtualView as MapboxView)?.InvokeMapLongTapped(point);
    private void HandleMapViewReady(MapView view)
        => (VirtualView as MapboxView)?.InvokeMapReady();
    private void HandleStyleLoaded(MapView view)
        => (VirtualView as MapboxView)?.InvokeStyleLoaded();


}
