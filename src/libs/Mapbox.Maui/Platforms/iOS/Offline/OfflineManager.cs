using Foundation;
using MapboxCoreMaps;
using MapboxMapsObjC;

namespace Mapbox.Maui.Offline;

using PlatformOfflineManager = MBMOfflineManager;

partial class OfflineManager : IOfflineManager
{
    PlatformOfflineManager nativeManager;

    partial void InitializePlatformManager()
    {
        var optionsBuilder = MapInitOptionsBuilder.Create();
        optionsBuilder.CameraOptions(cameraOptions.ToNative());
        var options = optionsBuilder.Build();

        nativeManager = new PlatformOfflineManager(
            options.ResourceOptions()
        );
    }

    public void DownloadStyle(
        string styleUri,
        StylePackLoadOptions options,
        Action<StylePackLoadProgress> progressHandler,
        Action<StylePack, Exception> completionHandler)
    {
        var metadata = new NSMutableDictionary();
        if (options.Metadata != null)
        {
            foreach (var item in options.Metadata)
            {
                metadata[new NSString(item.Key)] = item.Value.Wrap();
            }
        }
        var nativeOptions = new MBMStylePackLoadOptions(
            options.Mode.HasValue
            ? NSNumber.FromInt32((int)options.Mode)
            : null,
            metadata,
            options.AcceptsExpired
        );

        nativeManager.LoadStyleWithStyleUriString(
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
}

