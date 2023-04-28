namespace Maui03;
using SQLite;

public class Constants
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public String userName { get; set; }
}
