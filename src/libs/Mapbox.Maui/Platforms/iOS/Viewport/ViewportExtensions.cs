using MapboxMapsObjC;
using X = MapboxMaui.Viewport;

namespace MapboxMaui;

public static class ViewportExtensions
{
    public static TMBFollowPuckViewportStateOptions ToNative(
        this X.FollowPuckViewportStateOptions options)
    {
        TMBFollowPuckViewportStateBearing bearing = options.Bearing.HasValue
            ? TMBFollowPuckViewportStateBearing.FromConstant((float)options.Bearing.Value)
            : TMBFollowPuckViewportStateBearing.HeadingInstance;
        return new TMBFollowPuckViewportStateOptions(
            bearing: bearing,
            padding: options.Padding?.ToNSValue(),
            pitch: options.Pitch,
            zoom: options.Zoom
            );
    }
    public static TMBOverviewViewportStateOptions ToNative(
        this X.OverviewViewportStateOptions options)
    {
        return new TMBOverviewViewportStateOptions(
            animationDuration: options.AnimationDurationMs,
            bearing: options.Bearing,
            geometry: options.Geometry.ToNative(),
            geometryPadding: options.GeometryPadding.ToNative(),
            maxZoom: options.MaxZoom,
            offset: options.Offset?.ToNSValue(),
            padding: options.Padding.ToNSValue(),
            pitch: options.Pitch);
    }

    public static X.IFollowPuckViewportState ToX(this TMBFollowPuckViewportState state)
        => new XFollowPuckViewPortState(state);
    public static X.IOverviewViewportState ToX(this TMBOverviewViewportState state)
        => new XOverviewViewportState(state);

    public static X.OverviewViewportStateOptions ToX(this TMBOverviewViewportStateOptions state)
        => new()
        {
            AnimationDurationMs = (long)state.AnimationDuration,
            Bearing = state.Bearing?.DoubleValue ?? 0,
            Geometry = state.Geometry?.ToX(),
            GeometryPadding = state.GeometryPadding.ToX(),
            MaxZoom = state.MaxZoom?.DoubleValue,
            Offset = state.Offset?.ToScreenPosition(),
            Padding = state.padding?.ToThickness() ?? Thickness.Zero,
            Pitch = state.Pitch?.DoubleValue ?? 0,
        };
    public static X.FollowPuckViewportStateOptions ToX(this TMBFollowPuckViewportStateOptions state)
        => new()
        {
            Bearing = state.Bearing.Heading == true
                ? null
                : state.Bearing.Bearing,
            Padding = state.Padding?.ToThickness(),
            Pitch = state.Pitch?.DoubleValue,
            Zoom = state.Zoom?.DoubleValue,
        };
}
