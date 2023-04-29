namespace MapboxMaui.Annotations;

public interface IPolygonAnnotationManager : IAnnotationManager<PolygonAnnotation>
{
    /// Whether or not the fill should be antialiased.
    bool? FillAntialias { get; set; }

    /// The geometry's offset. Values are [x, y] where negatives indicate left and up, respectively.
    double[] FillTranslate { get; set; }

    /// Controls the frame of reference for `fill-translate`.
    FillTranslateAnchor? FillTranslateAnchor { get; set; }
}

public partial class PolygonAnnotationManager
{
}