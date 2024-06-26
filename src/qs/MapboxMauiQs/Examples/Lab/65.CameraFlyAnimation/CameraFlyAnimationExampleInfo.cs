namespace MapboxMauiQs;

class CameraFlyAnimationExampleInfo : IExampleInfo
{
    public string Group => "Lab";
    public string Title => "Camera Fly Animation";
    public string Subtitle => "Change mapcenter with fly animation";
    public string PageRoute => typeof(CameraFlyAnimationExample).FullName;
    public int GroupIndex => 0;
    public int Index => 65;
}