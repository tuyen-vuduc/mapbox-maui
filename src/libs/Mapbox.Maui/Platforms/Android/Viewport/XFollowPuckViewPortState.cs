using Com.Mapbox.Maps.Plugins.Viewport.Data;
using Com.Mapbox.Maps.Plugins.Viewport.State;
using X = MapboxMaui.Viewport;

namespace MapboxMaui;

sealed class XFollowPuckViewPortState : XViewportState, X.IFollowPuckViewportState, IDisposable
{
    public readonly IFollowPuckViewportState platformValue;

    public XFollowPuckViewPortState(IFollowPuckViewportState platformValue)
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
