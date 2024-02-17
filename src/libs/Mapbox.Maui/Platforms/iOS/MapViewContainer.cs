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
        if (!string.IsNullOrWhiteSpace(accessToken)) 
        {
            MapboxCommon.MBXMapboxOptions.SetAccessTokenForToken(accessToken);
        }

        var mapboxOptions = new MBMMapOptions(null, null, null, null, null, null, 1, null);
        var options = MapInitOptionsFactory
            .CreateWithMapOptions(mapboxOptions, null, null, null, 0);

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

