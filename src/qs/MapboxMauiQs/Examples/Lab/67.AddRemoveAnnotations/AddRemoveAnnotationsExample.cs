namespace MapboxMauiQs;

public class AddRemoveAnnotationsExample : ContentPage, IExamplePage, IQueryAttributable
{
    const string markerIconId = "marker_icon";
    static readonly IPosition defaultCenterPosition = new MapPosition(21.0278, 105.8342);

    MapboxView map;
    IExampleInfo info;

    public AddRemoveAnnotationsExample()
    {
        iOSPage.SetUseSafeArea(this, false);
        
        Content = new Grid
        {
            Children = {
                (map = new MapboxView()),
                new StackLayout {
                    Margin = 16,
                    VerticalOptions = LayoutOptions.End,
                    HorizontalOptions = LayoutOptions.End,
                    Orientation = StackOrientation.Vertical,
                    Spacing = 4,
                    Children = {
                        new Button
                        {
                            Text = "+One",
                            Padding = 4,
                            TextColor = Colors.White,
                            BackgroundColor = Colors.Purple.WithAlpha(0.7f),
                            Command = new Command(AddAnnotation),
                        },
                        new Button
                        {
                            Text = "-One",
                            Padding = 4,
                            TextColor = Colors.White,
                            BackgroundColor = Colors.Purple.WithAlpha(0.7f),
                            Command = new Command(RemoveAnnotation)
                        },
                        new Button
                        {
                            Text = "-All",
                            Padding = 4,
                            TextColor = Colors.White,
                            BackgroundColor = Colors.Purple.WithAlpha(0.7f),
                            Command = new Command(RemoveAllAnnotations)
                        }
                    },
                },
            },
        };

        map.MapReady += Map_MapReady;
        map.MapLoaded += Map_MapLoaded;
    }

    Random random = new Random();
    Stack<IAnnotation> annotations = new ();
    ICircleAnnotationManager circleAnnotationManager;
    IPointAnnotationManager pointAnnotationManager;
    private void AddAnnotation()
    {
        var option = random.Next(0, 2);
        var position = new MapPosition(
            random.NextDouble() * 180 - 90,
            random.NextDouble() * 360 - 180);
        switch (option)
        {
            case 0:
                pointAnnotationManager = pointAnnotationManager ?? map.AnnotationController.CreatePointAnnotationManager(
                    "POINT_ANNOTATIONS",
                    LayerPosition.Unknown());
                var pointAnnotation = new PointAnnotation(
                    new GeoJSON.Text.Geometry.Point(
                        position
                    ))
                {
                    IconImage = markerIconId,
                };
                pointAnnotationManager.AddAnnotations(pointAnnotation);
                annotations.Push(pointAnnotation);

                map.CameraController.EaseTo(new CameraOptions {
                    Center = position,
                    Zoom = 3,
                });
                break;
            case 1:
                circleAnnotationManager = circleAnnotationManager ?? map.AnnotationController.CreateCircleAnnotationManager(
                    "CIRCLE_ANNOTATIONS",
                    LayerPosition.Unknown());
                var circleAnnotation = new CircleAnnotation(
                    new GeoJSON.Text.Geometry.Point(
                        position
                    ))
                {
                    CircleRadius = (8.0),
                    CircleColor = Color.FromRgba(0xee, 0x4e, 0x8b, 0xff),
                    CircleStrokeWidth = (2.0),
                    CircleStrokeColor = Color.FromRgba(0xff, 0xff, 0xff, 0xff),
                };
                circleAnnotationManager.AddAnnotations(circleAnnotation);
                annotations.Push(circleAnnotation);

                map.CameraController.EaseTo(new CameraOptions
                {
                    Center = position,
                    Zoom = 3,
                });
                break;
        }
    }
    private async void RemoveAnnotation()
    {
        if (!annotations.TryPop(out var annotation)) return;

        switch (annotation)
        {
            case PointAnnotation pointAnnotation:
                pointAnnotationManager.RemoveAnnotations(pointAnnotation.Id);
                break;
            case CircleAnnotation circleAnnotation:
                circleAnnotationManager.RemoveAnnotations(circleAnnotation.Id);
                break;
        }

        await DisplayAlert("Info", $"Last {annotation.GetType().Name} was removed", "OK");

        if (annotations.TryPeek(out annotation))
        {
            IPosition mapPosition = annotation switch
            {
                PointAnnotation pointAnnotation => pointAnnotation.GeometryValue.Coordinates,
                CircleAnnotation circleAnnotation => circleAnnotation.GeometryValue.Coordinates,
                _ => defaultCenterPosition,
            };
            map.CameraController.EaseTo(new CameraOptions
            {
                Center = mapPosition,
                Zoom = 3,
            });
        }
    }
    private async void RemoveAllAnnotations()
    {
        pointAnnotationManager?.RemoveAllAnnotations();
        circleAnnotationManager?.RemoveAllAnnotations();
        await DisplayAlert("Info", $"All annotations were removed", "OK");
        annotations?.Clear();
        map.CameraController.EaseTo(new CameraOptions
        {
            Center = defaultCenterPosition,
            Zoom = 14,
        });
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }

    private void Map_MapReady(object sender, EventArgs e)
    {
        var centerLocation = defaultCenterPosition;
        var cameraOptions = new CameraOptions
        {
            Center = centerLocation,
            Zoom = 14,
        };

        map.CameraOptions = cameraOptions;
    }

    private void Map_MapLoaded(object sender, EventArgs e)
    {
        map.MapboxStyle = MapboxStyle.MAPBOX_STREETS;

        // Setup Styles, Annotations, etc here
        map.Images = [
            new ResolvedImage(markerIconId, "red_marker"),
        ];
    }
}