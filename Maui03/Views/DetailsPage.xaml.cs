namespace Maui03.Views;
using Maui03.ViewModels;
public partial class DetailsPage : ContentPage
{
	public DetailsPage(DetailsPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}
