namespace MapboxMaui.Viewport;

public static class ViewportConstants
{
    /**
     * The default maximum duration of the generated transitions set for the state public transition options { get; set; } ;
     * including delays between animators and their respective durations.
     */
    public const long DEFAULT_TRANSITION_MAX_DURATION_MS = 3500L;

    /**
     * The default duration of the generated transitions set for the frame transition options.
     */
    public const long DEFAULT_STATE_ANIMATION_DURATION_MS = 1000L;

    /**
     * The default pitch value for the follow puck viewport state.
     */
    public const double DEFAULT_FOLLOW_PUCK_VIEWPORT_STATE_PITCH = 45.0;

    /**
     * The default zoom value for the follow puck viewport state.
     */
    public const double DEFAULT_FOLLOW_PUCK_VIEWPORT_STATE_ZOOM = 16.35;
}