namespace MapboxMauiQs;

public class BuildingExtrusionsExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;
    Light light;

    static readonly double[] firstPosition = new[] { 1.5, 90, 80 };
    static readonly double[] secondPosition = new[] { 1.15, 210, 30 };


    public BuildingExtrusionsExample()
    {
        iOSPage.SetUseSafeArea(this, false);

        var content = new Grid
        {
            (map = new MapboxView()),
            new ImageButton()
            {
                Source = "flashlight",
                WidthRequest = 48,
                HeightRequest = 48,
                BackgroundColor = Colors.CadetBlue,
                Command = new Command(ChangeLight),
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.End,
                Margin = new Thickness(16,96),
                Padding = new Thickness(8),
            },
            new ImageButton()
            {
                Source = "paintbrush",
                WidthRequest = 48,
                HeightRequest = 48,
                BackgroundColor = Colors.CadetBlue,
                Command = new Command(ChangeColor),
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.End,
                Margin = new Thickness(16,96+48+16),
                Padding = new Thickness(8),
            }
        };

        Content = content;
        light = new Light();

        map.MapReady += Map_MapReady;
        map.StyleLoaded += Map_StyleLoaded;
    }

    private void ChangeColor(object obj)
    {
        light.Color = light.Color == Colors.Red
            ? Colors.Blue
            : Colors.Red;

        map.Light = new Light
        {
            Color = light.Color,
            Position = light.Position,
        };
    }

    private void ChangeLight(object obj)
    {
        light.Position = light.Position == firstPosition
            ? secondPosition
            : firstPosition;

        map.Light = new Light
        {
            Color = light.Color,
            Position = light.Position,
        };
    }

    private void Map_StyleLoaded(object sender, EventArgs e)
    {
        var layer = new FillExtrusionLayer("3d-buildings")
        {
            Source = "composite",
            MinZoom = 15,
            SourceLayer = "building",
            FillExtrusionColor = new PropertyValue<Color>(
                Colors.LightGray
            ),
            FillExtrusionOpacity = new PropertyValue<double>(0.6),
            FillExtrusionAmbientOcclusionIntensity = new PropertyValue<double>(0.3),
            FillExtrusionAmbientOcclusionRadius = new PropertyValue<double>(3.0),
            Filter = DslExpression.Eq(
                DslExpression.Get("extrude"),
                "true"
            ),
            FillExtrusionHeight = new PropertyValue<double>(
                DslExpression.Interpolate(
                    DslExpression.Linear(),
                    DslExpression.Zoom(),
                    15,
                    0,
                    15.05,
                    DslExpression.Get("height")
                )
            ),
            FillExtrusionBase = new PropertyValue<double>(
                DslExpression.Interpolate(
                    DslExpression.Linear(),
                    DslExpression.Zoom(),
                    15,
                    0,
                    15.05,
                    DslExpression.Get("min_height")
                )
            ),
        };

        map.Layers = new List<MapboxLayer>
        {
            layer,
        };

        var center = new Point(40.7135, -74.0066);
        var cameraOptions = new CameraOptions
        {
            Center = center,
            Zoom = 15.5f,
            Bearing = -17.6f,
            Pitch = 45,
        };
        map.CameraOptions = cameraOptions;
    }

    private void Map_MapReady(object sender, EventArgs e)
    {
        map.MapboxStyle = MapboxStyle.LIGHT;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }
}