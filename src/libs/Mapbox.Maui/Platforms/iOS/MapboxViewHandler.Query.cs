namespace MapboxMaui;

using MapboxMaui.Query;
using MapboxMapsObjC;
using Foundation;

partial class MapboxViewHandler : IMapFeatureQueryable
{
    public Task<IEnumerable<QueriedFeature>> QueryRenderedFeaturesWith(Point point, RenderedQueryOptions options)
    {
        var mapView = PlatformView.MapView;
        if (mapView == null) return Task.FromResult(
            Array.Empty<QueriedFeature>() as IEnumerable<QueriedFeature>
        );

        var tcs = new TaskCompletionSource<IEnumerable<QueriedFeature>>();

        _ = mapView.MapboxMap().QueryRenderedFeaturesWithPoint(point, options.ToPlatform(), (features, error) => {
            if (error != null) {
                tcs.TrySetException(new NSErrorException(error));
                return;
            }
            var xfeatures = features
                .Select(x => x.ToX())
                .ToArray();

            tcs.TrySetResult(xfeatures);
        });

        return tcs.Task;
    }
}