namespace Mapbox.Maui.Styles;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Mapbox.Maui.Expressions;

public class MapboxLayer : BaseKVContainer
{
    public MapboxLayer(
        string id
        ) : base()
    {
        base.SetProperty<string>(MapboxLayerKey.id, id);
        base.SetProperty<Dictionary<string, object>>(MapboxLayerKey.layout, new Dictionary<string, object>());
        base.SetProperty<Dictionary<string, object>>(MapboxLayerKey.paint, new Dictionary<string, object>());
    }

    public static class MapboxLayerKey
    {
        public const string id = "id";
        public const string type = "type";
        public const string filter = "filter";
        public const string source = "source";
        public const string sourceLayer = "source-layer";
        public const string minZoom = "minzoom";
        public const string maxZoom = "maxzoom";
        public const string layout = "layout";
        public const string paint = "paint";
        public const string visibility = "visibility";
    }

    private readonly Dictionary<string, object> properties;

    protected override MapboxLayer SetProperty<T>(string name, T value, string group = null)
    {
        // Not allow to use empty string as a name
        if (string.IsNullOrWhiteSpace(name)) return this;

        name = name.Trim();

        // Not allow to change id, layout or paint
        if (string.Equals(name, MapboxLayerKey.id, StringComparison.OrdinalIgnoreCase)) return this;
        if (string.Equals(name, MapboxLayerKey.layout, StringComparison.OrdinalIgnoreCase)) return this;
        if (string.Equals(name, MapboxLayerKey.paint, StringComparison.OrdinalIgnoreCase)) return this;
              

        return base.SetProperty(name, value, group) as MapboxLayer;
    }

    public LayerPosition LayerPosition { get; set; }

    public ReadOnlyDictionary<string, object> LayoutProperties
    {
        get => new ReadOnlyDictionary<string, object>(
            GetProperty<Dictionary<string, object>>(MapboxLayerKey.layout, default)
        );
    }

    public ReadOnlyDictionary<string, object> PaintProperties
    {
        get => new ReadOnlyDictionary<string, object>(
            GetProperty<Dictionary<string, object>>(MapboxLayerKey.paint, default)
        );
    }

    public string Id
    {
        get => GetProperty<string>(MapboxLayerKey.id, default);
    }

    public LayerType Type
    {
        get => GetProperty<LayerType>(MapboxLayerKey.type, default);
        protected set => SetProperty<LayerType>(MapboxLayerKey.type, value);
    }

    public DslExpression Filter
    {
        get => GetProperty<DslExpression>(MapboxLayerKey.filter, default);
        set => SetProperty<DslExpression>(MapboxLayerKey.filter, value);
    }

    public string Source
    {
        get => GetProperty<string>(MapboxLayerKey.source, default);
        set => SetProperty<string>(MapboxLayerKey.source, value);
    }

    public string SourceLayer
    {
        get => GetProperty<string>(MapboxLayerKey.sourceLayer, default);
        set => SetProperty<string>(MapboxLayerKey.sourceLayer, value);
    }

    public double? MinZoom
    {
        get => GetProperty<double?>(MapboxLayerKey.minZoom, default);
        set => SetProperty<double?>(MapboxLayerKey.minZoom, value);
    }

    public double? MaxZoom
    {
        get => GetProperty<double?>(MapboxLayerKey.maxZoom, default);
        set => SetProperty<double?>(MapboxLayerKey.maxZoom, value);
    }

    public PropertyValue<Mapbox.Maui.Visibility> Visibility
    {
        get => GetProperty<PropertyValue<Mapbox.Maui.Visibility>>(
            MapboxLayerKey.visibility,
            new PropertyValue<Mapbox.Maui.Visibility>(Mapbox.Maui.Visibility.visible),
            MapboxLayerKey.layout
        );
        set => SetProperty<PropertyValue<Mapbox.Maui.Visibility>>(
            MapboxLayerKey.visibility,
            value,
            MapboxLayerKey.layout
        );
    }
}