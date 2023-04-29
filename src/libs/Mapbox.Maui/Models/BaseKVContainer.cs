using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace MapboxMaui;

public abstract class BaseKVContainer : INotifyCollectionChanged
{
    protected BaseKVContainer()
    {
        properties = new Dictionary<string, object>();
    }

    public event NotifyCollectionChangedEventHandler CollectionChanged;

    public ReadOnlyDictionary<string, object> Properties => new(properties);

    private readonly Dictionary<string, object> properties;

    protected virtual BaseKVContainer SetProperty<T>(string name, T value, string group = null)
    {
        // Not allow to use empty string as a name
        if (string.IsNullOrWhiteSpace(name)) return this;

        name = name.Trim();

        void SetOrRemoveProperty(Dictionary<string, object> container, string key, T value)
        {
            if (value == null)
            {
                if (!container.ContainsKey(key)) return;

                CollectionChanged?.Invoke(
                    this,
                    new NotifyCollectionChangedEventArgs(
                        NotifyCollectionChangedAction.Remove,
                        container.Single(x => x.Key == key)
                    )
                );

                container.Remove(name);
            }
            else
            {
                var action = container.ContainsKey(key)
                    ? NotifyCollectionChangedAction.Replace
                    : NotifyCollectionChangedAction.Add;

                container[name] = value;

                CollectionChanged?.Invoke(
                    this,
                    new NotifyCollectionChangedEventArgs(
                        action,
                        container.Single(x => x.Key == key)
                    )
                );

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

    protected virtual T GetProperty<T>(string name, T defaultValue, string group = null)
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
}
