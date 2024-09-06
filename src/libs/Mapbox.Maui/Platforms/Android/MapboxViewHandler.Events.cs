using Com.Mapbox.Maps;
using MapboxMaui.Gestures;

namespace MapboxMaui;

public partial class MapboxViewHandler
{
    private void RegisterEvents(MapboxFragment mapboxFragment)
    {
        if (VirtualView is MapboxView mapboxView)
        {
            mapboxView.AnnotationController = this;
            mapboxView.QueryManager = this;
            mapboxView.MapboxController = this;
            mapboxView.CameraController = this;
            mapboxView.Viewport = this;
            mapboxView.LocationComponent = this;
            mapboxView.ViewAnnotationController = this;
        }

        mapboxFragment.MapReady += HandleMapReady;
        mapboxFragment.CameraChanged += HandleCameraChanged;
        mapboxFragment.IndicatorAccuracyRadiusChanged += HandleIndicatorAccuracyRadiusChanged;
        mapboxFragment.IndicatorBearingChanged += HandleIndicatorBearingChanged;
        mapboxFragment.IndicatorPositionChanged += HandleIndicatorPositionChanged;
        mapboxFragment.MapLoaded += HandleMapLoaded;
        mapboxFragment.MapLoadingError += HandleMapLoadingError;
        mapboxFragment.MapClicked += HandleMapClicked;
        mapboxFragment.MapLongClicked += HandleMapLongClicked;
        mapboxFragment.StyleLoaded += HandleStyleLoaded;
        mapboxFragment.ViewportStatusChanged += HandleViewportStatusChanged;
        mapboxFragment.Rotating -= HandleRotating;
        mapboxFragment.RotatingBegan -= HandleRotatingBegan;
        mapboxFragment.RotatingEnded -= HandleRotatingEnded;
    }

    private void UnregisterEvents(MapboxFragment mapboxFragment)
    {
        if (VirtualView is MapboxView mapboxView)
        {
            mapboxView.AnnotationController = null;
            mapboxView.QueryManager = null;
            mapboxView.CameraController = null;
            mapboxView.MapboxController = null;
            mapboxView.Viewport = null;
            mapboxView.LocationComponent = null;
            mapboxView.ViewAnnotationController = null;
        }

        mapboxFragment.MapReady -= HandleMapReady;
        mapboxFragment.CameraChanged -= HandleCameraChanged;
        mapboxFragment.IndicatorAccuracyRadiusChanged -= HandleIndicatorAccuracyRadiusChanged;
        mapboxFragment.IndicatorBearingChanged -= HandleIndicatorBearingChanged;
        mapboxFragment.IndicatorPositionChanged -= HandleIndicatorPositionChanged;
        mapboxFragment.MapLoaded -= HandleMapLoaded;
        mapboxFragment.MapLoadingError -= HandleMapLoadingError;
        mapboxFragment.MapClicked -= HandleMapClicked;
        mapboxFragment.MapLongClicked -= HandleMapLongClicked;
        mapboxFragment.StyleLoaded -= HandleStyleLoaded;
        mapboxFragment.ViewportStatusChanged -= HandleViewportStatusChanged;
        mapboxFragment.Rotating -= HandleRotating;
        mapboxFragment.RotatingBegan -= HandleRotatingBegan;
        mapboxFragment.RotatingEnded -= HandleRotatingEnded;
    }

    private void HandleMapReady(MapView view)
        => (VirtualView as MapboxView)?.InvokeMapReady();
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
    private void HandleStyleLoaded(MapView view)
        => (VirtualView as MapboxView)?.InvokeStyleLoaded();
    private void HandleViewportStatusChanged(Viewport.ViewportStatusChangedEventArgs args)
        => (VirtualView as MapboxView)?.InvokeViewportStatusChanged(args);
    private void HandleRotatingBegan(RotatingBeganEventArgs args)
        => (VirtualView as MapboxView)?.InvokeRotatingBegan(args);
    private void HandleRotating(RotatingEventArgs args)
        => (VirtualView as MapboxView)?.InvokeRotating(args);
    private void HandleRotatingEnded(RotatingEndedEventArgs args)
        => (VirtualView as MapboxView)?.InvokeRotatingEnded(args);
}
