namespace MapboxMaui;

using Com.Mapbox.Maps;
using XQueriedFeature = Query.QueriedFeature;
using XQueriedRenderedFeature = Query.QueriedRenderedFeature;

public static class QueriedFeatureExtensions
{
    public static XQueriedFeature ToX(this QueriedFeature src)
        => new XQueriedFeature
        {
            Feature = src.Feature.ToX(),
            Source = src.Source,
            SourceLayer = src.SourceLayer,
            State = src.State,
        };
    public static XQueriedRenderedFeature ToX(this QueriedRenderedFeature src)
        => new XQueriedRenderedFeature
        {
            QueriedFeature = src.QueriedFeature.ToX(),
            Layers = src.Layers?.ToArray(),
        };
}

