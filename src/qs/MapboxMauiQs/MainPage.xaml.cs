namespace MapboxMauiQs;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        map.MapCenter = new Point(21.028511, 105.804817);
        map.MapZoom = 15;
    }
}


