namespace MapboxMaui;

using XRenderedQueryOptions = Query.RenderedQueryOptions;
using Com.Mapbox.Maps;

public static class RenderedQueryOptionsExtensions
{
    public static RenderedQueryOptions ToPlatform(this XRenderedQueryOptions src)
        => new (src.LayerIds, src.Filter?.Wrap());
}

