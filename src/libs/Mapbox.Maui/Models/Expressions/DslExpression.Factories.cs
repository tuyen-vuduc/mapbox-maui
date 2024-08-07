namespace MapboxMaui.Expressions;

partial class DslExpression
{
    public static DslExpression Subtract(params object[] arguments) => new(ExpressionOperator.Subtract, arguments);
    public static DslExpression Not(params object[] arguments) => new(ExpressionOperator.Not, arguments);
    public static DslExpression Neq(params object[] arguments) => new(ExpressionOperator.Neq, arguments);
    public static DslExpression Product(params object[] arguments) => new(ExpressionOperator.Product, arguments);
    public static DslExpression Division(params object[] arguments) => new(ExpressionOperator.Division, arguments);
    public static DslExpression Mod(params object[] arguments) => new(ExpressionOperator.Mod, arguments);
    public static DslExpression Pow(params object[] arguments) => new(ExpressionOperator.Pow, arguments);
    public static DslExpression Sum(params object[] arguments) => new(ExpressionOperator.Sum, arguments);
    public static DslExpression Lt(params object[] arguments) => new(ExpressionOperator.Lt, arguments);
    public static DslExpression Lte(params object[] arguments) => new(ExpressionOperator.Lte, arguments);
    public static DslExpression Eq(params object[] arguments) => new(ExpressionOperator.Eq, arguments);
    public static DslExpression Gt(params object[] arguments) => new(ExpressionOperator.Gt, arguments);
    public static DslExpression Gte(params object[] arguments) => new(ExpressionOperator.Gte, arguments);
    public static DslExpression Abs(params object[] arguments) => new(ExpressionOperator.Abs, arguments);
    public static DslExpression Accumulated(params object[] arguments) => new(ExpressionOperator.Accumulated, arguments);
    public static DslExpression Acos(params object[] arguments) => new(ExpressionOperator.Acos, arguments);
    public static DslExpression All(params object[] arguments) => new(ExpressionOperator.All, arguments);
    public static DslExpression Any(params object[] arguments) => new(ExpressionOperator.Any, arguments);
    public static DslExpression Array(params object[] arguments) => new(ExpressionOperator.Array, arguments);
    public static DslExpression Asin(params object[] arguments) => new(ExpressionOperator.Asin, arguments);
    public static DslExpression At(params object[] arguments) => new(ExpressionOperator.At, arguments);
    public static DslExpression Atan(params object[] arguments) => new(ExpressionOperator.Atan, arguments);
    public static DslExpression Boolean(params object[] arguments) => new(ExpressionOperator.Boolean, arguments);
    public static DslExpression SwitchCase(params object[] arguments) => new(ExpressionOperator.SwitchCase, arguments);
    public static DslExpression Ceil(params object[] arguments) => new(ExpressionOperator.Ceil, arguments);
    public static DslExpression Coalesce(params object[] arguments) => new(ExpressionOperator.Coalesce, arguments);
    public static DslExpression Collator(params object[] arguments) => new(ExpressionOperator.Collator, arguments);
    public static DslExpression Concat(params object[] arguments) => new(ExpressionOperator.Concat, arguments);
    public static DslExpression Cos(params object[] arguments) => new(ExpressionOperator.Cos, arguments);
    public static DslExpression Distance(params object[] arguments) => new(ExpressionOperator.Distance, arguments);
    public static DslExpression DistanceFromCenter(params object[] arguments) => new(ExpressionOperator.DistanceFromCenter, arguments);
    public static DslExpression Downcase(params object[] arguments) => new(ExpressionOperator.Downcase, arguments);
    public static DslExpression E(params object[] arguments) => new(ExpressionOperator.E, arguments);
    public static DslExpression FeatureState(params object[] arguments) => new(ExpressionOperator.FeatureState, arguments);
    public static DslExpression Floor(params object[] arguments) => new(ExpressionOperator.Floor, arguments);
    public static DslExpression Format(params object[] arguments) => new(ExpressionOperator.Format, arguments);
    public static DslExpression GeometryType(params object[] arguments) => new(ExpressionOperator.GeometryType, arguments);
    public static DslExpression Get(params object[] arguments) => new(ExpressionOperator.Get, arguments);
    public static DslExpression Has(params object[] arguments) => new(ExpressionOperator.Has, arguments);
    public static DslExpression HeatmapDensity(params object[] arguments) => new(ExpressionOperator.HeatmapDensity, arguments);
    public static DslExpression Id(params object[] arguments) => new(ExpressionOperator.Id, arguments);
    public static DslExpression Image(params object[] arguments) => new(ExpressionOperator.Image, arguments);
    public static DslExpression InExpression(params object[] arguments) => new(ExpressionOperator.InExpression, arguments);
    public static DslExpression IndexOf(params object[] arguments) => new(ExpressionOperator.IndexOf, arguments);
    public static DslExpression Interpolate(params object[] arguments) => new(ExpressionOperator.Interpolate, arguments);
    public static DslExpression IsSupportedScript(params object[] arguments) => new(ExpressionOperator.IsSupportedScript, arguments);
    public static DslExpression Length(params object[] arguments) => new(ExpressionOperator.Length, arguments);
    public static DslExpression LetExpression(params object[] arguments) => new(ExpressionOperator.LetExpression, arguments);
    public static DslExpression LineProgress(params object[] arguments) => new(ExpressionOperator.LineProgress, arguments);
    public static DslExpression Literal(params object[] arguments) => new(ExpressionOperator.Literal, arguments);
    public static DslExpression Ln(params object[] arguments) => new(ExpressionOperator.Ln, arguments);
    public static DslExpression Ln2(params object[] arguments) => new(ExpressionOperator.Ln2, arguments);
    public static DslExpression Log10(params object[] arguments) => new(ExpressionOperator.Log10, arguments);
    public static DslExpression Log2(params object[] arguments) => new(ExpressionOperator.Log2, arguments);
    public static DslExpression Match(params object[] arguments) => new(ExpressionOperator.Match, arguments);
    public static DslExpression Max(params object[] arguments) => new(ExpressionOperator.Max, arguments);
    public static DslExpression Min(params object[] arguments) => new(ExpressionOperator.Min, arguments);
    public static DslExpression Number(params object[] arguments) => new(ExpressionOperator.Number, arguments);
    public static DslExpression NumberFormat(params object[] arguments) => new(ExpressionOperator.NumberFormat, arguments);
    public static DslExpression ObjectExpression(params object[] arguments) => new(ExpressionOperator.ObjectExpression, arguments);
    public static DslExpression Pi(params object[] arguments) => new(ExpressionOperator.Pi, arguments);
    public static DslExpression Pitch(params object[] arguments) => new(ExpressionOperator.Pitch, arguments);
    public static DslExpression Properties(params object[] arguments) => new(ExpressionOperator.Properties, arguments);
    public static DslExpression ResolvedLocale(params object[] arguments) => new(ExpressionOperator.ResolvedLocale, arguments);
    public static DslExpression Rgb(params object[] arguments) => new(ExpressionOperator.Rgb, arguments);
    public static DslExpression Rgba(params object[] arguments) => new(ExpressionOperator.Rgba, arguments);
    public static DslExpression Round(params object[] arguments) => new(ExpressionOperator.Round, arguments);
    public static DslExpression Sin(params object[] arguments) => new(ExpressionOperator.Sin, arguments);
    public static DslExpression SkyRadialProgress(params object[] arguments) => new(ExpressionOperator.SkyRadialProgress, arguments);
    public static DslExpression Slice(params object[] arguments) => new(ExpressionOperator.Slice, arguments);
    public static DslExpression Sqrt(params object[] arguments) => new(ExpressionOperator.Sqrt, arguments);
    public static DslExpression Step(params object[] arguments) => new(ExpressionOperator.Step, arguments);
    public static DslExpression String(params object[] arguments) => new(ExpressionOperator.String, arguments);
    public static DslExpression Tan(params object[] arguments) => new(ExpressionOperator.Tan, arguments);
    public static DslExpression ToBoolean(params object[] arguments) => new(ExpressionOperator.ToBoolean, arguments);
    public static DslExpression ToColor(params object[] arguments) => new(ExpressionOperator.ToColor, arguments);
    public static DslExpression ToNumber(params object[] arguments) => new(ExpressionOperator.ToNumber, arguments);
    public static DslExpression ToRgba(params object[] arguments) => new(ExpressionOperator.ToRgba, arguments);
    public static DslExpression ToStringX(params object[] arguments) => new(ExpressionOperator.ToStringX, arguments);
    public static DslExpression TypeofExpression(params object[] arguments) => new(ExpressionOperator.TypeofExpression, arguments);
    public static DslExpression Upcase(params object[] arguments) => new(ExpressionOperator.Upcase, arguments);
    public static DslExpression VarExpression(params object[] arguments) => new(ExpressionOperator.VarExpression, arguments);
    public static DslExpression Within(params object[] arguments) => new(ExpressionOperator.Within, arguments);
    public static DslExpression Zoom(params object[] arguments) => new(ExpressionOperator.Zoom, arguments);
    public static DslExpression Linear(params object[] arguments) => new(ExpressionOperator.Linear, arguments);
    public static DslExpression Exponential(params object[] arguments) => new(ExpressionOperator.Exponential, arguments);
    public static DslExpression CubicBezier(params object[] arguments) => new(ExpressionOperator.CubicBezier, arguments);
}