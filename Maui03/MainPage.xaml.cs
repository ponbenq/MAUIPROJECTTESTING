namespace Maui03;
using Services;
using SQLite;

public partial class MainPage : ContentPage
{
	String name = "user1";

	private int num = 1;
	Service_init db;
	public MainPage()
	{
		InitializeComponent();
		db = new Service_init();
		
	}



	private async void OnCounterClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("NEWPAGE");
	}

    async void AddDataToDatabase_Clicked(System.Object sender, System.EventArgs e)
    {
		if (String.IsNullOrEmpty(name))
		{
			await DisplayAlert("Name required!", "Please enter a name for adding to datbase", "OK");
			return;
		}
		await db.AddColumn(name);
    }

	//not really sure..
    void retrieveData_Clicked(System.Object sender, System.EventArgs e)
    {
		 DisplayAlert("Data Retrieve", db.GetItem().ToString(), "OK") ;
    }
}


