using Com.Mapbox.Maps.Plugins.Viewport.State;
using X = MapboxMaui.Viewport;

namespace MapboxMaui;

abstract class XViewportState : X.IViewportState, IDisposable
{
    private bool disposedValue;
    private readonly IViewportState platformValue;

    protected XViewportState(IViewportState platformValue)
    {
        this.platformValue = platformValue;
    }

    private void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                platformValue.Dispose();
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public ICancelable ObserveDataSource(X.ViewportStateDataObserver observer)
    {
        return new XCancellable(
            platformValue.ObserveDataSource(new XViewportStateDataObserver(observer))
        );
    }

    public void StartUpdatingCamera() => platformValue.StartUpdatingCamera();

    public void StopUpdatingCamera() => platformValue.StopUpdatingCamera();
}
