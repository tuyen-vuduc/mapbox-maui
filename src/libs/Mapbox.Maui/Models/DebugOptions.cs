namespace MapboxMaui;

public enum DebugOption
{
    /**
     * Edges of tile boundaries are shown as thick, red lines to help diagnose
     * tile clipping issues.
     */
    TileBorders,
    /** Each tile shows its tile coordinate (x/y/z) in the upper-left corner. */
    ParseStatus,
    /** Each tile shows a timestamp indicating when it was loaded. */
    Timestamps,
    /**
     * Edges of glyphs and symbols are shown as faint, green lines to help
     * diagnose collision and label placement issues.
     */
    Collision,
    /**
     * Each drawing operation is replaced by a translucent fill. Overlapping
     * drawing operations appear more prominent to help diagnose overdrawing.
     */
    Overdraw,
    /** The stencil buffer is shown instead of the color buffer. */
    StencilClip,
    /** The depth buffer is shown instead of the color buffer. */
    DepthBuffer,
    /**
     * Visualize residency of tiles in the render cache. Tile boundaries of cached tiles
     * are rendered with green, tiles waiting for an update with yellow and tiles not in the cache
     * with red.
     */
    RenderCache,
    /** Show 3D model bounding boxes. */
    ModelBounds,
    /** Show a wireframe for terrain. */
    TerrainWireframe
}

