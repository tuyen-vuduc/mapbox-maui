# Mapbox for MAUI

A dedicated library and starting sample for integrating Mapbox into your MAUI application.

# Installation

```
Install-Package Mapbox.Maui --version 10.11.1
```

## Setup

1/ MAPBOX_DOWNLOADS_TOKEN

All Mapbox libraries required an access token to download them for use. 
Please follow [the guide from Mapbox](https://docs.mapbox.com/android/maps/guides/install/) and go the dashboard of your Mapbox account and grab one.

a/ Android
On Android, we will leverage the gradle way of downloading Mapbox native libraries, please set `MAPBOX_DOWNLOADS_TOKEN` property and put it in `~/.gradle/gradle.properties` as below example

```
MAPBOX_DOWNLOADS_TOKEN=YOUR_MAPBOX_DOWNLOADS_TOKEN
```

b/ iOS
oOn iOS, we will need to edit iOS's CSPROJ file to have `MAPBOX_DOWNLOADS_TOKEN` property as below example.

```
<Project ...>
    ...

	<PropertyGroup>
		<MAPBOX_DOWNLOADS_TOKEN>YOUR_MAPBOX_DOWNLOADS_TOKEN</MAPBOX_DOWNLOADS_TOKEN>
	</PropertyGroup>
    ...
</Project>
```

2/ Android addtional setup
As Mapbox has its own private Gradle repository, we need to add these lines to Android's CSPROJ file.

```
<Project ...>
    ...

	<ItemGroup>
		<GradleRepository Include="https://api.mapbox.com/downloads/v2/releases/maven">
			<Repository>
			maven {
				url 'https://api.mapbox.com/downloads/v2/releases/maven'
				authentication {
					basic(BasicAuthentication)
				}
				credentials {
					// Do not change the username below.
					// This should always be `mapbox` (not your username).
					username = "mapbox"
					// Use the secret token you stored in gradle.properties as the password
					password = MAPBOX_DOWNLOADS_TOKEN
				}
			}
			</Repository>
		</GradleRepository>
	</ItemGroup>

    ...
</Project>
```

2/ YOUR_ACCESS_TOKEN

To display Mapbox Map in your app, you will need another access token which can be easily grabbed by following [the guide from Mapbox](https://docs.mapbox.com/help/getting-started/access-tokens/).

You can set it conventionally in `strings.xml` for Android or in `info.plist` for iOS. Otherwise, you can also set the value in code as the guide from Mapbox documetation.

a/ Android's `strings.xml`
```
<string name="mapbox_access_token">YOUR_MAPBOX_ACCESS_TOKEN</string>
```

b/ iOS's `info.plist`
```
<key>MBXAccessToken</key>
<string>YOUR_MAPBOX_ACCESS_TOKEN</string>
```

# Ported Examples

| # | Example | Ported |
| - | - | - |
| 1 | [AddMarkersSymbolExample](./mapboxqs/AddMarkersSymbolExample.m) |  |
| 2 | [AddOneMarkerSymbolExample](./mapboxqs/AddOneMarkerSymbolExample.m) |  |
| 3 | [AdvancedViewportGesturesExample](./mapboxqs/AdvancedViewportGesturesExample.m) |  |
| 4 | [AnimateGeoJSONLineExample](./mapboxqs/AnimateGeoJSONLineExample.m) |  |
| 5 | [AnimateImageLayerExample](./mapboxqs/AnimateImageLayerExample.m) |  |
| 6 | [AnimateLayerExample](./mapboxqs/AnimateLayerExample.m) |  |
| 7 | [AnimatedMarkerExample](./mapboxqs/AnimatedMarkerExample.m) |  |
| 8 | [BasicLocationPulsingExample](./mapboxqs/BasicLocationPulsingExample.m) |  |
| 9 | [BasicMapExample](./mapboxqs/BasicMapExample.m) | OK |
| 10 | [BuildingExtrusionsExample](./mapboxqs/BuildingExtrusionsExample.m) | OK |
| 11 | [CameraAnimationExample](./mapboxqs/CameraAnimationExample.m) |  |
| 12 | [CameraAnimatorsExample](./mapboxqs/CameraAnimatorsExample.m) |  |
| 13 | [CircleAnnotationExample](./mapboxqs/CircleAnnotationExample.m) | x |
| 14 | [ColorExpressionExample](./mapboxqs/ColorExpressionExample.m) |  |
| 15 | [Custom2DPuckExample](./mapboxqs/Custom2DPuckExample.m) |  |
| 16 | [Custom3DPuckExample](./mapboxqs/Custom3DPuckExample.m) |  |
| 17 | [CustomLayerExample](./mapboxqs/CustomLayerExample.m) |  |
| 18 | [CustomLocationProviderExample](./mapboxqs/CustomLocationProviderExample.m) |  |
| 19 | [CustomPointAnnotationExample](./mapboxqs/CustomPointAnnotationExample.m) |  |
| 20 | [CustomStyleURLExample](./mapboxqs/CustomStyleURLExample.m) | OK |
| 21 | [DataDrivenSymbolsExample](./mapboxqs/DataDrivenSymbolsExample.m) |  |
| 22 | [DataJoinExample](./mapboxqs/DataJoinExample.m) |  |
| 23 | [DebugMapExample](./mapboxqs/DebugMapExample.m) | OK |
| 24 | [DistanceExpressionExample](./mapboxqs/DistanceExpressionExample.m) |  |
| 25 | [ExternalVectorSourceExample](./mapboxqs/ExternalVectorSourceExample.m) |  |
| 26 | [FeatureStateExample](./mapboxqs/FeatureStateExample.m) |  |
| 27 | [FeaturesAtPointExample](./mapboxqs/FeaturesAtPointExample.m) |  |
| 28 | [FrameViewAnnotationsExample](./mapboxqs/FrameViewAnnotationsExample.m) |  |
| 29 | [GlobeExample](./mapboxqs/GlobeExample.m) |  |
| 30 | [GlobeFlyToExample](./mapboxqs/GlobeFlyToExample.m) |  |
| 31 | [HeatmapLayerGlobeExample](./mapboxqs/HeatmapLayerGlobeExample.m) |  |
| 32 | [IconSizeChangeExample](./mapboxqs/IconSizeChangeExample.m) |  |
| 33 | [LargeGeoJSONPerformanceExample](./mapboxqs/LargeGeoJSONPerformanceExample.m) |  |
| 34 | [LayerPositionExample](./mapboxqs/LayerPositionExample.m) |  |
| 35 | [LineAnnotationExample](./mapboxqs/LineAnnotationExample.m) |  |
| 36 | [LineGradientExample](./mapboxqs/LineGradientExample.m) |  |
| 37 | [LiveDataExample](./mapboxqs/LiveDataExample.m) |  |
| 38 | [LocalizationExample](./mapboxqs/LocalizationExample.m) |  |
| 39 | [MultipleGeometriesExample](./mapboxqs/MultipleGeometriesExample.m) |  |
| 40 | [NavigationSimulatorExample](./mapboxqs/NavigationSimulatorExample.m) |  |
| 41 | [OfflineManagerExample](./mapboxqs/OfflineManagerExample.m) | x |
| 42 | [OfflineRegionManagerExample](./mapboxqs/OfflineRegionManagerExample.m) |  |
| 43 | [PitchAndDistanceExample](./mapboxqs/PitchAndDistanceExample.m) |  |
| 44 | [PointAnnotationClusteringExample](./mapboxqs/PointAnnotationClusteringExample.m) |  |
| 45 | [PointClusteringExample](./mapboxqs/PointClusteringExample.m) |  |
| 46 | [PolygonAnnotationExample](./mapboxqs/PolygonAnnotationExample.m) | OK |
| 47 | [RasterTileSourceExample](./mapboxqs/RasterTileSourceExample.m) |  |
| 48 | [ResizableImageExample](./mapboxqs/ResizableImageExample.m) |  |
| 49 | [RestrictCoordinateBoundsExample](./mapboxqs/RestrictCoordinateBoundsExample.m) |  |
| 50 | [SceneKitExample](./mapboxqs/SceneKitExample.m) | N/A |
| 51 | [ShowHideLayerExample](./mapboxqs/ShowHideLayerExample.m) |  |
| 52 | [SkyLayerExample](./mapboxqs/SkyLayerExample.m) | OK |
| 53 | [SnapshotterCoreGraphicsExample](./mapboxqs/SnapshotterCoreGraphicsExample.m) |  |
| 54 | [SnapshotterExample](./mapboxqs/SnapshotterExample.m) |  |
| 55 | [SpinningGlobeExample](./mapboxqs/SpinningGlobeExample.m) |  |
| 56 | [StoryboardMapViewExample](./mapboxqs/StoryboardMapViewExample.m) | N/A |
| 57 | [SwitchStylesExample](./mapboxqs/SwitchStylesExample.m) |  |
| 58 | [SymbolClusteringExample](./mapboxqs/SymbolClusteringExample.m) |  |
| 59 | [TerrainExample](./mapboxqs/TerrainExample.m) | OK |
| 60 | [TrackingModeExample](./mapboxqs/TrackingModeExample.m) |  |
| 61 | [ViewAnnotationAnimationExample](./mapboxqs/ViewAnnotationAnimationExample.m) |  |
| 62 | [ViewAnnotationBasicExample](./mapboxqs/ViewAnnotationBasicExample.m) |  |
| 63 | [ViewAnnotationMarkerExample](./mapboxqs/ViewAnnotationMarkerExample.m) |  |
| 64 | [ViewAnnotationWithPointAnnotationExample](./mapboxqs/ViewAnnotationWithPointAnnotationExample.m) |  |
| 65 | [ViewportExample](./mapboxqs/ViewportExample.m) |  |
| 66 | [VoiceOverAccessibilityExample](./mapboxqs/VoiceOverAccessibilityExample.m) |  |

# LICENSE
This library is release under The BSD 3-Clause License. You are freely to use and make changes. 
However, this license doesn't override [the license from Mapbox](https://www.mapbox.com/legal/tos).