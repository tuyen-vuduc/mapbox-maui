using Com.Mapbox.Maps.Plugins.Viewport;
using Com.Mapbox.Maps.Plugins.Viewport.Data;
using Com.Mapbox.Maps.Plugins.Viewport.State;
using Com.Mapbox.Maps.Plugins.Viewport.Transition;
using X = MapboxMaui.Viewport;

namespace MapboxMaui;

public static class ViewportExtensions
{
    public static X.ViewportStatusChangeReason ToX(this ViewportStatusChangeReason status)
    {
        if (status == ViewportStatusChangeReason.IdleRequested)
        {
            return X.ViewportStatusChangeReason.IdleRequested;
        }
        if (status == ViewportStatusChangeReason.TransitionFailed)
        {
            return X.ViewportStatusChangeReason.TransitionFailed;
        }
        if (status == ViewportStatusChangeReason.TransitionStarted)
        {
            return X.ViewportStatusChangeReason.TransitionStarted;
        }
        if (status == ViewportStatusChangeReason.TransitionSucceeded)
        {
            return X.ViewportStatusChangeReason.TransitionSucceeded;
        }
        if (status == ViewportStatusChangeReason.UserInteraction)
        {
            return X.ViewportStatusChangeReason.UserInteraction;
        }
        return X.ViewportStatusChangeReason.IdleRequested;
    }

    public static X.ViewportStatus ToX(this ViewportStatus status)
    {
        if (status == ViewportStatus.Idle.Instance)
        {
            return X.ViewportStatus.IdleInstance;
        }

        if (status is ViewportStatus.State state)
        {
            return X.ViewportStatus.FromViewportState(
                state.GetState().ToX()
            );
        }

        if (status is ViewportStatus.Transition transition)
        {
            return X.ViewportStatus.FromTransition(
                transition.GetTransition().ToX(),
                transition.ToState.ToX()
            );
        }
        return null;
    }
    public static X.IViewportTransition ToX(this IViewportTransition transition)
        => new X.XViewportTransition(transition);
    public static IViewportTransition ToNative(this X.IViewportTransition transition)
        => new X.PViewportTransition(transition);

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

    public static X.IViewportState GetCurrentOrNextState(this ViewportStatus status)
    {
        if (status is ViewportStatus.State state)
        {
            return state.GetState().ToX();
        }

        if (status is ViewportStatus.Transition transition)
        {
            return transition.ToState.ToX();
        }

        return null;
    }

    public static X.IFollowPuckViewportState ToX(this IFollowPuckViewportState state)
        => new XFollowPuckViewPortState(state);
    public static X.IOverviewViewportState ToX(this IOverviewViewportState state)
        => new XOverviewViewportState(state);

    public static IViewportState ToNative(this X.IViewportState state)
    {
        if (state is not XViewportState wrapper)
        {
            throw new NotSupportedException("Invalid instance of IViewportState");
        }
        return wrapper.State;
    }

    public static X.IViewportState ToX(this IViewportState state)
        => state switch
        {
            IFollowPuckViewportState followPuckViewportState => followPuckViewportState.ToX(),
            IOverviewViewportState overviewViewportState => overviewViewportState.ToX(),
            _ => throw new NotSupportedException("Invalid ViewportState"),
        };

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
