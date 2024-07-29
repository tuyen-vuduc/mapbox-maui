using System;
namespace MapboxMaui.Viewport;

public record ViewportOptions
{
    /// Indicates whether the ``ViewportManager`` should idle when the ``MapView``
    /// receives pan touch input.
    ///
    /// Set this property to `false` to enable building custom ``ViewportState``s that
    /// can work simultaneously with certain types of gestures.
    ///
    /// Defaults to `true`.
    public bool TransitionsToIdleUponUserInteraction { get; set; } = true;
}

