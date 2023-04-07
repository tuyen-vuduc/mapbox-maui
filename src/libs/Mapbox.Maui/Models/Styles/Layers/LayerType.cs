namespace Mapbox.Maui.Styles;

public struct LayerType : IStringEnum
{
    public string Value { get; }

    private LayerType(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator string(LayerType encoding) => encoding.Value;

    /// A filled polygon with an optional stroked border.
    public static readonly LayerType fill = new LayerType("fill");

    /// A stroked line.
    public static readonly LayerType line = new LayerType("line");

    /// An icon or a text label.
    public static readonly LayerType symbol = new LayerType("symbol");

    /// A filled circle.
    public static readonly LayerType circle = new LayerType("circle");

    /// A heatmap.
    public static readonly LayerType heatmap = new LayerType("heatmap");

    /// An extruded (3D) polygon.
    public static readonly LayerType fillExtrusion = new LayerType("fill-extrusion");

    /// Raster map textures such as satellite imagery.
    public static readonly LayerType raster = new LayerType("raster");

    /// Client-side hillshading visualization based on DEM data.
    /// Currently, the implementation only supports Mapbox Terrain RGB and Mapzen Terrarium tiles.
    public static readonly LayerType hillshade = new LayerType("hillshade");

    /// The background color or pattern of the map.
    public static readonly LayerType background = new LayerType("background");

    /// Layer representing the location indicator
    public static readonly LayerType locationIndicator = new LayerType("location-indicator");

    /// Layer representing the sky
    public static readonly LayerType sky = new LayerType("sky");
}

