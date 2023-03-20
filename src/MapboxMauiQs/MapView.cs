using System;
using Microsoft.Maui.Handlers;

namespace MapboxMauiQs;

public class MapView : View
{
    public static readonly BindableProperty CenterProperty = BindableProperty.Create(
       nameof(Center),
       typeof(Point?),
       typeof(MapView),
       default(Point?)
    );
    public Point? Center
    {
        get => (Point?)GetValue(CenterProperty);
        set => SetValue(CenterProperty, value);
    }
}

//public partial class MapViewHandler : ViewHandler
//{

//}

