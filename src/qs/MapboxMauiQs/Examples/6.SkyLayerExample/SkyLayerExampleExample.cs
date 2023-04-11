using System;
using Mapbox.Maui;
using Mapbox.Maui.Styles;
using iOSPage = Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific.Page;
namespace MapboxMauiQs;

public class SkyLayerExampleExample : ContentPage, IExamplePage, IQueryAttributable
{
    static readonly Color skyBlue = new Color(0.53f, 0.81f, 0.92f, 1.00f);
    static readonly Color lightPink = new Color(1.00f, 0.82f, 0.88f, 1.00f);

    MapboxView map;
    IExampleInfo info;

    public SkyLayerExampleExample()
	{
        iOSPage.SetUseSafeArea(this, false);
		Content = map = new MapboxView();

        map.MapReady += Map_MapReady;
	}

    private void Map_MapReady(object sender, EventArgs e)
    {
        var center = new Point(35.67283, 127.60597);

        var cameraOptions = new CameraOptions {
            Center = center,
            Zoom = 12.5f,
            Pitch = 83,
        };

        map.CameraOptions = cameraOptions;
        map.MapboxStyle = (MapboxStyle)@"mapbox://styles/mapbox-map-design/ckhqrf2tz0dt119ny6azh975y";

        map.StyleLoaded += Map_StyleLoaded;
    }

    private void Map_StyleLoaded(object sender, EventArgs e)
    {
        AddSkyLayer();

        AddTerrain();
    }

    private void AddTerrain()
    {
        // Add a `RasterDEMSource`. This will be used to create and add a terrain layer.
        var demSource = new RasterDemSource("mapbox-dem");
        demSource.Url = "mapbox://mapbox.mapbox-terrain-dem-v1";
        demSource.TileSize = 514;
        demSource.MaxZoom = 14.0;

        map.Sources = new List<MapboxSource>
        {
            demSource,
        };

        var terrain = new Terrain(sourceId: "mapbox-dem");
        terrain.Exaggeration = new PropertyValue<double>(1.5);

        map.Terrain = terrain;
    }

    private void AddSkyLayer()
    {
        // Initialize a sky layer with a sky type of `gradient`, which applies a gradient effect to the sky.
        // Read more about sky layer types on the Mapbox blog: https://www.mapbox.com/blog/sky-api-atmospheric-scattering-algorithm-for-3d-maps
        var skyLayer = new SkyLayer("sky-layer");
        skyLayer.SkyType = new PropertyValue<SkyType>(SkyType.atmosphere);

        // Define the position of the sun.
        // The azimuthal angle indicates the sun's position relative to 0 degrees north. When the map's bearing
        // is `0` and the azimuthal angle is `0`, the sun will appear horizontally centered.
        double azimuthalAngle = 0;

        // Indicates the sun's position relative to the horizon. A value of `90` places the sun's center at the
        // horizon line. Lower values place the sun below the horizon line, while higher values place the sun's
        // center further above the horizon line.
        double polarAngle = 90;
        skyLayer.SkyAtmosphereSun = new PropertyValue<double[]>(new[] { azimuthalAngle, polarAngle });

        // The intensity or brightness of the sun.
        skyLayer.SkyAtmosphereSunIntensity = new PropertyValue<double>(10);

        // Set the sky's color to light blue with a light pink halo effect.
        skyLayer.SkyAtmosphereColor = new PropertyValue<Color>(skyBlue);
        skyLayer.SkyAtmosphereHaloColor = new PropertyValue<Color>(lightPink);

        map.Layers = new List<MapboxLayer>
        {
            skyLayer,
        };
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }
}