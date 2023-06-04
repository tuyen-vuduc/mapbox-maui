namespace MapboxMaui.Annotations;

using PlatformCircleAnnotationManager = Com.Mapbox.Maps.Plugin.Annotation.Generated.CircleAnnotationManager;

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

    public override void AddAnnotations(params CircleAnnotation[] xitems)
    {
        var items = xitems
            .Select(x => x.ToPlatformValue())
            .ToList();

        var platformAnnotations = nativeManager.Create(items);

        for (int i = 0; i < platformAnnotations.Count; i++)
        {
            var item = platformAnnotations[i] as Com.Mapbox.Maps.Plugin.Annotation.Generated.CircleAnnotation;
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
                .Cast<Com.Mapbox.Maps.Plugin.Annotation.Generated.CircleAnnotation>()
                .FirstOrDefault(x => x.Id == id);

            if (item == null) continue;

            nativeManager.Annotations.Remove(item);
        }
    }
}

