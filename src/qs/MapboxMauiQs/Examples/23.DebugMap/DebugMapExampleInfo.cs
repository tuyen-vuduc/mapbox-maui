namespace MapboxMauiQs;
class DebugMapExampleInfo : IExampleInfo
{
    public string Group => "Get Started";
    public string Title => "Debug Map";
    public string Subtitle => "This example shows how the map looks with different debug options";
    public string PageRoute => typeof(DebugMapExample).FullName;
    public int GroupIndex => 1;
    public int Index => 23;
}