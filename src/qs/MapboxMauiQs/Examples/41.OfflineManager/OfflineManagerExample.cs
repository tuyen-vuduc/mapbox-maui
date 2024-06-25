namespace MapboxMauiQs;

public class OfflineManagerExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;
    IPosition tokyoCoord;
    string tileRegionId = @"myTileRegion";
    float tokyoZoom = 12;
    IOfflineManager offlineManager;

    public OfflineManagerExample()
    {
        iOSPage.SetUseSafeArea(this, false);
        Content = map = new MapboxView();
        tokyoCoord = new MapPosition(35.682027, 139.769305);

        map.MapReady += Map_MapReady;
    }

    private void Map_MapReady(object sender, EventArgs e)
    {
        var cameraOptions = new CameraOptions
        {
            Center = tokyoCoord,
            Zoom = tokyoZoom,
        };
        map.CameraOptions = cameraOptions;
        map.MapboxStyle = MapboxStyle.OUTDOORS;

        offlineManager = new OfflineManager(
            MauiProgram.ACCESS_TOKEN,
            cameraOptions);

        offlineManager.IsMapboxStackConnected = true;

        offlineManager.DownloadStyle(
            MapboxStyle.OUTDOORS.Value,
            new StylePackLoadOptions
            {
                Mode = GlyphsRasterizationMode.IdeographsRasterizedLocally,
                Metadata = new Dictionary<string, object>
                {
                    { @"tag", @"my-outdoors-style-pack" }
                }
            },
            (progress) =>
            {
                System.Diagnostics.Debug.WriteLine($"PROGRESS:DownloadStyle {
                    progress.CompletedResourceCount}/{
                    progress.RequiredResourceCount}");
            },
            (stylePack, exception) =>
            {
                if (exception != null)
                {
                    System.Diagnostics.Debug.WriteLine($"ERR:DownloadStyle {exception.Message}");
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"DONE:DownloadStyle {
                    stylePack.CompletedResourceCount}/{
                    stylePack.RequiredResourceCount}");
            });

        var tilesetDescriptorOptions = new TilesetDescriptorOptions(
            MapboxStyle.OUTDOORS.Value,
            MinZoom: 0,
            MaxZoom: 16
            );

        var tileRegionLoadOptions = new TileRegionLoadOptions(
            Geometry: new GeoJSON.Text.Geometry.Point(tokyoCoord),
            TilesetDescriptors: [tilesetDescriptorOptions],
            AcceptsExpired: true,
            NetworkRestriction: NetworkRestriction.None,
            Metadata: new Dictionary<string, object>
            {
                { @"tag", @"my-outdoors-tile-region" }
            });

        offlineManager.DownloadTile(
            tileRegionId,
            tileRegionLoadOptions,
            progress =>
            {
                System.Diagnostics.Debug.WriteLine($"PROGRESS:DownloadTile {
                    progress.CompletedResourceCount}/{
                    progress.RequiredResourceCount}");
            },
            (tileRegion, exception) =>
            {
                if (exception != null)
                {
                    System.Diagnostics.Debug.WriteLine($"ERR:DownloadTile {exception.Message}");
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"DONE:DownloadTile {
                    tileRegion.CompletedResourceCount}/{
                    tileRegion.RequiredResourceCount}");
            });
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }
}