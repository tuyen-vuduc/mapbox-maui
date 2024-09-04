namespace MapboxMaui.Styles;

/// A spherical dome around the map that is always rendered behind all other layers.
/// Warning: As of v10.6.0, ``Atmosphere`` is the preferred method for atmospheric styling. Sky layer is not supported by the globe projection, and will be phased out in future major release.
///
/// - SeeAlso: [Mapbox Style Specification](https://www.mapbox.com/mapbox-gl-style-spec/#layers-sky)
public class SkyLayer : MapboxLayer
{
    public SkyLayer(string id)
        : base(id)
    {
        Type = LayerType.Sky;
        Visibility = new PropertyValue<Visibility>(MapboxMaui.Visibility.Visible);
    }
    /// A color used to tweak the main atmospheric scattering coefficients. Using white applies the default coefficients giving the natural blue color to the atmosphere. This color affects how heavily the corresponding wavelength is represented during scattering. The alpha channel describes the density of the atmosphere, with 1 maximum density and 0 no density.
    /// Default value: "white".
    public PropertyValue<Color> SkyAtmosphereColor
    {
        get => GetProperty<PropertyValue<Color>>(
            PaintCodingKeys.SkyAtmosphereColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.SkyAtmosphereColor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// A color applied to the atmosphere sun halo. The alpha channel describes how strongly the sun halo is represented in an atmosphere sky layer.
    /// Default value: "white".
    public PropertyValue<Color> SkyAtmosphereHaloColor
    {
        get => GetProperty<PropertyValue<Color>>(
            PaintCodingKeys.SkyAtmosphereHaloColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.SkyAtmosphereHaloColor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Position of the sun center [a azimuthal angle, p polar angle]. The azimuthal angle indicates the position of the sun relative to 0 degree north, where degrees proceed clockwise. The polar angle indicates the height of the sun, where 0 degree is directly above, at zenith, and 90 degree at the horizon. When this property is ommitted, the sun center is directly inherited from the light position.
    /// Minimum value: [0,0]. Maximum value: [360,180].
    public PropertyValue<double[]> SkyAtmosphereSun
    {
        get => GetProperty<PropertyValue<double[]>>(
            PaintCodingKeys.SkyAtmosphereSun,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.SkyAtmosphereSun,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Intensity of the sun as a light source in the atmosphere (on a scale from 0 to a 100). Setting higher values will brighten up the sky.
    /// Default value: 10. Value range: [0, 100]
    public PropertyValue<double> SkyAtmosphereSunIntensity
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.SkyAtmosphereSunIntensity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.SkyAtmosphereSunIntensity,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Defines a radial color gradient with which to color the sky. The color values can be interpolated with an expression using `sky-radial-progress`. The range [0, 1] for the interpolant covers a radial distance (in degrees) of [0, `sky-gradient-radius`] centered at the position specified by `sky-gradient-center`.
    /// Default value: ["interpolate",["linear"],["sky-radial-progress"],0.8,"#87ceeb",1,"white"].
    public PropertyValue<Color> SkyGradient
    {
        get => GetProperty<PropertyValue<Color>>(
            PaintCodingKeys.SkyGradient,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.SkyGradient,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Position of the gradient center [a azimuthal angle, p polar angle]. The azimuthal angle indicates the position of the gradient center relative to 0 degree north, where degrees proceed clockwise. The polar angle indicates the height of the gradient center, where 0 degree is directly above, at zenith, and 90 degree at the horizon.
    /// Default value: [0,0]. Minimum value: [0,0]. Maximum value: [360,180].
    public PropertyValue<double[]> SkyGradientCenter
    {
        get => GetProperty<PropertyValue<double[]>>(
            PaintCodingKeys.SkyGradientCenter,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.SkyGradientCenter,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The angular distance (measured in degrees) from `sky-gradient-center` up to which the gradient extends. A value of 180 causes the gradient to wrap around to the opposite direction from `sky-gradient-center`.
    /// Default value: 90. Value range: [0, 180]
    public PropertyValue<double> SkyGradientRadius
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.SkyGradientRadius,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.SkyGradientRadius,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The opacity of the entire sky layer.
    /// Default value: 1. Value range: [0, 1]
    public PropertyValue<double> SkyOpacity
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.SkyOpacity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.SkyOpacity,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `skyOpacity`.
    public PropertyValue<StyleTransition> SkyOpacityTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.SkyOpacityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.SkyOpacityTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The type of the sky
    /// Default value: "atmosphere".
    public PropertyValue<SkyType> SkyType
    {
        get => GetProperty<PropertyValue<SkyType>>(
            PaintCodingKeys.SkyType,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.SkyType,
            value,
            MapboxLayerKey.paint
        );
    }

    public static class PaintCodingKeys {
        public const string SkyAtmosphereColor = "sky-atmosphere-color";
        public const string SkyAtmosphereHaloColor = "sky-atmosphere-halo-color";
        public const string SkyAtmosphereSun = "sky-atmosphere-sun";
        public const string SkyAtmosphereSunIntensity = "sky-atmosphere-sun-intensity";
        public const string SkyGradient = "sky-gradient";
        public const string SkyGradientCenter = "sky-gradient-center";
        public const string SkyGradientRadius = "sky-gradient-radius";
        public const string SkyOpacity = "sky-opacity";
        public const string SkyOpacityTransition = "sky-opacity-transition";
        public const string SkyType = "sky-type";
    }

    public static class LayoutCodingKeys {

    }
}