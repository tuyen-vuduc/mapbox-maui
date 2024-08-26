

using Com.Mapbox.Bindgen;

namespace MapboxMaui;

internal class XExpectedAction : Java.Lang.Object, Expected.IAction
{
    private readonly Action<Java.Lang.Object> action;

    public XExpectedAction(Action<Java.Lang.Object> action)
    {
        this.action = action;
    }

    public void Run(Java.Lang.Object p0)
    {
        action?.Invoke(p0);
    }
}
