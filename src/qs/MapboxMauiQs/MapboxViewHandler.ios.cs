using System;
using Microsoft.Maui.Handlers;

namespace MapboxMauiQs;
using PlatformView = MapboxMaps.MapView;

public partial class MapboxViewHandler
{
    private static void HandleCenterChanged(MapboxViewHandler handler, IMapboxView view)
    {
        //throw new NotImplementedException();
    }

    private static void HandleMapboxStyleChanged(MapboxViewHandler handler, IMapboxView view)
    {
        //handler.PlatformView;
    }

    protected override PlatformView CreatePlatformView()
    {
        return new PlatformView();
    }
}

