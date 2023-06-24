namespace MapboxMaui.Annotations;

using PlatformPolylineAnnotationManager = Com.Mapbox.Maps.Plugin.Annotation.Generated.PolylineAnnotationManager;

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

    public override void AddAnnotations(params PolylineAnnotation[] xitems)
    {
        var items = xitems
            .Select(x => x.ToPlatformValue())
            .ToList();

        var platformAnnotations = nativeManager.Create(items);

        for (int i = 0; i < platformAnnotations.Count; i++)
        {
            var item = platformAnnotations[i] as Com.Mapbox.Maps.Plugin.Annotation.Generated.PolylineAnnotation;
            xitems[i].Id = item.Id.ToString();
        }
    }

    public override void RemoveAllAnnotations()
    {
        nativeManager.Annotations.Clear();
    }

    public override void RemoveAnnotations(params string[] annotationIDs)
    {
        foreach (var xid in annotationIDs)
        {
            if (!long.TryParse(xid, out var id)) continue;

            var item = nativeManager
                .Annotations
                .Cast<Com.Mapbox.Maps.Plugin.Annotation.Generated.PolylineAnnotation>()
                .FirstOrDefault(x => x.Id == id);

            if (item == null) continue;

            nativeManager.Annotations.Remove(item);
        }
    }
}