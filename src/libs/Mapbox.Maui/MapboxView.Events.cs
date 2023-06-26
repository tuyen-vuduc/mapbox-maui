namespace MapboxMaui;

using System.Windows.Input;

partial class MapboxView
{
    public event EventHandler<MapTappedEventArgs> MapTapped;
    internal void InvokeMapTapped(MapTappedPosition point)
    {
        MapTapped?.Invoke(this, new MapTappedEventArgs(point));

        if (Command?.CanExecute(point) == true)
        {
            Command.Execute(point);
        }
    }

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
       nameof(Command),
       typeof(ICommand),
       typeof(MapboxView)
    );
    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public event EventHandler MapReady;
    internal void InvokeMapReady()
    {
        MapReady?.Invoke(this, EventArgs.Empty);

        if (MapReadyCommand?.CanExecute(null) == true)
        {
            MapReadyCommand.Execute(null);
        }
    }

    public static readonly BindableProperty MapReadyCommandProperty = BindableProperty.Create(
       nameof(MapReadyCommand),
       typeof(ICommand),
       typeof(MapboxView),
       default(ICommand)
    );
    public ICommand MapReadyCommand
    {
        get => (ICommand)GetValue(MapReadyCommandProperty);
        set => SetValue(MapReadyCommandProperty, value);
    }

    public event EventHandler StyleLoaded;
    internal void InvokeStyleLoaded()
    {
        StyleLoaded?.Invoke(this, EventArgs.Empty);

        if (StyleLoadedCommand?.CanExecute(null) == true)
        {
            StyleLoadedCommand.Execute(null);
        }
    }

    public static readonly BindableProperty StyleLoadedCommandProperty = BindableProperty.Create(
       nameof(StyleLoadedCommand),
       typeof(ICommand),
       typeof(MapboxView),
       default(ICommand)
    );
    public ICommand StyleLoadedCommand
    {
        get => (ICommand)GetValue(StyleLoadedCommandProperty);
        set => SetValue(StyleLoadedCommandProperty, value);
    }

    public event EventHandler MapLoaded;
    internal void InvokeMapLoaded()
    {
        MapLoaded?.Invoke(this, EventArgs.Empty);

        if (MapLoadedCommand?.CanExecute(null) == true)
        {
            MapLoadedCommand.Execute(null);
        }
    }

    public static readonly BindableProperty MapLoadedCommandProperty = BindableProperty.Create(
       nameof(MapLoadedCommand),
       typeof(ICommand),
       typeof(MapboxView),
       default(ICommand)
    );
    public ICommand MapLoadedCommand
    {
        get => (ICommand)GetValue(MapLoadedCommandProperty);
        set => SetValue(MapLoadedCommandProperty, value);
    }
}

public class MapTappedPosition
{
    public Point ScreenPosition { get; set; }

    public GeoJSON.Text.Geometry.Point Point { get; set; }
}

