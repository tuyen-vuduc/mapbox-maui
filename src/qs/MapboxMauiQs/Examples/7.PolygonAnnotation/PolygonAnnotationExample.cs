namespace MapboxMauiQs;

using System;
using GeoJSON.Net.Geometry;
using Mapbox.Maui;
using Mapbox.Maui.Annotations;
using iOSPage = Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific.Page;

public class PolygonAnnotationExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;

    public PolygonAnnotationExample()
    {
        iOSPage.SetUseSafeArea(this, false);
        Content = map = new MapboxView();

        map.MapReady += Map_MapReady;
        map.MapLoaded += Map_MapLoaded;
    }

    private void Map_MapReady(object sender, EventArgs e)
    {
        var centerLocation = new Microsoft.Maui.Graphics.Point(25.04579, -88.90136);
        var cameraOptions = new CameraOptions
        {
            Center = centerLocation,
            Zoom = 5,
        };

        map.CameraOptions = cameraOptions;

    }

    private void Map_MapLoaded(object sender, EventArgs e)
    {
        var polygon = new Polygon(new[]
        {
            // outer ring
            new [] {
                new [] { 24.51713945052515, -89.857177734375 },
                new [] { 24.51713945052515, -87.967529296875 },
                new [] { 26.244156283890756, -87.967529296875 },
                new [] { 26.244156283890756, -89.857177734375 },
                new [] { 24.51713945052515, -89.857177734375 }
            },
            // inner ring
            new [] {
                new [] { 25.085598897064752, -89.20898437499999 },
                new [] { 25.085598897064752, -88.61572265625 },
                new [] { 25.720735134412106, -88.61572265625 },
                new [] { 25.720735134412106, -89.20898437499999 },
                new [] { 25.085598897064752, -89.20898437499999 }
            }
        });
        var polygonAnnotation = new PolygonAnnotation(polygon)
        {
            FillColor = Colors.Red,
            FillOpacity = 0.8,
        };

        map.Annotations = new[]
        {
            polygonAnnotation,
        };
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }
}