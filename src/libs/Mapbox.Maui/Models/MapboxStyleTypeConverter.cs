using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Mapbox.Maui;

public class MapboxStyleTypeConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
        return sourceType == typeof(string) || sourceType == typeof(MapboxBuiltInStyle);
    }

    public override bool CanConvertTo(ITypeDescriptorContext context, [NotNullWhen(true)] Type destinationType)
    {
        return destinationType == typeof(string);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        return value is MapboxStyle mapboxStyle ? (string)mapboxStyle : null;
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is MapboxBuiltInStyle builtInStyle) return (MapboxStyle)builtInStyle;

        if (value is string builtStyleOrUri)
        {
            if(Enum.TryParse<MapboxBuiltInStyle>(builtStyleOrUri, out var builtInStyle1)
                && builtInStyle1 != MapboxBuiltInStyle.None)
            {
                return (MapboxStyle)builtInStyle1;
            }

            return (MapboxStyle)builtStyleOrUri;
        }

        return (MapboxStyle)MapboxBuiltInStyle.None;
    }
}
