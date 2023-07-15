namespace MapboxMaui.Styles;

public class CircleLayer : MapboxLayer
{
    public CircleLayer(string id)
        : base(id)
    {
        Type = LayerType.Circle;
        Visibility = new PropertyValue<Visibility>(MapboxMaui.Visibility.Visible);
    }
    /// Sorts features in ascending order based on this value. Features with a higher sort key will appear above features with a lower sort key.
    public PropertyValue<double> CircleSortKey
    {
        get => GetProperty<PropertyValue<double>>(
            CircleLayerLayoutKey.circleSortKey,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            CircleLayerLayoutKey.circleSortKey,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Amount to blur the circle. 1 blurs the circle such that only the centerpoint is full opacity.
    public PropertyValue<double> CircleBlur
    {
        get => GetProperty<PropertyValue<double>>(
            CircleLayerKey.circleBlur,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            CircleLayerKey.circleBlur,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `circleBlur`.
    public PropertyValue<StyleTransition> CircleBlurTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            CircleLayerKey.circleBlurTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            CircleLayerKey.circleBlurTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The fill color of the circle.
    public PropertyValue<Color> CircleColor
    {
        get => GetProperty<PropertyValue<Color>>(
            CircleLayerKey.circleColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            CircleLayerKey.circleColor,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `circleColor`.
    public PropertyValue<StyleTransition> CircleColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            CircleLayerKey.circleColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            CircleLayerKey.circleColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The opacity at which the circle will be drawn.
    public PropertyValue<double> CircleOpacity
    {
        get => GetProperty<PropertyValue<double>>(
            CircleLayerKey.circleOpacity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            CircleLayerKey.circleOpacity,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `circleOpacity`.
    public PropertyValue<StyleTransition> CircleOpacityTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            CircleLayerKey.circleOpacityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            CircleLayerKey.circleOpacityTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Orientation of circle when map is pitched.
    public PropertyValue<CirclePitchAlignment> CirclePitchAlignment
    {
        get => GetProperty<PropertyValue<CirclePitchAlignment>>(
            CircleLayerKey.circlePitchAlignment,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            CircleLayerKey.circlePitchAlignment,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Controls the scaling behavior of the circle when the map is pitched.
    public PropertyValue<CirclePitchScale> CirclePitchScale
    {
        get => GetProperty<PropertyValue<CirclePitchScale>>(
            CircleLayerKey.circlePitchScale,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            CircleLayerKey.circlePitchScale,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Circle radius.
    public PropertyValue<double> CircleRadius
    {
        get => GetProperty<PropertyValue<double>>(
            CircleLayerKey.circleRadius,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            CircleLayerKey.circleRadius,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `circleRadius`.
    public PropertyValue<StyleTransition> CircleRadiusTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            CircleLayerKey.circleRadiusTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            CircleLayerKey.circleRadiusTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The stroke color of the circle.
    public PropertyValue<Color> CircleStrokeColor
    {
        get => GetProperty<PropertyValue<Color>>(
            CircleLayerKey.circleStrokeColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            CircleLayerKey.circleStrokeColor,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `circleStrokeColor`.
    public PropertyValue<StyleTransition> CircleStrokeColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            CircleLayerKey.circleStrokeColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            CircleLayerKey.circleStrokeColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The opacity of the circle's stroke.
    public PropertyValue<double> CircleStrokeOpacity
    {
        get => GetProperty<PropertyValue<double>>(
            CircleLayerKey.circleStrokeOpacity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            CircleLayerKey.circleStrokeOpacity,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `circleStrokeOpacity`.
    public PropertyValue<StyleTransition> CircleStrokeOpacityTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            CircleLayerKey.circleStrokeOpacityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            CircleLayerKey.circleStrokeOpacityTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The width of the circle's stroke. Strokes are placed outside of the `circle-radius`.
    public PropertyValue<double> CircleStrokeWidth
    {
        get => GetProperty<PropertyValue<double>>(
            CircleLayerKey.circleStrokeWidth,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            CircleLayerKey.circleStrokeWidth,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `circleStrokeWidth`.
    public PropertyValue<StyleTransition> CircleStrokeWidthTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            CircleLayerKey.circleStrokeWidthTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            CircleLayerKey.circleStrokeWidthTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The geometry's offset. Values are [x, y] where negatives indicate left and up, respectively.
    public PropertyValue<double[]> CircleTranslate
    {
        get => GetProperty<PropertyValue<double[]>>(
            CircleLayerKey.circleTranslate,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            CircleLayerKey.circleTranslate,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `circleTranslate`.
    public PropertyValue<StyleTransition> CircleTranslateTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            CircleLayerKey.circleTranslateTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            CircleLayerKey.circleTranslateTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Controls the frame of reference for `circle-translate`.
    public PropertyValue<CircleTranslateAnchor> CircleTranslateAnchor
    {
        get => GetProperty<PropertyValue<CircleTranslateAnchor>>(
            CircleLayerKey.circleTranslateAnchor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            CircleLayerKey.circleTranslateAnchor,
            value,
            MapboxLayerKey.paint
        );
    }


    private static class CircleLayerLayoutKey
    {
        public const string circleSortKey = "circle-sort-key";
    }

    private static class CircleLayerKey
    {
        public const string circleBlur = "circle-blur";
        public const string circleBlurTransition = "circle-blur-transition";
        public const string circleColor = "circle-color";
        public const string circleColorTransition = "circle-color-transition";
        public const string circleOpacity = "circle-opacity";
        public const string circleOpacityTransition = "circle-opacity-transition";
        public const string circlePitchAlignment = "circle-pitch-alignment";
        public const string circlePitchScale = "circle-pitch-scale";
        public const string circleRadius = "circle-radius";
        public const string circleRadiusTransition = "circle-radius-transition";
        public const string circleStrokeColor = "circle-stroke-color";
        public const string circleStrokeColorTransition = "circle-stroke-color-transition";
        public const string circleStrokeOpacity = "circle-stroke-opacity";
        public const string circleStrokeOpacityTransition = "circle-stroke-opacity-transition";
        public const string circleStrokeWidth = "circle-stroke-width";
        public const string circleStrokeWidthTransition = "circle-stroke-width-transition";
        public const string circleTranslate = "circle-translate";
        public const string circleTranslateTransition = "circle-translate-transition";
        public const string circleTranslateAnchor = "circle-translate-anchor";
    }
}

