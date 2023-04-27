using System;
using Mapbox.Maui;
using Mapbox.Maui.Offline;
using iOSPage = Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific.Page;
namespace MapboxMauiQs;

public class OfflineManagerExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;
    Point tokyoCoord;
    string tileRegionId = @"myTileRegion";
    float tokyoZoom = 12;
    IOfflineManager offlineManager;

    public OfflineManagerExample()
    {
        iOSPage.SetUseSafeArea(this, false);
        Content = map = new MapboxView();
        tokyoCoord = new Point(35.682027, 139.769305);

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
                System.Diagnostics.Debug.WriteLine($"PROGRESS {progress.CompletedResourceCount}/{progress.RequiredResourceCount}");
            },
            (stylePack, exception) =>
            {
                System.Diagnostics.Debug.WriteLine($"DONE {stylePack.CompletedResourceCount}/{stylePack.RequiredResourceCount}");
            });
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }
}