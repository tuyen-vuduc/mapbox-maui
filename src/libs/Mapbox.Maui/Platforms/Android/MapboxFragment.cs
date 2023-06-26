namespace MapboxMaui;

using Android.Views;
using Com.Mapbox.Maps;
using AndroidX.Fragment.App;
using Android.OS;
using System;
using Android.Runtime;
using Com.Mapbox.Maps.Plugin.Delegates.Listeners;
using Com.Mapbox.Maps.Extension.Observable.Eventdata;
using Com.Mapbox.Maps.Plugin.Gestures;
using Com.Mapbox.Geojson;

public partial class MapboxFragment : Fragment
{
    public event Action<MapView> MapViewReady;
    public event Action<MapView> StyleLoaded;
    public event Action<MapView> MapLoaded;
    public event Action<MapTappedPosition> MapClicked;

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
        if (string.IsNullOrWhiteSpace(MapboxViewHandler.ACCESS_TOKEN))
        {
            return new MapView(Context);
        }

        var resourceOptionsManager = ResourceOptionsManager.CompanionField.GetDefault(
                Context,
                MapboxViewHandler.ACCESS_TOKEN
            );
        var initOptions = new MapInitOptions(
            Context,
            resourceOptionsManager?.ResourceOptions
        );

        return MapView = new MapView(Context, initOptions);
    }

    public override void OnViewCreated(View view, Bundle savedInstanceState)
    {
        base.OnViewCreated(view, savedInstanceState);

        MapViewReady?.Invoke(MapView);
        MapView.MapboxMap.AddOnStyleLoadedListener(this);
        MapView.MapboxMap.AddOnMapLoadedListener(this);

        GesturesUtils.AddOnMapClickListener(MapView.MapboxMap, this);
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
            MapView.MapboxMap.RemoveOnStyleLoadedListener(this);
            MapView.MapboxMap.RemoveOnMapLoadedListener(this);
            GesturesUtils.RemoveOnMapClickListener(MapView.MapboxMap, this);
            MapView?.Dispose();
        }
    }
}


partial class MapboxFragment
    : IOnStyleLoadedListener
    , IOnMapLoadedListener
    , IOnMapClickListener
{
    public bool OnMapClick(Point point)
    {
        if (MapClicked is null) return false;

        var xpoint = new Microsoft.Maui.Graphics.Point(
            point.Latitude(),
            point.Longitude());
        MapClicked?.Invoke(new MapTappedPosition
        {
            ScreenPosition = xpoint,
            Point = new GeoJSON.Text.Geometry.Point(
                new GeoJSON.Text.Geometry.Position(
                    point.Latitude(),
                    point.Longitude(),
                    point.HasAltitude ? point.Altitude() : null
                )
            )
        });
        return true;
    }

    public void OnMapLoaded(MapLoadedEventData eventData)
    {
        MapLoaded?.Invoke(MapView);
    }

    public void OnStyleLoaded(StyleLoadedEventData eventData)
    {
        StyleLoaded?.Invoke(MapView);
    }
}
