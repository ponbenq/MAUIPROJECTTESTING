namespace Maui03;
using SQLite;

public class Constants : ContentPage
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public String userName { get; set; }
}
