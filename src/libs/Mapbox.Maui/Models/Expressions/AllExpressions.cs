namespace MapboxMaui;
#if IOS
using MapboxMapsObjC;
#endif
// This file is generated.

public readonly struct ExpressionOperator : INamedString
{

        /// For two inputs, returns the result of subtracting the second input from the first. For a single input, returns the result of subtracting it from 0.
    public static readonly ExpressionOperator Subtract = new ("-");

        /// Logical negation. Returns `true` if the input is `false`, and `false` if the input is `true`.
    public static readonly ExpressionOperator Not = new ("!");

        /// Returns `true` if the input values are not equal, `false` otherwise. The comparison is strictly typed: values of different runtime types are always considered unequal. Cases where the types are known to be different at parse time are considered invalid and will produce a parse error. Accepts an optional `collator` argument to control locale-dependent string comparisons.
    public static readonly ExpressionOperator Neq = new ("!=");

        /// Returns the product of the inputs.
    public static readonly ExpressionOperator Product = new ("*");

        /// Returns the result of floating point division of the first input by the second.
    public static readonly ExpressionOperator Division = new ("/");

        /// Returns the remainder after integer division of the first input by the second.
    public static readonly ExpressionOperator Mod = new ("%");

        /// Returns the result of raising the first input to the power specified by the second.
    public static readonly ExpressionOperator Pow = new ("^");

        /// Returns the sum of the inputs.
    public static readonly ExpressionOperator Sum = new ("+");

        /// Returns `true` if the first input is strictly less than the second, `false` otherwise. The arguments are required to be either both strings or both numbers; if during evaluation they are not, expression evaluation produces an error. Cases where this constraint is known not to hold at parse time are considered in valid and will produce a parse error. Accepts an optional `collator` argument to control locale-dependent string comparisons.
    public static readonly ExpressionOperator Lt = new ("<");

        /// Returns `true` if the first input is less than or equal to the second, `false` otherwise. The arguments are required to be either both strings or both numbers; if during evaluation they are not, expression evaluation produces an error. Cases where this constraint is known not to hold at parse time are considered in valid and will produce a parse error. Accepts an optional `collator` argument to control locale-dependent string comparisons.
    public static readonly ExpressionOperator Lte = new ("<=");

        /// Returns `true` if the input values are equal, `false` otherwise. The comparison is strictly typed: values of different runtime types are always considered unequal. Cases where the types are known to be different at parse time are considered invalid and will produce a parse error. Accepts an optional `collator` argument to control locale-dependent string comparisons.
    public static readonly ExpressionOperator Eq = new ("==");

        /// Returns `true` if the first input is strictly greater than the second, `false` otherwise. The arguments are required to be either both strings or both numbers; if during evaluation they are not, expression evaluation produces an error. Cases where this constraint is known not to hold at parse time are considered in valid and will produce a parse error. Accepts an optional `collator` argument to control locale-dependent string comparisons.
    public static readonly ExpressionOperator Gt = new (">");

        /// Returns `true` if the first input is greater than or equal to the second, `false` otherwise. The arguments are required to be either both strings or both numbers; if during evaluation they are not, expression evaluation produces an error. Cases where this constraint is known not to hold at parse time are considered in valid and will produce a parse error. Accepts an optional `collator` argument to control locale-dependent string comparisons.
    public static readonly ExpressionOperator Gte = new (">=");

        /// Returns the absolute value of the input.
    public static readonly ExpressionOperator Abs = new ("abs");

        /// Returns the value of a cluster property accumulated so far. Can only be used in the `clusterProperties` option of a clustered GeoJSON source.
    public static readonly ExpressionOperator Accumulated = new ("accumulated");

        /// Returns the arccosine of the input.
    public static readonly ExpressionOperator Acos = new ("acos");

        /// Returns `true` if all the inputs are `true`, `false` otherwise. The inputs are evaluated in order, and evaluation is short-circuiting: once an input expression evaluates to `false`, the result is `false` and no further input expressions are evaluated.
    public static readonly ExpressionOperator All = new ("all");

        /// Returns `true` if any of the inputs are `true`, `false` otherwise. The inputs are evaluated in order, and evaluation is short-circuiting: once an input expression evaluates to `true`, the result is `true` and no further input expressions are evaluated.
    public static readonly ExpressionOperator Any = new ("any");

        /// Asserts that the input is an array (optionally with a specific item type and length).  If, when the input expression is evaluated, it is not of the asserted type, then this assertion will cause the whole expression to be aborted.
    public static readonly ExpressionOperator Array = new ("array");

        /// Returns the arcsine of the input.
    public static readonly ExpressionOperator Asin = new ("asin");

        /// Retrieves an item from an array.
    public static readonly ExpressionOperator At = new ("at");

        /// Returns the arctangent of the input.
    public static readonly ExpressionOperator Atan = new ("atan");

        /// Asserts that the input value is a boolean. If multiple values are provided, each one is evaluated in order until a boolean is obtained. If none of the inputs are booleans, the expression is an error.
    public static readonly ExpressionOperator Boolean = new ("boolean");

        /// Selects the first output whose corresponding test condition evaluates to true, or the fallback value otherwise.
    public static readonly ExpressionOperator SwitchCase = new ("case");

        /// Returns the smallest integer that is greater than or equal to the input.
    public static readonly ExpressionOperator Ceil = new ("ceil");

        /// Evaluates each expression in turn until the first valid value is obtained. Invalid values are `null` and [`'image'`](#types-image) expressions that are unavailable in the style. If all values are invalid, `coalesce` returns the first value listed.
    public static readonly ExpressionOperator Coalesce = new ("coalesce");

        /// Returns a `collator` for use in locale-dependent comparison operations. The `case-sensitive` and `diacritic-sensitive` options default to `false`. The `locale` argument specifies the IETF language tag of the locale to use. If none is provided, the default locale is used. If the requested locale is not available, the `collator` will use a system-defined fallback locale. Use `resolved-locale` to test the results of locale fallback behavior.
    public static readonly ExpressionOperator Collator = new ("collator");

        /// Returns a `string` consisting of the concatenation of the inputs. Each input is converted to a string as if by `to-string`.
    public static readonly ExpressionOperator Concat = new ("concat");

        /// Returns the cosine of the input.
    public static readonly ExpressionOperator Cos = new ("cos");

        /// Returns the shortest distance in meters between the evaluated feature and the input geometry. The input value can be a valid GeoJSON of type `Point`, `MultiPoint`, `LineString`, `MultiLineString`, `Polygon`, `MultiPolygon`, `Feature`, or `FeatureCollection`. Distance values returned may vary in precision due to loss in precision from encoding geometries, particularly below zoom level 13.
    public static readonly ExpressionOperator Distance = new ("distance");

        /// Returns the distance of a `symbol` instance from the center of the map. The distance is measured in pixels divided by the height of the map container. It measures 0 at the center, decreases towards the camera and increase away from the camera. For example, if the height of the map is 1000px, a value of -1 means 1000px away from the center towards the camera, and a value of 1 means a distance of 1000px away from the camera from the center. `["distance-from-center"]` may only be used in the `filter` expression for a `symbol` layer.
    public static readonly ExpressionOperator DistanceFromCenter = new ("distance-from-center");

        /// Returns the input string converted to lowercase. Follows the Unicode Default Case Conversion algorithm and the locale-insensitive case mappings in the Unicode Character Database.
    public static readonly ExpressionOperator Downcase = new ("downcase");

        /// Returns the mathematical constant e.
    public static readonly ExpressionOperator E = new ("e");

        /// Retrieves a property value from the current feature's state. Returns `null` if the requested property is not present on the feature's state. A feature's state is not part of the GeoJSON or vector tile data, and must be set programmatically on each feature. Features are identified by their `id` attribute, which must be an integer or a string that can be cast to an integer. Note that ["feature-state"] can only be used with paint properties that support data-driven styling.
    public static readonly ExpressionOperator FeatureState = new ("feature-state");

        /// Returns the largest integer that is less than or equal to the input.
    public static readonly ExpressionOperator Floor = new ("floor");

        /// Returns a `formatted` string for displaying mixed-format text in the `text-field` property. The input may contain a string literal or expression, including an [`'image'`](#types-image) expression. Strings may be followed by a style override object that supports the following properties:
        /// - `"text-font"`: Overrides the font stack specified by the root layout property.
        /// - `"text-color"`: Overrides the color specified by the root paint property.
        /// - `"font-scale"`: Applies a scaling factor on `text-size` as specified by the root layout property.
    public static readonly ExpressionOperator Format = new ("format");

        /// Returns the feature's geometry type: `Point`, `LineString` or `Polygon`. `Multi*` feature types return the singular forms.
    public static readonly ExpressionOperator GeometryType = new ("geometry-type");

        /// Retrieves a property value from the current feature's properties, or from another object if a second argument is provided. Returns `null` if the requested property is missing.
    public static readonly ExpressionOperator Get = new ("get");

        /// Tests for the presence of an property value in the current feature's properties, or from another object if a second argument is provided.
    public static readonly ExpressionOperator Has = new ("has");

        /// Returns the kernel density estimation of a pixel in a heatmap layer, which is a relative measure of how many data points are crowded around a particular pixel. Can only be used in the `heatmap-color` property.
    public static readonly ExpressionOperator HeatmapDensity = new ("heatmap-density");

        /// Returns the feature's id, if it has one.
    public static readonly ExpressionOperator Id = new ("id");

        /// Returns a [`ResolvedImage`](/mapbox-gl-js/style-spec/types/#resolvedimage) for use in [`icon-image`](/mapbox-gl-js/style-spec/layers/#layout-symbol-icon-image), `*-pattern` entries, and as a section in the [`'format'`](#types-format) expression. A [`'coalesce'`](#coalesce) expression containing `image` expressions will evaluate to the first listed image that is currently in the style. This validation process is synchronous and requires the image to have been added to the style before requesting it in the `'image'` argument.
    public static readonly ExpressionOperator Image = new ("image");

        /// Determines whether an item exists in an array or a substring exists in a string. In the specific case when the second and third arguments are string literals, you must wrap at least one of them in a [`literal`](#types-literal) expression to hint correct interpretation to the [type system](#type-system).
    public static readonly ExpressionOperator InExpression = new ("in");

        /// Returns the first position at which an item can be found in an array or a substring can be found in a string, or `-1` if the input cannot be found. Accepts an optional index from where to begin the search.
    public static readonly ExpressionOperator IndexOf = new ("index-of");

        /// Produces continuous, smooth results by interpolating between pairs of input and output values ("stops"). The `input` may be any numeric expression (e.g., `["get", "population"]`). Stop inputs must be numeric literals in strictly ascending order. The output type must be `number`, `array<number>`, or `color`.
        ///
        /// Interpolation types:
        /// - `["linear"]`: Interpolates linearly between the pair of stops just less than and just greater than the input.
        /// - `["exponential", base]`: Interpolates exponentially between the stops just less than and just greater than the input. `base` controls the rate at which the output increases: higher values make the output increase more towards the high end of the range. With values close to 1 the output increases linearly.
        /// - `["cubic-bezier", x1, y1, x2, y2]`: Interpolates using the cubic bezier curve defined by the given control points.
    public static readonly ExpressionOperator Interpolate = new ("interpolate");

        /// Returns `true` if the input string is expected to render legibly. Returns `false` if the input string contains sections that cannot be rendered without potential loss of meaning (e.g. Indic scripts that require complex text shaping, or right-to-left scripts if the the `mapbox-gl-rtl-text` plugin is not in use in Mapbox GL JS).
    public static readonly ExpressionOperator IsSupportedScript = new ("is-supported-script");

        /// Returns the length of an array or string.
    public static readonly ExpressionOperator Length = new ("length");

        /// Binds expressions to named variables, which can then be referenced in the result expression using ["var", "variable_name"].
    public static readonly ExpressionOperator LetExpression = new ("let");

        /// Returns the progress along a gradient line. Can only be used in the `line-gradient` property.
    public static readonly ExpressionOperator LineProgress = new ("line-progress");

        /// Provides a literal array or object value.
    public static readonly ExpressionOperator Literal = new ("literal");

        /// Returns the natural logarithm of the input.
    public static readonly ExpressionOperator Ln = new ("ln");

        /// Returns mathematical constant ln(2).
    public static readonly ExpressionOperator Ln2 = new ("ln2");

        /// Returns the base-ten logarithm of the input.
    public static readonly ExpressionOperator Log10 = new ("log10");

        /// Returns the base-two logarithm of the input.
    public static readonly ExpressionOperator Log2 = new ("log2");

        /// Selects the output for which the label value matches the input value, or the fallback value if no match is found. The input can be any expression (for example, `["get", "building_type"]`). Each label must be unique, and must be either:
        ///  - a single literal value; or
        ///  - an array of literal values, the values of which must be all strings or all numbers (for example `[100, 101]` or `["c", "b"]`).
        ///
        /// The input matches if any of the values in the array matches using strict equality, similar to the `"in"` operator.
        /// If the input type does not match the type of the labels, the result will be the fallback value.
    public static readonly ExpressionOperator Match = new ("match");

        /// Returns the maximum value of the inputs.
    public static readonly ExpressionOperator Max = new ("max");

        /// Returns the minimum value of the inputs.
    public static readonly ExpressionOperator Min = new ("min");

        /// Asserts that the input value is a number. If multiple values are provided, each one is evaluated in order until a number is obtained. If none of the inputs are numbers, the expression is an error.
    public static readonly ExpressionOperator Number = new ("number");

        /// Converts the input number into a string representation using the providing formatting rules. If set, the `locale` argument specifies the locale to use, as a BCP 47 language tag. If set, the `currency` argument specifies an ISO 4217 code to use for currency-style formatting. If set, the `unit` argument specifies a [simple ECMAScript unit](https://tc39.es/proposal-unified-intl-numberformat/section6/locales-currencies-tz_proposed_out.html#sec-issanctionedsimpleunitidentifier) to use for unit-style formatting. If set, the `min-fraction-digits` and `max-fraction-digits` arguments specify the minimum and maximum number of fractional digits to include.
    public static readonly ExpressionOperator NumberFormat = new ("number-format");

        /// Asserts that the input value is an object. If multiple values are provided, each one is evaluated in order until an object is obtained. If none of the inputs are objects, the expression is an error.
    public static readonly ExpressionOperator ObjectExpression = new ("object");

        /// Returns the mathematical constant pi.
    public static readonly ExpressionOperator Pi = new ("pi");

        /// Returns the current pitch in degrees. `["pitch"]` may only be used in the `filter` expression for a `symbol` layer.
    public static readonly ExpressionOperator Pitch = new ("pitch");

        /// Returns the feature properties object.  Note that in some cases, it may be more efficient to use `["get", "property_name"]` directly.
    public static readonly ExpressionOperator Properties = new ("properties");

        /// Returns the IETF language tag of the locale being used by the provided `collator`. This can be used to determine the default system locale, or to determine if a requested locale was successfully loaded.
    public static readonly ExpressionOperator ResolvedLocale = new ("resolved-locale");

        /// Creates a color value from red, green, and blue components, which must range between 0 and 255, and an alpha component of 1. If any component is out of range, the expression is an error.
    public static readonly ExpressionOperator Rgb = new ("rgb");

        /// Creates a color value from red, green, blue components, which must range between 0 and 255, and an alpha component which must range between 0 and 1. If any component is out of range, the expression is an error.
    public static readonly ExpressionOperator Rgba = new ("rgba");

        /// Rounds the input to the nearest integer. Halfway values are rounded away from zero. For example, `["round", -1.5]` evaluates to -2.
    public static readonly ExpressionOperator Round = new ("round");

        /// Returns the sine of the input.
    public static readonly ExpressionOperator Sin = new ("sin");

        /// Returns the distance of a point on the sky from the sun position. Returns 0 at sun position and 1 when the distance reaches `sky-gradient-radius`. Can only be used in the `sky-gradient` property.
    public static readonly ExpressionOperator SkyRadialProgress = new ("sky-radial-progress");

        /// Returns an item from an array or a substring from a string from a specified start index, or between a start index and an end index if set. The return value is inclusive of the start index but not of the end index.
    public static readonly ExpressionOperator Slice = new ("slice");

        /// Returns the square root of the input.
    public static readonly ExpressionOperator Sqrt = new ("sqrt");

        /// Produces discrete, stepped results by evaluating a piecewise-constant function defined by pairs of input and output values ("stops"). The `input` may be any numeric expression (e.g., `["get", "population"]`). Stop inputs must be numeric literals in strictly ascending order. Returns the output value of the stop just less than the input, or the first output if the input is less than the first stop.
    public static readonly ExpressionOperator Step = new ("step");

        /// Asserts that the input value is a string. If multiple values are provided, each one is evaluated in order until a string is obtained. If none of the inputs are strings, the expression is an error.
    public static readonly ExpressionOperator String = new ("string");

        /// Returns the tangent of the input.
    public static readonly ExpressionOperator Tan = new ("tan");

        /// Converts the input value to a boolean. The result is `false` when then input is an empty string, 0, `false`, `null`, or `NaN`; otherwise it is `true`.
    public static readonly ExpressionOperator ToBoolean = new ("to-boolean");

        /// Converts the input value to a color. If multiple values are provided, each one is evaluated in order until the first successful conversion is obtained. If none of the inputs can be converted, the expression is an error.
    public static readonly ExpressionOperator ToColor = new ("to-color");

        /// Converts the input value to a number, if possible. If the input is `null` or `false`, the result is 0. If the input is `true`, the result is 1. If the input is a string, it is converted to a number as specified by the ["ToNumber Applied to the String Type" algorithm](https://tc39.github.io/ecma262/#sec-tonumber-applied-to-the-string-type) of the ECMAScript Language Specification. If multiple values are provided, each one is evaluated in order until the first successful conversion is obtained. If none of the inputs can be converted, the expression is an error.
    public static readonly ExpressionOperator ToNumber = new ("to-number");

        /// Returns a four-element array containing the input color's red, green, blue, and alpha components, in that order.
    public static readonly ExpressionOperator ToRgba = new ("to-rgba");

        /// Converts the input value to a string. If the input is `null`, the result is `""`. If the input is a [`boolean`](#types-boolean), the result is `"true"` or `"false"`. If the input is a number, it is converted to a string as specified by the ["NumberToString" algorithm](https://tc39.github.io/ecma262/#sec-tostring-applied-to-the-number-type) of the ECMAScript Language Specification. If the input is a [`color`](#color), it is converted to a string of the form `"rgba(r,g,b,a)"`, where `r`, `g`, and `b` are numerals ranging from 0 to 255, and `a` ranges from 0 to 1. If the input is an [`'image'`](#types-image) expression, `'to-string'` returns the image name. Otherwise, the input is converted to a string in the format specified by the [`JSON.stringify`](https://tc39.github.io/ecma262/#sec-json.stringify) function of the ECMAScript Language Specification.
    public static readonly ExpressionOperator ToStringX = new ("to-string");

        /// Returns a string describing the type of the given value.
    public static readonly ExpressionOperator TypeofExpression = new ("typeof");

        /// Returns the input string converted to uppercase. Follows the Unicode Default Case Conversion algorithm and the locale-insensitive case mappings in the Unicode Character Database.
    public static readonly ExpressionOperator Upcase = new ("upcase");

        /// References variable bound using "let".
    public static readonly ExpressionOperator VarExpression = new ("var");

        /// Returns `true` if the evaluated feature is fully contained inside a boundary of the input geometry, `false` otherwise. The input value can be a valid GeoJSON of type `Polygon`, `MultiPolygon`, `Feature`, or `FeatureCollection`. Supported features for evaluation:
        /// - `Point`: Returns `false` if a point is on the boundary or falls outside the boundary.
        /// - `LineString`: Returns `false` if any part of a line falls outside the boundary, the line intersects the boundary, or a line's endpoint is on the boundary.
    public static readonly ExpressionOperator Within = new ("within");

        /// Returns the current zoom level.  Note that in style layout and paint properties, ["zoom"] may only appear as the input to a top-level "step" or "interpolate" expression.
    public static readonly ExpressionOperator Zoom = new ("zoom");

        /// Interpolates linearly between the pair of stops just less than and just greater than the input
    public static readonly ExpressionOperator Linear = new ("linear");

        /// `["exponential", base]`
        /// Interpolates exponentially between the stops just less than and just
        /// greater than the input. base controls the rate at which the output increases: higher values make the output
        /// increase more towards the high end of the range.
        /// With values close to 1 the output increases linearly.
    public static readonly ExpressionOperator Exponential = new ("exponential");

        /// `["cubic-bezier", x1, y1, x2, y2]`
        /// Interpolates using the cubic bezier curve defined by the given control points.
    public static readonly ExpressionOperator CubicBezier = new ("cubic-bezier");

    public string Value { get; }

    private ExpressionOperator(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(ExpressionOperator value) => value.Value;
    public static implicit operator ExpressionOperator(string value) => new (value);
}
public static partial class ExpressionOperatorExtensions {}
#if IOS    
partial class ExpressionOperatorExtensions
{
    public static MapboxMapsObjC.TMBExpressionOperator ToPlatform(this ExpressionOperator value)
    {
        return value.Value switch 
        {
            "-" => MapboxMapsObjC.TMBExpressionOperator.Subtract,
            "!" => MapboxMapsObjC.TMBExpressionOperator.Not,
            "!=" => MapboxMapsObjC.TMBExpressionOperator.Neq,
            "*" => MapboxMapsObjC.TMBExpressionOperator.Product,
            "/" => MapboxMapsObjC.TMBExpressionOperator.Division,
            "%" => MapboxMapsObjC.TMBExpressionOperator.Mod,
            "^" => MapboxMapsObjC.TMBExpressionOperator.Pow,
            "+" => MapboxMapsObjC.TMBExpressionOperator.Sum,
            "<" => MapboxMapsObjC.TMBExpressionOperator.Lt,
            "<=" => MapboxMapsObjC.TMBExpressionOperator.Lte,
            "==" => MapboxMapsObjC.TMBExpressionOperator.Eq,
            ">" => MapboxMapsObjC.TMBExpressionOperator.Gt,
            ">=" => MapboxMapsObjC.TMBExpressionOperator.Gte,
            "abs" => MapboxMapsObjC.TMBExpressionOperator.Abs,
            "accumulated" => MapboxMapsObjC.TMBExpressionOperator.Accumulated,
            "acos" => MapboxMapsObjC.TMBExpressionOperator.Acos,
            "all" => MapboxMapsObjC.TMBExpressionOperator.All,
            "any" => MapboxMapsObjC.TMBExpressionOperator.Any,
            "array" => MapboxMapsObjC.TMBExpressionOperator.Array,
            "asin" => MapboxMapsObjC.TMBExpressionOperator.Asin,
            "at" => MapboxMapsObjC.TMBExpressionOperator.At,
            "atan" => MapboxMapsObjC.TMBExpressionOperator.Atan,
            "boolean" => MapboxMapsObjC.TMBExpressionOperator.Boolean,
            "case" => MapboxMapsObjC.TMBExpressionOperator.SwitchCase,
            "ceil" => MapboxMapsObjC.TMBExpressionOperator.Ceil,
            "coalesce" => MapboxMapsObjC.TMBExpressionOperator.Coalesce,
            "collator" => MapboxMapsObjC.TMBExpressionOperator.Collator,
            "concat" => MapboxMapsObjC.TMBExpressionOperator.Concat,
            "cos" => MapboxMapsObjC.TMBExpressionOperator.Cos,
            "distance" => MapboxMapsObjC.TMBExpressionOperator.Distance,
            "distance-from-center" => MapboxMapsObjC.TMBExpressionOperator.DistanceFromCenter,
            "downcase" => MapboxMapsObjC.TMBExpressionOperator.Downcase,
            "e" => MapboxMapsObjC.TMBExpressionOperator.E,
            "feature-state" => MapboxMapsObjC.TMBExpressionOperator.FeatureState,
            "floor" => MapboxMapsObjC.TMBExpressionOperator.Floor,
            "format" => MapboxMapsObjC.TMBExpressionOperator.Format,
            "geometry-type" => MapboxMapsObjC.TMBExpressionOperator.GeometryType,
            "get" => MapboxMapsObjC.TMBExpressionOperator.Get,
            "has" => MapboxMapsObjC.TMBExpressionOperator.Has,
            "heatmap-density" => MapboxMapsObjC.TMBExpressionOperator.HeatmapDensity,
            "id" => MapboxMapsObjC.TMBExpressionOperator.Id,
            "image" => MapboxMapsObjC.TMBExpressionOperator.Image,
            "in" => MapboxMapsObjC.TMBExpressionOperator.InExpression,
            "index-of" => MapboxMapsObjC.TMBExpressionOperator.IndexOf,
            "interpolate" => MapboxMapsObjC.TMBExpressionOperator.Interpolate,
            "is-supported-script" => MapboxMapsObjC.TMBExpressionOperator.IsSupportedScript,
            "length" => MapboxMapsObjC.TMBExpressionOperator.Length,
            "let" => MapboxMapsObjC.TMBExpressionOperator.LetExpression,
            "line-progress" => MapboxMapsObjC.TMBExpressionOperator.LineProgress,
            "literal" => MapboxMapsObjC.TMBExpressionOperator.Literal,
            "ln" => MapboxMapsObjC.TMBExpressionOperator.Ln,
            "ln2" => MapboxMapsObjC.TMBExpressionOperator.Ln2,
            "log10" => MapboxMapsObjC.TMBExpressionOperator.Log10,
            "log2" => MapboxMapsObjC.TMBExpressionOperator.Log2,
            "match" => MapboxMapsObjC.TMBExpressionOperator.Match,
            "max" => MapboxMapsObjC.TMBExpressionOperator.Max,
            "min" => MapboxMapsObjC.TMBExpressionOperator.Min,
            "number" => MapboxMapsObjC.TMBExpressionOperator.Number,
            "number-format" => MapboxMapsObjC.TMBExpressionOperator.NumberFormat,
            "object" => MapboxMapsObjC.TMBExpressionOperator.ObjectExpression,
            "pi" => MapboxMapsObjC.TMBExpressionOperator.Pi,
            "pitch" => MapboxMapsObjC.TMBExpressionOperator.Pitch,
            "properties" => MapboxMapsObjC.TMBExpressionOperator.Properties,
            "resolved-locale" => MapboxMapsObjC.TMBExpressionOperator.ResolvedLocale,
            "rgb" => MapboxMapsObjC.TMBExpressionOperator.Rgb,
            "rgba" => MapboxMapsObjC.TMBExpressionOperator.Rgba,
            "round" => MapboxMapsObjC.TMBExpressionOperator.Round,
            "sin" => MapboxMapsObjC.TMBExpressionOperator.Sin,
            "sky-radial-progress" => MapboxMapsObjC.TMBExpressionOperator.SkyRadialProgress,
            "slice" => MapboxMapsObjC.TMBExpressionOperator.Slice,
            "sqrt" => MapboxMapsObjC.TMBExpressionOperator.Sqrt,
            "step" => MapboxMapsObjC.TMBExpressionOperator.Step,
            "string" => MapboxMapsObjC.TMBExpressionOperator.String,
            "tan" => MapboxMapsObjC.TMBExpressionOperator.Tan,
            "to-boolean" => MapboxMapsObjC.TMBExpressionOperator.ToBoolean,
            "to-color" => MapboxMapsObjC.TMBExpressionOperator.ToColor,
            "to-number" => MapboxMapsObjC.TMBExpressionOperator.ToNumber,
            "to-rgba" => MapboxMapsObjC.TMBExpressionOperator.ToRgba,
            "to-string" => MapboxMapsObjC.TMBExpressionOperator.ToString,
            "typeof" => MapboxMapsObjC.TMBExpressionOperator.TypeofExpression,
            "upcase" => MapboxMapsObjC.TMBExpressionOperator.Upcase,
            "var" => MapboxMapsObjC.TMBExpressionOperator.VarExpression,
            "within" => MapboxMapsObjC.TMBExpressionOperator.Within,
            "zoom" => MapboxMapsObjC.TMBExpressionOperator.Zoom,
            "linear" => MapboxMapsObjC.TMBExpressionOperator.Linear,
            "exponential" => MapboxMapsObjC.TMBExpressionOperator.Exponential,
            "cubic-bezier" => MapboxMapsObjC.TMBExpressionOperator.CubicBezier
        };
    }

    public static ExpressionOperator ToPlatform(this MapboxMapsObjC.TMBExpressionOperator value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBExpressionOperator.Subtract => "-",
            MapboxMapsObjC.TMBExpressionOperator.Not => "!",
            MapboxMapsObjC.TMBExpressionOperator.Neq => "!=",
            MapboxMapsObjC.TMBExpressionOperator.Product => "*",
            MapboxMapsObjC.TMBExpressionOperator.Division => "/",
            MapboxMapsObjC.TMBExpressionOperator.Mod => "%",
            MapboxMapsObjC.TMBExpressionOperator.Pow => "^",
            MapboxMapsObjC.TMBExpressionOperator.Sum => "+",
            MapboxMapsObjC.TMBExpressionOperator.Lt => "<",
            MapboxMapsObjC.TMBExpressionOperator.Lte => "<=",
            MapboxMapsObjC.TMBExpressionOperator.Eq => "==",
            MapboxMapsObjC.TMBExpressionOperator.Gt => ">",
            MapboxMapsObjC.TMBExpressionOperator.Gte => ">=",
            MapboxMapsObjC.TMBExpressionOperator.Abs => "abs",
            MapboxMapsObjC.TMBExpressionOperator.Accumulated => "accumulated",
            MapboxMapsObjC.TMBExpressionOperator.Acos => "acos",
            MapboxMapsObjC.TMBExpressionOperator.All => "all",
            MapboxMapsObjC.TMBExpressionOperator.Any => "any",
            MapboxMapsObjC.TMBExpressionOperator.Array => "array",
            MapboxMapsObjC.TMBExpressionOperator.Asin => "asin",
            MapboxMapsObjC.TMBExpressionOperator.At => "at",
            MapboxMapsObjC.TMBExpressionOperator.Atan => "atan",
            MapboxMapsObjC.TMBExpressionOperator.Boolean => "boolean",
            MapboxMapsObjC.TMBExpressionOperator.SwitchCase => "case",
            MapboxMapsObjC.TMBExpressionOperator.Ceil => "ceil",
            MapboxMapsObjC.TMBExpressionOperator.Coalesce => "coalesce",
            MapboxMapsObjC.TMBExpressionOperator.Collator => "collator",
            MapboxMapsObjC.TMBExpressionOperator.Concat => "concat",
            MapboxMapsObjC.TMBExpressionOperator.Cos => "cos",
            MapboxMapsObjC.TMBExpressionOperator.Distance => "distance",
            MapboxMapsObjC.TMBExpressionOperator.DistanceFromCenter => "distance-from-center",
            MapboxMapsObjC.TMBExpressionOperator.Downcase => "downcase",
            MapboxMapsObjC.TMBExpressionOperator.E => "e",
            MapboxMapsObjC.TMBExpressionOperator.FeatureState => "feature-state",
            MapboxMapsObjC.TMBExpressionOperator.Floor => "floor",
            MapboxMapsObjC.TMBExpressionOperator.Format => "format",
            MapboxMapsObjC.TMBExpressionOperator.GeometryType => "geometry-type",
            MapboxMapsObjC.TMBExpressionOperator.Get => "get",
            MapboxMapsObjC.TMBExpressionOperator.Has => "has",
            MapboxMapsObjC.TMBExpressionOperator.HeatmapDensity => "heatmap-density",
            MapboxMapsObjC.TMBExpressionOperator.Id => "id",
            MapboxMapsObjC.TMBExpressionOperator.Image => "image",
            MapboxMapsObjC.TMBExpressionOperator.InExpression => "in",
            MapboxMapsObjC.TMBExpressionOperator.IndexOf => "index-of",
            MapboxMapsObjC.TMBExpressionOperator.Interpolate => "interpolate",
            MapboxMapsObjC.TMBExpressionOperator.IsSupportedScript => "is-supported-script",
            MapboxMapsObjC.TMBExpressionOperator.Length => "length",
            MapboxMapsObjC.TMBExpressionOperator.LetExpression => "let",
            MapboxMapsObjC.TMBExpressionOperator.LineProgress => "line-progress",
            MapboxMapsObjC.TMBExpressionOperator.Literal => "literal",
            MapboxMapsObjC.TMBExpressionOperator.Ln => "ln",
            MapboxMapsObjC.TMBExpressionOperator.Ln2 => "ln2",
            MapboxMapsObjC.TMBExpressionOperator.Log10 => "log10",
            MapboxMapsObjC.TMBExpressionOperator.Log2 => "log2",
            MapboxMapsObjC.TMBExpressionOperator.Match => "match",
            MapboxMapsObjC.TMBExpressionOperator.Max => "max",
            MapboxMapsObjC.TMBExpressionOperator.Min => "min",
            MapboxMapsObjC.TMBExpressionOperator.Number => "number",
            MapboxMapsObjC.TMBExpressionOperator.NumberFormat => "number-format",
            MapboxMapsObjC.TMBExpressionOperator.ObjectExpression => "object",
            MapboxMapsObjC.TMBExpressionOperator.Pi => "pi",
            MapboxMapsObjC.TMBExpressionOperator.Pitch => "pitch",
            MapboxMapsObjC.TMBExpressionOperator.Properties => "properties",
            MapboxMapsObjC.TMBExpressionOperator.ResolvedLocale => "resolved-locale",
            MapboxMapsObjC.TMBExpressionOperator.Rgb => "rgb",
            MapboxMapsObjC.TMBExpressionOperator.Rgba => "rgba",
            MapboxMapsObjC.TMBExpressionOperator.Round => "round",
            MapboxMapsObjC.TMBExpressionOperator.Sin => "sin",
            MapboxMapsObjC.TMBExpressionOperator.SkyRadialProgress => "sky-radial-progress",
            MapboxMapsObjC.TMBExpressionOperator.Slice => "slice",
            MapboxMapsObjC.TMBExpressionOperator.Sqrt => "sqrt",
            MapboxMapsObjC.TMBExpressionOperator.Step => "step",
            MapboxMapsObjC.TMBExpressionOperator.String => "string",
            MapboxMapsObjC.TMBExpressionOperator.Tan => "tan",
            MapboxMapsObjC.TMBExpressionOperator.ToBoolean => "to-boolean",
            MapboxMapsObjC.TMBExpressionOperator.ToColor => "to-color",
            MapboxMapsObjC.TMBExpressionOperator.ToNumber => "to-number",
            MapboxMapsObjC.TMBExpressionOperator.ToRgba => "to-rgba",
            MapboxMapsObjC.TMBExpressionOperator.ToString => "to-string",
            MapboxMapsObjC.TMBExpressionOperator.TypeofExpression => "typeof",
            MapboxMapsObjC.TMBExpressionOperator.Upcase => "upcase",
            MapboxMapsObjC.TMBExpressionOperator.VarExpression => "var",
            MapboxMapsObjC.TMBExpressionOperator.Within => "within",
            MapboxMapsObjC.TMBExpressionOperator.Zoom => "zoom",
            MapboxMapsObjC.TMBExpressionOperator.Linear => "linear",
            MapboxMapsObjC.TMBExpressionOperator.Exponential => "exponential",
            MapboxMapsObjC.TMBExpressionOperator.CubicBezier => "cubic-bezier"
        };
    }

    public static ExpressionOperator ExpressionOperatorX(this Foundation.NSNumber value)
    {
        return value.ExpressionOperator().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this ExpressionOperator value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif


// End of generated file.
