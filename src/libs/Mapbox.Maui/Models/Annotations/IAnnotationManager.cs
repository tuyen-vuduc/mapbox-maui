namespace Mapbox.Maui.Annotations;

public interface IAnnotationManager
{
    event EventHandler<AnnotationsSelectedEventArgs> AnnotationsSelected;

    string Id { get; }

    /// The id of the `GeoJSONSource` that this manager is responsible for.
    string SourceId { get; }

    /// The id of the layer that this manager is responsible for.
    string LayerId { get; }

    void AddAnnotations<T>(params T[] annotations) where T : IAnnotation;

    void RemoveAnnotations(params string[] annotationIDs);

    void RemoveAllAnnotations();
}