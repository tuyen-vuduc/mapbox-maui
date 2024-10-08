﻿namespace MapboxMaui.Annotations;

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
        get => nativeManager.IconPitchAlignment?.RawValue;
        set => nativeManager.IconPitchAlignment = value?.ToPlatform();
    }
    public IconRotationAlignment? IconRotationAlignment
    {
        get => nativeManager.IconRotationAlignment?.RawValue;
        set => nativeManager.IconRotationAlignment = value?.ToPlatform();
    }
    public bool? SymbolAvoidEdges
    {
        get => nativeManager.SymbolAvoidEdges?.BoolValue;
        set => nativeManager.SymbolAvoidEdges = value;
    }
    public SymbolPlacement? SymbolPlacement
    {
        get => nativeManager.SymbolPlacement?.RawValue;
        set => nativeManager.SymbolPlacement = value?.ToPlatform();
    }
    public double? SymbolSpacing
    {
        get => nativeManager.SymbolSpacing?.DoubleValue;
        set => nativeManager.SymbolSpacing = value;
    }
    public SymbolZOrder? SymbolZOrder
    {
        get => nativeManager.SymbolZOrder?.RawValue;
        set => nativeManager.SymbolZOrder = value?.ToPlatform();
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
        get => nativeManager.TextPitchAlignment?.RawValue;
        set => nativeManager.TextPitchAlignment = value?.ToPlatform();
    }
    public TextRotationAlignment? TextRotationAlignment
    {
        get => nativeManager.TextRotationAlignment?.RawValue;
        set => nativeManager.TextRotationAlignment = value?.ToPlatform();
    }
    public TextAnchor[] TextVariableAnchor
    {
        get => nativeManager.TextVariableAnchor?
                .Select(x => (TextAnchor)x.RawValue)
                .ToArray() ?? Array.Empty<TextAnchor>();
        set => nativeManager.TextVariableAnchor = value?
            .Select(x => x.ToPlatform())
            .ToArray();
    }
    public TextWritingMode[] TextWritingMode
    {
        get => nativeManager.TextWritingMode?
                .Select(x => (TextWritingMode)x.RawValue)
                .ToArray() ?? Array.Empty<TextWritingMode>();
        set => nativeManager.TextWritingMode = value?
            .Select(x => x.ToPlatform())
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
        get => nativeManager.IconTranslateAnchor?.RawValue;
        set => nativeManager.IconTranslateAnchor = value?.ToPlatform();
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
        get => nativeManager.TextTranslateAnchor?.RawValue;
        set => nativeManager.TextTranslateAnchor = value?.ToPlatform();
    }

    protected override ITMBAnnotation ToPlatformAnnotationOption(PointAnnotation annotation)
        => annotation.ToPlatformValue();
}

