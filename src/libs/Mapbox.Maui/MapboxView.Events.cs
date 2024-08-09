namespace MapboxMaui;

using System.Windows.Input;

partial class MapboxView
{
    public event EventHandler<Gestures.RotatingEventArgs> Rotating;
    public static readonly BindableProperty RotatingCommandProperty = BindableProperty.Create(
        nameof(RotatingCommand),
        typeof(ICommand),
        typeof(MapboxView)
    );
    public ICommand RotatingCommand
    {
        get => (ICommand)GetValue(RotatingCommandProperty);
        set => SetValue(RotatingCommandProperty, value);
    }
    internal void InvokeRotating(Gestures.RotatingEventArgs args)
    {
        Rotating?.Invoke(this, args);

        if (RotatingCommand?.CanExecute(args) == true)
        {
            RotatingCommand.Execute(args);
        }
    }
    
    public event EventHandler<Gestures.RotatingBeganEventArgs> RotatingBegan;
    public static readonly BindableProperty RotatingBeganCommandProperty = BindableProperty.Create(
        nameof(RotatingBeganCommand),
        typeof(ICommand),
        typeof(MapboxView)
    );
    public ICommand RotatingBeganCommand
    {
        get => (ICommand)GetValue(RotatingBeganCommandProperty);
        set => SetValue(RotatingBeganCommandProperty, value);
    }
    internal void InvokeRotatingBegan(Gestures.RotatingBeganEventArgs args)
    {
        RotatingBegan?.Invoke(this, args);

        if (RotatingBeganCommand?.CanExecute(args) == true)
        {
            RotatingBeganCommand.Execute(args);
        }
    }

    public event EventHandler<Gestures.RotatingEndedEventArgs> RotatingEnded;
    public static readonly BindableProperty RotatingEndedCommandProperty = BindableProperty.Create(
        nameof(RotatingEndedCommand),
        typeof(ICommand),
        typeof(MapboxView)
    );
    public ICommand RotatingEndedCommand
    {
        get => (ICommand)GetValue(RotatingEndedCommandProperty);
        set => SetValue(RotatingEndedCommandProperty, value);
    }
    internal void InvokeRotatingEnded(Gestures.RotatingEndedEventArgs args)
    {
        RotatingEnded?.Invoke(this, args);

        if (RotatingEndedCommand?.CanExecute(args) == true)
        {
            RotatingEndedCommand.Execute(args);
        }
    }
    public event EventHandler<Viewport.ViewportStatusChangedEventArgs> ViewportStatusChanged;
    public static readonly BindableProperty ViewportStatusChangedCommandProperty = BindableProperty.Create(
        nameof(ViewportStatusChangedCommand),
        typeof(ICommand),
        typeof(MapboxView)
    );
    public ICommand ViewportStatusChangedCommand
    {
        get => (ICommand)GetValue(ViewportStatusChangedCommandProperty);
        set => SetValue(ViewportStatusChangedCommandProperty, value);
    }
    internal void InvokeViewportStatusChanged(Viewport.ViewportStatusChangedEventArgs args)
    {
        ViewportStatusChanged?.Invoke(this, args);

        if (ViewportStatusChangedCommand?.CanExecute(args) == true)
        {
            ViewportStatusChangedCommand.Execute(args);
        }
    }
    public event EventHandler<CameraChangedEventArgs> CameraChanged;
    public static readonly BindableProperty CameraChangedCommandProperty = BindableProperty.Create(
        nameof(CameraChangedCommand),
        typeof(ICommand),
        typeof(MapboxView)
    );
    public ICommand CameraChangedCommand
    {
        get => (ICommand)GetValue(CameraChangedCommandProperty);
        set => SetValue(CameraChangedCommandProperty, value);
    }
    internal void InvokeCameraChanged(CameraOptions options)
    {
        CameraChanged?.Invoke(this, new CameraChangedEventArgs(options));

        if (CameraChangedCommand?.CanExecute(options) == true)
        {
            CameraChangedCommand.Execute(options);
        }
    }

    public event EventHandler<IndicatorAccuracyRadiusChangedEventArgs> IndicatorAccuracyRadiusChanged;
    public static readonly BindableProperty IndicatorAccuracyRadiusChangedCommandProperty = BindableProperty.Create(
        nameof(IndicatorAccuracyRadiusChangedCommand),
        typeof(ICommand),
        typeof(MapboxView)
    );
    public ICommand IndicatorAccuracyRadiusChangedCommand
    {
        get => (ICommand)GetValue(IndicatorAccuracyRadiusChangedCommandProperty);
        set => SetValue(IndicatorAccuracyRadiusChangedCommandProperty, value);
    }
    internal void InvokeIndicatorAccuracyRadiusChanged(double radius)
    {
        IndicatorAccuracyRadiusChanged?.Invoke(this, new IndicatorAccuracyRadiusChangedEventArgs(radius));

        if (IndicatorAccuracyRadiusChangedCommand?.CanExecute(radius) == true)
        {
            IndicatorAccuracyRadiusChangedCommand.Execute(radius);
        }
    }

    public event EventHandler<IndicatorBearingChangedEventArgs> IndicatorBearingChanged;
    public static readonly BindableProperty IndicatorBearingChangedCommandProperty = BindableProperty.Create(
        nameof(IndicatorBearingChangedCommand),
        typeof(ICommand),
        typeof(MapboxView)
    );
    public ICommand IndicatorBearingChangedCommand
    {
        get => (ICommand)GetValue(IndicatorBearingChangedCommandProperty);
        set => SetValue(IndicatorBearingChangedCommandProperty, value);
    }
    internal void InvokeIndicatorBearingChanged(double bearing)
    {
        IndicatorBearingChanged?.Invoke(this, new IndicatorBearingChangedEventArgs(bearing));

        if (IndicatorBearingChangedCommand?.CanExecute(bearing) == true)
        {
            IndicatorBearingChangedCommand.Execute(bearing);
        }
    }

    public event EventHandler<IndicatorPositionChangedEventArgs> IndicatorPositionChanged;
    public static readonly BindableProperty IndicatorPositionChangedCommandProperty = BindableProperty.Create(
        nameof(IndicatorPositionChangedCommand),
        typeof(ICommand),
        typeof(MapboxView)
    );
    public ICommand IndicatorPositionChangedCommand
    {
        get => (ICommand)GetValue(IndicatorPositionChangedCommandProperty);
        set => SetValue(IndicatorPositionChangedCommandProperty, value);
    }
    internal void InvokeIndicatorPositionChanged(IPosition position)
    {
        IndicatorPositionChanged?.Invoke(this, new IndicatorPositionChangedEventArgs(position));

        if (IndicatorPositionChangedCommand?.CanExecute(position) == true)
        {
            IndicatorPositionChangedCommand.Execute(position);
        }
    }

    public event EventHandler<MapTappedEventArgs> MapTapped;
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
    internal void InvokeMapTapped(MapTappedPosition point)
    {
        MapTapped?.Invoke(this, new MapTappedEventArgs(point));

        if (Command?.CanExecute(point) == true)
        {
            Command.Execute(point);
        }
    }

    public event EventHandler<MapTappedEventArgs> MapLongTapped;
    internal void InvokeMapLongTapped(MapTappedPosition position)
    {
        MapLongTapped?.Invoke(this, new MapTappedEventArgs(position));

        if (LongTapCommand?.CanExecute(position) == true)
        {
            LongTapCommand.Execute(position);
        }
    }    
    public static readonly BindableProperty LongTapCommandProperty = BindableProperty.Create(
        nameof(LongTapCommand),
        typeof(ICommand),
        typeof(MapboxView)
    );
    public ICommand LongTapCommand
    {
        get => (ICommand)GetValue(LongTapCommandProperty);
        set => SetValue(LongTapCommandProperty, value);
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
    internal void InvokeMapLoaded()
    {
        MapLoaded?.Invoke(this, EventArgs.Empty);

        if (MapLoadedCommand?.CanExecute(null) == true)
        {
            MapLoadedCommand.Execute(null);
        }
    }

    public event EventHandler MapLoadingError;
    public static readonly BindableProperty MapLoadingErrorCommandProperty = BindableProperty.Create(
       nameof(MapLoadingErrorCommand),
       typeof(ICommand),
       typeof(MapboxView),
       default(ICommand)
    );
    public ICommand MapLoadingErrorCommand
    {
        get => (ICommand)GetValue(MapLoadingErrorCommandProperty);
        set => SetValue(MapLoadingErrorCommandProperty, value);
    }
    internal void InvokeMapLoadingError()
    {
        MapLoadingError?.Invoke(this, EventArgs.Empty);

        if (MapLoadingErrorCommand?.CanExecute(null) == true)
        {
            MapLoadingErrorCommand.Execute(null);
        }
    }
}