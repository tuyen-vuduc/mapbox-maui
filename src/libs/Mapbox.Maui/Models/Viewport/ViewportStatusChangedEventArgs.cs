namespace MapboxMaui.Viewport;

public class ViewportStatusChangedEventArgs : EventArgs
{
    public ViewportStatus FromStatus { get; }
    public ViewportStatus ToStatus { get; }
    public ViewportStatusChangeReason Reason { get; }

    public ViewportStatusChangedEventArgs(
        ViewportStatus fromStatus,
        ViewportStatus toStatus,
        ViewportStatusChangeReason reason)
    {
        FromStatus = fromStatus;
        ToStatus = toStatus;
        Reason = reason;
    }
}

public record ViewportStatus
{
    /// The `idle` status indicates that ``ViewportManager`` is inactive.
    public bool Idle { get; init; }

    /// The `state(_:)` status indicates that ``ViewportManager`` is running the associated value `state`.
    public IViewportState State { get; init; }

    /// The `transition(_:toState:)` status indicates that ``ViewportManager`` is running `transition`
    /// and will start running `toState` upon success.
    public IViewportTransition Transition { get; init; }

    public static readonly ViewportStatus IdleInstance = new()
    {
        Idle = true,
    };

    public static ViewportStatus FromViewportState(
        IViewportState state)
        => new()
        {
            State = state,
        };

    public static ViewportStatus FromTransition(
        IViewportTransition transition,
        IViewportState toState)
        => new()
        {
            Transition = transition,
            State = toState,
        };
}

public enum ViewportStatusChangeReason
{
    IdleRequested,
    TransitionStarted,
    TransitionSucceeded,
    TransitionFailed,
    UserInteraction,
}