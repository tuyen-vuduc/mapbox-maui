using MapboxCoreMaps;
using MapboxMaps;
using MapboxMapsObjC;
using UIKit;

namespace MapboxMaui;

public class MapViewContainer : UIView
{
    public MapView MapView { get; private set; }

    public MapViewContainer(string accessToken)
        : base()
    {
        var resourceOptions = new MBMResourceOptions(accessToken, null,  null, null, null);
        var options = MapInitOptionsFactory
            .CreateWithResourceOptions(resourceOptions, null, null, null, null);

        var mapView = MapViewFactory.CreateWithFrame(
            CoreGraphics.CGRect.FromLTRB(0, 0, 320, 675),
            options
        );
        mapView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

        AddSubview(mapView);

        mapView.TranslatesAutoresizingMaskIntoConstraints = false;

        NSLayoutConstraint.ActivateConstraints(new NSLayoutConstraint[]
        {
            mapView.TopAnchor.ConstraintEqualTo(TopAnchor),
            mapView.LeadingAnchor.ConstraintEqualTo(LeadingAnchor),
            mapView.BottomAnchor.ConstraintEqualTo(BottomAnchor),
            mapView.TrailingAnchor.ConstraintEqualTo(TrailingAnchor),
        });

        MapView = mapView;
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        if (!disposing) return;

        if (MapView != null)
        {
            MapView.Dispose();
            MapView = null;
        }
    }
}

