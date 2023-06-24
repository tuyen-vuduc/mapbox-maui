namespace MapboxMaui;

using PlatformPolygonAnnotationManager = Com.Mapbox.Maps.Plugin.Annotation.Generated.PolygonAnnotationManager;
using PlatformCircleAnnotationManager = Com.Mapbox.Maps.Plugin.Annotation.Generated.CircleAnnotationManager;
using PlatformPointAnnotationManager = Com.Mapbox.Maps.Plugin.Annotation.Generated.PointAnnotationManager;
using PlatformPolylineAnnotationManager = Com.Mapbox.Maps.Plugin.Annotation.Generated.PolylineAnnotationManager;
using Com.Mapbox.Maps.Plugin.Annotation;
using MapboxMaui.Annotations;
using MapboxMaui.Styles;

partial class MapboxViewHandler : IAnnotationController
{
    public IPolygonAnnotationManager CreatePolygonAnnotationManager(
        string id,
        Styles.LayerPosition layerPosition)
    {
        var mapView = mapboxFragment?.MapView;

        if (mapView == null) return null;

        var nativeManager = AnnotationPluginImplKt
            .GetAnnotations(mapView)
            .CreateAnnotationManager(
                AnnotationType.PolygonAnnotation,
                new AnnotationConfig(null, id, id, null)
            ) as PlatformPolygonAnnotationManager;

        return new PolygonAnnotationManager(id, nativeManager);
    }

    public ICircleAnnotationManager CreateCircleAnnotationManager(
        string id,
        Styles.LayerPosition layerPosition)
    {
        var mapView = mapboxFragment?.MapView;

        if (mapView == null) return null;

        var nativeManager = AnnotationPluginImplKt
            .GetAnnotations(mapView)
            .CreateAnnotationManager(
                AnnotationType.CircleAnnotation,
                new AnnotationConfig(null, id, id, null)
            ) as PlatformCircleAnnotationManager;

        return new CircleAnnotationManager(id, nativeManager);
    }

    public IPointAnnotationManager CreatePointAnnotationManager(
        string id,
        Styles.LayerPosition layerPosition,
        Annotations.ClusterOptions clusterOptions = null)
    {
        var mapView = mapboxFragment?.MapView;

        if (mapView == null) return null;

        var xclusterOptions = clusterOptions.ToPlatform();
        var clusterMaxZoom = clusterOptions != null
            ? new Java.Lang.Long((long)clusterOptions.ClusterMaxZoom)
            : null;
        var options = new AnnotationSourceOptions(
            clusterMaxZoom,
            null, null, null,
            xclusterOptions);
        var nativeManager = AnnotationPluginImplKt
            .GetAnnotations(mapView)
            .CreateAnnotationManager(
                AnnotationType.PointAnnotation,
                new AnnotationConfig(null, id, id, options)
            ) as PlatformPointAnnotationManager;

        return new PointAnnotationManager(id, nativeManager);
    }

    public IPolylineAnnotationManager CreatePolylineAnnotationManager(string id, LayerPosition layerPosition)
    {
        var mapView = mapboxFragment?.MapView;

        if (mapView == null) return null;

        var nativeManager = AnnotationPluginImplKt
            .GetAnnotations(mapView)
            .CreateAnnotationManager(
                AnnotationType.PolylineAnnotation,
                new AnnotationConfig(null, id, id, null)
            ) as PlatformPolylineAnnotationManager;

        return new PolylineAnnotationManager(id, nativeManager);
    }
}