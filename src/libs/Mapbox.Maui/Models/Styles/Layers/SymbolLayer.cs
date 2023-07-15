namespace MapboxMaui.Styles;

public class SymbolLayer : MapboxLayer
{
    public SymbolLayer(string id)
        : base(id)
    {
        Type = LayerType.Symbol;
        Visibility = new PropertyValue<Visibility>(MapboxMaui.Visibility.Visible);
    }


    /// If true, the icon will be visible even if it collides with other previously drawn symbols.
    public PropertyValue<bool> IconAllowOverlap
    {
        get => GetProperty<PropertyValue<bool>>(
            SymbolLayerLayoutKey.iconAllowOverlap,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.iconAllowOverlap,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Part of the icon placed closest to the anchor.
    public PropertyValue<IconAnchor> IconAnchor
    {
        get => GetProperty<PropertyValue<IconAnchor>>(
            SymbolLayerLayoutKey.iconAnchor,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.iconAnchor,
            value,
            MapboxLayerKey.layout
        );
    }

    /// If true, other symbols can be visible even if they collide with the icon.
    public PropertyValue<bool> IconIgnorePlacement
    {
        get => GetProperty<PropertyValue<bool>>(
            SymbolLayerLayoutKey.iconIgnorePlacement,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.iconIgnorePlacement,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Name of image in sprite to use for drawing an image background.
    public PropertyValue<ResolvedImage> IconImage
    {
        get => GetProperty<PropertyValue<ResolvedImage>>(
            SymbolLayerLayoutKey.iconImage,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.iconImage,
            value,
            MapboxLayerKey.layout
        );
    }

    /// If true, the icon may be flipped to prevent it from being rendered upside-down.
    public PropertyValue<bool> IconKeepUpright
    {
        get => GetProperty<PropertyValue<bool>>(
            SymbolLayerLayoutKey.iconKeepUpright,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.iconKeepUpright,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Offset distance of icon from its anchor. Positive values indicate right and down, while negative values indicate left and up. Each component is multiplied by the value of `icon-size` to obtain the final offset in pixels. When combined with `icon-rotate` the offset will be as if the rotated direction was up.
    public PropertyValue<double[]> IconOffset
    {
        get => GetProperty<PropertyValue<double[]>>(
            SymbolLayerLayoutKey.iconOffset,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.iconOffset,
            value,
            MapboxLayerKey.layout
        );
    }

    /// If true, text will display without their corresponding icons when the icon collides with other symbols and the text does not.
    public PropertyValue<bool> IconOptional
    {
        get => GetProperty<PropertyValue<bool>>(
            SymbolLayerLayoutKey.iconOptional,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.iconOptional,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Size of the additional area around the icon bounding box used for detecting symbol collisions.
    public PropertyValue<double> IconPadding
    {
        get => GetProperty<PropertyValue<double>>(
            SymbolLayerLayoutKey.iconPadding,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.iconPadding,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Orientation of icon when map is pitched.
    public PropertyValue<IconPitchAlignment> IconPitchAlignment
    {
        get => GetProperty<PropertyValue<IconPitchAlignment>>(
            SymbolLayerLayoutKey.iconPitchAlignment,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.iconPitchAlignment,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Rotates the icon clockwise.
    public PropertyValue<double> IconRotate
    {
        get => GetProperty<PropertyValue<double>>(
            SymbolLayerLayoutKey.iconRotate,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.iconRotate,
            value,
            MapboxLayerKey.layout
        );
    }

    /// In combination with `symbol-placement`, determines the rotation behavior of icons.
    public PropertyValue<IconRotationAlignment> IconRotationAlignment
    {
        get => GetProperty<PropertyValue<IconRotationAlignment>>(
            SymbolLayerLayoutKey.iconRotationAlignment,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.iconRotationAlignment,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Scales the original size of the icon by the provided factor. The new pixel size of the image will be the original pixel size multiplied by `icon-size`. 1 is the original size; 3 triples the size of the image.
    public PropertyValue<double> IconSize
    {
        get => GetProperty<PropertyValue<double>>(
            SymbolLayerLayoutKey.iconSize,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.iconSize,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Scales the icon to fit around the associated text.
    public PropertyValue<IconTextFit> IconTextFit
    {
        get => GetProperty<PropertyValue<IconTextFit>>(
            SymbolLayerLayoutKey.iconTextFit,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.iconTextFit,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Size of the additional area added to dimensions determined by `icon-text-fit`, in clockwise order: top, right, bottom, left.
    public PropertyValue<double[]> IconTextFitPadding
    {
        get => GetProperty<PropertyValue<double[]>>(
            SymbolLayerLayoutKey.iconTextFitPadding,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.iconTextFitPadding,
            value,
            MapboxLayerKey.layout
        );
    }

    /// If true, the symbols will not cross tile edges to avoid mutual collisions. Recommended in layers that don't have enough padding in the vector tile to prevent collisions, or if it is a point symbol layer placed after a line symbol layer. When using a client that supports global collision detection, like Mapbox GL JS version 0.42.0 or greater, enabling this property is not needed to prevent clipped labels at tile boundaries.
    public PropertyValue<bool> SymbolAvoidEdges
    {
        get => GetProperty<PropertyValue<bool>>(
            SymbolLayerLayoutKey.symbolAvoidEdges,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.symbolAvoidEdges,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Label placement relative to its geometry.
    public PropertyValue<SymbolPlacement> SymbolPlacement
    {
        get => GetProperty<PropertyValue<SymbolPlacement>>(
            SymbolLayerLayoutKey.symbolPlacement,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.symbolPlacement,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Sorts features in ascending order based on this value. Features with lower sort keys are drawn and placed first.  When `icon-allow-overlap` or `text-allow-overlap` is `false`, features with a lower sort key will have priority during placement. When `icon-allow-overlap` or `text-allow-overlap` is set to `true`, features with a higher sort key will overlap over features with a lower sort key.
    public PropertyValue<double> SymbolSortKey
    {
        get => GetProperty<PropertyValue<double>>(
            SymbolLayerLayoutKey.symbolSortKey,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.symbolSortKey,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Distance between two symbol anchors.
    public PropertyValue<double> SymbolSpacing
    {
        get => GetProperty<PropertyValue<double>>(
            SymbolLayerLayoutKey.symbolSpacing,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.symbolSpacing,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Determines whether overlapping symbols in the same layer are rendered in the order that they appear in the data source or by their y-position relative to the viewport. To control the order and prioritization of symbols otherwise, use `symbol-sort-key`.
    public PropertyValue<SymbolZOrder> SymbolZOrder
    {
        get => GetProperty<PropertyValue<SymbolZOrder>>(
            SymbolLayerLayoutKey.symbolZOrder,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.symbolZOrder,
            value,
            MapboxLayerKey.layout
        );
    }

    /// If true, the text will be visible even if it collides with other previously drawn symbols.
    public PropertyValue<bool> TextAllowOverlap
    {
        get => GetProperty<PropertyValue<bool>>(
            SymbolLayerLayoutKey.textAllowOverlap,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.textAllowOverlap,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Part of the text placed closest to the anchor.
    public PropertyValue<TextAnchor> TextAnchor
    {
        get => GetProperty<PropertyValue<TextAnchor>>(
            SymbolLayerLayoutKey.textAnchor,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.textAnchor,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Value to use for a text label. If a plain `string` is provided, it will be treated as a `formatted` with default/inherited formatting options. SDF images are not supported in formatted text and will be ignored.
    public PropertyValue<string> TextField
    {
        get => GetProperty<PropertyValue<string>>(
            SymbolLayerLayoutKey.textField,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.textField,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Font stack to use for displaying text.
    public PropertyValue<string[]> TextFont
    {
        get => GetProperty<PropertyValue<string[]>>(
            SymbolLayerLayoutKey.textFont,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.textFont,
            value,
            MapboxLayerKey.layout
        );
    }

    /// If true, other symbols can be visible even if they collide with the text.
    public PropertyValue<bool> TextIgnorePlacement
    {
        get => GetProperty<PropertyValue<bool>>(
            SymbolLayerLayoutKey.textIgnorePlacement,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.textIgnorePlacement,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Text justification options.
    public PropertyValue<TextJustify> TextJustify
    {
        get => GetProperty<PropertyValue<TextJustify>>(
            SymbolLayerLayoutKey.textJustify,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.textJustify,
            value,
            MapboxLayerKey.layout
        );
    }

    /// If true, the text may be flipped vertically to prevent it from being rendered upside-down.
    public PropertyValue<bool> TextKeepUpright
    {
        get => GetProperty<PropertyValue<bool>>(
            SymbolLayerLayoutKey.textKeepUpright,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.textKeepUpright,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Text tracking amount.
    public PropertyValue<double> TextLetterSpacing
    {
        get => GetProperty<PropertyValue<double>>(
            SymbolLayerLayoutKey.textLetterSpacing,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.textLetterSpacing,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Text leading value for multi-line text.
    public PropertyValue<double> TextLineHeight
    {
        get => GetProperty<PropertyValue<double>>(
            SymbolLayerLayoutKey.textLineHeight,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.textLineHeight,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Maximum angle change between adjacent characters.
    public PropertyValue<double> TextMaxAngle
    {
        get => GetProperty<PropertyValue<double>>(
            SymbolLayerLayoutKey.textMaxAngle,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.textMaxAngle,
            value,
            MapboxLayerKey.layout
        );
    }

    /// The maximum line width for text wrapping.
    public PropertyValue<double> TextMaxWidth
    {
        get => GetProperty<PropertyValue<double>>(
            SymbolLayerLayoutKey.textMaxWidth,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.textMaxWidth,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Offset distance of text from its anchor. Positive values indicate right and down, while negative values indicate left and up. If used with text-variable-anchor, input values will be taken as absolute values. Offsets along the x- and y-axis will be applied automatically based on the anchor position.
    public PropertyValue<double[]> TextOffset
    {
        get => GetProperty<PropertyValue<double[]>>(
            SymbolLayerLayoutKey.textOffset,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.textOffset,
            value,
            MapboxLayerKey.layout
        );
    }

    /// If true, icons will display without their corresponding text when the text collides with other symbols and the icon does not.
    public PropertyValue<bool> TextOptional
    {
        get => GetProperty<PropertyValue<bool>>(
            SymbolLayerLayoutKey.textOptional,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.textOptional,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Size of the additional area around the text bounding box used for detecting symbol collisions.
    public PropertyValue<double> TextPadding
    {
        get => GetProperty<PropertyValue<double>>(
            SymbolLayerLayoutKey.textPadding,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.textPadding,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Orientation of text when map is pitched.
    public PropertyValue<TextPitchAlignment> TextPitchAlignment
    {
        get => GetProperty<PropertyValue<TextPitchAlignment>>(
            SymbolLayerLayoutKey.textPitchAlignment,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.textPitchAlignment,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Radial offset of text, in the direction of the symbol's anchor. Useful in combination with `text-variable-anchor`, which defaults to using the two-dimensional `text-offset` if present.
    public PropertyValue<double> TextRadialOffset
    {
        get => GetProperty<PropertyValue<double>>(
            SymbolLayerLayoutKey.textRadialOffset,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.textRadialOffset,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Rotates the text clockwise.
    public PropertyValue<double> TextRotate
    {
        get => GetProperty<PropertyValue<double>>(
            SymbolLayerLayoutKey.textRotate,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.textRotate,
            value,
            MapboxLayerKey.layout
        );
    }

    /// In combination with `symbol-placement`, determines the rotation behavior of the individual glyphs forming the text.
    public PropertyValue<TextRotationAlignment> TextRotationAlignment
    {
        get => GetProperty<PropertyValue<TextRotationAlignment>>(
            SymbolLayerLayoutKey.textRotationAlignment,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.textRotationAlignment,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Font size.
    public PropertyValue<double> TextSize
    {
        get => GetProperty<PropertyValue<double>>(
            SymbolLayerLayoutKey.textSize,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.textSize,
            value,
            MapboxLayerKey.layout
        );
    }

    /// Specifies how to capitalize text, similar to the CSS `text-transform` property.
    public PropertyValue<TextTransform> TextTransform
    {
        get => GetProperty<PropertyValue<TextTransform>>(
            SymbolLayerLayoutKey.textTransform,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.textTransform,
            value,
            MapboxLayerKey.layout
        );
    }

    /// To increase the chance of placing high-priority labels on the map, you can provide an array of `text-anchor` locations: the renderer will attempt to place the label at each location, in order, before moving onto the next label. Use `text-justify: auto` to choose justification based on anchor position. To apply an offset, use the `text-radial-offset` or the two-dimensional `text-offset`.
    public PropertyValue<TextAnchor[]> TextVariableAnchor
    {
        get => GetProperty<PropertyValue<TextAnchor[]>>(
            SymbolLayerLayoutKey.textVariableAnchor,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.textVariableAnchor,
            value,
            MapboxLayerKey.layout
        );
    }

    /// The property allows control over a symbol's orientation. Note that the property values act as a hint, so that a symbol whose language doesn’t support the provided orientation will be laid out in its natural orientation. Example: English point symbol will be rendered horizontally even if array value contains single 'vertical' enum value. For symbol with point placement, the order of elements in an array define priority order for the placement of an orientation variant. For symbol with line placement, the default text writing mode is either ['horizontal', 'vertical'] or ['vertical', 'horizontal'], the order doesn't affect the placement.
    public PropertyValue<TextWritingMode[]> TextWritingMode
    {
        get => GetProperty<PropertyValue<TextWritingMode[]>>(
            SymbolLayerLayoutKey.textWritingMode,
            default,
            MapboxLayerKey.layout
        );
        set => SetProperty(
            SymbolLayerLayoutKey.textWritingMode,
            value,
            MapboxLayerKey.layout
        );
    }

    /// The color of the icon. This can only be used with [SDF icons](/help/troubleshooting/using-recolorable-images-in-mapbox-maps/).
    public PropertyValue<Color> IconColor
    {
        get => GetProperty<PropertyValue<Color>>(
            SymbolLayerKey.iconColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.iconColor,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `iconColor`.
    public PropertyValue<StyleTransition> IconColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            SymbolLayerKey.iconColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.iconColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Fade out the halo towards the outside.
    public PropertyValue<double> IconHaloBlur
    {
        get => GetProperty<PropertyValue<double>>(
            SymbolLayerKey.iconHaloBlur,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.iconHaloBlur,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `iconHaloBlur`.
    public PropertyValue<StyleTransition> IconHaloBlurTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            SymbolLayerKey.iconHaloBlurTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.iconHaloBlurTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The color of the icon's halo. Icon halos can only be used with [SDF icons](/help/troubleshooting/using-recolorable-images-in-mapbox-maps/).
    public PropertyValue<Color> IconHaloColor
    {
        get => GetProperty<PropertyValue<Color>>(
            SymbolLayerKey.iconHaloColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.iconHaloColor,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `iconHaloColor`.
    public PropertyValue<StyleTransition> IconHaloColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            SymbolLayerKey.iconHaloColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.iconHaloColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Distance of halo to the icon outline.
    public PropertyValue<double> IconHaloWidth
    {
        get => GetProperty<PropertyValue<double>>(
            SymbolLayerKey.iconHaloWidth,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.iconHaloWidth,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `iconHaloWidth`.
    public PropertyValue<StyleTransition> IconHaloWidthTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            SymbolLayerKey.iconHaloWidthTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.iconHaloWidthTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The opacity at which the icon will be drawn.
    public PropertyValue<double> IconOpacity
    {
        get => GetProperty<PropertyValue<double>>(
            SymbolLayerKey.iconOpacity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.iconOpacity,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `iconOpacity`.
    public PropertyValue<StyleTransition> IconOpacityTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            SymbolLayerKey.iconOpacityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.iconOpacityTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Distance that the icon's anchor is moved from its original placement. Positive values indicate right and down, while negative values indicate left and up.
    public PropertyValue<double[]> IconTranslate
    {
        get => GetProperty<PropertyValue<double[]>>(
            SymbolLayerKey.iconTranslate,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.iconTranslate,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `iconTranslate`.
    public PropertyValue<StyleTransition> IconTranslateTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            SymbolLayerKey.iconTranslateTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.iconTranslateTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Controls the frame of reference for `icon-translate`.
    public PropertyValue<IconTranslateAnchor> IconTranslateAnchor
    {
        get => GetProperty<PropertyValue<IconTranslateAnchor>>(
            SymbolLayerKey.iconTranslateAnchor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.iconTranslateAnchor,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The color with which the text will be drawn.
    public PropertyValue<Color> TextColor
    {
        get => GetProperty<PropertyValue<Color>>(
            SymbolLayerKey.textColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.textColor,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `textColor`.
    public PropertyValue<StyleTransition> TextColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            SymbolLayerKey.textColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.textColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The halo's fadeout distance towards the outside.
    public PropertyValue<double> TextHaloBlur
    {
        get => GetProperty<PropertyValue<double>>(
            SymbolLayerKey.textHaloBlur,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.textHaloBlur,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `textHaloBlur`.
    public PropertyValue<StyleTransition> TextHaloBlurTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            SymbolLayerKey.textHaloBlurTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.textHaloBlurTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The color of the text's halo, which helps it stand out from backgrounds.
    public PropertyValue<Color> TextHaloColor
    {
        get => GetProperty<PropertyValue<Color>>(
            SymbolLayerKey.textHaloColor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.textHaloColor,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `textHaloColor`.
    public PropertyValue<StyleTransition> TextHaloColorTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            SymbolLayerKey.textHaloColorTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.textHaloColorTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Distance of halo to the font outline. Max text halo width is 1/4 of the font-size.
    public PropertyValue<double> TextHaloWidth
    {
        get => GetProperty<PropertyValue<double>>(
            SymbolLayerKey.textHaloWidth,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.textHaloWidth,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `textHaloWidth`.
    public PropertyValue<StyleTransition> TextHaloWidthTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            SymbolLayerKey.textHaloWidthTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.textHaloWidthTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// The opacity at which the text will be drawn.
    public PropertyValue<double> TextOpacity
    {
        get => GetProperty<PropertyValue<double>>(
            SymbolLayerKey.textOpacity,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.textOpacity,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `textOpacity`.
    public PropertyValue<StyleTransition> TextOpacityTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            SymbolLayerKey.textOpacityTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.textOpacityTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Distance that the text's anchor is moved from its original placement. Positive values indicate right and down, while negative values indicate left and up.
    public PropertyValue<double[]> TextTranslate
    {
        get => GetProperty<PropertyValue<double[]>>(
            SymbolLayerKey.textTranslate,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.textTranslate,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Transition options for `textTranslate`.
    public PropertyValue<StyleTransition> TextTranslateTransition
    {
        get => GetProperty<PropertyValue<StyleTransition>>(
            SymbolLayerKey.textTranslateTransition,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.textTranslateTransition,
            value,
            MapboxLayerKey.paint
        );
    }

    /// Controls the frame of reference for `text-translate`.
    public PropertyValue<TextTranslateAnchor> TextTranslateAnchor
    {
        get => GetProperty<PropertyValue<TextTranslateAnchor>>(
            SymbolLayerKey.textTranslateAnchor,
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            SymbolLayerKey.textTranslateAnchor,
            value,
            MapboxLayerKey.paint
        );
    }

    public static class SymbolLayerKey
    {
        public const string iconColor = "icon-color";
        public const string iconColorTransition = "icon-color-transition";
        public const string iconHaloBlur = "icon-halo-blur";
        public const string iconHaloBlurTransition = "icon-halo-blur-transition";
        public const string iconHaloColor = "icon-halo-color";
        public const string iconHaloColorTransition = "icon-halo-color-transition";
        public const string iconHaloWidth = "icon-halo-width";
        public const string iconHaloWidthTransition = "icon-halo-width-transition";
        public const string iconOpacity = "icon-opacity";
        public const string iconOpacityTransition = "icon-opacity-transition";
        public const string iconTranslate = "icon-translate";
        public const string iconTranslateTransition = "icon-translate-transition";
        public const string iconTranslateAnchor = "icon-translate-anchor";
        public const string textColor = "text-color";
        public const string textColorTransition = "text-color-transition";
        public const string textHaloBlur = "text-halo-blur";
        public const string textHaloBlurTransition = "text-halo-blur-transition";
        public const string textHaloColor = "text-halo-color";
        public const string textHaloColorTransition = "text-halo-color-transition";
        public const string textHaloWidth = "text-halo-width";
        public const string textHaloWidthTransition = "text-halo-width-transition";
        public const string textOpacity = "text-opacity";
        public const string textOpacityTransition = "text-opacity-transition";
        public const string textTranslate = "text-translate";
        public const string textTranslateTransition = "text-translate-transition";
        public const string textTranslateAnchor = "text-translate-anchor";
    }

    public static class SymbolLayerLayoutKey
    {
        public const string iconAllowOverlap = "icon-allow-overlap";
        public const string iconAnchor = "icon-anchor";
        public const string iconIgnorePlacement = "icon-ignore-placement";
        public const string iconImage = "icon-image";
        public const string iconKeepUpright = "icon-keep-upright";
        public const string iconOffset = "icon-offset";
        public const string iconOptional = "icon-optional";
        public const string iconPadding = "icon-padding";
        public const string iconPitchAlignment = "icon-pitch-alignment";
        public const string iconRotate = "icon-rotate";
        public const string iconRotationAlignment = "icon-rotation-alignment";
        public const string iconSize = "icon-size";
        public const string iconTextFit = "icon-text-fit";
        public const string iconTextFitPadding = "icon-text-fit-padding";
        public const string symbolAvoidEdges = "symbol-avoid-edges";
        public const string symbolPlacement = "symbol-placement";
        public const string symbolSortKey = "symbol-sort-key";
        public const string symbolSpacing = "symbol-spacing";
        public const string symbolZOrder = "symbol-z-order";
        public const string textAllowOverlap = "text-allow-overlap";
        public const string textAnchor = "text-anchor";
        public const string textField = "text-field";
        public const string textFont = "text-font";
        public const string textIgnorePlacement = "text-ignore-placement";
        public const string textJustify = "text-justify";
        public const string textKeepUpright = "text-keep-upright";
        public const string textLetterSpacing = "text-letter-spacing";
        public const string textLineHeight = "text-line-height";
        public const string textMaxAngle = "text-max-angle";
        public const string textMaxWidth = "text-max-width";
        public const string textOffset = "text-offset";
        public const string textOptional = "text-optional";
        public const string textPadding = "text-padding";
        public const string textPitchAlignment = "text-pitch-alignment";
        public const string textRadialOffset = "text-radial-offset";
        public const string textRotate = "text-rotate";
        public const string textRotationAlignment = "text-rotation-alignment";
        public const string textSize = "text-size";
        public const string textTransform = "text-transform";
        public const string textVariableAnchor = "text-variable-anchor";
        public const string textWritingMode = "text-writing-mode";
        public const string visibility = "visibility";
    }
}

