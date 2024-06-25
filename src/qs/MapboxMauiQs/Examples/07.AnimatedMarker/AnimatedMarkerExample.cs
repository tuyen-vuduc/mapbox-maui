namespace MapboxMauiQs;

public class AnimatedMarkerExample : ContentPage, IExamplePage, IQueryAttributable
{
    static class Constants
    {
        public const string markerIconId = "marker_icon";
        public const string sourceId = "source-id";
        public const double animationDuration = 2;
    }

    MapboxView map;
    IExampleInfo info;

    private IPosition currentPosition = new MapPosition(64.900932, -18.167040);

    public AnimatedMarkerExample()
	{
        iOSPage.SetUseSafeArea(this, false);
		Content = map = new MapboxView();

        map.MapReady += Map_MapReady;
        map.MapLoaded += Map_MapLoaded;
        map.Command = new Command<MapTappedPosition>(HandleMapTapped);
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }

    private void HandleMapTapped(MapTappedPosition point)
    {
        // Create a GeoJSON data source.
        var feature = new Feature(
            new GeoJSON.Text.Geometry.Point(point.MapPosition)
        );
        var source = new GeoJSONSource(Constants.sourceId)
        {
            Data = new RawGeoJSONObject(
                JsonSerializer.Serialize(feature)
            )
        };

        map.Sources = new[] { source };
    }

    private void Map_MapReady(object sender, EventArgs e)
    {
        var cameraOptions = new CameraOptions
        {
            Center = currentPosition,
            Zoom = 5,
        };

        map.CameraOptions = cameraOptions;
        map.MapboxStyle = MapboxStyle.SATELLITE_STREETS;
    }

    private void Map_MapLoaded(object sender, EventArgs e)
    {
        var image = new ResolvedImage(Constants.markerIconId, "red_marker");
        map.Images = new[] { image };

        // Create a GeoJSON data source.
        var feature = new Feature(
            new GeoJSON.Text.Geometry.Point(currentPosition)
        );
        var source = new GeoJSONSource(Constants.sourceId)
        {
            Data = new RawGeoJSONObject(
                JsonSerializer.Serialize(feature)
            )
        };

        map.Sources = new[] { source };

        // Create a symbol layer
        var symbolLayer = new SymbolLayer(id: "layer-id");
        symbolLayer.Source = Constants.sourceId;
        symbolLayer.IconImage = image;
        symbolLayer.IconIgnorePlacement = true;
        symbolLayer.IconAllowOverlap = true;

        map.Layers = new[] { symbolLayer };
    }
}