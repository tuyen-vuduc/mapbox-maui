namespace MapboxMaui.Viewport;

/**
 * Configuration options that impact the [FollowPuckViewportState].
 *
 * Each of the [CameraOptions] related properties is optional, so that the state can be configured
 * to only modify certain aspects of the camera if desired. This can be used, to achieve effects like
 * allowing zoom gestures to work simultaneously with [FollowPuckViewportState].
 *
 * @see [ViewportOptions.transitionsToIdleUponUserInteraction]
 */
public class FollowPuckViewportStateOptions
{
    /**
   * The value to use for setting [CameraOptions.padding]. If null, padding will not be modified by
   * the [FollowPuckViewportState].
   *
   * Defaults to 0 padding.
   */
    public Thickness? Padding { get; set; } = default(Thickness);
    /**
     * The value to use for setting [CameraOptions.zoom]. If null, zoom will not be modified by
     * the [FollowPuckViewportState].
     *
     * Defaults to [DEFAULT_FOLLOW_PUCK_VIEWPORT_STATE_ZOOM].
     */
    public double? Zoom { get; set; } = ViewportConstants.DEFAULT_FOLLOW_PUCK_VIEWPORT_STATE_ZOOM;
    /**
     * Indicates how to obtain the value to use for [CameraOptions.bearing] when setting the camera.
     * If set to null, bearing will not be modified by the [FollowPuckViewportState].
     *
     * Defaults to [FollowPuckViewportStateBearing.SyncWithLocationPuck]
     */
    public double? Bearing { get; set; }
    /**
     * The value to use for setting [CameraOptions.pitch]. If null, pitch will not be modified by
     * the [FollowPuckViewportState].
     *
     * Defaults to [DEFAULT_FOLLOW_PUCK_VIEWPORT_STATE_PITCH] degrees.
     */
    public double? Pitch { get; set; } = ViewportConstants.DEFAULT_FOLLOW_PUCK_VIEWPORT_STATE_PITCH;
}