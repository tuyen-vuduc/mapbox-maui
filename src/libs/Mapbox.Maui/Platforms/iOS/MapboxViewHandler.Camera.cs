using MapboxMapsObjC;

namespace MapboxMaui;

partial class MapboxViewHandler : IMapCameraController
{
    public void EaseTo(CameraOptions cameraOptions, AnimationOptions animationOptions = default, Action<AnimationState> completion = default)
    {
        var mapView = PlatformView.MapView;

        if (mapView == null) return;

        var xcameraOptions = cameraOptions.ToNative();
        mapView.Camera().FlyTo(
            xcameraOptions,
            animationOptions?.Duration / 1000L ?? 0,
            (position) =>
            {
                var xposition = position switch
                {
                    UIKit.UIViewAnimatingPosition.Start => AnimatingPosition.Start,
                    UIKit.UIViewAnimatingPosition.End => AnimatingPosition.End,
                    UIKit.UIViewAnimatingPosition.Current => AnimatingPosition.Current,
                    _ => AnimatingPosition.Current,
                };

                completion?.Invoke(new AnimationState(xposition));
            });
    }
    public void FlyTo(CameraOptions cameraOptions, AnimationOptions animationOptions = default, Action<AnimationState> completion = default)
    {
        var mapView = PlatformView.MapView;

        if (mapView == null) return;

        var xcameraOptions = cameraOptions.ToNative();
        mapView.Camera().FlyTo(
            xcameraOptions,
            animationOptions?.Duration / 1000L ?? 0,
            (position) =>
            {
                var xposition = position switch
                {
                    UIKit.UIViewAnimatingPosition.Start => AnimatingPosition.Start,
                    UIKit.UIViewAnimatingPosition.End => AnimatingPosition.End,
                    UIKit.UIViewAnimatingPosition.Current => AnimatingPosition.Current,
                    _ => AnimatingPosition.Current,
                };

                completion?.Invoke(new AnimationState(xposition));
            });
    }
}
