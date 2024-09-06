
using MapboxMapsObjC;
using MapboxMaui.ViewAnnotations;

namespace MapboxMaui;

partial class MapboxViewHandler : IViewAnnotationController
{
    public void AddViewAnnotation(ViewAnnotationOptions options, DataTemplate dataTemplate = null)
    {
        var mapView = PlatformView.MapView;

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

        mapView.ViewAnnotations().AddWithAnnotation(options.ToPlatform(platformHandler.PlatformView));
    }

    public void RemoveAllViewAnnotations()
    {
        var mapView = PlatformView.MapView;

        if (mapView == null) return;

        mapView.ViewAnnotations().RemoveAllViewAnnotations();
    }
}
