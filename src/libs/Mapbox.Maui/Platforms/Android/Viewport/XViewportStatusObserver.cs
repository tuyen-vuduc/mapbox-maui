
using Com.Mapbox.Maps.Plugins.Viewport;
using MapboxMaui.Viewport;

namespace MapboxMaui;

sealed class XViewportStatusObserver : Java.Lang.Object, IViewportStatusObserver
{
    private readonly Action<ViewportStatusChangedEventArgs> action;

    public XViewportStatusObserver(Action<ViewportStatusChangedEventArgs> action)
    {
        this.action = action;
    }

    public void OnViewportStatusChanged(
        Com.Mapbox.Maps.Plugins.Viewport.ViewportStatus from,
        Com.Mapbox.Maps.Plugins.Viewport.ViewportStatus to,
        Com.Mapbox.Maps.Plugins.Viewport.Data.ViewportStatusChangeReason reason)
    {
        action?.Invoke(new ViewportStatusChangedEventArgs(
            from.ToX(),
            to.ToX(),
            reason.ToX()
            ));
    }
}