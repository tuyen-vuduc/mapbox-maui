namespace MapboxMaui;

using Com.Mapbox.Maps;
using XQueriedFeature = Query.QueriedFeature;

public static class QueriedFeatureExtensions
{
    public static XQueriedFeature ToX(this QueriedFeature src)
        => new XQueriedFeature
        {
            Feature = src.Feature.ToX(),
            Source = src.Source,
            SourceLayer = src.SourceLayer,
            // TODO Convert state
            //State = src.State.ToX(),
        };
}

