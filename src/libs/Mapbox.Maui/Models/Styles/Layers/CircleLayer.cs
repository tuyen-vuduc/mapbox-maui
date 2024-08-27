namespace MapboxMaui.Styles;

/// A filled circle.
///
/// - SeeAlso: [Mapbox Style Specification](https://www.mapbox.com/mapbox-gl-style-spec/#layers-circle)
public class CircleLayer : MapboxLayer
{
    public CircleLayer(string id, string source)
        : base(id)
    {
        Type = LayerType.Circle;
        Source = source;
        Visibility = new PropertyValue<Visibility>(MapboxMaui.Visibility.Visible);
    }
    /// Sorts features in ascending order based on this value. Features with a higher sort key will appear above features with a lower sort key.
    public PropertyValue<double> CircleSortKey
    {
        get => GetProperty<PropertyValue<double>>(
            LayoutCodingKeys.CircleSortKey,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.CircleSortKey,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Amount to blur the circle. 1 blurs the circle such that only the centerpoint is full opacity.
    /// Default value: 0.
    public PropertyValue<double> CircleBlur
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.CircleBlur,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.CircleBlur,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `circleBlur`.
    public PropertyValue<StyleTransition> CircleBlurTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.CircleBlurTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.CircleBlurTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The fill color of the circle.
    /// Default value: "#000000".
    public PropertyValue<Color> CircleColor
    {
        get => GetProperty<PropertyValue<Color>>(
            PaintCodingKeys.CircleColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.CircleColor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `circleColor`.
    public PropertyValue<StyleTransition> CircleColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.CircleColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.CircleColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Controls the intensity of light emitted on the source features.
    /// Default value: 0. Minimum value: 0.
    public PropertyValue<double> CircleEmissiveStrength
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.CircleEmissiveStrength,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.CircleEmissiveStrength,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `circleEmissiveStrength`.
    public PropertyValue<StyleTransition> CircleEmissiveStrengthTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.CircleEmissiveStrengthTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.CircleEmissiveStrengthTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The opacity at which the circle will be drawn.
    /// Default value: 1. Value range: [0, 1]
    public PropertyValue<double> CircleOpacity
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.CircleOpacity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.CircleOpacity,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `circleOpacity`.
    public PropertyValue<StyleTransition> CircleOpacityTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.CircleOpacityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.CircleOpacityTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Orientation of circle when map is pitched.
    /// Default value: "viewport".
    public PropertyValue<CirclePitchAlignment> CirclePitchAlignment
    {
        get => GetProperty<PropertyValue<CirclePitchAlignment>>(
            PaintCodingKeys.CirclePitchAlignment,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.CirclePitchAlignment,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Controls the scaling behavior of the circle when the map is pitched.
    /// Default value: "map".
    public PropertyValue<CirclePitchScale> CirclePitchScale
    {
        get => GetProperty<PropertyValue<CirclePitchScale>>(
            PaintCodingKeys.CirclePitchScale,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.CirclePitchScale,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Circle radius.
    /// Default value: 5. Minimum value: 0.
    public PropertyValue<double> CircleRadius
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.CircleRadius,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.CircleRadius,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `circleRadius`.
    public PropertyValue<StyleTransition> CircleRadiusTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.CircleRadiusTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.CircleRadiusTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The stroke color of the circle.
    /// Default value: "#000000".
    public PropertyValue<Color> CircleStrokeColor
    {
        get => GetProperty<PropertyValue<Color>>(
            PaintCodingKeys.CircleStrokeColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.CircleStrokeColor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `circleStrokeColor`.
    public PropertyValue<StyleTransition> CircleStrokeColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.CircleStrokeColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.CircleStrokeColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The opacity of the circle's stroke.
    /// Default value: 1. Value range: [0, 1]
    public PropertyValue<double> CircleStrokeOpacity
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.CircleStrokeOpacity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.CircleStrokeOpacity,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `circleStrokeOpacity`.
    public PropertyValue<StyleTransition> CircleStrokeOpacityTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.CircleStrokeOpacityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.CircleStrokeOpacityTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The width of the circle's stroke. Strokes are placed outside of the `circle-radius`.
    /// Default value: 0. Minimum value: 0.
    public PropertyValue<double> CircleStrokeWidth
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.CircleStrokeWidth,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.CircleStrokeWidth,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `circleStrokeWidth`.
    public PropertyValue<StyleTransition> CircleStrokeWidthTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.CircleStrokeWidthTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.CircleStrokeWidthTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The geometry's offset. Values are [x, y] where negatives indicate left and up, respectively.
    /// Default value: [0,0].
    public PropertyValue<double[]> CircleTranslate
    {
        get => GetProperty<PropertyValue<double[]>>(
            PaintCodingKeys.CircleTranslate,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.CircleTranslate,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `circleTranslate`.
    public PropertyValue<StyleTransition> CircleTranslateTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.CircleTranslateTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.CircleTranslateTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Controls the frame of reference for `circle-translate`.
    /// Default value: "map".
    public PropertyValue<CircleTranslateAnchor> CircleTranslateAnchor
    {
        get => GetProperty<PropertyValue<CircleTranslateAnchor>>(
            PaintCodingKeys.CircleTranslateAnchor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.CircleTranslateAnchor,
            value,
            MapboxLayerKey.paint
        );
    }

    public static class PaintCodingKeys {
        public const string CircleBlur = "circle-blur";
        public const string CircleBlurTransition = "circle-blur-transition";
        public const string CircleColor = "circle-color";
        public const string CircleColorTransition = "circle-color-transition";
        public const string CircleEmissiveStrength = "circle-emissive-strength";
        public const string CircleEmissiveStrengthTransition = "circle-emissive-strength-transition";
        public const string CircleOpacity = "circle-opacity";
        public const string CircleOpacityTransition = "circle-opacity-transition";
        public const string CirclePitchAlignment = "circle-pitch-alignment";
        public const string CirclePitchScale = "circle-pitch-scale";
        public const string CircleRadius = "circle-radius";
        public const string CircleRadiusTransition = "circle-radius-transition";
        public const string CircleStrokeColor = "circle-stroke-color";
        public const string CircleStrokeColorTransition = "circle-stroke-color-transition";
        public const string CircleStrokeOpacity = "circle-stroke-opacity";
        public const string CircleStrokeOpacityTransition = "circle-stroke-opacity-transition";
        public const string CircleStrokeWidth = "circle-stroke-width";
        public const string CircleStrokeWidthTransition = "circle-stroke-width-transition";
        public const string CircleTranslate = "circle-translate";
        public const string CircleTranslateTransition = "circle-translate-transition";
        public const string CircleTranslateAnchor = "circle-translate-anchor";
    }

    public static class LayoutCodingKeys {
        public const string CircleSortKey = "circle-sort-key";
    }
}