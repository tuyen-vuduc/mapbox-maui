using MapboxMapsObjC;
using MapboxMaui.Locations;
using ObjCRuntime;

namespace MapboxMaui;
using PlatformView = MapViewContainer;

partial class MapboxViewHandler : ILocationComponentPlugin
{
    private TMBLocationManager Plugin
    {
        get
        {
            var mapView = PlatformView.MapView;
            if (mapView is null) return null;

            return mapView.Location();
        }
    }

    public bool Enabled
    {
        get => Plugin.Options.PuckType is not null;
        set
        {
            var options = Plugin.Options;
            if (!value)
            {
                options.PuckType = null;
            }
            else
            {
                options.PuckType = TMBPuck2DConfiguration.MakeDefaultWithShowBearing(false);
            }
            Plugin.Options = options;
        }
    }

    public bool PulsingEnabled
    {
        get
        {
            if (Plugin.Options.PuckType is null) return false;

            try
            {
                var puck2D = Runtime.GetNSObject<TMBPuck2DConfiguration>(
                    Plugin.Options.PuckType.Handle
                );

                return puck2D.Pulsing != null;
            }
            catch
            {
                // When the native value isn't a valid TMBPuck2DConfiguration,
                // Runtime.GetNSObject will throw an error
                return false;
            }
        }
        set
        {
            if (Plugin.Options.PuckType is null) return;

            try
            {
                var options = Plugin.Options;
                var puck2D = Runtime.GetNSObject<TMBPuck2DConfiguration>(
                    options.PuckType.Handle
                );

                if (value is false)
                {
                    // TODO Set this property to NULL
                    // or just set the inner property, IsEnabled, to false?
                    puck2D.Pulsing = null;
                }
                else
                {
                    puck2D.Pulsing = puck2D.Pulsing ?? TMBPuck2DConfigurationPulsing.Default();
                }
                options.PuckType = puck2D;
                Plugin.Options = options;
            }
            catch
            {
                // When the native value isn't a valid TMBPuck2DConfiguration,
                // Runtime.GetNSObject will throw an error
                return;
            }
        }
    }
    public bool ShowAccuracyRing
    {
        get
        {
            if (Plugin.Options.PuckType is null) return false;

            try
            {
                var puck2D = Runtime.GetNSObject<TMBPuck2DConfiguration>(
                    Plugin.Options.PuckType.Handle
                );

                return puck2D.ShowsAccuracyRing == true;
            }
            catch
            {
                // When the native value isn't a valid TMBPuck2DConfiguration,
                // Runtime.GetNSObject will throw an error
                return false;
            }
        }
        set
        {
            if (Plugin.Options.PuckType is null) return;

            try
            {
                var options = Plugin.Options;
                var puck2D = Runtime.GetNSObject<TMBPuck2DConfiguration>(
                    options.PuckType.Handle
                );
                puck2D.ShowsAccuracyRing = value;

                options.PuckType = puck2D;
                Plugin.Options = options;
            }
            catch
            {
                // When the native value isn't a valid TMBPuck2DConfiguration,
                // Runtime.GetNSObject will throw an error
                return;
            }
        }
    }
    public float PulsingMaxRadius
    {
        get
        {
            if (Plugin.Options.PuckType is null) return float.NegativeInfinity;

            try
            {
                var puck2D = Runtime.GetNSObject<TMBPuck2DConfiguration>(
                    Plugin.Options.PuckType.Handle
                );

                return puck2D.Pulsing?.Radius.Constant?.FloatValue
                    ?? float.NegativeInfinity;
            }
            catch
            {
                // When the native value isn't a valid TMBPuck2DConfiguration,
                // Runtime.GetNSObject will throw an error
                return float.NegativeInfinity;
            }
        }
        set
        {
            if (Plugin.Options.PuckType is null) return;

            try
            {
                var options = Plugin.Options;
                var puck2D = Runtime.GetNSObject<TMBPuck2DConfiguration>(
                    options.PuckType.Handle
                );

                if (puck2D.Pulsing is null)
                {
                    return;
                }

                puck2D.Pulsing.Radius = value <= 0
                    ? TMBPuck2DConfigurationPulsingRadius.Accuracy
                    : TMBPuck2DConfigurationPulsingRadius.FromConstant(value);
                options.PuckType = puck2D;
                Plugin.Options = options;
            }
            catch
            {
                // When the native value isn't a valid TMBPuck2DConfiguration,
                // Runtime.GetNSObject will throw an error
                return;
            }
        }
    }
}
