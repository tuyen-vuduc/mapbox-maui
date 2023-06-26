namespace MapboxMaui;

using Com.Mapbox.Bindgen;
using Com.Mapbox.Maps;
using XQueriedFeature = Query.QueriedFeature;
using XRenderedQueryOptions = Query.RenderedQueryOptions;

partial class MapboxViewHandler : IMapFeatureQueryable
{
    public Task<IEnumerable<XQueriedFeature>> QueryRenderedFeaturesWith(Point point, XRenderedQueryOptions options)
    {
        var mapView = PlatformView.GetMapView();
        if (mapView == null) return Task.FromResult(
            Array.Empty<XQueriedFeature>() as IEnumerable<XQueriedFeature>
        );

        var tcs = new TaskCompletionSource<IEnumerable<XQueriedFeature>>();
        var pixel = mapView.MapboxMap.PixelForCoordinate(
            Com.Mapbox.Geojson.Point.FromLngLat(point.Y, point.X)
            );
        _ = mapView.MapboxMap.QueryRenderedFeatures(
            new RenderedQueryGeometry(
                new ScreenBox(
                    new ScreenCoordinate(pixel.GetX() - 25.0, pixel.GetY() - 25.0),
                    new ScreenCoordinate(pixel.GetX() + 25.0, pixel.GetY() + 25.0)
                )
            ),
            options.ToPlatform(),
            new QueryRenderedFeaturesWithPointCallback(tcs)
        );

        return tcs.Task;
    }

    class QueryRenderedFeaturesWithPointCallback : Java.Lang.Object, IQueryFeaturesCallback
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

            var xfeatures = (p0.Value as Java.Util.IList)?.ToArray().Cast<QueriedFeature>();
            tcs.TrySetResult(xfeatures.Select(x => x.ToX()).ToArray());
        }
    }
}