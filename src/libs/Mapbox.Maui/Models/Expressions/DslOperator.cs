namespace MapboxMaui.Expressions;

public struct DslOperator : INamedString
{
    public string Value { get; }

    private DslOperator(string op)
    {
        Value = op;
    }

    public override string ToString() => Value;

    public static implicit operator string(DslOperator value) => value.Value;
    public static implicit operator DslOperator(string value) => new (value);

    public static readonly DslOperator Subtract = new("-");
    public static readonly DslOperator Not = new("!");
    public static readonly DslOperator Neq = new("!=");
    public static readonly DslOperator Product = new("*");
    public static readonly DslOperator Division = new("/");
    public static readonly DslOperator Mod = new("%");
    public static readonly DslOperator Pow = new("^");
    public static readonly DslOperator Sum = new("+");
    public static readonly DslOperator Lt = new("<");
    public static readonly DslOperator Lte = new("<=");
    public static readonly DslOperator Eq = new("==");
    public static readonly DslOperator Gt = new(">");
    public static readonly DslOperator Gte = new(">=");
    public static readonly DslOperator Abs = new("abs");
    public static readonly DslOperator Accumulated = new("accumulated");
    public static readonly DslOperator Acos = new("acos");
    public static readonly DslOperator All = new("all");
    public static readonly DslOperator Any = new("any");
    public static readonly DslOperator Array = new("array");
    public static readonly DslOperator Asin = new("asin");
    public static readonly DslOperator At = new("at");
    public static readonly DslOperator Atan = new("atan");
    public static readonly DslOperator Boolean = new("boolean");
    public static readonly DslOperator SwitchCase = new("case");
    public static readonly DslOperator Ceil = new("ceil");
    public static readonly DslOperator Coalesce = new("coalesce");
    public static readonly DslOperator Collator = new("collator");
    public static readonly DslOperator Concat = new("concat");
    public static readonly DslOperator Config = new("config");
    public static readonly DslOperator Cos = new("cos");
    public static readonly DslOperator Distance = new("distance");
    public static readonly DslOperator DistanceFromCenter = new("distance-from-center");
    public static readonly DslOperator Downcase = new("downcase");
    public static readonly DslOperator E = new("e");
    public static readonly DslOperator FeatureState = new("feature-state");
    public static readonly DslOperator Floor = new("floor");
    public static readonly DslOperator Format = new("format");
    public static readonly DslOperator GeometryType = new("geometry-type");
    public static readonly DslOperator Get = new("get");
    public static readonly DslOperator Has = new("has");
    public static readonly DslOperator HeatmapDensity = new("heatmap-density");
    public static readonly DslOperator Hsl = new("hsl");
    public static readonly DslOperator Hsla = new("hsla");
    public static readonly DslOperator Id = new("id");
    public static readonly DslOperator Image = new("image");
    public static readonly DslOperator InExpression = new("in");
    public static readonly DslOperator IndexOf = new("index-of");
    public static readonly DslOperator Interpolate = new("interpolate");
    public static readonly DslOperator IsSupportedScript = new("is-supported-script");
    public static readonly DslOperator Length = new("length");
    public static readonly DslOperator LetExpression = new("let");
    public static readonly DslOperator LineProgress = new("line-progress");
    public static readonly DslOperator Literal = new("literal");
    public static readonly DslOperator Ln = new("ln");
    public static readonly DslOperator Ln2 = new("ln2");
    public static readonly DslOperator Log10 = new("log10");
    public static readonly DslOperator Log2 = new("log2");
    public static readonly DslOperator Match = new("match");
    public static readonly DslOperator Max = new("max");
    public static readonly DslOperator MeasureLight = new("measure-light");
    public static readonly DslOperator Min = new("min");
    public static readonly DslOperator Number = new("number");
    public static readonly DslOperator NumberFormat = new("number-format");
    public static readonly DslOperator ObjectExpression = new("object");
    public static readonly DslOperator Pi = new("pi");
    public static readonly DslOperator Pitch = new("pitch");
    public static readonly DslOperator Properties = new("properties");
    public static readonly DslOperator Random = new("random");
    public static readonly DslOperator RasterParticleSpeed = new("raster-particle-speed");
    public static readonly DslOperator RasterValue = new("raster-value");
    public static readonly DslOperator ResolvedLocale = new("resolved-locale");
    public static readonly DslOperator Rgb = new("rgb");
    public static readonly DslOperator Rgba = new("rgba");
    public static readonly DslOperator Round = new("round");
    public static readonly DslOperator Sin = new("sin");
    public static readonly DslOperator SkyRadialProgress = new("sky-radial-progress");
    public static readonly DslOperator Slice = new("slice");
    public static readonly DslOperator Sqrt = new("sqrt");
    public static readonly DslOperator Step = new("step");
    public static readonly DslOperator String = new("string");
    public static readonly DslOperator Tan = new("tan");
    public static readonly DslOperator ToBoolean = new("to-boolean");
    public static readonly DslOperator ToColor = new("to-color");
    public static readonly DslOperator ToNumber = new("to-number");
    public static readonly DslOperator ToRgba = new("to-rgba");
    public static readonly DslOperator ToStringX = new("to-string");
    public static readonly DslOperator TypeofExpression = new("typeof");
    public static readonly DslOperator Upcase = new("upcase");
    public static readonly DslOperator VarExpression = new("var");
    public static readonly DslOperator Within = new("within");
    public static readonly DslOperator Zoom = new("zoom");
    public static readonly DslOperator Linear = new("linear");
    public static readonly DslOperator Exponential = new("exponential");
    public static readonly DslOperator CubicBezier = new("cubic-bezier");
}