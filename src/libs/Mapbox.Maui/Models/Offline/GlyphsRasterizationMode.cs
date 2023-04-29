namespace MapboxMaui.Offline;

public enum GlyphsRasterizationMode
{
    /** No glyphs are rasterized locally. All glyphs are loaded from the server. */
    NoGlyphsRasterizedLocally,
    /** Ideographs are rasterized locally, and they are not loaded from the server. */
    IdeographsRasterizedLocally,
    /** All glyphs are rasterized locally. No glyphs are loaded from the server. */
    AllGlyphsRasterizedLocally
}

