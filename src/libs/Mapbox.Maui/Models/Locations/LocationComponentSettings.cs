using Microsoft.VisualBasic;

namespace MapboxMaui.Locations;

/**
 * Shows a location puck on the map.
 */
public record LocationComponentSettings(
  /**
   * Whether the user location is visible on the map.
   */
  bool Enabled,
  /**
   * Whether the location puck is pulsing on the map. Works for 2D location puck only.
   */
  bool PulsingEnabled,
  /**
   * The color of the pulsing circle. Works for 2D location puck only.
   */
  int PulsingColor,
  /**
   * The maximum radius of the pulsing circle. Works for 2D location puck only. Note: Setting
   * [pulsingMaxRadius] to LocationComponentConstants.PULSING_MAX_RADIUS_FOLLOW_ACCURACY will set the
   * pulsing circle's maximum radius to follow location accuracy circle. This property is specified in
   * pixels.
   */
  float PulsingMaxRadius,
  /**
   * Whether show accuracy ring with location puck. Works for 2D location puck only.
   */
  bool ShowAccuracyRing,
  /**
   * The color of the accuracy ring. Works for 2D location puck only.
   */
  int AccuracyRingColor,
  /**
   * The color of the accuracy ring border. Works for 2D location puck only.
   */
  int AccuracyRingBorderColor,
  /**
   * Sets the id of the layer that's added above to when placing the component on the map.
   */
  string LayerAbove,
  /**
   * Sets the id of the layer that's added below to when placing the component on the map.
   */
  string LayerBelow,
  /**
   * Whether the puck rotates to track the bearing source.
   */
  bool PuckBearingEnabled,
  /**
   * The enum controls how the puck is oriented
   */
  PuckBearing puckBearing,
  /**
   * The slot this layer is assigned to. If specified, and a slot with that name exists, it will be
   * placed at that position in the layer order.
   */
  string Slot,
  /**
   * Defines what the customised look of the location puck. Note that direct changes to the puck
   * variables won't have any effect, a new puck needs to be set every time.
   */
  ILocationPuck LocationPuck
);