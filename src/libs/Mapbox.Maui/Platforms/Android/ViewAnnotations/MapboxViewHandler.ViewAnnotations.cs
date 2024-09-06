
using MapboxMaui.ViewAnnotations;

namespace MapboxMaui;

partial class MapboxViewHandler : IViewAnnotationController
{
    public void AddViewAnnotation(ViewAnnotationOptions options, DataTemplate dataTemplate = null)
    {
        var mapView = mapboxFragment?.MapView;

        if (mapView == null) return;

        dataTemplate = dataTemplate ?? VirtualView.DefaultViewAnnotationTemplate;

        if (dataTemplate == null)
        {
            throw new InvalidOperationException("DataTemplate must be provided eiher via this method parameter or via DefaultViewAnnotationTemplate");
        }

        var xview = (View)dataTemplate.CreateContent();
        xview.BindingContext = VirtualView is View xxview
            ? xxview.BindingContext
            : options;

        var platformHandler = TemplateHelpers.GetHandler(xview, VirtualView.Handler.MauiContext);

        mapView.ViewAnnotationManager.AddViewAnnotation(platformHandler.PlatformView, options.ToPlatform());
    }

    public void RemoveAllViewAnnotations()
    {
        var mapView = mapboxFragment?.MapView;

        if (mapView == null) return;

        mapView.ViewAnnotationManager.RemoveAllViewAnnotations();
    }
}
