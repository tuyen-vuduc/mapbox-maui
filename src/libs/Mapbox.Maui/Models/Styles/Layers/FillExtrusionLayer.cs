namespace Mapbox.Maui.Styles;

public class FillExtrusionLayer : MapboxLayer
{
	public FillExtrusionLayer(string id) : base(id)
	{
		Type = LayerType.fillExtrusion;
        Visibility = new PropertyValue(Mapbox.Maui.Visibility.visible);
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
    public PropertyValue FillExtrusionAmbientOcclusionIntensity
    {
        get => GetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionAmbientOcclusionIntensity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionAmbientOcclusionIntensity,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `fillExtrusionAmbientOcclusionIntensity`.
    public PropertyValue FillExtrusionAmbientOcclusionIntensityTransition
    {
        get => GetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionAmbientOcclusionIntensityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionAmbientOcclusionIntensityTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Shades area near ground and concave angles between walls where the radius defines only vertical impact. Default value 3.0 corresponds to height of one floor and brings the most plausible results for buildings.
    public PropertyValue FillExtrusionAmbientOcclusionRadius
    {
        get => GetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionAmbientOcclusionRadius,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionAmbientOcclusionRadius,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `fillExtrusionAmbientOcclusionRadius`.
    public PropertyValue FillExtrusionAmbientOcclusionRadiusTransition
    {
        get => GetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionAmbientOcclusionRadiusTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionAmbientOcclusionRadiusTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The height with which to extrude the base of this layer. Must be less than or equal to `fill-extrusion-height`.
    public PropertyValue FillExtrusionBase
    {
        get => GetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionBase,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionBase,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `fillExtrusionBase`.
    public PropertyValue FillExtrusionBaseTransition
    {
        get => GetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionBaseTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionBaseTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The base color of the extruded fill. The extrusion's surfaces will be shaded differently based on this color in combination with the root `light` settings. If this color is specified as `rgba` with an alpha component, the alpha component will be ignored; use `fill-extrusion-opacity` to set layer opacity.
    public PropertyValue FillExtrusionColor
    {
        get => GetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionColor,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `fillExtrusionColor`.
    public PropertyValue FillExtrusionColorTransition
    {
        get => GetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The height with which to extrude this layer.
    public PropertyValue FillExtrusionHeight
    {
        get => GetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionHeight,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionHeight,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `fillExtrusionHeight`.
    public PropertyValue FillExtrusionHeightTransition
    {
        get => GetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionHeightTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionHeightTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The opacity of the entire fill extrusion layer. This is rendered on a per-layer, not per-feature, basis, and data-driven styling is not available.
    public PropertyValue FillExtrusionOpacity
    {
        get => GetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionOpacity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionOpacity,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `fillExtrusionOpacity`.
    public PropertyValue FillExtrusionOpacityTransition
    {
        get => GetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionOpacityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionOpacityTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Name of image in sprite to use for drawing images on extruded fills. For seamless patterns, image width and height must be a factor of two (2, 4, 8, ..., 512). Note that zoom-dependent expressions will be evaluated only at integer zoom levels.
    public PropertyValue FillExtrusionPattern
    {
        get => GetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionPattern,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionPattern,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The geometry's offset. Values are [x, y] where negatives indicate left and up (on the flat plane), respectively.
    public PropertyValue FillExtrusionTranslate
    {
        get => GetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionTranslate,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionTranslate,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `fillExtrusionTranslate`.
    public PropertyValue FillExtrusionTranslateTransition
    {
        get => GetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionTranslateTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionTranslateTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Controls the frame of reference for `fill-extrusion-translate`.
    public PropertyValue FillExtrusionTranslateAnchor
    {
        get => GetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionTranslateAnchor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionTranslateAnchor,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Whether to apply a vertical gradient to the sides of a fill-extrusion layer. If true, sides will be shaded slightly darker farther down.
    public PropertyValue FillExtrusionVerticalGradient
    {
        get => GetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionVerticalGradient,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty<PropertyValue>(
            FillExtrusionLayerKey.fillExtrusionVerticalGradient,
            value,
            MapboxLayerKey.paint
        );
    }
}

