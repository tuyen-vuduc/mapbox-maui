
namespace MapboxMaui;

using Foundation;
using MapboxMapsObjC;
using PlatformView = MapViewContainer;
using UIKit;
using MapboxMaui.Styles;

public partial class MapboxViewHandler
{
    UITapGestureRecognizer mapTapGestureRecognizer;
    UILongPressGestureRecognizer mapLongPressGestureRecognizer;


    private static void HandleLightChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.PlatformView.MapView;
        if (mapView == null) return;

        var light = view.Light;
        if (light == null) return;

        var platformProperties = light.Properties.Wrap() as NSDictionary<NSString, NSObject>;
        var style = mapView.MapboxMap();

        // TODO SetLightWithProperties
        throw new NotImplementedException();
        //style.SetLightWithProperties(
        //    platformProperties,
        //    (error) =>
        //    {
        //        if (error == null) return;

        //        System.Diagnostics.Debug.WriteLine(error.LocalizedDescription);
        //    });
    }

    private static void HandleImagesChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.PlatformView.MapView;
        if (mapView == null) return;

        var images = view.Images;
        if (images == null) return;

        var style = mapView.MapboxMap();

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

                style.AddImage(
                    image,
                    ximage.Id,
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

        var style = mapView.MapboxMap();

        foreach (var layer in layers)
        {
            var properties = layer.ToPlatformValue();
            var layerPosition = layer.LayerPosition.ToPlatformValue(layer.LayerPosition.Parameter?.Wrap());

            if (style.LayerExistsWithId(layer.Id))
            {
                style.SetLayerPropertiesFor(
                    layer.Id,
                    properties,
                    (error) =>
                    {
                        if (error == null) return;

                        System.Diagnostics.Debug.WriteLine(error.LocalizedDescription);
                    });

                continue;
            }

            style.AddLayerWith(
                properties,
                layerPosition,
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

        mapView.MapboxMap().SetTerrain(platformValue, null);
    }

    private static void HandleSourcesChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.PlatformView.MapView;
        if (mapView == null) return;

        var sources = view.Sources;
        if (sources == null) return;

        var style = mapView.MapboxMap();

        foreach (var source in sources)
        {
            var platformValue = source.ToPlatformValue();
            var sourceExists = style.SourceExistsWithId(source.Id);

            if (source is GeoJSONSource geojsonSource)
            {
                HandleGeoJSONSource(style, source.Id, platformValue, geojsonSource.Data);
                continue;
            }

            if (sourceExists)
            {
                style.SetSourcePropertiesFor(
                    source.Id, platformValue,
                    (error) =>
                    {
                        if (error == null) return;

                        System.Diagnostics.Debug.WriteLine(error.LocalizedDescription);
                    });
                continue;
            }

            style.AddSourceWithId(
                source.Id,
                platformValue,
                (error) =>
                {
                    if (error == null) return;

                    System.Diagnostics.Debug.WriteLine(error.LocalizedDescription);
                });
        }
    }

    private static void HandleGeoJSONSource(TMBMapboxMap style, string sourceId, NSDictionary<NSString, NSObject> platformValue, GeoJSON.Text.IGeoJSONObject data)
    {
        var sourceExists = style.SourceExistsWithId(sourceId);

        switch (data)
        {
            case RawGeoJSONObject raw:

                var source = new TMBGeoJSONSource(sourceId);
                source.Data = TMBGeoJSONSourceData.FromString(raw.Data);
                
                style.AddSource(source , sourceId,  (error) =>
                {
                    if (error == null) return;
                    System.Diagnostics.Debug.WriteLine(error.LocalizedDescription);
                });
            break;
        }

        //switch(data) {
        //    //case RawGeoJSONObject raw:
        //    //    if (sourceExists)
        //    //    {
        //    //        style.UpdateGeoJSONSourceWithId(
        //    //            sourceId, raw.Data,
        //    //            (error) =>
        //    //            {
        //    //                if (error == null) return;

        //    //                System.Diagnostics.Debug.WriteLine(error.LocalizedDescription);
        //    //            });
        //    //        return;
        //    //    }

        //    //    style.AddGeoJSONSourceWithId(
        //    //        sourceId, platformValue, raw.Data,
        //    //        (error) =>
        //    //        {
        //    //            if (error == null) return;

        //    //            System.Diagnostics.Debug.WriteLine(error.LocalizedDescription);
        //    //        });
        //    //    break;
        //    //case GeoJSON.Text.Geometry.IGeometryObject geometry:
        //    //    if (sourceExists) {
        //    //        style.UpdateGeoJSONSourceWithId(
        //    //            sourceId, geometry.ToNative(),
        //    //            (error) => {
        //    //                if (error == null) return;

        //    //                System.Diagnostics.Debug.WriteLine(error.LocalizedDescription);
        //    //            });
        //    //        return;
        //    //    }
        //    //    style.AddSourceWithId(
        //    //        sourceId, geometry.ToNative(),
        //    //        (error) => {
        //    //            if (error == null) return;

        //    //            System.Diagnostics.Debug.WriteLine(error.LocalizedDescription);
        //    //        });
        //    //    break;
        //}        
    }

    private static void HandleCameraOptionsChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.PlatformView.MapView;
        if (mapView == null) return;

        var cameraOptions = view.CameraOptions.ToNative();
        if (cameraOptions == null) return;

        mapView.MapboxMap().SetCameraTo(cameraOptions);
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

        mapView.Ornaments().Options.ScaleBar.Visibility = view.ScaleBarVisibility.ToNative();
    }

    private static void HandleMapboxStyleChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.PlatformView.MapView;
        if (mapView == null) return;

        var styleUri = view.MapboxStyle.ToNative();
        if (string.IsNullOrWhiteSpace(styleUri)) return;

        mapView.MapboxMap().LoadStyleWithUri(styleUri, null, (error) =>
        {
            if (error == null) return;

            System.Diagnostics.Debug.WriteLine(error.LocalizedDescription);
        });
    }

    protected override PlatformView CreatePlatformView()
    {
        return new PlatformView(ACCESS_TOKEN);
    }

    protected override void DisconnectHandler(PlatformView platformView)
    {
        base.DisconnectHandler(platformView);

        if (VirtualView is MapboxView mapboxView)
        {
            mapboxView.AnnotationController = null;
            mapboxView.QueryManager = null;
        }

        var mapView = platformView.MapView;
        if (mapView == null) return;

        if (mapTapGestureRecognizer != null)
        {
            mapView.RemoveGestureRecognizer(mapTapGestureRecognizer);
        }
        
        if (mapLongPressGestureRecognizer != null)
        {
            mapView.RemoveGestureRecognizer(mapLongPressGestureRecognizer);
        }
    }

    protected override void ConnectHandler(PlatformView platformView)
    {
        base.ConnectHandler(platformView);

        if (VirtualView is MapboxView mapboxView)
        {
            mapboxView.InvokeMapReady();
            mapboxView.AnnotationController = this;
            mapboxView.QueryManager = this;
        }

        var mapView = platformView.MapView;
        if (mapView == null) return;

        var mapboxMap = mapView.MapboxMap();

        mapboxMap.OnStyleLoaded(_ =>
        {
            (VirtualView as MapboxView)?.InvokeStyleLoaded();
        });
        mapboxMap.OnMapLoaded(_ =>
        {
            (VirtualView as MapboxView)?.InvokeMapLoaded();
        });

        mapTapGestureRecognizer = new UITapGestureRecognizer(HandleMapTapped);
        mapView.AddGestureRecognizer(mapTapGestureRecognizer);
        
        mapLongPressGestureRecognizer = new UILongPressGestureRecognizer(HandleMapLongPress);
        mapView.AddGestureRecognizer(mapLongPressGestureRecognizer);
    }

    private void HandleMapLongPress(UILongPressGestureRecognizer longPressGestureRecognizer)
    {
        if (longPressGestureRecognizer.State != UIGestureRecognizerState.Began) return;
        
        var position = GetPositionForGesture(longPressGestureRecognizer);
        if (position == null) return;
        
        (VirtualView as MapboxView)?.InvokeMapLongTapped(
            position
        );
    }

    private void HandleMapTapped(UITapGestureRecognizer tapGestureRecognizer)
    {
        var position = GetPositionForGesture(tapGestureRecognizer);
        if (position == null) return;
        
        (VirtualView as MapboxView)?.InvokeMapTapped(
            position
        );
    }

    private MapTappedPosition GetPositionForGesture(UIGestureRecognizer gesture)
    {
        var mapView = PlatformView.MapView;
        if (mapView == null) return null;
        
        var screenPosition = gesture.LocationInView(mapView);
        var coords = mapView.MapboxMap().CoordinateFor(
            screenPosition
        );

        return coords.ToMapTappedPosition(screenPosition);
    }
}