using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace MapboxMaui;

public class MapboxStyleTypeConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
        return sourceType == typeof(string);
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
        if (value is string builtStyleOrUri)
        {
            return (MapboxStyle)builtStyleOrUri;
        }

        return null;
    }
}
