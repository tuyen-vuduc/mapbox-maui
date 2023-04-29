namespace MapboxMaui.Styles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class MapboxSource : BaseKVContainer
{
    public MapboxSource(string id)
        : base()
    {
        base.SetProperty(MapboxSourceKey.id, id);

        volatileProperties = new Dictionary<string, object>();
    }

    public MapboxSource(string id, string type)
        : this(id)
    {
        base.SetProperty(MapboxSourceKey.type, type);
    }

    private readonly Dictionary<string, object> volatileProperties;

    private static class MapboxSourceKey
    {
        public const string id = nameof(id);
        public const string type = nameof(type);
    }

    public string Id => GetProperty<string>(MapboxSourceKey.id, default);

    public string Type => GetProperty<string>(MapboxSourceKey.type, default);

    protected override BaseKVContainer SetProperty<T>(string name, T value, string group = null)
    {
        // Not allow to use empty string as a name
        if (string.IsNullOrWhiteSpace(name)) return this;

        name = name.Trim();

        // Not allow to change id and/or type
        if (string.Equals(name, MapboxSourceKey.id, StringComparison.OrdinalIgnoreCase)) return this;
        if (string.Equals(name, MapboxSourceKey.type, StringComparison.OrdinalIgnoreCase)) return this;

        return base.SetProperty(name, value, group);
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

    // Properties that only settable after the source is added to the style.
    public ReadOnlyDictionary<string, object> VolatileProperties => new ReadOnlyDictionary<string, object>(volatileProperties);
}

