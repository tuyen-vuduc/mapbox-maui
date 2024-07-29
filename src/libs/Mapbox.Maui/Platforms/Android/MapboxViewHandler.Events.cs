﻿using Com.Mapbox.Maps;

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

            mapboxView.InvokeMapReady();
        }

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
        }

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
    private void HandleStyleLoaded(MapView view)
        => (VirtualView as MapboxView)?.InvokeStyleLoaded();
    private void HandleViewportStatusChanged(Viewport.ViewportStatusChangedEventArgs args)
        => (VirtualView as MapboxView)?.InvokeViewportStatusChanged(args);


}
