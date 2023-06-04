namespace MapboxMaui.Annotations;

using GeoJSON.Text.Geometry;

public class PointAnnotation : Annotation<Point>
{
    public PointAnnotation(Point geometry, string id = null)
        : base(geometry, id)
    {
    }

    // MARK: - Style Properties -

    /// Part of the icon placed closest to the anchor.
    public IconAnchor? IconAnchor
    {
        get
        {
            return GetProperty<IconAnchor?>("icon-anchor", default);
        }
        set
        {
            SetProperty("icon-anchor", value);
        }
    }

    /// Name of image in sprite to use for drawing an image background.
    public string IconImage
    {
        get
        {
            return GetProperty<string>("icon-image", default);
        }
        set
        {
            SetProperty("icon-image", value);
        }
    }

    /// Offset distance of icon from its anchor. Positive values indicate right and down, while negative values indicate left and up. Each component is multiplied by the value of `icon-size` to obtain the final offset in pixels. When combined with `icon-rotate` the offset will be as if the rotated direction was up.
    public double[] IconOffset
    {
        get
        {
            return GetProperty<double[]>("icon-offset", default);
        }
        set
        {
            SetProperty("icon-offset", value);
        }
    }

    /// Rotates the icon clockwise.
    public double? IconRotate
    {
        get
        {
            return GetProperty<double?>("icon-rotate", default);
        }
        set
        {
            SetProperty("icon-rotate", value);
        }
    }

    /// Scales the original size of the icon by the provided factor. The new pixel size of the image will be the original pixel size multiplied by `icon-size`. 1 is the original size; 3 triples the size of the image.
    public double? IconSize
    {
        get
        {
            return GetProperty<double?>("icon-size", default);
        }
        set
        {
            SetProperty("icon-size", value);
        }
    }

    /// Sorts features in ascending order based on this value. Features with lower sort keys are drawn and placed first.  When `icon-allow-overlap` or `text-allow-overlap` is `false`, features with a lower sort key will have priority during placement. When `icon-allow-overlap` or `text-allow-overlap` is set to `true`, features with a higher sort key will overlap over features with a lower sort key.
    public double? SymbolSortKey
    {
        get
        {
            return GetProperty<double?>("symbol-sort-key", default);
        }
        set
        {
            SetProperty("symbol-sort-key", value);
        }
    }

    /// Part of the text placed closest to the anchor.
    public TextAnchor? TextAnchor
    {
        get
        {
            return GetProperty<TextAnchor?>("text-anchor", default);
        }
        set
        {
            SetProperty("text-anchor", value);
        }
    }

    /// Value to use for a text label. If a plain `string` is provided, it will be treated as a `formatted` with default/inherited formatting options. SDF images are not supported in formatted text and will be ignored.
    public string TextField
    {
        get
        {
            return GetProperty<string>("text-field", default);
        }
        set
        {
            SetProperty("text-field", value);
        }
    }

    /// Text justification options.
    public TextJustify? TextJustify
    {
        get
        {
            return GetProperty<TextJustify?>("text-justify", default);
        }
        set
        {
            SetProperty("text-justify", value);
        }
    }

    /// Text tracking amount.
    public double? TextLetterSpacing
    {
        get
        {
            return GetProperty<double?>("text-letter-spacing", default);
        }
        set
        {
            SetProperty("text-letter-spacing", value);
        }
    }

    /// Text leading value for multi-line text.
    public double? TextLineHeight
    {
        get
        {
            return GetProperty<double?>("text-line-height", default);
        }
        set
        {
            SetProperty("text-line-height", value);
        }
    }

    /// The maximum line width for text wrapping.
    public double? TextMaxWidth
    {
        get
        {
            return GetProperty<double?>("text-max-width", default);
        }
        set
        {
            SetProperty("text-max-width", value);
        }
    }

    /// Offset distance of text from its anchor. Positive values indicate right and down, while negative values indicate left and up. If used with text-variable-anchor, input values will be taken as absolute values. Offsets along the x- and y-axis will be applied automatically based on the anchor position.
    public double[] TextOffset
    {
        get
        {
            return GetProperty<double[]>("text-offset", default);
        }
        set
        {
            SetProperty("text-offset", value);
        }
    }

    /// Radial offset of text, in the direction of the symbol's anchor. Useful in combination with `text-variable-anchor`, which defaults to using the two-dimensional `text-offset` if present.
    public double? TextRadialOffset
    {
        get
        {
            return GetProperty<double?>("text-radial-offset", default);
        }
        set
        {
            SetProperty("text-radial-offset", value);
        }
    }

    /// Rotates the text clockwise.
    public double? TextRotate
    {
        get
        {
            return GetProperty<double?>("text-rotate", default);
        }
        set
        {
            SetProperty("text-rotate", value);
        }
    }

    /// Font size.
    public double? TextSize
    {
        get
        {
            return GetProperty<double?>("text-size", default);
        }
        set
        {
            SetProperty("text-size", value);
        }
    }

    /// Specifies how to capitalize text, similar to the CSS `text-transform` property.
    public TextTransform? TextTransform
    {
        get
        {
            return GetProperty<TextTransform?>("text-transform", default);
        }
        set
        {
            SetProperty("text-transform", value);
        }
    }

    /// The color of the icon. This can only be used with [SDF icons](/help/troubleshooting/using-recolorable-images-in-mapbox-maps/).
    public Color IconColor
    {
        get
        {
            return GetProperty<Color>("icon-color", default);
        }
        set
        {
            SetProperty("icon-color", value);
        }
    }

    /// Fade out the halo towards the outside.
    public double? IconHaloBlur
    {
        get
        {
            return GetProperty<double?>("icon-halo-blur", default);
        }
        set
        {
            SetProperty("icon-halo-blur", value);
        }
    }

    /// The color of the icon's halo. Icon halos can only be used with [SDF icons](/help/troubleshooting/using-recolorable-images-in-mapbox-maps/).
    public Color IconHaloColor
    {
        get
        {
            return GetProperty<Color>("icon-halo-color", default);
        }
        set
        {
            SetProperty("icon-halo-color", value);
        }
    }

    /// Distance of halo to the icon outline.
    public double? IconHaloWidth
    {
        get
        {
            return GetProperty<double?>("icon-halo-width", default);
        }
        set
        {
            SetProperty("icon-halo-width", value);
        }
    }

    /// The opacity at which the icon will be drawn.
    public double? IconOpacity
    {
        get
        {
            return GetProperty<double?>("icon-opacity", default);
        }
        set
        {
            SetProperty("icon-opacity", value);
        }
    }

    /// The color with which the text will be drawn.
    public Color TextColor
    {
        get
        {
            return GetProperty<Color>("text-color", default);
        }
        set
        {
            SetProperty("text-color", value);
        }
    }

    /// The halo's fadeout distance towards the outside.
    public double? TextHaloBlur
    {
        get
        {
            return GetProperty<double?>("text-halo-blur", default);
        }
        set
        {
            SetProperty("text-halo-blur", value);
        }
    }

    /// The color of the text's halo, which helps it stand out from backgrounds.
    public Color TextHaloColor
    {
        get
        {
            return GetProperty<Color>("text-halo-color", default);
        }
        set
        {
            SetProperty("text-halo-color", value);
        }
    }

    /// Distance of halo to the font outline. Max text halo width is 1/4 of the font-size.
    public double? TextHaloWidth
    {
        get
        {
            return GetProperty<double?>("text-halo-width", default);
        }
        set
        {
            SetProperty("text-halo-width", value);
        }
    }

    /// The opacity at which the text will be drawn.
    public double? TextOpacity
    {
        get
        {
            return GetProperty<double?>("text-opacity", default);
        }
        set
        {
            SetProperty("text-opacity", value);
        }
    }
}

