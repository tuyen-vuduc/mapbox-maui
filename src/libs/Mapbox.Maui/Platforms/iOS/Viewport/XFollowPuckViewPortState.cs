using MapboxMapsObjC;
using X = MapboxMaui.Viewport;

namespace MapboxMaui;

sealed class XFollowPuckViewPortState : XViewportState, X.IFollowPuckViewportState, IDisposable
{
    private bool disposedValue;
    private readonly TMBFollowPuckViewportState platformValue;

    public XFollowPuckViewPortState(TMBFollowPuckViewportState platformValue)
        : base(platformValue)
    {
        this.platformValue = platformValue;
    }

    public X.FollowPuckViewportStateOptions Options
    {
        get => platformValue.Options.ToX();
        set => platformValue.Options = value.ToNative();
    }
}
