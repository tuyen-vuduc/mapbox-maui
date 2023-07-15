namespace MapboxMauiQs;

public partial class MainPage : ContentPage
{
    public MainPage(IEnumerable<IExampleInfo> examples)
    {
        InitializeComponent();

        var items = examples
            .GroupBy(x => x.Group)
            .ToList();

        BindableLayout.SetItemsSource(exampleList, items);
    }

    // Examples that show how to get started with Mapbox, such as creating a basic map view or setting a style once.
    static List<ExampleItemModel> gettingStartedExamples = new List<ExampleItemModel> {
        new ExampleItemModel {Title =  "Display a map view",
                Subtitle = @"
Create and display a map that uses the default Mapbox streets style. This example also shows how to update the starting camera for a map.
                ",
                PageRoute = "BasicMapExample", },
        new ExampleItemModel {Title =  "Use a custom map style",
                Subtitle = "Set and use a custom map style URL.",
                PageRoute = "CustomStyleURLExample", },
        new ExampleItemModel {Title =  "Display a map view using storyboard",
                Subtitle = "Create and display a map using a storyboard.",
                PageRoute = "StoryboardMapViewExample", },
        new ExampleItemModel {Title =  "Debug Map",
                Subtitle = "This example shows how the map looks with different debug options",
                PageRoute = "DebugMapExample", },
    };

    // Examples that show how to use 3D terrain or fill extrusions.
    static List<ExampleItemModel>threeDExamples = new List<ExampleItemModel> {
        new ExampleItemModel {Title =  "Show 3D terrain",
                Subtitle = "Show realistic elevation by enabling terrain.",
                PageRoute = "TerrainExample", },
        new ExampleItemModel {Title =  "SceneKit rendering on map",
                Subtitle = "Use custom layer to render SceneKit model over terrain.",
                PageRoute = "SceneKitExample", },
        new ExampleItemModel {Title =  "Display 3D buildings",
                Subtitle = "Extrude the building layer in the Mapbox Light style using FillExtrusionLayer and set up the light position.",
                PageRoute = "BuildingExtrusionsExample", },
        new ExampleItemModel {Title =  "Add a sky layer",
                Subtitle = "Add a customizable sky layer to simulate natural lighting with a Terrain layer.",
                PageRoute = "SkyLayerExample", }
    };

    // Examples that focus on annotations.
    static List<ExampleItemModel>annotationExamples = new List<ExampleItemModel> {
        new ExampleItemModel {Title =  "Add a polygon annotation",
                Subtitle = "Add a polygon annotation to the map.",
                PageRoute = "PolygonAnnotationExample", },
        new ExampleItemModel {Title =  "Add a marker symbol",
                Subtitle = "Add a blue teardrop-shaped marker image to a style and display it on the map using a SymbolLayer.",
                PageRoute = "AddOneMarkerSymbolExample", },
        new ExampleItemModel {Title =  "Add Circle Annotations",
                Subtitle = "Show circle annotations on a map",
                PageRoute = "CircleAnnotationExample", },
        new ExampleItemModel {Title =  "Add Cluster Symbol Annotations",
                Subtitle = "Show fire hydrants in Washington DC area in a cluster using a symbol layer.",
                PageRoute = "SymbolClusteringExample", },
        new ExampleItemModel {Title =  "Add Cluster Point Annotations",
                Subtitle = "Show fire hydrants in Washington DC area in a cluster using point annotations.",
                PageRoute = "PointAnnotationClusteringExample", },
        new ExampleItemModel {Title =  "Add markers to a map",
                Subtitle = "Add markers that use different icons.",
                PageRoute = "AddMarkersSymbolExample", },
        new ExampleItemModel {Title =  "Add Point Annotations",
                Subtitle = "Show point annotations on a map",
                PageRoute = "CustomPointAnnotationExample", },
        new ExampleItemModel {Title =  "Add Polylines Annotations",
                Subtitle = "Show polyline annotations on a map.",
                PageRoute = "LineAnnotationExample", },
        new ExampleItemModel {Title =  "Animate Marker Position",
                Subtitle = "Animate updates to a marker/annotation's position.",
                PageRoute = "AnimatedMarkerExample", },
        new ExampleItemModel {Title =  "Change icon size",
                Subtitle = "Change icon size with Symbol layer.",
                PageRoute = "IconSizeChangeExample", },
        new ExampleItemModel {Title =  "Draw multiple geometries",
                Subtitle = "Draw multiple shapes on a map.",
                PageRoute = "MultipleGeometriesExample", },
        new ExampleItemModel {Title =  "Use a map & annotations with SwiftUI",
                Subtitle = "Use the UIViewRepresentable protocol to wrap a MapView in a SwiftUI view.",
                PageRoute = "SwiftUIExample", },
        new ExampleItemModel {Title =  "View annotation with point annotation",
                Subtitle = "Add view annotation to a point annotation",
                PageRoute = "ViewAnnotationWithPointAnnotationExample", },
        new ExampleItemModel {Title =  "View annotations: basic example",
                Subtitle = "Add view annotation on a map with a click.",
                PageRoute = "ViewAnnotationBasicExample", },
        new ExampleItemModel {Title =  "View annotations: advanced example",
                Subtitle = "Add view annotations anchored to a symbol layer feature.",
                PageRoute = "ViewAnnotationMarkerExample", },
        new ExampleItemModel {Title =  "View annotations: Frame list of annotations",
                Subtitle = "Animates to camera framing the list of selected view annotations.",
                PageRoute = "FrameViewAnnotationsExample", },
        new ExampleItemModel {Title =  "View annotations: animation",
                Subtitle = "Animate a view annotation along a route",
                PageRoute = "ViewAnnotationAnimationExample", }
    };

    // Examples that focus on setting, animating, or otherwise changing the map's camera and viewport.
    static List<ExampleItemModel>cameraExamples = new List<ExampleItemModel> {
            new ExampleItemModel {Title =  "Use custom camera animations",
                Subtitle = @"
Animate the map camera to a new position using camera animators. Individual camera properties such as zoom, bearing, and center coordinate can be animated independently.
                ",
                PageRoute = "CameraAnimatorsExample", },
        new ExampleItemModel {Title =  "Use camera animations",
                Subtitle = "Use ease(to:) to animate updates to the camera's position.",
                PageRoute = "CameraAnimationExample", },
        new ExampleItemModel {Title =  "Viewport",
                Subtitle = "Viewport camera showcase",
                PageRoute = "ViewportExample", },
        new ExampleItemModel {Title =  "Advanced Viewport Gestures",
                Subtitle = "Viewport configured to allow gestures",
                PageRoute = "AdvancedViewportGesturesExample", },
        new ExampleItemModel {Title =  "Filter symbols based on pitch and distance",
                Subtitle = "Use pitch and distance-from-center expressions in the filter field of a symbol layer to remove large size POI labels in the far distance at high pitch",
                PageRoute = "PitchAndDistanceExample", },
    };

    // Miscellaneous examples
    public static List<ExampleItemModel>labExamples = new List<ExampleItemModel> {
        new ExampleItemModel {Title =  "Resizable image",
                Subtitle = "Add a resizable image with cap insets to a style.",
                PageRoute = "ResizableImageExample", },
        new ExampleItemModel {Title =  "Geojson performance",
                Subtitle = "Display long route as large geojson",
                PageRoute = "LargeGeoJSONPerformanceExample", }
    };

    // Examples that focus on displaying the user's location.
    public static List<ExampleItemModel>locationExamples = new List<ExampleItemModel> {
        new ExampleItemModel {Title =  "Display the user's location",
                Subtitle = "Display the user's location on a map with the default user location puck.",
                PageRoute = "TrackingModeExample", },
        new ExampleItemModel {Title =  "Basic pulsing circle",
                Subtitle = "Display sonar-like animation radiating from the location puck.",
                PageRoute = "BasicLocationPulsingExample", },
        new ExampleItemModel {Title =  "Customize the location puck",
                Subtitle = "Customized the location puck on the map",
                PageRoute = "Custom2DPuckExample", },
        new ExampleItemModel {Title =  "Use a 3D model to show the user's location",
                Subtitle = "A 3D model is used to represent the user's location.",
                PageRoute = "Custom3DPuckExample", },
        new ExampleItemModel {Title =  "Add a custom location provider",
                Subtitle = "Display the location puck at a custom location.",
                PageRoute = "CustomLocationProviderExample", },
        new ExampleItemModel {Title =  "Simulate navigation",
                Subtitle = "Simulate a driving trip from LA to San Francisco along a pre-defined route",
                PageRoute = "NavigationSimulatorExample", },
    };

    // Examples that highlight using the Offline APIs.

    static List<ExampleItemModel>offlineExamples = new List<ExampleItemModel> {
        new ExampleItemModel {Title =  "Use OfflineManager and TileStore to download a region",
                Subtitle = @"
Shows how to use OfflineManager and TileStore to download regions for offline use.

By default, users may download up to 750 tile packs for offline use across all regions. If the limit is hit, any loadRegion call will fail until excess regions are deleted. This limit is subject to change. Please contact Mapbox if you require a higher limit. Additional charges may apply.
                ",
                PageRoute = "OfflineManagerExample", }
    };

    // Examples that show how to use the map's snapshotter.
    static List<ExampleItemModel>snapshotExamples = new List<ExampleItemModel> {
    new ExampleItemModel {Title =  "Create a static map snapshot",
            Subtitle = @"
Create a static, non-interactive image of a map style with specified camera position. The resulting snapshot is provided as a `UIImage`.
The map on top is interactive. The bottom one is a static snapshot.
                ",
            PageRoute = "SnapshotterExample", },
    new ExampleItemModel {Title =  "Draw on a static snapshot with Core Graphics",
            Subtitle = @"
Use the overlayHandler parameter to draw on top of a snapshot using Core Graphhics APIs.
                ",
            PageRoute = "SnapshotterCoreGraphicsExample", },

};

    // Examples that highlight how to set or modify the map's style and its contents.
    static List<ExampleItemModel>styleExamples = new List<ExampleItemModel> {
        new ExampleItemModel {Title =  "Display multiple icon images in a symbol layer",
                Subtitle = @"
            Add point data and several images to a style and use the switchCase and get expressions to choose which image to display at each point in a SymbolLayer based on a data property.
            ",
                PageRoute = "DataDrivenSymbolsExample", },
        new ExampleItemModel {Title =  "Change the position of a layer",
                Subtitle = "Insert a specific layer above or below other layers.",
                PageRoute = "LayerPositionExample", },
        new ExampleItemModel {Title =  "Cluster points within a layer",
                Subtitle = "Create a circle layer from a geoJSON source and cluster the points from that source. The clusters will update as the map's camera changes.",
                PageRoute = "PointClusteringExample", },
        new ExampleItemModel {Title =  "Animate a line layer",
                Subtitle = "Animate updates to a line layer from a geoJSON source.",
                PageRoute = "AnimateGeoJSONLineExample", },
        new ExampleItemModel {Title =  "Animate a style layer",
                Subtitle = "Animate the position of a style layer by updating its source data.",
                PageRoute = "AnimateLayerExample", },
        new ExampleItemModel {Title =  "Add external vector tiles",
                Subtitle = "Add vector map tiles from an external source, using the {z}/{x}/{y} URL scheme.",
                PageRoute = "ExternalVectorSourceExample", },
        new ExampleItemModel {Title =  "Use interpolate colors between zoom level",
                Subtitle = @"
                    Use an interpolate expression to style the background layer color depending on zoom level.
                ",
                PageRoute = "ColorExpressionExample", },
        new ExampleItemModel {Title =  "Add a custom rendered layer",
                Subtitle = "Add a custom rendered Metal layer.",
                PageRoute = "CustomLayerExample", },
        new ExampleItemModel {Title =  "Add a line with a color gradient",
                Subtitle = "Load a polyline to a style using GeoJSONSource, display it on a map using LineLayer, and style it with a rainbow color gradient.",
                PageRoute = "LineGradientExample", },
        new ExampleItemModel {Title =  "Change the map's style",
                Subtitle = "Switch between local and default Mapbox styles for the same map view.",
                PageRoute = "SwitchStylesExample", },
        new ExampleItemModel {Title =  "Change the map's language",
                Subtitle = "Switch between supported languages for Symbol Layers",
                PageRoute = "LocalizationExample", },
        new ExampleItemModel {Title =  "Add animated weather data",
                Subtitle = "Load a raster image to a style using ImageSource and display it on a map as animated weather data using RasterLayer.",
                PageRoute = "AnimateImageLayerExample", },
        new ExampleItemModel {Title =  "Add a raster tile source",
                Subtitle = "Add third-party raster tiles to a map.",
                PageRoute = "RasterTileSourceExample", },
        new ExampleItemModel {Title =  "Show and hide layers",
                Subtitle = "Allow the user to toggle the visibility of a CircleLayer and LineLayer on a map.",
                PageRoute = "ShowHideLayerExample", },
        new ExampleItemModel {Title =  "Add live data",
                Subtitle = "Update feature coordinates from a geoJSON source in real time.",
                PageRoute = "LiveDataExample", },
        new ExampleItemModel {Title =  "Join data to vector geometry",
                Subtitle = "Join local JSON data with vector tile geometries.",
                PageRoute = "DataJoinExample", },
        new ExampleItemModel {Title =  "Use a distance expression", Subtitle = "Use a distance style expression to show features within a specific radius.", PageRoute = "DistanceExpressionExample", }
    };

    // Examples that show use cases related to user interaction with the map.
    static List<ExampleItemModel>userInteractionExamples = new List<ExampleItemModel> {
        new ExampleItemModel {Title =  "Find features at a point",
                Subtitle = "Query the map for rendered features belonging to a specific layer.",
                PageRoute = "FeaturesAtPointExample", },
        new ExampleItemModel {Title =  "Use Feature State",
                Subtitle = "Manipulate map styling with feature states and expressions.",
                PageRoute = "FeatureStateExample", },
        new ExampleItemModel {Title =  "Restrict the map's coordinate bounds",
                Subtitle = "Prevent the map from panning outside the specified coordinate bounds.",
                PageRoute = "RestrictCoordinateBoundsExample", },
        new ExampleItemModel {Title =  "Add an interactive clustered layer",
                Subtitle = "Display an alert controller after selecting a feature.",
                PageRoute = "SymbolClusteringExample", },
    };

    // Examples that show map accessibility features
    static List<ExampleItemModel>accessibilityExamples = new List<ExampleItemModel> {
        new ExampleItemModel {Title =  "Access map features using VoiceOver",
                Subtitle = "Use VoiceOver to highlight annotations and hear their associated features.",
                PageRoute = "VoiceOverAccessibilityExample", },
    };

    // Examples that display maps using the globe projection
    static List<ExampleItemModel>globeAndAtmosphere = new List<ExampleItemModel> {
        new ExampleItemModel {Title =  "Display a globe",
                Subtitle = "Create a map using the globe projection.",
                PageRoute = "GlobeExample", },
        new ExampleItemModel {Title =  "Fly-to camera animation",
                Subtitle = "Smoothly interpolate between locations with the fly-to animation.",
                PageRoute = "GlobeFlyToExample", },
        new ExampleItemModel {Title =  "Create a rotating globe",
                Subtitle = "Display your map as an interactive, rotating globe.",
                PageRoute = "SpinningGlobeExample", },
        new ExampleItemModel {Title =  "Visualize data as a heatmap",
                Subtitle = "Display your heatmap using the globe projection.",
                PageRoute = "HeatmapLayerGlobeExample", }
    };

    static Dictionary<string, List<ExampleItemModel>> all = new Dictionary<string, List<ExampleItemModel>> {
        { "Getting started", gettingStartedExamples },
        { "3D and Fill Extrusions", threeDExamples },
        {"Annotations", annotationExamples },
        { "Camera", cameraExamples},
        {"Lab", labExamples },
        {"Location", locationExamples },
        {"Offline", offlineExamples },
        {"Snapshot", snapshotExamples},
        {"Style", styleExamples},
        {"User Interaction", userInteractionExamples},
        {"Accessibility", accessibilityExamples},
        { "Globe and Atmosphere", globeAndAtmosphere},
    };

    void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        var example = (sender as VisualElement).BindingContext as IExampleInfo;

        if (example == null) return;

        Shell.Current.GoToAsync(example.PageRoute, new Dictionary<string, object>
        {
            { nameof(example), example }
        }).ContinueWith(t => {

        });
    }
}


