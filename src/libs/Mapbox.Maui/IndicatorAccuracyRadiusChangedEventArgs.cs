namespace MapboxMaui;

public class IndicatorAccuracyRadiusChangedEventArgs : EventArgs
{
    public IndicatorAccuracyRadiusChangedEventArgs(double radius)
    {
        Radius = radius;
    }

    public double Radius { get; }
}
