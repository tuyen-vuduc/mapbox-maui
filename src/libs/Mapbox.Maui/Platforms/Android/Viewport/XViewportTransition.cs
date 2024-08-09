using Com.Mapbox.Maps.Plugins.Viewport;
using P = Com.Mapbox.Maps.Plugins.Viewport;

namespace MapboxMaui.Viewport;

sealed class XViewportTransition : IViewportTransition
{
    private readonly P.Transition.IViewportTransition transition;

    public XViewportTransition(P.Transition.IViewportTransition transition)
    {
        this.transition = transition;
    }

    public ICancelable RunTo(IViewportState toState, Action<bool> completion)
    {
        return new XCancellable(
            transition.Run(
                toState.ToNative(),
                new XViewportTransitionCompletionListener(completion)
            )
        );
    }
}
sealed class PViewportTransition : Java.Lang.Object, P.Transition.IViewportTransition
{
    private readonly IViewportTransition transition;

    public PViewportTransition(IViewportTransition transition)
    {
        this.transition = transition;
    }

    public Com.Mapbox.Common.ICancelable Run(P.State.IViewportState toState, ICompletionListener completion)
    {
        if (transition is not XViewportTransition wrapper)
        {
            throw new NotSupportedException("Invalid instance of IViewportState");
        }

        var cancelable = wrapper.RunTo(toState.ToX(), (x) => completion?.OnComplete(x)) as XCancellable;

        return cancelable?.Cancelable;
    }
}

sealed class XViewportTransitionCompletionListener : Java.Lang.Object, ICompletionListener
{
    private readonly Action<bool> completion;

    public XViewportTransitionCompletionListener(Action<bool> completion)
    {
        this.completion = completion;
    }

    public void OnComplete(bool isFinished)
    {
        completion?.Invoke(isFinished);
    }
}