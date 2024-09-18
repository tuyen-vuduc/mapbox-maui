using MapboxMaui.ViewAnnotations;

namespace MapboxMauiQs;

public class ViewAnnotationWithPointAnnotationExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;
    IPointAnnotationManager pointAnnotationManager;
    float markerHeight = 24;

    private class Constants
    {
        public const string blueIconId = "blue";
        public const float selectedAddCoefPX = 50;
        public static readonly string markerId = Guid.NewGuid().ToString();
    }

    public ViewAnnotationWithPointAnnotationExample()
    {
        iOSPage.SetUseSafeArea(this, false);
        Content = map = new MapboxView();

        map.AnnotationView = new SimpleViewAnnodationView();

        map.MapReady += Map_MapReady;
        map.MapLoaded += Map_MapLoaded;
        map.MapTapped += Map_MapTapped;
    }

    private void Map_MapTapped(object sender, MapTappedEventArgs e)
    {

    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }

    private void Map_MapReady(object sender, EventArgs e)
    {
        var centerLocation = new MapPosition(39.7128, -75.0060);
        var cameraOptions = new CameraOptions
        {
            Center = centerLocation,
            Zoom = 7,
        };

        map.CameraOptions = cameraOptions;
        map.MapboxStyle = MapboxStyle.MAPBOX_STREETS;

        pointAnnotationManager = map.AnnotationController.CreatePointAnnotationManager(
            nameof(pointAnnotationManager),
            LayerPosition.Unknown());
    }

    private void Map_MapLoaded(object sender, EventArgs e)
    {
        var image = new ResolvedImage(Constants.blueIconId, "blue_marker_view");

        map.Images = new[] { image };


        AddPointAndViewAnnotationAt(map.CameraOptions.Center);
    }

    private void AddPointAndViewAnnotationAt(IPosition coordinate)
    {
        if (coordinate is null) return;

        AddPointAnnotationAt(coordinate);
        AddViewAnnotationAt(coordinate);
    }

    private void AddViewAnnotationAt(IPosition value)
    {
        var options = new ViewAnnotationOptions
        {
            Geometry = new GeoJSON.Text.Geometry.Point(value),
            Width = 144,
            Height = 96,
            AssociatedFeatureId = Constants.markerId,
            AllowOverlap = false,
            Anchor = ViewAnnotationAnchor.Bottom,
            OffsetY = markerHeight,
            Title = $"Lat={value.Latitude}, Lng={value.Longitude}",
        };

        map.ViewAnnotationController.AddViewAnnotation(options);
    }

    private void AddPointAnnotationAt(IPosition value)
    {
        var pointAnnotation = new PointAnnotation(
            new GeoJSON.Text.Geometry.Point(value),
            id: Constants.markerId)
        {
            IconImage = Constants.blueIconId,
            IconAnchor = IconAnchor.Bottom,
        };

        pointAnnotationManager.AddAnnotations(pointAnnotation);
    }

    class SimpleViewAnnodationView : ContentView
    {
        public SimpleViewAnnodationView()
        {
            var grid = new Grid()
            {
                RowDefinitions =
                {
                    new() { Height = 16 },
                    new() { Height = 48 },
                    new() { Height = 32 },
                },
                BackgroundColor = Colors.Purple,
            };

            var label = new Label
            {
                TextColor = Colors.White,
                FontSize = 10,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Padding = new Thickness(24, 0),
            };

            label.SetBinding(Label.TextProperty, new Binding(nameof(ViewAnnotationOptions.Title)));

            var btnClose = new Label()
            {
                Text = "X",
                TextColor = Colors.Red,
                FontSize = 12, 
                Padding = new Thickness(2),
                Margin = 4,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.End,
            };
            var btnSelect = new Label()
            {
                Text = "Select",
                FontSize = 12,
                TextColor = Colors.White,
                BackgroundColor = Colors.BlueViolet,
                Padding = new Thickness(12, 4),
                Margin = 6,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };

            grid.Add(label, row: 1);
            grid.Add(btnClose, row: 0);
            grid.Add(btnSelect, row: 2);

            Grid.SetRowSpan(btnClose, 2);

            Content = grid;

            HeightRequest = 144;
            WidthRequest = 168;
        }
    }

}