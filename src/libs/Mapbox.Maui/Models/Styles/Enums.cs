namespace MapboxMaui;
#if IOS
using MapboxMapsObjC;
#endif
// This file is generated.

public readonly struct Visibility : INamedString
{

    /// The layer is shown.
    public static readonly Visibility Visible = new ("visible");

    /// The layer is not shown.
    public static readonly Visibility None = new ("none");

    public string Value { get; }

    private Visibility(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(Visibility value) => value.Value;
    public static implicit operator Visibility(string value) => new (value);
}
public static partial class VisibilityExtensions {}
#if IOS    
partial class VisibilityExtensions
{
    public static MapboxMapsObjC.TMBVisibility ToPlatform(this Visibility value)
    {
        return value.Value switch 
        {
            "visible" => MapboxMapsObjC.TMBVisibility.Visible,
            "none" => MapboxMapsObjC.TMBVisibility.None
        };
    }

    public static Visibility ToPlatform(this MapboxMapsObjC.TMBVisibility value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBVisibility.Visible => "visible",
            MapboxMapsObjC.TMBVisibility.None => "none"
        };
    }

    public static Visibility VisibilityX(this Foundation.NSNumber value)
    {
        return value.Visibility().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this Visibility value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class VisibilityExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.Visibility ToPlatform(this Visibility value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.Visibility.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: LINE_CAP

/// The display of line endings.
public readonly struct LineCap : INamedString
{

    /// A cap with a squared-off end which is drawn to the exact endpoint of the line.
    public static readonly LineCap Butt = new ("butt");

    /// A cap with a rounded end which is drawn beyond the endpoint of the line at a radius of one-half of the line's width and centered on the endpoint of the line.
    public static readonly LineCap Round = new ("round");

    /// A cap with a squared-off end which is drawn beyond the endpoint of the line at a distance of one-half of the line's width.
    public static readonly LineCap Square = new ("square");


    public string Value { get; }

    private LineCap(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(LineCap value) => value.Value;
    public static implicit operator LineCap(string value) => new (value);
}
public static partial class LineCapExtensions {}
#if IOS    
partial class LineCapExtensions
{
    public static MapboxMapsObjC.TMBLineCap ToPlatform(this LineCap value)
    {
        return value.Value switch 
        {
            "butt" => MapboxMapsObjC.TMBLineCap.Butt,
            "round" => MapboxMapsObjC.TMBLineCap.Round,
            "square" => MapboxMapsObjC.TMBLineCap.Square
        };
    }

    public static LineCap ToPlatform(this MapboxMapsObjC.TMBLineCap value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBLineCap.Butt => "butt",
            MapboxMapsObjC.TMBLineCap.Round => "round",
            MapboxMapsObjC.TMBLineCap.Square => "square"
        };
    }

    public static LineCap LineCapX(this Foundation.NSNumber value)
    {
        return value.LineCap().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this LineCap value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class LineCapExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.LineCap ToPlatform(this LineCap value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.LineCap.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: LINE_JOIN

/// The display of lines when joining.
public readonly struct LineJoin : INamedString
{

    /// A join with a squared-off end which is drawn beyond the endpoint of the line at a distance of one-half of the line's width.
    public static readonly LineJoin Bevel = new ("bevel");

    /// A join with a rounded end which is drawn beyond the endpoint of the line at a radius of one-half of the line's width and centered on the endpoint of the line.
    public static readonly LineJoin Round = new ("round");

    /// A join with a sharp, angled corner which is drawn with the outer sides beyond the endpoint of the path until they meet.
    public static readonly LineJoin Miter = new ("miter");


    public string Value { get; }

    private LineJoin(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(LineJoin value) => value.Value;
    public static implicit operator LineJoin(string value) => new (value);
}
public static partial class LineJoinExtensions {}
#if IOS    
partial class LineJoinExtensions
{
    public static MapboxMapsObjC.TMBLineJoin ToPlatform(this LineJoin value)
    {
        return value.Value switch 
        {
            "bevel" => MapboxMapsObjC.TMBLineJoin.Bevel,
            "round" => MapboxMapsObjC.TMBLineJoin.Round,
            "miter" => MapboxMapsObjC.TMBLineJoin.Miter
        };
    }

    public static LineJoin ToPlatform(this MapboxMapsObjC.TMBLineJoin value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBLineJoin.Bevel => "bevel",
            MapboxMapsObjC.TMBLineJoin.Round => "round",
            MapboxMapsObjC.TMBLineJoin.Miter => "miter"
        };
    }

    public static LineJoin LineJoinX(this Foundation.NSNumber value)
    {
        return value.LineJoin().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this LineJoin value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class LineJoinExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.LineJoin ToPlatform(this LineJoin value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.LineJoin.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: ICON_ANCHOR

/// Part of the icon placed closest to the anchor.
public readonly struct IconAnchor : INamedString
{

    /// The center of the icon is placed closest to the anchor.
    public static readonly IconAnchor Center = new ("center");

    /// The left side of the icon is placed closest to the anchor.
    public static readonly IconAnchor Left = new ("left");

    /// The right side of the icon is placed closest to the anchor.
    public static readonly IconAnchor Right = new ("right");

    /// The top of the icon is placed closest to the anchor.
    public static readonly IconAnchor Top = new ("top");

    /// The bottom of the icon is placed closest to the anchor.
    public static readonly IconAnchor Bottom = new ("bottom");

    /// The top left corner of the icon is placed closest to the anchor.
    public static readonly IconAnchor TopLeft = new ("top-left");

    /// The top right corner of the icon is placed closest to the anchor.
    public static readonly IconAnchor TopRight = new ("top-right");

    /// The bottom left corner of the icon is placed closest to the anchor.
    public static readonly IconAnchor BottomLeft = new ("bottom-left");

    /// The bottom right corner of the icon is placed closest to the anchor.
    public static readonly IconAnchor BottomRight = new ("bottom-right");


    public string Value { get; }

    private IconAnchor(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(IconAnchor value) => value.Value;
    public static implicit operator IconAnchor(string value) => new (value);
}
public static partial class IconAnchorExtensions {}
#if IOS    
partial class IconAnchorExtensions
{
    public static MapboxMapsObjC.TMBIconAnchor ToPlatform(this IconAnchor value)
    {
        return value.Value switch 
        {
            "center" => MapboxMapsObjC.TMBIconAnchor.Center,
            "left" => MapboxMapsObjC.TMBIconAnchor.Left,
            "right" => MapboxMapsObjC.TMBIconAnchor.Right,
            "top" => MapboxMapsObjC.TMBIconAnchor.Top,
            "bottom" => MapboxMapsObjC.TMBIconAnchor.Bottom,
            "top-left" => MapboxMapsObjC.TMBIconAnchor.TopLeft,
            "top-right" => MapboxMapsObjC.TMBIconAnchor.TopRight,
            "bottom-left" => MapboxMapsObjC.TMBIconAnchor.BottomLeft,
            "bottom-right" => MapboxMapsObjC.TMBIconAnchor.BottomRight
        };
    }

    public static IconAnchor ToPlatform(this MapboxMapsObjC.TMBIconAnchor value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBIconAnchor.Center => "center",
            MapboxMapsObjC.TMBIconAnchor.Left => "left",
            MapboxMapsObjC.TMBIconAnchor.Right => "right",
            MapboxMapsObjC.TMBIconAnchor.Top => "top",
            MapboxMapsObjC.TMBIconAnchor.Bottom => "bottom",
            MapboxMapsObjC.TMBIconAnchor.TopLeft => "top-left",
            MapboxMapsObjC.TMBIconAnchor.TopRight => "top-right",
            MapboxMapsObjC.TMBIconAnchor.BottomLeft => "bottom-left",
            MapboxMapsObjC.TMBIconAnchor.BottomRight => "bottom-right"
        };
    }

    public static IconAnchor IconAnchorX(this Foundation.NSNumber value)
    {
        return value.IconAnchor().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this IconAnchor value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class IconAnchorExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.IconAnchor ToPlatform(this IconAnchor value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.IconAnchor.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: ICON_PITCH_ALIGNMENT

/// Orientation of icon when map is pitched.
public readonly struct IconPitchAlignment : INamedString
{

    /// The icon is aligned to the plane of the map.
    public static readonly IconPitchAlignment Map = new ("map");

    /// The icon is aligned to the plane of the viewport.
    public static readonly IconPitchAlignment Viewport = new ("viewport");

    /// Automatically matches the value of {@link ICON_ROTATION_ALIGNMENT}.
    public static readonly IconPitchAlignment Auto = new ("auto");


    public string Value { get; }

    private IconPitchAlignment(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(IconPitchAlignment value) => value.Value;
    public static implicit operator IconPitchAlignment(string value) => new (value);
}
public static partial class IconPitchAlignmentExtensions {}
#if IOS    
partial class IconPitchAlignmentExtensions
{
    public static MapboxMapsObjC.TMBIconPitchAlignment ToPlatform(this IconPitchAlignment value)
    {
        return value.Value switch 
        {
            "map" => MapboxMapsObjC.TMBIconPitchAlignment.Map,
            "viewport" => MapboxMapsObjC.TMBIconPitchAlignment.Viewport,
            "auto" => MapboxMapsObjC.TMBIconPitchAlignment.Auto
        };
    }

    public static IconPitchAlignment ToPlatform(this MapboxMapsObjC.TMBIconPitchAlignment value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBIconPitchAlignment.Map => "map",
            MapboxMapsObjC.TMBIconPitchAlignment.Viewport => "viewport",
            MapboxMapsObjC.TMBIconPitchAlignment.Auto => "auto"
        };
    }

    public static IconPitchAlignment IconPitchAlignmentX(this Foundation.NSNumber value)
    {
        return value.IconPitchAlignment().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this IconPitchAlignment value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class IconPitchAlignmentExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.IconPitchAlignment ToPlatform(this IconPitchAlignment value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.IconPitchAlignment.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: ICON_ROTATION_ALIGNMENT

/// In combination with `symbol-placement`, determines the rotation behavior of icons.
public readonly struct IconRotationAlignment : INamedString
{

    /// When {@link SYMBOL_PLACEMENT} is set to {@link Property#SYMBOL_PLACEMENT_POINT}, aligns icons east-west. When {@link SYMBOL_PLACEMENT} is set to {@link Property#SYMBOL_PLACEMENT_LINE} or {@link Property#SYMBOL_PLACEMENT_LINE_CENTER}, aligns icon x-axes with the line.
    public static readonly IconRotationAlignment Map = new ("map");

    /// Produces icons whose x-axes are aligned with the x-axis of the viewport, regardless of the value of {@link SYMBOL_PLACEMENT}.
    public static readonly IconRotationAlignment Viewport = new ("viewport");

    /// When {@link SYMBOL_PLACEMENT} is set to {@link Property#SYMBOL_PLACEMENT_POINT}, this is equivalent to {@link Property#ICON_ROTATION_ALIGNMENT_VIEWPORT}. When {@link SYMBOL_PLACEMENT} is set to {@link Property#SYMBOL_PLACEMENT_LINE} or {@link Property#SYMBOL_PLACEMENT_LINE_CENTER}, this is equivalent to {@link Property#ICON_ROTATION_ALIGNMENT_MAP}.
    public static readonly IconRotationAlignment Auto = new ("auto");


    public string Value { get; }

    private IconRotationAlignment(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(IconRotationAlignment value) => value.Value;
    public static implicit operator IconRotationAlignment(string value) => new (value);
}
public static partial class IconRotationAlignmentExtensions {}
#if IOS    
partial class IconRotationAlignmentExtensions
{
    public static MapboxMapsObjC.TMBIconRotationAlignment ToPlatform(this IconRotationAlignment value)
    {
        return value.Value switch 
        {
            "map" => MapboxMapsObjC.TMBIconRotationAlignment.Map,
            "viewport" => MapboxMapsObjC.TMBIconRotationAlignment.Viewport,
            "auto" => MapboxMapsObjC.TMBIconRotationAlignment.Auto
        };
    }

    public static IconRotationAlignment ToPlatform(this MapboxMapsObjC.TMBIconRotationAlignment value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBIconRotationAlignment.Map => "map",
            MapboxMapsObjC.TMBIconRotationAlignment.Viewport => "viewport",
            MapboxMapsObjC.TMBIconRotationAlignment.Auto => "auto"
        };
    }

    public static IconRotationAlignment IconRotationAlignmentX(this Foundation.NSNumber value)
    {
        return value.IconRotationAlignment().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this IconRotationAlignment value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class IconRotationAlignmentExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.IconRotationAlignment ToPlatform(this IconRotationAlignment value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.IconRotationAlignment.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: ICON_TEXT_FIT

/// Scales the icon to fit around the associated text.
public readonly struct IconTextFit : INamedString
{

    /// The icon is displayed at its intrinsic aspect ratio.
    public static readonly IconTextFit None = new ("none");

    /// The icon is scaled in the x-dimension to fit the width of the text.
    public static readonly IconTextFit Width = new ("width");

    /// The icon is scaled in the y-dimension to fit the height of the text.
    public static readonly IconTextFit Height = new ("height");

    /// The icon is scaled in both x- and y-dimensions.
    public static readonly IconTextFit Both = new ("both");


    public string Value { get; }

    private IconTextFit(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(IconTextFit value) => value.Value;
    public static implicit operator IconTextFit(string value) => new (value);
}
public static partial class IconTextFitExtensions {}
#if IOS    
partial class IconTextFitExtensions
{
    public static MapboxMapsObjC.TMBIconTextFit ToPlatform(this IconTextFit value)
    {
        return value.Value switch 
        {
            "none" => MapboxMapsObjC.TMBIconTextFit.None,
            "width" => MapboxMapsObjC.TMBIconTextFit.Width,
            "height" => MapboxMapsObjC.TMBIconTextFit.Height,
            "both" => MapboxMapsObjC.TMBIconTextFit.Both
        };
    }

    public static IconTextFit ToPlatform(this MapboxMapsObjC.TMBIconTextFit value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBIconTextFit.None => "none",
            MapboxMapsObjC.TMBIconTextFit.Width => "width",
            MapboxMapsObjC.TMBIconTextFit.Height => "height",
            MapboxMapsObjC.TMBIconTextFit.Both => "both"
        };
    }

    public static IconTextFit IconTextFitX(this Foundation.NSNumber value)
    {
        return value.IconTextFit().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this IconTextFit value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class IconTextFitExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.IconTextFit ToPlatform(this IconTextFit value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.IconTextFit.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: SYMBOL_PLACEMENT

/// Label placement relative to its geometry.
public readonly struct SymbolPlacement : INamedString
{

    /// The label is placed at the point where the geometry is located.
    public static readonly SymbolPlacement Point = new ("point");

    /// The label is placed along the line of the geometry. Can only be used on LineString and Polygon geometries.
    public static readonly SymbolPlacement Line = new ("line");

    /// The label is placed at the center of the line of the geometry. Can only be used on LineString and Polygon geometries. Note that a single feature in a vector tile may contain multiple line geometries.
    public static readonly SymbolPlacement LineCenter = new ("line-center");


    public string Value { get; }

    private SymbolPlacement(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(SymbolPlacement value) => value.Value;
    public static implicit operator SymbolPlacement(string value) => new (value);
}
public static partial class SymbolPlacementExtensions {}
#if IOS    
partial class SymbolPlacementExtensions
{
    public static MapboxMapsObjC.TMBSymbolPlacement ToPlatform(this SymbolPlacement value)
    {
        return value.Value switch 
        {
            "point" => MapboxMapsObjC.TMBSymbolPlacement.Point,
            "line" => MapboxMapsObjC.TMBSymbolPlacement.Line,
            "line-center" => MapboxMapsObjC.TMBSymbolPlacement.LineCenter
        };
    }

    public static SymbolPlacement ToPlatform(this MapboxMapsObjC.TMBSymbolPlacement value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBSymbolPlacement.Point => "point",
            MapboxMapsObjC.TMBSymbolPlacement.Line => "line",
            MapboxMapsObjC.TMBSymbolPlacement.LineCenter => "line-center"
        };
    }

    public static SymbolPlacement SymbolPlacementX(this Foundation.NSNumber value)
    {
        return value.SymbolPlacement().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this SymbolPlacement value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class SymbolPlacementExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.SymbolPlacement ToPlatform(this SymbolPlacement value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.SymbolPlacement.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: SYMBOL_Z_ORDER

/// Determines whether overlapping symbols in the same layer are rendered in the order that they appear in the data source or by their y-position relative to the viewport. To control the order and prioritization of symbols otherwise, use `symbol-sort-key`.
public readonly struct SymbolZOrder : INamedString
{

    /// Sorts symbols by symbol sort key if set. Otherwise, sorts symbols by their y-position relative to the viewport if {@link ICON_ALLOW_OVERLAP} or {@link TEXT_ALLOW_OVERLAP} is set to {@link TRUE} or {@link ICON_IGNORE_PLACEMENT} or {@link TEXT_IGNORE_PLACEMENT} is {@link FALSE}.
    public static readonly SymbolZOrder Auto = new ("auto");

    /// Sorts symbols by their y-position relative to the viewport if {@link ICON_ALLOW_OVERLAP} or {@link TEXT_ALLOW_OVERLAP} is set to {@link TRUE} or {@link ICON_IGNORE_PLACEMENT} or {@link TEXT_IGNORE_PLACEMENT} is {@link FALSE}.
    public static readonly SymbolZOrder ViewportY = new ("viewport-y");

    /// Sorts symbols by symbol sort key if set. Otherwise, no sorting is applied; symbols are rendered in the same order as the source data.
    public static readonly SymbolZOrder Source = new ("source");


    public string Value { get; }

    private SymbolZOrder(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(SymbolZOrder value) => value.Value;
    public static implicit operator SymbolZOrder(string value) => new (value);
}
public static partial class SymbolZOrderExtensions {}
#if IOS    
partial class SymbolZOrderExtensions
{
    public static MapboxMapsObjC.TMBSymbolZOrder ToPlatform(this SymbolZOrder value)
    {
        return value.Value switch 
        {
            "auto" => MapboxMapsObjC.TMBSymbolZOrder.Auto,
            "viewport-y" => MapboxMapsObjC.TMBSymbolZOrder.ViewportY,
            "source" => MapboxMapsObjC.TMBSymbolZOrder.Source
        };
    }

    public static SymbolZOrder ToPlatform(this MapboxMapsObjC.TMBSymbolZOrder value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBSymbolZOrder.Auto => "auto",
            MapboxMapsObjC.TMBSymbolZOrder.ViewportY => "viewport-y",
            MapboxMapsObjC.TMBSymbolZOrder.Source => "source"
        };
    }

    public static SymbolZOrder SymbolZOrderX(this Foundation.NSNumber value)
    {
        return value.SymbolZOrder().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this SymbolZOrder value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class SymbolZOrderExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.SymbolZOrder ToPlatform(this SymbolZOrder value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.SymbolZOrder.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: TEXT_ANCHOR

/// Part of the text placed closest to the anchor.
public readonly struct TextAnchor : INamedString
{

    /// The center of the text is placed closest to the anchor.
    public static readonly TextAnchor Center = new ("center");

    /// The left side of the text is placed closest to the anchor.
    public static readonly TextAnchor Left = new ("left");

    /// The right side of the text is placed closest to the anchor.
    public static readonly TextAnchor Right = new ("right");

    /// The top of the text is placed closest to the anchor.
    public static readonly TextAnchor Top = new ("top");

    /// The bottom of the text is placed closest to the anchor.
    public static readonly TextAnchor Bottom = new ("bottom");

    /// The top left corner of the text is placed closest to the anchor.
    public static readonly TextAnchor TopLeft = new ("top-left");

    /// The top right corner of the text is placed closest to the anchor.
    public static readonly TextAnchor TopRight = new ("top-right");

    /// The bottom left corner of the text is placed closest to the anchor.
    public static readonly TextAnchor BottomLeft = new ("bottom-left");

    /// The bottom right corner of the text is placed closest to the anchor.
    public static readonly TextAnchor BottomRight = new ("bottom-right");


    public string Value { get; }

    private TextAnchor(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(TextAnchor value) => value.Value;
    public static implicit operator TextAnchor(string value) => new (value);
}
public static partial class TextAnchorExtensions {}
#if IOS    
partial class TextAnchorExtensions
{
    public static MapboxMapsObjC.TMBTextAnchor ToPlatform(this TextAnchor value)
    {
        return value.Value switch 
        {
            "center" => MapboxMapsObjC.TMBTextAnchor.Center,
            "left" => MapboxMapsObjC.TMBTextAnchor.Left,
            "right" => MapboxMapsObjC.TMBTextAnchor.Right,
            "top" => MapboxMapsObjC.TMBTextAnchor.Top,
            "bottom" => MapboxMapsObjC.TMBTextAnchor.Bottom,
            "top-left" => MapboxMapsObjC.TMBTextAnchor.TopLeft,
            "top-right" => MapboxMapsObjC.TMBTextAnchor.TopRight,
            "bottom-left" => MapboxMapsObjC.TMBTextAnchor.BottomLeft,
            "bottom-right" => MapboxMapsObjC.TMBTextAnchor.BottomRight
        };
    }

    public static TextAnchor ToPlatform(this MapboxMapsObjC.TMBTextAnchor value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBTextAnchor.Center => "center",
            MapboxMapsObjC.TMBTextAnchor.Left => "left",
            MapboxMapsObjC.TMBTextAnchor.Right => "right",
            MapboxMapsObjC.TMBTextAnchor.Top => "top",
            MapboxMapsObjC.TMBTextAnchor.Bottom => "bottom",
            MapboxMapsObjC.TMBTextAnchor.TopLeft => "top-left",
            MapboxMapsObjC.TMBTextAnchor.TopRight => "top-right",
            MapboxMapsObjC.TMBTextAnchor.BottomLeft => "bottom-left",
            MapboxMapsObjC.TMBTextAnchor.BottomRight => "bottom-right"
        };
    }

    public static TextAnchor TextAnchorX(this Foundation.NSNumber value)
    {
        return value.TextAnchor().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this TextAnchor value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class TextAnchorExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.TextAnchor ToPlatform(this TextAnchor value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.TextAnchor.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: TEXT_JUSTIFY

/// Text justification options.
public readonly struct TextJustify : INamedString
{

    /// The text is aligned towards the anchor position.
    public static readonly TextJustify Auto = new ("auto");

    /// The text is aligned to the left.
    public static readonly TextJustify Left = new ("left");

    /// The text is centered.
    public static readonly TextJustify Center = new ("center");

    /// The text is aligned to the right.
    public static readonly TextJustify Right = new ("right");


    public string Value { get; }

    private TextJustify(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(TextJustify value) => value.Value;
    public static implicit operator TextJustify(string value) => new (value);
}
public static partial class TextJustifyExtensions {}
#if IOS    
partial class TextJustifyExtensions
{
    public static MapboxMapsObjC.TMBTextJustify ToPlatform(this TextJustify value)
    {
        return value.Value switch 
        {
            "auto" => MapboxMapsObjC.TMBTextJustify.Auto,
            "left" => MapboxMapsObjC.TMBTextJustify.Left,
            "center" => MapboxMapsObjC.TMBTextJustify.Center,
            "right" => MapboxMapsObjC.TMBTextJustify.Right
        };
    }

    public static TextJustify ToPlatform(this MapboxMapsObjC.TMBTextJustify value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBTextJustify.Auto => "auto",
            MapboxMapsObjC.TMBTextJustify.Left => "left",
            MapboxMapsObjC.TMBTextJustify.Center => "center",
            MapboxMapsObjC.TMBTextJustify.Right => "right"
        };
    }

    public static TextJustify TextJustifyX(this Foundation.NSNumber value)
    {
        return value.TextJustify().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this TextJustify value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class TextJustifyExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.TextJustify ToPlatform(this TextJustify value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.TextJustify.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: TEXT_PITCH_ALIGNMENT

/// Orientation of text when map is pitched.
public readonly struct TextPitchAlignment : INamedString
{

    /// The text is aligned to the plane of the map.
    public static readonly TextPitchAlignment Map = new ("map");

    /// The text is aligned to the plane of the viewport.
    public static readonly TextPitchAlignment Viewport = new ("viewport");

    /// Automatically matches the value of {@link TEXT_ROTATION_ALIGNMENT}.
    public static readonly TextPitchAlignment Auto = new ("auto");


    public string Value { get; }

    private TextPitchAlignment(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(TextPitchAlignment value) => value.Value;
    public static implicit operator TextPitchAlignment(string value) => new (value);
}
public static partial class TextPitchAlignmentExtensions {}
#if IOS    
partial class TextPitchAlignmentExtensions
{
    public static MapboxMapsObjC.TMBTextPitchAlignment ToPlatform(this TextPitchAlignment value)
    {
        return value.Value switch 
        {
            "map" => MapboxMapsObjC.TMBTextPitchAlignment.Map,
            "viewport" => MapboxMapsObjC.TMBTextPitchAlignment.Viewport,
            "auto" => MapboxMapsObjC.TMBTextPitchAlignment.Auto
        };
    }

    public static TextPitchAlignment ToPlatform(this MapboxMapsObjC.TMBTextPitchAlignment value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBTextPitchAlignment.Map => "map",
            MapboxMapsObjC.TMBTextPitchAlignment.Viewport => "viewport",
            MapboxMapsObjC.TMBTextPitchAlignment.Auto => "auto"
        };
    }

    public static TextPitchAlignment TextPitchAlignmentX(this Foundation.NSNumber value)
    {
        return value.TextPitchAlignment().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this TextPitchAlignment value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class TextPitchAlignmentExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.TextPitchAlignment ToPlatform(this TextPitchAlignment value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.TextPitchAlignment.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: TEXT_ROTATION_ALIGNMENT

/// In combination with `symbol-placement`, determines the rotation behavior of the individual glyphs forming the text.
public readonly struct TextRotationAlignment : INamedString
{

    /// When {@link SYMBOL_PLACEMENT} is set to {@link Property#SYMBOL_PLACEMENT_POINT}, aligns text east-west. When {@link SYMBOL_PLACEMENT} is set to {@link Property#SYMBOL_PLACEMENT_LINE} or {@link Property#SYMBOL_PLACEMENT_LINE_CENTER}, aligns text x-axes with the line.
    public static readonly TextRotationAlignment Map = new ("map");

    /// Produces glyphs whose x-axes are aligned with the x-axis of the viewport, regardless of the value of {@link SYMBOL_PLACEMENT}.
    public static readonly TextRotationAlignment Viewport = new ("viewport");

    /// When {@link SYMBOL_PLACEMENT} is set to {@link Property#SYMBOL_PLACEMENT_POINT}, this is equivalent to {@link Property#TEXT_ROTATION_ALIGNMENT_VIEWPORT}. When {@link SYMBOL_PLACEMENT} is set to {@link Property#SYMBOL_PLACEMENT_LINE} or {@link Property#SYMBOL_PLACEMENT_LINE_CENTER}, this is equivalent to {@link Property#TEXT_ROTATION_ALIGNMENT_MAP}.
    public static readonly TextRotationAlignment Auto = new ("auto");


    public string Value { get; }

    private TextRotationAlignment(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(TextRotationAlignment value) => value.Value;
    public static implicit operator TextRotationAlignment(string value) => new (value);
}
public static partial class TextRotationAlignmentExtensions {}
#if IOS    
partial class TextRotationAlignmentExtensions
{
    public static MapboxMapsObjC.TMBTextRotationAlignment ToPlatform(this TextRotationAlignment value)
    {
        return value.Value switch 
        {
            "map" => MapboxMapsObjC.TMBTextRotationAlignment.Map,
            "viewport" => MapboxMapsObjC.TMBTextRotationAlignment.Viewport,
            "auto" => MapboxMapsObjC.TMBTextRotationAlignment.Auto
        };
    }

    public static TextRotationAlignment ToPlatform(this MapboxMapsObjC.TMBTextRotationAlignment value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBTextRotationAlignment.Map => "map",
            MapboxMapsObjC.TMBTextRotationAlignment.Viewport => "viewport",
            MapboxMapsObjC.TMBTextRotationAlignment.Auto => "auto"
        };
    }

    public static TextRotationAlignment TextRotationAlignmentX(this Foundation.NSNumber value)
    {
        return value.TextRotationAlignment().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this TextRotationAlignment value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class TextRotationAlignmentExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.TextRotationAlignment ToPlatform(this TextRotationAlignment value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.TextRotationAlignment.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: TEXT_TRANSFORM

/// Specifies how to capitalize text, similar to the CSS `text-transform` property.
public readonly struct TextTransform : INamedString
{

    /// The text is not altered.
    public static readonly TextTransform None = new ("none");

    /// Forces all letters to be displayed in uppercase.
    public static readonly TextTransform Uppercase = new ("uppercase");

    /// Forces all letters to be displayed in lowercase.
    public static readonly TextTransform Lowercase = new ("lowercase");


    public string Value { get; }

    private TextTransform(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(TextTransform value) => value.Value;
    public static implicit operator TextTransform(string value) => new (value);
}
public static partial class TextTransformExtensions {}
#if IOS    
partial class TextTransformExtensions
{
    public static MapboxMapsObjC.TMBTextTransform ToPlatform(this TextTransform value)
    {
        return value.Value switch 
        {
            "none" => MapboxMapsObjC.TMBTextTransform.None,
            "uppercase" => MapboxMapsObjC.TMBTextTransform.Uppercase,
            "lowercase" => MapboxMapsObjC.TMBTextTransform.Lowercase
        };
    }

    public static TextTransform ToPlatform(this MapboxMapsObjC.TMBTextTransform value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBTextTransform.None => "none",
            MapboxMapsObjC.TMBTextTransform.Uppercase => "uppercase",
            MapboxMapsObjC.TMBTextTransform.Lowercase => "lowercase"
        };
    }

    public static TextTransform TextTransformX(this Foundation.NSNumber value)
    {
        return value.TextTransform().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this TextTransform value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class TextTransformExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.TextTransform ToPlatform(this TextTransform value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.TextTransform.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: FILL_TRANSLATE_ANCHOR

/// Controls the frame of reference for `fill-translate`.
public readonly struct FillTranslateAnchor : INamedString
{

    /// The fill is translated relative to the map.
    public static readonly FillTranslateAnchor Map = new ("map");

    /// The fill is translated relative to the viewport.
    public static readonly FillTranslateAnchor Viewport = new ("viewport");


    public string Value { get; }

    private FillTranslateAnchor(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(FillTranslateAnchor value) => value.Value;
    public static implicit operator FillTranslateAnchor(string value) => new (value);
}
public static partial class FillTranslateAnchorExtensions {}
#if IOS    
partial class FillTranslateAnchorExtensions
{
    public static MapboxMapsObjC.TMBFillTranslateAnchor ToPlatform(this FillTranslateAnchor value)
    {
        return value.Value switch 
        {
            "map" => MapboxMapsObjC.TMBFillTranslateAnchor.Map,
            "viewport" => MapboxMapsObjC.TMBFillTranslateAnchor.Viewport
        };
    }

    public static FillTranslateAnchor ToPlatform(this MapboxMapsObjC.TMBFillTranslateAnchor value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBFillTranslateAnchor.Map => "map",
            MapboxMapsObjC.TMBFillTranslateAnchor.Viewport => "viewport"
        };
    }

    public static FillTranslateAnchor FillTranslateAnchorX(this Foundation.NSNumber value)
    {
        return value.FillTranslateAnchor().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this FillTranslateAnchor value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class FillTranslateAnchorExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.FillTranslateAnchor ToPlatform(this FillTranslateAnchor value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.FillTranslateAnchor.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: LINE_TRANSLATE_ANCHOR

/// Controls the frame of reference for `line-translate`.
public readonly struct LineTranslateAnchor : INamedString
{

    /// The line is translated relative to the map.
    public static readonly LineTranslateAnchor Map = new ("map");

    /// The line is translated relative to the viewport.
    public static readonly LineTranslateAnchor Viewport = new ("viewport");


    public string Value { get; }

    private LineTranslateAnchor(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(LineTranslateAnchor value) => value.Value;
    public static implicit operator LineTranslateAnchor(string value) => new (value);
}
public static partial class LineTranslateAnchorExtensions {}
#if IOS    
partial class LineTranslateAnchorExtensions
{
    public static MapboxMapsObjC.TMBLineTranslateAnchor ToPlatform(this LineTranslateAnchor value)
    {
        return value.Value switch 
        {
            "map" => MapboxMapsObjC.TMBLineTranslateAnchor.Map,
            "viewport" => MapboxMapsObjC.TMBLineTranslateAnchor.Viewport
        };
    }

    public static LineTranslateAnchor ToPlatform(this MapboxMapsObjC.TMBLineTranslateAnchor value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBLineTranslateAnchor.Map => "map",
            MapboxMapsObjC.TMBLineTranslateAnchor.Viewport => "viewport"
        };
    }

    public static LineTranslateAnchor LineTranslateAnchorX(this Foundation.NSNumber value)
    {
        return value.LineTranslateAnchor().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this LineTranslateAnchor value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class LineTranslateAnchorExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.LineTranslateAnchor ToPlatform(this LineTranslateAnchor value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.LineTranslateAnchor.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: ICON_TRANSLATE_ANCHOR

/// Controls the frame of reference for `icon-translate`.
public readonly struct IconTranslateAnchor : INamedString
{

    /// Icons are translated relative to the map.
    public static readonly IconTranslateAnchor Map = new ("map");

    /// Icons are translated relative to the viewport.
    public static readonly IconTranslateAnchor Viewport = new ("viewport");


    public string Value { get; }

    private IconTranslateAnchor(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(IconTranslateAnchor value) => value.Value;
    public static implicit operator IconTranslateAnchor(string value) => new (value);
}
public static partial class IconTranslateAnchorExtensions {}
#if IOS    
partial class IconTranslateAnchorExtensions
{
    public static MapboxMapsObjC.TMBIconTranslateAnchor ToPlatform(this IconTranslateAnchor value)
    {
        return value.Value switch 
        {
            "map" => MapboxMapsObjC.TMBIconTranslateAnchor.Map,
            "viewport" => MapboxMapsObjC.TMBIconTranslateAnchor.Viewport
        };
    }

    public static IconTranslateAnchor ToPlatform(this MapboxMapsObjC.TMBIconTranslateAnchor value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBIconTranslateAnchor.Map => "map",
            MapboxMapsObjC.TMBIconTranslateAnchor.Viewport => "viewport"
        };
    }

    public static IconTranslateAnchor IconTranslateAnchorX(this Foundation.NSNumber value)
    {
        return value.IconTranslateAnchor().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this IconTranslateAnchor value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class IconTranslateAnchorExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.IconTranslateAnchor ToPlatform(this IconTranslateAnchor value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.IconTranslateAnchor.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: TEXT_TRANSLATE_ANCHOR

/// Controls the frame of reference for `text-translate`.
public readonly struct TextTranslateAnchor : INamedString
{

    /// The text is translated relative to the map.
    public static readonly TextTranslateAnchor Map = new ("map");

    /// The text is translated relative to the viewport.
    public static readonly TextTranslateAnchor Viewport = new ("viewport");


    public string Value { get; }

    private TextTranslateAnchor(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(TextTranslateAnchor value) => value.Value;
    public static implicit operator TextTranslateAnchor(string value) => new (value);
}
public static partial class TextTranslateAnchorExtensions {}
#if IOS    
partial class TextTranslateAnchorExtensions
{
    public static MapboxMapsObjC.TMBTextTranslateAnchor ToPlatform(this TextTranslateAnchor value)
    {
        return value.Value switch 
        {
            "map" => MapboxMapsObjC.TMBTextTranslateAnchor.Map,
            "viewport" => MapboxMapsObjC.TMBTextTranslateAnchor.Viewport
        };
    }

    public static TextTranslateAnchor ToPlatform(this MapboxMapsObjC.TMBTextTranslateAnchor value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBTextTranslateAnchor.Map => "map",
            MapboxMapsObjC.TMBTextTranslateAnchor.Viewport => "viewport"
        };
    }

    public static TextTranslateAnchor TextTranslateAnchorX(this Foundation.NSNumber value)
    {
        return value.TextTranslateAnchor().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this TextTranslateAnchor value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class TextTranslateAnchorExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.TextTranslateAnchor ToPlatform(this TextTranslateAnchor value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.TextTranslateAnchor.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: CIRCLE_PITCH_ALIGNMENT

/// Orientation of circle when map is pitched.
public readonly struct CirclePitchAlignment : INamedString
{

    /// The circle is aligned to the plane of the map.
    public static readonly CirclePitchAlignment Map = new ("map");

    /// The circle is aligned to the plane of the viewport.
    public static readonly CirclePitchAlignment Viewport = new ("viewport");


    public string Value { get; }

    private CirclePitchAlignment(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(CirclePitchAlignment value) => value.Value;
    public static implicit operator CirclePitchAlignment(string value) => new (value);
}
public static partial class CirclePitchAlignmentExtensions {}
#if IOS    
partial class CirclePitchAlignmentExtensions
{
    public static MapboxMapsObjC.TMBCirclePitchAlignment ToPlatform(this CirclePitchAlignment value)
    {
        return value.Value switch 
        {
            "map" => MapboxMapsObjC.TMBCirclePitchAlignment.Map,
            "viewport" => MapboxMapsObjC.TMBCirclePitchAlignment.Viewport
        };
    }

    public static CirclePitchAlignment ToPlatform(this MapboxMapsObjC.TMBCirclePitchAlignment value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBCirclePitchAlignment.Map => "map",
            MapboxMapsObjC.TMBCirclePitchAlignment.Viewport => "viewport"
        };
    }

    public static CirclePitchAlignment CirclePitchAlignmentX(this Foundation.NSNumber value)
    {
        return value.CirclePitchAlignment().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this CirclePitchAlignment value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class CirclePitchAlignmentExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.CirclePitchAlignment ToPlatform(this CirclePitchAlignment value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.CirclePitchAlignment.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: CIRCLE_PITCH_SCALE

/// Controls the scaling behavior of the circle when the map is pitched.
public readonly struct CirclePitchScale : INamedString
{

    /// Circles are scaled according to their apparent distance to the camera.
    public static readonly CirclePitchScale Map = new ("map");

    /// Circles are not scaled.
    public static readonly CirclePitchScale Viewport = new ("viewport");


    public string Value { get; }

    private CirclePitchScale(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(CirclePitchScale value) => value.Value;
    public static implicit operator CirclePitchScale(string value) => new (value);
}
public static partial class CirclePitchScaleExtensions {}
#if IOS    
partial class CirclePitchScaleExtensions
{
    public static MapboxMapsObjC.TMBCirclePitchScale ToPlatform(this CirclePitchScale value)
    {
        return value.Value switch 
        {
            "map" => MapboxMapsObjC.TMBCirclePitchScale.Map,
            "viewport" => MapboxMapsObjC.TMBCirclePitchScale.Viewport
        };
    }

    public static CirclePitchScale ToPlatform(this MapboxMapsObjC.TMBCirclePitchScale value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBCirclePitchScale.Map => "map",
            MapboxMapsObjC.TMBCirclePitchScale.Viewport => "viewport"
        };
    }

    public static CirclePitchScale CirclePitchScaleX(this Foundation.NSNumber value)
    {
        return value.CirclePitchScale().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this CirclePitchScale value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class CirclePitchScaleExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.CirclePitchScale ToPlatform(this CirclePitchScale value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.CirclePitchScale.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: CIRCLE_TRANSLATE_ANCHOR

/// Controls the frame of reference for `circle-translate`.
public readonly struct CircleTranslateAnchor : INamedString
{

    /// The circle is translated relative to the map.
    public static readonly CircleTranslateAnchor Map = new ("map");

    /// The circle is translated relative to the viewport.
    public static readonly CircleTranslateAnchor Viewport = new ("viewport");


    public string Value { get; }

    private CircleTranslateAnchor(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(CircleTranslateAnchor value) => value.Value;
    public static implicit operator CircleTranslateAnchor(string value) => new (value);
}
public static partial class CircleTranslateAnchorExtensions {}
#if IOS    
partial class CircleTranslateAnchorExtensions
{
    public static MapboxMapsObjC.TMBCircleTranslateAnchor ToPlatform(this CircleTranslateAnchor value)
    {
        return value.Value switch 
        {
            "map" => MapboxMapsObjC.TMBCircleTranslateAnchor.Map,
            "viewport" => MapboxMapsObjC.TMBCircleTranslateAnchor.Viewport
        };
    }

    public static CircleTranslateAnchor ToPlatform(this MapboxMapsObjC.TMBCircleTranslateAnchor value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBCircleTranslateAnchor.Map => "map",
            MapboxMapsObjC.TMBCircleTranslateAnchor.Viewport => "viewport"
        };
    }

    public static CircleTranslateAnchor CircleTranslateAnchorX(this Foundation.NSNumber value)
    {
        return value.CircleTranslateAnchor().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this CircleTranslateAnchor value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class CircleTranslateAnchorExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.CircleTranslateAnchor ToPlatform(this CircleTranslateAnchor value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.CircleTranslateAnchor.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: FILL_EXTRUSION_TRANSLATE_ANCHOR

/// Controls the frame of reference for `fill-extrusion-translate`.
public readonly struct FillExtrusionTranslateAnchor : INamedString
{

    /// The fill extrusion is translated relative to the map.
    public static readonly FillExtrusionTranslateAnchor Map = new ("map");

    /// The fill extrusion is translated relative to the viewport.
    public static readonly FillExtrusionTranslateAnchor Viewport = new ("viewport");


    public string Value { get; }

    private FillExtrusionTranslateAnchor(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(FillExtrusionTranslateAnchor value) => value.Value;
    public static implicit operator FillExtrusionTranslateAnchor(string value) => new (value);
}
public static partial class FillExtrusionTranslateAnchorExtensions {}
#if IOS    
partial class FillExtrusionTranslateAnchorExtensions
{
    public static MapboxMapsObjC.TMBFillExtrusionTranslateAnchor ToPlatform(this FillExtrusionTranslateAnchor value)
    {
        return value.Value switch 
        {
            "map" => MapboxMapsObjC.TMBFillExtrusionTranslateAnchor.Map,
            "viewport" => MapboxMapsObjC.TMBFillExtrusionTranslateAnchor.Viewport
        };
    }

    public static FillExtrusionTranslateAnchor ToPlatform(this MapboxMapsObjC.TMBFillExtrusionTranslateAnchor value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBFillExtrusionTranslateAnchor.Map => "map",
            MapboxMapsObjC.TMBFillExtrusionTranslateAnchor.Viewport => "viewport"
        };
    }

    public static FillExtrusionTranslateAnchor FillExtrusionTranslateAnchorX(this Foundation.NSNumber value)
    {
        return value.FillExtrusionTranslateAnchor().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this FillExtrusionTranslateAnchor value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class FillExtrusionTranslateAnchorExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.FillExtrusionTranslateAnchor ToPlatform(this FillExtrusionTranslateAnchor value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.FillExtrusionTranslateAnchor.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: RASTER_RESAMPLING

/// The resampling/interpolation method to use for overscaling, also known as texture magnification filter
public readonly struct RasterResampling : INamedString
{

    /// (Bi)linear filtering interpolates pixel values using the weighted average of the four closest original source pixels creating a smooth but blurry look when overscaled
    public static readonly RasterResampling Linear = new ("linear");

    /// Nearest neighbor filtering interpolates pixel values using the nearest original source pixel creating a sharp but pixelated look when overscaled
    public static readonly RasterResampling Nearest = new ("nearest");


    public string Value { get; }

    private RasterResampling(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(RasterResampling value) => value.Value;
    public static implicit operator RasterResampling(string value) => new (value);
}
public static partial class RasterResamplingExtensions {}
#if IOS    
partial class RasterResamplingExtensions
{
    public static MapboxMapsObjC.TMBRasterResampling ToPlatform(this RasterResampling value)
    {
        return value.Value switch 
        {
            "linear" => MapboxMapsObjC.TMBRasterResampling.Linear,
            "nearest" => MapboxMapsObjC.TMBRasterResampling.Nearest
        };
    }

    public static RasterResampling ToPlatform(this MapboxMapsObjC.TMBRasterResampling value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBRasterResampling.Linear => "linear",
            MapboxMapsObjC.TMBRasterResampling.Nearest => "nearest"
        };
    }

    public static RasterResampling RasterResamplingX(this Foundation.NSNumber value)
    {
        return value.RasterResampling().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this RasterResampling value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class RasterResamplingExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.RasterResampling ToPlatform(this RasterResampling value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.RasterResampling.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: HILLSHADE_ILLUMINATION_ANCHOR

/// Direction of light source when map is rotated.
public readonly struct HillshadeIlluminationAnchor : INamedString
{

    /// The hillshade illumination is relative to the north direction.
    public static readonly HillshadeIlluminationAnchor Map = new ("map");

    /// The hillshade illumination is relative to the top of the viewport.
    public static readonly HillshadeIlluminationAnchor Viewport = new ("viewport");


    public string Value { get; }

    private HillshadeIlluminationAnchor(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(HillshadeIlluminationAnchor value) => value.Value;
    public static implicit operator HillshadeIlluminationAnchor(string value) => new (value);
}
public static partial class HillshadeIlluminationAnchorExtensions {}
#if IOS    
partial class HillshadeIlluminationAnchorExtensions
{
    public static MapboxMapsObjC.TMBHillshadeIlluminationAnchor ToPlatform(this HillshadeIlluminationAnchor value)
    {
        return value.Value switch 
        {
            "map" => MapboxMapsObjC.TMBHillshadeIlluminationAnchor.Map,
            "viewport" => MapboxMapsObjC.TMBHillshadeIlluminationAnchor.Viewport
        };
    }

    public static HillshadeIlluminationAnchor ToPlatform(this MapboxMapsObjC.TMBHillshadeIlluminationAnchor value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBHillshadeIlluminationAnchor.Map => "map",
            MapboxMapsObjC.TMBHillshadeIlluminationAnchor.Viewport => "viewport"
        };
    }

    public static HillshadeIlluminationAnchor HillshadeIlluminationAnchorX(this Foundation.NSNumber value)
    {
        return value.HillshadeIlluminationAnchor().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this HillshadeIlluminationAnchor value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class HillshadeIlluminationAnchorExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.HillshadeIlluminationAnchor ToPlatform(this HillshadeIlluminationAnchor value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.HillshadeIlluminationAnchor.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: SKY_TYPE

/// The type of the sky
public readonly struct SkyType : INamedString
{

    /// Renders the sky with a gradient that can be configured with {@link SKY_GRADIENT_RADIUS} and {@link SKY_GRADIENT}.
    public static readonly SkyType Gradient = new ("gradient");

    /// Renders the sky with a simulated atmospheric scattering algorithm, the sun direction can be attached to the light position or explicitly set through {@link SKY_ATMOSPHERE_SUN}.
    public static readonly SkyType Atmosphere = new ("atmosphere");


    public string Value { get; }

    private SkyType(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(SkyType value) => value.Value;
    public static implicit operator SkyType(string value) => new (value);
}
public static partial class SkyTypeExtensions {}
#if IOS    
partial class SkyTypeExtensions
{
    public static MapboxMapsObjC.TMBSkyType ToPlatform(this SkyType value)
    {
        return value.Value switch 
        {
            "gradient" => MapboxMapsObjC.TMBSkyType.Gradient,
            "atmosphere" => MapboxMapsObjC.TMBSkyType.Atmosphere
        };
    }

    public static SkyType ToPlatform(this MapboxMapsObjC.TMBSkyType value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBSkyType.Gradient => "gradient",
            MapboxMapsObjC.TMBSkyType.Atmosphere => "atmosphere"
        };
    }

    public static SkyType SkyTypeX(this Foundation.NSNumber value)
    {
        return value.SkyType().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this SkyType value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class SkyTypeExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.SkyType ToPlatform(this SkyType value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.SkyType.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: ANCHOR

/// Whether extruded geometries are lit relative to the map or viewport.
public readonly struct Anchor : INamedString
{

    /// The position of the light source is aligned to the rotation of the map.
    public static readonly Anchor Map = new ("map");

    /// The position of the light source is aligned to the rotation of the viewport.
    public static readonly Anchor Viewport = new ("viewport");


    public string Value { get; }

    private Anchor(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(Anchor value) => value.Value;
    public static implicit operator Anchor(string value) => new (value);
}
public static partial class AnchorExtensions {}
#if IOS    
partial class AnchorExtensions
{
    public static MapboxMapsObjC.TMBAnchor ToPlatform(this Anchor value)
    {
        return value.Value switch 
        {
            "map" => MapboxMapsObjC.TMBAnchor.Map,
            "viewport" => MapboxMapsObjC.TMBAnchor.Viewport
        };
    }

    public static Anchor ToPlatform(this MapboxMapsObjC.TMBAnchor value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBAnchor.Map => "map",
            MapboxMapsObjC.TMBAnchor.Viewport => "viewport"
        };
    }

    public static Anchor AnchorX(this Foundation.NSNumber value)
    {
        return value.Anchor().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this Anchor value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class AnchorExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.Anchor ToPlatform(this Anchor value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.Anchor.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: NAME

/// The name of the projection to be used for rendering the map.
public readonly struct StyleProjectionName : INamedString
{

    /// The Mercator projection is the default projection.
    public static readonly StyleProjectionName Mercator = new ("mercator");

    /// A globe projection.
    public static readonly StyleProjectionName Globe = new ("globe");


    public string Value { get; }

    private StyleProjectionName(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(StyleProjectionName value) => value.Value;
    public static implicit operator StyleProjectionName(string value) => new (value);
}
public static partial class StyleProjectionNameExtensions {}
#if IOS    
partial class StyleProjectionNameExtensions
{
    public static MapboxMapsObjC.TMBStyleProjectionName ToPlatform(this StyleProjectionName value)
    {
        return value.Value switch 
        {
            "mercator" => MapboxMapsObjC.TMBStyleProjectionName.Mercator,
            "globe" => MapboxMapsObjC.TMBStyleProjectionName.Globe
        };
    }

    public static StyleProjectionName ToPlatform(this MapboxMapsObjC.TMBStyleProjectionName value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBStyleProjectionName.Mercator => "mercator",
            MapboxMapsObjC.TMBStyleProjectionName.Globe => "globe"
        };
    }

    public static StyleProjectionName StyleProjectionNameX(this Foundation.NSNumber value)
    {
        return value.StyleProjectionName().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this StyleProjectionName value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class StyleProjectionNameExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.ProjectionName ToPlatform(this StyleProjectionName value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.ProjectionName.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// MARK: TEXT_WRITING_MODE

/// The property allows control over a symbol's orientation. Note that the property values act as a hint, so that a symbol whose language doesn’t support the provided orientation will be laid out in its natural orientation. Example: English point symbol will be rendered horizontally even if array value contains single 'vertical' enum value. For symbol with point placement, the order of elements in an array define priority order for the placement of an orientation variant. For symbol with line placement, the default text writing mode is either ['horizontal', 'vertical'] or ['vertical', 'horizontal'], the order doesn't affect the placement.
public readonly struct TextWritingMode : INamedString
{

    /// If a text's language supports horizontal writing mode, symbols would be laid out horizontally.
    public static readonly TextWritingMode Horizontal = new ("horizontal");

    /// If a text's language supports vertical writing mode, symbols would be laid out vertically.
    public static readonly TextWritingMode Vertical = new ("vertical");


    public string Value { get; }

    private TextWritingMode(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(TextWritingMode value) => value.Value;
    public static implicit operator TextWritingMode(string value) => new (value);
}
public static partial class TextWritingModeExtensions {}
#if IOS    
partial class TextWritingModeExtensions
{
    public static MapboxMapsObjC.TMBTextWritingMode ToPlatform(this TextWritingMode value)
    {
        return value.Value switch 
        {
            "horizontal" => MapboxMapsObjC.TMBTextWritingMode.Horizontal,
            "vertical" => MapboxMapsObjC.TMBTextWritingMode.Vertical
        };
    }

    public static TextWritingMode ToPlatform(this MapboxMapsObjC.TMBTextWritingMode value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBTextWritingMode.Horizontal => "horizontal",
            MapboxMapsObjC.TMBTextWritingMode.Vertical => "vertical"
        };
    }

    public static TextWritingMode TextWritingModeX(this Foundation.NSNumber value)
    {
        return value.TextWritingMode().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this TextWritingMode value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif
#if ANDROID    
partial class TextWritingModeExtensions
{
    public static Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.TextWritingMode ToPlatform(this TextWritingMode value)
    {
        return Com.Mapbox.Maps.Extension.Style.Layers.Properties.Generated.TextWritingMode.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif

// End of generated file.
