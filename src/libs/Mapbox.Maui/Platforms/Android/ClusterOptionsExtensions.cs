using MapboxMaui.Annotations;
using Color = Android.Graphics.Color;
using Microsoft.Maui.Platform;

namespace MapboxMaui;

public static class ClusterOptionsExtensions
{
    public static new Com.Mapbox.Maps.Plugin.Annotation.ClusterOptions ToPlatform(this ClusterOptions clusterOptions)
        => clusterOptions == null
            ? null
            : new Com.Mapbox.Maps.Plugin.Annotation.ClusterOptions(
                true,
                (long)clusterOptions.ClusterRadius,
                clusterOptions.CircleRadius?.Expression?.ToPlatformValue(),
                clusterOptions.CircleRadius?.GetConstant(18.0) ?? 18.0,
                clusterOptions.TextColor?.Expression?.ToPlatformValue(),
                clusterOptions.TextColor?.GetConstant(Color.White.ToColor())?.ToPlatform() ?? Color.White,
                clusterOptions.TextSize?.Expression?.ToPlatformValue(),
                clusterOptions.TextSize?.GetConstant(12.0) ?? 12.0,
                clusterOptions.TextField?.Expression?.ToPlatformValue(),
                (long)clusterOptions.ClusterMaxZoom,
                new List<Kotlin.Pair> {
                    new Kotlin.Pair(new Java.Lang.Integer(250), new Java.Lang.Integer(Color.LightPink)),
                    new Kotlin.Pair(new Java.Lang.Integer(150), new Java.Lang.Integer(Color.Orange)),
                    new Kotlin.Pair(new Java.Lang.Integer(100), new Java.Lang.Integer(Color.Red)),
                    new Kotlin.Pair(new Java.Lang.Integer(50), new Java.Lang.Integer(Color.Cyan)),
                    new Kotlin.Pair(new Java.Lang.Integer(10), new Java.Lang.Integer(Color.Green)),
                    new Kotlin.Pair(new Java.Lang.Integer(0), new Java.Lang.Integer(Color.Yellow)),
                },
                new Dictionary<string, Java.Lang.Object>(
                    clusterOptions.ClusterProperties?
                        .Select(
                            x => new KeyValuePair<string, Java.Lang.Object>(
                                x.Key,
                                x.Value.Wrap()
                            )
                        )
                    )
                );
}

