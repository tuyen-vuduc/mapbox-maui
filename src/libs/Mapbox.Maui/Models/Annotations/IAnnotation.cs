namespace MapboxMaui.Annotations;

using GeoJSON.Text.Geometry;

public interface IAnnotation
{
    /// The unique identifier of the annotation.
    public string Id { get; set; }

    /// The geometry that is backing this annotation.
    public IGeometryObject Geometry { get; }

    /// Properties associated with the annotation.
    public IReadOnlyDictionary<string, object> UserInfo { get; set; }
}

public abstract class Annotation<T>
    : BaseKVContainer
    , IAnnotation where T : IGeometryObject
{
    public string Id { get; set; }

    public IGeometryObject Geometry { get; }

    public T GeometryValue => (T)Geometry;

    public IReadOnlyDictionary<string, object> UserInfo { get; set; }

    /// Toggles the annotation's selection state.
    /// If the annotation is deselected, it becomes selected.
    /// If the annotation is selected, it becomes deselected.
    public bool IsSelected { get; set; }

    /// Property to determine whether annotation can be manually moved around map
    public bool IsDraggable { get; set; }

    protected Annotation(T geometry, string id = null)
    {
        Id = id ?? Guid.NewGuid().ToString();
        Geometry = geometry;
    }
}
