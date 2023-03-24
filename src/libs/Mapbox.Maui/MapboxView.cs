using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Security.AccessControl;
using Microsoft.Maui.Handlers;

namespace Mapbox.Maui;

public class MapboxView : View, IMapboxView
{
    public static readonly BindableProperty MapCenterProperty = BindableProperty.Create(
       nameof(MapCenter),
       typeof(Microsoft.Maui.Graphics.Point?),
       typeof(MapboxView),
       default(Microsoft.Maui.Graphics.Point?)
    );
    public Microsoft.Maui.Graphics.Point? MapCenter
    {
        get => (Microsoft.Maui.Graphics.Point?)GetValue(MapCenterProperty);
        set => SetValue(MapCenterProperty, value);
    }

    public static readonly BindableProperty AccessTokenProperty = BindableProperty.Create(
       nameof(AccessToken),
       typeof(string),
       typeof(MapboxView),
       default(string)
    );
    public string AccessToken
    {
        get => (string)GetValue(AccessTokenProperty);
        set => SetValue(AccessTokenProperty, value);
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

    public static readonly BindableProperty MapZoomProperty = BindableProperty.Create(
       nameof(MapZoom),
       typeof(float?),
       typeof(MapboxView),
       default(float?)
    );
    public float? MapZoom
    {
        get => (float?)GetValue(MapZoomProperty);
        set => SetValue(MapZoomProperty, value);
    }
}