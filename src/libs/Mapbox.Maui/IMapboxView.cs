namespace MapboxMaui;

using System.Windows.Input;
using MapboxMaui.Annotations;
using MapboxMaui.Query;
using MapboxMaui.Styles;

public partial interface IMapboxView : IView
{
    CameraOptions CameraOptions { get; set; }
    MapboxStyle MapboxStyle { get; set; }
    Point? MapCenter { get; set; }
    float? MapZoom { get; set; }

    OrnamentVisibility ScaleBarVisibility { get; set; }

    DebugOption[] DebugOptions { get; set; }

    IEnumerable<MapboxSource> Sources { get; set; }

    IEnumerable<MapboxLayer> Layers { get; set; }

    IEnumerable<ResolvedImage> Images { get; set; }

    IEnumerable<ViewAnnotationOptions> ViewAnnotations { get; set; }

    Terrain Terrain { get; set; }

    Light Light { get; set; }

    IAnnotationController AnnotationController { get; }

    IMapFeatureQueryable QueryManager { get; }
}

partial interface IMapboxView
{
    event EventHandler MapReady;
    ICommand MapReadyCommand { get; set; }

    event EventHandler StyleLoaded;
    ICommand StyleLoadedCommand { get; set; }

    event EventHandler MapLoaded;
    ICommand MapLoadedCommand { get; set; }

    event EventHandler<MapTappedEventArgs> MapTapped;
    ICommand Command { get; }
}

public interface IAnnotationController
{
    IPolygonAnnotationManager CreatePolygonAnnotationManager(string id, LayerPosition layerPosition);
    ICircleAnnotationManager CreateCircleAnnotationManager(string id, LayerPosition layerPosition);
    IPointAnnotationManager CreatePointAnnotationManager(string id, LayerPosition layerPosition, ClusterOptions clusterOptions = null);
    IPolylineAnnotationManager CreatePolylineAnnotationManager(string id, LayerPosition layerPosition);
}

public interface IMapFeatureQueryable
{
    Task<IEnumerable<QueriedFeature>> QueryRenderedFeaturesWith(Point point, RenderedQueryOptions options);
}

public class MapTappedEventArgs : EventArgs
{
    public MapTappedPosition Position { get; }

    public MapTappedEventArgs(MapTappedPosition position)
    {
        Position = position;
    }
}