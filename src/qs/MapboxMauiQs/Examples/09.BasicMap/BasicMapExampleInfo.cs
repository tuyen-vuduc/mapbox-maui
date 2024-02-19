namespace MapboxMauiQs;

public class BasicMapExampleInfo : IExampleInfo
{
    public string Group => "Get Started";

    public string Title => "Display a map view";

    public string Subtitle => "Create and display a map that uses the default Mapbox Standard style.";

    public string PageRoute => typeof(BasicMapExample).FullName;

    public int GroupIndex => 1;

    public int Index => 9;
}
