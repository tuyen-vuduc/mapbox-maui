namespace MapboxMaui;

using Android.Views;
using Com.Mapbox.Maps;
using AndroidX.Fragment.App;
using Android.OS;
using System;
using Android.Runtime;
using Com.Mapbox.Maps.Plugins.Gestures;
using Com.Mapbox.Geojson;
using Com.Mapbox.Common;
using Com.Mapbox.Maps.Plugins.Locationcomponent;
using MapboxMaui.Viewport;
using Com.Mapbox.Maps.Plugins.Viewport;
using Com.Mapbox.Android.Gestures;
using MapboxMaui.Gestures;

public partial class MapboxFragment : Fragment
{
    public event Action<CameraOptions> CameraChanged;
    public event Action<double> IndicatorAccuracyRadiusChanged;
    public event Action<double> IndicatorBearingChanged;
    public event Action<IPosition> IndicatorPositionChanged;
    public event Action<MapTappedPosition> MapClicked;
    public event Action<MapView> MapLoaded;
    public event Action<MapView> MapLoadingError;
    public event Action<MapTappedPosition> MapLongClicked;
    public event Action<MapView> MapReady;
    public event Action<MapView> StyleLoaded;
    public event Action<ViewportStatusChangedEventArgs> ViewportStatusChanged;
    public event Action<RotatingEventArgs> Rotating;
    public event Action<RotatingBeganEventArgs> RotatingBegan;
    public event Action<RotatingEndedEventArgs> RotatingEnded;

    public MapView MapView { get; private set; }

    public MapboxFragment() : base()
    {

    }

    public MapboxFragment(int contentLayoutId)
        : base(contentLayoutId)
    {

    }

    public MapboxFragment(IntPtr javaReference, JniHandleOwnership transfer)
        : base(javaReference, transfer)
    {

    }

    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        if (!string.IsNullOrWhiteSpace(MapboxViewHandler.ACCESS_TOKEN))
        {
            MapboxOptions.AccessToken = MapboxViewHandler.ACCESS_TOKEN;
        }

        MapView = new MapView(Context);
        return MapView;
    }

    public override void OnViewCreated(View view, Bundle savedInstanceState)
    {
        base.OnViewCreated(view, savedInstanceState);

        MapReady?.Invoke(MapView);

        cancelables.Add(
            MapView.MapboxMap.SubscribeCameraChanged(this)
        );
        cancelables.Add(
            MapView.MapboxMap.SubscribeMapLoaded(this)
        );
        cancelables.Add(
            MapView.MapboxMap.SubscribeMapLoadingError(this)
        );
        cancelables.Add(
            MapView.MapboxMap.SubscribeStyleLoaded(this)
        );

        var locationUtils = LocationComponentUtils.GetLocationComponent(MapView);
        locationUtils.AddOnIndicatorAccuracyRadiusChangedListener(this);
        locationUtils.AddOnIndicatorBearingChangedListener(this);
        locationUtils.AddOnIndicatorPositionChangedListener(this);

        GesturesUtils.AddOnMapClickListener(MapView.MapboxMap, this);
        GesturesUtils.AddOnMapLongClickListener(MapView.MapboxMap, this);
        GesturesUtils.AddOnRotateListener(MapView.MapboxMap, this);

        ViewportUtils.GetViewport(MapView).AddStatusObserver(new XViewportStatusObserver(ViewportStatusChanged));
    }

    public override void OnStart()
    {
        base.OnStart();
        MapView?.OnStart();
    }

    public override void OnStop()
    {
        base.OnStop();
        MapView?.OnStop();
    }

    public override void OnLowMemory()
    {
        base.OnLowMemory();
        MapView?.OnLowMemory();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        MapView?.OnDestroy();
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        if (disposing)
        {
            foreach (var cancelable in cancelables)
            {
                cancelable.Dispose();
            }
            cancelables.Clear();

            GesturesUtils.RemoveOnMapClickListener(MapView.MapboxMap, this);
            GesturesUtils.RemoveOnMapLongClickListener(MapView.MapboxMap, this);
            GesturesUtils.RemoveOnRotateListener(MapView.MapboxMap, this);

            var locationUtils = LocationComponentUtils.GetLocationComponent(MapView);
            locationUtils.RemoveOnIndicatorAccuracyRadiusChangedListener(this);
            locationUtils.RemoveOnIndicatorBearingChangedListener(this);
            locationUtils.RemoveOnIndicatorPositionChangedListener(this);

            MapView?.Dispose();
        }
    }

    private IList<Com.Mapbox.Common.ICancelable> cancelables = new List<Com.Mapbox.Common.ICancelable>();
}

partial class MapboxFragment : IOnRotateListener
{
    public void OnRotate(RotateGestureDetector detector)
    {
        Rotating?.Invoke(new RotatingEventArgs());
    }

    public void OnRotateBegin(RotateGestureDetector detector)
    {
        RotatingBegan?.Invoke(new RotatingBeganEventArgs());
    }

    public void OnRotateEnd(RotateGestureDetector detector)
    {
        RotatingEnded?.Invoke(new RotatingEndedEventArgs());
    }
}

partial class MapboxFragment
    : ICameraChangedCallback
{
    void ICameraChangedCallback.Run(CameraChanged p0)
    {
        var center = p0.CameraState.Center.ToMapPosition();
        var padding = p0.CameraState.Padding.ToX();
        var cameraOptions = new CameraOptions
        {
            Center = center,
            Bearing = (float)p0.CameraState.Bearing,
            Padding = padding,
            Pitch = (float)p0.CameraState.Pitch,
            Zoom = (float)p0.CameraState.Zoom,
        };
        CameraChanged?.Invoke(cameraOptions);
    }
}
partial class MapboxFragment
    : IOnIndicatorAccuracyRadiusChangedListener
    , IOnIndicatorBearingChangedListener
    , IOnIndicatorPositionChangedListener
{
    void IOnIndicatorAccuracyRadiusChangedListener.OnIndicatorAccuracyRadiusChanged(double radius)
    {
        IndicatorAccuracyRadiusChanged?.Invoke(radius);
    }
    void IOnIndicatorBearingChangedListener.OnIndicatorBearingChanged(double bearing)
    {
        IndicatorBearingChanged?.Invoke(bearing);
    }
    void IOnIndicatorPositionChangedListener.OnIndicatorPositionChanged(Point point)
    {
        IndicatorPositionChanged?.Invoke(point.ToMapPosition());
    }
}

partial class MapboxFragment
    : IStyleLoadedCallback
    , IMapLoadedCallback
    , IMapLoadingErrorCallback
    , IOnMapClickListener
    , IOnMapLongClickListener
{
    public bool OnMapClick(Point point)
    {
        if (MapClicked is null) return false;
        
        var screenCoordinate = MapView.MapboxMap.PixelForCoordinate(point);

        MapClicked?.Invoke(point.ToMapTappedPosition(screenCoordinate));
        return true;
    }

    public bool OnMapLongClick(Point point)
    {
        if (MapLongClicked is null) return false;

        var screenCoordinate = MapView.MapboxMap.PixelForCoordinate(point);
        
        MapLongClicked?.Invoke(point.ToMapTappedPosition(screenCoordinate));
        return true;
    }

    public void Run(StyleLoaded p0)
    {
        StyleLoaded?.Invoke(MapView);
    }

    public void Run(MapLoaded p0)
    {
        MapLoaded?.Invoke(MapView);
    }

    void IMapLoadingErrorCallback.Run(MapLoadingError p0)
    {
        MapLoadingError?.Invoke(MapView);
    }
}
