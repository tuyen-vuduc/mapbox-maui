namespace MapboxMaui.Styles;

/// A heatmap.
///
/// - SeeAlso: [Mapbox Style Specification](https://www.mapbox.com/mapbox-gl-style-spec/#layers-heatmap)
public class HeatmapLayer : MapboxLayer
{
    public HeatmapLayer(string id, string source)
        : base(id)
    {
        Type = LayerType.Heatmap;
        Source = source;
        Visibility = new PropertyValue<Visibility>(MapboxMaui.Visibility.Visible);
    }
    /// Defines the color of each pixel based on its density value in a heatmap. Should be an expression that uses `["heatmap-density"]` as input.
    /// Default value: ["interpolate",["linear"],["heatmap-density"],0,"rgba(0, 0, 255, 0)",0.1,"royalblue",0.3,"cyan",0.5,"lime",0.7,"yellow",1,"red"].
    public PropertyValue<Color> HeatmapColor
    {
        get => GetProperty<PropertyValue<Color>>(
            PaintCodingKeys.HeatmapColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.HeatmapColor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Similar to `heatmap-weight` but controls the intensity of the heatmap globally. Primarily used for adjusting the heatmap based on zoom level.
    /// Default value: 1. Minimum value: 0.
    public PropertyValue<double> HeatmapIntensity
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.HeatmapIntensity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.HeatmapIntensity,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `heatmapIntensity`.
    public PropertyValue<StyleTransition> HeatmapIntensityTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.HeatmapIntensityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.HeatmapIntensityTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The global opacity at which the heatmap layer will be drawn.
    /// Default value: 1. Value range: [0, 1]
    public PropertyValue<double> HeatmapOpacity
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.HeatmapOpacity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.HeatmapOpacity,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `heatmapOpacity`.
    public PropertyValue<StyleTransition> HeatmapOpacityTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.HeatmapOpacityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.HeatmapOpacityTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Radius of influence of one heatmap point in pixels. Increasing the value makes the heatmap smoother, but less detailed. `queryRenderedFeatures` on heatmap layers will return points within this radius.
    /// Default value: 30. Minimum value: 1.
    public PropertyValue<double> HeatmapRadius
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.HeatmapRadius,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.HeatmapRadius,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `heatmapRadius`.
    public PropertyValue<StyleTransition> HeatmapRadiusTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.HeatmapRadiusTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.HeatmapRadiusTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// A measure of how much an individual point contributes to the heatmap. A value of 10 would be equivalent to having 10 points of weight 1 in the same spot. Especially useful when combined with clustering.
    /// Default value: 1. Minimum value: 0.
    public PropertyValue<double> HeatmapWeight
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.HeatmapWeight,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.HeatmapWeight,
            value,
            MapboxLayerKey.paint
        );
    }

    public static class PaintCodingKeys {
        public const string HeatmapColor = "heatmap-color";
        public const string HeatmapIntensity = "heatmap-intensity";
        public const string HeatmapIntensityTransition = "heatmap-intensity-transition";
        public const string HeatmapOpacity = "heatmap-opacity";
        public const string HeatmapOpacityTransition = "heatmap-opacity-transition";
        public const string HeatmapRadius = "heatmap-radius";
        public const string HeatmapRadiusTransition = "heatmap-radius-transition";
        public const string HeatmapWeight = "heatmap-weight";
    }

    public static class LayoutCodingKeys {

    }
}