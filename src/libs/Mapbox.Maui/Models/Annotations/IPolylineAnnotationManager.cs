namespace MapboxMaui.Annotations;

public interface IPolylineAnnotationManager : IAnnotationManager<PolylineAnnotation>
{
    LineCap? LineCap { get; set; }
    double? LineMiterLimit { get; set; }
    double? LineRoundLimit { get; set; }
    double[] LineDasharray { get; set; }
    double[] LineTranslate { get; set; }
    LineTranslateAnchor? LineTranslateAnchor { get; set; }
    double[] LineTrimOffset { get; set; }
}

public partial class PolylineAnnotationManager
{
}