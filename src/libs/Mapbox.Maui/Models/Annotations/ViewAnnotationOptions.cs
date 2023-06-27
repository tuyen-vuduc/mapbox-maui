namespace MapboxMaui.Annotations;

public record ViewAnnotationOptions
{
    /// Geometry the view annotation is bound to. Currently only support 'point' geometry type.
    /// Note: geometry must be set when adding a new view annotation, otherwise an operation error will be returned from the call that is associated to this option.
    public GeoJSON.Text.Geometry.IGeometryObject Geometry { get; set; }

    /// View annotation width in pixels.
    public float? Width { get; set; }

    /// View annotation height in pixels.
    public float? Height { get; set; }

    /// Optional style symbol id connected to given view annotation.
    ///
    /// View annotation's visibility behaviour becomes tied to feature visibility where feature could represent an icon or a text label.
    /// E.g. if the bounded symbol is not visible view annotation also becomes not visible.
    ///
    /// Note: Invalid associatedFeatureId (meaning no actual symbol has such feature id) will lead to the cooresponding annotation to be invisible.
    public string AssociatedFeatureId { get; set; }

    /// If true, the annotation will be visible even if it collides with other previously drawn annotations.
    /// If allowOverlap is null, default value `false` will be applied.
    /// Note: When the value is true, the ordering of the views are determined by the order of their addition.
    public bool? AllowOverlap { get; set; }

    /// Specifies if this view annotation is visible or not.
    ///
    /// Note: If this property is not specified explicitly when creating / updating view annotation, visibility will be
    /// handled automatically based on the `ViewAnnotation` view's visibility e.g. if actual view is set to be not visible the SDK
    /// will automatically update view annotation to have `visible = false`.
    ///
    /// If visible is null, default value `true` will be applied.
    public bool? Visible { get; set; }

    /// Anchor describing where the view annotation will be located relatively to given geometry.
    /// If anchor is null, default value `CENTER` will be applied.
    public ViewAnnotationAnchor? Anchor { get; set; }

    /// Extra X offset in `platform pixels`.
    /// Providing positive value moves view annotation to the right while negative moves it to the left.
    public float? OffsetX { get; set; }

    /// Extra Y offset in `platform pixels`.
    /// Providing positive value moves view annotation to the top while negative moves it to the bottom.
    public float? OffsetY { get; set; }

    /// Specifies if this view annotation is selected meaning it should be placed on top of others.
    /// If selected in null, default value `false` will be applied.
    public bool? Selected { get; set; }

    public string Title { get; set; }

    public string Id { get; set; }
}