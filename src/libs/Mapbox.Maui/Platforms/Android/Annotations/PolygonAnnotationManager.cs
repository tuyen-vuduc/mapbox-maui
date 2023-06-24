namespace MapboxMaui.Annotations;

using PlatformPolygonAnnotationManager = Com.Mapbox.Maps.Plugin.Annotation.Generated.PolygonAnnotationManager;

partial class PolygonAnnotationManager
    : AnnotationManager<PlatformPolygonAnnotationManager, PolygonAnnotation>
    , IPolygonAnnotationManager
{
    private readonly PlatformPolygonAnnotationManager nativeManager;

    public PolygonAnnotationManager(
        string id,
        PlatformPolygonAnnotationManager nativeManager)
        : base(id, nativeManager)
    {
        this.nativeManager = nativeManager;
    }

    public bool? FillAntialias
    {
        get => nativeManager.FillAntialias?.BooleanValue();
        set => nativeManager.FillAntialias = value?.ToPlatform();
    }
    public double[] FillTranslate
    {
        get => nativeManager.FillTranslate.GetValue();
        set => nativeManager.FillTranslate = value.ToPlatform();
    }
    public FillTranslateAnchor? FillTranslateAnchor
    {
        get => nativeManager.FillTranslateAnchor != null
            ? (FillTranslateAnchor)nativeManager.FillTranslateAnchor.GetValue()
            : null;
        set => nativeManager.FillTranslateAnchor = value != null
            ? Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.FillTranslateAnchor.ValueOf(value.Value)
            : null;
    }

    public override void AddAnnotations(params PolygonAnnotation[] xitems)
    {
        var items = xitems
            .Select(x => x.ToPlatformValue())
            .ToList();

        var platformAnnotations = nativeManager.Create(items);

        for (int i = 0; i < platformAnnotations.Count; i++)
        {
            var item = platformAnnotations[i] as Com.Mapbox.Maps.Plugin.Annotation.Generated.PolygonAnnotation;
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
                .Cast<Com.Mapbox.Maps.Plugin.Annotation.Generated.PolygonAnnotation>()
                .FirstOrDefault(x => x.Id == id);

            if (item == null) continue;

            nativeManager.Annotations.Remove(item);
        }
    }
}