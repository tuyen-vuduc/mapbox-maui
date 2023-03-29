namespace Mapbox.Maui;

using Android.Widget;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers;
using PlatformView = AndroidX.Fragment.App.FragmentContainerView;
using MapboxMapsStyle = Com.Mapbox.Maps.Style;
using MapboxMapsCameraOptions = Com.Mapbox.Maps.CameraOptions;
using Com.Mapbox.Maps;
using Microsoft.Maui.Controls;
using Com.Mapbox.Maps.Plugin.Scalebar;
using static Google.Android.Material.Tabs.TabLayout;
using Microsoft.Maui.Platform;
using Android.Content;
using AndroidX.Fragment.App;
using System;

public partial class MapboxViewHandler
{
    MapboxFragment mapboxFragment;

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

        var fragmentTransaction = mainActivity.SupportFragmentManager.BeginTransaction();
        fragmentTransaction.Replace(fragmentContainerView.Id, mapboxFragment, $"mapbox-maui-{fragmentContainerView.Id}");
        fragmentTransaction.CommitAllowingStateLoss();
        return fragmentContainerView;
    }

    protected override void DisconnectHandler(PlatformView platformView)
    {
        if (mapboxFragment != null)
        {
            mapboxFragment.MapViewReady -= HandleMapViewReady;
            mapboxFragment?.Dispose();
        }
        base.DisconnectHandler(platformView);
    }

    private void HandleMapViewReady(MapView view)
    {
        (VirtualView as MapboxView)?.InvokeMapReady();

        if (VirtualView.MapReadyCommand?.CanExecute(view) == true)
        {
            VirtualView.MapReadyCommand.Execute(view);
        }
    }
}

static class AdditionalExtensions
{
    internal static MapView GetMapView(this MapboxViewHandler handler)
    {
        var mainActivity = (MauiAppCompatActivity)handler.Context.GetActivity();
        var tag = $"mapbox-maui-{handler.PlatformView.Id}";
        var fragnent = mainActivity.SupportFragmentManager.FindFragmentByTag(tag);
        return (fragnent as MapboxFragment)?.MapView;
    }

    public static MapDebugOptions ToNative(this DebugOption option)
    {
        return option switch
        {
            DebugOption.TileBorders => MapDebugOptions.TileBorders,
            DebugOption.ParseStatus => MapDebugOptions.ParseStatus,
            DebugOption.Timestamps => MapDebugOptions.Timestamps,
            DebugOption.Collision => MapDebugOptions.Collision,
            DebugOption.StencilClip => MapDebugOptions.StencilClip,
            DebugOption.DepthBuffer => MapDebugOptions.DepthBuffer,
            _ => MapDebugOptions.ModelBounds,
        };
    }

    public static IList<MapDebugOptions> ToNative(this IEnumerable<DebugOption> options)
    {
        return options
            .Select(x => x.ToNative())
            .ToList();
    }

    public static string ToNative(this MapboxStyle mapboxStyle)
    {
        return mapboxStyle.BuiltInStyle switch
        {
            MapboxBuiltInStyle.Dark => MapboxMapsStyle.Dark,
            MapboxBuiltInStyle.Light => MapboxMapsStyle.Light,
            MapboxBuiltInStyle.Outdoors => MapboxMapsStyle.Outdoors,
            MapboxBuiltInStyle.MapboxStreets => MapboxMapsStyle.MapboxStreets,
            MapboxBuiltInStyle.Satellite => MapboxMapsStyle.Satellite,
            MapboxBuiltInStyle.SatelliteStreets => MapboxMapsStyle.SatelliteStreets,
            MapboxBuiltInStyle.TrafficDay => MapboxMapsStyle.TrafficDay,
            MapboxBuiltInStyle.TrafficNight => MapboxMapsStyle.TrafficNight,
            _ => mapboxStyle.Uri,
        };
    }

    public static MapboxMapsCameraOptions ToNative(this CameraOptions cameraOptions)
    {
        var cameraOptionsBuilder = new MapboxMapsCameraOptions.Builder();

        if (cameraOptions.Center.HasValue)
        {
            cameraOptionsBuilder.Center(
                Com.Mapbox.Geojson.Point.FromLngLat(
            cameraOptions.Center.Value.Y,
                cameraOptions.Center.Value.X
            ));
        }

        if (cameraOptions.Zoom.HasValue)
        {
            cameraOptionsBuilder.Zoom(new Java.Lang.Double(cameraOptions.Zoom.Value));
        }

        if (cameraOptions.Bearing.HasValue)
        {
            cameraOptionsBuilder.Bearing(new Java.Lang.Double(cameraOptions.Bearing.Value));
        }

        if (cameraOptions.Pitch.HasValue)
        {
            cameraOptionsBuilder.Pitch(new Java.Lang.Double(cameraOptions.Pitch.Value));
        }

        if (cameraOptions.Padding.HasValue)
        {
            cameraOptionsBuilder.Padding(new EdgeInsets(
                cameraOptions.Padding.Value.Top,
                cameraOptions.Padding.Value.Left,
                cameraOptions.Padding.Value.Bottom,
                cameraOptions.Padding.Value.Right
                ));
        }

        if (cameraOptions.Anchor.HasValue)
        {
            cameraOptionsBuilder.Anchor(new ScreenCoordinate(
                cameraOptions.Anchor.Value.X,
                cameraOptions.Anchor.Value.Y
                ));
        }

        return cameraOptionsBuilder.Build();
    }
}

