namespace MapboxMaui.Offline;

public enum NetworkRestriction : long
{
    None = 0,
    DisallowExpensive = 1,
    DisallowAll = 255
}