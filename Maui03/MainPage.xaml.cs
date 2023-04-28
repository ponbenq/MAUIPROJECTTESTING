namespace Maui03;
using Services;
using SQLite;

public partial class MainPage : ContentPage
{
	String name = "user1";

	
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
    async void retrieveData_Clicked(System.Object sender, System.EventArgs e)
    {
		//DisplayAlert("Data Retrieve", db.GetItem().ToString(), "OK") ;
		await GetData();
		
    }

	async Task GetData()
	{
		var task = db.GetItem();

		try
		{
			var constantsList = await task;

			foreach(Constants constant in constantsList)
			{
				int id = constant.Id;
				string userName = constant.userName;

				await DisplayAlert("Data Retrieve", $"id : {id}, userName: {userName}", "OK");
			}
		}catch(Exception ex)
		{
			Console.WriteLine($"{ex.Message}");
		}
	}

    async void Page2_Clicked(System.Object sender, System.EventArgs e)
    {
		await Shell.Current.GoToAsync("PAGETWO");
    }

    async void Page3_Clicked(System.Object sender, System.EventArgs e)
    {
		await Shell.Current.GoToAsync("VIEWPAGE");
    }
}


