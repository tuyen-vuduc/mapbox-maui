using Foundation;
using MapboxCommon;
using MapboxMapsObjC;
using UIKit;

namespace MapboxMaui;
using PlatformView = MapViewContainer;

partial class MapboxViewHandler
{
    private UITapGestureRecognizer mapTapGestureRecognizer;
    private UILongPressGestureRecognizer mapLongPressGestureRecognizer;
    private XViewportStatusObserver viewportStatusObserver;
    private HashSet<TMBCancelable> cancelables;

    void RegisterEvents(PlatformView platformView)
    {
        cancelables ??= new HashSet<TMBCancelable>();

        var mapboxView = VirtualView as MapboxView;
        if (mapboxView is not null)
        {
            mapboxView.AnnotationController = this;
            mapboxView.QueryManager = this;
            mapboxView.MapboxController = this;
            mapboxView.CameraController = this;
            mapboxView.Viewport = this;

            mapboxView.InvokeMapReady();
        }

        var mapView = platformView.MapView;
        if (mapView == null) return;

        var mapboxMap = mapView.MapboxMap();

        cancelables.Add(
            mapboxMap.OnCameraChanged(data =>
            {
                mapboxView?.InvokeCameraChanged(data.CameraState.ToX());
            }),
            mapboxMap.OnMapLoaded(_ =>
            {
                mapboxView?.InvokeMapLoaded();
            }),
            mapboxMap.OnMapLoadingError(_ =>
            {
                mapboxView?.InvokeMapLoadingError();
            }),
            mapboxMap.OnStyleLoaded(_ =>
            {
                mapboxView?.InvokeStyleLoaded();
            })
        );

        mapTapGestureRecognizer = new UITapGestureRecognizer(HandleMapTapped);
        mapView.AddGestureRecognizer(mapTapGestureRecognizer);

        mapLongPressGestureRecognizer = new UILongPressGestureRecognizer(HandleMapLongPress);
        mapView.AddGestureRecognizer(mapLongPressGestureRecognizer);

        viewportStatusObserver = new XViewportStatusObserver(mapboxView.InvokeViewportStatusChanged);
        mapView.Viewport().AddStatusObserver(
            viewportStatusObserver
        );

        mapView.Gestures().WeakDelegate = new XTMBGestureManagerDelegate(mapboxView);

        cancelables.Add(
            mapView.Location().OnLocationChangeWithHandler(HandleLocationChanged),
            mapView.Location().OnHeadingChangeWithHandler(HandleHeadingChanged)
        );
    }

    private void HandleHeadingChanged(TMBHeading heading)
    {
        var mapboxView = VirtualView as MapboxView;
        if (mapboxView is null) return;

        mapboxView.InvokeIndicatorAccuracyRadiusChanged(heading.Accuracy);
    }

    private void HandleLocationChanged(NSArray<MBXLocation> array)
    {
        var mapboxView = VirtualView as MapboxView;
        if (mapboxView is null) return;

        var mbxLocation = array[(int)array.Count - 1];
        var mapPosition = new MapPosition(
            mbxLocation.Latitude,
            mbxLocation.Longitude,
            mbxLocation.Altitude?.DoubleValue);
        mapboxView.InvokeIndicatorPositionChanged(mapPosition);
    }

    void UnRegisterEvents(PlatformView platformView)
    {
        if (VirtualView is MapboxView mapboxView)
        {
            mapboxView.AnnotationController = null;
            mapboxView.QueryManager = null;
            mapboxView.MapboxController = null;
            mapboxView.CameraController = null;
            mapboxView.Viewport = null;
        }

        foreach (var cancelable in cancelables)
        {
            cancelable?.Dispose();
        }
        cancelables.Clear();

        var mapView = platformView.MapView;
        if (mapView == null) return;

        if (mapTapGestureRecognizer != null)
        {
            mapView.RemoveGestureRecognizer(mapTapGestureRecognizer);
            mapTapGestureRecognizer.Dispose();
            mapTapGestureRecognizer = null;
        }

        if (mapLongPressGestureRecognizer != null)
        {
            mapView.RemoveGestureRecognizer(mapLongPressGestureRecognizer);
            mapLongPressGestureRecognizer.Dispose();
            mapLongPressGestureRecognizer = null;
        }

        if (viewportStatusObserver != null)
        {
            mapView.Viewport().RemoveStatusObserver(viewportStatusObserver);
            viewportStatusObserver.Dispose();
            viewportStatusObserver = null;
        }

        mapView.Gestures().WeakDelegate?.Dispose();
        mapView.Gestures().WeakDelegate = null;
    }

    private void HandleMapLongPress(UILongPressGestureRecognizer longPressGestureRecognizer)
    {
        if (longPressGestureRecognizer.State != UIGestureRecognizerState.Began) return;

        var position = GetPositionForGesture(longPressGestureRecognizer);
        if (position == null) return;

        (VirtualView as MapboxView)?.InvokeMapLongTapped(
            position
        );
    }

    private void HandleMapTapped(UITapGestureRecognizer tapGestureRecognizer)
    {
        var position = GetPositionForGesture(tapGestureRecognizer);
        if (position == null) return;

        (VirtualView as MapboxView)?.InvokeMapTapped(
            position
        );
    }

    private MapTappedPosition GetPositionForGesture(UIGestureRecognizer gesture)
    {
        var mapView = PlatformView.MapView;
        if (mapView == null) return null;

        var screenPosition = gesture.LocationInView(mapView);
        var coords = mapView.MapboxMap().CoordinateFor(
            screenPosition
        );

        return coords.ToMapTappedPosition(screenPosition);
    }
}


sealed class XTMBGestureManagerDelegate
    : NSObject
    , ITMBGestureManagerDelegate
{
    private readonly MapboxView mapboxView;

    public XTMBGestureManagerDelegate(
        MapboxView mapboxView
        )
    {
        this.mapboxView = mapboxView;
    }

    public void GestureManagerWithDidBegin(TMBGestureType gestureType)
    {
        switch(gestureType)
        {
            case TMBGestureType.Rotation:
                mapboxView?.InvokeRotatingBegan(new Gestures.RotatingBeganEventArgs());
                break;
        }
    }

    public void GestureManagerWithDidEnd(TMBGestureType gestureType, bool willAnimate)
    {
        switch (gestureType)
        {
            case TMBGestureType.Rotation:
                mapboxView?.InvokeRotatingEnded(new Gestures.RotatingEndedEventArgs());
                break;
        }
    }

    public void GestureManagerWithDidEndAnimatingFor(TMBGestureType gestureType)
    {
    }
}