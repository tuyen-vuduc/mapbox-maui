namespace MapboxMaui;

using PlatformView = AndroidX.Fragment.App.FragmentContainerView;
using PlatformPolygonAnnotationManager = Com.Mapbox.Maps.Plugin.Annotation.Generated.PolygonAnnotationManager;
using PlatformCircleAnnotationManager = Com.Mapbox.Maps.Plugin.Annotation.Generated.CircleAnnotationManager;
using PlatformPointAnnotationManager = Com.Mapbox.Maps.Plugin.Annotation.Generated.PointAnnotationManager;
using MapboxMapsStyle = Com.Mapbox.Maps.Style;
using Com.Mapbox.Maps;
using Com.Mapbox.Maps.Plugin.Scalebar;
using Microsoft.Maui.Platform;
using Android.Content;
using MapboxMaui.Annotations;
using Com.Mapbox.Maps.Plugin.Annotation;
using Android.Graphics;
using Com.Mapbox.Geojson;

public partial class MapboxViewHandler : IAnnotationController
{
    MapboxFragment mapboxFragment;

    private static void HandleLightChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var mapView = handler.GetMapView();
        if (mapView == null) return;

        if (view.Light == null) return;

        mapView.MapboxMap.Style.SetStyleLight(
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

        foreach (var source in view.Sources)
        {
            var addStyleSourceResult = mapView.MapboxMap.Style.AddStyleSource(
                source.Id,
                source.ToPlatformValue()
            );

            if (addStyleSourceResult.IsError)
            {
                System.Diagnostics.Debug.WriteLine(addStyleSourceResult.Error);
            }

            if (source is Styles.GeoJSONSource geojsonSource
                && geojsonSource.Data is Styles.RawGeoJSONObject raw)
            {
                var data = GeoJSONSourceData.ValueOf(raw.Data);
                var setStyleGeoJSONSourceDataResult = mapView.MapboxMap.Style.SetStyleGeoJSONSourceData(source.Id, data);

                if (setStyleGeoJSONSourceDataResult.IsError)
                {
                    System.Diagnostics.Debug.WriteLine(addStyleSourceResult.Error);
                }
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
        if (view.ScaleBarVisibility == OrnamentVisibility.Hidden)
        {
            scaleBarPlugin.Enabled = false;
            return;
        }

        scaleBarPlugin.Enabled = true;

    }

    private static void HandleMapboxStyleChanged(MapboxViewHandler handler, IMapboxView view)
    {
        var styleUri = view.MapboxStyle.ToNative();

        if (string.IsNullOrWhiteSpace(styleUri))
        {
            styleUri = MapboxMapsStyle.MapboxStreets;
        }

        handler.GetMapView()?.MapboxMap.LoadStyleUri(styleUri);
    }

    protected override PlatformView CreatePlatformView()
    {
        var mainActivity = (MauiAppCompatActivity)Context.GetActivity();

        var fragmentContainerView = new PlatformView(Context)
        {
            Id = Android.Views.View.GenerateViewId(),
        };
        mapboxFragment = new MapboxFragment();
        mapboxFragment.MapViewReady += HandleMapViewReady;
        mapboxFragment.StyleLoaded += HandleStyleLoaded;
        mapboxFragment.MapLoaded += HandleMapLoaded;

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
        }
    }

    protected override void DisconnectHandler(PlatformView platformView)
    {
        if (mapboxFragment != null)
        {
            mapboxFragment.MapViewReady -= HandleMapViewReady;
            mapboxFragment.StyleLoaded -= HandleStyleLoaded;
            mapboxFragment.MapLoaded -= HandleMapLoaded;
            mapboxFragment.Dispose();
            mapboxFragment = null;
        }
        base.DisconnectHandler(platformView);
    }

    private void HandleMapViewReady(MapView view)
        => (VirtualView as MapboxView)?.InvokeMapReady();

    private void HandleMapLoaded(MapView view)
        => (VirtualView as MapboxView)?.InvokeMapLoaded();

    private void HandleStyleLoaded(MapView view)
        => (VirtualView as MapboxView)?.InvokeStyleLoaded();

    public IPolygonAnnotationManager CreatePolygonAnnotationManager(
        string id,
        Styles.LayerPosition layerPosition)
    {
        var mapView = mapboxFragment?.MapView;

        if (mapView == null) return null;

        var nativeManager = AnnotationPluginImplKt
            .GetAnnotations(mapView)
            .CreateAnnotationManager(
                AnnotationType.PolygonAnnotation,
                new AnnotationConfig(null, id, id, null)
            ) as PlatformPolygonAnnotationManager;

        return new PolygonAnnotationManager(id, nativeManager);
    }

    public ICircleAnnotationManager CreateCircleAnnotationManager(
        string id,
        Styles.LayerPosition layerPosition)
    {
        var mapView = mapboxFragment?.MapView;

        if (mapView == null) return null;

        var nativeManager = AnnotationPluginImplKt
            .GetAnnotations(mapView)
            .CreateAnnotationManager(
                AnnotationType.CircleAnnotation,
                new AnnotationConfig(null, id, id, null)
            ) as PlatformCircleAnnotationManager;

        return new CircleAnnotationManager(id, nativeManager);
    }

    public IPointAnnotationManager CreatePointAnnotationManager(
        string id,
        Styles.LayerPosition layerPosition,
        Annotations.ClusterOptions clusterOptions = null)
    {
        var mapView = mapboxFragment?.MapView;

        if (mapView == null) return null;

        var options = new AnnotationSourceOptions(
            null, null, null, null,
            new Com.Mapbox.Maps.Plugin.Annotation.ClusterOptions(
                true,
                (long)clusterOptions.ClusterRadius,
                clusterOptions.CircleRadius?.Wrap(),
                18.0,
                clusterOptions.TextColor?.Wrap(),
                Color.White,
                clusterOptions.TextSize?.Wrap(),
                12.0,
                clusterOptions.TextField?.Wrap(),
                (long)clusterOptions.ClusterMaxZoom,
                new List<Kotlin.Pair> {
                    new Kotlin.Pair(new Java.Lang.Integer(100), new Java.Lang.Integer(Color.Red)),
                    new Kotlin.Pair(new Java.Lang.Integer(50), new Java.Lang.Integer(Color.Blue)),
                    new Kotlin.Pair(new Java.Lang.Integer(0), new Java.Lang.Integer(Color.Green)),
                },
                null //new Dictionary<string, Java.Lang.Object>(
                //    clusterOptions.ClusterProperties?
                //        .Select(
                //            x => new KeyValuePair<string, Java.Lang.Object>(
                //                x.Key,
                //                x.Value.Wrap()
                //            )
                //        )
                //    )
                ));
        var nativeManager = AnnotationPluginImplKt
            .GetAnnotations(mapView)
            .CreateAnnotationManager(
                AnnotationType.PointAnnotation,
                new AnnotationConfig(null, id, id, options)
            ) as PlatformPointAnnotationManager;

        return new PointAnnotationManager(id, nativeManager);
    }
}

