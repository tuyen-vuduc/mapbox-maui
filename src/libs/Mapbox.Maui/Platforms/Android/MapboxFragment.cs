namespace Mapbox.Maui;

using Android.Views;
using Com.Mapbox.Maps;
using AndroidX.Fragment.App;
using Android.OS;
using System;
using Android.Runtime;

public class MapboxFragment : Fragment
{
    public event Action<MapView> MapViewReady;

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

    public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
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

    public override void OnViewCreated(Android.Views.View view, Bundle savedInstanceState)
    {
        base.OnViewCreated(view, savedInstanceState);

        MapViewReady?.Invoke(MapView);
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
            MapView?.Dispose();
        }
    }
}

