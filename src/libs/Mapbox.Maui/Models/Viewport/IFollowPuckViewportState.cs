namespace MapboxMaui.Viewport;

/**
 * The [ViewportState] that tracks the location puck's position.
 *
 * Use [ViewportPlugin.makeFollowPuckViewportState] to create instances of [FollowPuckViewportState].
 *
 * Note: [LocationComponentPlugin] should be enabled to use this viewport state, and Users are
 * responsible to create the viewport states and keep a reference to these states for
 * future operations.
 */
public interface IFollowPuckViewportState : IViewportState
{
    /**
     * Describes the configuration options of the state.
     */
    FollowPuckViewportStateOptions Options { get; set; }
}