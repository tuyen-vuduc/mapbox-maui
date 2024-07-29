using Foundation;
using MapboxMapsObjC;
using ObjCRuntime;

namespace MapboxMaui.Viewport;

sealed class XViewportTransition : IViewportTransition
{
    private readonly ITMBViewportTransition transition;

    public XViewportTransition(ITMBViewportTransition transition)
    {
        this.transition = transition;
    }

    public ICancelable RunTo(IViewportState toState, Action<bool> completion)
    {
        return new XCancellable(
            transition.RunTo(
                toState.ToNative(),
                completion
            )
        );
    }
}

sealed class XTMBViewportTransition : NSObject, ITMBViewportTransition
{
    private readonly IViewportTransition transition;

    public XTMBViewportTransition(IViewportTransition transition)
    {
        this.transition = transition;
    }

    public TMBCancelable RunTo(ITMBViewportState toState, Action<bool> completion)
    {
        if (transition is not XViewportTransition wrapper)
        {
            throw new NotSupportedException("Invalid instance of IViewportState");
        }

        var cancelable = wrapper.RunTo(toState.ToX(), completion) as XCancellable;

        return cancelable?.Cancelable;
    }
}

