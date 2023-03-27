namespace MapboxMauiQs;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        map.MapCenter = new Point(21.028511, 105.804817);
        map.MapZoom = 15;
        map.MapboxStyle = new Mapbox.Maui.MapboxStyle("mapbox://styles/examples/cke97f49z5rlg19l310b7uu7j");
    }
}


