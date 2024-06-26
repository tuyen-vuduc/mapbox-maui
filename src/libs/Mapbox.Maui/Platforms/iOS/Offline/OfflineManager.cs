using Foundation;
using MapboxCommon;
using MapboxCoreMaps;
using MapboxMapsObjC;

namespace MapboxMaui.Offline;

using PlatformOfflineManager = MBMOfflineManager;

partial class OfflineManager : NSObject, IOfflineManager
{
    PlatformOfflineManager nativeManager;
    MBXTileStore titleStore;

    partial void InitializePlatformManager()
    {
        nativeManager = new PlatformOfflineManager();
        nativeManager = new PlatformOfflineManager();

        titleStore = MBXTileStore.Create();
    }

    public bool IsMapboxStackConnected
    {
        get => MBXOfflineSwitch.Instance.IsMapboxStackConnected;
        set => MBXOfflineSwitch.Instance.SetMapboxStackConnectedForConnected(value);
    }

    public void DownloadStyle(
        string styleUri,
        StylePackLoadOptions options,
        Action<StylePackLoadProgress> progressHandler,
        Action<StylePack, Exception> completionHandler)
    {
        var nativeOptions = options.ToNative();

        nativeManager.LoadStylePackFor(
            styleUri,
            nativeOptions,
            (progress) =>
            {
                var xprogress = new StylePackLoadProgress
                {
                    CompletedResourceCount = progress.CompletedResourceCount,
                    CompletedResourceSize = progress.CompletedResourceSize,
                    ErroredResourceCount = progress.ErroredResourceCount,
                    LoadedResourceCount = progress.LoadedResourceCount,
                    LoadedResourceSize = progress.LoadedResourceSize,
                    RequiredResourceCount = progress.RequiredResourceCount,
                };
                progressHandler?.Invoke(xprogress);
            },
            (stylePack, error) =>
            {
                var xstylePack = stylePack != null
                    ? new StylePack
                    {
                        CompletedResourceCount = stylePack.CompletedResourceCount,
                        CompletedResourceSize = stylePack.CompletedResourceSize,
                        Expires = stylePack.Expires != null
                            ? DateTime.Parse(stylePack.Expires.ToString())
                            : null,
                        RequiredResourceCount = stylePack.RequiredResourceCount,
                        StyleUri = stylePack.StyleURI,
                        GlyphsRasterizationMode = (GlyphsRasterizationMode)stylePack.GlyphsRasterizationMode,
                    }
                    : null;
                var xerror = error != null
                    ? new NSErrorException(error)
                    : null;
                completionHandler?.Invoke(xstylePack, xerror);
            });
    }


    public void DownloadTile(
        string tileId,
        TileRegionLoadOptions xoptions,
        Action<TileRegionLoadProgress> progressHandler,
        Action<TileRegion, Exception> completionHandler)
    {
        if (xoptions == null) return;

        var descriptors = xoptions.TilesetDescriptors?
            .Select(
                x => new MBMTilesetDescriptorOptions(
                    x.StyleUri,
                    (byte)x.MinZoom,
                    (byte)x.MaxZoom,
                    null,
                    x.StylePackLoadOptions?.ToNative(),
                    null
                ))
            .Select(
                nativeManager.CreateTilesetDescriptorForTilesetDescriptorOptions)
            .ToArray();

        var metadata = new NSMutableDictionary();
        if (xoptions.Metadata != null)
        {
            foreach (var item in xoptions.Metadata)
            {
                metadata[new NSString(item.Key)] = item.Value.Wrap();
            }
        }

        var options = new MBXTileRegionLoadOptions(
            xoptions.Geometry?.ToNative(),
            descriptors,
            metadata,
            xoptions.AcceptsExpired,
            (MBXNetworkRestriction)xoptions.NetworkRestriction,
            xoptions.StartLocation.HasValue
                ? new MBXCoordinate2D(
                    new CoreLocation.CLLocationCoordinate2D(
                    xoptions.StartLocation.Value.X,
                    xoptions.StartLocation.Value.Y
                    ))
                : null,
            xoptions.AvarageBytesPerSecond.HasValue
                ? NSNumber.FromInt32(xoptions.AvarageBytesPerSecond.Value)
                : null,
            xoptions.ExtraOptions?.Wrap()
        );

        titleStore.LoadTileRegionForId(
            tileId,
            options,
            (progress) =>
            {
                var xprogress = new TileRegionLoadProgress
                {
                    CompletedResourceCount = progress.CompletedResourceCount,
                    CompletedResourceSize = progress.CompletedResourceSize,
                    ErroredResourceCount = progress.ErroredResourceCount,
                    LoadedResourceCount = progress.LoadedResourceCount,
                    LoadedResourceSize = progress.LoadedResourceSize,
                    RequiredResourceCount = progress.RequiredResourceCount,
                };

                progressHandler?.Invoke(xprogress);
            },
            (tileRegion, error) =>
            {
                var xtileRegion = tileRegion != null
                    ? new TileRegion
                    {
                        CompletedResourceCount = tileRegion.CompletedResourceCount,
                        CompletedResourceSize = tileRegion.CompletedResourceSize,
                        Expires = tileRegion.Expires != null
                            ? DateTime.Parse(tileRegion.Expires.ToString())
                            : null,
                        RequiredResourceCount = tileRegion.RequiredResourceCount,
                        Id = tileRegion.Id,
                    }
                    : null;
                var xerror = error != null
                    ? new NSErrorException(error)
                    : null;

                completionHandler?.Invoke(xtileRegion, xerror);
            }
            );
    }
    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        if (disposing)
        {
            nativeManager?.Dispose();
            nativeManager = null;

            titleStore?.Dispose();
            titleStore = null;
        }
    }
}

