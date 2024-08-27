namespace MapboxMaui.Styles;

/// The background color or pattern of the map.
///
/// - SeeAlso: [Mapbox Style Specification](https://www.mapbox.com/mapbox-gl-style-spec/#layers-background)
public class BackgroundLayer : MapboxLayer
{
    public BackgroundLayer(string id)
        : base(id)
    {
        Type = LayerType.Background;
        Visibility = new PropertyValue<Visibility>(MapboxMaui.Visibility.Visible);
    }
    /// The color with which the background will be drawn.
    /// Default value: "#000000".
    public PropertyValue<Color> BackgroundColor
    {
        get => GetProperty<PropertyValue<Color>>(
            PaintCodingKeys.BackgroundColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.BackgroundColor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `backgroundColor`.
    public PropertyValue<StyleTransition> BackgroundColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.BackgroundColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.BackgroundColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Controls the intensity of light emitted on the source features.
    /// Default value: 0. Minimum value: 0.
    public PropertyValue<double> BackgroundEmissiveStrength
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.BackgroundEmissiveStrength,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.BackgroundEmissiveStrength,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `backgroundEmissiveStrength`.
    public PropertyValue<StyleTransition> BackgroundEmissiveStrengthTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.BackgroundEmissiveStrengthTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.BackgroundEmissiveStrengthTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The opacity at which the background will be drawn.
    /// Default value: 1. Value range: [0, 1]
    public PropertyValue<double> BackgroundOpacity
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.BackgroundOpacity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.BackgroundOpacity,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `backgroundOpacity`.
    public PropertyValue<StyleTransition> BackgroundOpacityTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.BackgroundOpacityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.BackgroundOpacityTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Name of image in sprite to use for drawing an image background. For seamless patterns, image width and height must be a factor of two (2, 4, 8, ..., 512). Note that zoom-dependent expressions will be evaluated only at integer zoom levels.
    public PropertyValue<ResolvedImage> BackgroundPattern
    {
        get => GetProperty<PropertyValue<ResolvedImage>>(
            PaintCodingKeys.BackgroundPattern,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.BackgroundPattern,
            value,
            MapboxLayerKey.paint
        );
    }

    public static class PaintCodingKeys {
        public const string BackgroundColor = "background-color";
        public const string BackgroundColorTransition = "background-color-transition";
        public const string BackgroundEmissiveStrength = "background-emissive-strength";
        public const string BackgroundEmissiveStrengthTransition = "background-emissive-strength-transition";
        public const string BackgroundOpacity = "background-opacity";
        public const string BackgroundOpacityTransition = "background-opacity-transition";
        public const string BackgroundPattern = "background-pattern";
    }

    public static class LayoutCodingKeys {

    }
}