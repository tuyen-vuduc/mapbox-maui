
using MapboxMapsObjC;
using MapboxMaui.ViewAnnotations;
using Microsoft.Maui.Platform;

namespace MapboxMaui;

partial class MapboxViewHandler : IViewAnnotationController
{
    public void AddViewAnnotation(ViewAnnotationOptions options, Microsoft.Maui.Controls.ContentView contentView = default)
    {
        var mapView = PlatformView.MapView;

        if (mapView == null) return;

        contentView = contentView ?? VirtualView.AnnotationView;

        if (contentView == null)
        {
            throw new InvalidOperationException("DataTemplate must be provided eiher via this method parameter or via DefaultViewAnnotationTemplate");
        }

        contentView.Parent = VirtualView as Element;
        contentView.BindingContext = options;

        var platformHandler = contentView.ToHandler(
            VirtualView.Handler.MauiContext
        );

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
