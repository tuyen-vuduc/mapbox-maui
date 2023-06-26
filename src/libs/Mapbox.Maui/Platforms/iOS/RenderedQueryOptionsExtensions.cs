using MapboxCoreMaps;
using MapboxMaui.Query;

namespace MapboxMaui;

public static class RenderedQueryOptionsExtensions
{
	public static MBMRenderedQueryOptions ToPlatform(this RenderedQueryOptions xoptions)
		// TODO Pass in filter arg
		=> new (xoptions.LayerIds, xoptions.Filter?.Wrap());
}