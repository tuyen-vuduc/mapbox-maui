namespace MapboxMauiQs;

public class GestureSettingsExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;

    public GestureSettingsExample()
    {
        iOSPage.SetUseSafeArea(this, false);

        var centerLocation = new MapPosition(21.028511, 105.804817);
        var cameraOptions = new CameraOptions
        {
            Center = centerLocation,
            Zoom = 14,
        };
        Content = map = new MapboxView()
        {
            CameraOptions = cameraOptions,
        };

        var toolbarItem = new ToolbarItem()
        {
            Text = "Config",
            Command = new Command(ShowPopup)
        };
        ToolbarItems.Add(toolbarItem);



        map.MapReady += Map_MapReady;
        map.MapLoaded += Map_MapLoaded;
    }

    private async void ShowPopup()
    {
        await Shell.Current.GoToAsync(nameof(GestureSettingsExampleSettingsPage), true, new Dictionary<string, object>()
        {
            { "data", map.GestureSettings }
        });
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("example", out var example) && example is IExampleInfo exampleInfo)
        {
            info = exampleInfo;
            Title = info?.Title;
        }

        if (query.TryGetValue("data", out var data) && data is GestureSettings gestureSettings)
        {
            map.GestureSettings = gestureSettings;
        }
    }

    private void Map_MapReady(object sender, EventArgs e)
    {
    }

    private void Map_MapLoaded(object sender, EventArgs e)
    {
        // Setup Styles, Annotations, etc here
    }

    public class GestureSettingsExampleSettingsPage : ContentPage, IQueryAttributable
    {
        private GestureSettings gestureSettings;
        private StackLayout mainContent;

        public GestureSettingsExampleSettingsPage()
        {
            Shell.SetPresentationMode(this, PresentationMode.ModalAnimated);

            Padding = new Thickness(0, 64, 0, 0);

            mainContent = new StackLayout
            {
                Spacing = 0,
            };
            Content =  new StackLayout
            {
                Spacing = 0,
                Children = {
                    new Grid
                    {
                        Children =
                        {
                            new Label
                            {
                                Text = "Gesture Configs",
                                FontSize = 26,
                                Margin = 16,
                                HorizontalTextAlignment = TextAlignment.Center,
                            },
                            new Label
                            {
                                Text = "Apply",
                                Margin = 16,
                                VerticalOptions = LayoutOptions.Center,
                                HorizontalOptions = LayoutOptions.End,
                                GestureRecognizers =
                                {
                                    new TapGestureRecognizer
                                    {
                                        Command = new Command(Apply),
                                    },
                                }
                            }
                        }
                    },
                    new BoxView
                    {
                        Margin = 16,
                    },
                    new ScrollView
                    {
                        HorizontalScrollBarVisibility = ScrollBarVisibility.Never,
                        Content = new Grid
                        {
                            Children =
                            {
                                mainContent,
                            },
                        },
                    }
                },
            };
        }

        private View CreateSwitchRow(string title, bool defaultValue)
        {
            var @switch = new Switch
            {
                IsToggled = defaultValue,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.End,
            };
            
            @switch.Toggled += (s, e) =>
            {
                ToggleEnabled((s as Switch).Parent, e);
            };
            return new Grid
            {
                Padding = new Thickness(16, 8),
                Children = {
                            new Label
                            {
                                Text = title,
                                FontSize = 16,
                                VerticalOptions = LayoutOptions.Center,
                            },
                            @switch,
                        }
            };
        }

        private void ToggleEnabled(object sender, ToggledEventArgs e)
        {
            var grid = (Grid)sender;
            var label = (Label)grid.Children[0];

            switch (label.Text) {
                case nameof(DoubleTapToZoomInEnabled):
                    DoubleTapToZoomInEnabled = e.Value;
                    break;
                case nameof(DoubleTouchToZoomOutEnabled):
                    DoubleTouchToZoomOutEnabled = e.Value;
                    break;
                case nameof(PinchScrollEnabled):
                    PinchScrollEnabled = e.Value;
                    break;
                case nameof(PinchToZoomDecelerationEnabled):
                    PinchToZoomDecelerationEnabled = e.Value;
                    break;
                case nameof(PinchToZoomEnabled):
                    PinchToZoomEnabled = e.Value;
                    break;
                case nameof(PitchEnabled):
                    PitchEnabled = e.Value;
                    break;
                case nameof(QuickZoomEnabled):
                    QuickZoomEnabled = e.Value;
                    break;
                case nameof(RotateDecelerationEnabled):
                    RotateDecelerationEnabled = e.Value;
                    break;
                case nameof(RotateEnabled):
                    RotateEnabled = e.Value;
                    break;
                case nameof(ScrollDecelerationEnabled):
                    ScrollDecelerationEnabled = e.Value;
                    break;
                case nameof(ScrollEnabled):
                    ScrollEnabled = e.Value;
                    break;
                case nameof(SimultaneousRotateAndPinchToZoomEnabled):
                    SimultaneousRotateAndPinchToZoomEnabled = e.Value;
                    break;
            }
        }

        private async void Apply()
        {
            await Shell.Current.GoToAsync("..", new Dictionary<string, object>()
            {
                { "data", gestureSettings },
            });
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            gestureSettings = (GestureSettings)query["data"];

            mainContent.Children.Add(CreateSwitchRow(nameof(DoubleTapToZoomInEnabled), DoubleTapToZoomInEnabled));
            mainContent.Children.Add(CreateSwitchRow(nameof(DoubleTouchToZoomOutEnabled), DoubleTouchToZoomOutEnabled));
            mainContent.Children.Add(CreateSwitchRow(nameof(IncreasePinchToZoomThresholdWhenRotating), IncreasePinchToZoomThresholdWhenRotating));
            mainContent.Children.Add(CreateSwitchRow(nameof(IncreaseRotateThresholdWhenPinchingToZoom), IncreaseRotateThresholdWhenPinchingToZoom));
            mainContent.Children.Add(CreateSwitchRow(nameof(PinchScrollEnabled), PinchScrollEnabled));
            mainContent.Children.Add(CreateSwitchRow(nameof(PinchToZoomDecelerationEnabled), PinchToZoomDecelerationEnabled));
            mainContent.Children.Add(CreateSwitchRow(nameof(PinchToZoomEnabled), PinchToZoomEnabled));
            mainContent.Children.Add(CreateSwitchRow(nameof(PitchEnabled), PitchEnabled));
            mainContent.Children.Add(CreateSwitchRow(nameof(QuickZoomEnabled), QuickZoomEnabled));
            mainContent.Children.Add(CreateSwitchRow(nameof(RotateDecelerationEnabled), RotateDecelerationEnabled));
            mainContent.Children.Add(CreateSwitchRow(nameof(RotateEnabled), RotateEnabled));
            mainContent.Children.Add(CreateSwitchRow(nameof(ScrollDecelerationEnabled), ScrollDecelerationEnabled));
            mainContent.Children.Add(CreateSwitchRow(nameof(ScrollEnabled), ScrollEnabled));
            mainContent.Children.Add(CreateSwitchRow(nameof(SimultaneousRotateAndPinchToZoomEnabled), SimultaneousRotateAndPinchToZoomEnabled));

            mainContent.Children.Add(CreateFocalPointView());
        }

        private IView CreateFocalPointView()
        {
            var row = new StackLayout
            {
                
            };
            row.Add(new Label
            {
                Text = "FocalPoint",                
            });
            row.Add(new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    new Label
                    {
                        Text = "X="
                    },
                    new Slider
                    {
                        Minimum = 0,
                        Maximum = DeviceDisplay.Current.MainDisplayInfo.Width,
                    },
                }
            });
            row.Add(new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    new Label
                    {
                        Text = "Y="
                    },
                    new Slider
                    {
                        Minimum = 0,
                        Maximum = DeviceDisplay.Current.MainDisplayInfo.Height,
                    },
                }
            });

            return row;
        }

        /// <summary>
        /// Whether the rotate gesture is enabled.
        /// </summary>
        public bool RotateEnabled
        {
            get => gestureSettings.RotateEnabled;
            set => gestureSettings = gestureSettings with
            {
                RotateEnabled = value,
            };
        }
        /// <summary>
        /// Whether the pinch to zoom gesture is enabled.
        ///
        /// iOS: PinchZoomEnabled
        /// </summary>
        public bool PinchToZoomEnabled
        {
            get => gestureSettings.PinchToZoomEnabled;
            set => gestureSettings = gestureSettings with
            {
                PinchToZoomEnabled = value,
            };
        }
        /// <summary>
        /// Whether the single-touch scroll gesture is enabled.
        /// </summary>
        public bool ScrollEnabled
        {
            get => gestureSettings.ScrollEnabled;
            set => gestureSettings = gestureSettings with
            {
                ScrollEnabled = value,
            };
        }
        /// <summary>
        /// Whether rotation is enabled for the pinch to zoom gesture.
        ///
        /// iOS: SimultaneousRotateAndPinchZoomEnabled
        /// </summary>
        public bool SimultaneousRotateAndPinchToZoomEnabled
        {
            get => gestureSettings.SimultaneousRotateAndPinchToZoomEnabled;
            set => gestureSettings = gestureSettings with
            {
                SimultaneousRotateAndPinchToZoomEnabled = value,
            };
        }
        /// <summary>
        /// Whether the pitch gesture is enabled.
        /// </summary>
        public bool PitchEnabled
        {
            get => gestureSettings.PitchEnabled;
            set => gestureSettings = gestureSettings with
            {
                PitchEnabled = value,
            };
        }
        /// <summary>
        /// Configures the directions in which the map is allowed to move during a scroll gesture.
        ///
        /// iOS: PanMode
        /// </summary>
        public PanMode ScrollMode
        {
            get => gestureSettings.ScrollMode;
            set => gestureSettings = gestureSettings with
            {
                ScrollMode = value,
            };
        }
        /// <summary>
        /// Whether double tapping the map with one touch results in a zoom-in animation.
        /// </summary>
        public bool DoubleTapToZoomInEnabled
        {
            get => gestureSettings.DoubleTapToZoomInEnabled;
            set => gestureSettings = gestureSettings with
            {
                DoubleTapToZoomInEnabled = value,
            };
        }
        /// <summary>
        /// Whether single tapping the map with two touches results in a zoom-out animation.
        /// </summary>
        public bool DoubleTouchToZoomOutEnabled
        {
            get => gestureSettings.DoubleTouchToZoomOutEnabled;
            set => gestureSettings = gestureSettings with
            {
                DoubleTouchToZoomOutEnabled = value,
            };
        }
        /// <summary>
        /// Whether the quick zoom gesture is enabled.
        /// </summary>
        public bool QuickZoomEnabled
        {
            get => gestureSettings.QuickZoomEnabled;
            set => gestureSettings = gestureSettings with
            {
                QuickZoomEnabled = value,
            };
        }
        /// <summary>
        /// By default, gestures rotate and zoom around the center of the gesture. Set this property to
        /// rotate and zoom around a fixed point instead.
        /// </summary>
        public ScreenPosition? FocalPoint
        {
            get => gestureSettings.FocalPoint;
            set => gestureSettings = gestureSettings with
            {
                FocalPoint = value,
            };
        }
        /// <summary>
        /// Android only.
        /// Whether a deceleration animation following a pinch-to-zoom gesture is enabled. True by default.
        /// </summary>
        public bool PinchToZoomDecelerationEnabled
        {
            get => gestureSettings.PinchToZoomDecelerationEnabled;
            set => gestureSettings = gestureSettings with
            {
                PinchToZoomDecelerationEnabled = value,
            };
        }
        /// <summary>
        /// Android only.
        /// Whether a deceleration animation following a rotate gesture is enabled. True by default.
        /// </summary>
        public bool RotateDecelerationEnabled
        {
            get => gestureSettings.RotateDecelerationEnabled;
            set => gestureSettings = gestureSettings with
            {
                RotateDecelerationEnabled = value,
            };
        }
        /// <summary>
        /// Android only.
        /// Whether a deceleration animation following a scroll gesture is enabled. True by default.
        /// </summary>
        public bool ScrollDecelerationEnabled
        {
            get => gestureSettings.ScrollDecelerationEnabled;
            set => gestureSettings = gestureSettings with
            {
                ScrollDecelerationEnabled = value,
            };
        }
        /// <summary>
        /// Android only.
        /// 
        /// Whether rotate threshold increases when pinching to zoom. true by default.
        /// </summary>
        public bool IncreaseRotateThresholdWhenPinchingToZoom
        {
            get => gestureSettings.IncreaseRotateThresholdWhenPinchingToZoom;
            set => gestureSettings = gestureSettings with
            {
                IncreaseRotateThresholdWhenPinchingToZoom = value,
            };
        }
        /// <summary>
        /// Android only.
        /// Whether pinch to zoom threshold increases when rotating. true by default.
        /// </summary>
        public bool IncreasePinchToZoomThresholdWhenRotating
        {
            get => gestureSettings.IncreasePinchToZoomThresholdWhenRotating;
            set => gestureSettings = gestureSettings with
            {
                IncreasePinchToZoomThresholdWhenRotating = value,
            };
        }
        /// <summary>
        /// The amount by which the zoom level increases or decreases during a double-tap-to-zoom-in or
        /// double-touch-to-zoom-out gesture. 1.0 by default. Must be positive.
        /// </summary>
        public float ZoomAnimationAmount
        {
            get => gestureSettings.ZoomAnimationAmount;
            set => gestureSettings = gestureSettings with
            {
                ZoomAnimationAmount = value,
            };
        }
        /// <summary>
        /// Whether pan is enabled for the pinch gesture.
        ///
        /// iOS: PanEnabled
        /// </summary>
        public bool PinchScrollEnabled
        {
            get => gestureSettings.PinchScrollEnabled;
            set => gestureSettings = gestureSettings with
            {
                PinchScrollEnabled = value,
            };
        }
    }
}