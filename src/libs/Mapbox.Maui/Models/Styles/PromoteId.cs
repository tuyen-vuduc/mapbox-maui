namespace MapboxMaui.Styles;

public record PromoteId
{
    public string StringValue { get; }
    public IDictionary<string, string> KeyValues { get; }

    public PromoteId(string stringValue)
    {
        StringValue = stringValue;
    }

    public PromoteId(IDictionary<string, string> keyValues)
    {
        KeyValues = keyValues;
    }
}