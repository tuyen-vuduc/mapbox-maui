namespace MapboxMaui;

public record struct CameraOptions
{
    public Point? Center { get; set; }
    public Thickness? Padding { get; set; }
    public Point? Anchor { get; set; }
    public float? Zoom { get; set; }
    public float? Bearing { get; set; }
    public float? Pitch { get; set; }
}

