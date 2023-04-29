namespace MapboxMaui.Offline;

public record TileRegion
{
    /** The id of the tile region */
    public string Id { get; init; }

    /** The number of resources that are known to be required for this tile region. */
    public ulong RequiredResourceCount { get; init; }

    /**
     * The number of resources that have been fully downloaded and are ready for
     * offline access.
     *
     * The tile region is complete if `completedResourceCount` is equal to `requiredResourceCount`.
     */
    public ulong CompletedResourceCount { get; init; }

    /**
     * The cumulative size, in bytes, of all resources (inclusive of tiles) that have
     * been fully downloaded.
     */
    public ulong CompletedResourceSize { get; init; }

    /**
     * The earliest point in time when any of the region resources gets expired.
     *
     * Unitialized for incomplete tile regions or for complete tile regions with all immutable resources.
     */
    public DateTime? Expires { get; init; }
}