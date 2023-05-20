namespace Maui03.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui03.Models;
using Maui03.Views;
[QueryProperty("Item","Item")]
public partial class DetailsPageViewModel : ObservableObject
{
	public DetailsPageViewModel()
	{
	}
	[ObservableProperty]
	Items item;

}
