namespace MapboxMaui.Locations;

public interface ILocationPuck { }

public record LocationPuck2D(
  /**
   * Name of image in sprite to use as the top of the location indicator.
   */
  ResolvedImage TopImage = null,
  /**
   * Name of image in sprite to use as the middle of the location indicator.
   */
  ResolvedImage BearingImage = null,
  /**
   * Name of image in sprite to use as the background of the location indicator.
   */
  ResolvedImage ShadowImage = null,
  /**
   * The scale expression of the images. If defined, it will be applied to all the three images.
   */
  string ScaleExpression = null,
  /**
   * The opacity of the entire location puck
   */
  float Opacity = 1f
) : ILocationPuck
{ }

/**
 * Definition of a location_puck_3_d.
 */
public record LocationPuck3D(
  /**
   * An URL for the model file in gltf format.
   */
  string ModelUri,
  /**
   * The position of the model.
   */
  float[] Position = default,
  /**
   * The opacity of the model.
   */
  float ModelOpacity = 1f,
  /**
   * The scale of the model.
   */
  float[] ModelScale = default,
  /**
   * The scale expression of the model, which will overwrite the default scale expression that keeps the model size constant during zoom.
   */
  string ModelScaleExpression = null,
  /**
   * The translation of the model [lon, lat, z]
   */
  float[] ModelTranslation = default,
  /**
   * The rotation of the model.
   */
  float[] ModelRotation = default,
  /**
   * Enable/Disable shadow casting for the 3D location puck.
   */
  bool ModelCastShadows = true,
  /**
   * Enable/Disable shadow receiving for the 3D location puck.
   */
  bool ModelReceiveShadows = true,
  /**
   * Defines scaling mode. Only applies to location-indicator type layers.
   */
  ModelScaleMode modelScaleMode = ModelScaleMode.Viewport,
  /**
   * Strength of the emission. There is no emission for value 0. For value 1.0, only emissive component (no shading) is displayed and values above 1.0 produce light contribution to surrounding area, for some of the parts (e.g. doors).
   */
  float modelEmissiveStrength = 1f,
  /**
   * Strength of the emission as Expression string, note that when [modelEmissiveStrengthExpression] is specified, it will overwrite the [modelEmissiveStrength] property. There is no emission for value 0. For value 1.0, only emissive component (no shading) is displayed and values above 1.0 produce light contribution to surrounding area, for some of the parts (e.g. doors).
   */
  string modelEmissiveStrengthExpression = default
) : ILocationPuck
{
    public float[] Position { get; init; } = Position ?? [0, 0];
    public float[] ModelScale { get; init; } = ModelScale ?? [1, 1, 1];
    public float[] ModelTranslation { get; init; } = ModelTranslation ?? [0, 0, 0];
    public float[] ModelRotation { get; init; } = ModelRotation ?? [0, 0, 90];
}

/**
 * Defines scaling mode. Only applies to location-indicator type layers.
 *
 * @param value String value of this property
 */
public enum ModelScaleMode
{
    /**
     * Model is scaled so that it's always the same size relative to other map features. The property model-scale specifies how many meters each unit in the model file should cover.
     */
    Map,
    /**
     * Model is scaled so that it's always the same size on the screen. The property model-scale specifies how many pixels each unit in model file should cover.
     */
    Viewport,
}