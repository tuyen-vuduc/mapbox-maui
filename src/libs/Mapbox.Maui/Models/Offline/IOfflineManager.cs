namespace Mapbox.Maui.Offline;

public interface IOfflineManager
{
    bool IsMapboxStackConnected { get; set; }

    void DownloadStyle(
        string styleUri,
        StylePackLoadOptions options,
        Action<StylePackLoadProgress> progressHandler,
        Action<StylePack, Exception> completionHandler
    );
}

public partial class OfflineManager : IOfflineManager
{
    private readonly string accessToken;
    private readonly CameraOptions cameraOptions;

    public OfflineManager(
        string accessToken,
        CameraOptions cameraOptions
        )
    {
        this.accessToken = accessToken;
        this.cameraOptions = cameraOptions;

        InitializePlatformManager();
    }

    partial void InitializePlatformManager();
}
