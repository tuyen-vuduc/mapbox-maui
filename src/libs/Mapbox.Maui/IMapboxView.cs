using System.Windows.Input;
using Mapbox.Maui.Styles;

namespace Mapbox.Maui;

public partial interface IMapboxView : IView
{
    CameraOptions CameraOptions { get; set; }
    MapboxStyle MapboxStyle { get; set; }
    Microsoft.Maui.Graphics.Point? MapCenter { get; set; }
    float? MapZoom { get; set; }

    OrnamentVisibility ScaleBarVisibility { get; set; }

    DebugOption[] DebugOptions { get; set; }

    public RasterDemSource RasterDemSourceBuilder { get; set; }
}

partial interface IMapboxView { 
    event EventHandler MapReady;
    ICommand MapReadyCommand { get; set; }
}
