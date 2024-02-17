using MapboxCoreMaps;
using MapboxMaui.Query;

namespace MapboxMaui;

public static class QueriedFeatureExtensions
{
    public static QueriedFeature ToX(this MBMQueriedRenderedFeature src)
        => new QueriedFeature
        {
            // TODO Check mapper
            //Feature = src.Feature.ToX(),
            //Source = src.Source,
            //SourceLayer = src.SourceLayer,
            // TODO Convert state
            //State = src.State.ToX(),
        };
}

