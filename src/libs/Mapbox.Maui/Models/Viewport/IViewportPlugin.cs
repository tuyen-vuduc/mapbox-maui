namespace MapboxMaui.Viewport;

public interface IViewportPlugin
{
    IFollowPuckViewportState MakeFollowPuckViewportState(FollowPuckViewportStateOptions options);
    IOverviewViewportState MakeOverviewViewportState(OverviewViewportStateOptions options);
}
