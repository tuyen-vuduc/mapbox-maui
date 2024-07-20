using System.Text;
using Math = System.Math;

namespace MapboxMaui;

/**
 * Polyline utils class contains method that can decode/encode a polyline, simplify a line, and
 * more.
 *
 * @since 1.0.0
 */
public static class PolylineUtils
{
    public const int PRECISION_6 = 6;
    public const int PRECISION_5 = 5;
    /**
     * Decodes an encoded path string into a sequence of {@link Point}.
     *
     * @param encodedPath a String representing an encoded path string
     * @param precision   OSRMv4 uses 6, OSRMv5 and Google uses 5
     * @return list of {@link Point} making up the line
     * @see <a href="https://github.com/mapbox/polyline/blob/master/src/polyline.js">Part of algorithm came from this source</a>
     * @see <a href="https://github.com/googlemaps/android-maps-utils/blob/master/library/src/com/google/maps/android/PolyUtil.java">Part of algorithm came from this source.</a>
     * @since 1.0.0
     */
    public static List<IPosition> Decode(string encodedPath, int precision)
    {
        int len = encodedPath.Length;

        // OSRM uses precision=6, the default Polyline spec divides by 1E5, capping at precision=5
        double factor = Math.Pow(10, precision);

        // For speed we preallocate to an upper bound on the final length, then
        // truncate the array before returning.
        List<IPosition> path = new();
        int index = 0;
        int lat = 0;
        int lng = 0;

        while (index < len)
        {
            int result = 1;
            int shift = 0;
            int temp;
            do
            {
                temp = encodedPath[index++] - 63 - 1;
                result += temp << shift;
                shift += 5;
            }
            while (temp >= 0x1f);
            lat += (result & 1) != 0 ? ~(result >> 1) : (result >> 1);

            result = 1;
            shift = 0;
            do
            {
                temp = encodedPath[index++] - 63 - 1;
                result += temp << shift;
                shift += 5;
            }
            while (temp >= 0x1f);
            lng += (result & 1) != 0 ? ~(result >> 1) : (result >> 1);

            path.Add(
                (lat / factor).ToPosition(lng / factor)
            );
        }

        return path;
    }

    /**
     * Encodes a sequence of Points into an encoded path string.
     *
     * @param path      list of {@link Point}s making up the line
     * @param precision OSRMv4 uses 6, OSRMv5 and Google uses 5
     * @return a String representing a path string
     * @since 1.0.0
     */
  public static string Encode(IList<IPosition> path, int precision)
    {
        long lastLat = 0;
        long lastLng = 0;

        StringBuilder result = new();

        // OSRM uses precision=6, the default Polyline spec divides by 1E5, capping at precision=5
        double factor = Math.Pow(10, precision);

        foreach (IPosition position in path)
        {
            long lat = (long)Math.Round(position.Latitude * factor);
            long lng = (long)Math.Round(position.Longitude * factor);

            long varLat = lat - lastLat;
            long varLng = lng - lastLng;

            Encode(varLat, result);
            Encode(varLng, result);

            lastLat = lat;
            lastLng = lng;
        }
        return result.ToString();
    }

    private static void Encode(long variable, StringBuilder result)
    {
        variable = variable < 0 ? ~(variable << 1) : variable << 1;
        while (variable >= 0x20)
        {
            result.Append((char)((0x20 | (variable & 0x1f)) + 63));
            variable >>= 5;
        }
        result.Append((char)(variable + 63));
    }

    public static double Longitude(this GPoint point)
        => point.Coordinates.Longitude;
    public static double Latitude(this GPoint point)
        => point.Coordinates.Latitude;
    public static GPoint ToPoint(this IPosition position)
        => new (position);
    public static GPoint ToPoint(this double lat, double lng)
        => new (lat.ToPosition(lng));
    public static IPosition ToPosition(this double lat, double lng)
        => new MapPosition(lat, lng);
}
