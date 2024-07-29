using MapboxMapsObjC;
using X = MapboxMaui.Viewport;

namespace MapboxMaui;

abstract class XViewportState : X.IViewportState, IDisposable
{
    private bool disposedValue;
    public ITMBViewportState State { get; }

    protected XViewportState(ITMBViewportState platformValue)
    {
        this.State = platformValue;
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
            State.ObserveDataSourceWith(
                cameraOptions => observer.Invoke(cameraOptions.ToX())
            )
        );
    }

    public void StartUpdatingCamera() => State.StartUpdatingCamera();

    public void StopUpdatingCamera() => State.StopUpdatingCamera();
}
