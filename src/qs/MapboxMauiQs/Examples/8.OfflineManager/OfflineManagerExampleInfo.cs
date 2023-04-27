namespace MapboxMauiQs;
class OfflineManagerExampleInfo : IExampleInfo
{
    public string Group => "Offline";
    public string Title => "Use OfflineManager and TileStore to download a region";
    public string Subtitle => "Shows how to use OfflineManager and TileStore to download regions for offline use. By default, users may download up to 750 tile packs for offline use across all regions. If the limit is hit, any loadRegion call will fail until excess regions are deleted. This limit is subject to change. Please contact Mapbox if you require a higher limit. Additional charges may apply.";
    public string PageRoute => typeof(OfflineManagerExample).FullName;
}