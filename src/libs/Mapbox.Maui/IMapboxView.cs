namespace MapboxMaui;

using System.Windows.Input;
using MapboxMaui.Annotations;
using MapboxMaui.Locations;
using MapboxMaui.Query;
using MapboxMaui.Styles;
using MapboxMaui.Viewport;

public partial interface IMapboxView : IView
{
    CameraOptions CameraOptions { get; set; }
    GestureSettings GestureSettings { get; set; }
    MapboxStyle MapboxStyle { get; set; }
    IPosition MapCenter { get; set; }
    float? MapZoom { get; set; }

    OrnamentVisibility ScaleBarVisibility { get; set; }

    DebugOption[] DebugOptions { get; set; }

    IEnumerable<MapboxSource> Sources { get; set; }

    IEnumerable<MapboxLayer> Layers { get; set; }

    IEnumerable<ResolvedImage> Images { get; set; }

    IEnumerable<ViewAnnotationOptions> ViewAnnotations { get; set; }

    Terrain Terrain { get; set; }

    Light Light { get; set; }
    IViewAnnotationController ViewAnnotationController { get; }

    IAnnotationController AnnotationController { get; }

    IMapFeatureQueryable QueryManager { get; }

    IViewportPlugin Viewport { get; }

    ILocationComponentPlugin LocationComponent { get; }
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

    event EventHandler<CameraChangedEventArgs> CameraChanged;
    ICommand CameraChangedCommand { get; }

    event EventHandler<Viewport.ViewportStatusChangedEventArgs> ViewportStatusChanged;
    ICommand ViewportStatusChangedCommand { get; }

    event EventHandler<Gestures.RotatingBeganEventArgs> RotatingBegan;
    ICommand RotatingBeganCommand { get; }
    event EventHandler<Gestures.RotatingEndedEventArgs> RotatingEnded;
    ICommand RotatingEndedCommand { get; }
    event EventHandler<Gestures.RotatingEventArgs> Rotating;
    ICommand RotatingCommand { get; }
}

public interface IMapFeatureQueryable
{
    Task<IEnumerable<QueriedRenderedFeature>> QueryRenderedFeaturesWith(ScreenPosition point, RenderedQueryOptions options);
}
