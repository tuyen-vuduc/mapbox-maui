using System.Text.Json.Nodes;
using MapboxMaui.Viewport;

namespace MapboxMauiQs;

public class AdvancedViewportGesturesExample : ContentPage, IExamplePage, IQueryAttributable
{
    private const string NAVIGATION_ROUTE_JSON_NAME = "navigation_route.json";
    private const string GEOJSON_SOURCE_ID = "source_id";
    private const string ROUTE_LINE_LAYER_ID = "route_line_layer_id";

    MapboxView map;
    IExampleInfo info;

    IFollowPuckViewportState followPuckViewportState;
    IOverviewViewportState overviewViewportState;

    public AdvancedViewportGesturesExample()
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

    private async void Map_MapReady(object sender, EventArgs e)
    {
        var centerLocation = new MapPosition(37.3230, -122.0322); // Cupertino
        var cameraOptions = new CameraOptions
        {
            Center = centerLocation,
            Zoom = 14,
        };

        map.CameraOptions = cameraOptions;
        map.MapboxStyle = MapboxStyle.TRAFFIC_DAY;

        followPuckViewportState = map.Viewport.MakeFollowPuckViewportState(new FollowPuckViewportStateOptions
        {
            Bearing = 0,
            Padding = new Thickness(200, 0, 0, 0),
        });

        var geometry = await LoadGeojson();
        overviewViewportState = map.Viewport.MakeOverviewViewportState(new OverviewViewportStateOptions
        {
            Geometry = geometry,
            Padding = 100,
        });

    }

    private void Map_MapLoaded(object sender, EventArgs e)
    {
        // Setup Styles, Annotations, etc here
    }

    async static Task<LineString> LoadGeojson()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync(NAVIGATION_ROUTE_JSON_NAME);
        var jsonDocument = await JsonDocument.ParseAsync(stream);
        var geometryString = jsonDocument.RootElement
            .GetProperty("routes")[0]
            .GetProperty("geometry")
            .GetString();
        var positions = PolylineUtils.Decode(geometryString, PolylineUtils.PRECISION_6);
        return new LineString(positions);
    }
}