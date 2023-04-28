namespace Maui03;
using Services;
public partial class Page2 : ContentPage
{
	Service_init _sv;

    public List<Constants> dataitem { get; set; }
    public List<String> items { get; set; }
    public string uname = "Item1";

	public Page2()
	{
		InitializeComponent();
		_sv = new Service_init();
        popUp();
        items = new List<string>
    {
        "item 1",
        "item 2",
        "item 3"
    };
        
    }

	public async void popUp()
	{
        var task = _sv.GetItem();
        
        try
        {
            var constantsList = await task;

            foreach (Constants constant in constantsList)
            {
                int id = constant.Id;
                string userName = constant.userName;

                dataitem = new List<Constants> { new Constants { Id = id, userName = userName } };
            }
            dataitem.ForEach(Console.WriteLine);
        }
        
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }

    void Add_Clicked(System.Object sender, System.EventArgs e)
    {
        AddingUser();
    }

    void Delete_Clicked(System.Object sender, System.EventArgs e)
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
             maxLength: 2, keyboard: Keyboard.Numeric);
        if (String.IsNullOrEmpty(result))
            return;
        int id = int.Parse(result);
        await _sv.DeleteColumn(id);
    }
}
