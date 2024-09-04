namespace MapboxMaui.Styles;

/// Client-side hillshading visualization based on DEM data. Currently, the implementation only supports Mapbox Terrain RGB and Mapzen Terrarium tiles.
///
/// - SeeAlso: [Mapbox Style Specification](https://www.mapbox.com/mapbox-gl-style-spec/#layers-hillshade)
public class HillshadeLayer : MapboxLayer
{
    public HillshadeLayer(string id, string source)
        : base(id)
    {
        Type = LayerType.Hillshade;
        Source = source;
        Visibility = new PropertyValue<Visibility>(MapboxMaui.Visibility.Visible);
    }
    /// The shading color used to accentuate rugged terrain like sharp cliffs and gorges.
    /// Default value: "#000000".
    public PropertyValue<Color> HillshadeAccentColor
    {
        get => GetProperty<PropertyValue<Color>>(
            PaintCodingKeys.HillshadeAccentColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.HillshadeAccentColor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `hillshadeAccentColor`.
    public PropertyValue<StyleTransition> HillshadeAccentColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.HillshadeAccentColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.HillshadeAccentColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Controls the intensity of light emitted on the source features.
    /// Default value: 0. Minimum value: 0.
    public PropertyValue<double> HillshadeEmissiveStrength
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.HillshadeEmissiveStrength,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.HillshadeEmissiveStrength,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `hillshadeEmissiveStrength`.
    public PropertyValue<StyleTransition> HillshadeEmissiveStrengthTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.HillshadeEmissiveStrengthTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.HillshadeEmissiveStrengthTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Intensity of the hillshade
    /// Default value: 0.5. Value range: [0, 1]
    public PropertyValue<double> HillshadeExaggeration
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.HillshadeExaggeration,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.HillshadeExaggeration,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `hillshadeExaggeration`.
    public PropertyValue<StyleTransition> HillshadeExaggerationTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.HillshadeExaggerationTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.HillshadeExaggerationTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The shading color of areas that faces towards the light source.
    /// Default value: "#FFFFFF".
    public PropertyValue<Color> HillshadeHighlightColor
    {
        get => GetProperty<PropertyValue<Color>>(
            PaintCodingKeys.HillshadeHighlightColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.HillshadeHighlightColor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `hillshadeHighlightColor`.
    public PropertyValue<StyleTransition> HillshadeHighlightColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.HillshadeHighlightColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.HillshadeHighlightColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Direction of light source when map is rotated.
    /// Default value: "viewport".
    public PropertyValue<HillshadeIlluminationAnchor> HillshadeIlluminationAnchor
    {
        get => GetProperty<PropertyValue<HillshadeIlluminationAnchor>>(
            PaintCodingKeys.HillshadeIlluminationAnchor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.HillshadeIlluminationAnchor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The direction of the light source used to generate the hillshading with 0 as the top of the viewport if `hillshade-illumination-anchor` is set to `viewport` and due north if `hillshade-illumination-anchor` is set to `map` and no 3d lights enabled. If `hillshade-illumination-anchor` is set to `map` and 3d lights enabled, the direction from 3d lights is used instead.
    /// Default value: 335. Value range: [0, 359]
    public PropertyValue<double> HillshadeIlluminationDirection
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.HillshadeIlluminationDirection,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.HillshadeIlluminationDirection,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The shading color of areas that face away from the light source.
    /// Default value: "#000000".
    public PropertyValue<Color> HillshadeShadowColor
    {
        get => GetProperty<PropertyValue<Color>>(
            PaintCodingKeys.HillshadeShadowColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.HillshadeShadowColor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `hillshadeShadowColor`.
    public PropertyValue<StyleTransition> HillshadeShadowColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.HillshadeShadowColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.HillshadeShadowColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    public static class PaintCodingKeys {
        public const string HillshadeAccentColor = "hillshade-accent-color";
        public const string HillshadeAccentColorTransition = "hillshade-accent-color-transition";
        public const string HillshadeEmissiveStrength = "hillshade-emissive-strength";
        public const string HillshadeEmissiveStrengthTransition = "hillshade-emissive-strength-transition";
        public const string HillshadeExaggeration = "hillshade-exaggeration";
        public const string HillshadeExaggerationTransition = "hillshade-exaggeration-transition";
        public const string HillshadeHighlightColor = "hillshade-highlight-color";
        public const string HillshadeHighlightColorTransition = "hillshade-highlight-color-transition";
        public const string HillshadeIlluminationAnchor = "hillshade-illumination-anchor";
        public const string HillshadeIlluminationDirection = "hillshade-illumination-direction";
        public const string HillshadeShadowColor = "hillshade-shadow-color";
        public const string HillshadeShadowColorTransition = "hillshade-shadow-color-transition";
    }

    public static class LayoutCodingKeys {

    }
}