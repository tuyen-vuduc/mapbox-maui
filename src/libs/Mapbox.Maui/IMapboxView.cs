namespace Mapbox.Maui;

using System.Windows.Input;
using Mapbox.Maui.Annotations;
using Mapbox.Maui.Styles;

public partial interface IMapboxView : IView
{
    CameraOptions CameraOptions { get; set; }
    MapboxStyle MapboxStyle { get; set; }
    Point? MapCenter { get; set; }
    float? MapZoom { get; set; }

    OrnamentVisibility ScaleBarVisibility { get; set; }

    DebugOption[] DebugOptions { get; set; }

    IEnumerable<MapboxSource> Sources { get; set; }

    Terrain Terrain { get; set; }

    Light Light { get; set; }

    IEnumerable<MapboxLayer> Layers { get; set; }

    IAnnotationController AnnotationController { get; }
}

partial interface IMapboxView { 
    event EventHandler MapReady;
    ICommand MapReadyCommand { get; set; }

    event EventHandler StyleLoaded;
    ICommand StyleLoadedCommand { get; set; }

    event EventHandler MapLoaded;
    ICommand MapLoadedCommand { get; set; }
}

public interface IAnnotationController
{
    public IPolygonAnnotationManager CreatePolygonAnnotationManager(string id, LayerPosition layerPosition);
    //public IAnnotationManager<Annotations.PolygonAnnotation> CircleAnnotationManager(string id);
    //public IAnnotationManager<Annotations.PolygonAnnotation> PointAnnotationManager(string id);
    //public IAnnotationManager<Annotations.PolygonAnnotation> PolylineAnnotationManager(string id);
}
