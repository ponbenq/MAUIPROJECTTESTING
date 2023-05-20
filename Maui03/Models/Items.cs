namespace Maui03.Models;
using SQLite;

public class Items
{
    //[PrimaryKey, AutoIncrement]
    public int id { get; set; }
    public string itemName { get; set; }
    public string itemPic { get; set; }
    public string itemQuantity { get; set; }
}
//public record Items(
//    string itemName,
//    string itemPic,
//    string itemQuantity);