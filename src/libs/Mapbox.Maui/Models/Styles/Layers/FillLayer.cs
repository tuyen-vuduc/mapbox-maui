namespace MapboxMaui.Styles;

public class FillLayer : MapboxLayer
{
    public FillLayer(string id)
        : base(id)
    {
        Type = LayerType.Fill;
        Visibility = new PropertyValue<Visibility>(MapboxMaui.Visibility.Visible);
    }
    /// Sorts features in ascending order based on this value. Features with a higher sort key will appear above features with a lower sort key.
    public PropertyValue<double> FillSortKey
    {
        get => GetProperty<PropertyValue<double>>(
            LayoutCodingKeys.fillSortKey,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            LayoutCodingKeys.fillSortKey,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Whether or not the fill should be antialiased.
    public PropertyValue<bool> FillAntialias
    {
        get => GetProperty<PropertyValue<bool>>(
            FillLayerKey.fillAntialias,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillLayerKey.fillAntialias,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The color of the filled part of this layer. This color can be specified as `rgba` with an alpha component and the color's opacity will not affect the opacity of the 1px stroke, if it is used.
    public PropertyValue<Color> FillColor
    {
        get => GetProperty<PropertyValue<Color>>(
            FillLayerKey.fillColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillLayerKey.fillColor,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `fillColor`.
    public PropertyValue<StyleTransition> FillColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            FillLayerKey.fillColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillLayerKey.fillColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The opacity of the entire fill layer. In contrast to the `fill-color`, this value will also affect the 1px stroke around the fill, if the stroke is used.
    public PropertyValue<double> FillOpacity
    {
        get => GetProperty<PropertyValue<double>>(
            FillLayerKey.fillOpacity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillLayerKey.fillOpacity,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `fillOpacity`.
    public PropertyValue<StyleTransition> FillOpacityTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            FillLayerKey.fillOpacityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillLayerKey.fillOpacityTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The outline color of the fill. Matches the value of `fill-color` if unspecified.
    public PropertyValue<Color> FillOutlineColor
    {
        get => GetProperty<PropertyValue<Color>>(
            FillLayerKey.fillOutlineColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillLayerKey.fillOutlineColor,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `fillOutlineColor`.
    public PropertyValue<StyleTransition> FillOutlineColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            FillLayerKey.fillOutlineColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillLayerKey.fillOutlineColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Name of image in sprite to use for drawing image fills. For seamless patterns, image width and height must be a factor of two (2, 4, 8, ..., 512). Note that zoom-dependent expressions will be evaluated only at integer zoom levels.
    public PropertyValue<ResolvedImage> FillPattern
    {
        get => GetProperty<PropertyValue<ResolvedImage>>(
            FillLayerKey.fillPattern,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillLayerKey.fillPattern,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The geometry's offset. Values are [x, y] where negatives indicate left and up, respectively.
    public PropertyValue<double[]> FillTranslate
    {
        get => GetProperty<PropertyValue<double[]>>(
            FillLayerKey.fillTranslate,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillLayerKey.fillTranslate,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `fillTranslate`.
    public PropertyValue<StyleTransition> FillTranslateTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            FillLayerKey.fillTranslateTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillLayerKey.fillTranslateTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Controls the frame of reference for `fill-translate`.
    public PropertyValue<FillTranslateAnchor> FillTranslateAnchor
    {
        get => GetProperty<PropertyValue<FillTranslateAnchor>>(
            FillLayerKey.fillTranslateAnchor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            FillLayerKey.fillTranslateAnchor,
            value,
            MapboxLayerKey.paint
        );
    }

    static class LayoutCodingKeys
    {
        public const string fillSortKey = "fill-sort-key";
        public const string visibility = "visibility";
    }

    static class FillLayerKey
    {
        public const string fillAntialias = "fill-antialias";
        public const string fillColor = "fill-color";
        public const string fillColorTransition = "fill-color-transition";
        public const string fillOpacity = "fill-opacity";
        public const string fillOpacityTransition = "fill-opacity-transition";
        public const string fillOutlineColor = "fill-outline-color";
        public const string fillOutlineColorTransition = "fill-outline-color-transition";
        public const string fillPattern = "fill-pattern";
        public const string fillTranslate = "fill-translate";
        public const string fillTranslateTransition = "fill-translate-transition";
        public const string fillTranslateAnchor = "fill-translate-anchor";
    }
}

