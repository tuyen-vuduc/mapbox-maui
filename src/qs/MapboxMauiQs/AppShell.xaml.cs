namespace MapboxMauiQs;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(GestureSettingsExample.GestureSettingsExampleSettingsPage), typeof(GestureSettingsExample.GestureSettingsExampleSettingsPage));
    }
}

