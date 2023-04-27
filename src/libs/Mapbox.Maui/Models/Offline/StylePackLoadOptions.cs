using System;

namespace Mapbox.Maui.Offline;

public record StylePackLoadOptions
{
    public GlyphsRasterizationMode? Mode { get; init; }
    public IReadOnlyDictionary<string, object> Metadata { get; init; }
    public bool AcceptsExpired { get; init; }
}

