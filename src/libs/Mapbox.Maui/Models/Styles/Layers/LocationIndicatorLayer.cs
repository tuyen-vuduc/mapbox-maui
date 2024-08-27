namespace MapboxMaui.Styles;

/// Location Indicator layer.
///
/// - SeeAlso: [Mapbox Style Specification](https://www.mapbox.com/mapbox-gl-style-spec/#layers-location-indicator)
public class LocationIndicatorLayer : MapboxLayer
{
    public LocationIndicatorLayer(string id)
        : base(id)
    {
        Type = LayerType.LocationIndicator;
        Visibility = new PropertyValue<Visibility>(MapboxMaui.Visibility.Visible);
    }
    /// Name of image in sprite to use as the middle of the location indicator.
    public PropertyValue<ResolvedImage> BearingImage
    {
        get => GetProperty<PropertyValue<ResolvedImage>>(
            LayoutCodingKeys.BearingImage,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.BearingImage,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Name of image in sprite to use as the background of the location indicator.
    public PropertyValue<ResolvedImage> ShadowImage
    {
        get => GetProperty<PropertyValue<ResolvedImage>>(
            LayoutCodingKeys.ShadowImage,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.ShadowImage,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Name of image in sprite to use as the top of the location indicator.
    public PropertyValue<ResolvedImage> TopImage
    {
        get => GetProperty<PropertyValue<ResolvedImage>>(
            LayoutCodingKeys.TopImage,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.TopImage,
            value,
            MapboxLayerKey.layout
        );
    }
    /// The accuracy, in meters, of the position source used to retrieve the position of the location indicator.
    /// Default value: 0.
    public PropertyValue<double> AccuracyRadius
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.AccuracyRadius,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.AccuracyRadius,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `accuracyRadius`.
    public PropertyValue<StyleTransition> AccuracyRadiusTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.AccuracyRadiusTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.AccuracyRadiusTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The color for drawing the accuracy radius border. To adjust transparency, set the alpha component of the color accordingly.
    /// Default value: "#ffffff".
    public PropertyValue<Color> AccuracyRadiusBorderColor
    {
        get => GetProperty<PropertyValue<Color>>(
            PaintCodingKeys.AccuracyRadiusBorderColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.AccuracyRadiusBorderColor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `accuracyRadiusBorderColor`.
    public PropertyValue<StyleTransition> AccuracyRadiusBorderColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.AccuracyRadiusBorderColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.AccuracyRadiusBorderColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The color for drawing the accuracy radius, as a circle. To adjust transparency, set the alpha component of the color accordingly.
    /// Default value: "#ffffff".
    public PropertyValue<Color> AccuracyRadiusColor
    {
        get => GetProperty<PropertyValue<Color>>(
            PaintCodingKeys.AccuracyRadiusColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.AccuracyRadiusColor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `accuracyRadiusColor`.
    public PropertyValue<StyleTransition> AccuracyRadiusColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.AccuracyRadiusColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.AccuracyRadiusColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The bearing of the location indicator.
    /// Default value: 0.
    public PropertyValue<double> Bearing
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.Bearing,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.Bearing,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `bearing`.
    public PropertyValue<StyleTransition> BearingTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.BearingTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.BearingTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The size of the bearing image, as a scale factor applied to the size of the specified image.
    /// Default value: 1.
    public PropertyValue<double> BearingImageSize
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.BearingImageSize,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.BearingImageSize,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `bearingImageSize`.
    public PropertyValue<StyleTransition> BearingImageSizeTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.BearingImageSizeTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.BearingImageSizeTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The color of the circle emphasizing the indicator. To adjust transparency, set the alpha component of the color accordingly.
    /// Default value: "#ffffff".
    public PropertyValue<Color> EmphasisCircleColor
    {
        get => GetProperty<PropertyValue<Color>>(
            PaintCodingKeys.EmphasisCircleColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.EmphasisCircleColor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `emphasisCircleColor`.
    public PropertyValue<StyleTransition> EmphasisCircleColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.EmphasisCircleColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.EmphasisCircleColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The radius, in pixel, of the circle emphasizing the indicator, drawn between the accuracy radius and the indicator shadow.
    /// Default value: 0.
    public PropertyValue<double> EmphasisCircleRadius
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.EmphasisCircleRadius,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.EmphasisCircleRadius,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `emphasisCircleRadius`.
    public PropertyValue<StyleTransition> EmphasisCircleRadiusTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.EmphasisCircleRadiusTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.EmphasisCircleRadiusTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The displacement off the center of the top image and the shadow image when the pitch of the map is greater than 0. This helps producing a three-dimensional appearence.
    /// Default value: "0".
    public PropertyValue<double> ImagePitchDisplacement
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.ImagePitchDisplacement,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.ImagePitchDisplacement,
            value,
            MapboxLayerKey.paint
        );
    }
    /// An array of [latitude, longitude, altitude] position of the location indicator.
    /// Default value: [0,0,0].
    public PropertyValue<double[]> Location
    {
        get => GetProperty<PropertyValue<double[]>>(
            PaintCodingKeys.Location,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.Location,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `location`.
    public PropertyValue<StyleTransition> LocationTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.LocationTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LocationTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The opacity of the entire location indicator layer.
    /// Default value: 1. Value range: [0, 1]
    public PropertyValue<double> LocationIndicatorOpacity
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.LocationIndicatorOpacity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LocationIndicatorOpacity,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `locationIndicatorOpacity`.
    public PropertyValue<StyleTransition> LocationIndicatorOpacityTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.LocationIndicatorOpacityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.LocationIndicatorOpacityTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The amount of the perspective compensation, between 0 and 1. A value of 1 produces a location indicator of constant width across the screen. A value of 0 makes it scale naturally according to the viewing projection.
    /// Default value: "0.85".
    public PropertyValue<double> PerspectiveCompensation
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.PerspectiveCompensation,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.PerspectiveCompensation,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The size of the shadow image, as a scale factor applied to the size of the specified image.
    /// Default value: 1.
    public PropertyValue<double> ShadowImageSize
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.ShadowImageSize,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.ShadowImageSize,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `shadowImageSize`.
    public PropertyValue<StyleTransition> ShadowImageSizeTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.ShadowImageSizeTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.ShadowImageSizeTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The size of the top image, as a scale factor applied to the size of the specified image.
    /// Default value: 1.
    public PropertyValue<double> TopImageSize
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.TopImageSize,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.TopImageSize,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `topImageSize`.
    public PropertyValue<StyleTransition> TopImageSizeTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.TopImageSizeTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.TopImageSizeTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    public static class PaintCodingKeys {
        public const string AccuracyRadius = "accuracy-radius";
        public const string AccuracyRadiusTransition = "accuracy-radius-transition";
        public const string AccuracyRadiusBorderColor = "accuracy-radius-border-color";
        public const string AccuracyRadiusBorderColorTransition = "accuracy-radius-border-color-transition";
        public const string AccuracyRadiusColor = "accuracy-radius-color";
        public const string AccuracyRadiusColorTransition = "accuracy-radius-color-transition";
        public const string Bearing = "bearing";
        public const string BearingTransition = "bearing-transition";
        public const string BearingImageSize = "bearing-image-size";
        public const string BearingImageSizeTransition = "bearing-image-size-transition";
        public const string EmphasisCircleColor = "emphasis-circle-color";
        public const string EmphasisCircleColorTransition = "emphasis-circle-color-transition";
        public const string EmphasisCircleRadius = "emphasis-circle-radius";
        public const string EmphasisCircleRadiusTransition = "emphasis-circle-radius-transition";
        public const string ImagePitchDisplacement = "image-pitch-displacement";
        public const string Location = "location";
        public const string LocationTransition = "location-transition";
        public const string LocationIndicatorOpacity = "location-indicator-opacity";
        public const string LocationIndicatorOpacityTransition = "location-indicator-opacity-transition";
        public const string PerspectiveCompensation = "perspective-compensation";
        public const string ShadowImageSize = "shadow-image-size";
        public const string ShadowImageSizeTransition = "shadow-image-size-transition";
        public const string TopImageSize = "top-image-size";
        public const string TopImageSizeTransition = "top-image-size-transition";
    }

    public static class LayoutCodingKeys {
        public const string BearingImage = "bearing-image";
        public const string ShadowImage = "shadow-image";
        public const string TopImage = "top-image";
    }
}