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

    protected override ITMBAnnotation ToPlatformAnnotationOption(PolygonAnnotation annotation)
        => annotation.ToPlatformValue();
}