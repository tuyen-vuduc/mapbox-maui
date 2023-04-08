using System;
using Mapbox.Maui;
using Mapbox.Maui.Expressions;
using Mapbox.Maui.Styles;
using iOSPage = Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific.Page;
namespace MapboxMauiQs;

public class BuildingExtrusionsExampleExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;

    public BuildingExtrusionsExampleExample()
	{
        iOSPage.SetUseSafeArea(this, false);
		Content = map = new MapboxView();

        map.MapReady += Map_MapReady;
        map.StyleLoaded += Map_StyleLoaded;
	}

    private void Map_StyleLoaded(object sender, EventArgs e)
    {
        var layer = new FillExtrusionLayer("3d-buildings")
        {
            Source = "composite",
            MinZoom = 15,
            SourceLayer = "building",
            FillExtrusionColor = new PropertyValue(Colors.LightGray.ToArgbHex(true)),
            FillExtrusionOpacity = new PropertyValue(0.6),
            FillExtrusionAmbientOcclusionIntensity = new PropertyValue(0.3),
            FillExtrusionAmbientOcclusionRadius = new PropertyValue(3.0),
            Filter = DslExpression.eq(
                DslExpression.get("extrude"),
                "true"
            ),
            FillExtrusionHeight = new PropertyValue(
                DslExpression.interpolate(
                    DslExpression.linear(),
                    DslExpression.zoom(),
                    15,
                    0,
                    15.05,
                    DslExpression.get("height")
                )
            ),
            FillExtrusionBase = new PropertyValue(
                DslExpression.interpolate(
                    DslExpression.linear(),
                    DslExpression.zoom(),
                    15,
                    0,
                    15.05,
                    DslExpression.get("min_height")
                )
            ),
        };

        map.Layers = new List<MapboxLayer>
        {
            layer,
        };
    }

    private void Map_MapReady(object sender, EventArgs e)
    {
        var center = new Point(40.7135,  -74.0066);
        var cameraOptions = new CameraOptions {
            Center = center,
            Zoom = 15.5f,
            Bearing = -17.6f,
            Pitch = 45,
        };
        map.CameraOptions = cameraOptions;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }
}