namespace MapboxMaui.Styles;

/// An icon or a text label.
///
/// - SeeAlso: [Mapbox Style Specification](https://www.mapbox.com/mapbox-gl-style-spec/#layers-symbol)
public class SymbolLayer : MapboxLayer
{
    public SymbolLayer(string id, string source)
        : base(id)
    {
        Type = LayerType.Symbol;
        Source = source;
        Visibility = new PropertyValue<Visibility>(MapboxMaui.Visibility.Visible);
    }
    /// If true, the icon will be visible even if it collides with other previously drawn symbols.
    /// Default value: false.
    public PropertyValue<bool> IconAllowOverlap
    {
        get => GetProperty<PropertyValue<bool>>(
            LayoutCodingKeys.IconAllowOverlap,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.IconAllowOverlap,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Part of the icon placed closest to the anchor.
    /// Default value: "center".
    public PropertyValue<IconAnchor> IconAnchor
    {
        get => GetProperty<PropertyValue<IconAnchor>>(
            LayoutCodingKeys.IconAnchor,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.IconAnchor,
            value,
            MapboxLayerKey.layout
        );
    }
    /// If true, other symbols can be visible even if they collide with the icon.
    /// Default value: false.
    public PropertyValue<bool> IconIgnorePlacement
    {
        get => GetProperty<PropertyValue<bool>>(
            LayoutCodingKeys.IconIgnorePlacement,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.IconIgnorePlacement,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Name of image in sprite to use for drawing an image background.
    public PropertyValue<ResolvedImage> IconImage
    {
        get => GetProperty<PropertyValue<ResolvedImage>>(
            LayoutCodingKeys.IconImage,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.IconImage,
            value,
            MapboxLayerKey.layout
        );
    }
    /// If true, the icon may be flipped to prevent it from being rendered upside-down.
    /// Default value: false.
    public PropertyValue<bool> IconKeepUpright
    {
        get => GetProperty<PropertyValue<bool>>(
            LayoutCodingKeys.IconKeepUpright,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.IconKeepUpright,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Offset distance of icon from its anchor. Positive values indicate right and down, while negative values indicate left and up. Each component is multiplied by the value of `icon-size` to obtain the final offset in pixels. When combined with `icon-rotate` the offset will be as if the rotated direction was up.
    /// Default value: [0,0].
    public PropertyValue<double[]> IconOffset
    {
        get => GetProperty<PropertyValue<double[]>>(
            LayoutCodingKeys.IconOffset,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.IconOffset,
            value,
            MapboxLayerKey.layout
        );
    }
    /// If true, text will display without their corresponding icons when the icon collides with other symbols and the text does not.
    /// Default value: false.
    public PropertyValue<bool> IconOptional
    {
        get => GetProperty<PropertyValue<bool>>(
            LayoutCodingKeys.IconOptional,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.IconOptional,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Size of the additional area around the icon bounding box used for detecting symbol collisions.
    /// Default value: 2. Minimum value: 0.
    public PropertyValue<double> IconPadding
    {
        get => GetProperty<PropertyValue<double>>(
            LayoutCodingKeys.IconPadding,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.IconPadding,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Orientation of icon when map is pitched.
    /// Default value: "auto".
    public PropertyValue<IconPitchAlignment> IconPitchAlignment
    {
        get => GetProperty<PropertyValue<IconPitchAlignment>>(
            LayoutCodingKeys.IconPitchAlignment,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.IconPitchAlignment,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Rotates the icon clockwise.
    /// Default value: 0.
    public PropertyValue<double> IconRotate
    {
        get => GetProperty<PropertyValue<double>>(
            LayoutCodingKeys.IconRotate,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.IconRotate,
            value,
            MapboxLayerKey.layout
        );
    }
    /// In combination with `symbol-placement`, determines the rotation behavior of icons.
    /// Default value: "auto".
    public PropertyValue<IconRotationAlignment> IconRotationAlignment
    {
        get => GetProperty<PropertyValue<IconRotationAlignment>>(
            LayoutCodingKeys.IconRotationAlignment,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.IconRotationAlignment,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Scales the original size of the icon by the provided factor. The new pixel size of the image will be the original pixel size multiplied by `icon-size`. 1 is the original size; 3 triples the size of the image.
    /// Default value: 1. Minimum value: 0.
    public PropertyValue<double> IconSize
    {
        get => GetProperty<PropertyValue<double>>(
            LayoutCodingKeys.IconSize,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.IconSize,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Scales the icon to fit around the associated text.
    /// Default value: "none".
    public PropertyValue<IconTextFit> IconTextFit
    {
        get => GetProperty<PropertyValue<IconTextFit>>(
            LayoutCodingKeys.IconTextFit,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.IconTextFit,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Size of the additional area added to dimensions determined by `icon-text-fit`, in clockwise order: top, right, bottom, left.
    /// Default value: [0,0,0,0].
    public PropertyValue<double[]> IconTextFitPadding
    {
        get => GetProperty<PropertyValue<double[]>>(
            LayoutCodingKeys.IconTextFitPadding,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.IconTextFitPadding,
            value,
            MapboxLayerKey.layout
        );
    }
    /// If true, the symbols will not cross tile edges to avoid mutual collisions. Recommended in layers that don't have enough padding in the vector tile to prevent collisions, or if it is a point symbol layer placed after a line symbol layer. When using a client that supports global collision detection, like Mapbox GL JS version 0.42.0 or greater, enabling this property is not needed to prevent clipped labels at tile boundaries.
    /// Default value: false.
    public PropertyValue<bool> SymbolAvoidEdges
    {
        get => GetProperty<PropertyValue<bool>>(
            LayoutCodingKeys.SymbolAvoidEdges,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.SymbolAvoidEdges,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Label placement relative to its geometry.
    /// Default value: "point".
    public PropertyValue<SymbolPlacement> SymbolPlacement
    {
        get => GetProperty<PropertyValue<SymbolPlacement>>(
            LayoutCodingKeys.SymbolPlacement,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.SymbolPlacement,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Sorts features in ascending order based on this value. Features with lower sort keys are drawn and placed first. When `icon-allow-overlap` or `text-allow-overlap` is `false`, features with a lower sort key will have priority during placement. When `icon-allow-overlap` or `text-allow-overlap` is set to `true`, features with a higher sort key will overlap over features with a lower sort key.
    public PropertyValue<double> SymbolSortKey
    {
        get => GetProperty<PropertyValue<double>>(
            LayoutCodingKeys.SymbolSortKey,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.SymbolSortKey,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Distance between two symbol anchors.
    /// Default value: 250. Minimum value: 1.
    public PropertyValue<double> SymbolSpacing
    {
        get => GetProperty<PropertyValue<double>>(
            LayoutCodingKeys.SymbolSpacing,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.SymbolSpacing,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Position symbol on buildings (both fill extrusions and models) rooftops. In order to have minimal impact on performance, this is supported only when `fill-extrusion-height` is not zoom-dependent and remains unchanged. For fading in buildings when zooming in, fill-extrusion-vertical-scale should be used and symbols would raise with building rooftops. Symbols are sorted by elevation, except in cases when `viewport-y` sorting or `symbol-sort-key` are applied.
    /// Default value: false.
    public PropertyValue<bool> SymbolZElevate
    {
        get => GetProperty<PropertyValue<bool>>(
            LayoutCodingKeys.SymbolZElevate,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.SymbolZElevate,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Determines whether overlapping symbols in the same layer are rendered in the order that they appear in the data source or by their y-position relative to the viewport. To control the order and prioritization of symbols otherwise, use `symbol-sort-key`.
    /// Default value: "auto".
    public PropertyValue<SymbolZOrder> SymbolZOrder
    {
        get => GetProperty<PropertyValue<SymbolZOrder>>(
            LayoutCodingKeys.SymbolZOrder,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.SymbolZOrder,
            value,
            MapboxLayerKey.layout
        );
    }
    /// If true, the text will be visible even if it collides with other previously drawn symbols.
    /// Default value: false.
    public PropertyValue<bool> TextAllowOverlap
    {
        get => GetProperty<PropertyValue<bool>>(
            LayoutCodingKeys.TextAllowOverlap,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.TextAllowOverlap,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Part of the text placed closest to the anchor.
    /// Default value: "center".
    public PropertyValue<TextAnchor> TextAnchor
    {
        get => GetProperty<PropertyValue<TextAnchor>>(
            LayoutCodingKeys.TextAnchor,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.TextAnchor,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Value to use for a text label. If a plain `string` is provided, it will be treated as a `formatted` with default/inherited formatting options. SDF images are not supported in formatted text and will be ignored.
    /// Default value: "".
    public PropertyValue<string> TextField
    {
        get => GetProperty<PropertyValue<string>>(
            LayoutCodingKeys.TextField,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.TextField,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Font stack to use for displaying text.
    public PropertyValue<string[]> TextFont
    {
        get => GetProperty<PropertyValue<string[]>>(
            LayoutCodingKeys.TextFont,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.TextFont,
            value,
            MapboxLayerKey.layout
        );
    }
    /// If true, other symbols can be visible even if they collide with the text.
    /// Default value: false.
    public PropertyValue<bool> TextIgnorePlacement
    {
        get => GetProperty<PropertyValue<bool>>(
            LayoutCodingKeys.TextIgnorePlacement,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.TextIgnorePlacement,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Text justification options.
    /// Default value: "center".
    public PropertyValue<TextJustify> TextJustify
    {
        get => GetProperty<PropertyValue<TextJustify>>(
            LayoutCodingKeys.TextJustify,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.TextJustify,
            value,
            MapboxLayerKey.layout
        );
    }
    /// If true, the text may be flipped vertically to prevent it from being rendered upside-down.
    /// Default value: true.
    public PropertyValue<bool> TextKeepUpright
    {
        get => GetProperty<PropertyValue<bool>>(
            LayoutCodingKeys.TextKeepUpright,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.TextKeepUpright,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Text tracking amount.
    /// Default value: 0.
    public PropertyValue<double> TextLetterSpacing
    {
        get => GetProperty<PropertyValue<double>>(
            LayoutCodingKeys.TextLetterSpacing,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.TextLetterSpacing,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Text leading value for multi-line text.
    /// Default value: 1.2.
    public PropertyValue<double> TextLineHeight
    {
        get => GetProperty<PropertyValue<double>>(
            LayoutCodingKeys.TextLineHeight,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.TextLineHeight,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Maximum angle change between adjacent characters.
    /// Default value: 45.
    public PropertyValue<double> TextMaxAngle
    {
        get => GetProperty<PropertyValue<double>>(
            LayoutCodingKeys.TextMaxAngle,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.TextMaxAngle,
            value,
            MapboxLayerKey.layout
        );
    }
    /// The maximum line width for text wrapping.
    /// Default value: 10. Minimum value: 0.
    public PropertyValue<double> TextMaxWidth
    {
        get => GetProperty<PropertyValue<double>>(
            LayoutCodingKeys.TextMaxWidth,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.TextMaxWidth,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Offset distance of text from its anchor. Positive values indicate right and down, while negative values indicate left and up. If used with text-variable-anchor, input values will be taken as absolute values. Offsets along the x- and y-axis will be applied automatically based on the anchor position.
    /// Default value: [0,0].
    public PropertyValue<double[]> TextOffset
    {
        get => GetProperty<PropertyValue<double[]>>(
            LayoutCodingKeys.TextOffset,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.TextOffset,
            value,
            MapboxLayerKey.layout
        );
    }
    /// If true, icons will display without their corresponding text when the text collides with other symbols and the icon does not.
    /// Default value: false.
    public PropertyValue<bool> TextOptional
    {
        get => GetProperty<PropertyValue<bool>>(
            LayoutCodingKeys.TextOptional,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.TextOptional,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Size of the additional area around the text bounding box used for detecting symbol collisions.
    /// Default value: 2. Minimum value: 0.
    public PropertyValue<double> TextPadding
    {
        get => GetProperty<PropertyValue<double>>(
            LayoutCodingKeys.TextPadding,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.TextPadding,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Orientation of text when map is pitched.
    /// Default value: "auto".
    public PropertyValue<TextPitchAlignment> TextPitchAlignment
    {
        get => GetProperty<PropertyValue<TextPitchAlignment>>(
            LayoutCodingKeys.TextPitchAlignment,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.TextPitchAlignment,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Radial offset of text, in the direction of the symbol's anchor. Useful in combination with `text-variable-anchor`, which defaults to using the two-dimensional `text-offset` if present.
    /// Default value: 0.
    public PropertyValue<double> TextRadialOffset
    {
        get => GetProperty<PropertyValue<double>>(
            LayoutCodingKeys.TextRadialOffset,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.TextRadialOffset,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Rotates the text clockwise.
    /// Default value: 0.
    public PropertyValue<double> TextRotate
    {
        get => GetProperty<PropertyValue<double>>(
            LayoutCodingKeys.TextRotate,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.TextRotate,
            value,
            MapboxLayerKey.layout
        );
    }
    /// In combination with `symbol-placement`, determines the rotation behavior of the individual glyphs forming the text.
    /// Default value: "auto".
    public PropertyValue<TextRotationAlignment> TextRotationAlignment
    {
        get => GetProperty<PropertyValue<TextRotationAlignment>>(
            LayoutCodingKeys.TextRotationAlignment,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.TextRotationAlignment,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Font size.
    /// Default value: 16. Minimum value: 0.
    public PropertyValue<double> TextSize
    {
        get => GetProperty<PropertyValue<double>>(
            LayoutCodingKeys.TextSize,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.TextSize,
            value,
            MapboxLayerKey.layout
        );
    }
    /// Specifies how to capitalize text, similar to the CSS `text-transform` property.
    /// Default value: "none".
    public PropertyValue<TextTransform> TextTransform
    {
        get => GetProperty<PropertyValue<TextTransform>>(
            LayoutCodingKeys.TextTransform,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.TextTransform,
            value,
            MapboxLayerKey.layout
        );
    }
    /// To increase the chance of placing high-priority labels on the map, you can provide an array of `text-anchor` locations: the renderer will attempt to place the label at each location, in order, before moving onto the next label. Use `text-justify: auto` to choose justification based on anchor position. To apply an offset, use the `text-radial-offset` or the two-dimensional `text-offset`.
    public PropertyValue<TextAnchor[]> TextVariableAnchor
    {
        get => GetProperty<PropertyValue<TextAnchor[]>>(
            LayoutCodingKeys.TextVariableAnchor,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.TextVariableAnchor,
            value,
            MapboxLayerKey.layout
        );
    }
    /// The property allows control over a symbol's orientation. Note that the property values act as a hint, so that a symbol whose language doesn’t support the provided orientation will be laid out in its natural orientation. Example: English point symbol will be rendered horizontally even if array value contains single 'vertical' enum value. For symbol with point placement, the order of elements in an array define priority order for the placement of an orientation variant. For symbol with line placement, the default text writing mode is either ['horizontal', 'vertical'] or ['vertical', 'horizontal'], the order doesn't affect the placement.
    public PropertyValue<TextWritingMode[]> TextWritingMode
    {
        get => GetProperty<PropertyValue<TextWritingMode[]>>(
            LayoutCodingKeys.TextWritingMode,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            LayoutCodingKeys.TextWritingMode,
            value,
            MapboxLayerKey.layout
        );
    }
    /// The color of the icon. This can only be used with [SDF icons](/help/troubleshooting/using-recolorable-images-in-mapbox-maps/).
    /// Default value: "#000000".
    public PropertyValue<Color> IconColor
    {
        get => GetProperty<PropertyValue<Color>>(
            PaintCodingKeys.IconColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.IconColor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `iconColor`.
    public PropertyValue<StyleTransition> IconColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.IconColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.IconColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Increase or reduce the saturation of the symbol icon.
    /// Default value: 0. Value range: [-1, 1]
    public PropertyValue<double> IconColorSaturation
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.IconColorSaturation,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.IconColorSaturation,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `iconColorSaturation`.
    public PropertyValue<StyleTransition> IconColorSaturationTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.IconColorSaturationTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.IconColorSaturationTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Controls the intensity of light emitted on the source features.
    /// Default value: 1. Minimum value: 0.
    public PropertyValue<double> IconEmissiveStrength
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.IconEmissiveStrength,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.IconEmissiveStrength,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `iconEmissiveStrength`.
    public PropertyValue<StyleTransition> IconEmissiveStrengthTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.IconEmissiveStrengthTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.IconEmissiveStrengthTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Fade out the halo towards the outside.
    /// Default value: 0. Minimum value: 0.
    public PropertyValue<double> IconHaloBlur
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.IconHaloBlur,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.IconHaloBlur,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `iconHaloBlur`.
    public PropertyValue<StyleTransition> IconHaloBlurTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.IconHaloBlurTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.IconHaloBlurTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The color of the icon's halo. Icon halos can only be used with [SDF icons](/help/troubleshooting/using-recolorable-images-in-mapbox-maps/).
    /// Default value: "rgba(0, 0, 0, 0)".
    public PropertyValue<Color> IconHaloColor
    {
        get => GetProperty<PropertyValue<Color>>(
            PaintCodingKeys.IconHaloColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.IconHaloColor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `iconHaloColor`.
    public PropertyValue<StyleTransition> IconHaloColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.IconHaloColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.IconHaloColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Distance of halo to the icon outline.
    /// Default value: 0. Minimum value: 0.
    public PropertyValue<double> IconHaloWidth
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.IconHaloWidth,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.IconHaloWidth,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `iconHaloWidth`.
    public PropertyValue<StyleTransition> IconHaloWidthTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.IconHaloWidthTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.IconHaloWidthTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Controls the transition progress between the image variants of icon-image. Zero means the first variant is used, one is the second, and in between they are blended together.
    /// Default value: 0. Value range: [0, 1]
    public PropertyValue<double> IconImageCrossFade
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.IconImageCrossFade,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.IconImageCrossFade,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `iconImageCrossFade`.
    public PropertyValue<StyleTransition> IconImageCrossFadeTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.IconImageCrossFadeTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.IconImageCrossFadeTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The opacity at which the icon will be drawn in case of being depth occluded. Not supported on globe zoom levels.
    /// Default value: 1. Value range: [0, 1]
    /// Transition options for `iconOcclusionOpacity`.
    /// The opacity at which the icon will be drawn.
    /// Default value: 1. Value range: [0, 1]
    public PropertyValue<double> IconOpacity
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.IconOpacity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.IconOpacity,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `iconOpacity`.
    public PropertyValue<StyleTransition> IconOpacityTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.IconOpacityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.IconOpacityTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Distance that the icon's anchor is moved from its original placement. Positive values indicate right and down, while negative values indicate left and up.
    /// Default value: [0,0].
    public PropertyValue<double[]> IconTranslate
    {
        get => GetProperty<PropertyValue<double[]>>(
            PaintCodingKeys.IconTranslate,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.IconTranslate,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `iconTranslate`.
    public PropertyValue<StyleTransition> IconTranslateTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.IconTranslateTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.IconTranslateTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Controls the frame of reference for `icon-translate`.
    /// Default value: "map".
    public PropertyValue<IconTranslateAnchor> IconTranslateAnchor
    {
        get => GetProperty<PropertyValue<IconTranslateAnchor>>(
            PaintCodingKeys.IconTranslateAnchor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.IconTranslateAnchor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The color with which the text will be drawn.
    /// Default value: "#000000".
    public PropertyValue<Color> TextColor
    {
        get => GetProperty<PropertyValue<Color>>(
            PaintCodingKeys.TextColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.TextColor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `textColor`.
    public PropertyValue<StyleTransition> TextColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.TextColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.TextColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Controls the intensity of light emitted on the source features.
    /// Default value: 1. Minimum value: 0.
    public PropertyValue<double> TextEmissiveStrength
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.TextEmissiveStrength,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.TextEmissiveStrength,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `textEmissiveStrength`.
    public PropertyValue<StyleTransition> TextEmissiveStrengthTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.TextEmissiveStrengthTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.TextEmissiveStrengthTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The halo's fadeout distance towards the outside.
    /// Default value: 0. Minimum value: 0.
    public PropertyValue<double> TextHaloBlur
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.TextHaloBlur,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.TextHaloBlur,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `textHaloBlur`.
    public PropertyValue<StyleTransition> TextHaloBlurTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.TextHaloBlurTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.TextHaloBlurTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The color of the text's halo, which helps it stand out from backgrounds.
    /// Default value: "rgba(0, 0, 0, 0)".
    public PropertyValue<Color> TextHaloColor
    {
        get => GetProperty<PropertyValue<Color>>(
            PaintCodingKeys.TextHaloColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.TextHaloColor,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `textHaloColor`.
    public PropertyValue<StyleTransition> TextHaloColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.TextHaloColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.TextHaloColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Distance of halo to the font outline. Max text halo width is 1/4 of the font-size.
    /// Default value: 0. Minimum value: 0.
    public PropertyValue<double> TextHaloWidth
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.TextHaloWidth,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.TextHaloWidth,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `textHaloWidth`.
    public PropertyValue<StyleTransition> TextHaloWidthTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.TextHaloWidthTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.TextHaloWidthTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// The opacity at which the text will be drawn in case of being depth occluded. Not supported on globe zoom levels.
    /// Default value: 1. Value range: [0, 1]
    /// Transition options for `textOcclusionOpacity`.
    /// The opacity at which the text will be drawn.
    /// Default value: 1. Value range: [0, 1]
    public PropertyValue<double> TextOpacity
    {
        get => GetProperty<PropertyValue<double>>(
            PaintCodingKeys.TextOpacity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.TextOpacity,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `textOpacity`.
    public PropertyValue<StyleTransition> TextOpacityTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.TextOpacityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.TextOpacityTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Distance that the text's anchor is moved from its original placement. Positive values indicate right and down, while negative values indicate left and up.
    /// Default value: [0,0].
    public PropertyValue<double[]> TextTranslate
    {
        get => GetProperty<PropertyValue<double[]>>(
            PaintCodingKeys.TextTranslate,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.TextTranslate,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Transition options for `textTranslate`.
    public PropertyValue<StyleTransition> TextTranslateTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            PaintCodingKeys.TextTranslateTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.TextTranslateTransition,
            value,
            MapboxLayerKey.paint
        );
    }
    /// Controls the frame of reference for `text-translate`.
    /// Default value: "map".
    public PropertyValue<TextTranslateAnchor> TextTranslateAnchor
    {
        get => GetProperty<PropertyValue<TextTranslateAnchor>>(
            PaintCodingKeys.TextTranslateAnchor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            PaintCodingKeys.TextTranslateAnchor,
            value,
            MapboxLayerKey.paint
        );
    }

    public static class PaintCodingKeys {
        public const string IconColor = "icon-color";
        public const string IconColorTransition = "icon-color-transition";
        public const string IconColorSaturation = "icon-color-saturation";
        public const string IconColorSaturationTransition = "icon-color-saturation-transition";
        public const string IconEmissiveStrength = "icon-emissive-strength";
        public const string IconEmissiveStrengthTransition = "icon-emissive-strength-transition";
        public const string IconHaloBlur = "icon-halo-blur";
        public const string IconHaloBlurTransition = "icon-halo-blur-transition";
        public const string IconHaloColor = "icon-halo-color";
        public const string IconHaloColorTransition = "icon-halo-color-transition";
        public const string IconHaloWidth = "icon-halo-width";
        public const string IconHaloWidthTransition = "icon-halo-width-transition";
        public const string IconImageCrossFade = "icon-image-cross-fade";
        public const string IconImageCrossFadeTransition = "icon-image-cross-fade-transition";
        public const string IconOcclusionOpacity = "icon-occlusion-opacity";
        public const string IconOcclusionOpacityTransition = "icon-occlusion-opacity-transition";
        public const string IconOpacity = "icon-opacity";
        public const string IconOpacityTransition = "icon-opacity-transition";
        public const string IconTranslate = "icon-translate";
        public const string IconTranslateTransition = "icon-translate-transition";
        public const string IconTranslateAnchor = "icon-translate-anchor";
        public const string TextColor = "text-color";
        public const string TextColorTransition = "text-color-transition";
        public const string TextEmissiveStrength = "text-emissive-strength";
        public const string TextEmissiveStrengthTransition = "text-emissive-strength-transition";
        public const string TextHaloBlur = "text-halo-blur";
        public const string TextHaloBlurTransition = "text-halo-blur-transition";
        public const string TextHaloColor = "text-halo-color";
        public const string TextHaloColorTransition = "text-halo-color-transition";
        public const string TextHaloWidth = "text-halo-width";
        public const string TextHaloWidthTransition = "text-halo-width-transition";
        public const string TextOcclusionOpacity = "text-occlusion-opacity";
        public const string TextOcclusionOpacityTransition = "text-occlusion-opacity-transition";
        public const string TextOpacity = "text-opacity";
        public const string TextOpacityTransition = "text-opacity-transition";
        public const string TextTranslate = "text-translate";
        public const string TextTranslateTransition = "text-translate-transition";
        public const string TextTranslateAnchor = "text-translate-anchor";
    }

    public static class LayoutCodingKeys {
        public const string IconAllowOverlap = "icon-allow-overlap";
        public const string IconAnchor = "icon-anchor";
        public const string IconIgnorePlacement = "icon-ignore-placement";
        public const string IconImage = "icon-image";
        public const string IconKeepUpright = "icon-keep-upright";
        public const string IconOffset = "icon-offset";
        public const string IconOptional = "icon-optional";
        public const string IconPadding = "icon-padding";
        public const string IconPitchAlignment = "icon-pitch-alignment";
        public const string IconRotate = "icon-rotate";
        public const string IconRotationAlignment = "icon-rotation-alignment";
        public const string IconSize = "icon-size";
        public const string IconTextFit = "icon-text-fit";
        public const string IconTextFitPadding = "icon-text-fit-padding";
        public const string SymbolAvoidEdges = "symbol-avoid-edges";
        public const string SymbolPlacement = "symbol-placement";
        public const string SymbolSortKey = "symbol-sort-key";
        public const string SymbolSpacing = "symbol-spacing";
        public const string SymbolZElevate = "symbol-z-elevate";
        public const string SymbolZOrder = "symbol-z-order";
        public const string TextAllowOverlap = "text-allow-overlap";
        public const string TextAnchor = "text-anchor";
        public const string TextField = "text-field";
        public const string TextFont = "text-font";
        public const string TextIgnorePlacement = "text-ignore-placement";
        public const string TextJustify = "text-justify";
        public const string TextKeepUpright = "text-keep-upright";
        public const string TextLetterSpacing = "text-letter-spacing";
        public const string TextLineHeight = "text-line-height";
        public const string TextMaxAngle = "text-max-angle";
        public const string TextMaxWidth = "text-max-width";
        public const string TextOffset = "text-offset";
        public const string TextOptional = "text-optional";
        public const string TextPadding = "text-padding";
        public const string TextPitchAlignment = "text-pitch-alignment";
        public const string TextRadialOffset = "text-radial-offset";
        public const string TextRotate = "text-rotate";
        public const string TextRotationAlignment = "text-rotation-alignment";
        public const string TextSize = "text-size";
        public const string TextTransform = "text-transform";
        public const string TextVariableAnchor = "text-variable-anchor";
        public const string TextWritingMode = "text-writing-mode";
    }
}