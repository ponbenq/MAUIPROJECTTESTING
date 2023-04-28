namespace Maui03;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("NEWPAGE", typeof(newPage));
		Routing.RegisterRoute("PAGETWO", typeof(Page2));
	}
}

