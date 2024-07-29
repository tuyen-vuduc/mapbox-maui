using Com.Mapbox.Maps.Plugins.Viewport;
using X = MapboxMaui.Viewport;

namespace MapboxMaui;

partial class MapboxViewHandler : X.IViewportPlugin
{
    public X.IViewportState GetCurrentOrNextState()
    {
        var mapView = mapboxFragment?.MapView;

        if (mapView == null) return null;

        var viewport = ViewportUtils.GetViewport(mapView);

        return viewport.Status.GetCurrentOrNextState();
    }

    public X.IFollowPuckViewportState MakeFollowPuckViewportState(X.FollowPuckViewportStateOptions options)
    {
        var mapView = mapboxFragment?.MapView;

        if (mapView == null) return null;

        var viewport = ViewportUtils.GetViewport(mapView);
        var state = viewport.MakeFollowPuckViewportState(options.ToNative());

        return state.ToX();
    }

    public X.IOverviewViewportState MakeOverviewViewportState(X.OverviewViewportStateOptions options)
    {
        var mapView = mapboxFragment?.MapView;

        if (mapView == null) return null;

        var viewport = ViewportUtils.GetViewport(mapView);
        var state = viewport.MakeOverviewViewportState(options.ToNative());

        return state.ToX();
    }

    public void TransitionTo(
        X.IViewportState state,
        X.IViewportTransition transition = null,
        Action<bool> completion = null)
    {
        var mapView = mapboxFragment?.MapView;

        if (mapView == null) return;

        var viewport = ViewportUtils.GetViewport(mapView);

        viewport.TransitionTo(state.ToNative(), transition?.ToNative(), completion);
    }
}
