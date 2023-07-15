namespace MapboxMaui;
#if IOS
using MapboxMapsObjC;
#endif

/// Layer rendering types
public readonly struct LayerType : INamedString
{
    /// A filled polygon with an optional stroked border.
    public static readonly LayerType Fill = new ("fill");

    /// A stroked line.
    public static readonly LayerType Line = new ("line");

    /// An icon or a text label.
    public static readonly LayerType Symbol = new ("symbol");

    /// A filled circle.
    public static readonly LayerType Circle = new ("circle");

    /// A heatmap.
    public static readonly LayerType Heatmap = new ("heatmap");

    /// An extruded (3D) polygon.
    public static readonly LayerType FillExtrusion = new ("fill-extrusion");

    /// Raster map textures such as satellite imagery.
    public static readonly LayerType Raster = new ("raster");

    /// Client-side hillshading visualization based on DEM data.
    /// Currently, the implementation only supports Mapbox Terrain RGB and Mapzen Terrarium tiles.
    public static readonly LayerType Hillshade = new ("hillshade");

    /// The background color or pattern of the map.
    public static readonly LayerType Background = new ("background");

    /// Layer representing the location indicator
    public static readonly LayerType LocationIndicator = new ("location-indicator");

    /// Layer representing the sky
    public static readonly LayerType Sky = new ("sky");

    // @available(*, deprecated, message: "Unsupported layer type")
    public static readonly LayerType Model = new ("model");


    public string Value { get; }

    private LayerType(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(LayerType value) => value.Value;
    public static implicit operator LayerType(string value) => new (value);
}
public static partial class LayerTypeExtensions {}
#if IOS    
partial class LayerTypeExtensions
{
    public static MapboxMapsObjC.TMBLayerType ToPlatform(this LayerType value)
    {
        return value.Value switch 
        {
            "fill" => MapboxMapsObjC.TMBLayerType.Fill,
            "line" => MapboxMapsObjC.TMBLayerType.Line,
            "symbol" => MapboxMapsObjC.TMBLayerType.Symbol,
            "circle" => MapboxMapsObjC.TMBLayerType.Circle,
            "heatmap" => MapboxMapsObjC.TMBLayerType.Heatmap,
            "fill-extrusion" => MapboxMapsObjC.TMBLayerType.FillExtrusion,
            "raster" => MapboxMapsObjC.TMBLayerType.Raster,
            "hillshade" => MapboxMapsObjC.TMBLayerType.Hillshade,
            "background" => MapboxMapsObjC.TMBLayerType.Background,
            "location-indicator" => MapboxMapsObjC.TMBLayerType.LocationIndicator,
            "sky" => MapboxMapsObjC.TMBLayerType.Sky,
            "model" => MapboxMapsObjC.TMBLayerType.Model
        };
    }

    public static LayerType ToPlatform(this MapboxMapsObjC.TMBLayerType value)
    {
        return value switch 
        {
            MapboxMapsObjC.TMBLayerType.Fill => "fill",
            MapboxMapsObjC.TMBLayerType.Line => "line",
            MapboxMapsObjC.TMBLayerType.Symbol => "symbol",
            MapboxMapsObjC.TMBLayerType.Circle => "circle",
            MapboxMapsObjC.TMBLayerType.Heatmap => "heatmap",
            MapboxMapsObjC.TMBLayerType.FillExtrusion => "fill-extrusion",
            MapboxMapsObjC.TMBLayerType.Raster => "raster",
            MapboxMapsObjC.TMBLayerType.Hillshade => "hillshade",
            MapboxMapsObjC.TMBLayerType.Background => "background",
            MapboxMapsObjC.TMBLayerType.LocationIndicator => "location-indicator",
            MapboxMapsObjC.TMBLayerType.Sky => "sky",
            MapboxMapsObjC.TMBLayerType.Model => "model"
        };
    }

    public static LayerType LayerTypeX(this Foundation.NSNumber value)
    {
        return value.LayerType().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this LayerType value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif




    /// The associated Swift struct type
