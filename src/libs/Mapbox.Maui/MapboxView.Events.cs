using System;
using System.Windows.Input;

namespace Mapbox.Maui;

partial class MapboxView
{
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
}

