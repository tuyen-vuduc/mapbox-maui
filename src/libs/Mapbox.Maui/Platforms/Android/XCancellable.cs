namespace MapboxMaui;

sealed class XCancellable : ICancelable, IDisposable
{
    private bool disposedValue;
    public Com.Mapbox.Common.ICancelable Cancelable { get; }

    public XCancellable(
        Com.Mapbox.Common.ICancelable platformValue
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