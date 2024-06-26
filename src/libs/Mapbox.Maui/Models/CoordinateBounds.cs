namespace MapboxMaui;

public record CoordinateBounds (
    IPosition Southwest,
    IPosition Northeast,
    bool InfiniteBounds = false);