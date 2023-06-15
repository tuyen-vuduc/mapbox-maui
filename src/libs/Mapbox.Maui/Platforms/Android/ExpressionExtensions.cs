
namespace MapboxMaui;

using System.Collections;
using Com.Mapbox.Maps.Extension.Style.Expressions.Generated;
using MapboxMaui.Expressions;

public static class ExpressionExtensions
{
    internal static Expression ToPlatformValue(
        this DslExpression xvalue
    )
    {
        var expressionBuilder = new Expression.ExpressionBuilder(xvalue.Operator.Value);

        foreach (var argument in xvalue)
        {
            switch (argument)
            {
                case bool value:
                    expressionBuilder.Literal(value);
                    break;
                case int value:
                    expressionBuilder.Literal(value);
                    break;
                case long value:
                    expressionBuilder.Literal(value);
                    break;
                case float value:
                    expressionBuilder.Literal(value);
                    break;
                case double value:
                    expressionBuilder.Literal(value);
                    break;
                case string value:
                    expressionBuilder.Literal(value);
                    break;
                case DslExpression value:
                    expressionBuilder.AddArgument(value.ToPlatformValue());
                    break;
                case IEnumerable value:
                    var items = value.Cast<object>()
                            .Select(x => x.Wrap(true))
                            .Cast<Java.Lang.Object>()
                            .ToList();
                    expressionBuilder.Literal(items);
                    break;
                default:
                    break;
            }
        }

        return expressionBuilder.Build();
    }
}

