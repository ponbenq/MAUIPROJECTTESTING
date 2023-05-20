namespace Maui03.Views;
using Maui03.ViewModels;

public partial class PurchasePage : ContentPage
{
	public PurchasePage(PurchasePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}
