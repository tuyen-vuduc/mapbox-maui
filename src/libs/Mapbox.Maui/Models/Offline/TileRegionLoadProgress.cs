using System;

namespace MapboxMaui.Offline;

public record TileRegionLoadProgress
{
    /** The number of resources that are ready for offline access. */
    public ulong CompletedResourceCount { get; init; }

    /**
     * The cumulative size, in bytes, of all resources (inclusive of tiles) that
     * are ready for offline access.
     */
    public ulong CompletedResourceSize { get; init; }

    /** The number of resources that have failed to download due to an error. */
    public ulong ErroredResourceCount { get; init; }

    /** The number of resources that are known to be required for this tile region. */
    public ulong RequiredResourceCount { get; init; }

    /**
     * The number of resources that are ready for offline use and that (at least partially)
     * have been downloaded from the network.
     */
    public ulong LoadedResourceCount { get; init; }

    /**
     * The cumulative size, in bytes, of all resources (inclusive of tiles) that have
     * been downloaded from the network.
     */
    public ulong LoadedResourceSize { get; init; }
}