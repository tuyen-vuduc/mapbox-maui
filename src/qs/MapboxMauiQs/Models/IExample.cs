namespace MapboxMauiQs;

public interface IExampleInfo
{
    int GroupIndex { get; }
    string Group { get; }
    int Index { get; }
    string Title { get; }
    string Subtitle { get; }
    string PageRoute { get; }
}

public interface IExamplePage
{
}