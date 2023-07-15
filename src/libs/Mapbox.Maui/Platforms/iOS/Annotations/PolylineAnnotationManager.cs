namespace MapboxMaui.Annotations;

using System.Collections.Generic;
using System.Linq;
using MapboxMapsObjC;

public partial class PolylineAnnotationManager
    : AnnotationManager<TMBPolylineAnnotationManager, PolylineAnnotation>
    , IPolylineAnnotationManager
{
    private readonly TMBPolylineAnnotationManager nativeManager;

    public PolylineAnnotationManager(
        string id,
        TMBPolylineAnnotationManager nativeManager
    )
    : base(id, nativeManager)
    {
        this.nativeManager = nativeManager;
        nativeManager.Delegate = this;
    }

    public LineCap? LineCap
    {
        get => nativeManager.LineCap?.LineCapX();
        set => nativeManager.LineCap = value?.AsNumber();
    }
    public double? LineMiterLimit
    {
        get => nativeManager.LineMiterLimit?.DoubleValue;
        set => nativeManager.LineMiterLimit = value.ToPlatform();
    }
    public double? LineRoundLimit
    {
        get => nativeManager.LineRoundLimit?.DoubleValue;
        set => nativeManager.LineRoundLimit = value.ToPlatform();
    }
    public double[] LineDasharray
    {
        get => nativeManager.LineDasharray?.ToDoubles();
        set => nativeManager.LineDasharray = value?.ToPlatform();
    }
    public double[] LineTranslate
    {
        get => nativeManager.LineTranslate?.ToDoubles();
        set => nativeManager.LineTranslate = value?.ToPlatform();
    }
    public LineTranslateAnchor? LineTranslateAnchor
    {
        get => nativeManager.LineTranslateAnchor?.LineTranslateAnchorX();
        set => nativeManager.LineTranslateAnchor = value?.AsNumber();
    }
    public double[] LineTrimOffset
    {
        get => nativeManager.LineTrimOffset?.ToDoubles();
        set => nativeManager.LineTrimOffset = value?.ToPlatform();
    }

    public override void AddAnnotations(params PolylineAnnotation[] xitems)
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
        nativeManager.Annotations = Array.Empty<TMBPolylineAnnotation>();
    }

    public override void RemoveAnnotations(params string[] annotationIDs)
    {
        for (int i = 0; i < annotationIDs.Length; i++)
        {
            var item = nativeManager.Annotations.FirstOrDefault(
                    x => x.Id == annotationIDs[i]
                );
            if (item == null) continue;

            var annotations = new List<TMBPolylineAnnotation>(nativeManager.Annotations);
            annotations.Remove(item);

            nativeManager.Annotations = annotations.ToArray();
        }
    }
}