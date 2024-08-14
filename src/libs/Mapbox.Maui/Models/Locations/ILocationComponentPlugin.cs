namespace MapboxMaui.Locations;

public interface ILocationComponentPlugin
{
    bool Enabled { get; set; }
    bool PulsingEnabled { get; set; }
    bool ShowAccuracyRing { get; set; }
    float PulsingMaxRadius { get; set; }
}
