using MapboxMaui.Gestures;
using MapboxMaui.Viewport;

namespace MapboxMauiQs;

public class AdvancedViewportGesturesExample : ContentPage, IExamplePage, IQueryAttributable
{
    private const string NAVIGATION_ROUTE_JSON_NAME = "navigation_route.json";
    private const string GEOJSON_SOURCE_ID = "source_id";
    private const string ROUTE_LINE_LAYER_ID = "route_line_layer_id";
    private static readonly Color MAPBOX_BLUE = Color.FromRgb(0x1E, 0x8C, 0xAB);

    MapboxView map;
    IExampleInfo info;
    LineString routePoints;

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
        //var centerLocation = new MapPosition(37.3230, -122.0322); // Cupertino
        //var cameraOptions = new CameraOptions
        //{
        //    Center = centerLocation,
        //    Zoom = 14,
        //};

        //map.CameraOptions = cameraOptions;
        followPuckViewportState = map.Viewport.MakeFollowPuckViewportState(new FollowPuckViewportStateOptions
        {
            Bearing = 0,
            Padding = new Thickness(200, 0, 0, 0),
        });

        routePoints = await LoadGeojson();
        overviewViewportState = map.Viewport.MakeOverviewViewportState(new OverviewViewportStateOptions
        {
            Geometry = routePoints,
            Padding = 100,
        });

        var geojsonSource = new GeoJSONSource(GEOJSON_SOURCE_ID)
        {
            Data = routePoints
        };
        var lineLayer = new LineLayer(ROUTE_LINE_LAYER_ID)
        {
            Source = GEOJSON_SOURCE_ID,
            LineColor = MAPBOX_BLUE,
            LineWidth = 10.0,
            LineCap = MapboxMaui.LineCap.Round,
            LineJoin = MapboxMaui.LineJoin.Round,
        };
        map.Sources = [geojsonSource];
        map.Layers = [lineLayer];

        map.StyleLoaded += Map_StyleLoaded;
        map.MapboxStyle = MapboxStyle.TRAFFIC_DAY;

    }

    private void Map_MapTapped(object sender, MapTappedEventArgs e)
    {
        var currentOrNextState = map.Viewport.GetCurrentOrNextState();
        map.Viewport.TransitionTo(currentOrNextState == followPuckViewportState
            ? overviewViewportState
            : followPuckViewportState);
    }

    private void Map_StyleLoaded(object sender, EventArgs e)
    {
        map.ViewportStatusChanged += Map_ViewportStatusChanged;
        map.MapTapped += Map_MapTapped;
        map.Viewport.TransitionTo(overviewViewportState);
    }

    private void Map_ViewportStatusChanged(object sender, ViewportStatusChangedEventArgs e)
    {
        if (e.FromStatus.State == followPuckViewportState)
        {
            ClearAdvancedGesturesForFollowPuckViewportState();
        }
        if (e.ToStatus.State == followPuckViewportState)
        {
            SetupAdvancedGesturesForFollowPuckViewportState();
        }
    }

    private void SetupAdvancedGesturesForFollowPuckViewportState()
    {
        map.Viewport.Options = new ViewportOptions
        {
            TransitionsToIdleUponUserInteraction = false,
        };
        map.IndicatorPositionChanged -= HandleIndicatorPositionChanged;
        map.GestureSettings = map.GestureSettings with
        {
            ScrollEnabled = false,
        };
        //map.GestureScaled += HandleGestureScaled;
        map.RotatingBegan += HandleRotatingBegan;
        map.RotatingEnded += HandleRotatingEnded;
        //map.GestureShoved += HandleGestureShoved;
    }

    private void HandleIndicatorPositionChanged(object sender, IndicatorPositionChangedEventArgs e)
    {
        var screenPosition = map.MapboxController.GetScreenPosition(e.Position);
        map.GestureSettings = map.GestureSettings with
        {
            FocalPoint = screenPosition,
        };
    }

    private void HandleRotatingBegan(object sender, RotatingBeganEventArgs e)
    {
        followPuckViewportState.Options.Bearing = null;
    }
    private void HandleRotatingEnded(object sender, RotatingEndedEventArgs e)
    {
        followPuckViewportState.Options.Bearing = map.CameraController.CameraState.Bearing;
    }

    private void ClearAdvancedGesturesForFollowPuckViewportState()
    {
        map.Viewport.Options = new ViewportOptions
        {
            TransitionsToIdleUponUserInteraction = true,
        };
        map.IndicatorPositionChanged -= HandleIndicatorPositionChanged;
        map.GestureSettings = map.GestureSettings with
        {
            FocalPoint = null,
            ScrollEnabled = true,
        };
        //map.GestureScaled -= HandleGestureScaled;
        map.RotatingBegan -= HandleRotatingBegan;
        map.RotatingEnded -= HandleRotatingEnded;
        //map.GestureShoved -= HandleGestureShoved;
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