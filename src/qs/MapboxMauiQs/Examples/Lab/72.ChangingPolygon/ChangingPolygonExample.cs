namespace MapboxMauiQs;

public class ChangingPolygonExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;

    public ChangingPolygonExample()
    {
        iOSPage.SetUseSafeArea(this, false);
        Content = new Grid
        {
            Children =
            {
                (map = new MapboxView()),
                new Button
                {
                    Text = "Change",
                    Command = new Command(ChangePolygonShape),
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.End,
                    Margin = 16,
                },
            },
        };

        map.MapReady += Map_MapReady;
        map.MapLoaded += Map_MapLoaded;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }

    private void Map_MapReady(object sender, EventArgs e)
    {
        var centerLocation = new MapPosition(21.0278, 105.8342);
        var cameraOptions = new CameraOptions
        {
            Center = centerLocation,
            Zoom = 14,
        };

        map.CameraOptions = cameraOptions;
        map.MapboxStyle = MapboxStyle.MAPBOX_STREETS;
    }
    private void ChangePolygonShape()
    {
        if (polygonAnnotation is null) return;

        var polygon = JsonSerializer.Deserialize<Polygon>(
            isRect
            ? circlePolygonJson
            : rectPolygonJson
            );
        polygonAnnotation.GeometryValue = polygon;
        polygonAnnotation.FillOutlineColor = !isRect
            ? Colors.Aquamarine
            : Colors.MediumVioletRed;
        polygonAnnotation.FillColor = !isRect
            ? Colors.MidnightBlue
            : Colors.MistyRose;
        isRect = !isRect;

        polygonAnnotationManager.UpdateAnnotations(polygonAnnotation);
    }

    IPolygonAnnotationManager polygonAnnotationManager;
    PolygonAnnotation polygonAnnotation;
    bool isRect = true;
    private void Map_MapLoaded(object sender, EventArgs e)
    {
        // Setup Styles, Annotations, etc here
        polygonAnnotationManager = map.AnnotationController.CreatePolygonAnnotationManager("POLYGON", LayerPosition.Unknown());

        var polygon = JsonSerializer.Deserialize<Polygon>(rectPolygonJson);
        polygonAnnotation = new PolygonAnnotation(polygon) { 
            FillOutlineColor = Colors.Aqua,
            FillColor = Colors.MidnightBlue,
        };

        polygonAnnotationManager.AddAnnotations(polygonAnnotation);
    }

    const string rectPolygonJson = """
            {
                "coordinates": [
                    [
                    [
                        105.83326185607308,
                        21.028376588352103
                    ],
                    [
                        105.83326185607308,
                        21.026889799662342
                    ],
                    [
                        105.83517732224095,
                        21.026889799662342
                    ],
                    [
                        105.83517732224095,
                        21.028376588352103
                    ],
                    [
                        105.83326185607308,
                        21.028376588352103
                    ]
                    ]
                ],
                "type": "Polygon"
            }
            """;
    const string circlePolygonJson = """
            {
                "type": "Polygon",
                "coordinates": [
                  [
                    [
                      105.83410869370863,
                      21.02885543808356
                    ],
                    [
                      105.83399912000088,
                      21.0288504135467
                    ],
                    [
                      105.83389060156982,
                      21.028835388326144
                    ],
                    [
                      105.8337841835284,
                      21.028810507125986
                    ],
                    [
                      105.83368089076001,
                      21.028776009570635
                    ],
                    [
                      105.83358171804758,
                      21.02873222789696
                    ],
                    [
                      105.83348762049256,
                      21.02867958375438
                    ],
                    [
                      105.83339950431622,
                      21.028618584143853
                    ],
                    [
                      105.83331821813196,
                      21.028549816534852
                    ],
                    [
                      105.83324454477231,
                      21.02847394320729
                    ],
                    [
                      105.83317919374984,
                      21.02839169487306
                    ],
                    [
                      105.83312279442421,
                      21.028303863638445
                    ],
                    [
                      105.83307588994136,
                      21.028211295375346
                    ],
                    [
                      105.83303893200303,
                      21.028114881574705
                    ],
                    [
                      105.83301227651732,
                      21.028015550760667
                    ],
                    [
                      105.83299618017169,
                      21.027914259548133
                    ],
                    [
                      105.83299079796151,
                      21.02781198342984
                    ],
                    [
                      105.83299618169852,
                      21.02770970738173
                    ],
                    [
                      105.83301227951235,
                      21.02760841637705
                    ],
                    [
                      105.8330389363511,
                      21.027509085900547
                    ],
                    [
                      105.8330758954754,
                      21.02741267255415
                    ],
                    [
                      105.83312280093156,
                      21.027320104844545
                    ],
                    [
                      105.83317920098042,
                      21.027232274241413
                    ],
                    [
                      105.83324455244826,
                      21.027150026592384
                    ],
                    [
                      105.83331822595828,
                      21.027074153977402
                    ],
                    [
                      105.83339951199217,
                      21.027005387080983
                    ],
                    [
                      105.83348762772314,
                      21.02694438815565
                    ],
                    [
                      105.83358172455495,
                      21.026891744644555
                    ],
                    [
                      105.83368089629406,
                      21.026847963524375
                    ],
                    [
                      105.83378418787647,
                      21.02681346642327
                    ],
                    [
                      105.83389060456481,
                      21.026788585560645
                    ],
                    [
                      105.83399912152771,
                      21.02677356054794
                    ],
                    [
                      105.83410869370863,
                      21.02676853608126
                    ],
                    [
                      105.83421826588956,
                      21.02677356054794
                    ],
                    [
                      105.83432678285246,
                      21.026788585560645
                    ],
                    [
                      105.8344331995408,
                      21.02681346642327
                    ],
                    [
                      105.83453649112322,
                      21.026847963524375
                    ],
                    [
                      105.83463566286233,
                      21.026891744644555
                    ],
                    [
                      105.83472975969414,
                      21.02694438815565
                    ],
                    [
                      105.8348178754251,
                      21.027005387080983
                    ],
                    [
                      105.83489916145898,
                      21.027074153977402
                    ],
                    [
                      105.83497283496902,
                      21.027150026592384
                    ],
                    [
                      105.83503818643683,
                      21.027232274241413
                    ],
                    [
                      105.8350945864857,
                      21.027320104844545
                    ],
                    [
                      105.83514149194188,
                      21.02741267255415
                    ],
                    [
                      105.83517845106618,
                      21.027509085900547
                    ],
                    [
                      105.83520510790493,
                      21.02760841637705
                    ],
                    [
                      105.83522120571875,
                      21.02770970738173
                    ],
                    [
                      105.83522658945576,
                      21.02781198342984
                    ],
                    [
                      105.8352212072456,
                      21.027914259548133
                    ],
                    [
                      105.83520511089993,
                      21.028015550760667
                    ],
                    [
                      105.83517845541425,
                      21.028114881574705
                    ],
                    [
                      105.83514149747592,
                      21.028211295375346
                    ],
                    [
                      105.83509459299306,
                      21.028303863638445
                    ],
                    [
                      105.83503819366742,
                      21.02839169487306
                    ],
                    [
                      105.83497284264496,
                      21.02847394320729
                    ],
                    [
                      105.83489916928531,
                      21.028549816534852
                    ],
                    [
                      105.83481788310104,
                      21.028618584143853
                    ],
                    [
                      105.83472976692471,
                      21.02867958375438
                    ],
                    [
                      105.83463566936967,
                      21.02873222789696
                    ],
                    [
                      105.83453649665726,
                      21.028776009570635
                    ],
                    [
                      105.83443320388886,
                      21.028810507125986
                    ],
                    [
                      105.83432678584745,
                      21.028835388326144
                    ],
                    [
                      105.83421826741639,
                      21.0288504135467
                    ],
                    [
                      105.83410869370863,
                      21.02885543808356
                    ]
                  ]
                ]
              }
        """;
}