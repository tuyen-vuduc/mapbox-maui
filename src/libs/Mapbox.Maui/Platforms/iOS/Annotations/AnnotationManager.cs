namespace Mapbox.Maui.Annotations;

using Foundation;
using MapboxMapsObjC;

public abstract partial class AnnotationManager<ITMBAnnotationManager>
    : NSObject
    , IAnnotationManager
    , ITMBAnnotationInteractionDelegate
{
    private readonly Guid id;

    protected AnnotationManager(Guid id, ITMBAnnotationManager nativeManager)
    {
        this.id = id;
        NativeManager = nativeManager;
    }

    public ITMBAnnotationManager NativeManager { get; init; }

    public string Id => id.ToString();
    public string SourceId => id.ToString();
    public string LayerId => id.ToString();

    public event EventHandler<AnnotationsSelectedEventArgs> AnnotationsSelected;

    public void DidDetectTappedAnnotations(MapboxMapsObjC.ITMBAnnotationManager manager, NSArray annotations)
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

    public abstract void AddAnnotations<T>(params T[] annotations) where T : IAnnotation;
    public abstract void RemoveAllAnnotations();
    public abstract void RemoveAnnotations(params string[] annotationIDs);
}
