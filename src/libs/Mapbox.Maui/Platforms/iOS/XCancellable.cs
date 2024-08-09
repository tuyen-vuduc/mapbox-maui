using Foundation;
using MapboxMapsObjC;

namespace MapboxMaui;

sealed class XCancellable : ICancelable, IDisposable
{
    private bool disposedValue;
    public TMBCancelable Cancelable { get; }

    public XCancellable(
        TMBCancelable platformValue
        )
    {
        this.Cancelable = platformValue;
    }

    void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                Cancelable?.Dispose();
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public void Cancel()
    {
        Cancelable.Cancel();
    }
}