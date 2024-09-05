namespace MapboxMaui;

public class CameraChangedEventArgs : EventArgs
{
    public CameraChangedEventArgs()
    {
    }

    public CameraChangedEventArgs(CameraOptions options)
    {
        Options = options;
    }

    public CameraOptions Options { get; }
}
