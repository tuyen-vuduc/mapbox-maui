using Com.Mapbox.Maps.Plugins.Viewport.State;
using X = MapboxMaui.Viewport;

namespace MapboxMaui;

sealed class XViewportStateDataObserver : Java.Lang.Object, IViewportStateDataObserver
{
    private readonly X.ViewportStateDataObserver observer;

    public XViewportStateDataObserver(X.ViewportStateDataObserver observer)
    {
        this.observer = observer;
    }
    public bool OnNewData(Com.Mapbox.Maps.CameraOptions cameraOptions)
        => observer.Invoke(cameraOptions.ToX());
}
