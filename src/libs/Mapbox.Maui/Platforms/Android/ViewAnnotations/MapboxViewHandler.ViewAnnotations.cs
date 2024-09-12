
using Android.Content;
using Android.Views;
using MapboxMaui.ViewAnnotations;
using Microsoft.Maui.Platform;

namespace MapboxMaui;

partial class MapboxViewHandler : IViewAnnotationController
{
    public void AddViewAnnotation(ViewAnnotationOptions options, ContentView contentView = default)
    {
        var mapView = mapboxFragment?.MapView;

        if (mapView == null) return;

        contentView = contentView ?? VirtualView.AnnotationView;

        if (contentView == null)
        {
            throw new InvalidOperationException("DataTemplate must be provided eiher via this method parameter or via DefaultViewAnnotationTemplate");
        }

        contentView.Parent = VirtualView as Element;
        contentView.BindingContext = options;

        var handler = contentView.ToHandler(MauiContext);

        var viewGroup = new ContentViewGroup(Context)
        {
            LayoutParameters = new ViewGroup.LayoutParams(
                ViewGroup.LayoutParams.WrapContent,
                ViewGroup.LayoutParams.WrapContent),
            CrossPlatformLayout = handler.VirtualView as ICrossPlatformLayout,
        };

        mapView.ViewAnnotationManager.AddViewAnnotation(
            viewGroup,
            options.ToPlatform());
    }

    public void RemoveAllViewAnnotations()
    {
        var mapView = mapboxFragment?.MapView;

        if (mapView == null) return;

        mapView.ViewAnnotationManager.RemoveAllViewAnnotations();
    }

    class ViewAnnotationView : ViewGroup
    {
        public ViewAnnotationView(Context context)
            : base(context)
        {
            
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            if (ChildCount == 0) return;

            var view = this.GetChildAt(0);
            view.Layout(l, t, r, b);
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
        }
    }
}
