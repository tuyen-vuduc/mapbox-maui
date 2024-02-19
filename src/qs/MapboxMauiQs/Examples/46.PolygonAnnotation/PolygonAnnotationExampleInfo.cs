namespace MapboxMauiQs;
class PolygonAnnotationExampleInfo : IExampleInfo
{
    public string Group => "Annotations";
    public string Title => "Add a polygon annotation";
    public string Subtitle => "Add a polygon annotation to the map";
    public string PageRoute => typeof(PolygonAnnotationExample).FullName;
    public int GroupIndex => 3;
    public int Index => 46;
}