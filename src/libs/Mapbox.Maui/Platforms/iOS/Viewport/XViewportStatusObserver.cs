using Foundation;
using MapboxMapsObjC;
using MapboxMaui.Viewport;

namespace MapboxMaui;

partial class XViewportStatusObserver : NSObject, ITMBViewportStatusObserver
{
    private readonly Action<ViewportStatusChangedEventArgs> action;

    public XViewportStatusObserver(Action<ViewportStatusChangedEventArgs> action)
    {
        this.action = action;
    }

    public void ViewportStatusDidChangeFrom(
        TMBViewportStatus fromStatus,
        TMBViewportStatus toStatus,
        TMBViewportStatusChangeReason reason)
    {
        action?.Invoke(new ViewportStatusChangedEventArgs(
            fromStatus.ToX(),
            toStatus.ToX(),
            reason.ToX()
            ));
    }
}