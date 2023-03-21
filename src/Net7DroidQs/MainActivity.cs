using Com.Mapbox.Maps;

namespace Net7DroidQs;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : Activity
{
    MapView mapView;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        //// Set our view from the "main" layout resource
        //SetContentView(Resource.Layout.activity_main);

        mapView = new MapView(this);
        SetContentView(mapView);
        mapView.MapboxMap.LoadStyleUri(Style.MapboxStreets);
    }

    protected override void OnStart()
    {
        base.OnStart();
        mapView?.OnStart();
    }

    protected override void OnStop()
    {
        base.OnStop();
        mapView?.OnStop();
    }

    public override void OnLowMemory()
    {
        base.OnLowMemory();
        mapView?.OnLowMemory();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        mapView?.OnDestroy();
    }
}
