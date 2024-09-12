namespace MapboxMaui.ViewAnnotations;

public interface IViewAnnotationController
{
    public void AddViewAnnotation(ViewAnnotationOptions options, ContentView contentView = default);
    public void RemoveAllViewAnnotations();
}