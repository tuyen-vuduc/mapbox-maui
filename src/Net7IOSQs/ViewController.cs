using MapboxCoreMaps;
using MapboxMaps;
using MapboxMapsObjC;

namespace Net7IOSQs;

[Register("ViewController")]
public class ViewController : UIViewController
{
    public override void ViewDidLoad()
    {
        View = new UIView
        {
            BackgroundColor = UIColor.Red,
        };

        base.ViewDidLoad();

        MapInitOptions options = MapInitOptionsBuilder
                .Create()
                .StyleUriString("mapbox://styles/examples/cke97f49z5rlg19l310b7uu7j")
                .Build();
        // Perform any additional setup after loading the view, typically from a nib.
        var mapView = MapViewFactory.CreateWithFrame(
            View.Bounds,
            options
        );
        mapView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight
            | UIViewAutoresizing.FlexibleWidth;

        View.AddSubview(mapView);
    }
}

