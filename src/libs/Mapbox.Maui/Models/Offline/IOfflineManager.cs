using GeoJSON.Text;
using GeoJSON.Text.Geometry;
using Point = Microsoft.Maui.Graphics.Point;

namespace MapboxMaui.Offline;

public interface IOfflineManager
{
    bool IsMapboxStackConnected { get; set; }

    void DownloadStyle(
        string styleUri,
        StylePackLoadOptions options,
        Action<StylePackLoadProgress> progressHandler,
        Action<StylePack, Exception> completionHandler
    );

    void DownloadTile(
        string tileId,
        TileRegionLoadOptions options,
        Action<TileRegionLoadProgress> progressHandler,
        Action<TileRegion, Exception> completionHandler
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

public record TilesetDescriptorOptions (
    string StyleUri,
    sbyte MinZoom,
    sbyte MaxZoom,
    float PixelRatio = 1.0f,
    StylePackLoadOptions StylePackLoadOptions = null);

public record TileRegionLoadOptions (
    IGeometryObject Geometry = null,
    TilesetDescriptorOptions[] TilesetDescriptors = null,
    IReadOnlyDictionary<string, object> Metadata = null,
    bool AcceptsExpired = false,
    NetworkRestriction NetworkRestriction = NetworkRestriction.None,
    Point? StartLocation = null,
    int? AvarageBytesPerSecond = null,
    object ExtraOptions = null);