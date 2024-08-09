using Com.Mapbox.Maps.Plugins.Viewport.State;
using X = MapboxMaui.Viewport;

namespace MapboxMaui;

abstract class XViewportState : X.IViewportState, IDisposable
{
    private bool disposedValue;
    public IViewportState State { get; }

    protected XViewportState(IViewportState state)
    {
        this.State = state;
    }

    private void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                State.Dispose();
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
            State.ObserveDataSource(new XViewportStateDataObserver(observer))
        );
    }

    public void StartUpdatingCamera() => State.StartUpdatingCamera();

    public void StopUpdatingCamera() => State.StopUpdatingCamera();
}
