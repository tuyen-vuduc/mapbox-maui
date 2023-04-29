using System;

namespace MapboxMaui.Offline;

public record StylePackLoadProgress
{
    /** The number of resources that are ready for offline access. */
    public ulong CompletedResourceCount { get; init; }

    /** The cumulative size, in bytes, of all resources that are ready for offline access. */
    public ulong CompletedResourceSize { get; init; }

    /** The number of resources that have failed to download due to an error. */
    public ulong ErroredResourceCount { get; init; }

    /** The number of resources that are known to be required for this style package. */
    public ulong RequiredResourceCount;

    /** The number of resources that have been fully downloaded from the network. */
    public ulong LoadedResourceCount { get; init; }

    /**
     * The cumulative size, in bytes, of all resources that have been fully downloaded
     * from the network.
     */
    public ulong LoadedResourceSize { get; init; }
}