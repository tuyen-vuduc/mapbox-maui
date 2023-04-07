namespace Mapbox.Maui.Styles;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Mapbox.Maui.Expressions;

public class MapboxLayer
{
    public MapboxLayer(
        string id
        )
    {
        properties = new Dictionary<string, object>()
        {
            { MapboxLayerKey.id, id },
            { MapboxLayerKey.layout, new Dictionary<string, object>() },
            { MapboxLayerKey.paint, new Dictionary<string, object>() },
        };
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

    public MapboxLayer SetProperty<T>(string name, T value, string group = null)
    {
        // Not allow to use empty string as a name
        if (string.IsNullOrWhiteSpace(name)) return this;

        name = name.Trim();

        // Not allow to change tilejson and/or tiles
        if (string.Equals(name, MapboxLayerKey.id, StringComparison.OrdinalIgnoreCase)) return this;
        if (string.Equals(name, MapboxLayerKey.layout, StringComparison.OrdinalIgnoreCase)) return this;
        if (string.Equals(name, MapboxLayerKey.paint, StringComparison.OrdinalIgnoreCase)) return this;

        void SetOrRemoveProperty(Dictionary<string, object> container, string key, T value)
        {
            if (value == null)
            {
                container.Remove(name);
            }
            else
            {
                container[name] = value;
            }
        }

        if (group == null ||
            !properties.TryGetValue(group, out var groupValue) ||
            groupValue is not Dictionary<string, object> groupProperties)
        {
            SetOrRemoveProperty(properties, name, value);
        }
        else
        {
            SetOrRemoveProperty(groupProperties, name, value);
        }

        return this;
    }

    public T GetProperty<T>(string name, T defaultValue, string group = null)
    {
        // Not allow to use empty string as a name
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid property name");

        name = name.Trim();

        if (group == null ||
            !properties.TryGetValue(group, out var groupValue) ||
            groupValue is not Dictionary<string, object> groupProperties)
        {
            if (properties.TryGetValue(name, out var value) && value is T result)
            {
                return result;
            }
        }
        else if (groupProperties.TryGetValue(name, out var value) && value is T result)
        {
            return result;
        }

        return defaultValue;
    }

    public LayerPosition LayerPosition { get; set; }

    public ReadOnlyDictionary<string, object> Properties => new ReadOnlyDictionary<string, object>(properties);

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

    public PropertyValue Visibility
    {
        get => GetProperty<PropertyValue>(
            MapboxLayerKey.visibility,
            new PropertyValue(Mapbox.Maui.Visibility.visible),
            MapboxLayerKey.layout
        );
        set => SetProperty<PropertyValue>(
            MapboxLayerKey.visibility,
            value,
            MapboxLayerKey.layout
        );
    }
}