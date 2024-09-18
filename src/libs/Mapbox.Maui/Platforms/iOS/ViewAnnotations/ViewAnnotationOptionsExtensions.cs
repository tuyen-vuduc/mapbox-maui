using MapboxCoreMaps;
using MapboxMapsObjC;
using UIKit;

namespace MapboxMaui.ViewAnnotations;

static class ViewAnnotationOptionsExtensions
{
    public static TMBViewAnnotation ToPlatform(
        this ViewAnnotationOptions options,
        UIView view)
    {
        var anchorConfig = new MBMViewAnnotationAnchorConfig(
            options.Anchor.Value.ToPlatform(),
            options.OffsetX ?? 0,
            options.OffsetY ?? 0
        );

        var result = TMBViewAnnotation.FromCoordinate(
            (options.Geometry as GeoJSON.Text.Geometry.Point).Coordinates.ToCoords(),
            view
        );

        return result;
    }

    public static MBMViewAnnotationAnchor ToPlatform(this ViewAnnotationAnchor value)
        => value switch
        {
            ViewAnnotationAnchor.Top => MBMViewAnnotationAnchor.Top,
            ViewAnnotationAnchor.Left => MBMViewAnnotationAnchor.Left,
            ViewAnnotationAnchor.Bottom => MBMViewAnnotationAnchor.Bottom,
            ViewAnnotationAnchor.Right => MBMViewAnnotationAnchor.Right,
            ViewAnnotationAnchor.TopLeft => MBMViewAnnotationAnchor.TopLeft,
            ViewAnnotationAnchor.BottomRight => MBMViewAnnotationAnchor.BottomRight,
            ViewAnnotationAnchor.TopRight => MBMViewAnnotationAnchor.TopRight,
            ViewAnnotationAnchor.BottomLeft => MBMViewAnnotationAnchor.BottomLeft,
            ViewAnnotationAnchor.Center => MBMViewAnnotationAnchor.Center,
            _ => throw new NotImplementedException(),
        };
}
