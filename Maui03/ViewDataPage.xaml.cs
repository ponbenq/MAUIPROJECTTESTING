namespace Maui03;
using Services;
public partial class ViewDataPage : ContentPage
{
	Service_init _db;

	List<Constants> consitem;

	public ViewDataPage()
	{
		InitializeComponent();
		_db = new Service_init();

		consitem = new List<Constants>();
		getD();

		ListView_1.ItemsSource = consitem;
	}

	public async void getD()
	{
		var task = _db.GetItem();

		try
		{
			var cons = await task;
			foreach(Constants con in cons)
			{
				int id = con.Id;
				String userName = con.userName;

				var data = new Constants { Id = id, userName = userName };
				consitem.Add(data);
			}
		}
		catch(Exception ex)
		{
			await DisplayAlert("Error Occured!", ex.Message, "OK");
		}
	}
}
