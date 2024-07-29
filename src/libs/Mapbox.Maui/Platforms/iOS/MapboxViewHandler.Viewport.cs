using MapboxMapsObjC;
using X = MapboxMaui.Viewport;

namespace MapboxMaui;

partial class MapboxViewHandler : X.IViewportPlugin
{
    public X.IViewportState GetCurrentOrNextState()
    {
        var mapView = PlatformView.MapView;

        if (mapView == null) return default;

        return mapView.Viewport().Status.GetCurrentOrNextState();
    }

    public X.IFollowPuckViewportState MakeFollowPuckViewportState(X.FollowPuckViewportStateOptions options)
    {
        var mapView = PlatformView.MapView;

        if (mapView == null) return default;

        var viewport = mapView.Viewport();
        var state = viewport.MakeFollowPuckViewportStateWithOptions(options.ToNative());
        return state.ToX();
    }

    public X.IOverviewViewportState MakeOverviewViewportState(X.OverviewViewportStateOptions options)
    {
        var mapView = PlatformView.MapView;

        if (mapView == null) return default;

        var viewport = mapView.Viewport();
        var state = viewport.MakeOverviewViewportStateWithOptions(options.ToNative());
        return state.ToX();
    }

    public void TransitionTo(
        X.IViewportState state,
        X.IViewportTransition transition = null,
        Action<bool> completion = null)
    {
        var mapView = PlatformView.MapView;

        if (mapView == null) return;

        mapView.Viewport().TransitionTo(
            state.ToNative(),
            transition?.ToNative(),
            completion
            );
    }
}
