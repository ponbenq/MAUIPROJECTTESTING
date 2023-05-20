namespace Maui03.ViewModels;
using System.Collections.ObjectModel;
using Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Net.Http;
using static Android.Content.ClipData;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Reflection;
using Maui03.Views;

public partial class ProductPage : ObservableObject
{
    [ObservableProperty]
    public List<Items> items;

    [ObservableProperty]
    bool isRefreshing;

    [RequiresAssemblyFiles()]
    public ProductPage()
	{

        //loadItems();	
        Console.WriteLine("Before starting Product page");
        //readFromJson();
        //httprequestingJson();
        
    }
    
	[RelayCommand]
	public static async Task GoToPurchasePageAsync(Items orders)
	{
		if (orders is null)
			return;
		await Shell.Current.GoToAsync(nameof(PurchasePage), true,
			new Dictionary<string,Object>
			{
				{ "orders","orders" }
			});
    }

    [RelayCommand]
	public static async Task GoToDetailsAsync(Items items)
	{
		if (items is null)
			return;
		await Shell.Current.GoToAsync("DetailsPage", true,
			new Dictionary<string, object>
			{
				{"Item", items }
			});
    }
   
    [RelayCommand]
    public async void simpleReadJson()
    {
        try
        {
            //waited for loading
            await Task.Delay(2000);
            //destination path
            string targetFilePath = Path.Combine(FileSystem.AppDataDirectory, "products.json");

            //connect stream of file
            var fileStream = await FileSystem.Current.OpenAppPackageFileAsync("products.json");

            //pass to streamreader [NOTE] streamreader only return Text
            var reader = new StreamReader(targetFilePath);

            //return collections of object
            var content = await reader.ReadToEndAsync();
            //Instantiated collections of object
            Items = JsonConvert.DeserializeObject<List<Items>>(content);

       }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            IsRefreshing = false;
        }
    }
    [RelayCommand]
    public async Task GetItem()
    {
        try
        {
            string path = Path.Combine(FileSystem.AppDataDirectory, "products.json");
            if (File.Exists(path))
                Console.WriteLine("File does exist!");
            using (StreamReader sr = File.OpenText(path))
            {
                var content = await sr.ReadToEndAsync();
                Items = JsonConvert.DeserializeObject<List<Items>>(content);

                foreach(var item in Items)
                {
                    Console.WriteLine(item.itemName);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    [RelayCommand]
    public async void writeJson()
    {
        try
        {
            int selectedId = 1;
            //selected one specific item where id = 1
            Items selectedItem = Items.FirstOrDefault(x => x.id == selectedId);
            //list other item
            List<Items> otherItems = Items.Where(x => x.id != selectedId).ToList();
            //modify selected item
            selectedItem.itemName = "new name";
            //selected index of the update one
            int selectedIndex = Items.FindIndex(x => x.id == selectedId);
            //combine two list 
            //List<Items> combinItems = otherItems.Concat(new List<Items> { selectedItem }).ToList();
            List<Items> combinItems = new List<Items>(otherItems);
            combinItems.Insert(selectedIndex, selectedItem);

            //serialize items
            string content = JsonConvert.SerializeObject(combinItems, Formatting.Indented);
            //write to file 
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "products.json");
            using (var streamWriter = new StreamWriter(filePath))
            { 
                streamWriter.Write(content);
                streamWriter.Flush();
            }
            Console.WriteLine("File saved to :" + filePath);

            if (selectedItem != null)
                Console.WriteLine(selectedItem.itemName);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    //[RelayCommand]
    //public async Task updateTestJson()
    //{
    //    try
    //    {
    //        //var url = "https://my-json-server.typicode.com/typicode/demo/posts";
    //        //HttpClient httpClient = new HttpClient();
    //        //var resultResponse = await httpClient.GetAsync(url);
    //        //HttpRequestMessage response = new(HttpMethod.Put, $"{url}/3");

    //        //var msg = new HttpRequestMessage(HttpMethod.Post, url);
    //        //roots = await response.Content.ReadFromJsonAsync<List<Root>>();

    //        //Root updateRoot = roots.FirstOrDefault(i => i.id == 1);

    //        //if (updateRoot != null)
    //        //    updateRoot.title = "update post 3";

    //        //msg.Content = JsonContent.Create<Root>(updateRoot);
    //        //var re = await httpClient.SendAsync(msg);
    //        //re.EnsureSuccessStatusCode();
    //        var url = "https://ponbenq.github.io/product-data/products.json";
    //        HttpClient httpClient = new HttpClient();
    //        var resultResponse = await httpClient.GetAsync(url);
    //        var items = await resultResponse.Content.ReadFromJsonAsync<List<Items>>();

    //        var updateRoot = items.FirstOrDefault(i => i.id == 3);
    //        if (updateRoot != null)
    //            updateRoot.itemName = "update post 3";

    //        var putRequest = new HttpRequestMessage(HttpMethod.Put, $"{url}/{updateRoot.id}");
    //        putRequest.Content = JsonContent.Create<Items>(updateRoot);

    //        var putResponse = await httpClient.SendAsync(putRequest);
    //        putResponse.EnsureSuccessStatusCode();

    //        var checkResponse = await httpClient.GetAsync(url);
    //        var updatedRoots = await checkResponse.Content.ReadFromJsonAsync<List<Items>>();

    //        var updatedRoot = updatedRoots.FirstOrDefault(i => i.id == 3);
    //        if (updatedRoot != null)
    //        {
    //            if (updatedRoot.itemName == "update post 3")
    //                Console.WriteLine("Data is updated successfully.");
    //            else
    //                Console.WriteLine("Data update failed.");
    //        }
    //        else
    //            Console.WriteLine("Object not found.");


    //    }
    //    catch (HttpRequestException ex)
    //    {
    //        Console.WriteLine(ex.Message);
    //    }catch(Exception e)
    //    {
    //        Console.WriteLine(e.Message);
    //    }

    //}

    ////get fake json from free hosting

    //public class Root
    //{
    //    public int id { get; set; }
    //    public string title { get; set; }
    //}
    //[ObservableProperty]
    //public List<Root> roots;

    //[RelayCommand]
    //public async Task testJsonGet()
    //{
    //    try
    //    {
    //        var url = "https://my-json-server.typicode.com/typicode/demo/posts";
    //        HttpClient httpClient = new HttpClient();
    //        var response = await httpClient.GetAsync(url);

    //        roots = await response.Content.ReadFromJsonAsync<List<Root>>();

    //        foreach(var root in roots)
    //        {
    //            Console.WriteLine($"id : {root.id} \nname : {root.title}");
    //        }
    //    }
    //    catch(HttpRequestException ex)
    //    {
    //        Console.WriteLine(ex.Message);
    //    }
    //}

    ////end 

    ///* try update json host in github but it won't work cuz github web host is staic */

    //[RelayCommand]
    //public async Task httprequestWriteJson()
    //{
    //    string token = "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";
    //    try
    //    {
    //        HttpClient httpClient = new HttpClient();
    //        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", token);
    //        var url = "https://ponbenq.github.io/product-data/products.json";
    //        HttpResponseMessage response = await httpClient.GetAsync(url);
    //        response.EnsureSuccessStatusCode();

    //        Items itemToUpdate = Items.FirstOrDefault(i => i.id == 3);
    //        if (itemToUpdate != null)
    //        {
    //            itemToUpdate.itemName = "item-3-1";
    //        }

    //        var json = JsonConvert.SerializeObject(itemToUpdate);
    //        response = await httpClient.PutAsJsonAsync(url, json);
    //        response.EnsureSuccessStatusCode();
    //    }
    //    catch(Exception e) {
    //        Console.WriteLine(e.Message);
    //    }
    //}


    ///* end */


    /* get json using REST API with github */


    public async void httprequestingJson()
    {
        try
        {
            HttpClient httpClient = new HttpClient();
            var url = "https://ponbenq.github.io/product-data/products.json";
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                Items = await response.Content.ReadFromJsonAsync<List<Items>>();
            }
        }
        catch(HttpRequestException e)
        { 

        }

    }

    /* end */

    /* get json from file in project */
    [RelayCommand]
    public async void readFromJson()
    {
        try
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("products.json") ;
            Console.WriteLine("in the product page");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            Items = JsonConvert.DeserializeObject<List<Items>>(contents);
        }
        catch(Exception ex) {
            Console.WriteLine("this is error message : " + ex.Message);
        }

    }
    /* end */

    [RelayCommand]
	public async Task loadItems()
	{
        try
        {
            await Task.Delay(2000);
            Items = new()
        {
            new Items
            {
                itemName = "Product1",
                itemPic = "p1.png",
                itemQuantity = "2"
            },
            new Items
            {
                itemName = "Product2",
                itemPic = "p2.png",
                itemQuantity = "1"
            },
            new Items
            {
                itemName = "Product3",
                itemPic = "p3.png",
                itemQuantity = "3"
            },
            new Items
            {
                itemName = "Product4",
                itemPic = "p4.png",
                itemQuantity = "1"
            },
            new Items
            {
                itemName = "Product5",
                itemPic = "p5.png",
                itemQuantity = "4"
            },
            new Items
            {
                itemName = "Product6",
                itemPic = "p6.png",
                itemQuantity = "1"
            }
        };
        }
        finally
        {
            IsRefreshing = false; 
        }
    }
}
