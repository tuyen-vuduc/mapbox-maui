namespace MapboxMaui.Styles;

public partial class RasterLayer : MapboxLayer
{
    public RasterLayer(string id, string source)
        : base(id)
    {
        Type = LayerType.Raster;
        Visibility = new PropertyValue<Visibility>(MapboxMaui.Visibility.Visible);
        Source = source;
    }

    // /// Displayed band of raster array source layer. Defaults to the first band if not set.
    // @_documentation(visibility: public)
    // @_spi(Experimental) public var rasterArrayBand: Value<String>?

    /// Increase or reduce the brightness of the image. The value is the maximum brightness.
    /// Default value: 1. Value range: [0, 1]
    public PropertyValue<double> RasterBrightnessMax
    {
        get => GetProperty<PropertyValue<double>>(
            RasterLayerKey.rasterBrightnessMax,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            RasterLayerKey.rasterBrightnessMax,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `rasterBrightnessMax`.
    public PropertyValue<StyleTransition> RasterBrightnessMaxTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            RasterLayerKey.rasterBrightnessMaxTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            RasterLayerKey.rasterBrightnessMaxTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Increase or reduce the brightness of the image. The value is the minimum brightness.
    /// Default value: 0. Value range: [0, 1]
    public PropertyValue<double> RasterBrightnessMin
    {
        get => GetProperty<PropertyValue<double>>(
            RasterLayerKey.rasterBrightnessMin,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            RasterLayerKey.rasterBrightnessMin,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `rasterBrightnessMin`.
    public PropertyValue<StyleTransition> RasterBrightnessMinTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            RasterLayerKey.rasterBrightnessMinTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            RasterLayerKey.rasterBrightnessMinTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Defines a color map by which to colorize a raster layer, parameterized by the `["raster-value"]` expression and evaluated at 256 uniformly spaced steps over the range specified by `raster-color-range`.
    public PropertyValue<Color> RasterColor
    {
        get => GetProperty<PropertyValue<Color>>(
            RasterLayerKey.rasterColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            RasterLayerKey.rasterColor,
            value,
            MapboxLayerKey.paint
        );
    }

    /// When `raster-color` is active, specifies the combination of source RGB channels used to compute the raster value. Computed using the equation `mix.r - src.r + mix.g - src.g + mix.b - src.b + mix.a`. The first three components specify the mix of source red, green, and blue channels, respectively. The fourth component serves as a constant offset and is -not- multipled by source alpha. Source alpha is instead carried through and applied as opacity to the colorized result. Default value corresponds to RGB luminosity.
    /// Default value: [0.2126,0.7152,0.0722,0].
    public PropertyValue<double[]> RasterColorMix
    {
        get => GetProperty<PropertyValue<double[]>>(
            RasterLayerKey.rasterColorMix,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            RasterLayerKey.rasterColorMix,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `rasterColorMix`.
    public PropertyValue<StyleTransition> RasterColorMixTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            RasterLayerKey.rasterColorMixTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            RasterLayerKey.rasterColorMixTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// When `raster-color` is active, specifies the range over which `raster-color` is tabulated. Units correspond to the computed raster value via `raster-color-mix`. For `rasterarray` sources, if `raster-color-range` is unspecified, the source's stated data range is used.
    public PropertyValue<double[]> RasterColorRange
    {
        get => GetProperty<PropertyValue<double[]>>(
            RasterLayerKey.rasterColorRange,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            RasterLayerKey.rasterColorRange,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `rasterColorRange`.
    public PropertyValue<StyleTransition> RasterColorRangeTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            RasterLayerKey.rasterColorRangeTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            RasterLayerKey.rasterColorRangeTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Increase or reduce the contrast of the image.
    /// Default value: 0. Value range: [-1, 1]
    public PropertyValue<double> RasterContrast
    {
        get => GetProperty<PropertyValue<double>>(
            RasterLayerKey.rasterContrast,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            RasterLayerKey.rasterContrast,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `rasterContrast`.
    public PropertyValue<StyleTransition> RasterContrastTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            RasterLayerKey.rasterContrastTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            RasterLayerKey.rasterContrastTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    // /// Specifies an uniform elevation from the ground, in meters.
    // /// Default value: 0. Minimum value: 0.
    // @_documentation(visibility: public)
    // @_spi(Experimental) public var rasterElevation: Value<Double>?

    // /// Transition options for `rasterElevation`.
    // @_documentation(visibility: public)
    // @_spi(Experimental) public var rasterElevationTransition: StyleTransition?

    /// Controls the intensity of light emitted on the source features.
    /// Default value: 0. Minimum value: 0.
    public PropertyValue<double> RasterEmissiveStrength
    {
        get => GetProperty<PropertyValue<double>>(
            RasterLayerKey.rasterEmissiveStrength,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            RasterLayerKey.rasterEmissiveStrength,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `rasterEmissiveStrength`.
    public PropertyValue<StyleTransition> RasterEmissiveStrengthTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            RasterLayerKey.rasterEmissiveStrengthTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            RasterLayerKey.rasterEmissiveStrengthTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Fade duration when a new tile is added.
    /// Default value: 300. Minimum value: 0.
    public PropertyValue<double> RasterFadeDuration
    {
        get => GetProperty<PropertyValue<double>>(
            RasterLayerKey.rasterFadeDuration,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            RasterLayerKey.rasterFadeDuration,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Rotates hues around the color wheel.
    /// Default value: 0.
    public PropertyValue<double> RasterHueRotate
    {
        get => GetProperty<PropertyValue<double>>(
            RasterLayerKey.rasterHueRotate,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            RasterLayerKey.rasterHueRotate,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `rasterHueRotate`.
    public PropertyValue<StyleTransition> RasterHueRotateTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            RasterLayerKey.rasterHueRotateTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            RasterLayerKey.rasterHueRotateTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The opacity at which the image will be drawn.
    /// Default value: 1. Value range: [0, 1]
    public PropertyValue<double> RasterOpacity
    {
        get => GetProperty<PropertyValue<double>>(
            RasterLayerKey.rasterOpacity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            RasterLayerKey.rasterOpacity,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `rasterOpacity`.
    public PropertyValue<StyleTransition> RasterOpacityTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            RasterLayerKey.rasterOpacityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            RasterLayerKey.rasterOpacityTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The resampling/interpolation method to use for overscaling, also known as texture magnification filter
    /// Default value: "linear".
    public PropertyValue<RasterResampling> RasterResampling
    {
        get => GetProperty<PropertyValue<RasterResampling>>(
            RasterLayerKey.rasterResampling,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            RasterLayerKey.rasterResampling,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Increase or reduce the saturation of the image.
    /// Default value: 0. Value range: [-1, 1]
    public PropertyValue<double> RasterSaturation
    {
        get => GetProperty<PropertyValue<double>>(
            RasterLayerKey.rasterSaturation,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            RasterLayerKey.rasterSaturation,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `rasterSaturation`.
    public PropertyValue<StyleTransition> RasterSaturationTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            RasterLayerKey.rasterSaturationTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            RasterLayerKey.rasterSaturationTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    public static class RasterLayerKey
    {
        public const string rasterArrayBand = "raster-array-band";
        public const string rasterBrightnessMax = "raster-brightness-max";
        public const string rasterBrightnessMaxTransition = "raster-brightness-max-transition";
        public const string rasterBrightnessMin = "raster-brightness-min";
        public const string rasterBrightnessMinTransition = "raster-brightness-min-transition";
        public const string rasterColor = "raster-color";
        public const string rasterColorMix = "raster-color-mix";
        public const string rasterColorMixTransition = "raster-color-mix-transition";
        public const string rasterColorRange = "raster-color-range";
        public const string rasterColorRangeTransition = "raster-color-range-transition";
        public const string rasterContrast = "raster-contrast";
        public const string rasterContrastTransition = "raster-contrast-transition";
        public const string rasterElevation = "raster-elevation";
        public const string rasterElevationTransition = "raster-elevation-transition";
        public const string rasterEmissiveStrength = "raster-emissive-strength";
        public const string rasterEmissiveStrengthTransition = "raster-emissive-strength-transition";
        public const string rasterFadeDuration = "raster-fade-duration";
        public const string rasterHueRotate = "raster-hue-rotate";
        public const string rasterHueRotateTransition = "raster-hue-rotate-transition";
        public const string rasterOpacity = "raster-opacity";
        public const string rasterOpacityTransition = "raster-opacity-transition";
        public const string rasterResampling = "raster-resampling";
        public const string rasterSaturation = "raster-saturation";
        public const string rasterSaturationTransition = "raster-saturation-transition";
    }
}