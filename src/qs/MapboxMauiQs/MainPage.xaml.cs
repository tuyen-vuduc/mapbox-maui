namespace MapboxMauiQs;

public partial class MainPage : ContentPage
{
    public MainPage(IEnumerable<IExampleInfo> examples)
    {
        InitializeComponent();

        var items = examples
            .OrderBy(x => x.GroupIndex)
            .ThenBy(x => x.Index)
            .GroupBy(x => x.Group)
            .ToList();

        BindableLayout.SetItemsSource(exampleList, items);
    }

    void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        var example = (sender as VisualElement).BindingContext as IExampleInfo;

        if (example == null) return;

        Shell.Current.GoToAsync(example.PageRoute, new Dictionary<string, object>
        {
            { nameof(example), example }
        }).ContinueWith(t => {
            if (t.IsFaulted)
            {
                System.Diagnostics.Debug.WriteLine(t.Exception.StackTrace);
            }
        });
    }
}


