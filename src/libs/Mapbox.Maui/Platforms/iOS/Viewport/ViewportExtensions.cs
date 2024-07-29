using MapboxMapsObjC;
using X = MapboxMaui.Viewport;

namespace MapboxMaui;

public static class ViewportExtensions
{
    public static X.ViewportStatusChangeReason ToX(this TMBViewportStatusChangeReason status)
    {
        if (status == TMBViewportStatusChangeReason.IdleRequested)
        {
            return X.ViewportStatusChangeReason.IdleRequested;
        }
        if (status == TMBViewportStatusChangeReason.TransitionFailed)
        {
            return X.ViewportStatusChangeReason.TransitionFailed;
        }
        if (status == TMBViewportStatusChangeReason.TransitionStarted)
        {
            return X.ViewportStatusChangeReason.TransitionStarted;
        }
        if (status == TMBViewportStatusChangeReason.TransitionSucceeded)
        {
            return X.ViewportStatusChangeReason.TransitionSucceeded;
        }
        if (status == TMBViewportStatusChangeReason.UserInteraction)
        {
            return X.ViewportStatusChangeReason.UserInteraction;
        }
        return X.ViewportStatusChangeReason.IdleRequested;
    }

    public static X.ViewportStatus ToX(this TMBViewportStatus status)
    {
        if (status.Transition is not null)
        {
            return X.ViewportStatus.FromTransition(
                status.Transition.ToX(),
                status.State.ToX());
        }

        if (status.State is not null)
        {
            return X.ViewportStatus.FromViewportState(
                status.State.ToX()
            );
        }

        return X.ViewportStatus.IdleInstance;
    }
    public static X.IViewportState GetCurrentOrNextState(this TMBViewportStatus status)
    {
        if (status.Transition is not null)
        {
            return status.State.ToX();
        }

        if (status.State is not null)
        {
            return status.State.ToX();
        }

        return null;
    }
    public static X.IViewportTransition ToX(this ITMBViewportTransition transition)
        => new X.XViewportTransition(transition);
    public static ITMBViewportTransition ToNative(this X.IViewportTransition transition)
        => new X.XTMBViewportTransition(transition);

    public static ITMBViewportState ToNative(this X.IViewportState state)
    {
        if (state is not XViewportState wrapper)
        {
            throw new NotSupportedException("Invalid instance of IViewportState");
        }
        return wrapper.State;
    }

    public static TMBFollowPuckViewportStateOptions ToNative(
        this X.FollowPuckViewportStateOptions options)
    {
        TMBFollowPuckViewportStateBearing bearing = options.Bearing.HasValue
            ? TMBFollowPuckViewportStateBearing.FromConstant((float)options.Bearing.Value)
            : TMBFollowPuckViewportStateBearing.CourseInstance;
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

    public static X.IViewportState ToX(this ITMBViewportState state)
        => state switch
        {
            TMBFollowPuckViewportState followPuckViewportState => followPuckViewportState.ToX(),
            TMBOverviewViewportState overviewViewportState => overviewViewportState.ToX(),
            _ => throw new NotSupportedException("Invalid ViewportState"),
        };
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
