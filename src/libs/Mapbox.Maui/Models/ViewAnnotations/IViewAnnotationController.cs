namespace MapboxMaui.ViewAnnotations;

public interface IViewAnnotationController
{
    public void AddViewAnnotation(ViewAnnotationOptions options, DataTemplate dataTemplate = default);
    public void RemoveAllViewAnnotations();
}