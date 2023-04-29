namespace MapboxMaui.Styles;

public class StyleTransition : BaseKVContainer
{
    public StyleTransition() : base()
	{
    }

    public StyleTransition(long duration, long delay)
    {
        Duration = duration;
        Delay = delay;
    }

    /// Time allotted for transitions to complete in seconds.
    public long Duration {
        get => GetProperty<long>(StyleTransitionKey.duration, default);
        set => SetProperty(StyleTransitionKey.duration, value);
    }

    /// Length of time before a transition begins in seconds.
    public long Delay
    {
        get => GetProperty<long>(StyleTransitionKey.delay, default);
        set => SetProperty(StyleTransitionKey.delay, value);
    }

    private static class StyleTransitionKey
    {
        public const string duration = "duration";
        public const string delay = "delay";
    }
}
