namespace MapboxMaui.Annotations;

using Com.Mapbox.Maps.Plugins.Annotations;
using System.Collections;
using PlatformPointAnnotationManager = Com.Mapbox.Maps.Plugins.Annotations.Generated.PointAnnotationManager;

public partial class PointAnnotationManager
    : AnnotationManager<PlatformPointAnnotationManager, PointAnnotation>
    , IPointAnnotationManager
{
    private readonly PlatformPointAnnotationManager nativeManager;

    public PointAnnotationManager(
        string id,
        PlatformPointAnnotationManager nativeManager)
        : base(id, nativeManager)
    {
        this.nativeManager = nativeManager;
    }
    public bool? IconAllowOverlap
    {
        get => nativeManager.IconAllowOverlap?.BooleanValue();
        set => nativeManager.IconAllowOverlap = value?.ToPlatform();
    }
    public bool? IconIgnorePlacement
    {
        get => nativeManager.IconIgnorePlacement?.BooleanValue();
        set => nativeManager.IconIgnorePlacement = value?.ToPlatform();
    }
    public bool? IconKeepUpright
    {
        get => nativeManager.IconKeepUpright?.BooleanValue();
        set => nativeManager.IconKeepUpright = value?.ToPlatform();
    }
    public bool? IconOptional
    {
        get => nativeManager.IconOptional?.BooleanValue();
        set => nativeManager.IconOptional = value?.ToPlatform();
    }
    public double? IconPadding
    {
        get => nativeManager.IconPadding?.DoubleValue();
        set => nativeManager.IconPadding = value?.ToPlatform();
    }
    public IconPitchAlignment? IconPitchAlignment
    {
        get => nativeManager.IconPitchAlignment?.GetValue();
        set => nativeManager.IconPitchAlignment = value?.ToPlatform();
    }
    public IconRotationAlignment? IconRotationAlignment
    {
        get => nativeManager.IconRotationAlignment?.GetValue();
        set => nativeManager.IconRotationAlignment = value?.ToPlatform();
    }
    public bool? SymbolAvoidEdges
    {
        get => nativeManager.SymbolAvoidEdges?.BooleanValue();
        set => nativeManager.SymbolAvoidEdges = value?.ToPlatform();
    }
    public SymbolPlacement? SymbolPlacement
    {
        get => nativeManager.SymbolPlacement?.GetValue();
        set => nativeManager.SymbolPlacement = value?.ToPlatform();
    }
    public double? SymbolSpacing
    {
        get => nativeManager.SymbolSpacing?.DoubleValue();
        set => nativeManager.SymbolSpacing = value?.ToPlatform();
    }
    public SymbolZOrder? SymbolZOrder
    {
        get => nativeManager.SymbolZOrder?.GetValue();
        set => nativeManager.SymbolZOrder = value?.ToPlatform();
    }
    public bool? TextAllowOverlap
    {
        get => nativeManager.TextAllowOverlap?.BooleanValue();
        set => nativeManager.TextAllowOverlap = value?.ToPlatform();
    }
    public string[] TextFont
    {
        get => nativeManager.TextFont?.ToArray();
        set => nativeManager.TextFont = value;
    }
    public bool? TextIgnorePlacement
    {
        get => nativeManager.TextIgnorePlacement?.BooleanValue();
        set => nativeManager.TextIgnorePlacement = value?.ToPlatform();
    }
    public bool? TextKeepUpright
    {
        get => nativeManager.TextKeepUpright?.BooleanValue();
        set => nativeManager.TextKeepUpright = value?.ToPlatform();
    }
    public double? TextMaxAngle
    {
        get => nativeManager.TextMaxAngle?.DoubleValue();
        set => nativeManager.TextMaxAngle = value?.ToPlatform();
    }
    public bool? TextOptional
    {
        get => nativeManager.TextOptional?.BooleanValue();
        set => nativeManager.TextOptional = value?.ToPlatform();
    }
    public double? TextPadding
    {
        get => nativeManager.TextPadding?.DoubleValue();
        set => nativeManager.TextPadding = value?.ToPlatform();
    }
    public TextPitchAlignment? TextPitchAlignment
    {
        get => nativeManager.TextPitchAlignment?.GetValue();
        set => nativeManager.TextPitchAlignment = value?.ToPlatform();
    }
    public TextRotationAlignment? TextRotationAlignment
    {
        get => nativeManager.TextRotationAlignment?.GetValue();
        set => nativeManager.TextRotationAlignment = value?.ToPlatform();
    }
    public TextAnchor[] TextVariableAnchor
    {
        get => nativeManager.TextVariableAnchor?
            .Select(x => (TextAnchor)x)
            .ToArray();
        set => nativeManager.TextVariableAnchor = value?
            .Select(x => x.Value)
            .ToArray();
    }
    public TextWritingMode[] TextWritingMode
    {
        get => nativeManager.TextWritingMode?
            .Select(x => (TextWritingMode)x)
            .ToArray();
        set => nativeManager.TextWritingMode = value?
            .Select(x => x.Value)
            .ToArray();
    }
    public double[] IconTranslate
    {
        get => nativeManager.IconTranslate?.GetValue();
        set => nativeManager.IconTranslate = value?.ToPlatform();
    }
    public IconTranslateAnchor? IconTranslateAnchor
    {
        get => nativeManager.IconTranslateAnchor?.GetValue();
        set => nativeManager.IconTranslateAnchor = value?.ToPlatform();
    }
    public double[] TextTranslate
    {
        get => nativeManager.TextTranslate?.GetValue();
        set => nativeManager.TextTranslate = value?.ToPlatform();
    }
    public TextTranslateAnchor? TextTranslateAnchor
    {
        get => nativeManager.TextTranslateAnchor?.GetValue();
        set => nativeManager.TextTranslateAnchor = value?.ToPlatform();
    }

    protected override IAnnotationOptions ToPlatformAnnotationOption(PointAnnotation annotation)
        => annotation.ToPlatformValue();

    protected override IList GetNativeAnnotations(params string[] annotationIDs)
    {
        var itemsToDelete = new List<Com.Mapbox.Maps.Plugins.Annotations.Generated.PointAnnotation>();
        foreach (var xid in annotationIDs)
        {
            var item = nativeManager
                .Annotations
                .Cast<Com.Mapbox.Maps.Plugins.Annotations.Generated.PointAnnotation>()
                .FirstOrDefault(x => x.Id == xid);

            if (item == null) continue;

            itemsToDelete.Add(item);
        }
        return itemsToDelete;
    }
    protected override Annotation ToPlatformAnnotation(PointAnnotation annotation)
        => (Annotation)annotation.ToPlatformValue().Build(annotation.Id, nativeManager);
}

