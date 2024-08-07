﻿using MapboxMapsObjC;
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
}
