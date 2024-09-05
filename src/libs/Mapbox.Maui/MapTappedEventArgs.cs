namespace MapboxMaui;

public class MapTappedEventArgs : EventArgs
{
    public MapTappedPosition Position { get; }

    public MapTappedEventArgs(MapTappedPosition position)
    {
        Position = position;
    }
}
