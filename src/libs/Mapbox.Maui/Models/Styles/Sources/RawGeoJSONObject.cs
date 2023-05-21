using GeoJSON.Text;
using GeoJSON.Text.CoordinateReferenceSystem;

namespace MapboxMaui.Styles;

public class RawGeoJSONObject : IGeoJSONObject
{
    public RawGeoJSONObject(string data)
    {
        Data = data;
    }

    /// <summary>
    /// Inline GeoJSON or a URL to GeoJSON file
    /// </summary>
    public string Data { get; }

    public GeoJSONObjectType Type => throw new NotImplementedException();

    public ICRSObject CRS => throw new NotImplementedException();

    public double[] BoundingBoxes
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }
}

