namespace MapboxMaui.Annotations;

using Foundation;
using MapboxMapsObjC;

public abstract partial class AnnotationManager<TAnnotationManager, TAnnotation>
    : NSObject
    , IAnnotationManager<TAnnotation>
    , ITMBAnnotationInteractionDelegate
    where TAnnotationManager : ITMBAnnotationManager
    where TAnnotation : IAnnotation
{
    private readonly string id;

    protected AnnotationManager(string id, ITMBAnnotationManager nativeManager)
    {
        this.id = id;
        NativeManager = nativeManager;
    }

    public ITMBAnnotationManager NativeManager { get; init; }

    public string Id => id;
    public string SourceId => id;
    public string LayerId => id;

    public event EventHandler<AnnotationsSelectedEventArgs> AnnotationsSelected;

    public void DidDetectTappedAnnotations(ITMBAnnotationManager manager, NSObject[] annotations)
    {
        if (AnnotationsSelected == null) return;

        AnnotationsSelected?.Invoke(
            this,
            new AnnotationsSelectedEventArgs(
                annotations
                    .Cast<ITMBAnnotation>()
                    .Select(x => x.Id)
                    .ToArray()
            )
        );
    }

    public void AddAnnotations(params TAnnotation[] xitems)
    {
        if (xitems.Length == 0) return; 

        var items = xitems
            .Select(ToPlatformAnnotationOption)
            .ToArray();

        NativeManager.AddAnnotations(items);
    }
    public void UpdateAnnotations(params TAnnotation[] xitems)
    {
        if (xitems.Length == 0) return;

        var items = xitems
            .Select(ToPlatformAnnotationOption)
            .ToArray();

        NativeManager.UpdateAnnotations(items);
    }
    public void RemoveAllAnnotations()
        => NativeManager.RemoveAllAnnotations();
    public void RemoveAnnotations(params string[] annotationIDs)
    {
        for (int i = 0; i < annotationIDs.Length; i++)
        {
            NativeManager.RemoveAnnotationById(annotationIDs[i]);
        }
    }

    protected abstract ITMBAnnotation ToPlatformAnnotationOption(TAnnotation annotation);
}
