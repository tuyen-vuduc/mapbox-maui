namespace MapboxMaui.Annotations;

using System.Collections.Generic;
using System.Linq;
using Foundation;
using MapboxMapsObjC;

public partial class CircleAnnotationManager
    : AnnotationManager<TMBPolygonAnnotationManager, CircleAnnotation>
    , ICircleAnnotationManager
{
    private readonly TMBCircleAnnotationManager nativeManager;

    public CircleAnnotationManager(
        string id,
        TMBCircleAnnotationManager nativeManager
    )
    : base(id, nativeManager)
    {
        this.nativeManager = nativeManager;
        nativeManager.Delegate = this;
    }

    public CirclePitchAlignment? CirclePitchAlignment
    {
        get => nativeManager.CirclePitchAlignment?.CirclePitchAlignmentX();
        set => nativeManager.CirclePitchAlignment = value?.AsNumber();
    }
    public CirclePitchScale? CirclePitchScale
    {
        get => nativeManager.CirclePitchScale?.StringValue;
        set => nativeManager.CirclePitchScale = value?.AsNumber();
    }
    public double[] CircleTranslate
    {
        get => nativeManager.CircleTranslate?
            .Select(x => x.DoubleValue)
            .ToArray();
        set => nativeManager.CircleTranslate = value?
            .Select(NSNumber.FromDouble)
            .ToArray();
    }
    public CircleTranslateAnchor? CircleTranslateAnchor
    {
        get => nativeManager.CircleTranslateAnchor?.StringValue;
        set => nativeManager.CircleTranslateAnchor = value?.AsNumber();
    }

    public override void AddAnnotations(params CircleAnnotation[] xitems)
    {
        var items = xitems
            .Select(x => x.ToPlatformValue())
            .ToList();

        nativeManager.Annotations = nativeManager.Annotations
            .Union(items)
            .ToArray();
    }

    public override void RemoveAllAnnotations()
    {
        nativeManager.Annotations = Array.Empty<TMBCircleAnnotation>();
    }

    public override void RemoveAnnotations(params string[] annotationIDs)
    {
        for (int i = 0; i < annotationIDs.Length; i++)
        {
            var item = nativeManager.Annotations.FirstOrDefault(
                    x => x.Id == annotationIDs[i]
                );
            if (item == null) continue;

            var annotations = new List<TMBCircleAnnotation>(nativeManager.Annotations);
            annotations.Remove(item);

            nativeManager.Annotations = annotations.ToArray();
        }
    }
}

