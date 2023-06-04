using MapboxMapsObjC;

namespace MapboxMaui;

public static class EnumExtensions
{
    public static TMBVisibility ToPlatform(this Visibility xvalue)
    {
        return new TMBVisibility(xvalue);
    }
    public static TMBLineCap ToPlatform(this LineCap xvalue)
    {
        return new TMBLineCap(xvalue);
    }
    public static TMBLineJoin ToPlatform(this LineJoin xvalue)
    {
        return new TMBLineJoin(xvalue);
    }
    public static TMBIconAnchor ToPlatform(this IconAnchor xvalue)
    {
        return new TMBIconAnchor(xvalue);
    }
    public static TMBIconPitchAlignment ToPlatform(this IconPitchAlignment xvalue)
    {
        return new TMBIconPitchAlignment(xvalue);
    }
    public static TMBIconRotationAlignment ToPlatform(this IconRotationAlignment xvalue)
    {
        return new TMBIconRotationAlignment(xvalue);
    }
    public static TMBIconTextFit ToPlatform(this IconTextFit xvalue)
    {
        return new TMBIconTextFit(xvalue);
    }
    public static TMBSymbolPlacement ToPlatform(this SymbolPlacement xvalue)
    {
        return new TMBSymbolPlacement(xvalue);
    }
    public static TMBSymbolZOrder ToPlatform(this SymbolZOrder xvalue)
    {
        return new TMBSymbolZOrder(xvalue);
    }
    public static TMBTextAnchor ToPlatform(this TextAnchor xvalue)
    {
        return new TMBTextAnchor(xvalue);
    }
    public static TMBTextJustify ToPlatform(this TextJustify xvalue)
    {
        return new TMBTextJustify(xvalue);
    }
    public static TMBTextPitchAlignment ToPlatform(this TextPitchAlignment xvalue)
    {
        return new TMBTextPitchAlignment(xvalue);
    }
    public static TMBTextRotationAlignment ToPlatform(this TextRotationAlignment xvalue)
    {
        return new TMBTextRotationAlignment(xvalue);
    }
    public static TMBTextTransform ToPlatform(this TextTransform xvalue)
    {
        return new TMBTextTransform(xvalue);
    }
    public static TMBFillTranslateAnchor ToPlatform(this FillTranslateAnchor xvalue)
    {
        return new TMBFillTranslateAnchor(xvalue);
    }
    public static TMBLineTranslateAnchor ToPlatform(this LineTranslateAnchor xvalue)
    {
        return new TMBLineTranslateAnchor(xvalue);
    }
    public static TMBIconTranslateAnchor ToPlatform(this IconTranslateAnchor xvalue)
    {
        return new TMBIconTranslateAnchor(xvalue);
    }
    public static TMBTextTranslateAnchor ToPlatform(this TextTranslateAnchor xvalue)
    {
        return new TMBTextTranslateAnchor(xvalue);
    }
    public static TMBCirclePitchAlignment ToPlatform(this CirclePitchAlignment xvalue)
    {
        return new TMBCirclePitchAlignment(xvalue);
    }
    public static TMBCirclePitchScale ToPlatform(this CirclePitchScale xvalue)
    {
        return new TMBCirclePitchScale(xvalue);
    }
    public static TMBCircleTranslateAnchor ToPlatform(this CircleTranslateAnchor xvalue)
    {
        return new TMBCircleTranslateAnchor(xvalue);
    }
    public static TMBFillExtrusionTranslateAnchor ToPlatform(this FillExtrusionTranslateAnchor xvalue)
    {
        return new TMBFillExtrusionTranslateAnchor(xvalue);
    }
    public static TMBRasterResampling ToPlatform(this RasterResampling xvalue)
    {
        return new TMBRasterResampling(xvalue);
    }
    public static TMBHillshadeIlluminationAnchor ToPlatform(this HillshadeIlluminationAnchor xvalue)
    {
        return new TMBHillshadeIlluminationAnchor(xvalue);
    }
    public static TMBSkyType ToPlatform(this SkyType xvalue)
    {
        return new TMBSkyType(xvalue);
    }
    public static TMBAnchor ToPlatform(this Anchor xvalue)
    {
        return new TMBAnchor(xvalue);
    }
    public static TMBStyleProjectionName ToPlatform(this StyleProjectionName xvalue)
    {
        return new TMBStyleProjectionName(xvalue);
    }
    public static TMBTextWritingMode ToPlatform(this TextWritingMode xvalue)
    {
        return new TMBTextWritingMode(xvalue);
    }
}

