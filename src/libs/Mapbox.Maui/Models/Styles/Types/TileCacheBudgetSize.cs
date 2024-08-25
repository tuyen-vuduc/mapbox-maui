namespace MapboxMaui;

public record TileCacheBudgetSize 
{
    public int? Tiles { get; }
    public int? Megabytes { get; }

    private TileCacheBudgetSize(int? tiles, int? megabytes) {
        Tiles = tiles;
        Megabytes = megabytes;
    }

    public static TileCacheBudgetSize FromTiles(int tiles)
        => new (tiles, null);
    public static TileCacheBudgetSize FromMegaBytes(int megabytes)
        => new (null, megabytes);
}