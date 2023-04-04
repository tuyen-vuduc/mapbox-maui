namespace Mapbox.Maui.Styles;

public record class StyleTransition
{
    /// Time allotted for transitions to complete in seconds.
    public double Duration { get; init; }

    /// Length of time before a transition begins in seconds.
    public double Delay { get; init; }

    public StyleTransition()
	{
    }

    public StyleTransition(double duration, double delay)
    {
        Duration = duration;
        Delay = delay;
    }
}

