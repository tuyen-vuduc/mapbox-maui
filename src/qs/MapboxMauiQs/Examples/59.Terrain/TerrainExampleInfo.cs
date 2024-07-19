namespace MapboxMauiQs;
class TerrainExampleInfo : IExampleInfo
{
    public string Group => "3D and Fill Extrusions";
    public string Title => "Show 3D terrain";
    public string Subtitle => "Show realistic elevation by enabling terrain.";
    public string PageRoute => typeof(TerrainExample).FullName;
    public int Index => 59;
}