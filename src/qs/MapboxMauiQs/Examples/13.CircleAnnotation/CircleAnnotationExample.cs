namespace MapboxMauiQs;

public class CircleAnnotationExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;

    public CircleAnnotationExample()
	{
        iOSPage.SetUseSafeArea(this, false);
		Content = map = new MapboxView();

        map.MapReady += Map_MapReady;
        map.MapLoaded += Map_MapLoaded;
	}

    private void Map_MapLoaded(object sender, EventArgs e)
    {
        var random = new Random();
        var circleAnnotations = new List<CircleAnnotation>();
        for (int i = 0; i < 2000; i++)
        {
            var center = new MapPosition(
                random.NextInt64(0, 180) - 90,
                random.NextInt64(0, 360) - 180);
            var color = new Color(
                random.Next(0, 255),
                random.Next(0, 255),
                random.Next(0, 255));

            var circleAnnotation = new CircleAnnotation(
                new GeoJSON.Text.Geometry.Point(center)
            )
            {
                CircleColor = color,
                CircleRadius = 12,
                IsDraggable = true,
            };
            circleAnnotations.Add(circleAnnotation);
        }

        var circleAnnotationManager = map.AnnotationController.CreateCircleAnnotationManager(
            Guid.NewGuid().ToString(),
            LayerPosition.Unknown()
        );

        circleAnnotationManager.AddAnnotations(circleAnnotations.ToArray());
    }

    private void Map_MapReady(object sender, EventArgs e)
    {
        // Setup Map here
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }
}