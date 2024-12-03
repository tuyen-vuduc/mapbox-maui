namespace MapboxMaui;

public interface IMapboxController
{
    IPosition GetMapPosition(ScreenPosition position);
    CoordinateBounds GetCoordinateBoundsForCamera(CameraOptions cameraOptions);
    ScreenPosition GetScreenPosition(IPosition position);
    CameraOptions? CameraForCoordinates(
        IEnumerable<IPosition> coordinates,
        CameraOptions? cameraOptions = default,
        Thickness? coordinatesPadding = default,
        double? maxZoom = default,
        ScreenPosition? offset = default
    );
    void CameraForCoordinates(
        IEnumerable<IPosition> coordinates,
        Action<CameraOptions?> completion,
        CameraOptions? cameraOptions = default,
        Thickness? coordinatesPadding = default,
        double? maxZoom = default,
        ScreenPosition? offset = default
    );
    void SetSourcePropertyFor<T>(string sourceId, string propertyName, T value, Action<Exception> completion = default);
    void SetLayerPropertyFor<T>(string layerId, string propertyName, T value, Action<Exception> completion = default);
}
