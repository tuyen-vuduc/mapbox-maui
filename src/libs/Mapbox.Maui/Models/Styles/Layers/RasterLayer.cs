namespace MapboxMaui.Styles;

/// Raster map textures such as satellite imagery.
///
/// - SeeAlso: [Mapbox Style Specification](https://www.mapbox.com/mapbox-gl-style-spec/#layers-raster)
public class RasterLayer : MapboxLayer
{
    public RasterLayer(string id, string source)
        : base(id)
    {
        Type = LayerType.Raster;
        Source = source;
        Visibility = new PropertyValue<Visibility>(MapboxMaui.Visibility.Visible);
    }
    /// Displayed band of raster array source layer. Defaults to the first band if not set.
    /// Increase or reduce the brightness of the image. The value is the maximum brightness.
    /// Default value: 1. Value range: [0, 1]
    public PropertyValue<double> RasterBrightnessMax
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.RasterBrightnessMax,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.RasterBrightnessMax,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `rasterBrightnessMax`.
    public PropertyValue<StyleTransition> RasterBrightnessMaxTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.RasterBrightnessMaxTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.RasterBrightnessMaxTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Increase or reduce the brightness of the image. The value is the minimum brightness.
    /// Default value: 0. Value range: [0, 1]
    public PropertyValue<double> RasterBrightnessMin
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.RasterBrightnessMin,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.RasterBrightnessMin,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `rasterBrightnessMin`.
    public PropertyValue<StyleTransition> RasterBrightnessMinTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.RasterBrightnessMinTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.RasterBrightnessMinTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Defines a color map by which to colorize a raster layer, parameterized by the `["raster-value"]` expression and evaluated at 256 uniformly spaced steps over the range specified by `raster-color-range`.
    public PropertyValue<Color> RasterColor
    {
        get => GetProperty<PropertyValue<Color>>(
            PaintCodingKeys.RasterColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.RasterColor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// When `raster-color` is active, specifies the combination of source RGB channels used to compute the raster value. Computed using the equation `mix.r - src.r + mix.g - src.g + mix.b - src.b + mix.a`. The first three components specify the mix of source red, green, and blue channels, respectively. The fourth component serves as a constant offset and is -not- multipled by source alpha. Source alpha is instead carried through and applied as opacity to the colorized result. Default value corresponds to RGB luminosity.
    /// Default value: [0.2126,0.7152,0.0722,0].
    public PropertyValue<double[]> RasterColorMix
    {
        get => GetProperty<PropertyValue<double[]>>(
            PaintCodingKeys.RasterColorMix,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.RasterColorMix,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `rasterColorMix`.
    public PropertyValue<StyleTransition> RasterColorMixTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.RasterColorMixTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.RasterColorMixTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// When `raster-color` is active, specifies the range over which `raster-color` is tabulated. Units correspond to the computed raster value via `raster-color-mix`. For `rasterarray` sources, if `raster-color-range` is unspecified, the source's stated data range is used.
    public PropertyValue<double[]> RasterColorRange
    {
        get => GetProperty<PropertyValue<double[]>>(
            PaintCodingKeys.RasterColorRange,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.RasterColorRange,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `rasterColorRange`.
    public PropertyValue<StyleTransition> RasterColorRangeTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.RasterColorRangeTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.RasterColorRangeTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Increase or reduce the contrast of the image.
    /// Default value: 0. Value range: [-1, 1]
    public PropertyValue<double> RasterContrast
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.RasterContrast,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.RasterContrast,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `rasterContrast`.
    public PropertyValue<StyleTransition> RasterContrastTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.RasterContrastTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.RasterContrastTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Specifies an uniform elevation from the ground, in meters.
    /// Default value: 0. Minimum value: 0.
    /// Transition options for `rasterElevation`.
    /// Controls the intensity of light emitted on the source features.
    /// Default value: 0. Minimum value: 0.
    public PropertyValue<double> RasterEmissiveStrength
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.RasterEmissiveStrength,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.RasterEmissiveStrength,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `rasterEmissiveStrength`.
    public PropertyValue<StyleTransition> RasterEmissiveStrengthTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.RasterEmissiveStrengthTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.RasterEmissiveStrengthTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Fade duration when a new tile is added.
    /// Default value: 300. Minimum value: 0.
    public PropertyValue<double> RasterFadeDuration
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.RasterFadeDuration,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.RasterFadeDuration,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Rotates hues around the color wheel.
    /// Default value: 0.
    public PropertyValue<double> RasterHueRotate
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.RasterHueRotate,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.RasterHueRotate,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `rasterHueRotate`.
    public PropertyValue<StyleTransition> RasterHueRotateTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.RasterHueRotateTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.RasterHueRotateTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The opacity at which the image will be drawn.
    /// Default value: 1. Value range: [0, 1]
    public PropertyValue<double> RasterOpacity
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.RasterOpacity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.RasterOpacity,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `rasterOpacity`.
    public PropertyValue<StyleTransition> RasterOpacityTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.RasterOpacityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.RasterOpacityTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The resampling/interpolation method to use for overscaling, also known as texture magnification filter
    /// Default value: "linear".
    public PropertyValue<RasterResampling> RasterResampling
    {
        get => GetProperty<PropertyValue<RasterResampling>>(
            PaintCodingKeys.RasterResampling,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.RasterResampling,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Increase or reduce the saturation of the image.
    /// Default value: 0. Value range: [-1, 1]
    public PropertyValue<double> RasterSaturation
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.RasterSaturation,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.RasterSaturation,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `rasterSaturation`.
    public PropertyValue<StyleTransition> RasterSaturationTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.RasterSaturationTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.RasterSaturationTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    public static class PaintCodingKeys {
        public const string RasterArrayBand = "raster-array-band";
        public const string RasterBrightnessMax = "raster-brightness-max";
        public const string RasterBrightnessMaxTransition = "raster-brightness-max-transition";
        public const string RasterBrightnessMin = "raster-brightness-min";
        public const string RasterBrightnessMinTransition = "raster-brightness-min-transition";
        public const string RasterColor = "raster-color";
        public const string RasterColorMix = "raster-color-mix";
        public const string RasterColorMixTransition = "raster-color-mix-transition";
        public const string RasterColorRange = "raster-color-range";
        public const string RasterColorRangeTransition = "raster-color-range-transition";
        public const string RasterContrast = "raster-contrast";
        public const string RasterContrastTransition = "raster-contrast-transition";
        public const string RasterElevation = "raster-elevation";
        public const string RasterElevationTransition = "raster-elevation-transition";
        public const string RasterEmissiveStrength = "raster-emissive-strength";
        public const string RasterEmissiveStrengthTransition = "raster-emissive-strength-transition";
        public const string RasterFadeDuration = "raster-fade-duration";
        public const string RasterHueRotate = "raster-hue-rotate";
        public const string RasterHueRotateTransition = "raster-hue-rotate-transition";
        public const string RasterOpacity = "raster-opacity";
        public const string RasterOpacityTransition = "raster-opacity-transition";
        public const string RasterResampling = "raster-resampling";
        public const string RasterSaturation = "raster-saturation";
        public const string RasterSaturationTransition = "raster-saturation-transition";
    }

    public static class LayoutCodingKeys {

    }
}