namespace MapboxMaui;

public class IndicatorBearingChangedEventArgs : EventArgs
{
    public IndicatorBearingChangedEventArgs(double bearing)
    {
        Bearing = bearing;
    }

    public double Bearing { get; }
}
