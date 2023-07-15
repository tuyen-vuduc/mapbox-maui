namespace MapboxMaui.Styles;

public class LineLayer : MapboxLayer
{
    public LineLayer(string id)
        : base(id)
    {
        Type = LayerType.Line;
        Visibility = new PropertyValue<Visibility>(MapboxMaui.Visibility.Visible);
    }

    /// The display of line endings.
    public PropertyValue<LineCap> LineCap
    {
        get => GetProperty<PropertyValue<LineCap>>(
            LayoutCodingKeys.lineCap,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LayoutCodingKeys.lineCap,
            value,
            MapboxLayerKey.layout
        );
    }

    /// The display of lines when joining.
    public PropertyValue<LineJoin> LineJoin
    {
        get => GetProperty<PropertyValue<LineJoin>>(
            LayoutCodingKeys.lineJoin,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LayoutCodingKeys.lineJoin,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Used to automatically convert miter joins to bevel joins for sharp angles.
    public PropertyValue<double> LineMiterLimit
    {
        get => GetProperty<PropertyValue<double>>(
            LayoutCodingKeys.lineMiterLimit,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LayoutCodingKeys.lineMiterLimit,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Used to automatically convert round joins to miter joins for shallow angles.
    public PropertyValue<double> LineRoundLimit
    {
        get => GetProperty<PropertyValue<double>>(
            LayoutCodingKeys.lineRoundLimit,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LayoutCodingKeys.lineRoundLimit,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Sorts features in ascending order based on this value. Features with a higher sort key will appear above features with a lower sort key.
    public PropertyValue<double> LineSortKey
    {
        get => GetProperty<PropertyValue<double>>(
            LayoutCodingKeys.lineSortKey,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LayoutCodingKeys.lineSortKey,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Blur applied to the line, in pixels.
    public PropertyValue<double> LineBlur
    {
        get => GetProperty<PropertyValue<double>>(
            LineLayerKey.lineBlur,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LineLayerKey.lineBlur,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `lineBlur`.
    public PropertyValue<StyleTransition> LineBlurTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            LineLayerKey.lineBlurTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LineLayerKey.lineBlurTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The color with which the line will be drawn.
    public PropertyValue<Color> LineColor
    {
        get => GetProperty<PropertyValue<Color>>(
            LineLayerKey.lineColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LineLayerKey.lineColor,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `lineColor`.
    public PropertyValue<StyleTransition> LineColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            LineLayerKey.lineColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LineLayerKey.lineColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Specifies the lengths of the alternating dashes and gaps that form the dash pattern. The lengths are later scaled by the line width. To convert a dash length to pixels, multiply the length by the current line width. Note that GeoJSON sources with `lineMetrics: true` specified won't render dashed lines to the expected scale. Also note that zoom-dependent expressions will be evaluated only at integer zoom levels.
    public PropertyValue<double[]> LineDasharray
    {
        get => GetProperty<PropertyValue<double[]>>(
            LineLayerKey.lineDasharray,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LineLayerKey.lineDasharray,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Draws a line casing outside of a line's actual path. Value indicates the width of the inner gap.
    public PropertyValue<double> LineGapWidth
    {
        get => GetProperty<PropertyValue<double>>(
            LineLayerKey.lineGapWidth,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LineLayerKey.lineGapWidth,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `lineGapWidth`.
    public PropertyValue<StyleTransition> LineGapWidthTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            LineLayerKey.lineGapWidthTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LineLayerKey.lineGapWidthTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Defines a gradient with which to color a line feature. Can only be used with GeoJSON sources that specify `"lineMetrics": true`.
    public PropertyValue<Color> LineGradient
    {
        get => GetProperty<PropertyValue<Color>>(
            LineLayerKey.lineGradient,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LineLayerKey.lineGradient,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The line's offset. For linear features, a positive value offsets the line to the right, relative to the direction of the line, and a negative value to the left. For polygon features, a positive value results in an inset, and a negative value results in an outset.
    public PropertyValue<double> LineOffset
    {
        get => GetProperty<PropertyValue<double>>(
            LineLayerKey.lineOffset,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LineLayerKey.lineOffset,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `lineOffset`.
    public PropertyValue<StyleTransition> LineOffsetTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            LineLayerKey.lineOffsetTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LineLayerKey.lineOffsetTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The opacity at which the line will be drawn.
    public PropertyValue<double> LineOpacity
    {
        get => GetProperty<PropertyValue<double>>(
            LineLayerKey.lineOpacity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LineLayerKey.lineOpacity,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `lineOpacity`.
    public PropertyValue<StyleTransition> LineOpacityTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            LineLayerKey.lineOpacityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LineLayerKey.lineOpacityTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Name of image in sprite to use for drawing image lines. For seamless patterns, image width must be a factor of two (2, 4, 8, ..., 512). Note that zoom-dependent expressions will be evaluated only at integer zoom levels.
    public PropertyValue<ResolvedImage> LinePattern
    {
        get => GetProperty<PropertyValue<ResolvedImage>>(
            LineLayerKey.linePattern,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LineLayerKey.linePattern,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The geometry's offset. Values are [x, y] where negatives indicate left and up, respectively.
    public PropertyValue<double[]> LineTranslate
    {
        get => GetProperty<PropertyValue<double[]>>(
            LineLayerKey.lineTranslate,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LineLayerKey.lineTranslate,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `lineTranslate`.
    public PropertyValue<StyleTransition> LineTranslateTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            LineLayerKey.lineTranslateTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LineLayerKey.lineTranslateTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Controls the frame of reference for `line-translate`.
    public PropertyValue<LineTranslateAnchor> LineTranslateAnchor
    {
        get => GetProperty<PropertyValue<LineTranslateAnchor>>(
            LineLayerKey.lineTranslateAnchor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LineLayerKey.lineTranslateAnchor,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The line part between [trim-start, trim-end] will be marked as transparent to make a route vanishing effect. The line trim-off offset is based on the whole line range [0.0, 1.0].
    public PropertyValue<double[]> LineTrimOffset
    {
        get => GetProperty<PropertyValue<double[]>>(
            LineLayerKey.lineTrimOffset,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LineLayerKey.lineTrimOffset,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Stroke thickness.
    public PropertyValue<double> LineWidth
    {
        get => GetProperty<PropertyValue<double>>(
            LineLayerKey.lineWidth,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LineLayerKey.lineWidth,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `lineWidth`.
    public PropertyValue<StyleTransition> LineWidthTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            LineLayerKey.lineWidthTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LineLayerKey.lineWidthTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    static class LayoutCodingKeys
    {
        public const string lineCap = "line-cap";
        public const string lineJoin = "line-join";
        public const string lineMiterLimit = "line-miter-limit";
        public const string lineRoundLimit = "line-round-limit";
        public const string lineSortKey = "line-sort-key";
        public const string visibility = "visibility";
    }

    static class LineLayerKey
    {
        public const string lineBlur = "line-blur";
        public const string lineBlurTransition = "line-blur-transition";
        public const string lineColor = "line-color";
        public const string lineColorTransition = "line-color-transition";
        public const string lineDasharray = "line-dasharray";
        public const string lineGapWidth = "line-gap-width";
        public const string lineGapWidthTransition = "line-gap-width-transition";
        public const string lineGradient = "line-gradient";
        public const string lineOffset = "line-offset";
        public const string lineOffsetTransition = "line-offset-transition";
        public const string lineOpacity = "line-opacity";
        public const string lineOpacityTransition = "line-opacity-transition";
        public const string linePattern = "line-pattern";
        public const string lineTranslate = "line-translate";
        public const string lineTranslateTransition = "line-translate-transition";
        public const string lineTranslateAnchor = "line-translate-anchor";
        public const string lineTrimOffset = "line-trim-offset";
        public const string lineWidth = "line-width";
        public const string lineWidthTransition = "line-width-transition";
    }
}

