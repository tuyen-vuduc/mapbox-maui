namespace MapboxMaui.Styles;

public class FillExtrusionLayer : MapboxLayer
{
	public FillExtrusionLayer(string id) : base(id)
	{
		Type = LayerType.FillExtrusion;
        Visibility = new PropertyValue<Visibility>(MapboxMaui.Visibility.Visible);
	}

    public static class FillExtrusionLayerKey
    {
        public const string fillExtrusionAmbientOcclusionIntensity = "fill-extrusion-ambient-occlusion-intensity";
        public const string fillExtrusionAmbientOcclusionIntensityTransition = "fill-extrusion-ambient-occlusion-intensity-transition";
        public const string fillExtrusionAmbientOcclusionRadius = "fill-extrusion-ambient-occlusion-radius";
        public const string fillExtrusionAmbientOcclusionRadiusTransition = "fill-extrusion-ambient-occlusion-radius-transition";
        public const string fillExtrusionBase = "fill-extrusion-base";
        public const string fillExtrusionBaseTransition = "fill-extrusion-base-transition";
        public const string fillExtrusionColor = "fill-extrusion-color";
        public const string fillExtrusionColorTransition = "fill-extrusion-color-transition";
        public const string fillExtrusionHeight = "fill-extrusion-height";
        public const string fillExtrusionHeightTransition = "fill-extrusion-height-transition";
        public const string fillExtrusionOpacity = "fill-extrusion-opacity";
        public const string fillExtrusionOpacityTransition = "fill-extrusion-opacity-transition";
        public const string fillExtrusionPattern = "fill-extrusion-pattern";
        public const string fillExtrusionTranslate = "fill-extrusion-translate";
        public const string fillExtrusionTranslateTransition = "fill-extrusion-translate-transition";
        public const string fillExtrusionTranslateAnchor = "fill-extrusion-translate-anchor";
        public const string fillExtrusionVerticalGradient = "fill-extrusion-vertical-gradient";
    }

    /// Controls the intensity of shading near ground and concave angles between walls. Default value 0.0 disables ambient occlusion and values around 0.3 provide the most plausible results for buildings.
    public PropertyValue<double> FillExtrusionAmbientOcclusionIntensity
    {
        get => GetProperty<PropertyValue<double>>(
            FillExtrusionLayerKey.fillExtrusionAmbientOcclusionIntensity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillExtrusionLayerKey.fillExtrusionAmbientOcclusionIntensity,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `fillExtrusionAmbientOcclusionIntensity`.
    public PropertyValue<StyleTransition> FillExtrusionAmbientOcclusionIntensityTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            FillExtrusionLayerKey.fillExtrusionAmbientOcclusionIntensityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillExtrusionLayerKey.fillExtrusionAmbientOcclusionIntensityTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Shades area near ground and concave angles between walls where the radius defines only vertical impact. Default value 3.0 corresponds to height of one floor and brings the most plausible results for buildings.
    public PropertyValue<double> FillExtrusionAmbientOcclusionRadius
    {
        get => GetProperty<PropertyValue<double>>(
            FillExtrusionLayerKey.fillExtrusionAmbientOcclusionRadius,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillExtrusionLayerKey.fillExtrusionAmbientOcclusionRadius,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `fillExtrusionAmbientOcclusionRadius`.
    public PropertyValue<StyleTransition> FillExtrusionAmbientOcclusionRadiusTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            FillExtrusionLayerKey.fillExtrusionAmbientOcclusionRadiusTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillExtrusionLayerKey.fillExtrusionAmbientOcclusionRadiusTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The height with which to extrude the base of this layer. Must be less than or equal to `fill-extrusion-height`.
    public PropertyValue<double> FillExtrusionBase
    {
        get => GetProperty<PropertyValue<double>>(
            FillExtrusionLayerKey.fillExtrusionBase,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillExtrusionLayerKey.fillExtrusionBase,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `fillExtrusionBase`.
    public PropertyValue<StyleTransition> FillExtrusionBaseTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            FillExtrusionLayerKey.fillExtrusionBaseTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillExtrusionLayerKey.fillExtrusionBaseTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The base color of the extruded fill. The extrusion's surfaces will be shaded differently based on this color in combination with the root `light` settings. If this color is specified as `rgba` with an alpha component, the alpha component will be ignored; use `fill-extrusion-opacity` to set layer opacity.
    public PropertyValue<Color> FillExtrusionColor
    {
        get => GetProperty<PropertyValue<Color>>(
            FillExtrusionLayerKey.fillExtrusionColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillExtrusionLayerKey.fillExtrusionColor,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `fillExtrusionColor`.
    public PropertyValue<StyleTransition> FillExtrusionColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            FillExtrusionLayerKey.fillExtrusionColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillExtrusionLayerKey.fillExtrusionColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The height with which to extrude this layer.
    public PropertyValue<double> FillExtrusionHeight
    {
        get => GetProperty<PropertyValue<double>>(
            FillExtrusionLayerKey.fillExtrusionHeight,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillExtrusionLayerKey.fillExtrusionHeight,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `fillExtrusionHeight`.
    public PropertyValue<StyleTransition> FillExtrusionHeightTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            FillExtrusionLayerKey.fillExtrusionHeightTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillExtrusionLayerKey.fillExtrusionHeightTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The opacity of the entire fill extrusion layer. This is rendered on a per-layer, not per-feature, basis, and data-driven styling is not available.
    public PropertyValue<double> FillExtrusionOpacity
    {
        get => GetProperty<PropertyValue<double>>(
            FillExtrusionLayerKey.fillExtrusionOpacity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillExtrusionLayerKey.fillExtrusionOpacity,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `fillExtrusionOpacity`.
    public PropertyValue<StyleTransition> FillExtrusionOpacityTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            FillExtrusionLayerKey.fillExtrusionOpacityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillExtrusionLayerKey.fillExtrusionOpacityTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Name of image in sprite to use for drawing images on extruded fills. For seamless patterns, image width and height must be a factor of two (2, 4, 8, ..., 512). Note that zoom-dependent expressions will be evaluated only at integer zoom levels.
    public PropertyValue<string> FillExtrusionPattern
    {
        get => GetProperty<PropertyValue<string>>(
            FillExtrusionLayerKey.fillExtrusionPattern,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillExtrusionLayerKey.fillExtrusionPattern,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The geometry's offset. Values are [x, y] where negatives indicate left and up (on the flat plane), respectively.
    public PropertyValue<double[]> FillExtrusionTranslate
    {
        get => GetProperty<PropertyValue<double[]>>(
            FillExtrusionLayerKey.fillExtrusionTranslate,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillExtrusionLayerKey.fillExtrusionTranslate,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `fillExtrusionTranslate`.
    public PropertyValue<StyleTransition> FillExtrusionTranslateTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            FillExtrusionLayerKey.fillExtrusionTranslateTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillExtrusionLayerKey.fillExtrusionTranslateTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Controls the frame of reference for `fill-extrusion-translate`.
    public PropertyValue<FillExtrusionTranslateAnchor> FillExtrusionTranslateAnchor
    {
        get => GetProperty<PropertyValue<FillExtrusionTranslateAnchor>>(
            FillExtrusionLayerKey.fillExtrusionTranslateAnchor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillExtrusionLayerKey.fillExtrusionTranslateAnchor,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Whether to apply a vertical gradient to the sides of a fill-extrusion layer. If true, sides will be shaded slightly darker farther down.
    public PropertyValue<bool> FillExtrusionVerticalGradient
    {
        get => GetProperty<PropertyValue<bool>>(
            FillExtrusionLayerKey.fillExtrusionVerticalGradient,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillExtrusionLayerKey.fillExtrusionVerticalGradient,
            value,
            MapboxLayerKey.paint
        );
    }
}

