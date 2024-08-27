namespace MapboxMaui.Styles;

/// A filled polygon with an optional stroked border.
///
/// - SeeAlso: [Mapbox Style Specification](https://www.mapbox.com/mapbox-gl-style-spec/#layers-fill)
public class FillLayer : MapboxLayer
{
    public FillLayer(string id, string source)
        : base(id)
    {
        Type = LayerType.Fill;
        Source = source;
        Visibility = new PropertyValue<Visibility>(MapboxMaui.Visibility.Visible);
    }
    /// Sorts features in ascending order based on this value. Features with a higher sort key will appear above features with a lower sort key.
    public PropertyValue<double> FillSortKey
    {
        get => GetProperty<PropertyValue<double>>(
            LayoutCodingKeys.FillSortKey,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.FillSortKey,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Whether or not the fill should be antialiased.
    /// Default value: true.
    public PropertyValue<bool> FillAntialias
    {
        get => GetProperty<PropertyValue<bool>>(
            PaintCodingKeys.FillAntialias,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillAntialias,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The color of the filled part of this layer. This color can be specified as `rgba` with an alpha component and the color's opacity will not affect the opacity of the 1px stroke, if it is used.
    /// Default value: "#000000".
    public PropertyValue<Color> FillColor
    {
        get => GetProperty<PropertyValue<Color>>(
            PaintCodingKeys.FillColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillColor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `fillColor`.
    public PropertyValue<StyleTransition> FillColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.FillColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Controls the intensity of light emitted on the source features.
    /// Default value: 0. Minimum value: 0.
    public PropertyValue<double> FillEmissiveStrength
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.FillEmissiveStrength,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillEmissiveStrength,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `fillEmissiveStrength`.
    public PropertyValue<StyleTransition> FillEmissiveStrengthTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.FillEmissiveStrengthTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillEmissiveStrengthTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The opacity of the entire fill layer. In contrast to the `fill-color`, this value will also affect the 1px stroke around the fill, if the stroke is used.
    /// Default value: 1. Value range: [0, 1]
    public PropertyValue<double> FillOpacity
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.FillOpacity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillOpacity,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `fillOpacity`.
    public PropertyValue<StyleTransition> FillOpacityTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.FillOpacityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillOpacityTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The outline color of the fill. Matches the value of `fill-color` if unspecified.
    public PropertyValue<Color> FillOutlineColor
    {
        get => GetProperty<PropertyValue<Color>>(
            PaintCodingKeys.FillOutlineColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillOutlineColor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `fillOutlineColor`.
    public PropertyValue<StyleTransition> FillOutlineColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.FillOutlineColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillOutlineColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Name of image in sprite to use for drawing image fills. For seamless patterns, image width and height must be a factor of two (2, 4, 8, ..., 512). Note that zoom-dependent expressions will be evaluated only at integer zoom levels.
    public PropertyValue<ResolvedImage> FillPattern
    {
        get => GetProperty<PropertyValue<ResolvedImage>>(
            PaintCodingKeys.FillPattern,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillPattern,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The geometry's offset. Values are [x, y] where negatives indicate left and up, respectively.
    /// Default value: [0,0].
    public PropertyValue<double[]> FillTranslate
    {
        get => GetProperty<PropertyValue<double[]>>(
            PaintCodingKeys.FillTranslate,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillTranslate,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `fillTranslate`.
    public PropertyValue<StyleTransition> FillTranslateTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.FillTranslateTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillTranslateTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Controls the frame of reference for `fill-translate`.
    /// Default value: "map".
    public PropertyValue<FillTranslateAnchor> FillTranslateAnchor
    {
        get => GetProperty<PropertyValue<FillTranslateAnchor>>(
            PaintCodingKeys.FillTranslateAnchor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillTranslateAnchor,
            value,
            MapboxLayerKey.paint
        );
    }

    public static class PaintCodingKeys {
        public const string FillAntialias = "fill-antialias";
        public const string FillColor = "fill-color";
        public const string FillColorTransition = "fill-color-transition";
        public const string FillEmissiveStrength = "fill-emissive-strength";
        public const string FillEmissiveStrengthTransition = "fill-emissive-strength-transition";
        public const string FillOpacity = "fill-opacity";
        public const string FillOpacityTransition = "fill-opacity-transition";
        public const string FillOutlineColor = "fill-outline-color";
        public const string FillOutlineColorTransition = "fill-outline-color-transition";
        public const string FillPattern = "fill-pattern";
        public const string FillTranslate = "fill-translate";
        public const string FillTranslateTransition = "fill-translate-transition";
        public const string FillTranslateAnchor = "fill-translate-anchor";
    }

    public static class LayoutCodingKeys {
        public const string FillSortKey = "fill-sort-key";
    }
}