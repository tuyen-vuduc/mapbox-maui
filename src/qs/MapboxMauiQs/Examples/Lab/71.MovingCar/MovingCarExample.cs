namespace MapboxMauiQs;

public class MovingCarExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;
    IPosition lastPosition;

    public MovingCarExample()
	{
        iOSPage.SetUseSafeArea(this, false);
		Content = new Grid
        {
            Children = {
                (map = new MapboxView()),
                new HorizontalStackLayout
                {
                    VerticalOptions = LayoutOptions.End,
                    HorizontalOptions = LayoutOptions.Center,
                    Margin = new Thickness(16),
                    Spacing = 16,
                    Children =
                    {
                        new Button
                        {
                            Text = "Move",
                            Command = new Command(Move),
                        },
                        new Button
                        {
                            Text = "Center",
                            Command = new Command(Centralize),
                        },
                    },
                },
            }
        };

        map.MapReady += Map_MapReady;
        map.MapLoaded += Map_MapLoaded;
	}

    private void Centralize(object obj)
    {
        if (carAnnotation is null) return;

        map.CameraController.EaseTo(new CameraOptions()
        {
            Center = carAnnotation.GeometryValue.Coordinates,
        });
    }

    private void Move(object obj)
    {
        if (carAnnotation is null) return;

        var currentPosition = carAnnotation.GeometryValue;
        carAnnotation.GeometryValue = new GeoJSON.Text.Geometry.Point(
            new MapPosition(
                currentPosition.Latitude() + 0.001,
                currentPosition.Longitude() + 0.0001
                )
            );
        pointAnnotationManager.UpdateAnnotations(carAnnotation);
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }

    private void Map_MapReady(object sender, EventArgs e)
    {
        var centerLocation = lastPosition = new MapPosition(21.0278, 105.8342);
        var cameraOptions = new CameraOptions
        {
            Center = centerLocation,
            Zoom = 14,
        };

        map.CameraOptions = cameraOptions;
        map.MapboxStyle = MapboxStyle.MAPBOX_STREETS;
    }

    IPointAnnotationManager pointAnnotationManager;
    PointAnnotation carAnnotation;
    private void Map_MapLoaded(object sender, EventArgs e)
    {
        map.Images = [
            new ResolvedImage("CAR", "ic_car_top"),
            ];

        pointAnnotationManager = map.AnnotationController.CreatePointAnnotationManager("CARS", LayerPosition.Unknown());

        carAnnotation = new PointAnnotation(new GeoJSON.Text.Geometry.Point(lastPosition))
        {
            IconImage = "CAR",
        };
        pointAnnotationManager.AddAnnotations(carAnnotation);
    }
}