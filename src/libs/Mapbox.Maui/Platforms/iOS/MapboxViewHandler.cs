
namespace Mapbox.Maui;

using Foundation;
using GeoJSON.Net.Geometry;
using Mapbox.Maui.Annotations;
using MapboxMapsObjC;
using PlatformView = MapViewContainer;

public partial class MapboxViewHandler
{
    private static void HandleLightChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.PlatformView.MapView;
        if (mapView == null) return;

        var light = view.Light;
        if (light == null) return;

        var platformProperties = light.Properties.Wrap() as NSDictionary<NSString, NSObject>;
        mapView.SetLightWithProperties(platformProperties, (error) =>
        {
            System.Diagnostics.Debug.WriteLine(error.UserInfo);
        });
    }

    private static void HandleLayersChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.PlatformView.MapView;
        if (mapView == null) return;

        var layers = view.Layers;
        if (layers == null) return;

        foreach (var layer in layers)
        {
            var properties = layer.ToPlatformValue();

            if (mapView.LayerExistsWithId(layer.Id, null))
            {
                mapView.UpdateLayerPropertiesFor(
                    layer.Id,
                    properties,
                    (error) =>
                    {
                        System.Diagnostics.Debug.WriteLine(error.UserInfo);
                    }
                );

                continue;
            }

            mapView.AddLayerWithProperties(
                properties,
                layer.LayerPosition.ToPlatformValue(),
                layer.LayerPosition.Parameter?.Wrap(),
                (error) =>
                {
                    System.Diagnostics.Debug.WriteLine(error.UserInfo);
                }
            );
        }
    }

    private static void HandleTerrainChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.PlatformView.MapView;
        if (mapView == null) return;

        var terrain = view.Terrain;
        if (terrain == null) return;

        var platformValue = terrain.ToPlatformValue();

        mapView.SetTerrain(platformValue, null);
    }

    private static void HandleSourcesChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.PlatformView.MapView;
        if (mapView == null) return;

        var sources = view.Sources;
        if (sources == null) return;

        foreach (var source in sources)
        {
            var platformValue = source.ToPlatformValue();

            mapView.AddSource(source.Id, platformValue, null);
        }
    }

    private static void HandleCameraOptionsChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.PlatformView.MapView;
        if (mapView == null) return;

        var cameraOptions = view.CameraOptions.ToNative();
        if (cameraOptions == null) return;

        mapView.SetCameraTo(cameraOptions);
    }

    private static void HandleDebugOptionsChanged(MapboxViewHandler handler, IMapboxView view)
    {
        if (view.DebugOptions == null) return;

        var mapView = handler.PlatformView.MapView;
        if (mapView == null) return;

        var debugOptions = view.DebugOptions.ToNative();

        mapView.MapboxMapDebugOptions(
            debugOptions
                .Select(x => NSNumber.FromInt32((int)x))
                .ToArray()
        );
    }

    private static void HandleScaleBarVisibilityChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.PlatformView.MapView;
        if (mapView == null) return;

        mapView.OrnamentsOptionsScaleBarVisibility(view.ScaleBarVisibility.ToNative());
    }

    private static void HandleMapboxStyleChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.PlatformView.MapView;
        if (mapView == null) return;

        var styleUri = view.MapboxStyle.ToNative();
        if (string.IsNullOrWhiteSpace(styleUri)) return;

        mapView.SetStyle(styleUri);
    }

    protected override PlatformView CreatePlatformView()
    {
        var accessToken = string.IsNullOrWhiteSpace(ACCESS_TOKEN)
            ? MapInitOptionsBuilder.DefaultResourceOptions.AccessToken
            : ACCESS_TOKEN;

        return new PlatformView(accessToken);
    }

    protected override void ConnectHandler(PlatformView platformView)
    {
        base.ConnectHandler(platformView);

        (VirtualView as MapboxView)?.InvokeMapReady();

        var mapView = platformView.MapView;
        if (mapView == null) return;

        mapView.OnStyleLoaded(_ =>
        {
            (VirtualView as MapboxView)?.InvokeStyleLoaded();
        });
        mapView.OnMapLoaded(_ =>
        {
            (VirtualView as MapboxView)?.InvokeMapLoaded();
        });
    }
}