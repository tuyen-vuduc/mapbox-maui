using MapboxMapsObjC;
using X = MapboxMaui.Viewport;

namespace MapboxMaui;

abstract class XViewportState : X.IViewportState, IDisposable
{
    private bool disposedValue;
    private readonly ITMBViewportState platformValue;

    protected XViewportState(ITMBViewportState platformValue)
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
            platformValue.ObserveDataSourceWith(
                cameraOptions => observer.Invoke(cameraOptions.ToX())
            )
        );
    }

    public void StartUpdatingCamera() => platformValue.StartUpdatingCamera();

    public void StopUpdatingCamera() => platformValue.StopUpdatingCamera();
}
