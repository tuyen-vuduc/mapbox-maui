namespace MapboxMauiQs;

class MovingCarExampleInfo : IExampleInfo
{
    public string Group => "Lab";
    public string Title => "Display a car moving on map";
    public string Subtitle => "Demo how to show a car moving on the map";
    public string PageRoute => typeof(MovingCarExample).FullName;
    public int Index => 71;
}