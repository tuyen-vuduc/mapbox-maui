namespace MapboxMaui.Annotations;

using Com.Mapbox.Maps.Plugins.Annotations;
using System.Collections;
using PlatformCircleAnnotationManager = Com.Mapbox.Maps.Plugins.Annotations.Generated.CircleAnnotationManager;

public partial class CircleAnnotationManager
    : AnnotationManager<PlatformCircleAnnotationManager, CircleAnnotation>
    , ICircleAnnotationManager
{
    private readonly PlatformCircleAnnotationManager nativeManager;

    public CircleAnnotationManager(
        string id,
        PlatformCircleAnnotationManager nativeManager)
        : base(id, nativeManager)
    {
        this.nativeManager = nativeManager;
    }

    public CirclePitchAlignment? CirclePitchAlignment
    {
        get => nativeManager.CirclePitchAlignment?.GetValue();
        set => nativeManager.CirclePitchAlignment = value?.ToPlatform();
    }
    public CirclePitchScale? CirclePitchScale
    {
        get => nativeManager.CirclePitchScale?.GetValue();
        set => nativeManager.CirclePitchScale = value?.ToPlatform();
    }
    public double[] CircleTranslate
    {
        get => nativeManager.CircleTranslate?
                .Select(x => x.DoubleValue())
                .ToArray();
        set => nativeManager.CircleTranslate = value?
            .Select(x => new Java.Lang.Double(x))
            .ToList();
    }
    public CircleTranslateAnchor? CircleTranslateAnchor
    {
        get => nativeManager.CircleTranslateAnchor?.GetValue();
        set => nativeManager.CircleTranslateAnchor = value?.ToPlatform();
    }

    protected override IAnnotationOptions ToPlatformAnnotationOption(CircleAnnotation annotation)
        => annotation.ToPlatformValue();
    protected override IList GetNativeAnnotations(params string[] annotationIDs)
    {
        var itemsToDelete = new List<Com.Mapbox.Maps.Plugins.Annotations.Generated.CircleAnnotation>();
        foreach (var xid in annotationIDs)
        {
            var item = nativeManager
                .Annotations
                .Cast<Com.Mapbox.Maps.Plugins.Annotations.Generated.CircleAnnotation>()
                .FirstOrDefault(x => x.Id == xid);

            if (item == null) continue;

            itemsToDelete.Add(item);
        }
        return itemsToDelete;
    }
}

