namespace Mapbox.Maui;

public interface IMapboxView : IView
{
    public string AccessToken { get; set; }
    public MapboxStyle MapboxStyle { get; set; }

    public Microsoft.Maui.Graphics.Point? MapCenter { get; set; }
    public float? MapZoom { get; set; }
}
