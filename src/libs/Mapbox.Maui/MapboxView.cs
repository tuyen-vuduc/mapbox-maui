using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Security.AccessControl;
using System.Windows.Input;
using Mapbox.Maui.Styles;
using Microsoft.Maui.Handlers;

namespace Mapbox.Maui;

public partial class MapboxView : View, IMapboxView
{
    public static readonly BindableProperty LayersProperty = BindableProperty.Create(
       nameof(Layers),
       typeof(IEnumerable<MapboxLayer>),
       typeof(MapboxView)
    );
    public IEnumerable<MapboxLayer> Layers
    {
        get => (IEnumerable<MapboxLayer>)GetValue(LayersProperty);
        set => SetValue(LayersProperty, value);
    }

    public static readonly BindableProperty TerrainProperty = BindableProperty.Create(
       nameof(Terrain),
       typeof(Terrain),
       typeof(MapboxView)
    );
    public Terrain Terrain
    {
        get => (Terrain)GetValue(TerrainProperty);
        set => SetValue(TerrainProperty, value);
    }

    public static readonly BindableProperty LightProperty = BindableProperty.Create(
       nameof(Light),
       typeof(Light),
       typeof(MapboxView)
    );
    public Light Light
    {
        get => (Light)GetValue(LightProperty);
        set => SetValue(LightProperty, value);
    }

    public static readonly BindableProperty SourcesProperty = BindableProperty.Create(
       nameof(Sources),
       typeof(IEnumerable<MapboxSource>),
       typeof(MapboxView)
    );
    public IEnumerable<MapboxSource> Sources
    {
        get => (IEnumerable<MapboxSource>)GetValue(SourcesProperty);
        set => SetValue(SourcesProperty, value);
    }

    public static readonly BindableProperty DebugOptionsProperty = BindableProperty.Create(
       nameof(DebugOptions),
       typeof(DebugOption[]),
       typeof(MapboxView)
    );
    public DebugOption[] DebugOptions
    {
        get => (DebugOption[])GetValue(DebugOptionsProperty);
        set => SetValue(DebugOptionsProperty, value);
    }

    public static readonly BindableProperty ScaleBarVisibilityProperty = BindableProperty.Create(
       nameof(ScaleBarVisibility),
       typeof(OrnamentVisibility),
       typeof(MapboxView),
       OrnamentVisibility.Hidden
    );
    public OrnamentVisibility ScaleBarVisibility
    {
        get => (OrnamentVisibility)GetValue(ScaleBarVisibilityProperty);
        set => SetValue(ScaleBarVisibilityProperty, value);
    }

    public static readonly BindableProperty CameraOptionsProperty = BindableProperty.Create(
       nameof(CameraOptions),
       typeof(CameraOptions),
       typeof(MapboxView),
       default(CameraOptions)
    );
    public CameraOptions CameraOptions
    {
        get => (CameraOptions)GetValue(CameraOptionsProperty);
        set => SetValue(CameraOptionsProperty, value);
    }

    public static readonly BindableProperty MapCenterProperty = BindableProperty.Create(
       nameof(MapCenter),
       typeof(Microsoft.Maui.Graphics.Point?),
       typeof(MapboxView),
       default(Microsoft.Maui.Graphics.Point?)
    );
    public Microsoft.Maui.Graphics.Point? MapCenter
    {
        get => CameraOptions.Center;
        set => CameraOptions = CameraOptions with
        {
            Center = value
        };
    }

    public static readonly BindableProperty MapPaddingProperty = BindableProperty.Create(
       nameof(MapPadding),
       typeof(Thickness?),
       typeof(MapboxView),
       default(Thickness?)
    );
    public Thickness? MapPadding
    {
        get => CameraOptions.Padding;
        set => CameraOptions = CameraOptions with
        {
            Padding = value
        };
    }

    public static readonly BindableProperty MapAnchorProperty = BindableProperty.Create(
       nameof(MapAnchor),
       typeof(Point?),
       typeof(MapboxView),
       default(Point?)
    );
    public Point? MapAnchor
    {
        get => CameraOptions.Anchor;
        set => CameraOptions = CameraOptions with
        {
            Anchor = value
        };
    }

    public static readonly BindableProperty MapZoomProperty = BindableProperty.Create(
       nameof(MapZoom),
       typeof(float?),
       typeof(MapboxView),
       default(float?)
    );
    public float? MapZoom
    {
        get => CameraOptions.Zoom;
        set => CameraOptions = CameraOptions with
        {
            Zoom = value
        };
    }

    public static readonly BindableProperty MapBearingProperty = BindableProperty.Create(
       nameof(MapBearing),
       typeof(float?),
       typeof(MapboxView),
       default(float?)
    );
    public float? MapBearing
    {
        get => CameraOptions.Bearing;
        set => CameraOptions = CameraOptions with
        {
            Bearing = value
        };
    }

    public static readonly BindableProperty MapPitchProperty = BindableProperty.Create(
       nameof(MapPitch),
       typeof(float?),
       typeof(MapboxView),
       default(float?)
    );
    public float? MapPitch
    {
        get => CameraOptions.Pitch;
        set => CameraOptions = CameraOptions with
        {
            Pitch = value
        };
    }

    public static readonly BindableProperty MapboxStyleProperty = BindableProperty.Create(
       nameof(MapboxStyle),
       typeof(MapboxStyle),
       typeof(MapboxView),
       default(MapboxStyle)
    );
    public MapboxStyle MapboxStyle
    {
        get => (MapboxStyle)GetValue(MapboxStyleProperty);
        set => SetValue(MapboxStyleProperty, value);
    }
}