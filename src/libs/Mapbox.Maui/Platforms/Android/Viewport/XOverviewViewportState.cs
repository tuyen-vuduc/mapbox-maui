using Com.Mapbox.Maps.Plugins.Viewport.State;
using X = MapboxMaui.Viewport;

namespace MapboxMaui;

sealed class XOverviewViewportState : XViewportState, X.IOverviewViewportState, IDisposable
{
    private readonly IOverviewViewportState platformValue;

    public XOverviewViewportState(IOverviewViewportState platformValue)
        : base(platformValue)
    {
        this.platformValue = platformValue;
    }

    public X.OverviewViewportStateOptions Options
    {
        get => platformValue.Options.ToX();
        set => platformValue.Options = value.ToNative();
    }
}
