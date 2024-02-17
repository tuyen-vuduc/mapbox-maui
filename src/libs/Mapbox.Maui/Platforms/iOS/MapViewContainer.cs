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
        // TODO Set access token
        var options = MapInitOptionsFactory
            .CreateWithMapOptions(null, null, null, null, 0);

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

