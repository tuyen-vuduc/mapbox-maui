namespace MapboxMauiQs;

internal static class GroupIndices
{
    private static readonly string[] groupNames = [
        "Lab",
        "Get Started",
        "Annotations",
        "3D and Fill Extrusions",
        "Camera",
        "Offline",
        "User interaction",
        "Viewport",
    ];


    public static int GroupIndex(this IExampleInfo exampleInfo)
    {
        var index = Array.IndexOf(groupNames, exampleInfo.Group);

        return index != -1 ? index : 99;
    }
}
