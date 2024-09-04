namespace MapboxMaui.Styles;

/// Marks the position of a slot.
///
/// - SeeAlso: [Mapbox Style Specification](https://www.mapbox.com/mapbox-gl-style-spec/#layers-slot)
public class SlotLayer : MapboxLayer
{
    public SlotLayer(string id)
        : base(id)
    {
        Type = LayerType.Slot;
        Visibility = new PropertyValue<Visibility>(MapboxMaui.Visibility.Visible);
    }

    public static class PaintCodingKeys {

    }

    public static class LayoutCodingKeys {

    }
}