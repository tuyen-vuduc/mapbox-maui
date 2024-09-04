namespace MapboxMaui.Styles;

/// An extruded (3D) polygon.
///
/// - SeeAlso: [Mapbox Style Specification](https://www.mapbox.com/mapbox-gl-style-spec/#layers-fill-extrusion)
public class FillExtrusionLayer : MapboxLayer
{
    public FillExtrusionLayer(string id, string source)
        : base(id)
    {
        Type = LayerType.FillExtrusion;
        Source = source;
        Visibility = new PropertyValue<Visibility>(MapboxMaui.Visibility.Visible);
    }
    /// Radius of a fill extrusion edge in meters. If not zero, rounds extrusion edges for a smoother appearance.
    /// Default value: 0. Value range: [0, 1]
    /// Provides a control to futher fine-tune the look of the ambient occlusion on the ground beneath the extruded buildings. Lower values give the effect a more solid look while higher values make it smoother.
    /// Default value: 0.69. Value range: [0, 1]
    /// Transition options for `fillExtrusionAmbientOcclusionGroundAttenuation`.
    /// The extent of the ambient occlusion effect on the ground beneath the extruded buildings in meters.
    /// Default value: 3. Minimum value: 0.
    /// Transition options for `fillExtrusionAmbientOcclusionGroundRadius`.
    /// Controls the intensity of shading near ground and concave angles between walls. Default value 0.0 disables ambient occlusion and values around 0.3 provide the most plausible results for buildings.
    /// Default value: 0. Value range: [0, 1]
    public PropertyValue<double> FillExtrusionAmbientOcclusionIntensity
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.FillExtrusionAmbientOcclusionIntensity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillExtrusionAmbientOcclusionIntensity,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `fillExtrusionAmbientOcclusionIntensity`.
    public PropertyValue<StyleTransition> FillExtrusionAmbientOcclusionIntensityTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.FillExtrusionAmbientOcclusionIntensityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillExtrusionAmbientOcclusionIntensityTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Shades area near ground and concave angles between walls where the radius defines only vertical impact. Default value 3.0 corresponds to height of one floor and brings the most plausible results for buildings. This property works only with legacy light. When 3D lights are enabled `fill-extrusion-ambient-occlusion-wall-radius` and `fill-extrusion-ambient-occlusion-ground-radius` are used instead.
    /// Default value: 3. Minimum value: 0.
    public PropertyValue<double> FillExtrusionAmbientOcclusionRadius
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.FillExtrusionAmbientOcclusionRadius,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillExtrusionAmbientOcclusionRadius,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `fillExtrusionAmbientOcclusionRadius`.
    public PropertyValue<StyleTransition> FillExtrusionAmbientOcclusionRadiusTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.FillExtrusionAmbientOcclusionRadiusTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillExtrusionAmbientOcclusionRadiusTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Shades area near ground and concave angles between walls where the radius defines only vertical impact. Default value 3.0 corresponds to height of one floor and brings the most plausible results for buildings.
    /// Default value: 3. Minimum value: 0.
    /// Transition options for `fillExtrusionAmbientOcclusionWallRadius`.
    /// The height with which to extrude the base of this layer. Must be less than or equal to `fill-extrusion-height`.
    /// Default value: 0. Minimum value: 0.
    public PropertyValue<double> FillExtrusionBase
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.FillExtrusionBase,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillExtrusionBase,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `fillExtrusionBase`.
    public PropertyValue<StyleTransition> FillExtrusionBaseTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.FillExtrusionBaseTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillExtrusionBaseTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The base color of the extruded fill. The extrusion's surfaces will be shaded differently based on this color in combination with the root `light` settings. If this color is specified as `rgba` with an alpha component, the alpha component will be ignored; use `fill-extrusion-opacity` to set layer opacity.
    /// Default value: "#000000".
    public PropertyValue<Color> FillExtrusionColor
    {
        get => GetProperty<PropertyValue<Color>>(
            PaintCodingKeys.FillExtrusionColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillExtrusionColor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `fillExtrusionColor`.
    public PropertyValue<StyleTransition> FillExtrusionColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.FillExtrusionColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillExtrusionColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// This parameter defines the range for the fade-out effect before an automatic content cutoff on pitched map views. Fade out is implemented by scaling down and removing buildings in the fade range in a staggered fashion. Opacity is not changed. The fade range is expressed in relation to the height of the map view. A value of 1.0 indicates that the content is faded to the same extent as the map's height in pixels, while a value close to zero represents a sharp cutoff. When the value is set to 0.0, the cutoff is completely disabled. Note: The property has no effect on the map if terrain is enabled.
    /// Default value: 0. Value range: [0, 1]
    public PropertyValue<double> FillExtrusionCutoffFadeRange
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.FillExtrusionCutoffFadeRange,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillExtrusionCutoffFadeRange,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Controls the intensity of light emitted on the source features.
    /// Default value: 0. Minimum value: 0.
    public PropertyValue<double> FillExtrusionEmissiveStrength
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.FillExtrusionEmissiveStrength,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillExtrusionEmissiveStrength,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `fillExtrusionEmissiveStrength`.
    public PropertyValue<StyleTransition> FillExtrusionEmissiveStrengthTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.FillExtrusionEmissiveStrengthTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillExtrusionEmissiveStrengthTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The color of the flood light effect on the walls of the extruded buildings.
    /// Default value: "#ffffff".
    /// Transition options for `fillExtrusionFloodLightColor`.
    /// Provides a control to futher fine-tune the look of the flood light on the ground beneath the extruded buildings. Lower values give the effect a more solid look while higher values make it smoother.
    /// Default value: 0.69. Value range: [0, 1]
    /// Transition options for `fillExtrusionFloodLightGroundAttenuation`.
    /// The extent of the flood light effect on the ground beneath the extruded buildings in meters.
    /// Default value: 0.
    /// Transition options for `fillExtrusionFloodLightGroundRadius`.
    /// The intensity of the flood light color.
    /// Default value: 0. Value range: [0, 1]
    /// Transition options for `fillExtrusionFloodLightIntensity`.
    /// The extent of the flood light effect on the walls of the extruded buildings in meters.
    /// Default value: 0. Minimum value: 0.
    /// Transition options for `fillExtrusionFloodLightWallRadius`.
    /// The height with which to extrude this layer.
    /// Default value: 0. Minimum value: 0.
    public PropertyValue<double> FillExtrusionHeight
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.FillExtrusionHeight,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillExtrusionHeight,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `fillExtrusionHeight`.
    public PropertyValue<StyleTransition> FillExtrusionHeightTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.FillExtrusionHeightTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillExtrusionHeightTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The opacity of the entire fill extrusion layer. This is rendered on a per-layer, not per-feature, basis, and data-driven styling is not available.
    /// Default value: 1. Value range: [0, 1]
    public PropertyValue<double> FillExtrusionOpacity
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.FillExtrusionOpacity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillExtrusionOpacity,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `fillExtrusionOpacity`.
    public PropertyValue<StyleTransition> FillExtrusionOpacityTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.FillExtrusionOpacityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillExtrusionOpacityTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Name of image in sprite to use for drawing images on extruded fills. For seamless patterns, image width and height must be a factor of two (2, 4, 8, ..., 512). Note that zoom-dependent expressions will be evaluated only at integer zoom levels.
    public PropertyValue<ResolvedImage> FillExtrusionPattern
    {
        get => GetProperty<PropertyValue<ResolvedImage>>(
            PaintCodingKeys.FillExtrusionPattern,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillExtrusionPattern,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Indicates whether top edges should be rounded when fill-extrusion-edge-radius has a value greater than 0. If false, rounded edges are only applied to the sides. Default is true.
    /// Default value: true.
    /// The geometry's offset. Values are [x, y] where negatives indicate left and up (on the flat plane), respectively.
    /// Default value: [0,0].
    public PropertyValue<double[]> FillExtrusionTranslate
    {
        get => GetProperty<PropertyValue<double[]>>(
            PaintCodingKeys.FillExtrusionTranslate,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillExtrusionTranslate,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `fillExtrusionTranslate`.
    public PropertyValue<StyleTransition> FillExtrusionTranslateTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.FillExtrusionTranslateTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillExtrusionTranslateTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Controls the frame of reference for `fill-extrusion-translate`.
    /// Default value: "map".
    public PropertyValue<FillExtrusionTranslateAnchor> FillExtrusionTranslateAnchor
    {
        get => GetProperty<PropertyValue<FillExtrusionTranslateAnchor>>(
            PaintCodingKeys.FillExtrusionTranslateAnchor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillExtrusionTranslateAnchor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Whether to apply a vertical gradient to the sides of a fill-extrusion layer. If true, sides will be shaded slightly darker farther down.
    /// Default value: true.
    public PropertyValue<bool> FillExtrusionVerticalGradient
    {
        get => GetProperty<PropertyValue<bool>>(
            PaintCodingKeys.FillExtrusionVerticalGradient,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.FillExtrusionVerticalGradient,
            value,
            MapboxLayerKey.paint
        );
    }
    /// A global multiplier that can be used to scale base, height, AO, and flood light of the fill extrusions.
    /// Default value: 1. Minimum value: 0.
    /// Transition options for `fillExtrusionVerticalScale`.

    public static class PaintCodingKeys {
        public const string FillExtrusionAmbientOcclusionGroundAttenuation = "fill-extrusion-ambient-occlusion-ground-attenuation";
        public const string FillExtrusionAmbientOcclusionGroundAttenuationTransition = "fill-extrusion-ambient-occlusion-ground-attenuation-transition";
        public const string FillExtrusionAmbientOcclusionGroundRadius = "fill-extrusion-ambient-occlusion-ground-radius";
        public const string FillExtrusionAmbientOcclusionGroundRadiusTransition = "fill-extrusion-ambient-occlusion-ground-radius-transition";
        public const string FillExtrusionAmbientOcclusionIntensity = "fill-extrusion-ambient-occlusion-intensity";
        public const string FillExtrusionAmbientOcclusionIntensityTransition = "fill-extrusion-ambient-occlusion-intensity-transition";
        public const string FillExtrusionAmbientOcclusionRadius = "fill-extrusion-ambient-occlusion-radius";
        public const string FillExtrusionAmbientOcclusionRadiusTransition = "fill-extrusion-ambient-occlusion-radius-transition";
        public const string FillExtrusionAmbientOcclusionWallRadius = "fill-extrusion-ambient-occlusion-wall-radius";
        public const string FillExtrusionAmbientOcclusionWallRadiusTransition = "fill-extrusion-ambient-occlusion-wall-radius-transition";
        public const string FillExtrusionBase = "fill-extrusion-base";
        public const string FillExtrusionBaseTransition = "fill-extrusion-base-transition";
        public const string FillExtrusionColor = "fill-extrusion-color";
        public const string FillExtrusionColorTransition = "fill-extrusion-color-transition";
        public const string FillExtrusionCutoffFadeRange = "fill-extrusion-cutoff-fade-range";
        public const string FillExtrusionEmissiveStrength = "fill-extrusion-emissive-strength";
        public const string FillExtrusionEmissiveStrengthTransition = "fill-extrusion-emissive-strength-transition";
        public const string FillExtrusionFloodLightColor = "fill-extrusion-flood-light-color";
        public const string FillExtrusionFloodLightColorTransition = "fill-extrusion-flood-light-color-transition";
        public const string FillExtrusionFloodLightGroundAttenuation = "fill-extrusion-flood-light-ground-attenuation";
        public const string FillExtrusionFloodLightGroundAttenuationTransition = "fill-extrusion-flood-light-ground-attenuation-transition";
        public const string FillExtrusionFloodLightGroundRadius = "fill-extrusion-flood-light-ground-radius";
        public const string FillExtrusionFloodLightGroundRadiusTransition = "fill-extrusion-flood-light-ground-radius-transition";
        public const string FillExtrusionFloodLightIntensity = "fill-extrusion-flood-light-intensity";
        public const string FillExtrusionFloodLightIntensityTransition = "fill-extrusion-flood-light-intensity-transition";
        public const string FillExtrusionFloodLightWallRadius = "fill-extrusion-flood-light-wall-radius";
        public const string FillExtrusionFloodLightWallRadiusTransition = "fill-extrusion-flood-light-wall-radius-transition";
        public const string FillExtrusionHeight = "fill-extrusion-height";
        public const string FillExtrusionHeightTransition = "fill-extrusion-height-transition";
        public const string FillExtrusionOpacity = "fill-extrusion-opacity";
        public const string FillExtrusionOpacityTransition = "fill-extrusion-opacity-transition";
        public const string FillExtrusionPattern = "fill-extrusion-pattern";
        public const string FillExtrusionRoundedRoof = "fill-extrusion-rounded-roof";
        public const string FillExtrusionTranslate = "fill-extrusion-translate";
        public const string FillExtrusionTranslateTransition = "fill-extrusion-translate-transition";
        public const string FillExtrusionTranslateAnchor = "fill-extrusion-translate-anchor";
        public const string FillExtrusionVerticalGradient = "fill-extrusion-vertical-gradient";
        public const string FillExtrusionVerticalScale = "fill-extrusion-vertical-scale";
        public const string FillExtrusionVerticalScaleTransition = "fill-extrusion-vertical-scale-transition";
    }

    public static class LayoutCodingKeys {
        public const string FillExtrusionEdgeRadius = "fill-extrusion-edge-radius";
    }
}