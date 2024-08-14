using MapboxMapsObjC;
using Microsoft.Maui.Platform;

namespace MapboxMaui;

partial class MapboxViewHandler : IMapboxController
{
    public CoordinateBounds GetCoordinateBoundsForCamera(CameraOptions cameraOptions)
    {
		var mapView = PlatformView.MapView;

		if (mapView == null) return null;

		var xcameraOptions = cameraOptions.ToNative();
		var xbounds = mapView.MapboxMap().CoordinateBoundsForCameraBounds(xcameraOptions);

		return new CoordinateBounds(
			xbounds.Southeast.ToMapPosition(),
			xbounds.Northeast.ToMapPosition(),
			xbounds.InfiniteBounds
			);
    }
    public IPosition GetMapPosition(ScreenPosition position)
    {
        var mapView = PlatformView.MapView;

        if (mapView == null) return null;

        var coords = mapView.MapboxMap().CoordinateFor(
            position.ToNative()
            );

        return coords.ToMapPosition();
    }

    public ScreenPosition GetScreenPosition(IPosition position)
    {
        var mapView = PlatformView.MapView;

        if (mapView == null) return default;

        var coords = mapView.MapboxMap().PointFor(position.ToCoords());
        return coords.ToPoint();
    }

    /**
    * Convenience method that returns the [CameraOptions] object for given parameters.
    *
    * Note: if the render thread did not yet calculate the size of the map (due to initialization or map resizing) - empty [CameraOptions] will be returned.
    *  Emptiness could be checked with [CameraOptions.isEmpty]. Consider using asynchronous overloaded method.
    *
    * @param coordinates The `coordinates` representing the bounds of the camera.
    * @param camera The [CameraOptions] which will be applied before calculating the camera for the coordinates. If any of the fields in [CameraOptions] are not provided then the current value from the map for that field will be used.
    * @param coordinatesPadding The amount of padding in pixels to add to the given `coordinates`.
    *                           Note: This padding is not applied to the map but to the coordinates provided. If you want to apply padding to the map use param `camera`.
    * @param maxZoom The maximum zoom level allowed in the returned camera options.
    * @param offset The center of the given bounds relative to map center in pixels.
    *
    * @return The [CameraOptions] object representing the provided parameters if the map size was calculated and empty [CameraOptions] otherwise, see [CameraOptions.isEmpty].
    *  Also empty [CameraOptions] are returned in case of an internal error.
    */
    public CameraOptions? CameraForCoordinates(
        IEnumerable<IPosition> coordinates,
        CameraOptions? cameraOptions = null,
        Thickness? coordinatesPadding = null,
        double? maxZoom = null,
        ScreenPosition? offset = null)
    {
        var mapView = PlatformView.MapView;

        if (mapView == null) return default;

        TMBCameraOptions? xresult = null;
        mapView.MapboxMap().CameraFor(
            coordinates?.Select(x => x.ToNSValue()).ToArray(),
            (cameraOptions?? new()).ToNative(),
            coordinatesPadding?.ToNSValue(),
            maxZoom?.ToNSNumber(),
            offset?.ToNSValue(),
            (result, _) =>
            {
                xresult = result;
            });
        return xresult?.ToX();
    }

    /**
    * Convenience method that returns the [CameraOptions] object for given parameters.
    *
    * @param coordinates The `coordinates` representing the bounds of the camera.
    * @param camera The [CameraOptions] which will be applied before calculating the camera for the coordinates. If any of the fields in [CameraOptions] are not provided then the current value from the map for that field will be used.
    * @param coordinatesPadding The amount of padding in pixels to add to the given `coordinates`.
    *                           Note: This padding is not applied to the map but to the coordinates provided. If you want to apply padding to the map use param `camera`.
    * @param maxZoom The maximum zoom level allowed in the returned camera options.
    * @param offset The center of the given bounds relative to map center in pixels.
    * @param completion Callback returning the [CameraOptions] object representing the provided parameters. Those [CameraOptions] always take into account actual MapView size and may return empty ([CameraOptions.isEmpty]) options only if an internal error has occurred.
    */
    public void CameraForCoordinates(
        IEnumerable<IPosition> coordinates,
        Action<CameraOptions?> completion,
        CameraOptions? cameraOptions = null,
        Thickness? coordinatesPadding = null,
        double? maxZoom = null,
        ScreenPosition? offset = null)
    {

        var mapView = PlatformView.MapView;

        if (mapView == null)
        {
            completion(null);
            return;
        }

        mapView.MapboxMap().CameraFor(
            coordinates?.Select(x => x.ToNSValue()).ToArray(),
            (cameraOptions?? new()).ToNative(),
            coordinatesPadding?.ToNSValue(),
            maxZoom?.ToNSNumber(),
            offset?.ToNSValue(),
            (result, _) =>
            {
                completion(result?.ToX());
            });
    }
}
