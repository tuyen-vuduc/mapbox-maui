namespace MapboxMaui;

public class IndicatorPositionChangedEventArgs : EventArgs
{
    public IndicatorPositionChangedEventArgs(IPosition position)
    {
        Position = position;
    }

    public IPosition Position { get; }
}