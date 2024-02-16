namespace MapboxMauiQs;

class ShowHideLayerExampleInfo : IExampleInfo
{
    public string Group => "User interaction";
    public string Title => "Show and hide a layer";
    public string Subtitle => "Allow the user to toggle the visibility of a CircleLayer and LineLayer on a map.";
    public string PageRoute => typeof(ShowHideLayerExample).FullName;
}