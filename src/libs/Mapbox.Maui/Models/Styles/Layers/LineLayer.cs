namespace MapboxMaui.Styles;

/// A stroked line.
///
/// - SeeAlso: [Mapbox Style Specification](https://www.mapbox.com/mapbox-gl-style-spec/#layers-line)
public class LineLayer : MapboxLayer
{
    public LineLayer(string id, string source)
        : base(id)
    {
        Type = LayerType.Line;
        Source = source;
        Visibility = new PropertyValue<Visibility>(MapboxMaui.Visibility.Visible);
    }
    /// The display of line endings.
    /// Default value: "butt".
    public PropertyValue<LineCap> LineCap
    {
        get => GetProperty<PropertyValue<LineCap>>(
            LayoutCodingKeys.LineCap,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.LineCap,
            value,
            MapboxLayerKey.layout
        );
    }
    /// The display of lines when joining.
    /// Default value: "miter".
    public PropertyValue<LineJoin> LineJoin
    {
        get => GetProperty<PropertyValue<LineJoin>>(
            LayoutCodingKeys.LineJoin,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.LineJoin,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Used to automatically convert miter joins to bevel joins for sharp angles.
    /// Default value: 2.
    public PropertyValue<double> LineMiterLimit
    {
        get => GetProperty<PropertyValue<double>>(
            LayoutCodingKeys.LineMiterLimit,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.LineMiterLimit,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Used to automatically convert round joins to miter joins for shallow angles.
    /// Default value: 1.05.
    public PropertyValue<double> LineRoundLimit
    {
        get => GetProperty<PropertyValue<double>>(
            LayoutCodingKeys.LineRoundLimit,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.LineRoundLimit,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Sorts features in ascending order based on this value. Features with a higher sort key will appear above features with a lower sort key.
    public PropertyValue<double> LineSortKey
    {
        get => GetProperty<PropertyValue<double>>(
            LayoutCodingKeys.LineSortKey,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.LineSortKey,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Vertical offset from ground, in meters. Defaults to 0. Not supported for globe projection at the moment.
    /// Blur applied to the line, in pixels.
    /// Default value: 0. Minimum value: 0.
    public PropertyValue<double> LineBlur
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.LineBlur,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineBlur,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `lineBlur`.
    public PropertyValue<StyleTransition> LineBlurTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.LineBlurTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineBlurTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The color of the line border. If line-border-width is greater than zero and the alpha value of this color is 0 (default), the color for the border will be selected automatically based on the line color.
    /// Default value: "rgba(0, 0, 0, 0)".
    public PropertyValue<Color> LineBorderColor
    {
        get => GetProperty<PropertyValue<Color>>(
            PaintCodingKeys.LineBorderColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineBorderColor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `lineBorderColor`.
    public PropertyValue<StyleTransition> LineBorderColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.LineBorderColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineBorderColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The width of the line border. A value of zero means no border.
    /// Default value: 0. Minimum value: 0.
    public PropertyValue<double> LineBorderWidth
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.LineBorderWidth,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineBorderWidth,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `lineBorderWidth`.
    public PropertyValue<StyleTransition> LineBorderWidthTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.LineBorderWidthTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineBorderWidthTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The color with which the line will be drawn.
    /// Default value: "#000000".
    public PropertyValue<Color> LineColor
    {
        get => GetProperty<PropertyValue<Color>>(
            PaintCodingKeys.LineColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineColor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `lineColor`.
    public PropertyValue<StyleTransition> LineColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.LineColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Specifies the lengths of the alternating dashes and gaps that form the dash pattern. The lengths are later scaled by the line width. To convert a dash length to pixels, multiply the length by the current line width. Note that GeoJSON sources with `lineMetrics: true` specified won't render dashed lines to the expected scale. Also note that zoom-dependent expressions will be evaluated only at integer zoom levels.
    /// Minimum value: 0.
    public PropertyValue<double[]> LineDasharray
    {
        get => GetProperty<PropertyValue<double[]>>(
            PaintCodingKeys.LineDasharray,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineDasharray,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Decrease line layer opacity based on occlusion from 3D objects. Value 0 disables occlusion, value 1 means fully occluded.
    /// Default value: 1. Value range: [0, 1]
    public PropertyValue<double> LineDepthOcclusionFactor
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.LineDepthOcclusionFactor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineDepthOcclusionFactor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `lineDepthOcclusionFactor`.
    public PropertyValue<StyleTransition> LineDepthOcclusionFactorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.LineDepthOcclusionFactorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineDepthOcclusionFactorTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Controls the intensity of light emitted on the source features.
    /// Default value: 0. Minimum value: 0.
    public PropertyValue<double> LineEmissiveStrength
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.LineEmissiveStrength,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineEmissiveStrength,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `lineEmissiveStrength`.
    public PropertyValue<StyleTransition> LineEmissiveStrengthTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.LineEmissiveStrengthTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineEmissiveStrengthTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Draws a line casing outside of a line's actual path. Value indicates the width of the inner gap.
    /// Default value: 0. Minimum value: 0.
    public PropertyValue<double> LineGapWidth
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.LineGapWidth,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineGapWidth,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `lineGapWidth`.
    public PropertyValue<StyleTransition> LineGapWidthTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.LineGapWidthTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineGapWidthTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// A gradient used to color a line feature at various distances along its length. Defined using a `step` or `interpolate` expression which outputs a color for each corresponding `line-progress` input value. `line-progress` is a percentage of the line feature's total length as measured on the webmercator projected coordinate plane (a `number` between `0` and `1`). Can only be used with GeoJSON sources that specify `"lineMetrics": true`.
    public PropertyValue<Color> LineGradient
    {
        get => GetProperty<PropertyValue<Color>>(
            PaintCodingKeys.LineGradient,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineGradient,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Opacity multiplier (multiplies line-opacity value) of the line part that is occluded by 3D objects. Value 0 hides occluded part, value 1 means the same opacity as non-occluded part. The property is not supported when `line-opacity` has data-driven styling.
    /// Default value: 0. Value range: [0, 1]
    /// Transition options for `lineOcclusionOpacity`.
    /// The line's offset. For linear features, a positive value offsets the line to the right, relative to the direction of the line, and a negative value to the left. For polygon features, a positive value results in an inset, and a negative value results in an outset.
    /// Default value: 0.
    public PropertyValue<double> LineOffset
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.LineOffset,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineOffset,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `lineOffset`.
    public PropertyValue<StyleTransition> LineOffsetTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.LineOffsetTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineOffsetTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The opacity at which the line will be drawn.
    /// Default value: 1. Value range: [0, 1]
    public PropertyValue<double> LineOpacity
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.LineOpacity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineOpacity,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `lineOpacity`.
    public PropertyValue<StyleTransition> LineOpacityTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.LineOpacityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineOpacityTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Name of image in sprite to use for drawing image lines. For seamless patterns, image width must be a factor of two (2, 4, 8, ..., 512). Note that zoom-dependent expressions will be evaluated only at integer zoom levels.
    public PropertyValue<ResolvedImage> LinePattern
    {
        get => GetProperty<PropertyValue<ResolvedImage>>(
            PaintCodingKeys.LinePattern,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LinePattern,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The geometry's offset. Values are [x, y] where negatives indicate left and up, respectively.
    /// Default value: [0,0].
    public PropertyValue<double[]> LineTranslate
    {
        get => GetProperty<PropertyValue<double[]>>(
            PaintCodingKeys.LineTranslate,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineTranslate,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `lineTranslate`.
    public PropertyValue<StyleTransition> LineTranslateTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.LineTranslateTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineTranslateTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Controls the frame of reference for `line-translate`.
    /// Default value: "map".
    public PropertyValue<LineTranslateAnchor> LineTranslateAnchor
    {
        get => GetProperty<PropertyValue<LineTranslateAnchor>>(
            PaintCodingKeys.LineTranslateAnchor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineTranslateAnchor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The line part between [trim-start, trim-end] will be marked as transparent to make a route vanishing effect. The line trim-off offset is based on the whole line range [0.0, 1.0].
    /// Default value: [0,0]. Minimum value: [0,0]. Maximum value: [1,1].
    public PropertyValue<double[]> LineTrimOffset
    {
        get => GetProperty<PropertyValue<double[]>>(
            PaintCodingKeys.LineTrimOffset,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineTrimOffset,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Stroke thickness.
    /// Default value: 1. Minimum value: 0.
    public PropertyValue<double> LineWidth
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.LineWidth,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineWidth,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `lineWidth`.
    public PropertyValue<StyleTransition> LineWidthTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.LineWidthTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LineWidthTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    public static class PaintCodingKeys {
        public const string LineBlur = "line-blur";
        public const string LineBlurTransition = "line-blur-transition";
        public const string LineBorderColor = "line-border-color";
        public const string LineBorderColorTransition = "line-border-color-transition";
        public const string LineBorderWidth = "line-border-width";
        public const string LineBorderWidthTransition = "line-border-width-transition";
        public const string LineColor = "line-color";
        public const string LineColorTransition = "line-color-transition";
        public const string LineDasharray = "line-dasharray";
        public const string LineDepthOcclusionFactor = "line-depth-occlusion-factor";
        public const string LineDepthOcclusionFactorTransition = "line-depth-occlusion-factor-transition";
        public const string LineEmissiveStrength = "line-emissive-strength";
        public const string LineEmissiveStrengthTransition = "line-emissive-strength-transition";
        public const string LineGapWidth = "line-gap-width";
        public const string LineGapWidthTransition = "line-gap-width-transition";
        public const string LineGradient = "line-gradient";
        public const string LineOcclusionOpacity = "line-occlusion-opacity";
        public const string LineOcclusionOpacityTransition = "line-occlusion-opacity-transition";
        public const string LineOffset = "line-offset";
        public const string LineOffsetTransition = "line-offset-transition";
        public const string LineOpacity = "line-opacity";
        public const string LineOpacityTransition = "line-opacity-transition";
        public const string LinePattern = "line-pattern";
        public const string LineTranslate = "line-translate";
        public const string LineTranslateTransition = "line-translate-transition";
        public const string LineTranslateAnchor = "line-translate-anchor";
        public const string LineTrimOffset = "line-trim-offset";
        public const string LineWidth = "line-width";
        public const string LineWidthTransition = "line-width-transition";
    }

    public static class LayoutCodingKeys {
        public const string LineCap = "line-cap";
        public const string LineJoin = "line-join";
        public const string LineMiterLimit = "line-miter-limit";
        public const string LineRoundLimit = "line-round-limit";
        public const string LineSortKey = "line-sort-key";
        public const string LineZOffset = "line-z-offset";
    }
}