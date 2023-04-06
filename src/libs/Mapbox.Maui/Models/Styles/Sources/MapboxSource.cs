namespace Mapbox.Maui.Styles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class MapboxSource
{
    public MapboxSource(string id)
    {
        properties = new Dictionary<string, object>()
        {
            { "id", id },
        };
        volatileProperties = new Dictionary<string, object>();
    }

    public MapboxSource(string id, string type)
    {
        properties = new Dictionary<string, object>()
        {
            { MapboxSourceKey.id, id },
            { MapboxSourceKey.type, type },
        };
        volatileProperties = new Dictionary<string, object>();
    }

    private readonly Dictionary<string, object> properties;
    private readonly Dictionary<string, object> volatileProperties;

    private static class MapboxSourceKey
    {
        public const string id = nameof(id);
        public const string type = nameof(type);
    }

    public string Id => properties[MapboxSourceKey.id] as string;

    public string Type => properties.TryGetValue(MapboxSourceKey.type, out var value) &&
        value is string stringValue
        ? stringValue : (string)null;

    public MapboxSource SetProperty<T>(string name, T value)
    {
        // Not allow to use empty string as a name
        if (string.IsNullOrWhiteSpace(name)) return this;

        name = name.Trim();

        // Not allow to change id and/or type
        if (string.Equals(name, MapboxSourceKey.id, StringComparison.OrdinalIgnoreCase)) return this;
        if (string.Equals(name, MapboxSourceKey.type, StringComparison.OrdinalIgnoreCase)) return this;

        if (value == null)
        {
            properties.Remove(name);
        }
        else
        {
            properties[name] = value;
        }

        return this;
    }

    public MapboxSource SetVolatileProperty<T>(string name, T value)
    {
        // Not allow to use empty string as a name
        if (string.IsNullOrWhiteSpace(name)) return this;

        name = name.Trim();

        // Not allow to change id and/or type
        if (string.Equals(name, MapboxSourceKey.id, StringComparison.OrdinalIgnoreCase)) return this;
        if (string.Equals(name, MapboxSourceKey.type, StringComparison.OrdinalIgnoreCase)) return this;

        if (value == null)
        {
            volatileProperties.Remove(name);
        }
        else
        {
            volatileProperties[name] = value;
        }

        return this;
    }

    public T GetProperty<T>(string name, T defaultValue)
    {
        // Not allow to use empty string as a name
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid property name");

        name = name.Trim();

        if (properties.TryGetValue(name, out var value) && value is T result)
        {
            return result;
        }

        return defaultValue;
    }

    public T GetVolatileProperty<T>(string name, T defaultValue)
    {
        // Not allow to use empty string as a name
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid property name");

        name = name.Trim();

        if (volatileProperties.TryGetValue(name, out var value) && value is T result)
        {
            return result;
        }

        return defaultValue;
    }

    public ReadOnlyDictionary<string, object> Properties => new ReadOnlyDictionary<string, object>(properties);
    // Properties that only settable after the source is added to the style.
    public ReadOnlyDictionary<string, object> VolatileProperties => new ReadOnlyDictionary<string, object>(volatileProperties);
}

