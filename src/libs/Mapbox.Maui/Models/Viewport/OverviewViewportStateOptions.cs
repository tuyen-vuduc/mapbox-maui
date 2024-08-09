namespace MapboxMaui.Viewport;

/// <summary>
/// Configuration options that impact the [OverviewViewportState].
/// </summary>
public record OverviewViewportStateOptions
{
    /**
     * The geometry that the [OverviewViewportState] should use when calculating its camera.
     */
    public IGeometryObject Geometry { get; set; }
    /**
     * The amount of padding in pixels to add to the map when calculating its camera.
     *
     * Defaults to EdgeInsets(0.0, 0.0, 0.0, 0.0).
     */
    public Thickness Padding { get; set; }  = Thickness.Zero;
  /**
   * The amount of padding in pixels to add to the given [geometry].
   *
   * Note: This padding is not applied to the map but to the provided [geometry]. If you want to apply padding to the map use param [padding].
   *
   * Defaults to EdgeInsets(0.0, 0.0, 0.0, 0.0).
   */
  public Thickness GeometryPadding { get; set; }  = Thickness.Zero;
  /**
   * The bearing that [OverviewViewportState] should use when calculating its camera.
   *
   * Defaults to 0.
   */
  public double Bearing { get; set; }  = 0;
  /**
   * The pitch that [OverviewViewportState] should use when calculating its camera.
   *
   * Defaults to 0.
   */
  public double Pitch { get; set; }  = 0;
  /**
   * The maximum allowed zoom level when calculating the camera of [OverviewViewportState].
   *
   * Defaults to null. public That is { get; set; } ; there won't be any restriction on the maximum zoom level allowed.
   */
  public double? MaxZoom { get; set; }  = default;
  /**
   * The offset to the center of the given geometry relative to map center public in pixels { get; set; } ; when calculating the camera of [OverviewViewportState].
   *
   * Defaults to ScreenCoordinate(0.0, 0.0).
   */
  public ScreenPosition? Offset { get; set; }  = ScreenPosition.Zero;
  /**
   * The length of the animation performed in milliseconds by [OverviewViewportState] when it starts
   * updating the camera and anytime [OverviewViewportState.options] is set.
   *
   * @see [OverviewViewportState.options] for details.
   *
   * Defaults to [DEFAULT_STATE_ANIMATION_DURATION_MS] milliseconds
   */
  public long AnimationDurationMs { get; set; } = ViewportConstants.DEFAULT_STATE_ANIMATION_DURATION_MS;
}