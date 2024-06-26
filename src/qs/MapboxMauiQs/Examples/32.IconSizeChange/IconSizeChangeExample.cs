namespace MapboxMauiQs;

public class IconSizeChangeExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;
    bool markerSelected;

    public IconSizeChangeExample()
	{
        iOSPage.SetUseSafeArea(this, false);
		Content = map = new MapboxView();

        map.MapReady += Map_MapReady;
        map.MapLoaded += Map_MapLoaded;
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        Title = info?.Title;
    }

    private void Map_MapReady(object sender, EventArgs e)
    {
        var centerLocation = new MapPosition(42.354950, -71.065634);
        var cameraOptions = new CameraOptions
        {
            Center = centerLocation,
            Zoom = 11,
        };

        map.CameraOptions = cameraOptions;
        map.MapboxStyle = MapboxStyle.DARK;
    }

    private void Map_MapLoaded(object sender, EventArgs e)
    {
        var markerFeatures = new [] {
            new MapPosition(latitude: 42.354950, longitude: -71.065634), // Boston Common Park
            new MapPosition(latitude: 42.346645, longitude: -71.097293), // Fenway Park
            new MapPosition(latitude: 42.363725, longitude: -71.053694) // The Paul Revere House
        }
        .Select(
            x => new Feature(
                new GeoJSON.Text.Geometry.Point(x)
            )
        )
        .ToList();

        // Create a GeoJSON data source for markers
        var featureCollection = new FeatureCollection(markerFeatures);
        var markerSource = new GeoJSONSource(Constants.markerSourceId);
        markerSource.Data = new RawGeoJSONObject(
            JsonSerializer.Serialize(featureCollection)
        );

        // Add marker image to the map
        var image = new ResolvedImage(Constants.blueMarkerImageId, "blue_marker_view");
        map.Images = new[] { image };

        // Create a symbol layer for markers
        var markerLayer = new SymbolLayer(id: Constants.markerLayerId);
        markerLayer.Source = Constants.markerSourceId;
        markerLayer.IconImage = image;
        markerLayer.IconAllowOverlap = true;
        // Adding an offset so that the bottom of the blue icon gets fixed to the coordinate, rather than the
        // middle of the icon being fixed to the coordinate point.
        markerLayer.IconOffset = new double[] { 0, -9 };

        // Create a GeoJSON source for the selected marker
        var selectedMarkerSource = new GeoJSONSource(Constants.selectedMarkerSourceId)
        {
            Data = new GeoJSON.Text.Geometry.Point(),
        };

        // TODO Check NPE
        map.Sources = new[] { markerSource, selectedMarkerSource };

        // Create a symbol layer for the selected marker
        var selectedMarkerLayer = new SymbolLayer(id: Constants.selectedMarkerLayerId);
        selectedMarkerLayer.Source = Constants.selectedMarkerSourceId;
        selectedMarkerLayer.IconImage = image;
        selectedMarkerLayer.IconAllowOverlap = true;
        // Adding an offset so that the bottom of the blue icon gets fixed to the coordinate, rather than the
        // middle of the icon being fixed to the coordinate point.
        selectedMarkerLayer.IconOffset = new double[] { 0, -9 };

        map.Layers = new[] { markerLayer, selectedMarkerLayer };

        // add a tap gesture recognizer to the map
        map.MapTapped += Map_MapTapped;
    }

    private async void Map_MapTapped(object sender, MapTappedEventArgs e)
    {
        var features = await map.QueryManager.QueryRenderedFeaturesWith(e.Position.ScreenPosition, new MapboxMaui.Query.RenderedQueryOptions
        {
            LayerIds = new[] { Constants.markerLayerId }
        });

        if (!features.Any())
        {
            UpdateMarker(false);
            return;
        }

        // TODO Check the original example
        var geometry = features.First().QueriedFeature;
        var geojson = JsonSerializer.Serialize(geometry.Feature.Geometry);
        var geoJSONSource = new GeoJSONSource(Constants.selectedMarkerSourceId)
        {
            Data = new RawGeoJSONObject(geojson),
        };
        map.Sources = new[] { geoJSONSource };

        UpdateMarker(!markerSelected);
    }

    private void UpdateMarker(bool selected)
    {
        var symbolLayer = new SymbolLayer(Constants.selectedMarkerLayerId)
        {
            IconSize = selected ? 2 : 1
        };
        markerSelected = selected;

        map.Layers = new[] { symbolLayer };
    }

    private class Constants
    {
        public const string blueMarkerImageId = "blue-marker";
        public const string markerLayerId = "marker-layer";
        public const string markerSourceId = "marker-source";
        public const string selectedMarkerLayerId = "selected-marker-layer";
        public const string selectedMarkerSourceId = "selected-marker";
    }
}