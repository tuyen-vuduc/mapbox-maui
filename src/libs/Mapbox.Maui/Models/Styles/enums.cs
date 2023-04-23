namespace Mapbox.Maui;

public interface INamedString
{
    string Value { get; }
}

public struct Visibility : INamedString
{
    public string Value { get; }

    private Visibility(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(Visibility value) => value.Value;
    public static implicit operator Visibility(string value) => new Visibility(value);

    /// The layer is shown.
    public static readonly Visibility visible = new Visibility("visible");

    /// The layer is not shown.
    public static readonly Visibility none = new Visibility("none");
}

// MARK: LINE_CAP

/// The display of line endings.
public struct LineCap : INamedString
{
    public string Value { get; }

    private LineCap(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(LineCap value) => value.Value;
    public static implicit operator LineCap(string value) => new LineCap(value);

    /// A cap with a squared-off end which is drawn to the exact endpoint of the line.
    public static readonly LineCap butt = new LineCap("butt");

    /// A cap with a rounded end which is drawn beyond the endpoint of the line at a radius of one-half of the line's width and centered on the endpoint of the line.
    public static readonly LineCap round = new LineCap("round");

    /// A cap with a squared-off end which is drawn beyond the endpoint of the line at a distance of one-half of the line's width.
    public static readonly LineCap square = new LineCap("square");

}

// MARK: LINE_JOIN

/// The display of lines when joining.
public struct LineJoin : INamedString
{
    public string Value { get; }

    private LineJoin(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(LineJoin value) => value.Value;
    public static implicit operator LineJoin(string value) => new LineJoin(value);

    /// A join with a squared-off end which is drawn beyond the endpoint of the line at a distance of one-half of the line's width.
    public static readonly LineJoin bevel = new LineJoin("bevel");

    /// A join with a rounded end which is drawn beyond the endpoint of the line at a radius of one-half of the line's width and centered on the endpoint of the line.
    public static readonly LineJoin round = new LineJoin("round");

    /// A join with a sharp, angled corner which is drawn with the outer sides beyond the endpoint of the path until they meet.
    public static readonly LineJoin miter = new LineJoin("miter");

}

// MARK: ICON_ANCHOR

/// Part of the icon placed closest to the anchor.
public struct IconAnchor : INamedString
{
    public string Value { get; }

    private IconAnchor(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(IconAnchor value) => value.Value;
    public static implicit operator IconAnchor(string value) => new IconAnchor(value);

    /// The center of the icon is placed closest to the anchor.
    public static readonly IconAnchor center = new IconAnchor("center");

    /// The left side of the icon is placed closest to the anchor.
    public static readonly IconAnchor left = new IconAnchor("left");

    /// The right side of the icon is placed closest to the anchor.
    public static readonly IconAnchor right = new IconAnchor("right");

    /// The top of the icon is placed closest to the anchor.
    public static readonly IconAnchor top = new IconAnchor("top");

    /// The bottom of the icon is placed closest to the anchor.
    public static readonly IconAnchor bottom = new IconAnchor("bottom");

    /// The top left corner of the icon is placed closest to the anchor.
    public static readonly IconAnchor topLeft = new IconAnchor("top-left");

    /// The top right corner of the icon is placed closest to the anchor.
    public static readonly IconAnchor topRight = new IconAnchor("top-right");

    /// The bottom left corner of the icon is placed closest to the anchor.
    public static readonly IconAnchor bottomLeft = new IconAnchor("bottom-left");

    /// The bottom right corner of the icon is placed closest to the anchor.
    public static readonly IconAnchor bottomRight = new IconAnchor("bottom-right");

}

// MARK: ICON_PITCH_ALIGNMENT

/// Orientation of icon when map is pitched.
public struct IconPitchAlignment : INamedString
{
    public string Value { get; }

    private IconPitchAlignment(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(IconPitchAlignment value) => value.Value;
    public static implicit operator IconPitchAlignment(string value) => new IconPitchAlignment(value);

    /// The icon is aligned to the plane of the map.
    public static readonly IconPitchAlignment map = new IconPitchAlignment("map");

    /// The icon is aligned to the plane of the viewport.
    public static readonly IconPitchAlignment viewport = new IconPitchAlignment("viewport");

    /// Automatically matches the value of {@link ICON_ROTATION_ALIGNMENT}.
    public static readonly IconPitchAlignment auto = new IconPitchAlignment("auto");

}

// MARK: ICON_ROTATION_ALIGNMENT

/// In combination with `symbol-placement`, determines the rotation behavior of icons.
public struct IconRotationAlignment : INamedString
{
    public string Value { get; }

    private IconRotationAlignment(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(IconRotationAlignment value) => value.Value;
    public static implicit operator IconRotationAlignment(string value) => new IconRotationAlignment(value);

    /// When {@link SYMBOL_PLACEMENT} is set to {@link Property#SYMBOL_PLACEMENT_POINT}, aligns icons east-west. When {@link SYMBOL_PLACEMENT} is set to {@link Property#SYMBOL_PLACEMENT_LINE} or {@link Property#SYMBOL_PLACEMENT_LINE_CENTER}, aligns icon x-axes with the line.
    public static readonly IconRotationAlignment map = new IconRotationAlignment("map");

    /// Produces icons whose x-axes are aligned with the x-axis of the viewport, regardless of the value of {@link SYMBOL_PLACEMENT}.
    public static readonly IconRotationAlignment viewport = new IconRotationAlignment("viewport");

    /// When {@link SYMBOL_PLACEMENT} is set to {@link Property#SYMBOL_PLACEMENT_POINT}, this is equivalent to {@link Property#ICON_ROTATION_ALIGNMENT_VIEWPORT}. When {@link SYMBOL_PLACEMENT} is set to {@link Property#SYMBOL_PLACEMENT_LINE} or {@link Property#SYMBOL_PLACEMENT_LINE_CENTER}, this is equivalent to {@link Property#ICON_ROTATION_ALIGNMENT_MAP}.
    public static readonly IconRotationAlignment auto = new IconRotationAlignment("auto");

}

// MARK: ICON_TEXT_FIT

/// Scales the icon to fit around the associated text.
public struct IconTextFit : INamedString
{
    public string Value { get; }

    private IconTextFit(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(IconTextFit value) => value.Value;
    public static implicit operator IconTextFit(string value) => new IconTextFit(value);

    /// The icon is displayed at its intrinsic aspect ratio.
    public static readonly IconTextFit none = new IconTextFit("none");

    /// The icon is scaled in the x-dimension to fit the width of the text.
    public static readonly IconTextFit width = new IconTextFit("width");

    /// The icon is scaled in the y-dimension to fit the height of the text.
    public static readonly IconTextFit height = new IconTextFit("height");

    /// The icon is scaled in both x- and y-dimensions.
    public static readonly IconTextFit both = new IconTextFit("both");

}

// MARK: SYMBOL_PLACEMENT

/// Label placement relative to its geometry.
public struct SymbolPlacement : INamedString
{
    public string Value { get; }

    private SymbolPlacement(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(SymbolPlacement value) => value.Value;
    public static implicit operator SymbolPlacement(string value) => new SymbolPlacement(value);

    /// The label is placed at the point where the geometry is located.
    public static readonly SymbolPlacement point = new SymbolPlacement("point");

    /// The label is placed along the line of the geometry. Can only be used on LineString and Polygon geometries.
    public static readonly SymbolPlacement line = new SymbolPlacement("line");

    /// The label is placed at the center of the line of the geometry. Can only be used on LineString and Polygon geometries. Note that a single feature in a vector tile may contain multiple line geometries.
    public static readonly SymbolPlacement lineCenter = new SymbolPlacement("line-center");

}

// MARK: SYMBOL_Z_ORDER

/// Determines whether overlapping symbols in the same layer are rendered in the order that they appear in the data source or by their y-position relative to the viewport. To control the order and prioritization of symbols otherwise, use `symbol-sort-key`.
public struct SymbolZOrder : INamedString
{
    public string Value { get; }

    private SymbolZOrder(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(SymbolZOrder value) => value.Value;
    public static implicit operator SymbolZOrder(string value) => new SymbolZOrder(value);

    /// Sorts symbols by symbol sort key if set. Otherwise, sorts symbols by their y-position relative to the viewport if {@link ICON_ALLOW_OVERLAP} or {@link TEXT_ALLOW_OVERLAP} is set to {@link TRUE} or {@link ICON_IGNORE_PLACEMENT} or {@link TEXT_IGNORE_PLACEMENT} is {@link FALSE}.
    public static readonly SymbolZOrder auto = new SymbolZOrder("auto");

    /// Sorts symbols by their y-position relative to the viewport if {@link ICON_ALLOW_OVERLAP} or {@link TEXT_ALLOW_OVERLAP} is set to {@link TRUE} or {@link ICON_IGNORE_PLACEMENT} or {@link TEXT_IGNORE_PLACEMENT} is {@link FALSE}.
    public static readonly SymbolZOrder viewportY = new SymbolZOrder("viewport-y");

    /// Sorts symbols by symbol sort key if set. Otherwise, no sorting is applied; symbols are rendered in the same order as the source data.
    public static readonly SymbolZOrder source = new SymbolZOrder("source");

}

// MARK: TEXT_ANCHOR

/// Part of the text placed closest to the anchor.
public struct TextAnchor : INamedString
{
    public string Value { get; }

    private TextAnchor(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(TextAnchor value) => value.Value;
    public static implicit operator TextAnchor(string value) => new TextAnchor(value);

    /// The center of the text is placed closest to the anchor.
    public static readonly TextAnchor center = new TextAnchor("center");

    /// The left side of the text is placed closest to the anchor.
    public static readonly TextAnchor left = new TextAnchor("left");

    /// The right side of the text is placed closest to the anchor.
    public static readonly TextAnchor right = new TextAnchor("right");

    /// The top of the text is placed closest to the anchor.
    public static readonly TextAnchor top = new TextAnchor("top");

    /// The bottom of the text is placed closest to the anchor.
    public static readonly TextAnchor bottom = new TextAnchor("bottom");

    /// The top left corner of the text is placed closest to the anchor.
    public static readonly TextAnchor topLeft = new TextAnchor("top-left");

    /// The top right corner of the text is placed closest to the anchor.
    public static readonly TextAnchor topRight = new TextAnchor("top-right");

    /// The bottom left corner of the text is placed closest to the anchor.
    public static readonly TextAnchor bottomLeft = new TextAnchor("bottom-left");

    /// The bottom right corner of the text is placed closest to the anchor.
    public static readonly TextAnchor bottomRight = new TextAnchor("bottom-right");

}

// MARK: TEXT_JUSTIFY

/// Text justification options.
public struct TextJustify : INamedString
{
    public string Value { get; }

    private TextJustify(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(TextJustify value) => value.Value;
    public static implicit operator TextJustify(string value) => new TextJustify(value);

    /// The text is aligned towards the anchor position.
    public static readonly TextJustify auto = new TextJustify("auto");

    /// The text is aligned to the left.
    public static readonly TextJustify left = new TextJustify("left");

    /// The text is centered.
    public static readonly TextJustify center = new TextJustify("center");

    /// The text is aligned to the right.
    public static readonly TextJustify right = new TextJustify("right");

}

// MARK: TEXT_PITCH_ALIGNMENT

/// Orientation of text when map is pitched.
public struct TextPitchAlignment : INamedString
{
    public string Value { get; }

    private TextPitchAlignment(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(TextPitchAlignment value) => value.Value;
    public static implicit operator TextPitchAlignment(string value) => new TextPitchAlignment(value);

    /// The text is aligned to the plane of the map.
    public static readonly TextPitchAlignment map = new TextPitchAlignment("map");

    /// The text is aligned to the plane of the viewport.
    public static readonly TextPitchAlignment viewport = new TextPitchAlignment("viewport");

    /// Automatically matches the value of {@link TEXT_ROTATION_ALIGNMENT}.
    public static readonly TextPitchAlignment auto = new TextPitchAlignment("auto");

}

// MARK: TEXT_ROTATION_ALIGNMENT

/// In combination with `symbol-placement`, determines the rotation behavior of the individual glyphs forming the text.
public struct TextRotationAlignment : INamedString
{
    public string Value { get; }

    private TextRotationAlignment(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(TextRotationAlignment value) => value.Value;
    public static implicit operator TextRotationAlignment(string value) => new TextRotationAlignment(value);

    /// When {@link SYMBOL_PLACEMENT} is set to {@link Property#SYMBOL_PLACEMENT_POINT}, aligns text east-west. When {@link SYMBOL_PLACEMENT} is set to {@link Property#SYMBOL_PLACEMENT_LINE} or {@link Property#SYMBOL_PLACEMENT_LINE_CENTER}, aligns text x-axes with the line.
    public static readonly TextRotationAlignment map = new TextRotationAlignment("map");

    /// Produces glyphs whose x-axes are aligned with the x-axis of the viewport, regardless of the value of {@link SYMBOL_PLACEMENT}.
    public static readonly TextRotationAlignment viewport = new TextRotationAlignment("viewport");

    /// When {@link SYMBOL_PLACEMENT} is set to {@link Property#SYMBOL_PLACEMENT_POINT}, this is equivalent to {@link Property#TEXT_ROTATION_ALIGNMENT_VIEWPORT}. When {@link SYMBOL_PLACEMENT} is set to {@link Property#SYMBOL_PLACEMENT_LINE} or {@link Property#SYMBOL_PLACEMENT_LINE_CENTER}, this is equivalent to {@link Property#TEXT_ROTATION_ALIGNMENT_MAP}.
    public static readonly TextRotationAlignment auto = new TextRotationAlignment("auto");

}

// MARK: TEXT_TRANSFORM

/// Specifies how to capitalize text, similar to the CSS `text-transform` property.
public struct TextTransform : INamedString
{
    public string Value { get; }

    private TextTransform(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(TextTransform value) => value.Value;
    public static implicit operator TextTransform(string value) => new TextTransform(value);

    /// The text is not altered.
    public static readonly TextTransform none = new TextTransform("none");

    /// Forces all letters to be displayed in uppercase.
    public static readonly TextTransform uppercase = new TextTransform("uppercase");

    /// Forces all letters to be displayed in lowercase.
    public static readonly TextTransform lowercase = new TextTransform("lowercase");

}

// MARK: FILL_TRANSLATE_ANCHOR

/// Controls the frame of reference for `fill-translate`.
public struct FillTranslateAnchor : INamedString
{
    public string Value { get; }

    private FillTranslateAnchor(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(FillTranslateAnchor value) => value.Value;
    public static implicit operator FillTranslateAnchor(string value) => new FillTranslateAnchor(value);

    /// The fill is translated relative to the map.
    public static readonly FillTranslateAnchor map = new FillTranslateAnchor("map");

    /// The fill is translated relative to the viewport.
    public static readonly FillTranslateAnchor viewport = new FillTranslateAnchor("viewport");

}

// MARK: LINE_TRANSLATE_ANCHOR

/// Controls the frame of reference for `line-translate`.
public struct LineTranslateAnchor : INamedString
{
    public string Value { get; }

    private LineTranslateAnchor(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(LineTranslateAnchor value) => value.Value;
    public static implicit operator LineTranslateAnchor(string value) => new LineTranslateAnchor(value);

    /// The line is translated relative to the map.
    public static readonly LineTranslateAnchor map = new LineTranslateAnchor("map");

    /// The line is translated relative to the viewport.
    public static readonly LineTranslateAnchor viewport = new LineTranslateAnchor("viewport");

}

// MARK: ICON_TRANSLATE_ANCHOR

/// Controls the frame of reference for `icon-translate`.
public struct IconTranslateAnchor : INamedString
{
    public string Value { get; }

    private IconTranslateAnchor(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(IconTranslateAnchor value) => value.Value;
    public static implicit operator IconTranslateAnchor(string value) => new IconTranslateAnchor(value);

    /// Icons are translated relative to the map.
    public static readonly IconTranslateAnchor map = new IconTranslateAnchor("map");

    /// Icons are translated relative to the viewport.
    public static readonly IconTranslateAnchor viewport = new IconTranslateAnchor("viewport");

}

// MARK: TEXT_TRANSLATE_ANCHOR

/// Controls the frame of reference for `text-translate`.
public struct TextTranslateAnchor : INamedString
{
    public string Value { get; }

    private TextTranslateAnchor(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(TextTranslateAnchor value) => value.Value;
    public static implicit operator TextTranslateAnchor(string value) => new TextTranslateAnchor(value);

    /// The text is translated relative to the map.
    public static readonly TextTranslateAnchor map = new TextTranslateAnchor("map");

    /// The text is translated relative to the viewport.
    public static readonly TextTranslateAnchor viewport = new TextTranslateAnchor("viewport");

}

// MARK: CIRCLE_PITCH_ALIGNMENT

/// Orientation of circle when map is pitched.
public struct CirclePitchAlignment : INamedString
{
    public string Value { get; }

    private CirclePitchAlignment(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(CirclePitchAlignment value) => value.Value;
    public static implicit operator CirclePitchAlignment(string value) => new CirclePitchAlignment(value);

    /// The circle is aligned to the plane of the map.
    public static readonly CirclePitchAlignment map = new CirclePitchAlignment("map");

    /// The circle is aligned to the plane of the viewport.
    public static readonly CirclePitchAlignment viewport = new CirclePitchAlignment("viewport");

}

// MARK: CIRCLE_PITCH_SCALE

/// Controls the scaling behavior of the circle when the map is pitched.
public struct CirclePitchScale : INamedString
{
    public string Value { get; }

    private CirclePitchScale(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(CirclePitchScale value) => value.Value;
    public static implicit operator CirclePitchScale(string value) => new CirclePitchScale(value);

    /// Circles are scaled according to their apparent distance to the camera.
    public static readonly CirclePitchScale map = new CirclePitchScale("map");

    /// Circles are not scaled.
    public static readonly CirclePitchScale viewport = new CirclePitchScale("viewport");

}

// MARK: CIRCLE_TRANSLATE_ANCHOR

/// Controls the frame of reference for `circle-translate`.
public struct CircleTranslateAnchor : INamedString
{
    public string Value { get; }

    private CircleTranslateAnchor(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(CircleTranslateAnchor value) => value.Value;
    public static implicit operator CircleTranslateAnchor(string value) => new CircleTranslateAnchor(value);

    /// The circle is translated relative to the map.
    public static readonly CircleTranslateAnchor map = new CircleTranslateAnchor("map");

    /// The circle is translated relative to the viewport.
    public static readonly CircleTranslateAnchor viewport = new CircleTranslateAnchor("viewport");

}

// MARK: FILL_EXTRUSION_TRANSLATE_ANCHOR

/// Controls the frame of reference for `fill-extrusion-translate`.
public struct FillExtrusionTranslateAnchor : INamedString
{
    public string Value { get; }

    private FillExtrusionTranslateAnchor(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(FillExtrusionTranslateAnchor value) => value.Value;
    public static implicit operator FillExtrusionTranslateAnchor(string value) => new FillExtrusionTranslateAnchor(value);

    /// The fill extrusion is translated relative to the map.
    public static readonly FillExtrusionTranslateAnchor map = new FillExtrusionTranslateAnchor("map");

    /// The fill extrusion is translated relative to the viewport.
    public static readonly FillExtrusionTranslateAnchor viewport = new FillExtrusionTranslateAnchor("viewport");

}

// MARK: RASTER_RESAMPLING

/// The resampling/interpolation method to use for overscaling, also known as texture magnification filter
public struct RasterResampling : INamedString
{
    public string Value { get; }

    private RasterResampling(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(RasterResampling value) => value.Value;
    public static implicit operator RasterResampling(string value) => new RasterResampling(value);

    /// (Bi)linear filtering interpolates pixel values using the weighted average of the four closest original source pixels creating a smooth but blurry look when overscaled
    public static readonly RasterResampling linear = new RasterResampling("linear");

    /// Nearest neighbor filtering interpolates pixel values using the nearest original source pixel creating a sharp but pixelated look when overscaled
    public static readonly RasterResampling nearest = new RasterResampling("nearest");

}

// MARK: HILLSHADE_ILLUMINATION_ANCHOR

/// Direction of light source when map is rotated.
public struct HillshadeIlluminationAnchor : INamedString
{
    public string Value { get; }

    private HillshadeIlluminationAnchor(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(HillshadeIlluminationAnchor value) => value.Value;
    public static implicit operator HillshadeIlluminationAnchor(string value) => new HillshadeIlluminationAnchor(value);

    /// The hillshade illumination is relative to the north direction.
    public static readonly HillshadeIlluminationAnchor map = new HillshadeIlluminationAnchor("map");

    /// The hillshade illumination is relative to the top of the viewport.
    public static readonly HillshadeIlluminationAnchor viewport = new HillshadeIlluminationAnchor("viewport");

}

// MARK: SKY_TYPE

/// The type of the sky
public struct SkyType : INamedString
{
    public string Value { get; }

    private SkyType(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(SkyType value) => value.Value;
    public static implicit operator SkyType(string value) => new SkyType(value);

    /// Renders the sky with a gradient that can be configured with {@link SKY_GRADIENT_RADIUS} and {@link SKY_GRADIENT}.
    public static readonly SkyType gradient = new SkyType("gradient");

    /// Renders the sky with a simulated atmospheric scattering algorithm, the sun direction can be attached to the light position or explicitly set through {@link SKY_ATMOSPHERE_SUN}.
    public static readonly SkyType atmosphere = new SkyType("atmosphere");

}

// MARK: ANCHOR

/// Whether extruded geometries are lit relative to the map or viewport.
public struct Anchor : INamedString
{
    public string Value { get; }

    private Anchor(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(Anchor value) => value.Value;
    public static implicit operator Anchor(string value) => new Anchor(value);

    /// The position of the light source is aligned to the rotation of the map.
    public static readonly Anchor map = new Anchor("map");

    /// The position of the light source is aligned to the rotation of the viewport.
    public static readonly Anchor viewport = new Anchor("viewport");

}

// MARK: NAME

/// The name of the projection to be used for rendering the map.
public struct StyleProjectionName : INamedString
{
    public string Value { get; }

    private StyleProjectionName(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(StyleProjectionName value) => value.Value;
    public static implicit operator StyleProjectionName(string value) => new StyleProjectionName(value);

    /// The Mercator projection is the default projection.
    public static readonly StyleProjectionName mercator = new StyleProjectionName("mercator");

    /// A globe projection.
    public static readonly StyleProjectionName globe = new StyleProjectionName("globe");

}

// MARK: TEXT_WRITING_MODE

/// The property allows control over a symbol's orientation. Note that the property values act as a hint, so that a symbol whose language doesn’t support the provided orientation will be laid out in its natural orientation. Example: English point symbol will be rendered horizontally even if array value contains single 'vertical' enum value. For symbol with point placement, the order of elements in an array define priority order for the placement of an orientation variant. For symbol with line placement, the default text writing mode is either ['horizontal', 'vertical'] or ['vertical', 'horizontal'], the order doesn't affect the placement.
public struct TextWritingMode : INamedString
{
    public string Value { get; }

    private TextWritingMode(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }


    public static implicit operator string(TextWritingMode value) => value.Value;
    public static implicit operator TextWritingMode(string value) => new TextWritingMode(value);

    /// If a text's language supports horizontal writing mode, symbols would be laid out horizontally.
    public static readonly TextWritingMode horizontal = new TextWritingMode("horizontal");

    /// If a text's language supports vertical writing mode, symbols would be laid out vertically.
    public static readonly TextWritingMode vertical = new TextWritingMode("vertical");

}

// End of generated file.