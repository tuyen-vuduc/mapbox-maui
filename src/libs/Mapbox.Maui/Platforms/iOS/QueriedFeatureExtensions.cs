using MapboxCoreMaps;
using MapboxMaui.Query;

namespace MapboxMaui;

public static class QueriedFeatureExtensions
{
    public static QueriedRenderedFeature ToX(this MBMQueriedRenderedFeature src)
        => new QueriedRenderedFeature
        {
            QueriedFeature = src.QueriedFeature.ToX(),
            Layers = src.Layers,
        };
    public static QueriedFeature ToX(this MBMQueriedFeature src)
        => new QueriedFeature
        {
            Feature = src.Feature.ToX(),
            Source = src.Source,
            SourceLayer = src.SourceLayer,
            State = src.State,
        };
}

