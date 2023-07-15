namespace MapboxMauiQs;

public class TerrainExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;

    public TerrainExample()
    {
        iOSPage.SetUseSafeArea(this, false);
        Content = map = new MapboxView();

        map.MapReady += Map_MapReady;
        map.StyleLoaded += Map_StyleLoaded;
    }

    private void Map_StyleLoaded(object sender, EventArgs e)
    {
        var sourceId = @"mapbox-dem";
        var rasterDemSource = new RasterDemSource(sourceId)
        {
            Url = @"mapbox://mapbox.mapbox-terrain-dem-v1",
            TileSize = 514.0,
            MaxZoom = 14.0,
        };
        map.Sources = new List<MapboxSource> {
            rasterDemSource,
        };

        var terrain = new Terrain(sourceId)
        {
            Exaggeration = new PropertyValue<double>(1.5)
        };
        map.Terrain = terrain;

        var skyLayer = new SkyLayer("sky-layer")
        {
            SkyType = new PropertyValue<SkyType>(SkyType.Atmosphere),
            SkyAtmosphereSun = new PropertyValue<double[]>(new[] { 0.0, 0.0 }),
            SkyAtmosphereSunIntensity = new PropertyValue<double>(15.0),
        };
        map.Layers = new List<MapboxLayer>
        {
            skyLayer,
        };
    }

    private void Map_MapReady(object sender, EventArgs e)
    {
        var mapCenter = new Point(32.6141, -114.34411);
        var cameraOptions = new CameraOptions
        {
            Center = mapCenter,
            Zoom = 13.1f,
            Bearing = 80,
            Pitch = 85,
        };

        map.CameraOptions = cameraOptions;
        map.MapboxStyle = (MapboxStyle)@"mapbox://styles/mapbox-map-design/ckhqrf2tz0dt119ny6azh975y";
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }
}