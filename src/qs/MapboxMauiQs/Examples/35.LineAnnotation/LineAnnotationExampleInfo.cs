namespace MapboxMauiQs;

class LineAnnotationExampleInfo : IExampleInfo
{
    public string Group => "Annotations";
    public string Title => "Add Polylines Annotations";
    public string Subtitle => "Show polyline annotations on a map.";
    public string PageRoute => typeof(LineAnnotationExample).FullName;
}