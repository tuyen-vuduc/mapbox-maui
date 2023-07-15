namespace MapboxMaui.Styles;

public class SkyLayer : MapboxLayer
{
    public SkyLayer(string id)
        : base(id)
    {
        Type = LayerType.Sky;
        Visibility = new PropertyValue<Visibility>(MapboxMaui.Visibility.Visible);
    }

    public static class SkyLayerKey
    {
        public const string skyAtmosphereColor = "sky-atmosphere-color";
        public const string skyAtmosphereHaloColor = "sky-atmosphere-halo-color";
        public const string skyAtmosphereSun = "sky-atmosphere-sun";
        public const string skyAtmosphereSunIntensity = "sky-atmosphere-sun-intensity";
        public const string skyGradient = "sky-gradient";
        public const string skyGradientCenter = "sky-gradient-center";
        public const string skyGradientRadius = "sky-gradient-radius";
        public const string skyOpacity = "sky-opacity";
        public const string skyOpacityTransition = "sky-opacity-transition";
        public const string skyType = "sky-type";
    }

    /// A color used to tweak the main atmospheric scattering coefficients. Using white applies the default coefficients giving the natural blue color to the atmosphere. This color affects how heavily the corresponding wavelength is represented during scattering. The alpha channel describes the density of the atmosphere, with 1 maximum density and 0 no density.
    public PropertyValue<Color> SkyAtmosphereColor
    {
        get => GetProperty<PropertyValue<Color>>(
            SkyLayerKey.skyAtmosphereColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SkyLayerKey.skyAtmosphereColor,
            value,
            MapboxLayerKey.paint
        );
    }

    /// A color applied to the atmosphere sun halo. The alpha channel describes how strongly the sun halo is represented in an atmosphere sky layer.
    public PropertyValue<Color> SkyAtmosphereHaloColor
    {
        get => GetProperty<PropertyValue<Color>>(
            SkyLayerKey.skyAtmosphereHaloColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SkyLayerKey.skyAtmosphereHaloColor,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Position of the sun center [a azimuthal angle, p polar angle]. The azimuthal angle indicates the position of the sun relative to 0 degree north, where degrees proceed clockwise. The polar angle indicates the height of the sun, where 0 degree is directly above, at zenith, and 90 degree at the horizon. When this property is ommitted, the sun center is directly inherited from the light position.
    public PropertyValue<double[]> SkyAtmosphereSun
    {
        get => GetProperty<PropertyValue<double[]>>(
            SkyLayerKey.skyAtmosphereSun,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SkyLayerKey.skyAtmosphereSun,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Intensity of the sun as a light source in the atmosphere (on a scale from 0 to a 100). Setting higher values will brighten up the sky.
    public PropertyValue<double> SkyAtmosphereSunIntensity
    {
        get => GetProperty<PropertyValue<double>>(
            SkyLayerKey.skyAtmosphereSunIntensity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SkyLayerKey.skyAtmosphereSunIntensity,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Defines a radial color gradient with which to color the sky. The color values can be interpolated with an expression using `sky-radial-progress`. The range [0, 1] for the interpolant covers a radial distance (in degrees) of [0, `sky-gradient-radius`] centered at the position specified by `sky-gradient-center`.
    public PropertyValue<Color> SkyGradient
    {
        get => GetProperty<PropertyValue<Color>>(
            SkyLayerKey.skyGradient,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SkyLayerKey.skyGradient,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Position of the gradient center [a azimuthal angle, p polar angle]. The azimuthal angle indicates the position of the gradient center relative to 0 degree north, where degrees proceed clockwise. The polar angle indicates the height of the gradient center, where 0 degree is directly above, at zenith, and 90 degree at the horizon.
    public PropertyValue<double[]> SkyGradientCenter
    {
        get => GetProperty<PropertyValue<double[]>>(
            SkyLayerKey.skyGradientCenter,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SkyLayerKey.skyGradientCenter,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The angular distance (measured in degrees) from `sky-gradient-center` up to which the gradient extends. A value of 180 causes the gradient to wrap around to the opposite direction from `sky-gradient-center`.
    public PropertyValue<double> SkyGradientRadius
    {
        get => GetProperty<PropertyValue<double>>(
            SkyLayerKey.skyGradientRadius,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SkyLayerKey.skyGradientRadius,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The opacity of the entire sky layer.
    public PropertyValue<double> SkyOpacity
    {
        get => GetProperty<PropertyValue<double>>(
            SkyLayerKey.skyOpacity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SkyLayerKey.skyOpacity,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `skyOpacity`.
    public StyleTransition SkyOpacityTransition
    {
        get => GetProperty<StyleTransition>(
            SkyLayerKey.skyOpacityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SkyLayerKey.skyOpacityTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The type of the sky
    public PropertyValue<SkyType> SkyType
    {
        get => GetProperty<PropertyValue<SkyType>>(
            SkyLayerKey.skyType,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SkyLayerKey.skyType,
            value,
            MapboxLayerKey.paint
        );
    }
}

