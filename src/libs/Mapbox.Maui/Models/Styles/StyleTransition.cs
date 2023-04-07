namespace Mapbox.Maui.Styles;

public record class StyleTransition
{
    /// Time allotted for transitions to complete in seconds.
    public long Duration { get; init; }

    /// Length of time before a transition begins in seconds.
    public long Delay { get; init; }

    public StyleTransition()
	{
    }

    public StyleTransition(long duration, long delay)
    {
        Duration = duration;
        Delay = delay;
    }
}

