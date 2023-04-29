using MapboxMaui;
using MapboxMaui.Annotations;
using MapboxMaui.Styles;
using iOSPage = Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific.Page;
namespace MapboxMauiQs;

public class AddOneMarkerSymbolExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;

    public AddOneMarkerSymbolExample()
	{
        iOSPage.SetUseSafeArea(this, false);
		Content = map = new MapboxView();

        map.MapReady += Map_MapReady;
        map.StyleLoaded += Map_StyleLoaded;
    }

    private void Map_StyleLoaded(object sender, EventArgs e)
    {
//        const string imageId = @"BLUE_ICON_ID";
//        const string imageName = @"blue_marker_view";
//        const string sourceId = @"SOURCE_ID";
//        var coordinates = new Point(55.665957, 12.550343);



//        TMBPoint* point = [TMBPoint withCoordinates: coordinates];
//        [mapView addSourceWithId:sourceId
    
//                        geometry:[TMBGeometry fromData:point]
//    onError: nil];

//        [mapView addLayerWithBuilder:^id _Nonnull{
//            return [self createSymbolLayerBuilder: sourceId
    
//                                             icon: imageId];
//        }
//    layerPosition: TMBLayerPositionUnowned
//layerPositionParam:nil
//          onError:nil];
    }

    private void Map_MapReady(object sender, EventArgs e)
    {
        // Do any additional setup after loading the view.
        var center = new Point(55.665957, 12.550343);
        var cameraOptions = new CameraOptions {
            Center = center,
            Zoom = 8,
        };

        map.CameraOptions = cameraOptions;

        map.MapboxStyle = MapboxStyle.MAPBOX_STREETS;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }
}