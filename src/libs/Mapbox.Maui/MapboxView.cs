namespace MapboxMaui;

using MapboxMaui.Annotations;
using MapboxMaui.Styles;

public partial class MapboxView : View, IMapboxView
{
    public static readonly BindableProperty ViewAnnotationsProperty = BindableProperty.Create(
       nameof(ViewAnnotations),
       typeof(IEnumerable<ViewAnnotationOptions>),
       typeof(MapboxView)
    );
    public IEnumerable<ViewAnnotationOptions> ViewAnnotations
    {
        get => (IEnumerable<ViewAnnotationOptions>)GetValue(ViewAnnotationsProperty);
        set => SetValue(ViewAnnotationsProperty, value);
    }

    public static readonly BindableProperty AnnotationsProperty = BindableProperty.Create(
       nameof(Annotations),
       typeof(IEnumerable<IAnnotation>),
       typeof(MapboxView)
    );
    public IEnumerable<IAnnotation> Annotations
    {
        get => (IEnumerable<IAnnotation>)GetValue(AnnotationsProperty);
        set => SetValue(AnnotationsProperty, value);
    }

    public static readonly BindableProperty SourcesProperty = BindableProperty.Create(
       nameof(Sources),
       typeof(IEnumerable<MapboxSource>),
       typeof(MapboxView)
    );
    public IEnumerable<MapboxSource> Sources
    {
        get => (IEnumerable<MapboxSource>)GetValue(SourcesProperty);
        set => SetValue(SourcesProperty, value);
    }

    public static readonly BindableProperty LayersProperty = BindableProperty.Create(
       nameof(Layers),
       typeof(IEnumerable<MapboxLayer>),
       typeof(MapboxView)
    );
    public IEnumerable<MapboxLayer> Layers
    {
        get => (IEnumerable<MapboxLayer>)GetValue(LayersProperty);
        set => SetValue(LayersProperty, value);
    }

    public static readonly BindableProperty ImagesProperty = BindableProperty.Create(
       nameof(Images),
       typeof(IEnumerable<ResolvedImage>),
       typeof(MapboxView)
    );
    public IEnumerable<ResolvedImage> Images
    {
        get => (IEnumerable<ResolvedImage>)GetValue(ImagesProperty);
        set => SetValue(ImagesProperty, value);
    }

    public static readonly BindableProperty TerrainProperty = BindableProperty.Create(
       nameof(Terrain),
       typeof(Terrain),
       typeof(MapboxView)
    );
    public Terrain Terrain
    {
        get => (Terrain)GetValue(TerrainProperty);
        set => SetValue(TerrainProperty, value);
    }

    public static readonly BindableProperty LightProperty = BindableProperty.Create(
       nameof(Light),
       typeof(Light),
       typeof(MapboxView)
    );
    public Light Light
    {
        get => (Light)GetValue(LightProperty);
        set => SetValue(LightProperty, value);
    }

    public static readonly BindableProperty DebugOptionsProperty = BindableProperty.Create(
       nameof(DebugOptions),
       typeof(DebugOption[]),
       typeof(MapboxView)
    );
    public DebugOption[] DebugOptions
    {
        get => (DebugOption[])GetValue(DebugOptionsProperty);
        set => SetValue(DebugOptionsProperty, value);
    }

    public static readonly BindableProperty ScaleBarVisibilityProperty = BindableProperty.Create(
       nameof(ScaleBarVisibility),
       typeof(OrnamentVisibility),
       typeof(MapboxView),
       OrnamentVisibility.Hidden
    );
    public OrnamentVisibility ScaleBarVisibility
    {
        get => (OrnamentVisibility)GetValue(ScaleBarVisibilityProperty);
        set => SetValue(ScaleBarVisibilityProperty, value);
    }

    public static readonly BindableProperty CameraOptionsProperty = BindableProperty.Create(
       nameof(CameraOptions),
       typeof(CameraOptions),
       typeof(MapboxView),
       default(CameraOptions)
    );
    public CameraOptions CameraOptions
    {
        get => (CameraOptions)GetValue(CameraOptionsProperty);
        set => SetValue(CameraOptionsProperty, value);
    }

    public static readonly BindableProperty MapCenterProperty = BindableProperty.Create(
       nameof(MapCenter),
       typeof(Point?),
       typeof(MapboxView),
       default(Point?)
    );
    public Point? MapCenter
    {
        get => CameraOptions.Center;
        set => CameraOptions = CameraOptions with
        {
            Center = value
        };
    }

    public static readonly BindableProperty MapPaddingProperty = BindableProperty.Create(
       nameof(MapPadding),
       typeof(Thickness?),
       typeof(MapboxView),
       default(Thickness?)
    );
    public Thickness? MapPadding
    {
        get => CameraOptions.Padding;
        set => CameraOptions = CameraOptions with
        {
            Padding = value
        };
    }

    public static readonly BindableProperty MapAnchorProperty = BindableProperty.Create(
       nameof(MapAnchor),
       typeof(Point?),
       typeof(MapboxView),
       default(Point?)
    );
    public Point? MapAnchor
    {
        get => CameraOptions.Anchor;
        set => CameraOptions = CameraOptions with
        {
            Anchor = value
        };
    }

    public static readonly BindableProperty MapZoomProperty = BindableProperty.Create(
       nameof(MapZoom),
       typeof(float?),
       typeof(MapboxView),
       default(float?)
    );
    public float? MapZoom
    {
        get => CameraOptions.Zoom;
        set => CameraOptions = CameraOptions with
        {
            Zoom = value
        };
    }

    public static readonly BindableProperty MapBearingProperty = BindableProperty.Create(
       nameof(MapBearing),
       typeof(float?),
       typeof(MapboxView),
       default(float?)
    );
    public float? MapBearing
    {
        get => CameraOptions.Bearing;
        set => CameraOptions = CameraOptions with
        {
            Bearing = value
        };
    }

    public static readonly BindableProperty MapPitchProperty = BindableProperty.Create(
       nameof(MapPitch),
       typeof(float?),
       typeof(MapboxView),
       default(float?)
    );
    public float? MapPitch
    {
        get => CameraOptions.Pitch;
        set => CameraOptions = CameraOptions with
        {
            Pitch = value
        };
    }

    public static readonly BindableProperty MapboxStyleProperty = BindableProperty.Create(
       nameof(MapboxStyle),
       typeof(MapboxStyle),
       typeof(MapboxView),
       default(MapboxStyle)
    );
    public MapboxStyle MapboxStyle
    {
        get => (MapboxStyle)GetValue(MapboxStyleProperty);
        set => SetValue(MapboxStyleProperty, value);
    }

    public IAnnotationController AnnotationController { get; internal set; }
    public IMapFeatureQueryable QueryManager { get; internal set; }
}