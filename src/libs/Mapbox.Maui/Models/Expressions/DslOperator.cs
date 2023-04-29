namespace MapboxMaui.Expressions;

public struct DslOperator : INamedString
{
    public string Value { get; }

    private DslOperator(string op)
    {
        Value = op;
    }

    public override string ToString() => Value;

    /// For two inputs, returns the result of subtracting the second input from the first. For a single input, returns the result of subtracting it from 0.
    public static readonly DslOperator subtract = new DslOperator("-");

    /// Logical negation. Returns `true` if the input is `false`, and `false` if the input is `true`.
    public static readonly DslOperator not = new DslOperator("!");

    /// Returns `true` if the input values are not equal, `false` otherwise. The comparison is strictly typed: values of different runtime types are always considered unequal. Cases where the types are known to be different at parse time are considered invalid and will produce a parse error. Accepts an optional `collator` argument to control locale-dependent string comparisons.
    public static readonly DslOperator neq = new DslOperator("!=");

    /// Returns the product of the inputs.
    public static readonly DslOperator product = new DslOperator("*");

    /// Returns the result of floating point division of the first input by the second.
    public static readonly DslOperator division = new DslOperator("/");

    /// Returns the remainder after integer division of the first input by the second.
    public static readonly DslOperator mod = new DslOperator("%");

    /// Returns the result of raising the first input to the power specified by the second.
    public static readonly DslOperator pow = new DslOperator("^");

    /// Returns the sum of the inputs.
    public static readonly DslOperator sum = new DslOperator("+");

    /// Returns `true` if the first input is strictly less than the second, `false` otherwise. The arguments are required to be either both strings or both numbers; if during evaluation they are not, expression evaluation produces an error. Cases where this constraint is known not to hold at parse time are considered in valid and will produce a parse error. Accepts an optional `collator` argument to control locale-dependent string comparisons.
    public static readonly DslOperator lt = new DslOperator("<");

    /// Returns `true` if the first input is less than or equal to the second, `false` otherwise. The arguments are required to be either both strings or both numbers; if during evaluation they are not, expression evaluation produces an error. Cases where this constraint is known not to hold at parse time are considered in valid and will produce a parse error. Accepts an optional `collator` argument to control locale-dependent string comparisons.
    public static readonly DslOperator lte = new DslOperator("<=");

    /// Returns `true` if the input values are equal, `false` otherwise. The comparison is strictly typed: values of different runtime types are always considered unequal. Cases where the types are known to be different at parse time are considered invalid and will produce a parse error. Accepts an optional `collator` argument to control locale-dependent string comparisons.
    public static readonly DslOperator eq = new DslOperator("==");

    /// Returns `true` if the first input is strictly greater than the second, `false` otherwise. The arguments are required to be either both strings or both numbers; if during evaluation they are not, expression evaluation produces an error. Cases where this constraint is known not to hold at parse time are considered in valid and will produce a parse error. Accepts an optional `collator` argument to control locale-dependent string comparisons.
    public static readonly DslOperator gt = new DslOperator(">");

    /// Returns `true` if the first input is greater than or equal to the second, `false` otherwise. The arguments are required to be either both strings or both numbers; if during evaluation they are not, expression evaluation produces an error. Cases where this constraint is known not to hold at parse time are considered in valid and will produce a parse error. Accepts an optional `collator` argument to control locale-dependent string comparisons.
    public static readonly DslOperator gte = new DslOperator(">=");

    /// Returns the absolute value of the input.
    public static readonly DslOperator abs = new DslOperator("abs");

    /// Returns the value of a cluster property accumulated so far. Can only be used in the `clusterProperties` option of a clustered GeoJSON source.
    public static readonly DslOperator accumulated = new DslOperator("accumulated");

    /// Returns the arccosine of the input.
    public static readonly DslOperator acos = new DslOperator("acos");

    /// Returns `true` if all the inputs are `true`, `false` otherwise. The inputs are evaluated in order, and evaluation is short-circuiting: once an input expression evaluates to `false`, the result is `false` and no further input expressions are evaluated.
    public static readonly DslOperator all = new DslOperator("all");

    /// Returns `true` if any of the inputs are `true`, `false` otherwise. The inputs are evaluated in order, and evaluation is short-circuiting: once an input expression evaluates to `true`, the result is `true` and no further input expressions are evaluated.
    public static readonly DslOperator any = new DslOperator("any");

    /// Asserts that the input is an array (optionally with a specific item type and length).  If, when the input expression is evaluated, it is not of the asserted type, then this assertion will cause the whole expression to be aborted.
    public static readonly DslOperator array = new DslOperator("array");

    /// Returns the arcsine of the input.
    public static readonly DslOperator asin = new DslOperator("asin");

    /// Retrieves an item from an array.
    public static readonly DslOperator at = new DslOperator("at");

    /// Returns the arctangent of the input.
    public static readonly DslOperator atan = new DslOperator("atan");

    /// Asserts that the input value is a boolean. If multiple values are provided, each one is evaluated in order until a boolean is obtained. If none of the inputs are booleans, the expression is an error.
    public static readonly DslOperator boolean = new DslOperator("boolean");

    /// Selects the first output whose corresponding test condition evaluates to true, or the fallback value otherwise.
    public static readonly DslOperator switchCase = new DslOperator("case");

    /// Returns the smallest integer that is greater than or equal to the input.
    public static readonly DslOperator ceil = new DslOperator("ceil");

    /// Evaluates each expression in turn until the first valid value is obtained. Invalid values are `null` and [`'image'`](#types-image) expressions that are unavailable in the style. If all values are invalid, `coalesce` returns the first value listed.
    public static readonly DslOperator coalesce = new DslOperator("coalesce");

    /// Returns a `collator` for use in locale-dependent comparison operations. The `case-sensitive` and `diacritic-sensitive` options default to `false`. The `locale` argument specifies the IETF language tag of the locale to use. If none is provided, the default locale is used. If the requested locale is not available, the `collator` will use a system-defined fallback locale. Use `resolved-locale` to test the results of locale fallback behavior.
    public static readonly DslOperator collator = new DslOperator("collator");

    /// Returns a `string` consisting of the concatenation of the inputs. Each input is converted to a string as if by `to-string`.
    public static readonly DslOperator concat = new DslOperator("concat");

    /// Returns the cosine of the input.
    public static readonly DslOperator cos = new DslOperator("cos");

    /// Returns the shortest distance in meters between the evaluated feature and the input geometry. The input value can be a valid GeoJSON of type `Point`, `MultiPoint`, `LineString`, `MultiLineString`, `Polygon`, `MultiPolygon`, `Feature`, or `FeatureCollection`. Distance values returned may vary in precision due to loss in precision from encoding geometries, particularly below zoom level 13.
    public static readonly DslOperator distance = new DslOperator("distance");

    /// Returns the distance of a `symbol` instance from the center of the map. The distance is measured in pixels divided by the height of the map container. It measures 0 at the center, decreases towards the camera and increase away from the camera. For example, if the height of the map is 1000px, a value of -1 means 1000px away from the center towards the camera, and a value of 1 means a distance of 1000px away from the camera from the center. `["distance-from-center"]` may only be used in the `filter` expression for a `symbol` layer.
    public static readonly DslOperator distanceFromCenter = new DslOperator("distance-from-center");

    /// Returns the input string converted to lowercase. Follows the Unicode Default Case Conversion algorithm and the locale-insensitive case mappings in the Unicode Character Database.
    public static readonly DslOperator downcase = new DslOperator("downcase");

    /// Returns the mathematical constant e.
    public static readonly DslOperator e = new DslOperator("e");

    /// Retrieves a property value from the current feature's state. Returns `null` if the requested property is not present on the feature's state. A feature's state is not part of the GeoJSON or vector tile data, and must be set programmatically on each feature. Features are identified by their `id` attribute, which must be an integer or a string that can be cast to an integer. Note that ["feature-state"] can only be used with paint properties that support data-driven styling.
    public static readonly DslOperator featureState = new DslOperator("feature-state");

    /// Returns the largest integer that is less than or equal to the input.
    public static readonly DslOperator floor = new DslOperator("floor");

    /// Returns a `formatted` string for displaying mixed-format text in the `text-field` property. The input may contain a string literal or expression, including an [`'image'`](#types-image) expression. Strings may be followed by a style override object that supports the following properties:
    /// - `"text-font"`: Overrides the font stack specified by the root layout property.
    /// - `"text-color"`: Overrides the color specified by the root paint property.
    /// - `"font-scale"`: Applies a scaling factor on `text-size` as specified by the root layout property.
    public static readonly DslOperator format = new DslOperator("format");

    /// Returns the feature's geometry type: `Point`, `LineString` or `Polygon`. `Multi*` feature types return the singular forms.
    public static readonly DslOperator geometryType = new DslOperator("geometry-type");

    /// Retrieves a property value from the current feature's properties, or from another object if a second argument is provided. Returns `null` if the requested property is missing.
    public static readonly DslOperator get = new DslOperator("get");

    /// Tests for the presence of an property value in the current feature's properties, or from another object if a second argument is provided.
    public static readonly DslOperator has = new DslOperator("has");

    /// Returns the kernel density estimation of a pixel in a heatmap layer, which is a relative measure of how many data points are crowded around a particular pixel. Can only be used in the `heatmap-color` property.
    public static readonly DslOperator heatmapDensity = new DslOperator("heatmap-density");

    /// Returns the feature's id, if it has one.
    public static readonly DslOperator id = new DslOperator("id");

    /// Returns a [`ResolvedImage`](/mapbox-gl-js/style-spec/types/#resolvedimage) for use in [`icon-image`](/mapbox-gl-js/style-spec/layers/#layout-symbol-icon-image), `*-pattern` entries, and as a section in the [`'format'`](#types-format) expression. A [`'coalesce'`](#coalesce) expression containing `image` expressions will evaluate to the first listed image that is currently in the style. This validation process is synchronous and requires the image to have been added to the style before requesting it in the `'image'` argument.
    public static readonly DslOperator image = new DslOperator("image");

    /// Determines whether an item exists in an array or a substring exists in a string. In the specific case when the second and third arguments are string literals, you must wrap at least one of them in a [`literal`](#types-literal) expression to hint correct interpretation to the [type system](#type-system).
    public static readonly DslOperator inExpression = new DslOperator("in");

    /// Returns the first position at which an item can be found in an array or a substring can be found in a string, or `-1` if the input cannot be found. Accepts an optional index from where to begin the search.
    public static readonly DslOperator indexOf = new DslOperator("index-of");

    /// Produces continuous, smooth results by interpolating between pairs of input and output values ("stops"). The `input` may be any numeric expression (e.g., `["get", "population"]`). Stop inputs must be numeric literals in strictly ascending order. The output type must be `number`, `array<number>`, or `color`.
    ///
    /// Interpolation types:
    /// - `["linear"]`: Interpolates linearly between the pair of stops just less than and just greater than the input.
    /// - `["exponential", base]`: Interpolates exponentially between the stops just less than and just greater than the input. `base` controls the rate at which the output increases: higher values make the output increase more towards the high end of the range. With values close to 1 the output increases linearly.
    /// - `["cubic-bezier", x1, y1, x2, y2]`: Interpolates using the cubic bezier curve defined by the given control points.
    public static readonly DslOperator interpolate = new DslOperator("interpolate");

    /// Returns `true` if the input string is expected to render legibly. Returns `false` if the input string contains sections that cannot be rendered without potential loss of meaning (e.g. Indic scripts that require complex text shaping, or right-to-left scripts if the the `mapbox-gl-rtl-text` plugin is not in use in Mapbox GL JS).
    public static readonly DslOperator isSupportedScript = new DslOperator("is-supported-script");

    /// Returns the length of an array or string.
    public static readonly DslOperator length = new DslOperator("length");

    /// Binds expressions to named variables, which can then be referenced in the result expression using ["var", "variable_name"].
    public static readonly DslOperator letExpression = new DslOperator("let");

    /// Returns the progress along a gradient line. Can only be used in the `line-gradient` property.
    public static readonly DslOperator lineProgress = new DslOperator("line-progress");

    /// Provides a literal array or object value.
    public static readonly DslOperator literal = new DslOperator("literal");

    /// Returns the natural logarithm of the input.
    public static readonly DslOperator ln = new DslOperator("ln");

    /// Returns mathematical constant ln(2).
    public static readonly DslOperator ln2 = new DslOperator("ln2");

    /// Returns the base-ten logarithm of the input.
    public static readonly DslOperator log10 = new DslOperator("log10");

    /// Returns the base-two logarithm of the input.
    public static readonly DslOperator log2 = new DslOperator("log2");

    /// Selects the output for which the label value matches the input value, or the fallback value if no match is found. The input can be any expression (for example, `["get", "building_type"]`). Each label must be unique, and must be either:
    ///  - a single literal value; or
    ///  - an array of literal values, the values of which must be all strings or all numbers (for example `[100, 101]` or `["c", "b"]`).
    ///
    /// The input matches if any of the values in the array matches using strict equality, similar to the `"in"` operator.
    /// If the input type does not match the type of the labels, the result will be the fallback value.
    public static readonly DslOperator match = new DslOperator("match");

    /// Returns the maximum value of the inputs.
    public static readonly DslOperator max = new DslOperator("max");

    /// Returns the minimum value of the inputs.
    public static readonly DslOperator min = new DslOperator("min");

    /// Asserts that the input value is a number. If multiple values are provided, each one is evaluated in order until a number is obtained. If none of the inputs are numbers, the expression is an error.
    public static readonly DslOperator number = new DslOperator("number");

    /// Converts the input number into a string representation using the providing formatting rules. If set, the `locale` argument specifies the locale to use, as a BCP 47 language tag. If set, the `currency` argument specifies an ISO 4217 code to use for currency-style formatting. If set, the `unit` argument specifies a [simple ECMAScript unit](https://tc39.es/proposal-unified-intl-numberformat/section6/locales-currencies-tz_proposed_out.html#sec-issanctionedsimpleunitidentifier) to use for unit-style formatting. If set, the `min-fraction-digits` and `max-fraction-digits` arguments specify the minimum and maximum number of fractional digits to include.
    public static readonly DslOperator numberFormat = new DslOperator("number-format");

    /// Asserts that the input value is an object. If multiple values are provided, each one is evaluated in order until an object is obtained. If none of the inputs are objects, the expression is an error.
    public static readonly DslOperator objectExpression = new DslOperator("object");

    /// Returns the mathematical constant pi.
    public static readonly DslOperator pi = new DslOperator("pi");

    /// Returns the current pitch in degrees. `["pitch"]` may only be used in the `filter` expression for a `symbol` layer.
    public static readonly DslOperator pitch = new DslOperator("pitch");

    /// Returns the feature properties object.  Note that in some cases, it may be more efficient to use `["get", "property_name"]` directly.
    public static readonly DslOperator properties = new DslOperator("properties");

    /// Returns the IETF language tag of the locale being used by the provided `collator`. This can be used to determine the default system locale, or to determine if a requested locale was successfully loaded.
    public static readonly DslOperator resolvedLocale = new DslOperator("resolved-locale");

    /// Creates a color value from red, green, and blue components, which must range between 0 and 255, and an alpha component of 1. If any component is out of range, the expression is an error.
    public static readonly DslOperator rgb = new DslOperator("rgb");

    /// Creates a color value from red, green, blue components, which must range between 0 and 255, and an alpha component which must range between 0 and 1. If any component is out of range, the expression is an error.
    public static readonly DslOperator rgba = new DslOperator("rgba");

    /// Rounds the input to the nearest integer. Halfway values are rounded away from zero. For example, `["round", -1.5]` evaluates to -2.
    public static readonly DslOperator round = new DslOperator("round");

    /// Returns the sine of the input.
    public static readonly DslOperator sin = new DslOperator("sin");

    /// Returns the distance of a point on the sky from the sun position. Returns 0 at sun position and 1 when the distance reaches `sky-gradient-radius`. Can only be used in the `sky-gradient` property.
    public static readonly DslOperator skyRadialProgress = new DslOperator("sky-radial-progress");

    /// Returns an item from an array or a substring from a string from a specified start index, or between a start index and an end index if set. The return value is inclusive of the start index but not of the end index.
    public static readonly DslOperator slice = new DslOperator("slice");

    /// Returns the square root of the input.
    public static readonly DslOperator sqrt = new DslOperator("sqrt");

    /// Produces discrete, stepped results by evaluating a piecewise-constant function defined by pairs of input and output values ("stops"). The `input` may be any numeric expression (e.g., `["get", "population"]`). Stop inputs must be numeric literals in strictly ascending order. Returns the output value of the stop just less than the input, or the first output if the input is less than the first stop.
    public static readonly DslOperator step = new DslOperator("step");

    /// Asserts that the input value is a string. If multiple values are provided, each one is evaluated in order until a string is obtained. If none of the inputs are strings, the expression is an error.
    public static readonly DslOperator stringLiteral = new DslOperator("string");

    /// Returns the tangent of the input.
    public static readonly DslOperator tan = new DslOperator("tan");

    /// Converts the input value to a boolean. The result is `false` when then input is an empty string, 0, `false`, `null`, or `NaN`; otherwise it is `true`.
    public static readonly DslOperator toBoolean = new DslOperator("to-boolean");

    /// Converts the input value to a color. If multiple values are provided, each one is evaluated in order until the first successful conversion is obtained. If none of the inputs can be converted, the expression is an error.
    public static readonly DslOperator toColor = new DslOperator("to-color");

    /// Converts the input value to a number, if possible. If the input is `null` or `false`, the result is 0. If the input is `true`, the result is 1. If the input is a string, it is converted to a number as specified by the ["ToNumber Applied to the String Type" algorithm](https://tc39.github.io/ecma262/#sec-tonumber-applied-to-the-string-type) of the ECMAScript Language Specification. If multiple values are provided, each one is evaluated in order until the first successful conversion is obtained. If none of the inputs can be converted, the expression is an error.
    public static readonly DslOperator toNumber = new DslOperator("to-number");

    /// Returns a four-element array containing the input color's red, green, blue, and alpha components, in that order.
    public static readonly DslOperator toRgba = new DslOperator("to-rgba");

    /// Converts the input value to a string. If the input is `null`, the result is `""`. If the input is a [`boolean`](#types-boolean), the result is `"true"` or `"false"`. If the input is a number, it is converted to a string as specified by the ["NumberToString" algorithm](https://tc39.github.io/ecma262/#sec-tostring-applied-to-the-number-type) of the ECMAScript Language Specification. If the input is a [`color`](#color), it is converted to a string of the form `"rgba(r,g,b,a)"`, where `r`, `g`, and `b` are numerals ranging from 0 to 255, and `a` ranges from 0 to 1. If the input is an [`'image'`](#types-image) expression, `'to-string'` returns the image name. Otherwise, the input is converted to a string in the format specified by the [`JSON.stringify`](https://tc39.github.io/ecma262/#sec-json.stringify) function of the ECMAScript Language Specification.
    public static readonly DslOperator toString = new DslOperator("to-string");

    /// Returns a string describing the type of the given value.
    public static readonly DslOperator typeofExpression = new DslOperator("typeof");

    /// Returns the input string converted to uppercase. Follows the Unicode Default Case Conversion algorithm and the locale-insensitive case mappings in the Unicode Character Database.
    public static readonly DslOperator upcase = new DslOperator("upcase");

    /// References variable bound using "let".
    public static readonly DslOperator varExpression = new DslOperator("var");

    /// Returns `true` if the evaluated feature is fully contained inside a boundary of the input geometry, `false` otherwise. The input value can be a valid GeoJSON of type `Polygon`, `MultiPolygon`, `Feature`, or `FeatureCollection`. Supported features for evaluation:
    /// - `Point`: Returns `false` if a point is on the boundary or falls outside the boundary.
    /// - `LineString`: Returns `false` if any part of a line falls outside the boundary, the line intersects the boundary, or a line's endpoint is on the boundary.
    public static readonly DslOperator within = new DslOperator("within");

    /// Returns the current zoom level.  Note that in style layout and paint properties, ["zoom"] may only appear as the input to a top-level "step" or "interpolate" expression.
    public static readonly DslOperator zoom = new DslOperator("zoom");

    /// Interpolates linearly between the pair of stops just less than and just greater than the input
    public static readonly DslOperator linear = new DslOperator("linear");

    /// `["exponential", base]`
    /// Interpolates exponentially between the stops just less than and just
    /// greater than the input. base controls the rate at which the output increases: higher values make the output
    /// increase more towards the high end of the range.
    /// With values close to 1 the output increases linearly.
    public static readonly DslOperator exponential = new DslOperator("exponential");

    /// `["cubic-bezier", x1, y1, x2, y2]`
    /// Interpolates using the cubic bezier curve defined by the given control points.
    public static readonly DslOperator cubicBezier = new DslOperator("cubic-bezier");
}

