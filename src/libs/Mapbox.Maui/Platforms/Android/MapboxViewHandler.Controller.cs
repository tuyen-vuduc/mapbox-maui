

using Com.Mapbox.Functions;

namespace MapboxMaui;

partial class MapboxViewHandler : IMapboxController
{
    public CoordinateBounds GetCoordinateBoundsForCamera(CameraOptions cameraOptions)
    {
		var mapView = mapboxFragment?.MapView;

		if (mapView == null) return null;

		var xcameraOptions = cameraOptions.ToNative();
		var xbounds = mapView.MapboxMap.CoordinateBoundsForCamera(xcameraOptions);

		return new CoordinateBounds(
			xbounds.Southwest.ToMapPosition(),
			xbounds.Northeast.ToMapPosition(),
			xbounds.InfiniteBounds
			);
	}

    public IPosition GetMapPosition(ScreenPosition position)
	{
		var mapView = mapboxFragment?.MapView;

		if (mapView == null) return null;

		var coords = mapView.MapboxMap.CoordinateForPixel(position.ToScreenCoordinate());
		return coords.ToMapPosition();
    }

    public ScreenPosition GetScreenPosition(IPosition position)
    {
        var mapView = mapboxFragment?.MapView;

        if (mapView == null) return default;

        var coords = mapView.MapboxMap.PixelForCoordinate(position.ToGeoPoint());
        return coords.ToX();
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
        var mapView = mapboxFragment?.MapView;

        if (mapView is null) return default;

        var result = mapView.MapboxMap.CameraForCoordinates(
            coordinates?.Select(x => x.ToGeoPoint()).ToList(),
            (cameraOptions?? new()).ToNative(),
            coordinatesPadding?.ToNative(),
            maxZoom?.ToNative(),
            offset?.ToScreenCoordinate()
            );
        return result.ToX();
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
        var mapView = mapboxFragment?.MapView;

        if (mapView is null)
        {
            completion(null);
            return;
        }

        mapView.MapboxMap.CameraForCoordinates(
            coordinates?.Select(x => x.ToGeoPoint()).ToList(),
            (cameraOptions??new()).ToNative(),
            coordinatesPadding?.ToNative(),
            maxZoom?.ToNative(),
            offset?.ToScreenCoordinate(),
            new Function1Action<Com.Mapbox.Maps.CameraOptions>((result) =>
            {
                completion?.Invoke(result.ToX());
            })
        );
    }
}
