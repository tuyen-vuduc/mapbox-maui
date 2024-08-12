namespace MapboxMaui.Locations;

public interface ILocationComponentPlugin
{
    bool Enabled { get; set; }
    bool PulsingEnabled { get; set; }
}
