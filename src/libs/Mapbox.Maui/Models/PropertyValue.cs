using Mapbox.Maui.Expressions;

namespace Mapbox.Maui;

public record class PropertyValue
{
    public object Constant { get; }
    public DslExpression Expression { get; }

    public PropertyValue(object value)
    {
        if (value is DslExpression expression)
        {
            Expression = expression;
        }
        else
        {
            Constant = value;
        }
    }

    //public static implicit operator PropertyValue(DslExpression expression) => new PropertyValue(expression);
}

