namespace Maui03.Views;
using Maui03.ViewModels;
public partial class DisplayText : ContentPage
{
	public DisplayText()
	{
		InitializeComponent();
		BindingContext = new DisplayTextViewModel();
	}
}
