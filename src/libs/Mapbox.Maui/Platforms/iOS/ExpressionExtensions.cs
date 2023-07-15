
namespace MapboxMaui;
using Foundation;
using MapboxMaui.Expressions;
using MapboxMapsObjC;

public static class ExpressionExtensions
{
    internal static TMBExpression ToPlatformValue(
        this DslExpression xvalue
    )
    {
        var arguments = xvalue.Select(x => x switch
        {
            DslExpression expression => expression.ToPlatformValue(),
            _ => x.Wrap()
        }).ToArray() ?? Array.Empty<NSObject>();

        return string.IsNullOrWhiteSpace(xvalue.Operator.Value)
            ? TMBExpression.Args(
                arguments
            )
            : TMBExpression.CreateWithOperator(
                xvalue.Operator.ToPlatform(),
                arguments
            );
    }
}

