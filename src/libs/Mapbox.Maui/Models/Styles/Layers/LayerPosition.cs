namespace MapboxMaui.Styles;

public struct LayerPosition
{
    public object Parameter { get; }
    public LayerPositionEnum Enum { get; }

    private LayerPosition(object parameter, LayerPositionEnum @enum)
    {
        Parameter = parameter;
        Enum = @enum;
    }

    public static LayerPosition Unknown() => new LayerPosition(null, LayerPositionEnum.Unknown);
    public static LayerPosition Above(string layerId) => new LayerPosition(layerId, LayerPositionEnum.Above);
    public static LayerPosition Below(string layerId) => new LayerPosition(layerId, LayerPositionEnum.Above);
    public static LayerPosition At(uint index) => new LayerPosition(index, LayerPositionEnum.At);
}

public enum LayerPositionEnum
{
    Unknown,
    Above,
    Below,
    At,
}