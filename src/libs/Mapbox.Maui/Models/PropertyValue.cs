using MapboxMaui.Expressions;

namespace MapboxMaui;

public interface IPropertyValue
{
    public object Value { get; }
}

public record class PropertyValue<T> : IPropertyValue
{
    public T Constant { get; }
    public DslExpression Expression { get; }

    public object Value => Expression ?? (object)Constant;

    public PropertyValue(T value)
    {
        if (value is DslExpression expression)
        {
            throw new ArgumentException("Argument must not be a DslExpression", nameof(value));
        }

        Constant = value;
        Expression = null;
    }

    public PropertyValue(DslExpression expression)
    {
        Expression = expression;
        Constant = default;
    }
}

