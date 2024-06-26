using Android.Animation;
using Com.Mapbox.Maps.Plugins.Animation;

namespace MapboxMaui;

partial class MapboxViewHandler : IMapCameraController
{
    public void FlyTo(CameraOptions cameraOptions, AnimationOptions animationOptions = default, Action<AnimationState> completion = default)
    {
        var mapView = mapboxFragment?.MapView;

        if (mapView == null) return;

        var xcameraOptions = cameraOptions.ToNative();
        var xanimationOptions = animationOptions?.ToNative();

        // TODO Return Cancellable obj
        CameraAnimationsUtils.FlyTo(
            mapView.MapboxMap,
            xcameraOptions,
            xanimationOptions,
            completion != null
            ? new XAnimationListener(completion)
            : null);
    }

    private class XAnimationListener : Java.Lang.Object, Android.Animation.Animator.IAnimatorListener
    {
        private Action<AnimationState> completion;

        public XAnimationListener(Action<AnimationState> completion)
        {
            this.completion = completion;
        }

        public void OnAnimationCancel(Animator animation)
        {
        }

        public void OnAnimationEnd(Animator animation)
        {
            completion(new AnimationState(AnimatingPosition.End));
        }

        public void OnAnimationRepeat(Animator animation)
        {
        }

        public void OnAnimationStart(Animator animation)
        {
            completion(new AnimationState(AnimatingPosition.Start));
        }
    }
}
