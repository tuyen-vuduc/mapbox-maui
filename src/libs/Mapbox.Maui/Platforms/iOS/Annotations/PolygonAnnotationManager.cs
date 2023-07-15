namespace MapboxMaui.Annotations;

using System.Collections.Generic;
using System.Linq;
using MapboxMapsObjC;

public partial class PolygonAnnotationManager
    : AnnotationManager<TMBPolygonAnnotationManager, PolygonAnnotation>
    , IPolygonAnnotationManager
{
    private readonly TMBPolygonAnnotationManager nativeManager;

    public PolygonAnnotationManager(
        string id,
        TMBPolygonAnnotationManager nativeManager
    )
    : base(id, nativeManager)
    {
        this.nativeManager = nativeManager;
        nativeManager.Delegate = this;
    }

    public bool? FillAntialias
    {
        get => nativeManager.FillAntialias?.BoolValue;
        set => nativeManager.FillAntialias = value;
    }
    public double[] FillTranslate
    {
        get => nativeManager.FillTranslate?.ToDoubles();
        set => nativeManager.FillTranslate = value?.ToPlatform();
    }
    public FillTranslateAnchor? FillTranslateAnchor
    {
        get => nativeManager.FillTranslateAnchor?.FillTranslateAnchorX();
        set => nativeManager.FillTranslateAnchor = value?.AsNumber();
    }

    public override void AddAnnotations(params PolygonAnnotation[] xitems)
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
        nativeManager.Annotations = Array.Empty<TMBPolygonAnnotation>();
    }

    public override void RemoveAnnotations(params string[] annotationIDs)
    {
        for (int i = 0; i < annotationIDs.Length; i++)
        {
            var item = nativeManager.Annotations.FirstOrDefault(
                    x => x.Id == annotationIDs[i]
                );
            if (item == null) continue;

            var annotations = new List<TMBPolygonAnnotation>(nativeManager.Annotations);
            annotations.Remove(item);

            nativeManager.Annotations = annotations.ToArray();
        }
    }
}