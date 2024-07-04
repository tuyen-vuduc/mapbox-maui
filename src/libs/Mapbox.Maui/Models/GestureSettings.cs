namespace MapboxMaui;

public record struct GestureSettings
{
    public GestureSettings()
    {
    }

    /// <summary>
    /// Whether the rotate gesture is enabled.
    /// </summary>
    public bool RotateEnabled { get; set; } = true;
    /// <summary>
    /// Whether the pinch to zoom gesture is enabled.
    ///
    /// iOS: PinchZoomEnabled
    /// </summary>
    public bool PinchToZoomEnabled { get; set; } = true;
    /// <summary>
    /// Whether the single-touch scroll gesture is enabled.
    /// </summary>
    public bool ScrollEnabled { get; set; } = true;
    /// <summary>
    /// Whether rotation is enabled for the pinch to zoom gesture.
    ///
    /// iOS: SimultaneousRotateAndPinchZoomEnabled
    /// </summary>
    public bool SimultaneousRotateAndPinchToZoomEnabled { get; set; } = true;
    /// <summary>
    /// Whether the pitch gesture is enabled.
    /// </summary>
    public bool PitchEnabled { get; set; } = true;
    /// <summary>
    /// Configures the directions in which the map is allowed to move during a scroll gesture.
    ///
    /// iOS: PanMode
    /// </summary>
    public PanMode ScrollMode { get; set; } = PanMode.Both;
    /// <summary>
    /// Whether double tapping the map with one touch results in a zoom-in animation.
    /// </summary>
    public bool DoubleTapToZoomInEnabled { get; set; } = true;
    /// <summary>
    /// Whether single tapping the map with two touches results in a zoom-out animation.
    /// </summary>
    public bool DoubleTouchToZoomOutEnabled { get; set; } = true;
    /// <summary>
    /// Whether the quick zoom gesture is enabled.
    /// </summary>
    public bool QuickZoomEnabled { get; set; } = true;
    /// <summary>
    /// By default, gestures rotate and zoom around the center of the gesture. Set this property to
    /// rotate and zoom around a fixed point instead.
    /// </summary>
    public ScreenPosition? FocalPoint { get; set; }
    /// <summary>
    /// Android only.
    /// Whether a deceleration animation following a pinch-to-zoom gesture is enabled. True by default.
    /// </summary>
    public bool PinchToZoomDecelerationEnabled { get; set; } = true;
    /// <summary>
    /// Android only.
    /// Whether a deceleration animation following a rotate gesture is enabled. True by default.
    /// </summary>
    public bool RotateDecelerationEnabled { get; set; } = true;
    /// <summary>
    /// Android only.
    /// Whether a deceleration animation following a scroll gesture is enabled. True by default.
    /// </summary>
    public bool ScrollDecelerationEnabled { get; set; } = true;
    /// <summary>
    /// Android only.
    /// 
    /// Whether rotate threshold increases when pinching to zoom. true by default.
    /// </summary>
    public bool IncreaseRotateThresholdWhenPinchingToZoom { get; set; } = true;
    /// <summary>
    /// Android only.
    /// Whether pinch to zoom threshold increases when rotating. true by default.
    /// </summary>
    public bool IncreasePinchToZoomThresholdWhenRotating { get; set; } = true;
    /// <summary>
    /// The amount by which the zoom level increases or decreases during a double-tap-to-zoom-in or
    /// double-touch-to-zoom-out gesture. 1.0 by default. Must be positive.
    /// </summary>
    public float ZoomAnimationAmount { get; set; } = 1.0f;
    /// <summary>
    /// Whether pan is enabled for the pinch gesture.
    ///
    /// iOS: PanEnabled
    /// </summary>
    public bool PinchScrollEnabled { get; set; } = true;
}
public enum PanMode
{
    Horizontal = 0x0001,
    Vertical = 0x0010,
    Both = 0x0011,
}