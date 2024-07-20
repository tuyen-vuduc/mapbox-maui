
using PlatformView = AndroidX.Fragment.App.FragmentContainerView;
using MapboxMapsStyle = Com.Mapbox.Maps.Style;
using Com.Mapbox.Maps;
using Com.Mapbox.Maps.Plugins.Scalebar;
using Microsoft.Maui.Platform;
using Android.Content;
using Android.Graphics;
using GeoJSON.Text;
using Com.Mapbox.Maps.Plugins.Gestures;
using Com.Mapbox.Maps.Plugins.Gestures.Generated;

namespace MapboxMaui;
public partial class MapboxViewHandler
{
    MapboxFragment mapboxFragment;

    private static void HandleGestureSettingsChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.GetMapView();
        if (mapView == null) return;

        var gestures = mapView.GetGestures();

        gestures.DoubleTapToZoomInEnabled = view.GestureSettings.DoubleTapToZoomInEnabled;
        gestures.DoubleTouchToZoomOutEnabled = view.GestureSettings.DoubleTouchToZoomOutEnabled;
        gestures.FocalPoint = view.GestureSettings.FocalPoint?.ToScreenCoordinate();
        gestures.QuickZoomEnabled = view.GestureSettings.QuickZoomEnabled;
        gestures.PitchEnabled = view.GestureSettings.PitchEnabled;
        gestures.PinchScrollEnabled = view.GestureSettings.PinchScrollEnabled;
        gestures.RotateEnabled = view.GestureSettings.RotateEnabled;
        gestures.ScrollEnabled = view.GestureSettings.ScrollEnabled;
        gestures.ScrollMode = view.GestureSettings.ScrollMode.ToNative();
        gestures.SimultaneousRotateAndPinchToZoomEnabled = view.GestureSettings.SimultaneousRotateAndPinchToZoomEnabled;

        // Android only
        gestures.IncreasePinchToZoomThresholdWhenRotating = view.GestureSettings.IncreasePinchToZoomThresholdWhenRotating;
        gestures.IncreaseRotateThresholdWhenPinchingToZoom = view.GestureSettings.IncreaseRotateThresholdWhenPinchingToZoom;
        gestures.PinchToZoomDecelerationEnabled = view.GestureSettings.PinchToZoomDecelerationEnabled;
        gestures.PinchToZoomEnabled = view.GestureSettings.PinchToZoomEnabled;
        gestures.RotateDecelerationEnabled = view.GestureSettings.RotateDecelerationEnabled;
        gestures.ScrollDecelerationEnabled = view.GestureSettings.ScrollDecelerationEnabled;
        gestures.ZoomAnimationAmount = view.GestureSettings.ZoomAnimationAmount;
    }

    private static void HandleLightChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.GetMapView();
        if (mapView == null) return;

        if (view.Light == null) return;

        mapView.MapboxMap.Style.SetStyleLights(
            view.Light.ToPlatformValue(true)
        );
    }

    private static void HandleLayersChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.GetMapView();
        if (mapView == null) return;

        if (view.Layers == null) return;

        foreach (var layer in view.Layers)
        {
            var value = layer.ToPlatformValue(true);

            if (mapView.MapboxMap.Style.StyleLayerExists(layer.Id))
            {
                mapView.MapboxMap.Style.SetStyleLayerProperties(layer.Id, value);

                continue;
            }

            mapView.MapboxMap.Style.AddStyleLayer(
                value,
                layer.LayerPosition.ToPlatformValue()
            );
        }
    }

    private static void HandleImagesChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.GetMapView();
        if (mapView == null) return;

        if (view.Images == null) return;

        foreach (var ximage in view.Images)
        {
            if (!string.IsNullOrWhiteSpace(ximage.Name))
            {
                var resourceId = mapView.Resources.GetDrawableId(AppInfo.PackageName, ximage.Name);

                if (resourceId == 0) continue;

                var bitmap = BitmapFactory.DecodeResource(mapView.Resources, resourceId);

                mapView.MapboxMap.Style.AddImage(
                    ximage.Id,
                    bitmap,
                    ximage.Sdf);
            }

            // TODO handle other image types
        }
    }

    private static void HandleTerrainChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.GetMapView();
        if (mapView == null) return;

        if (view.Terrain == null) return;

        var platformValue = view.Terrain.ToPlatformValue();
        platformValue.BindTo(mapView.MapboxMap.Style);
    }

    private static void HandleSourcesChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.GetMapView();
        if (mapView == null) return;

        if (view.Sources == null) return;
        var style = mapView.MapboxMap.Style;

        foreach (var source in view.Sources)
        {
            var sourceExists = style.StyleSourceExists(source.Id);
            var platformValue = source.ToPlatformValue();

            if (sourceExists)
            {
                style.SetStyleSourceProperties(source.Id, platformValue);
            }
            else
            {
                style.AddStyleSource(source.Id, platformValue);
            }

            if (source is Styles.GeoJSONSource geojsonSource)
            {
                HandleGeoJSONSourceChanged(style, source.Id, geojsonSource.Data);
                continue;
            }

            if (!source.VolatileProperties.Any()) continue;

            var setStyleSourcePropertiesResult = mapView.MapboxMap.Style.SetStyleSourceProperties(
                source.Id,
                source.GetVolatileProperties()
            );

            if (setStyleSourcePropertiesResult.IsError)
            {
                System.Diagnostics.Debug.WriteLine(setStyleSourcePropertiesResult.Error);
            }
        }
    }

    private static void HandleGeoJSONSourceChanged(MapboxMapsStyle style, string sourceId, IGeoJSONObject data)
    {
        var xdata = data switch
        {
            Styles.RawGeoJSONObject raw => GeoJSONSourceData.ValueOf(raw.Data),
            GeoJSON.Text.Geometry.IGeometryObject geometry => GeoJSONSourceData.ValueOf(geometry.ToNative()),
            _ => null,
        };

        if (xdata is null) return;

        // TODO Correctly define dataID
        var dataId = Guid.NewGuid().ToString();
        var setStyleGeoJSONSourceDataResult = style.SetStyleGeoJSONSourceData(sourceId, dataId, xdata);

        if (setStyleGeoJSONSourceDataResult.IsError)
        {
            System.Diagnostics.Debug.WriteLine(setStyleGeoJSONSourceDataResult.Error);
        }
    }

    private static void HandleCameraOptionsChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var cameraOptions = view.CameraOptions.ToNative();

        handler.GetMapView()?.MapboxMap.SetCamera(cameraOptions);
    }

    private static void HandleDebugOptionsChanged(MapboxViewHandler handler, IMapboxView view)
    {
        if (view.DebugOptions == null) return;

        var mapView = handler.GetMapView();
        if (mapView == null) return;

        var debugOptions = mapView.MapboxMap.Debug;
        handler.GetMapView().MapboxMap.SetDebug(debugOptions, false);

        debugOptions = view.DebugOptions.ToNative();
        handler.GetMapView().MapboxMap.SetDebug(debugOptions, true);
    }

    private static void HandleScaleBarVisibilityChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.GetMapView();
        if (mapView?.MapboxMap.Style?.IsStyleLoaded != true) return;

        var scaleBarPlugin = ScaleBarUtils.GetScaleBar(mapView);

        scaleBarPlugin.Enabled = view.ScaleBarVisibility != OrnamentVisibility.Hidden;

    }

    private static void HandleMapboxStyleChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var styleUri = view.MapboxStyle.ToNative();

        if (string.IsNullOrWhiteSpace(styleUri))
        {
            styleUri = MapboxMapsStyle.MapboxStreets;
        }

        handler.GetMapView()?.MapboxMap.LoadStyle(styleUri);
    }

    protected override PlatformView CreatePlatformView()
    {
        var mainActivity = (MauiAppCompatActivity)Context.GetActivity();

        var fragmentContainerView = new PlatformView(Context)
        {
            Id = Android.Views.View.GenerateViewId(),
        };
        mapboxFragment = new MapboxFragment();
        RegisterEvents(mapboxFragment);

        var fragmentTransaction = mainActivity.SupportFragmentManager.BeginTransaction();
        fragmentTransaction.Replace(fragmentContainerView.Id, mapboxFragment, $"mapbox-maui-{fragmentContainerView.Id}");
        fragmentTransaction.CommitAllowingStateLoss();
        return fragmentContainerView;
    }

    protected override void ConnectHandler(PlatformView platformView)
    {
        base.ConnectHandler(platformView);

        if (VirtualView is MapboxView mapboxView)
        {
            mapboxView.AnnotationController = this;
            mapboxView.QueryManager = this;
            mapboxView.MapboxController = this;
            mapboxView.CameraController = this;

            mapboxView.InvokeMapReady();
        }
    }

    protected override void DisconnectHandler(PlatformView platformView)
    {
        if (mapboxFragment != null)
        {
            UnregisterEvents(mapboxFragment);
            mapboxFragment.Dispose();
            mapboxFragment = null;
        }

        if (VirtualView is MapboxView mapboxView)
        {
            mapboxView.AnnotationController = null;
            mapboxView.QueryManager = null;
            mapboxView.CameraController = null;
            mapboxView.MapboxController = null;
        }
        base.DisconnectHandler(platformView);
    }

}

