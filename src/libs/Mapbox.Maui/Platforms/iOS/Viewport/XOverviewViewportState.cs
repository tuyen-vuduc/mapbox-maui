using MapboxMapsObjC;
using X = MapboxMaui.Viewport;

namespace MapboxMaui;

sealed class XOverviewViewportState : XViewportState, X.IOverviewViewportState, IDisposable
{
    private readonly TMBOverviewViewportState platformValue;

    public XOverviewViewportState(TMBOverviewViewportState platformValue)
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
