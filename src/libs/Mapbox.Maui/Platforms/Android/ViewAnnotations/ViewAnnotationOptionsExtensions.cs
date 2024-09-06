using Com.Mapbox.Maps;
using Com.Mapbox.Maps.Viewannotation;

namespace MapboxMaui.ViewAnnotations;

static class ViewAnnotationOptionsExtensions
{
    public static Com.Mapbox.Maps.ViewAnnotationOptions ToPlatform(this ViewAnnotationOptions options)
    {
        var variableAnchors = options.Anchor is null
            ? null
            : new List<ViewAnnotationAnchorConfig>
            {
                new ViewAnnotationAnchorConfig.Builder()
                    .Anchor(options.Anchor.Value.ToPlatform())
                    .OffsetX(options.OffsetX ?? 0)
                    .OffsetY(options.OffsetY ?? 0)
                    .Build(),
            };

        var builder = new Com.Mapbox.Maps.ViewAnnotationOptions.Builder()
            .AllowOverlap(options.AllowOverlap?.ToPlatform())
            .AllowOverlapWithPuck(options.AllowOverlap?.ToPlatform())
            //.AnnotatedFeature
            .Height(options.Height?.ToPlatform())
            .IgnoreCameraPadding(options.IgnoreCameraPadding?.ToPlatform())
            .Selected(options.Selected?.ToPlatform())
            .VariableAnchors(variableAnchors)
            .Visible(options.Visible?.ToPlatform())
            .Width(options.Width?.ToPlatform());

        ViewAnnotationOptionsKtxKt.Geometry(builder, options.Geometry.ToPlatform());

        return builder.Build();
    }

    public static Com.Mapbox.Maps.ViewAnnotationAnchor ToPlatform(this ViewAnnotationAnchor value)
        => value switch
        {
            ViewAnnotationAnchor.Top => Com.Mapbox.Maps.ViewAnnotationAnchor.Top,
            ViewAnnotationAnchor.Left => Com.Mapbox.Maps.ViewAnnotationAnchor.Left,
            ViewAnnotationAnchor.Bottom => Com.Mapbox.Maps.ViewAnnotationAnchor.Bottom,
            ViewAnnotationAnchor.Right => Com.Mapbox.Maps.ViewAnnotationAnchor.Right,
            ViewAnnotationAnchor.TopLeft => Com.Mapbox.Maps.ViewAnnotationAnchor.TopLeft,
            ViewAnnotationAnchor.BottomRight => Com.Mapbox.Maps.ViewAnnotationAnchor.BottomRight,
            ViewAnnotationAnchor.TopRight => Com.Mapbox.Maps.ViewAnnotationAnchor.TopRight,
            ViewAnnotationAnchor.BottomLeft => Com.Mapbox.Maps.ViewAnnotationAnchor.BottomLeft,
            ViewAnnotationAnchor.Center => Com.Mapbox.Maps.ViewAnnotationAnchor.Center,
            _ => throw new NotImplementedException(),
        };
}
