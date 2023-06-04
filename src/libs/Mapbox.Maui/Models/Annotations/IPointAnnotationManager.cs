namespace MapboxMaui.Annotations;

public interface IPointAnnotationManager : IAnnotationManager<PointAnnotation>
{
    bool? IconAllowOverlap { get; set; }
    bool? IconIgnorePlacement { get; set; }
    bool? IconKeepUpright { get; set; }
    bool? IconOptional { get; set; }
    double? IconPadding { get; set; }
    IconPitchAlignment? IconPitchAlignment { get; set; }
    IconRotationAlignment? IconRotationAlignment { get; set; }
    IconTextFit? IconTextFit { get; set; }
    double[] IconTextFitPadding { get; set; }
    bool? SymbolAvoidEdges { get; set; }
    SymbolPlacement? SymbolPlacement { get; set; }
    double? SymbolSpacing { get; set; }
    SymbolZOrder? SymbolZOrder { get; set; }
    bool? TextAllowOverlap { get; set; }
    string[] TextFont { get; set; }
    bool? TextIgnorePlacement { get; set; }
    bool? TextKeepUpright { get; set; }
    double? TextMaxAngle { get; set; }
    bool? TextOptional { get; set; }
    double? TextPadding { get; set; }
    TextPitchAlignment? TextPitchAlignment { get; set; }
    TextRotationAlignment? TextRotationAlignment { get; set; }
    TextAnchor[] TextVariableAnchor { get; set; }
    TextWritingMode[] TextWritingMode { get; set; }
    double[] IconTranslate { get; set; }
    IconTranslateAnchor? IconTranslateAnchor { get; set; }
    double[] TextTranslate { get; set; }
    TextTranslateAnchor? TextTranslateAnchor { get; set; }
    double? TextLineHeight { get; set; }
}

public partial class PointAnnotationManager
{
}

