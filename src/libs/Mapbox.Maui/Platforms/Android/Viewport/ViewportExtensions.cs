using Com.Mapbox.Maps.Plugins.Viewport.Data;
using Com.Mapbox.Maps.Plugins.Viewport.State;
using X = MapboxMaui.Viewport;

namespace MapboxMaui;

public static class ViewportExtensions
{
    public static FollowPuckViewportStateOptions ToNative(
        this X.FollowPuckViewportStateOptions options)
    {
        FollowPuckViewportStateBearing bearing = options.Bearing.HasValue
            ? new FollowPuckViewportStateBearing.Constant(options.Bearing.Value)
            : FollowPuckViewportStateBearing.SyncWithLocationPuck.Instance;
        var builder = new FollowPuckViewportStateOptions.Builder()
            .Bearing(bearing)
            .Padding(options.Padding?.ToNative())
            .Pitch(options.Pitch?.ToNative())
            .Zoom(options.Zoom?.ToNative());
        return builder.Build();
    }
    public static OverviewViewportStateOptions ToNative(
        this X.OverviewViewportStateOptions options)
    {
        var builder = new OverviewViewportStateOptions.Builder()
            .AnimationDurationMs(options.AnimationDurationMs)
            .Bearing(options.Bearing.ToNative())
            .Geometry(options.Geometry.ToNative())
            .GeometryPadding(options.GeometryPadding.ToNative())
            .MaxZoom(options.MaxZoom?.ToNative())
            .Offset(options.Offset?.ToScreenCoordinate())
            .Padding(options.Padding.ToNative())
            .Pitch(options.Pitch.ToNative());
        return builder.Build();
    }

    public static X.IFollowPuckViewportState ToX(this IFollowPuckViewportState state)
        => new XFollowPuckViewPortState(state);
    public static X.IOverviewViewportState ToX(this IOverviewViewportState state)
        => new XOverviewViewportState(state);

    public static X.OverviewViewportStateOptions ToX(this OverviewViewportStateOptions state)
        => new()
        {
            AnimationDurationMs = state.AnimationDurationMs,
            Bearing = state.Bearing?.DoubleValue() ?? 0,
            Geometry = state.Geometry?.ToX(),
            GeometryPadding = state.GeometryPadding.ToX(),
            MaxZoom = state.MaxZoom?.DoubleValue(),
            Offset = state.Offset?.ToX(),
            Padding = state.Padding?.ToX() ?? Thickness.Zero,
            Pitch = state.Pitch?.DoubleValue() ?? 0,
        };
    public static X.FollowPuckViewportStateOptions ToX(this FollowPuckViewportStateOptions state)
        => new()
        {
            Bearing = state.Bearing is FollowPuckViewportStateBearing.Constant constValue
                ? constValue.Bearing
                : null,
            Padding = state.Padding?.ToX(),
            Pitch = state.Pitch?.DoubleValue(),
            Zoom = state.Zoom?.DoubleValue(),
        };
}
