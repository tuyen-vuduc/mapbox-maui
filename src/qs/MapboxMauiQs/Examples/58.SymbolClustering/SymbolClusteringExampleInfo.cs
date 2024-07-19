namespace MapboxMauiQs;
class SymbolClusteringExampleInfo : IExampleInfo
{
    public string Group => "Annotations";
    public string Title => "Add Cluster Symbol Annotations";
    public string Subtitle => "Show fire hydrants in Washington DC area in a cluster using a symbol layer.";
    public string PageRoute => typeof(SymbolClusteringExample).FullName;
    public int Index => 58;
}