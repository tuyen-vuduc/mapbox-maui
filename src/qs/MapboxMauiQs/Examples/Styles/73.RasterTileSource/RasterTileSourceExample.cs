namespace MapboxMauiQs;

public class RasterTileSourceExample : ContentPage, IExamplePage, IQueryAttributable
{
    private const string sourceId = "raster-source";

    readonly MapboxView map;
    IExampleInfo info;
    bool isTileRequestDelayEnabled;
    readonly Button toggleTitleRequestButton;

    public RasterTileSourceExample()
    {
        iOSPage.SetUseSafeArea(this, false);
        Content = new Grid
        {
            Children =
            {
                (map = new MapboxView()),
                (toggleTitleRequestButton = new Button
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.End,
                    Text = "Enable tile request delay",
                    Command = new Command(ToggleTileRequestDelay)
                }),
            },
        };

        map.MapReady += Map_MapReady;
        map.MapLoaded += Map_MapLoaded;
    }

    private void ToggleTileRequestDelay(object obj)
    {
        isTileRequestDelayEnabled = !isTileRequestDelayEnabled;

        map.MapboxController.SetSourcePropertyFor(
            sourceId,
            "tile-requests-delay",
            isTileRequestDelayEnabled ? 5000 : 0,
            (error) =>
            {
                if (error is not null)
                {
                    System.Diagnostics.Debug.WriteLine($"ERR {nameof(ToggleTileRequestDelay)}: ${error}");
                }
            });

        toggleTitleRequestButton.Text = isTileRequestDelayEnabled
            ? @"Disable tile request delay"
            : @"Enable tile request delay";
    }



    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }

    private void Map_MapReady(object sender, EventArgs e)
    {
        var centerLocation = new MapPosition(40, -74.5);
        var cameraOptions = new CameraOptions
        {
            Center = centerLocation,
            Zoom = 2,
        };

        map.CameraOptions = cameraOptions;
        map.MapboxStyle = MapboxStyle.SATELLITE;
    }

    private void Map_MapLoaded(object sender, EventArgs e)
    {
        // Setup Styles, Annotations, etc here
        // This URL points to raster tiles from OpenStreetMap
        string sourceUrl = "https://tile.openstreetmap.org/{z}/{x}/{y}.png";

        // Create a `RasterSource` and set the source's `tiles` to the Stamen watercolor raster tiles.
        var rasterSource = new RasterSource(id: sourceId)
        {
            Tiles = [sourceUrl],

            // Specify the tile size for the `RasterSource`.
            TileSize = 256,
        };

        // Specify that the layer should use the source with the ID `raster-source`. This ID will be
        // assigned to the `RasterSource` when it is added to the style.
        var rasterLayer = new RasterLayer(id: "raster-layer", sourceId);

        map.Sources = [rasterSource];
        map.Layers = [rasterLayer];
    }
}