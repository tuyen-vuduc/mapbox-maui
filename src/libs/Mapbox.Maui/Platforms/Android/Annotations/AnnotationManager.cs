namespace Mapbox.Maui.Annotations;

using IPlatformAnnotationManager = Com.Mapbox.Maps.Plugin.Annotation.IAnnotationManager;

public abstract partial class AnnotationManager<IPlatformAnnotationManager> : IAnnotationManager
{
    private readonly Guid id;
    private readonly IPlatformAnnotationManager nativeManager;

    protected AnnotationManager(
        Guid id,
        IPlatformAnnotationManager nativeManager)
    {
        this.id = id;
        this.nativeManager = nativeManager;
    }

    public string Id => id.ToString();
    public string SourceId => id.ToString();
    public string LayerId => id.ToString();

    public event EventHandler<AnnotationsSelectedEventArgs> AnnotationsSelected;

    public abstract void AddAnnotations<T>(params T[] annotations) where T : IAnnotation;
    public abstract void RemoveAllAnnotations();
    public abstract void RemoveAnnotations(params string[] annotationIDs);
}
