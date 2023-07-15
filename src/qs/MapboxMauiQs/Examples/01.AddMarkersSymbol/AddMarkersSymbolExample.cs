namespace MapboxMauiQs;

public class AddMarkersSymbolExample : ContentPage, IExamplePage, IQueryAttributable
{
    private static class Constants
    {
        public const string ICON_KEY = "icon_key";
        public const string BLUE_MARKER_PROPERTY = "icon_blue_property";
        public const string RED_MARKER_PROPERTY = "icon_red_property";
        public const string BLUE_ICON_ID = "blue";
        public const string RED_ICON_ID = "red";
        public const string SOURCE_ID = "source_id";
        public const string LAYER_ID = "layer_id";
    }

    MapboxView map;
    IExampleInfo info;

    public AddMarkersSymbolExample()
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
        var centerLocation = new Point(55.70651, 12.554729);
        var cameraOptions = new CameraOptions
        {
            Center = centerLocation,
            Zoom = 8,
        };

        map.CameraOptions = cameraOptions;
        map.MapboxStyle = MapboxStyle.MAPBOX_STREETS;
    }

    private void Map_MapLoaded(object sender, EventArgs e)
    {
        map.Images = new[] {
            new ResolvedImage(Constants.BLUE_ICON_ID, "blue_marker_view"),
            new ResolvedImage(Constants.RED_ICON_ID, "red_marker"),
        };

        var features = new List<Feature>();

        var feature = new Feature(
            new GeoJSON.Text.Geometry.Point(
                new GeoJSON.Text.Geometry.Position(latitude: 55.608166, longitude: 12.65147)
            ),
            new Dictionary<string, object> {
                { Constants.ICON_KEY, Constants.BLUE_MARKER_PROPERTY }
            }
        );
        features.Add(feature);

        var feature1 = new Feature(
            new GeoJSON.Text.Geometry.Point(
                new GeoJSON.Text.Geometry.Position(latitude: 55.70651, longitude: 12.554729)
            ),
            new Dictionary<string, object> {
                { Constants.ICON_KEY, Constants.RED_MARKER_PROPERTY }
            }
        );
        features.Add(feature1);

        var geoJSONString = JsonSerializer.Serialize(new FeatureCollection(features));
        var source = new GeoJSONSource(Constants.SOURCE_ID)
        {
            Data = new RawGeoJSONObject(geoJSONString),
        };

        map.Sources = new[] { source };

        var rotateExpression = DslExpression.Match(
            DslExpression.Get(Constants.ICON_KEY),
            Constants.BLUE_MARKER_PROPERTY,
            45,
            0
        );
        var imageExpression = DslExpression.Match(
            DslExpression.Get(Constants.ICON_KEY),
            Constants.BLUE_MARKER_PROPERTY,
            Constants.BLUE_ICON_ID,
            Constants.RED_MARKER_PROPERTY,
            Constants.RED_ICON_ID,
            Constants.RED_ICON_ID
        );

        var layer = new SymbolLayer(id: Constants.LAYER_ID)
        {
            Source = Constants.SOURCE_ID,
            IconImage = (PropertyValue<ResolvedImage>)imageExpression,
            IconAnchor = IconAnchor.Bottom,
            IconAllowOverlap = false,
            IconRotate = (PropertyValue<double>)rotateExpression
        };

        map.Layers = new [] { layer };
    }
}