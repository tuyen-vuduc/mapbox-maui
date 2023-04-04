using System;
using Mapbox.Maui;
using iOSPage = Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific.Page;
namespace MapboxMauiQs;

public class TerrainExampleExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;

    public TerrainExampleExample()
    {
        iOSPage.SetUseSafeArea(this, false);
        Content = map = new MapboxView();

        map.MapReady += Map_MapReady;
    }

    private void Map_MapReady(object sender, EventArgs e)
    {
        // Setup Map here
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