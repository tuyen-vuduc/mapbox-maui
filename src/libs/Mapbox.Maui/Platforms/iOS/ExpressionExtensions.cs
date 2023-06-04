using Foundation;
using MapboxMaui.Expressions;
using MapboxMapsObjC;

namespace MapboxMaui;

public static class ExpressionExtensions
{
    internal static TMBExpression ToPlatformValue(
        this DslExpression xvalue
    )
    {
        var arguments = NSArray.FromNSObjects(xvalue.Select(x => x.Wrap()).ToArray());

        return string.IsNullOrWhiteSpace(xvalue.Operator.Value)
            ? TMBExpression.CreateWithArguments(
                arguments
            )
            : TMBExpression.CreateWithOperator(
                xvalue.Operator.ToPlatformValue(),
                arguments
            );
    }

    internal static TMBOperator ToPlatformValue(this DslOperator xvalue)
    {
        return stringToOperatorMapping[xvalue.Value];
    }

    static readonly Dictionary<string, TMBOperator> stringToOperatorMapping = new Dictionary<string, TMBOperator>
    {
		/// For two inputs, returns the result of subtracting the second input from the first. For a single input, returns the result of subtracting it from 0.
        { "-", TMBOperator.Subtract },

        /// Logical negation. Returns `true` if the input is `false`, and `false` if the input is `true`.
        { "!", TMBOperator.Not_ },

        /// Returns `true` if the input values are not equal, `false` otherwise. The comparison is strictly typed: values of different runtime types are always considered unequal. Cases where the types are known to be different at parse time are considered invalid and will produce a parse error. Accepts an optional `collator` argument to control locale-dependent string comparisons.
        { "!=", TMBOperator.Neq },

        /// Returns the product of the inputs.
        { "*", TMBOperator.Product },

        /// Returns the result of floating point division of the first input by the second.
        { "/", TMBOperator.Division },

        /// Returns the remainder after integer division of the first input by the second.
        { "%", TMBOperator.Mod },

        /// Returns the result of raising the first input to the power specified by the second.
        { "^", TMBOperator.Pow },

        /// Returns the sum of the inputs.
        { "+", TMBOperator.Sum },

        /// Returns `true` if the first input is strictly less than the second, `false` otherwise. The arguments are required to be either both strings or both numbers; if during evaluation they are not, expression evaluation produces an error. Cases where this constraint is known not to hold at parse time are considered in valid and will produce a parse error. Accepts an optional `collator` argument to control locale-dependent string comparisons.
        { "<", TMBOperator.Lt },

        /// Returns `true` if the first input is less than or equal to the second, `false` otherwise. The arguments are required to be either both strings or both numbers; if during evaluation they are not, expression evaluation produces an error. Cases where this constraint is known not to hold at parse time are considered in valid and will produce a parse error. Accepts an optional `collator` argument to control locale-dependent string comparisons.
        { "<=", TMBOperator.Lte },

        /// Returns `true` if the input values are equal, `false` otherwise. The comparison is strictly typed: values of different runtime types are always considered unequal. Cases where the types are known to be different at parse time are considered invalid and will produce a parse error. Accepts an optional `collator` argument to control locale-dependent string comparisons.
        { "==", TMBOperator.Eq },

        /// Returns `true` if the first input is strictly greater than the second, `false` otherwise. The arguments are required to be either both strings or both numbers; if during evaluation they are not, expression evaluation produces an error. Cases where this constraint is known not to hold at parse time are considered in valid and will produce a parse error. Accepts an optional `collator` argument to control locale-dependent string comparisons.
        { ">", TMBOperator.Gt },

        /// Returns `true` if the first input is greater than or equal to the second, `false` otherwise. The arguments are required to be either both strings or both numbers; if during evaluation they are not, expression evaluation produces an error. Cases where this constraint is known not to hold at parse time are considered in valid and will produce a parse error. Accepts an optional `collator` argument to control locale-dependent string comparisons.
        { ">=", TMBOperator.Gte },

        /// Returns the absolute value of the input.
        { "abs", TMBOperator.Abs },

        /// Returns the value of a cluster property accumulated so far. Can only be used in the `clusterProperties` option of a clustered GeoJSON source.
        { "accumulated", TMBOperator.Accumulated },

        /// Returns the arccosine of the input.
        { "acos", TMBOperator.Acos },

        /// Returns `true` if all the inputs are `true`, `false` otherwise. The inputs are evaluated in order, and evaluation is short-circuiting: once an input expression evaluates to `false`, the result is `false` and no further input expressions are evaluated.
        { "all", TMBOperator.All },

        /// Returns `true` if any of the inputs are `true`, `false` otherwise. The inputs are evaluated in order, and evaluation is short-circuiting: once an input expression evaluates to `true`, the result is `true` and no further input expressions are evaluated.
        { "any", TMBOperator.Any },

        /// Asserts that the input is an array (optionally with a specific item type and length).  If, when the input expression is evaluated, it is not of the asserted type, then this assertion will cause the whole expression to be aborted.
        { "array", TMBOperator.Array },

        /// Returns the arcsine of the input.
        { "asin", TMBOperator.Asin },

        /// Retrieves an item from an array.
        { "at", TMBOperator.At },

        /// Returns the arctangent of the input.
        { "atan", TMBOperator.Atan },

        /// Asserts that the input value is a boolean. If multiple values are provided, each one is evaluated in order until a boolean is obtained. If none of the inputs are booleans, the expression is an error.
        { "boolean", TMBOperator.Boolean },

        /// Selects the first output whose corresponding test condition evaluates to true, or the fallback value otherwise.
        { "case", TMBOperator.SwitchCase },

        /// Returns the smallest integer that is greater than or equal to the input.
        { "ceil", TMBOperator.Ceil },

        /// Evaluates each expression in turn until the first valid value is obtained. Invalid values are `null` and [`'image'`](#types-image) expressions that are unavailable in the style. If all values are invalid, `coalesce` returns the first value listed.
        { "coalesce", TMBOperator.Coalesce },

        /// Returns a `collator` for use in locale-dependent comparison operations. The `case-sensitive` and `diacritic-sensitive` options default to `false`. The `locale` argument specifies the IETF language tag of the locale to use. If none is provided, the default locale is used. If the requested locale is not available, the `collator` will use a system-defined fallback locale. Use `resolved-locale` to test the results of locale fallback behavior.
        { "collator", TMBOperator.Collator },

        /// Returns a `string` consisting of the concatenation of the inputs. Each input is converted to a string as if by `to-string`.
        { "concat", TMBOperator.Concat },

        /// Returns the cosine of the input.
        { "cos", TMBOperator.Cos },

        /// Returns the shortest distance in meters between the evaluated feature and the input geometry. The input value can be a valid GeoJSON of type `Point`, `MultiPoint`, `LineString`, `MultiLineString`, `Polygon`, `MultiPolygon`, `Feature`, or `FeatureCollection`. Distance values returned may vary in precision due to loss in precision from encoding geometries, particularly below zoom level 13.
        { "distance", TMBOperator.Distance },

        /// Returns the distance of a `symbol` instance from the center of the map. The distance is measured in pixels divided by the height of the map container. It measures 0 at the center, decreases towards the camera and increase away from the camera. For example, if the height of the map is 1000px, a value of -1 means 1000px away from the center towards the camera, and a value of 1 means a distance of 1000px away from the camera from the center. `["distance-from-center"]` may only be used in the `filter` expression for a `symbol` layer.
        { "distance-from-center", TMBOperator.DistanceFromCenter },

        /// Returns the input string converted to lowercase. Follows the Unicode Default Case Conversion algorithm and the locale-insensitive case mappings in the Unicode Character Database.
        { "downcase", TMBOperator.Downcase },

        /// Returns the mathematical constant e.
        { "e", TMBOperator.E },

        /// Retrieves a property value from the current feature's state. Returns `null` if the requested property is not present on the feature's state. A feature's state is not part of the GeoJSON or vector tile data, and must be set programmatically on each feature. Features are identified by their `id` attribute, which must be an integer or a string that can be cast to an integer. Note that ["feature-state"] can only be used with paint properties that support data-driven styling.
        { "feature-state", TMBOperator.FeatureState },

        /// Returns the largest integer that is less than or equal to the input.
        { "floor", TMBOperator.Floor },

        /// Returns a `formatted` string for displaying mixed-format text in the `text-field` property. The input may contain a string literal or expression, including an [`'image'`](#types-image) expression. Strings may be followed by a style override object that supports the following properties:
        /// - `"text-font"`: Overrides the font stack specified by the root layout property.
        /// - `"text-color"`: Overrides the color specified by the root paint property.
        /// - `"font-scale"`: Applies a scaling factor on `text-size` as specified by the root layout property.
        { "format", TMBOperator.Format },

        /// Returns the feature's geometry type: `Point`, `LineString` or `Polygon`. `Multi*` feature types return the singular forms.
        { "geometry-type", TMBOperator.GeometryType },

        /// Retrieves a property value from the current feature's properties, or from another object if a second argument is provided. Returns `null` if the requested property is missing.
        { "get", TMBOperator.Get },

        /// Tests for the presence of an property value in the current feature's properties, or from another object if a second argument is provided.
        { "has", TMBOperator.Has },

        /// Returns the kernel density estimation of a pixel in a heatmap layer, which is a relative measure of how many data points are crowded around a particular pixel. Can only be used in the `heatmap-color` property.
        { "heatmap-density", TMBOperator.HeatmapDensity },

        /// Returns the feature's id, if it has one.
        { "id", TMBOperator.Id },

        /// Returns a [`ResolvedImage`](/mapbox-gl-js/style-spec/types/#resolvedimage) for use in [`icon-image`](/mapbox-gl-js/style-spec/layers/#layout-symbol-icon-image), `*-pattern` entries, and as a section in the [`'format'`](#types-format) expression. A [`'coalesce'`](#coalesce) expression containing `image` expressions will evaluate to the first listed image that is currently in the style. This validation process is synchronous and requires the image to have been added to the style before requesting it in the `'image'` argument.
        { "image", TMBOperator.Image },

        /// Determines whether an item exists in an array or a substring exists in a string. In the specific case when the second and third arguments are string literals, you must wrap at least one of them in a [`literal`](#types-literal) expression to hint correct interpretation to the [type system](#type-system).
        { "in", TMBOperator.InExpression },

        /// Returns the first position at which an item can be found in an array or a substring can be found in a string, or `-1` if the input cannot be found. Accepts an optional index from where to begin the search.
        { "index-of", TMBOperator.IndexOf },

        /// Produces continuous, smooth results by interpolating between pairs of input and output values ("stops"). The `input` may be any numeric expression (e.g., `["get", "population"]`). Stop inputs must be numeric literals in strictly ascending order. The output type must be `number`, `array<number>`, or `color`.
        ///
        /// Interpolation types:
        /// - `["linear"]`: Interpolates linearly between the pair of stops just less than and just greater than the input.
        /// - `["exponential", base]`: Interpolates exponentially between the stops just less than and just greater than the input. `base` controls the rate at which the output increases: higher values make the output increase more towards the high end of the range. With values close to 1 the output increases linearly.
        /// - `["cubic-bezier", x1, y1, x2, y2]`: Interpolates using the cubic bezier curve defined by the given control points.
        { "interpolate", TMBOperator.Interpolate },

        /// Returns `true` if the input string is expected to render legibly. Returns `false` if the input string contains sections that cannot be rendered without potential loss of meaning (e.g. Indic scripts that require complex text shaping, or right-to-left scripts if the the `mapbox-gl-rtl-text` plugin is not in use in Mapbox GL JS).
        { "is-supported-script", TMBOperator.IsSupportedScript },

        /// Returns the length of an array or string.
        { "length", TMBOperator.Length },

        /// Binds expressions to named variables, which can then be referenced in the result expression using ["var", "variable_name"].
        { "let", TMBOperator.LetExpression },

        /// Returns the progress along a gradient line. Can only be used in the `line-gradient` property.
        { "line-progress", TMBOperator.LineProgress },

        /// Provides a literal array or object value.
        { "literal", TMBOperator.Literal },

        /// Returns the natural logarithm of the input.
        { "ln", TMBOperator.Ln },

        /// Returns mathematical constant ln(2).
        { "ln2", TMBOperator.Ln2 },

        /// Returns the base-ten logarithm of the input.
        { "log10", TMBOperator.Log10 },

        /// Returns the base-two logarithm of the input.
        { "log2", TMBOperator.Log2 },

        /// Selects the output for which the label value matches the input value, or the fallback value if no match is found. The input can be any expression (for example, `["get", "building_type"]`). Each label must be unique, and must be either:
        ///  - a single literal value; or
        ///  - an array of literal values, the values of which must be all strings or all numbers (for example `[100, 101]` or `["c", "b"]`).
        ///
        /// The input matches if any of the values in the array matches using strict equality, similar to the `"in"` operator.
        /// If the input type does not match the type of the labels, the result will be the fallback value.
        { "match", TMBOperator.Match },

        /// Returns the maximum value of the inputs.
        { "max", TMBOperator.Max },

        /// Returns the minimum value of the inputs.
        { "min", TMBOperator.Min },

        /// Asserts that the input value is a number. If multiple values are provided, each one is evaluated in order until a number is obtained. If none of the inputs are numbers, the expression is an error.
        { "number", TMBOperator.Number },

        /// Converts the input number into a string representation using the providing formatting rules. If set, the `locale` argument specifies the locale to use, as a BCP 47 language tag. If set, the `currency` argument specifies an ISO 4217 code to use for currency-style formatting. If set, the `unit` argument specifies a [simple ECMAScript unit](https://tc39.es/proposal-unified-intl-numberformat/section6/locales-currencies-tz_proposed_out.html#sec-issanctionedsimpleunitidentifier) to use for unit-style formatting. If set, the `min-fraction-digits` and `max-fraction-digits` arguments specify the minimum and maximum number of fractional digits to include.
        { "number-format", TMBOperator.NumberFormat },

        /// Asserts that the input value is an object. If multiple values are provided, each one is evaluated in order until an object is obtained. If none of the inputs are objects, the expression is an error.
        { "object", TMBOperator.ObjectExpression },

        /// Returns the mathematical constant pi.
        { "pi", TMBOperator.Pi },

        /// Returns the current pitch in degrees. `["pitch"]` may only be used in the `filter` expression for a `symbol` layer.
        { "pitch", TMBOperator.Pitch },

        /// Returns the feature properties object.  Note that in some cases, it may be more efficient to use `["get", "property_name"]` directly.
        { "properties", TMBOperator.Properties },

        /// Returns the IETF language tag of the locale being used by the provided `collator`. This can be used to determine the default system locale, or to determine if a requested locale was successfully loaded.
        { "resolved-locale", TMBOperator.ResolvedLocale },

        /// Creates a color value from red, green, and blue components, which must range between 0 and 255, and an alpha component of 1. If any component is out of range, the expression is an error.
        { "rgb", TMBOperator.Rgb },

        /// Creates a color value from red, green, blue components, which must range between 0 and 255, and an alpha component which must range between 0 and 1. If any component is out of range, the expression is an error.
        { "rgba", TMBOperator.Rgba },

        /// Rounds the input to the nearest integer. Halfway values are rounded away from zero. For example, `["round", -1.5]` evaluates to -2.
        { "round", TMBOperator.Round },

        /// Returns the sine of the input.
        { "sin", TMBOperator.Sin },

        /// Returns the distance of a point on the sky from the sun position. Returns 0 at sun position and 1 when the distance reaches `sky-gradient-radius`. Can only be used in the `sky-gradient` property.
        { "sky-radial-progress", TMBOperator.SkyRadialProgress },

        /// Returns an item from an array or a substring from a string from a specified start index, or between a start index and an end index if set. The return value is inclusive of the start index but not of the end index.
        { "slice", TMBOperator.Slice },

        /// Returns the square root of the input.
        { "sqrt", TMBOperator.Sqrt },

        /// Produces discrete, stepped results by evaluating a piecewise-constant function defined by pairs of input and output values ("stops"). The `input` may be any numeric expression (e.g., `["get", "population"]`). Stop inputs must be numeric literals in strictly ascending order. Returns the output value of the stop just less than the input, or the first output if the input is less than the first stop.
        { "step", TMBOperator.Step },

        /// Asserts that the input value is a string. If multiple values are provided, each one is evaluated in order until a string is obtained. If none of the inputs are strings, the expression is an error.
        { "string", TMBOperator.String },

        /// Returns the tangent of the input.
        { "tan", TMBOperator.Tan },

        /// Converts the input value to a boolean. The result is `false` when then input is an empty string, 0, `false`, `null`, or `NaN`; otherwise it is `true`.
        { "to-boolean", TMBOperator.ToBoolean },

        /// Converts the input value to a color. If multiple values are provided, each one is evaluated in order until the first successful conversion is obtained. If none of the inputs can be converted, the expression is an error.
        { "to-color", TMBOperator.ToColor },

        /// Converts the input value to a number, if possible. If the input is `null` or `false`, the result is 0. If the input is `true`, the result is 1. If the input is a string, it is converted to a number as specified by the ["ToNumber Applied to the String Type" algorithm](https://tc39.github.io/ecma262/#sec-tonumber-applied-to-the-string-type) of the ECMAScript Language Specification. If multiple values are provided, each one is evaluated in order until the first successful conversion is obtained. If none of the inputs can be converted, the expression is an error.
        { "to-number", TMBOperator.ToNumber },

        /// Returns a four-element array containing the input color's red, green, blue, and alpha components, in that order.
        { "to-rgba", TMBOperator.ToRgba },

        /// Converts the input value to a string. If the input is `null`, the result is `""`. If the input is a [`boolean`](#types-boolean), the result is `"true"` or `"false"`. If the input is a number, it is converted to a string as specified by the ["NumberToString" algorithm](https://tc39.github.io/ecma262/#sec-tostring-applied-to-the-number-type) of the ECMAScript Language Specification. If the input is a [`color`](#color), it is converted to a string of the form `"rgba(r,g,b,a)"`, where `r`, `g`, and `b` are numerals ranging from 0 to 255, and `a` ranges from 0 to 1. If the input is an [`'image'`](#types-image) expression, `'to-string'` returns the image name. Otherwise, the input is converted to a string in the format specified by the [`JSON.stringify`](https://tc39.github.io/ecma262/#sec-json.stringify) function of the ECMAScript Language Specification.
        { "to-string", TMBOperator.ToString },

        /// Returns a string describing the type of the given value.
        { "typeof", TMBOperator.TypeofExpression },

        /// Returns the input string converted to uppercase. Follows the Unicode Default Case Conversion algorithm and the locale-insensitive case mappings in the Unicode Character Database.
        { "upcase", TMBOperator.Upcase },

        /// References variable bound using "let".
        { "var", TMBOperator.VarExpression },

        /// Returns `true` if the evaluated feature is fully contained inside a boundary of the input geometry, `false` otherwise. The input value can be a valid GeoJSON of type `Polygon`, `MultiPolygon`, `Feature`, or `FeatureCollection`. Supported features for evaluation:
        /// - `Point`: Returns `false` if a point is on the boundary or falls outside the boundary.
        /// - `LineString`: Returns `false` if any part of a line falls outside the boundary, the line intersects the boundary, or a line's endpoint is on the boundary.
        { "within", TMBOperator.Within },

        /// Returns the current zoom level.  Note that in style layout and paint properties, ["zoom"] may only appear as the input to a top-level "step" or "interpolate" expression.
        { "zoom", TMBOperator.Zoom },

        /// Interpolates linearly between the pair of stops just less than and just greater than the input
        { "linear", TMBOperator.Linear },

        /// `["exponential", base]`
        /// Interpolates exponentially between the stops just less than and just
        /// greater than the input. base controls the rate at which the output increases: higher values make the output
        /// increase more towards the high end of the range.
        /// With values close to 1 the output increases linearly.
        { "exponential", TMBOperator.Exponential },

        /// `["cubic-bezier", x1, y1, x2, y2]`
        /// Interpolates using the cubic bezier curve defined by the given control points.
        { "cubic-bezier", TMBOperator.CubicBezier },
    };
}

