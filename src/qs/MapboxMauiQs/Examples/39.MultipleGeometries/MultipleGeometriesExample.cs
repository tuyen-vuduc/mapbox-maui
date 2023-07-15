namespace MapboxMauiQs;

public class MultipleGeometriesExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;

    class Constants
    {
        public const string geoJSONDataSourceIdentifier = "geoJSON-data-source";
    }

    public MultipleGeometriesExample()
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
        var centerLocation = new Point(38.93490939383946, -77.03619251024163);
        var cameraOptions = new CameraOptions
        {
            Center = centerLocation,
            Zoom = 11,
        };

        map.CameraOptions = cameraOptions;
    }

    private async void Map_MapLoaded(object sender, EventArgs e)
    {
        var geojsonSource = await AddGeoJSONSource();


        MainThread.BeginInvokeOnMainThread(() =>
        {
            map.Sources = new[] { geojsonSource };

            map.Layers = new MapboxLayer[]
            {
                AddPolygonLayer(),
                AddLineStringLayer(),
                AddPointLayer(),
            };
        });
    }

    private static CircleLayer AddPointLayer()
    {
        // Create a circle layer associated with the GeoJSON data source,
        // filter it so that only the point data is shown,
        // and apply basic styling to it.
        var circleLayer = new CircleLayer(id: "circle-layer")
        {
            Filter = DslExpression.Eq(
                "$type",
                "Point"
            ),
            Source = Constants.geoJSONDataSourceIdentifier,
            CircleColor = Colors.Red,
            CircleRadius = 6.0,
            CircleStrokeWidth = 2.0,
            CircleStrokeColor = Colors.Black
        };

        return circleLayer;
    }

    private static LineLayer AddLineStringLayer()
    {
        // Create and style a LineLayer that uses the Line String Feature's coordinates in the GeoJSON data
        var lineLayer = new LineLayer(id: "line-layer")
        {
            Filter = DslExpression.Eq(
                "$type",
                "LineString"
            ),
            Source = Constants.geoJSONDataSourceIdentifier,
            LineColor = Colors.Red,
            LineWidth = 2
        };

        return lineLayer;
    }

    private static FillLayer AddPolygonLayer()
    {
        var polygonLayer = new FillLayer(id: "fill-layer")
        {
            Filter = DslExpression.Eq(
                "$type",
                "Polygon"
            ),
            Source = Constants.geoJSONDataSourceIdentifier,
            FillColor = Color.FromRgb(68, 105, 247),
            FillOpacity = 0.3
        };

        return polygonLayer;
    }

    private static async Task<GeoJSONSource> AddGeoJSONSource()
    {
        var geojson = await LoadGeojson();

        // Create a GeoJSON data source.
        var geoJSONSource = new GeoJSONSource(Constants.geoJSONDataSourceIdentifier)
        {
            Data = new RawGeoJSONObject(geojson)
        };

        return geoJSONSource;
    }

    async static Task<string> LoadGeojson()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("GeoJSONSourceExample.geojson");
        using var reader = new StreamReader(stream);

        return reader.ReadToEnd();
    }
}