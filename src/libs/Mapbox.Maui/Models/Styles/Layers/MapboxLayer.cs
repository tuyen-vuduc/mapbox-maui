namespace MapboxMaui.Styles;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MapboxMaui.Expressions;

public class MapboxLayer : BaseKVContainer
{
    public MapboxLayer(
        string id
        ) : base()
    {
        base.SetProperty(MapboxLayerKey.id, id);
        base.SetProperty(MapboxLayerKey.layout, new Dictionary<string, object>());
        base.SetProperty(MapboxLayerKey.paint, new Dictionary<string, object>());
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
        protected set => SetProperty(MapboxLayerKey.type, value);
    }

    public DslExpression Filter
    {
        get => GetProperty<DslExpression>(MapboxLayerKey.filter, default);
        set => SetProperty(MapboxLayerKey.filter, value);
    }

    public string Source
    {
        get => GetProperty<string>(MapboxLayerKey.source, default);
        set => SetProperty(MapboxLayerKey.source, value);
    }

    public string SourceLayer
    {
        get => GetProperty<string>(MapboxLayerKey.sourceLayer, default);
        set => SetProperty(MapboxLayerKey.sourceLayer, value);
    }

    public double? MinZoom
    {
        get => GetProperty<double?>(MapboxLayerKey.minZoom, default);
        set => SetProperty(MapboxLayerKey.minZoom, value);
    }

    public double? MaxZoom
    {
        get => GetProperty<double?>(MapboxLayerKey.maxZoom, default);
        set => SetProperty(MapboxLayerKey.maxZoom, value);
    }

    public PropertyValue<Visibility> Visibility
    {
        get => GetProperty(
            MapboxLayerKey.visibility,
            new PropertyValue<Visibility>(MapboxMaui.Visibility.Visible),
            MapboxLayerKey.layout
        );
        set => SetProperty(
            MapboxLayerKey.visibility,
            value,
            MapboxLayerKey.layout
        );
    }
}