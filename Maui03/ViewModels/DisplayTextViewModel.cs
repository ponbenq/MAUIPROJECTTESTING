namespace Maui03.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui03.Models;
using Newtonsoft.Json;
public partial class DisplayTextViewModel : ObservableObject
{
	

	public DisplayTextViewModel()
	{

		readPlainText();
	}
	[ObservableProperty]
	public List<PlainText> plainText;

    [RelayCommand]
	public async Task readPlainText()
	{
		try {

			using var filePath = await FileSystem.Current.OpenAppPackageFileAsync("pl.json");
			using (var reader = new StreamReader(filePath))
			{
				var content = await reader.ReadToEndAsync();
				PlainText = JsonConvert.DeserializeObject<List<PlainText>>(content);
            }
        }
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
        }
    }

}
