namespace MapboxMaui.Styles;

public record ResolvedImage
{
    public string Id { get; }

    public string Name { get; }
    public byte[] Bytes { get; }
    public bool Sdf { get; init; }
    public bool IsTemplate { get; init; }

    public ResolvedImage(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public ResolvedImage(string id, byte[] bytes)
    {
        Id = id;
        Bytes = bytes;
    }
}