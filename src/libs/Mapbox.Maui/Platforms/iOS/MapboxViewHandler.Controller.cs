using Foundation;
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
			xbounds.Southwest.ToMapPosition(),
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
            completion?.Invoke(null);
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
                completion?.Invoke(result?.ToX());
            });
    }

    public void SetSourcePropertyFor<T>(
        string sourceId, string propertyName,
        T value, Action<Exception> completion = null)
    {
        var mapView = PlatformView.MapView;

        if (mapView == null)
        {
            completion?.Invoke(null);
            return;
        }

        mapView.MapboxMap().SetSourcePropertyFor(
            sourceId,
            propertyName,
            value.Wrap(),
            (error) =>
            {
                var exception = error is not null
                    ? new NSErrorException(error)
                    : null;
                completion?.Invoke(exception);
            });
    }


    public void SetLayerPropertyFor<T>(
        string layerId, string propertyName,
        T value, Action<Exception> completion = null)
    {
        var mapView = PlatformView.MapView;

        if (mapView == null)
        {
            completion?.Invoke(null);
            return;
        }

        mapView.MapboxMap().SetLayerPropertyFor(
            layerId,
            propertyName,
            value.Wrap(),
            (error) =>
            {
                var exception = error is not null
                    ? new NSErrorException(error)
                    : null;
                completion?.Invoke(exception);
            });
    }
}
