namespace MapboxMaui.Viewport;

public interface IViewportPlugin
{
    IViewportState GetCurrentOrNextState();
    IFollowPuckViewportState MakeFollowPuckViewportState(FollowPuckViewportStateOptions options);
    IOverviewViewportState MakeOverviewViewportState(OverviewViewportStateOptions options);
    void TransitionTo(IViewportState state, IViewportTransition transition = default, Action<bool> completion = default);
}
