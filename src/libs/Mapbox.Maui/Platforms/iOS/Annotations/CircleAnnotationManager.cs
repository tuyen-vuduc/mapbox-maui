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
    }

    public CirclePitchAlignment? CirclePitchAlignment
    {
        get => nativeManager.CirclePitchAlignment?.RawValue;
        set => nativeManager.CirclePitchAlignment = value?.ToPlatform();
    }
    public CirclePitchScale? CirclePitchScale
    {
        get => nativeManager.CirclePitchScale?.RawValue;
        set => nativeManager.CirclePitchScale = value?.ToPlatform();
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
        get => nativeManager.CircleTranslateAnchor?.RawValue;
        set => nativeManager.CircleTranslateAnchor = value?.ToPlatform();
    }

    protected override ITMBAnnotation ToPlatformAnnotationOption(CircleAnnotation annotation)
        => annotation.ToPlatformValue();
}

