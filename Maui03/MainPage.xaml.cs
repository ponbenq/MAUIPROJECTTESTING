namespace Maui03;

using Newtonsoft.Json;
using Services;
using SQLite;
using System;
using Maui03.Models;
public partial class MainPage : ContentPage
{
    String name = "user1";


    Service_init db;
    public MainPage()
    {
        InitializeComponent();
        db = new Service_init();

        string filePath = Path.GetFullPath("products.json");
        Console.WriteLine("file Path of json file : " + filePath);
        //CopyJsonFile();

    }

    private async void CopyJsonFile()
    {
        string targetFilePath = Path.Combine(FileSystem.AppDataDirectory, "products.json");

        //connect stream of file
        var fileStream = await FileSystem.Current.OpenAppPackageFileAsync("products.json");
        using (var fileStreamOutput = new FileStream(targetFilePath, FileMode.Create, FileAccess.ReadWrite))
        {
            await fileStream.CopyToAsync(fileStreamOutput);
        }
        Console.WriteLine("File copied to : " + targetFilePath);
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

            foreach (Constants constant in constantsList)
            {
                int id = constant.Id;
                string userName = constant.userName;

                await DisplayAlert("Data Retrieve", $"id : {id}, userName: {userName}", "OK");
            }
        }
        catch (Exception ex)
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

    async void ProductPage_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("PRODUCT");
    }
}
