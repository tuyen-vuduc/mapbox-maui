namespace MapboxMaui;

using Com.Mapbox.Bindgen;
using Com.Mapbox.Maps;
using XQueriedFeature = Query.QueriedRenderedFeature;
using XRenderedQueryOptions = Query.RenderedQueryOptions;

partial class MapboxViewHandler : IMapFeatureQueryable
{
    public Task<IEnumerable<XQueriedFeature>> QueryRenderedFeaturesWith(ScreenPosition point, XRenderedQueryOptions options)
    {
        var mapView = PlatformView.GetMapView();
        if (mapView == null) return Task.FromResult(
            Array.Empty<XQueriedFeature>() as IEnumerable<XQueriedFeature>
        );

        var x = point.X.PointToPixel();
        var y = point.Y.PointToPixel();

        var tcs = new TaskCompletionSource<IEnumerable<XQueriedFeature>>();
        _ = mapView.MapboxMap.QueryRenderedFeatures(
            new RenderedQueryGeometry(
                new ScreenBox(
                    new ScreenCoordinate(x - 25.0, y - 25.0),
                    new ScreenCoordinate(x + 25.0, y + 25.0)
                )
            ),
            options.ToPlatform(),
            new QueryRenderedFeaturesWithPointCallback(tcs)
        );

        return tcs.Task;
    }

    class QueryRenderedFeaturesWithPointCallback : Java.Lang.Object, IQueryRenderedFeaturesCallback
    {
        private readonly TaskCompletionSource<IEnumerable<XQueriedFeature>> tcs;

        public QueryRenderedFeaturesWithPointCallback(TaskCompletionSource<IEnumerable<XQueriedFeature>> tcs)
        {
            this.tcs = tcs;
        }

        public void Run(Expected p0)
        {
            if (p0.Error != null) {
                tcs.TrySetException(new Exception(p0.Error.ToString()));
                return;
            }

            var xfeatures = (p0.Value as Java.Util.IList)?.ToArray().Cast<QueriedRenderedFeature>();
            tcs.TrySetResult(xfeatures.Select(x => x.ToX()).ToArray());
        }
    }
}