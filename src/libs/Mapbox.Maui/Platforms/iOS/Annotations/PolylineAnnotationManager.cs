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
    }

    public LineCap? LineCap
    {
        get => nativeManager.LineCap?.RawValue;
        set => nativeManager.LineCap = value?.ToPlatform();
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
        get => nativeManager.LineTranslateAnchor?.RawValue;
        set => nativeManager.LineTranslateAnchor = value?.ToPlatform();
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