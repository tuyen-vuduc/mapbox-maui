namespace MapboxMaui;

public partial record struct CameraOptions
{
    public IPosition Center { get; set; }
    public Thickness? Padding { get; set; }
    public ScreenPosition? Anchor { get; set; }
    public float? Zoom { get; set; }
    public float? Bearing { get; set; }
    public float? Pitch { get; set; }
}