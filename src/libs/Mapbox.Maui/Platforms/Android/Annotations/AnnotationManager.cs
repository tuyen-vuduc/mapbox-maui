namespace MapboxMaui.Annotations;

using Com.Mapbox.Maps.Plugins.Annotations;
using System.Collections;
using IPlatformAnnotationManager = Com.Mapbox.Maps.Plugins.Annotations.IAnnotationManager;

public abstract partial class AnnotationManager<TAnnotationManager, TAnnotation>
    : IAnnotationManager<TAnnotation>
    where TAnnotationManager : IPlatformAnnotationManager
    where TAnnotation : IAnnotation
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

    public void AddAnnotations(params TAnnotation[] annotations)
    {
        var xannotations = annotations
            .Select(ToPlatformAnnotationOption)
            .ToList();
        var platformAnnotations = NativeManager.Create(xannotations);
        for (int i = 0; i < platformAnnotations.Count; i++)
        {
            var item = platformAnnotations[i] as Com.Mapbox.Maps.Plugins.Annotations.Annotation;
            annotations[i].Id = item.Id.ToString();
        }
    }
    public void RemoveAllAnnotations()
        => NativeManager.DeleteAll();
    public void RemoveAnnotations(params string[] annotationIDs)
    {
        var annotations = GetNativeAnnotations(annotationIDs);
        NativeManager.Delete(annotations);
    }

    protected abstract IAnnotationOptions ToPlatformAnnotationOption(TAnnotation annotation);
    protected abstract IList GetNativeAnnotations(params string[] annotationIDs);
}
