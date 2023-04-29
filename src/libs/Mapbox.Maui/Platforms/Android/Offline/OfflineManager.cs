namespace Mapbox.Maui.Offline;

using Com.Mapbox.Bindgen;
using Com.Mapbox.Common;
using Com.Mapbox.Maps;
using Java.Text;

public partial class OfflineManager
{
    IOfflineManagerInterface nativeManager;

    partial void InitializePlatformManager()
    {
        var resourceOptions = new ResourceOptions.Builder()
            .AccessToken(accessToken)
            .Build();

        nativeManager = new Com.Mapbox.Maps.OfflineManager(
            resourceOptions
        );
    }

    public bool IsMapboxStackConnected
    {
        get => OfflineSwitch.Instance.MapboxStackConnected;
        set => OfflineSwitch.Instance.MapboxStackConnected = value;
    }

    public void DownloadStyle(
        string styleUri,
        StylePackLoadOptions options,
        Action<StylePackLoadProgress> progressHandler,
        Action<StylePack, Exception> completionHandler)
    {
        nativeManager.LoadStylePack(
            styleUri,
            new Com.Mapbox.Maps.StylePackLoadOptions.Builder()
                .GlyphsRasterizationMode(options.Mode.HasValue
                    ? GetGlyphsRasterizationMode(options.Mode.Value)
                    : null
                )
                .Metadata(options.Metadata.Wrap())
                .AcceptExpired(options.AcceptsExpired)
            .Build()
            , new StylePackLoadProgressCallback(progressHandler)
            , new StylePackCallBack(completionHandler)
            );
    }

    private Com.Mapbox.Maps.GlyphsRasterizationMode GetGlyphsRasterizationMode(GlyphsRasterizationMode mode)
    {
        return mode switch
        {
            GlyphsRasterizationMode.NoGlyphsRasterizedLocally => Com.Mapbox.Maps.GlyphsRasterizationMode.NoGlyphsRasterizedLocally,
            GlyphsRasterizationMode.IdeographsRasterizedLocally => Com.Mapbox.Maps.GlyphsRasterizationMode.IdeographsRasterizedLocally,
            GlyphsRasterizationMode.AllGlyphsRasterizedLocally => Com.Mapbox.Maps.GlyphsRasterizationMode.AllGlyphsRasterizedLocally,
            _ => null,
        };
    }

    class StylePackLoadProgressCallback : Java.Lang.Object, IStylePackLoadProgressCallback
    {
        private Action<StylePackLoadProgress> progressHandler;

        public StylePackLoadProgressCallback(Action<StylePackLoadProgress> progressHandler)
        {
            this.progressHandler = progressHandler;
        }

        public void Run(Com.Mapbox.Maps.StylePackLoadProgress progress)
        {
            progressHandler?.Invoke(new StylePackLoadProgress
            {
                CompletedResourceCount = (ulong)progress.CompletedResourceCount,
                CompletedResourceSize = (ulong)progress.CompletedResourceSize,
                ErroredResourceCount = (ulong)progress.ErroredResourceCount,
                LoadedResourceCount = (ulong)progress.LoadedResourceCount,
                LoadedResourceSize = (ulong)progress.LoadedResourceSize,
                RequiredResourceCount = (ulong)progress.RequiredResourceCount,
            });
        }
    }

    class StylePackCallBack : Java.Lang.Object, IStylePackCallback
    {
        private Action<StylePack, Exception> completionHandler;

        public StylePackCallBack(Action<StylePack, Exception> completionHandler)
        {
            this.completionHandler = completionHandler;
        }

        public void Run(Expected expected)
        {
            var xstylePack = expected.IsValue
                && expected.Value is Com.Mapbox.Maps.StylePack stylePack
                ? new StylePack
                {
                    CompletedResourceCount = (ulong)stylePack.CompletedResourceCount,
                    CompletedResourceSize = (ulong)stylePack.CompletedResourceSize,
                    Expires = stylePack.Expires != null
                        ? DateTime.Parse(new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss.SSSZ").Format(stylePack.Expires))
                        : null,
                    RequiredResourceCount = (ulong)stylePack.RequiredResourceCount,
                    StyleUri = stylePack.StyleURI,
                    GlyphsRasterizationMode = GetGlyphsRasterizationMode(stylePack.GlyphsRasterizationMode),
                }
                : null;
            var xerror = expected.IsError
                ? new StylePackCallBackException((StylePackError)expected.Error)
                : null;

            completionHandler?.Invoke(xstylePack, xerror);
        }

        private GlyphsRasterizationMode? GetGlyphsRasterizationMode(Com.Mapbox.Maps.GlyphsRasterizationMode mode)
        {
            switch (mode)
            {
                case Com.Mapbox.Maps.GlyphsRasterizationMode x
                    when x == Com.Mapbox.Maps.GlyphsRasterizationMode.NoGlyphsRasterizedLocally:
                    return GlyphsRasterizationMode.NoGlyphsRasterizedLocally;
                case Com.Mapbox.Maps.GlyphsRasterizationMode x
                    when x == Com.Mapbox.Maps.GlyphsRasterizationMode.IdeographsRasterizedLocally:
                    return GlyphsRasterizationMode.IdeographsRasterizedLocally;
                case Com.Mapbox.Maps.GlyphsRasterizationMode x
                    when x == Com.Mapbox.Maps.GlyphsRasterizationMode.AllGlyphsRasterizedLocally:
                    return GlyphsRasterizationMode.AllGlyphsRasterizedLocally;
                default:
                    return null;
            };
        }

    }

    class StylePackCallBackException : Exception
    {
        private readonly StylePackError error;

        public StylePackCallBackException(StylePackError error)
        {
            this.error = error;
        }
    }
}

