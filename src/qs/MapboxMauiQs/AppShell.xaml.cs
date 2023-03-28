namespace MapboxMauiQs;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(BasicMapExample), typeof(BasicMapExample));
        Routing.RegisterRoute(nameof(CustomStyleURLExample), typeof(CustomStyleURLExample));
    }
}

