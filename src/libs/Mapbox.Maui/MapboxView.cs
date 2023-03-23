using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Security.AccessControl;
using Microsoft.Maui.Handlers;

namespace Mapbox.Maui;

public class MapboxStyleTypeConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
        return sourceType == typeof(string) || sourceType == typeof(MapboxBuiltInStyle);
    }

    public override bool CanConvertTo(ITypeDescriptorContext context, [NotNullWhen(true)] Type destinationType)
    {
        return destinationType == typeof(string);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        return value is MapboxStyle mapboxStyle ? (string)mapboxStyle : null;
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is MapboxBuiltInStyle builtInStyle) return (MapboxStyle)builtInStyle;

        if (value is string builtStyleOrUri)
        {
            if(Enum.TryParse<MapboxBuiltInStyle>(builtStyleOrUri, out var builtInStyle1)
                && builtInStyle1 != MapboxBuiltInStyle.None)
            {
                return (MapboxStyle)builtInStyle1;
            }

            return (MapboxStyle)builtStyleOrUri;
        }

        return (MapboxStyle)MapboxBuiltInStyle.None;
    }
}

[TypeConverter(typeof(MapboxStyleTypeConverter))]
public struct MapboxStyle
{
    public string Uri { get; private set; }
    public MapboxBuiltInStyle BuiltInStyle { get; private set; }

    public MapboxStyle(string uri)
    {
        Uri = uri;
    }

    public MapboxStyle(MapboxBuiltInStyle builtInStyle)
    {
        BuiltInStyle = builtInStyle;
    }

    public static implicit operator string(MapboxStyle mapboxStyle) => mapboxStyle.BuiltInStyle != MapboxBuiltInStyle.None
        && !string.IsNullOrWhiteSpace(mapboxStyle.Uri)
        ? mapboxStyle.Uri
        : mapboxStyle.BuiltInStyle.ToString();

    public static explicit operator MapboxBuiltInStyle(MapboxStyle mapboxStyle) => mapboxStyle.BuiltInStyle;

    public static explicit operator MapboxStyle(MapboxBuiltInStyle builtInStyle) => new MapboxStyle
    {
        BuiltInStyle = builtInStyle,
    };

    public static explicit operator MapboxStyle(string uri) => new MapboxStyle
    {
        Uri = uri,
    };

    public override string ToString() => $"BuiltinStyle: {BuiltInStyle}, Uri: {Uri}";
}

public enum MapboxBuiltInStyle
{
    None,
    Dark,
    Light,
    Outdoors,
    MapboxStreets,
    Satellite,
    SatelliteStreets,
    TrafficDay,
    TrafficNight,
}

public interface IMapboxView : IView
{
    public string AccessToken { get; set; }
    public MapboxStyle MapboxStyle { get; set; }

    public Point? Center { get; set; }
}

public class MapboxView : View, IMapboxView
{
    public static readonly BindableProperty CenterProperty = BindableProperty.Create(
       nameof(Center),
       typeof(Point?),
       typeof(MapboxView),
       default(Point?)
    );
    public Point? Center
    {
        get => (Point?)GetValue(CenterProperty);
        set => SetValue(CenterProperty, value);
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
}