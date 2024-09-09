
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
        xview.Parent = VirtualView as Element;
        xview.BindingContext = options;
        xview.HeightRequest = options.Height ?? xview.HeightRequest;
        xview.WidthRequest = options.Width ?? xview.WidthRequest;

        var platformHandler = TemplateHelpers.GetHandler(
            xview,
            VirtualView.Handler.MauiContext);

        mapView
            .ViewAnnotations()
            .AddWithAnnotation(
                options.ToPlatform(platformHandler.PlatformView)
            );
    }

    public void RemoveAllViewAnnotations()
    {
        var mapView = PlatformView.MapView;

        if (mapView == null) return;

        mapView.ViewAnnotations().RemoveAllViewAnnotations();
    }
}
