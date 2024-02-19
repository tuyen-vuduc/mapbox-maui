namespace MapboxMauiQs;

class MultipleGeometriesExampleInfo : IExampleInfo
{
    public string Group => "Annotations";
    public string Title => "Draw multiple geometries";
    public string Subtitle => "Draw multiple shapes on a map.";
    public string PageRoute => typeof(MultipleGeometriesExample).FullName;
    public int GroupIndex => 3;
    public int Index => 39;
}