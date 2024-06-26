
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
}
