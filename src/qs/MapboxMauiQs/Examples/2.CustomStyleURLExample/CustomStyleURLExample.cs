using System;
using Mapbox.Maui;
namespace MapboxMauiQs;

public class CustomStyleURLExample : ContentPage, IExamplePage
{
    MapboxView map;

    public CustomStyleURLExample()
	{
		Content = map = new MapboxView();

        map.MapReady += Map_MapReady;
	}

    private void Map_MapReady(object sender, EventArgs e)
    {
        map.MapboxStyle = (MapboxStyle)"mapbox://styles/examples/cke97f49z5rlg19l310b7uu7j";
    }
}