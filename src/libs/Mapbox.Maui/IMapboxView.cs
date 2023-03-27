using System.Windows.Input;

namespace Mapbox.Maui;

public interface IMapboxView : IView
{
    CameraOptions CameraOptions { get; set; }
    MapboxStyle MapboxStyle { get; set; }

    Microsoft.Maui.Graphics.Point? MapCenter { get; set; }
    float? MapZoom { get; set; }
    OrnamentVisibility ScaleBarVisibility { get; set; }

    event EventHandler MapReady;
    ICommand MapReadyCommand { get; set; }
}
