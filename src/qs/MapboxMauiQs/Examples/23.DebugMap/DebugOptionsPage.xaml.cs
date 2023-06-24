namespace MapboxMauiQs;

public partial class DebugOptionsPage : ContentPage, IQueryAttributable, IExamplePage
{
    private DebugOptionItem[] options;

    public DebugOptionsPage()
	{
		InitializeComponent();
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        options = (DebugOptionItem[])query["options"];
        optionList.ItemsSource = options;
    }

    void Switch_Toggled(System.Object sender, Microsoft.Maui.Controls.ToggledEventArgs e)
    {
        var option = (DebugOptionItem)((VisualElement)sender).BindingContext;
        option.Enabled = e.Value;
    }

    void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync("..", new Dictionary<string, object>
        {
            {  "options", options }
        }); ;
    }
}

public class DebugOptionItem
{
    public string Title { get; set; }
    public DebugOption DebugOption { get; set; }
    public bool Enabled { get; set; }

    public DebugOptionItem Clone()
    {
        return (DebugOptionItem)MemberwiseClone();
    }
}