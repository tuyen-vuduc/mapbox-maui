namespace MapboxMauiQs;

public interface IExampleInfo
{
    string Group { get; }
    int Index { get; }
    string Title { get; }
    string Subtitle { get; }
    string PageRoute { get; }
}

public interface IExamplePage
{
}