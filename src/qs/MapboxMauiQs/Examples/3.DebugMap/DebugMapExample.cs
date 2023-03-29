using System;
using Mapbox.Maui;
using iOSPage = Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific.Page;
namespace MapboxMauiQs;

public class DebugMapExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;

    public DebugMapExample()
	{
        iOSPage.SetUseSafeArea(this, false);
		Content = map = new MapboxView();

        map.MapReady += Map_MapReady;
	}

    private void Map_MapReady(object sender, EventArgs e)
    {
        // Setup Map here
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }
}