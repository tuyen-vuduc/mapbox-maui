namespace MapboxMaui;

public static partial class DslOperatorExtensions 
{
    public static MapboxMapsObjC.TMBExpressionOperator ToPlatform(this DslOperator value)
    {
        return new MapboxMapsObjC.TMBExpressionOperator(value.Value);
    }

    public static DslOperator ToPlatform(this MapboxMapsObjC.TMBExpressionOperator value)
    {
        return value.RawValue;
    }
}