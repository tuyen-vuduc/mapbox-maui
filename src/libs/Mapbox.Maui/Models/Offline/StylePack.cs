namespace MapboxMaui.Offline;

public record StylePack
{
    /** The style associated with the style package. */
    public string StyleUri { get; init; }

    /**
     * The glyphs rasterization mode of the style package.
     *
     * It defines which glyphs will be loaded from the server.
     */
    public GlyphsRasterizationMode? GlyphsRasterizationMode { get; init; }

    /** The number of resources that are known to be required for this style package. */
    public ulong RequiredResourceCount { get; init; }

    /**
     * The number of resources that have been fully downloaded and are ready for
     * offline access.
     */
    public ulong CompletedResourceCount { get; init; }

    /**
     * The cumulative size, in bytes, of all resources that have
     * been fully downloaded.
     */
    public ulong CompletedResourceSize { get; init; }

    /**
     * The earliest point in time when any of the style package resources gets expired.
     *
     * Unitialized for incomplete style packages or for complete style packages with all immutable resources.
     */
    public DateTime? Expires { get; init; }
}

