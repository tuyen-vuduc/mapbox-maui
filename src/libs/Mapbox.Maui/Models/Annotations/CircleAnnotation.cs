namespace MapboxMaui.Annotations;

using GeoJSON.Text.Geometry;

public class CircleAnnotation : Annotation<Point>
{
    public CircleAnnotation(Point geometry, string id = null)
        : base(geometry, id)
    {
    }

    /// Sorts features in ascending order based on this value. Features with a higher sort key will appear above features with a lower sort key.
    public double? CircleSortKey
    {
        get
        {
            return GetProperty<double?>("circle-sort-key", default);
        }
        set
        {
            SetProperty("circle-sort-key", value);
        }
    }

    /// Amount to blur the circle. 1 blurs the circle such that only the centerpoint is full opacity.
    public double? CircleBlur
    {
        get
        {
            return GetProperty<double?>("circle-blur", default);
        }
        set
        {
            SetProperty("circle-blur", value);
        }
    }

    /// The fill color of the circle.
    public Color CircleColor
    {
        get
        {
            return GetProperty<Color>("circle-color", default);
        }
        set
        {
            SetProperty("circle-color", value);
        }
    }

    /// The opacity at which the circle will be drawn.
    public double? CircleOpacity
    {
        get
        {
            return GetProperty<double?>("circle-opacity", default);
        }
        set
        {
            SetProperty("circle-opacity", value);
        }
    }

    /// Circle radius.
    public double? CircleRadius
    {
        get
        {
            return GetProperty<double?>("circle-radius", default);
        }
        set
        {
            SetProperty("circle-radius", value);
        }
    }

    /// The stroke color of the circle.
    public Color CircleStrokeColor
    {
        get
        {
            return GetProperty<Color>("circle-stroke-color", default);
        }
        set
        {
            SetProperty("circle-stroke-color", value);
        }
    }

    /// The opacity of the circle's stroke.
    public double? CircleStrokeOpacity
    {
        get
        {
            return GetProperty<double?>("circle-stroke-opacity", default);
        }
        set
        {
            SetProperty("circle-stroke-opacity", value);
        }
    }

    /// The width of the circle's stroke. Strokes are placed outside of the `circle-radius`.
    public double? CircleStrokeWidth
    {
        get
        {
            return GetProperty<double?>("circle-stroke-width", default);
        }
        set
        {
            SetProperty("circle-stroke-width", value);
        }
    }
}

