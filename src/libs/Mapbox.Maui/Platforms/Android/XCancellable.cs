namespace MapboxMaui;

sealed class XCancellable : ICancelable, IDisposable
{
    private bool disposedValue;
    private readonly Com.Mapbox.Common.ICancelable platformValue;

    public XCancellable(
        Com.Mapbox.Common.ICancelable platformValue
        )
    {
        this.platformValue = platformValue;
    }

    void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                platformValue?.Dispose();
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
        platformValue.Cancel();
    }
}