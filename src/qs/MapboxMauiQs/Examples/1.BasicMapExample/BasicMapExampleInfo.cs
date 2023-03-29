namespace MapboxMauiQs;

public class BasicMapExampleInfo : IExampleInfo
{
    public string Group => "Get Started";

    public string Title => "Display a map view";

    public string Subtitle => "Create and display a map that uses the default Mapbox streets style. This example also shows how to update the starting camera for a map.";

    public string PageRoute => typeof(BasicMapExample).FullName;
}
