namespace MapboxMaui.Annotations;

public class AnnotationsSelectedEventArgs : EventArgs
{
    public AnnotationsSelectedEventArgs(IEnumerable<string> selectedAnnotationIDs)
    {
        SelectedAnnotationIDs = selectedAnnotationIDs.ToArray();
    }

    public string[] SelectedAnnotationIDs { get; init; }
}
