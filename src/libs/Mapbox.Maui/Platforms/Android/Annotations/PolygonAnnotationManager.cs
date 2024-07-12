namespace MapboxMaui.Annotations;

using Com.Mapbox.Maps.Plugins.Annotations;
using System.Collections;
using PlatformPolygonAnnotationManager = Com.Mapbox.Maps.Plugins.Annotations.Generated.PolygonAnnotationManager;

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

    protected override IAnnotationOptions ToPlatformAnnotationOption(PolygonAnnotation annotation)
        => annotation.ToPlatformValue();
    protected override IList GetNativeAnnotations(params string[] annotationIDs)
    {
        var itemsToDelete = new List<Com.Mapbox.Maps.Plugins.Annotations.Generated.PolygonAnnotation>();
        foreach (var id in annotationIDs)
        {
            var item = nativeManager
                .Annotations
                .Cast<Com.Mapbox.Maps.Plugins.Annotations.Generated.PolygonAnnotation>()
                .FirstOrDefault(x => x.Id == id);

            if (item == null) continue;

            itemsToDelete.Add(item);
        }
        return itemsToDelete;
    }
}