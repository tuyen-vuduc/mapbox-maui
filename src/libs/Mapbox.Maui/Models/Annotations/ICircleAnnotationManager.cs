namespace MapboxMaui.Annotations;

public interface ICircleAnnotationManager : IAnnotationManager<CircleAnnotation>
{
    CirclePitchAlignment? CirclePitchAlignment { get; set; }
    CirclePitchScale? CirclePitchScale { get; set; }
    double[] CircleTranslate { get; set; }
    CircleTranslateAnchor? CircleTranslateAnchor { get; set; }
}

public partial class CircleAnnotationManager
{
}
