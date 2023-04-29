namespace MapboxMaui.Annotations;

using IPlatformAnnotationManager = Com.Mapbox.Maps.Plugin.Annotation.IAnnotationManager;

public abstract partial class AnnotationManager<TAnnotationManager, TAnnotation>
    : IAnnotationManager<TAnnotation>
    where TAnnotationManager: IPlatformAnnotationManager
    where TAnnotation: IAnnotation
{
    private readonly string id;

    protected AnnotationManager(
        string id,
        IPlatformAnnotationManager nativeManager)
    {
        this.id = id;
        NativeManager = nativeManager;
    }

    public IPlatformAnnotationManager NativeManager { get; init; }

    public string Id => id;
    public string SourceId => id;
    public string LayerId => id;

    public event EventHandler<AnnotationsSelectedEventArgs> AnnotationsSelected;

    public abstract void AddAnnotations(params TAnnotation[] annotations);
    public abstract void RemoveAllAnnotations();
    public abstract void RemoveAnnotations(params string[] annotationIDs);
}
