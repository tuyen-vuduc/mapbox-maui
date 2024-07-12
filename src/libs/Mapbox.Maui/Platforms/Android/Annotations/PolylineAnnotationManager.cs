namespace MapboxMaui.Annotations;

using Com.Mapbox.Maps.Plugins.Annotations;
using System.Collections;
using PlatformPolylineAnnotationManager = Com.Mapbox.Maps.Plugins.Annotations.Generated.PolylineAnnotationManager;

partial class PolylineAnnotationManager
    : AnnotationManager<PlatformPolylineAnnotationManager, PolylineAnnotation>
    , IPolylineAnnotationManager
{
    private readonly PlatformPolylineAnnotationManager nativeManager;

    public PolylineAnnotationManager(
        string id,
        PlatformPolylineAnnotationManager nativeManager)
        : base(id, nativeManager)
    {
        this.nativeManager = nativeManager;
    }

    public LineCap? LineCap
    {
        get => nativeManager.LineCap?.GetValue();
        set => nativeManager.LineCap = value?.ToPlatform();
    }
    public double? LineMiterLimit
    {
        get => nativeManager.LineMiterLimit?.DoubleValue();
        set => nativeManager.LineMiterLimit = value?.ToPlatform();
    }
    public double? LineRoundLimit
    {
        get => nativeManager.LineRoundLimit?.DoubleValue();
        set => nativeManager.LineRoundLimit = value?.ToPlatform();
    }
    public double[] LineDasharray
    {
        get => nativeManager.LineDasharray?.GetValue();
        set => nativeManager.LineDasharray = value?.ToPlatform();
    }
    public double[] LineTranslate
    {
        get => nativeManager.LineTranslate?.GetValue();
        set => nativeManager.LineTranslate = value?.ToPlatform();
    }
    public LineTranslateAnchor? LineTranslateAnchor
    {
        get => nativeManager.LineTranslateAnchor?.GetValue();
        set => nativeManager.LineTranslateAnchor = value?.ToPlatform();
    }
    public double[] LineTrimOffset
    {
        get => nativeManager.LineTrimOffset?.GetValue();
        set => nativeManager.LineTrimOffset = value?.ToPlatform();
    }

    protected override IAnnotationOptions ToPlatformAnnotationOption(PolylineAnnotation annotation)
        => annotation.ToPlatformValue();
    protected override IList GetNativeAnnotations(params string[] annotationIDs)
    {
        var itemsToDelete = new List<Com.Mapbox.Maps.Plugins.Annotations.Generated.PolylineAnnotation>();
        foreach (var xid in annotationIDs)
        {
            var item = nativeManager
                .Annotations
                .Cast<Com.Mapbox.Maps.Plugins.Annotations.Generated.PolylineAnnotation>()
                .FirstOrDefault(x => x.Id == xid);

            if (item == null) continue;

            itemsToDelete.Add(item);
        }
        return itemsToDelete;
    }
}