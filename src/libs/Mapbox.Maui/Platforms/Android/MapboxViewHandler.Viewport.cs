using Com.Mapbox.Maps.Plugins.Viewport;
using Com.Mapbox.Maps.Plugins.Viewport.Data;
using Com.Mapbox.Maps.Plugins.Viewport.State;
using X = MapboxMaui.Viewport;

namespace MapboxMaui;

partial class MapboxViewHandler : X.IViewportPlugin
{
    public X.IFollowPuckViewportState MakeFollowPuckViewportState(X.FollowPuckViewportStateOptions options)
    {
        var mapView = mapboxFragment?.MapView;

        if (mapView == null) return null;

        var viewport = ViewportUtils.GetViewport(mapView);
        var state = viewport.MakeFollowPuckViewportState(options.ToNative());

        return state.ToX();
    }

    public X.IOverviewViewportState MakeOverviewViewportState(X.OverviewViewportStateOptions options)
    {
        var mapView = mapboxFragment?.MapView;

        if (mapView == null) return null;

        var viewport = ViewportUtils.GetViewport(mapView);
        var state = viewport.MakeOverviewViewportState(options.ToNative());

        return state.ToX();
    }
}

public static class ViewportExtensions
{
    public static FollowPuckViewportStateOptions ToNative(
        this X.FollowPuckViewportStateOptions options)
    {
        FollowPuckViewportStateBearing bearing = options.Bearing.HasValue
            ? new FollowPuckViewportStateBearing.Constant(options.Bearing.Value)
            : FollowPuckViewportStateBearing.SyncWithLocationPuck.Instance;
        var builder = new FollowPuckViewportStateOptions.Builder()
            .Bearing(bearing)
            .Padding(options.Padding?.ToNative())
            .Pitch(options.Pitch?.ToNative())
            .Zoom(options.Zoom?.ToNative());
        return builder.Build();
    }
    public static OverviewViewportStateOptions ToNative(
        this X.OverviewViewportStateOptions options)
    {
        var builder = new OverviewViewportStateOptions.Builder()
            .AnimationDurationMs(options.AnimationDurationMs)
            .Bearing(options.Bearing.ToNative())
            .Geometry(options.Geometry.ToNative())
            .GeometryPadding(options.GeometryPadding.ToNative())
            .MaxZoom(options.MaxZoom?.ToNative())
            .Offset(options.Offset?.ToScreenCoordinate())
            .Padding(options.Padding.ToNative())
            .Pitch(options.Pitch.ToNative());
        return builder.Build();
    }

    public static X.IFollowPuckViewportState ToX(this IFollowPuckViewportState state)
        => new XFollowPuckViewPortState(state);
    public static X.IOverviewViewportState ToX(this IOverviewViewportState state)
        => new XOverviewViewportState(state);

    public static X.OverviewViewportStateOptions ToX(this OverviewViewportStateOptions state)
        => new()
        {
            AnimationDurationMs = state.AnimationDurationMs,
            Bearing = state.Bearing?.DoubleValue() ?? 0,
            Geometry = state.Geometry?.ToX(),
            GeometryPadding = state.GeometryPadding.ToX(),
            MaxZoom = state.MaxZoom?.DoubleValue(),
            Offset = state.Offset?.ToX(),
            Padding = state.Padding?.ToX() ?? Thickness.Zero,
            Pitch = state.Pitch?.DoubleValue() ?? 0,
        };
    public static X.FollowPuckViewportStateOptions ToX(this FollowPuckViewportStateOptions state)
        => new()
        {
            Bearing = state.Bearing is FollowPuckViewportStateBearing.Constant constValue
                ? constValue.Bearing
                : null,
            Padding = state.Padding?.ToX(),
            Pitch = state.Pitch?.DoubleValue(),
            Zoom = state.Zoom?.DoubleValue(),
        };
}

abstract class XViewportState : X.IViewportState, IDisposable
{
    private bool disposedValue;
    private readonly IViewportState platformValue;

    protected XViewportState(IViewportState platformValue)
    {
        this.platformValue = platformValue;
    }

    private void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                platformValue.Dispose();
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public ICancelable ObserveDataSource(X.ViewportStateDataObserver observer)
    {
        return new XCancellable(
            platformValue.ObserveDataSource(new XViewportStateDataObserver(observer))
        );
    }

    public void StartUpdatingCamera() => platformValue.StartUpdatingCamera();

    public void StopUpdatingCamera() => platformValue.StopUpdatingCamera();
}

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

sealed class XFollowPuckViewPortState : XViewportState, X.IFollowPuckViewportState, IDisposable
{
    private bool disposedValue;
    private readonly IFollowPuckViewportState platformValue;

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

sealed class XViewportStateDataObserver : Java.Lang.Object, IViewportStateDataObserver
{
    private readonly X.ViewportStateDataObserver observer;

    public XViewportStateDataObserver(X.ViewportStateDataObserver observer)
    {
        this.observer = observer;
    }
    public bool OnNewData(Com.Mapbox.Maps.CameraOptions cameraOptions)
        => observer.Invoke(cameraOptions.ToX());
}
