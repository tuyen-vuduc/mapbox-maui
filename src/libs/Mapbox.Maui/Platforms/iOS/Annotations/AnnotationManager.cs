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

    public void DidDetectTappedAnnotations(ITMBAnnotationManager manager, NSArray annotations)
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

    public abstract void AddAnnotations(params TAnnotation[] annotations);
    public abstract void RemoveAllAnnotations();
    public abstract void RemoveAnnotations(params string[] annotationIDs);
}
