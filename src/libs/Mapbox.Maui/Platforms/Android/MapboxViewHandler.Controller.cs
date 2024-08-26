

using Com.Mapbox.Bindgen;
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
            completion?.Invoke(null);
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

    public void SetSourcePropertyFor<T>(
        string sourceId, string propertyName,
        T value, Action<Exception> completion = null)
    {
        var mapView = mapboxFragment?.MapView;

        if (mapView is null)
        {
            completion?.Invoke(null);
            return;
        }

        var result = mapView.MapboxMap.SetStyleSourceProperty(sourceId, propertyName, value.Wrap());

        result.OnError(new XExpectedAction(error =>
        {
            completion?.Invoke(new Exception("An error occurred when setting source property"));
        }));
        result.OnValue(new XExpectedAction(result =>
        {
            completion?.Invoke(null);
        }));
    }
}

internal class XExpectedAction : Java.Lang.Object, Expected.IAction
{
    private readonly Action<Java.Lang.Object> action;

    public XExpectedAction(Action<Java.Lang.Object> action)
    {
        this.action = action;
    }

    public void Run(Java.Lang.Object p0)
    {
        action?.Invoke(p0);
    }
}
