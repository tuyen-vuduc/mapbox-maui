using GeoJSON.Text.Geometry;

namespace MapboxMaui.Annotations;

public class PolylineAnnotation : Annotation<LineString>
{
    public PolylineAnnotation(LineString geometry, string id = null)
        : base(geometry, id)
    {
    }

    /// The display of lines when joining.
    public LineJoin? LineJoin
    {
        get
        {
            return GetProperty<LineJoin?>("line-join", default);
        }
        set
        {
            SetProperty("line-join", value);
        }
    }

    /// Sorts features in ascending order based on this value. Features with a higher sort key will appear above features with a lower sort key.
    public double? LineSortKey
    {
        get
        {
            return GetProperty<double?>("line-sort-key", default);
        }
        set
        {
            SetProperty("line-sort-key", value);
        }
    }

    /// Blur applied to the line, in pixels.
    public double? LineBlur
    {
        get
        {
            return GetProperty<double?>("line-blur", default);
        }
        set
        {
            SetProperty("line-blur", value);
        }
    }

    /// The color with which the line will be drawn.
    public Color LineColor
    {
        get
        {
            return GetProperty<Color>("line-color", default);
        }
        set
        {
            SetProperty("line-color", value);
        }
    }

    /// Draws a line casing outside of a line's actual path. Value indicates the width of the inner gap.
    public double? LineGapWidth
    {
        get
        {
            return GetProperty<double?>("line-gap-width", default);
        }
        set
        {
            SetProperty("line-gap-width", value);
        }
    }

    /// The line's offset. For linear features, a positive value offsets the line to the right, relative to the direction of the line, and a negative value to the left. For polygon features, a positive value results in an inset, and a negative value results in an outset.
    public double? LineOffset
    {
        get
        {
            return GetProperty<double?>("line-offset", default);
        }
        set
        {
            SetProperty("line-offset", value);
        }
    }

    /// The opacity at which the line will be drawn.
    public double? LineOpacity
    {
        get
        {
            return GetProperty<double?>("line-opacity", default);
        }
        set
        {
            SetProperty("line-opacity", value);
        }
    }

    /// Name of image in sprite to use for drawing image lines. For seamless patterns, image width must be a factor of two (2, 4, 8, ..., 512). Note that zoom-dependent expressions will be evaluated only at integer zoom levels.
    public string LinePattern
    {
        get
        {
            return GetProperty<string>("line-pattern", default);
        }
        set
        {
            SetProperty("line-pattern", value);
        }
    }

    /// Stroke thickness.
    public double? LineWidth
    {
        get
        {
            return GetProperty<double?>("line-width", default);
        }
        set
        {
            SetProperty("line-width", value);
        }
    }
}

