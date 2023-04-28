namespace Maui03;
using Services;
public partial class Page2 : ContentPage
{
	Service_init _sv;
	public Page2()
	{
		InitializeComponent();
		_sv = new Service_init();
		
	}

	public async void popUp()
	{
        AddingUser();
	}

    async void Add_Clicked(System.Object sender, System.EventArgs e)
    {
        AddingUser();
    }

    async void Delete_Clicked(System.Object sender, System.EventArgs e)
    {
        DeletingUser();
    }

	public async void AddingUser()
	{
        string result = await DisplayPromptAsync("Adding new Data to Database UserName", "Enter your name");
        if (String.IsNullOrEmpty(result))
        {
            await DisplayAlert("Name Required!", "Please enter your name", "OK");
            return;
        }
        await _sv.AddColumn(result);
    }

    public async void DeletingUser()
    {
        string result = await DisplayPromptAsync("Remove Data by ID", "Enter ID",
            initialValue: "1", maxLength: 2, keyboard: Keyboard.Numeric);

        int id = int.Parse(result);
        await _sv.DeleteColumn(id);
    }
}
