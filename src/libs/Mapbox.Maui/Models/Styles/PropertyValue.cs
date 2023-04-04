namespace Mapbox.Maui.Styles;

public record class PropertyValue<T>
{
    public T Value { get; init; }

    public string Name { get; init; }

    public PropertyValue()
    {

    }

    public PropertyValue(string name, T value)
    {
        Name = name;
        Value = value;
    }
}

