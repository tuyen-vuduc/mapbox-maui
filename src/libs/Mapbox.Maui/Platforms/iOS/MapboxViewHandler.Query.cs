﻿namespace MapboxMaui;

using MapboxMaui.Query;
using MapboxMapsObjC;
using Foundation;

partial class MapboxViewHandler : IMapFeatureQueryable
{
    public Task<IEnumerable<QueriedRenderedFeature>> QueryRenderedFeaturesWith(Point point, RenderedQueryOptions options)
    {
        var mapView = PlatformView.MapView;
        if (mapView == null) return Task.FromResult(
            Array.Empty<QueriedRenderedFeature>() as IEnumerable<QueriedRenderedFeature>
        );

        var tcs = new TaskCompletionSource<IEnumerable<QueriedRenderedFeature>>();

        _ = mapView.MapboxMap().QueryRenderedFeaturesWithPoint(point, options.ToPlatform(), (features, error) => {
            if (error != null) {
                tcs.TrySetException(new NSErrorException(error));
                return;
            }
            var xfeatures = features.ToArray()
                .Select(x => x.ToX())
                .ToArray();

            tcs.TrySetResult(xfeatures);
        });

        return tcs.Task;
    }
}