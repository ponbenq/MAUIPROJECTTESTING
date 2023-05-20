namespace Maui03.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui03.Models;
[QueryProperty("Items","orders")]
public partial class PurchasePageViewModel : ObservableObject
{
	public PurchasePageViewModel()
	{
	}
	[ObservableProperty]
	Items orders;
}
