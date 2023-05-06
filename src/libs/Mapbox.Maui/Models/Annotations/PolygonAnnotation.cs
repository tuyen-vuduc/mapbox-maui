namespace MapboxMaui.Annotations;

using GeoJSON.Text.Geometry;

public class PolygonAnnotation : Annotation<Polygon>
{
    public PolygonAnnotation(Polygon geometry, string id = null)
        : base(geometry, id)
    {
    }

    /// Sorts features in ascending order based on this value. Features with a higher sort key will appear above features with a lower sort key.
    public double? FillSortKey
    {
        get => GetProperty<double?>("fill-sort-key", default);
        set => SetProperty("fill-sort-key", value);
    }

    /// The color of the filled part of this layer. This color can be specified as `rgba` with an alpha component and the color's opacity will not affect the opacity of the 1px stroke, if it is used.
    public Color FillColor
    {
        get => GetProperty<Color>("fill-color", default);
        set => SetProperty("fill-color", value);
    }

    /// The opacity of the entire fill layer. In contrast to the `fill-color`, this value will also affect the 1px stroke around the fill, if the stroke is used.
    public double? FillOpacity
    {
        get => GetProperty<double>("fill-opacity", default);
        set => SetProperty("fill-opacity", value);
    }

    /// The outline color of the fill. Matches the value of `fill-color` if unspecified.
    public Color FillOutlineColor
    {
        get => GetProperty<Color>("fill-outline-color", default);
        set => SetProperty("fill-outline-color", value);
    }

    /// Name of image in sprite to use for drawing image fills. For seamless patterns, image width and height must be a factor of two (2, 4, 8, ..., 512). Note that zoom-dependent expressions will be evaluated only at integer zoom levels.
    public string FillPattern
    {
        get => GetProperty<string>("fill-pattern", default);
        set => SetProperty("fill-pattern", value);
    }
}
