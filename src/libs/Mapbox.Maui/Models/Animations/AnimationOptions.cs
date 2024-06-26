namespace MapboxMaui;

public record AnimationOptions (
    long? Duration,
    TimingCurve Curve = TimingCurve.EaseOut,
    long? StartDelay = default,
    string Owner = default);

public enum TimingCurve
{
    EaseIn,
    EaseInOut,
    EaseOut,
    Linear,
}

public enum AnimatingPosition
{
    End,
    Start,
    Current
}

public record AnimationState(AnimatingPosition Position);
