namespace MapboxMaui.Styles;

public class Light : BaseKVContainer
{
    /// Whether extruded geometries are lit relative to the map or viewport.
    public Anchor Anchor
    {
        get => GetProperty<Anchor>(LightKey.anchor, default);
        set => SetProperty(LightKey.anchor, value);
    }

    /// Color tint for lighting extruded geometries.
    public Color Color
    {
        get => GetProperty<Color>(LightKey.color, default);
        set => SetProperty(LightKey.color, value);
    }

    /// Transition property for `color`
    public StyleTransition ColorTransition
    {
        get => GetProperty<StyleTransition>(LightKey.colorTransition, default);
        set => SetProperty(LightKey.colorTransition, value);
    }

    /// Intensity of lighting (on a scale from 0 to 1). Higher numbers will present as more extreme contrast.
    public double Intensity
    {
        get => GetProperty<double>(LightKey.intensity, default);
        set => SetProperty(LightKey.intensity, value);
    }

    /// Transition property for `intensity`
    public StyleTransition IntensityTransition
    {
        get => GetProperty<StyleTransition>(LightKey.intensityTransition, default);
        set => SetProperty(LightKey.intensityTransition, value);
    }

    /// Position of the light source relative to lit (extruded) geometries, in [r radial coordinate, a azimuthal angle, p polar angle] where r indicates the distance from the center of the base of an object to its light, a indicates the position of the light relative to 0 degree (0 degree when `light.anchor` is set to `viewport` corresponds to the top of the viewport, or 0 degree when `light.anchor` is set to `map` corresponds to due north, and degrees proceed clockwise), and p indicates the height of the light (from 0 degree, directly above, to 180 degree, directly below).
    public double[] Position
    {
        get => GetProperty <double[]> (LightKey.position, default);
        set => SetProperty <double[]> (LightKey.position, value);
    }

    /// Transition property for `position`
    public StyleTransition PositionTransition
    {
        get => GetProperty<StyleTransition>(LightKey.positionTransition, default);
        set => SetProperty(LightKey.positionTransition, value);
    }

    public static class LightKey
    {
        public const string anchor = "anchor";
        public const string color = "color";
        public const string colorTransition = "color-transition";
        public const string intensity = "intensity";
        public const string intensityTransition = "intensity-transition";
        public const string position = "position";
        public const string positionTransition = "position-transition";
    }
}

