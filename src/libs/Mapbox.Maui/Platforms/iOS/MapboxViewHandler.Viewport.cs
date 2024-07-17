using X = MapboxMaui.Viewport;

namespace MapboxMaui;

partial class MapboxViewHandler : X.IViewportPlugin
{
    public X.IFollowPuckViewportState MakeFollowPuckViewportState(X.FollowPuckViewportStateOptions options)
    {
        var mapView = PlatformView.MapView;

        if (mapView == null) return default;

        throw new NotImplementedException();
        //var viewport = mapView.Ma.GetViewport(mapView);
        //var state = viewport.MakeFollowPuckViewportState(options.ToNative());

        //return state.ToX();
    }

    public X.IOverviewViewportState MakeOverviewViewportState(X.OverviewViewportStateOptions options)
    {
        var mapView = PlatformView.MapView;

        if (mapView == null) return default;

        throw new NotImplementedException();
        //var viewport = ViewportUtils.GetViewport(mapView);
        //var state = viewport.MakeOverviewViewportState(options.ToNative());

        //return state.ToX();
    }
}
