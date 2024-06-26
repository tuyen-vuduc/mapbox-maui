namespace MapboxMauiQs;
class CustomPointAnnotationExampleInfo : IExampleInfo
{
    public string Group => "Annotations";
    public string Title => "Add Point Annotations";
    public string Subtitle => "Show point annotations on a map";
    public string PageRoute => typeof(CustomPointAnnotationExample).FullName;
    public int GroupIndex => 3;
    public int Index => 19;
}