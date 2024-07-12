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
        get => nativeManager.FillTranslateAnchor?.RawValue;
        set => nativeManager.FillTranslateAnchor = value?.ToPlatform();
    }

    public override void AddAnnotations(params PolygonAnnotation[] xitems)
    {
        var items = xitems
            .Select(x => x.ToPlatformValue())
            .ToArray();

        nativeManager.AddAnnotations(items);
    }

    public override void RemoveAllAnnotations()
    {
        nativeManager.RemoveAllAnnotations();
    }

    public override void RemoveAnnotations(params string[] annotationIDs)
    {
        for (int i = 0; i < annotationIDs.Length; i++)
        {
            nativeManager.RemoveAnnotationById(annotationIDs[i]);
        }
    }
}