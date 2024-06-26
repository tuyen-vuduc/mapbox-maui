namespace MapboxMauiQs;
class SkyLayerExampleInfo : IExampleInfo
{
    public string Group => "3D and Fill Extrusions";
    public string Title => "Add a sky layer";
    public string Subtitle => "Add a customizable sky layer to simulate natural lighting with a Terrain layer.";
    public string PageRoute => typeof(SkyLayerExample).FullName;
    public int GroupIndex => 2;
    public int Index => 52;
}