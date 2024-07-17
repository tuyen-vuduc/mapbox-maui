namespace MapboxMaui.Camera;

public interface ICameraPlugin
{
    void FlyTo(CameraOptions cameraOptions, AnimationOptions animationOptions = default, Action<AnimationState> completion = default);
    void EaseTo(CameraOptions cameraOptions, AnimationOptions animationOptions = default, Action<AnimationState> completion = default);
}
