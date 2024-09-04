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

public interface IAnnotationController
{
    IPolygonAnnotationManager CreatePolygonAnnotationManager(string id, LayerPosition layerPosition);
    ICircleAnnotationManager CreateCircleAnnotationManager(string id, LayerPosition layerPosition);
    IPointAnnotationManager CreatePointAnnotationManager(string id, LayerPosition layerPosition, ClusterOptions clusterOptions = null);
    IPolylineAnnotationManager CreatePolylineAnnotationManager(string id, LayerPosition layerPosition);
}

public interface IMapFeatureQueryable
{
    Task<IEnumerable<QueriedRenderedFeature>> QueryRenderedFeaturesWith(ScreenPosition point, RenderedQueryOptions options);
}

public interface IMapboxController
{
    IPosition GetMapPosition(ScreenPosition position);
    CoordinateBounds GetCoordinateBoundsForCamera(CameraOptions cameraOptions);
    ScreenPosition GetScreenPosition(IPosition position);
    CameraOptions? CameraForCoordinates(
        IEnumerable<IPosition> coordinates,
        CameraOptions? cameraOptions = default,
        Thickness? coordinatesPadding = default,
        double? maxZoom = default,
        ScreenPosition? offset = default
    );
    void CameraForCoordinates(
        IEnumerable<IPosition> coordinates,
        Action<CameraOptions?> completion,
        CameraOptions? cameraOptions = default,
        Thickness? coordinatesPadding = default,
        double? maxZoom = default,
        ScreenPosition? offset = default
    );
    void SetSourcePropertyFor<T>(string sourceId, string propertyName, T value, Action<Exception> completion = default);
    void SetLayerPropertyFor<T>(string layerId, string propertyName, T value, Action<Exception> completion = default);
}

public class MapTappedEventArgs : EventArgs
{
    public MapTappedPosition Position { get; }

    public MapTappedEventArgs(MapTappedPosition position)
    {
        Position = position;
    }
}
public class CameraChangedEventArgs : EventArgs
{
    public CameraChangedEventArgs(CameraOptions options)
    {
        Options = options;
    }

    public CameraOptions Options { get; }
}
public class IndicatorAccuracyRadiusChangedEventArgs : EventArgs
{
    public IndicatorAccuracyRadiusChangedEventArgs(double radius)
    {
        Radius = radius;
    }

    public double Radius { get; }
}
public class IndicatorBearingChangedEventArgs : EventArgs
{
    public IndicatorBearingChangedEventArgs(double bearing)
    {
        Bearing = bearing;
    }

    public double Bearing { get; }
}
public class IndicatorPositionChangedEventArgs : EventArgs
{
    public IndicatorPositionChangedEventArgs(IPosition position)
    {
        Position = position;
    }

    public IPosition Position { get; }
}