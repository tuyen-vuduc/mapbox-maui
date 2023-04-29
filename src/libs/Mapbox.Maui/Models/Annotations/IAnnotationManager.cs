namespace MapboxMaui.Annotations;

public interface IAnnotationManager<TAnnotation> where TAnnotation : IAnnotation
{
    event EventHandler<AnnotationsSelectedEventArgs> AnnotationsSelected;

    string Id { get; }

    /// The id of the `GeoJSONSource` that this manager is responsible for.
    string SourceId { get; }

    /// The id of the layer that this manager is responsible for.
    string LayerId { get; }

    void AddAnnotations(params TAnnotation[] annotations);

    void RemoveAnnotations(params string[] annotationIDs);

    void RemoveAllAnnotations();
}