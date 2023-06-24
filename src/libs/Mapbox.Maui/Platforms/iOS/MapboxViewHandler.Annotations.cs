namespace MapboxMaui;

using MapboxMapsObjC;
using MapboxMaui.Annotations;
using MapboxMaui.Styles;

partial class MapboxViewHandler : IAnnotationController
{

    public IPolygonAnnotationManager CreatePolygonAnnotationManager(
        string id,
        Styles.LayerPosition layerPosition
        )
    {
        var mapView = PlatformView?.MapView;

        if (mapView == null) return null;

        var nativeManager = mapView.PolygonAnnotationManagerWithId(
            id,
            layerPosition.ToPlatformValue(),
            layerPosition.Parameter?.Wrap());

        return new PolygonAnnotationManager(id, nativeManager);
    }

    public ICircleAnnotationManager CreateCircleAnnotationManager(
        string id,
        Styles.LayerPosition layerPosition
        )
    {
        var mapView = PlatformView?.MapView;

        if (mapView == null) return null;

        var nativeManager = mapView.CircleAnnotationManagerWithId(
            id,
            layerPosition.ToPlatformValue(),
            layerPosition.Parameter?.Wrap());

        return new CircleAnnotationManager(id, nativeManager);
    }

    public IPointAnnotationManager CreatePointAnnotationManager(
        string id,
        Styles.LayerPosition layerPosition,
        ClusterOptions clusterOptions = null)
    {
        var mapView = PlatformView?.MapView;

        if (mapView == null) return null;

        TMBClusterOptions nativeClusterOptions = null;
        if (clusterOptions != null)
        {
            nativeClusterOptions = new TMBClusterOptions(
                clusterOptions.CircleRadius?.ToTMBValue(),
                clusterOptions.CircleColor?.ToTMBValue(),
                clusterOptions.TextColor?.ToTMBValue(),
                clusterOptions.TextSize?.ToTMBValue(),
                clusterOptions.TextField?.ToTMBValue(),
                clusterOptions.ClusterRadius,
                clusterOptions.ClusterMaxZoom,
                clusterOptions.ClusterProperties?.ToNative()
            );
        }

        var nativeManager = mapView.PointAnnotationManagerWithId(
            id,
            layerPosition.ToPlatformValue(),
            layerPosition.Parameter?.Wrap(),
            nativeClusterOptions);

        return new PointAnnotationManager(id, nativeManager);
    }

    public IPolylineAnnotationManager CreatePolylineAnnotationManager(string id, LayerPosition layerPosition)
    {
        var mapView = PlatformView?.MapView;

        if (mapView == null) return null;

        var nativeManager = mapView.PolylineAnnotationManagerWithId(
            id,
            layerPosition.ToPlatformValue(),
            layerPosition.Parameter?.Wrap()
        );

        return new PolylineAnnotationManager(id, nativeManager);
    }
}