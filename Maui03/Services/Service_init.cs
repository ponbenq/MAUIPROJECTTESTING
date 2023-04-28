namespace Maui03.Services;
using SQLite;

public class Service_init : Constants
{
	static SQLiteAsyncConnection db;

	

	public Service_init()
	{
        Init();	 
	}

    public async Task Init()
    {
        if (db != null)
            return;

        var path = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

        db = new SQLiteAsyncConnection(path);
        Console.WriteLine("Table Created!");
        await db.CreateTableAsync<Constants>();

    }

    public async Task AddColumn(String name)
    {
        await Init();

        var item = new Constants
        {
            userName = name
        };

        var id = await db.InsertAsync(item);
    }

    public async Task<List<Constants>> GetItem()
    {
        //give anything!
        await Init();

        var constants = await db.Table<Constants>().ToListAsync();
        return constants;
    }

    public async Task DeleteColumn(int id)
    {
        await Init();

        await db.DeleteAsync<Constants>(id);
    }
}
