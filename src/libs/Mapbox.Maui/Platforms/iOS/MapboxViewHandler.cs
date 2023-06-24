
namespace MapboxMaui;

using Foundation;
using MapboxMapsObjC;
using PlatformView = MapViewContainer;
using UIKit;

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
            if (error == null) return;

            System.Diagnostics.Debug.WriteLine(error.LocalizedDescription);
        });
    }

    private static void HandleImagesChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.PlatformView.MapView;
        if (mapView == null) return;

        var images = view.Images;
        if (images == null) return;

        foreach (var ximage in images)
        {
            if (!string.IsNullOrWhiteSpace(ximage.Name))
            {
                var image = UIImage.FromBundle(ximage.Name);

                if (image == null) continue;

                if (ximage.IsTemplate)
                {
                    image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                }

                mapView.AddImageWithId(
                    ximage.Id,
                    image,
                    ximage.Sdf,
                    UIEdgeInsets.Zero,
                    (error) =>
                    {
                        if (error == null) return;

                        System.Diagnostics.Debug.WriteLine(error.LocalizedDescription);
                    });
            }

            // TODO handle other image types
        }
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

            if (mapView.LayerExistsWithId(
                    layer.Id,
                    (error) =>
                    {
                        if (error == null) return;

                        System.Diagnostics.Debug.WriteLine(error.LocalizedDescription);
                    }))
            {
                mapView.UpdateLayerPropertiesFor(
                    layer.Id,
                    properties,
                    (error) =>
                    {
                        if (error == null) return;

                        System.Diagnostics.Debug.WriteLine(error.LocalizedDescription);
                    });

                continue;
            }

            mapView.AddLayerWithProperties(
                properties,
                layer.LayerPosition.ToPlatformValue(),
                layer.LayerPosition.Parameter?.Wrap(),
                (error) =>
                {
                    if (error == null) return;

                    System.Diagnostics.Debug.WriteLine(error.LocalizedDescription);
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

            if (source is Styles.GeoJSONSource geojsonSource
                && geojsonSource.Data is Styles.RawGeoJSONObject raw)
            {
                mapView.AddGeoJSONSourceWithId(
                    source.Id, platformValue, raw.Data,
                    (error) =>
                    {
                        if (error == null) return;

                        System.Diagnostics.Debug.WriteLine(error.LocalizedDescription);
                    });
                continue;
            }

            mapView.AddSource(
                source.Id, platformValue,
                (error) =>
                {
                    if (error == null) return;

                    System.Diagnostics.Debug.WriteLine(error.LocalizedDescription);
                });
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

        if (VirtualView is MapboxView mapboxView)
        {
            mapboxView.InvokeMapReady();
            mapboxView.AnnotationController = this;
        }

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