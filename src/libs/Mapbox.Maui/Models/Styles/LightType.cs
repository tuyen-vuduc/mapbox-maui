namespace MapboxMaui;


/// Supported light types
public readonly struct LightType : INamedString
{
    public string Value { get; }

    private LightType(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(LightType value) => value.Value;
    public static implicit operator LightType(string value) => new (value);

    public static readonly LightType Flat = new ("flat");

    /// An indirect type of light.
    public static readonly LightType Ambient = new ("ambient");

    /// A type of light that has a direction.
    public static readonly LightType Directional = new ("directional");

}