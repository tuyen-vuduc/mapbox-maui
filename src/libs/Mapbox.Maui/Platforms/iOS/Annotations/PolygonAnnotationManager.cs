namespace Mapbox.Maui.Annotations;

using System.Collections.Generic;
using System.Linq;
using Foundation;
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
        nativeManager.Delegate = this;
    }

    public bool? FillAntialias
    {
        get => nativeManager.FillAntialias?.BoolValue;
        set => nativeManager.FillAntialias = value;
    }
    public double[] FillTranslate
    {
        get => nativeManager.FillTranslate?
            .Select(x => x.DoubleValue)
            .ToArray();
        set => nativeManager.FillTranslate = value?
            .Select(NSNumber.FromDouble)
            .ToArray();
    }
    public FillTranslateAnchor? FillTranslateAnchor
    {
        get => nativeManager.FillTranslateAnchor.StringValue;
        set => nativeManager.FillTranslateAnchor = string.IsNullOrWhiteSpace(value)
            ? null
            : new TMBFillTranslateAnchor(value);
    }

    public override void AddAnnotations(params PolygonAnnotation[] xitems)
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
        nativeManager.Annotations = Array.Empty<TMBPolygonAnnotation>();
    }

    public override void RemoveAnnotations(params string[] annotationIDs)
    {
        for (int i = 0; i < annotationIDs.Length; i++)
        {
            var item = nativeManager.Annotations.FirstOrDefault(
                    x => x.Id == annotationIDs[i]
                );
            if (item == null) continue;

            var annotations = new List<TMBPolygonAnnotation>(nativeManager.Annotations);
            annotations.Remove(item);

            nativeManager.Annotations = annotations.ToArray();
        }
    }
}