namespace MapboxMaui;

using MapboxMaui.Annotations;
using MapboxMaui.Styles;

public interface IAnnotationController
{
    IPolygonAnnotationManager CreatePolygonAnnotationManager(string id, LayerPosition layerPosition);
    ICircleAnnotationManager CreateCircleAnnotationManager(string id, LayerPosition layerPosition);
    IPointAnnotationManager CreatePointAnnotationManager(string id, LayerPosition layerPosition, ClusterOptions clusterOptions = null);
    IPolylineAnnotationManager CreatePolylineAnnotationManager(string id, LayerPosition layerPosition);
}
