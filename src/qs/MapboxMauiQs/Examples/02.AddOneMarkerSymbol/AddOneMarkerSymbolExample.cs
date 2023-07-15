namespace MapboxMauiQs;

public class AddOneMarkerSymbolExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;

    public AddOneMarkerSymbolExample()
	{
        iOSPage.SetUseSafeArea(this, false);
		Content = map = new MapboxView();

        map.MapReady += Map_MapReady;
        map.StyleLoaded += Map_StyleLoaded;
    }

    private void Map_StyleLoaded(object sender, EventArgs e)
    {
        const string imageId = @"BLUE_ICON_ID";
        const string imageName = @"blue_marker_view";
        const string sourceId = @"SOURCE_ID";
        var image = new ResolvedImage(imageId, imageName);

        map.Images = new[] { image };

        var source = new GeoJSONSource(sourceId)
        {
            Data = new GeoJSON.Text.Geometry.Point(
                new Position(55.665957, 12.550343))
        };

        map.Sources = new[] { source };

        var layer = new SymbolLayer(@"LAYER_ID")
        {
            Source = sourceId,
            IconImage = new PropertyValue<ResolvedImage>(image)
        };

        map.Layers = new[] { layer };
    }

    private void Map_MapReady(object sender, EventArgs e)
    {
        // Do any additional setup after loading the view.
        var center = new Point(55.665957, 12.550343);
        var cameraOptions = new CameraOptions {
            Center = center,
            Zoom = 8,
        };

        map.CameraOptions = cameraOptions;

        map.MapboxStyle = MapboxStyle.MAPBOX_STREETS;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }
}