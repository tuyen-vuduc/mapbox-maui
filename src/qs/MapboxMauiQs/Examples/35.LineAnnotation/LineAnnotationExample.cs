namespace MapboxMauiQs;

public class LineAnnotationExample : ContentPage, IExamplePage, IQueryAttributable
{
    static Random random = new Random();

    MapboxView map;
    IExampleInfo info;

    public LineAnnotationExample()
    {
        iOSPage.SetUseSafeArea(this, false);
        Content = map = new MapboxView();

        map.MapReady += Map_MapReady;
        map.MapLoaded += Map_MapLoaded;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }

    private void Map_MapReady(object sender, EventArgs e)
    {
    }

    private void Map_MapLoaded(object sender, EventArgs e)
    {
        var annotations = new List<PolylineAnnotation>();
        var coordinates = new List<Position> {
            new Position(-2.178992, -4.375974),
            new Position(-4.107888, -7.639772),
            new Position(2.798737, -11.439207),
        };
        var lineAnnotation = new PolylineAnnotation(
            new LineString(coordinates)
        )
        {
            LineColor = Colors.Red,
            LineWidth = 5.0
        };

        annotations.Add(lineAnnotation);

        // random add lines across the globe
        var randomCoordinates = new List<Position>();
        for (var i = 0; i < 400; i++)
        {
            randomCoordinates.Add(RandomizePosition());
        }

        for (var i = 0; i < 400; i += 8)
        {
            // Create the line annotation.
            var randomAnnotation = new PolylineAnnotation(
                new LineString(randomCoordinates.Skip(i).Take(8))
            );

            // Customize the style of the line annotation
            randomAnnotation.LineColor = RandomizeColor();

            annotations.Add(randomAnnotation);
        };

        // Create the PolylineAnnotationManager responsible for managing
        // this line annotations (and others if you so choose).
        // Annotation managers are kept alive by `AnnotationOrchestrator`
        // (`mapView.annotations`) until you explicitly destroy them
        // by calling `mapView.annotations.removeAnnotationManager(withId:)`
        var polylineAnnotationManager = map.AnnotationController.CreatePolylineAnnotationManager(
            "polylineAnnotationManager",
            // position line annotations layer in a way that line annotations clipped at land borders
            LayerPosition.Below("pitch-outline")
        );

        // Sync the annotation to the manager.
        polylineAnnotationManager.AddAnnotations(annotations.ToArray());
    }

    static Position RandomizePosition()
        => new Position(
            random.Next(-90, 90),
            random.Next(-180, 180)
        );

    static Color RandomizeColor()
        => new Color(
            random.Next(0, 255),
            random.Next(0, 255),
            random.Next(0, 255),
            255
        );
}