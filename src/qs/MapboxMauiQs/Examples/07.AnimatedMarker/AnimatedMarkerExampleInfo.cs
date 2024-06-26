namespace MapboxMauiQs;

class AnimatedMarkerExampleInfo : IExampleInfo
{
    public string Group => "Annotations";
    public string Title => "Animate Marker Position";
    public string Subtitle => "Animate updates to a marker/annotation's position.";
    public string PageRoute => typeof(AnimatedMarkerExample).FullName;
    public int GroupIndex => 3;
    public int Index => 7;
}