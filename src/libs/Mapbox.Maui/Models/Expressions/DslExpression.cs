using System.Diagnostics;

namespace MapboxMaui.Expressions;

[DebuggerDisplay("{GetString()}")]
public partial class DslExpression : List<object>
{
    public ExpressionOperator Operator { get; }

    public DslExpression(ExpressionOperator @operator)
    {
        Operator = @operator;
    }

    public DslExpression(ExpressionOperator @operator, params object[] arguments)
        : base(arguments)
    {
        Operator = @operator;
    }

    public DslExpression(params object[] arguments)
        : base(arguments)
    {
    }

    public object[] ToObjects()
    {
        var result = new List<object>();

        if (!string.IsNullOrWhiteSpace(Operator.Value))
        {
            result.Add(Operator);
        }

        foreach (var argument in this)
        {
            switch (argument)
            {
                case DslExpression expression:
                    result.Add(expression.ToObjects());
                    break;
                default:
                    result.Add(argument);
                    break;
            }
        }

        return result.ToArray();
    }

    private string GetString()
    {
        var items = new List<string>();

        if (!string.IsNullOrWhiteSpace(Operator.Value))
        {
            items.Add(Operator.Value);
        }

        foreach (var argument in this)
        {
            switch (argument)
            {
                case DslExpression expression:
                    items.Add(expression.ToString());
                    break;
                default:
                    items.Add(argument.ToString());
                    break;
            }
        }

        return $"[{string.Join(",", items)}]";
    }

    public static DslExpression Args(params object[] arguments) => new(arguments);
}