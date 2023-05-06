namespace MapboxMauiQs;
class BuildingExtrusionsExampleInfo : IExampleInfo
{
    public string Group => "3D and Fill Extrusions";
    public string Title => "Display 3D buildings";
    public string Subtitle => "Extrude the building layer in the Mapbox Light style using FillExtrusionLayer and set up the light position.";
    public string PageRoute => typeof(BuildingExtrusionsExample).FullName;
}