namespace MapboxMauiQs;
class PointAnnotationClusteringExampleInfo : IExampleInfo
{
    public string Group => "Annotations";
    public string Title => "Add Cluster Point Annotations";
    public string Subtitle => "Show fire hydrants in Washington DC area in a cluster using point annotations.";
    public string PageRoute => typeof(PointAnnotationClusteringExample).FullName;
    public int GroupIndex => 3;
    public int Index => 44;
}