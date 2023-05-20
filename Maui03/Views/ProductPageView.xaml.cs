namespace Maui03.Views;
using ViewModels;

public partial class ProductPageView : ContentPage
{
	
	public ProductPageView()
	{
		InitializeComponent();
		BindingContext = new ProductPage();
	}
}
