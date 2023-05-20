namespace Maui03;
using Views;
public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("NEWPAGE", typeof(newPage));
		Routing.RegisterRoute("PAGETWO", typeof(Page2));
		Routing.RegisterRoute("VIEWPAGE", typeof(ViewDataPage));
		Routing.RegisterRoute("PRODUCT", typeof(ProductPageView));
		//nameof(DetailsPage = "DetailsPage"
		Routing.RegisterRoute("DetailsPage", typeof(DetailsPage));
		Routing.RegisterRoute(nameof(PurchasePage), typeof(PurchasePage));
		Routing.RegisterRoute(nameof(DisplayText), typeof(DisplayText));
	}
}

