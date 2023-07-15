namespace MapboxMaui.Annotations;

using System.Linq;
using Foundation;
using MapboxMapsObjC;

public partial class PointAnnotationManager
    : AnnotationManager<TMBPointAnnotationManager, PointAnnotation>
    , IPointAnnotationManager
{
    private readonly TMBPointAnnotationManager nativeManager;

    public PointAnnotationManager(
        string id,
        TMBPointAnnotationManager nativeManager
    )
    : base(id, nativeManager)
    {
        this.nativeManager = nativeManager;
        nativeManager.Delegate = this;
    }

    public bool? IconAllowOverlap
    {
        get => nativeManager.IconAllowOverlap?.BoolValue;
        set => nativeManager.IconAllowOverlap = value;
    }
    public bool? IconIgnorePlacement
    {
        get => nativeManager.IconIgnorePlacement?.BoolValue;
        set => nativeManager.IconIgnorePlacement = value;
    }
    public bool? IconKeepUpright
    {
        get => nativeManager.IconKeepUpright?.BoolValue;
        set => nativeManager.IconKeepUpright = value;
    }
    public bool? IconOptional
    {
        get => nativeManager.IconOptional?.BoolValue;
        set => nativeManager.IconOptional = value;
    }
    public double? IconPadding
    {
        get => nativeManager.IconPadding?.DoubleValue;
        set => nativeManager.IconPadding = value;
    }
    public IconPitchAlignment? IconPitchAlignment
    {
        get => nativeManager.IconPitchAlignment?.IconPitchAlignmentX();
        set => nativeManager.IconPitchAlignment = value?.AsNumber();
    }
    public IconRotationAlignment? IconRotationAlignment
    {
        get => nativeManager.IconRotationAlignment?.IconRotationAlignmentX();
        set => nativeManager.IconRotationAlignment = value?.AsNumber();
    }
    public IconTextFit? IconTextFit
    {
        get => nativeManager.IconTextFit?.IconTextFitX();
        set => nativeManager.IconTextFit = value?.AsNumber();
    }
    public double[] IconTextFitPadding
    {
        get => nativeManager.IconTextFitPadding?
                .Select(x => x.DoubleValue)
                .ToArray() ?? Array.Empty<double>();
        set => nativeManager.IconTextFitPadding = value?
                .Select(NSNumber.FromDouble)
                .ToArray();
    }
    public bool? SymbolAvoidEdges
    {
        get => nativeManager.SymbolAvoidEdges?.BoolValue;
        set => nativeManager.SymbolAvoidEdges = value;
    }
    public SymbolPlacement? SymbolPlacement
    {
        get => nativeManager.SymbolPlacement?.SymbolPlacementX();
        set => nativeManager.SymbolPlacement = value?.AsNumber();
    }
    public double? SymbolSpacing
    {
        get => nativeManager.SymbolSpacing?.DoubleValue;
        set => nativeManager.SymbolSpacing = value;
    }
    public SymbolZOrder? SymbolZOrder
    {
        get => nativeManager.SymbolZOrder?.SymbolZOrderX();
        set => nativeManager.SymbolZOrder = value?.AsNumber();
    }
    public bool? TextAllowOverlap
    {
        get => nativeManager.TextAllowOverlap?.BoolValue;
        set => nativeManager.TextAllowOverlap = value;
    }
    public string[] TextFont
    {
        get => nativeManager.TextFont;
        set => nativeManager.TextFont = value;
    }
    public bool? TextIgnorePlacement
    {
        get => nativeManager.TextIgnorePlacement?.BoolValue;
        set => nativeManager.TextIgnorePlacement = value;
    }
    public bool? TextKeepUpright
    {
        get => nativeManager.TextKeepUpright?.BoolValue;
        set => nativeManager.TextKeepUpright = value;
    }
    public double? TextMaxAngle
    {
        get => nativeManager.TextMaxAngle?.DoubleValue;
        set => nativeManager.TextMaxAngle = value;
    }
    public bool? TextOptional
    {
        get => nativeManager.TextOptional?.BoolValue;
        set => nativeManager.TextOptional = value;
    }
    public double? TextPadding
    {
        get => nativeManager.TextPadding?.DoubleValue;
        set => nativeManager.TextPadding = value;
    }
    public TextPitchAlignment? TextPitchAlignment
    {
        get => nativeManager.TextPitchAlignment?.TextPitchAlignmentX();
        set => nativeManager.TextPitchAlignment = value?.AsNumber();
    }
    public TextRotationAlignment? TextRotationAlignment
    {
        get => nativeManager.TextRotationAlignment?.StringValue;
        set => nativeManager.TextRotationAlignment = value?.AsNumber();
    }
    public TextAnchor[] TextVariableAnchor
    {
        get => nativeManager.TextVariableAnchor?
                .Select(x => (TextAnchor)x.TextAnchorX())
                .ToArray() ?? Array.Empty<TextAnchor>();
        set => nativeManager.TextVariableAnchor = value?
            .Select(x => x.AsNumber())
            .ToArray();
    }
    public TextWritingMode[] TextWritingMode
    {
        get => nativeManager.TextWritingMode?
                .Select(x => (TextWritingMode)x.TextWritingModeX())
                .ToArray() ?? Array.Empty<TextWritingMode>();
        set => nativeManager.TextWritingMode = value?
            .Select(x => x.AsNumber())
            .ToArray();
    }
    public double[] IconTranslate
    {
        get => nativeManager.IconTranslate?
                .Select(x => x.DoubleValue)
                .ToArray() ?? Array.Empty<double>();
        set => nativeManager.IconTranslate = value?
                .Select(NSNumber.FromDouble)
                .ToArray();
    }
    public IconTranslateAnchor? IconTranslateAnchor
    {
        get => nativeManager.IconTranslateAnchor?.IconTranslateAnchorX();
        set => nativeManager.IconTranslateAnchor = value?.AsNumber();
    }
    public double[] TextTranslate
    {
        get => nativeManager.TextTranslate?
                .Select(x => x.DoubleValue)
                .ToArray() ?? Array.Empty<double>();
        set => nativeManager.TextTranslate = value?
                .Select(NSNumber.FromDouble)
                .ToArray();
    }
    public TextTranslateAnchor? TextTranslateAnchor
    {
        get => nativeManager.TextTranslateAnchor?.TextTranslateAnchorX();
        set => nativeManager.TextTranslateAnchor = value?.AsNumber();
    }
    public double? TextLineHeight
    {
        get => nativeManager.TextLineHeight?.DoubleValue;
        set => nativeManager.TextLineHeight = value;
    }

    public override void AddAnnotations(params PointAnnotation[] xitems)
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
        nativeManager.Annotations = Array.Empty<TMBPointAnnotation>();
    }

    public override void RemoveAnnotations(params string[] annotationIDs)
    {
        for (int i = 0; i < annotationIDs.Length; i++)
        {
            var item = nativeManager.Annotations.FirstOrDefault(
                    x => x.Id == annotationIDs[i]
                );
            if (item == null) continue;

            var annotations = new List<TMBPointAnnotation>(nativeManager.Annotations);
            annotations.Remove(item);

            nativeManager.Annotations = annotations.ToArray();
        }
    }
}

