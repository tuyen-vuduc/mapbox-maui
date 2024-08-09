namespace MapboxMaui.Viewport;

public interface IViewportTransition
{
    ICancelable RunTo(IViewportState toState, Action<bool> completion);
}

