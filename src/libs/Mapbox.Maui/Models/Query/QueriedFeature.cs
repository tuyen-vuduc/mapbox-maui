using GeoJSON.Text.Feature;

namespace MapboxMaui.Query;

public class QueriedFeature
{
    public Feature Feature { get; internal set; }
    public string Source { get; internal set; }
    public string SourceLayer { get; internal set; }
}