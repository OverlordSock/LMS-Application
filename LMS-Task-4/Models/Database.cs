namespace LMS_Task_4.Models;

public class Database
{
    private readonly SQLiteConnection _connection;
    public Database()
    {
        string dbName = "FarmData.db";
        string dbPath = Path.Combine(Current.AppDataDirectory, dbName);
        if (!File.Exists(dbPath))
        {
            //open the db file
            using Stream stream = Current.OpenAppPackageFileAsync(dbName).Result;
            using MemoryStream memoryStream = new();
            stream.CopyTo(memoryStream);
            //write db data to app directory
            File.WriteAllBytes(dbPath, memoryStream.ToArray());
        }
        _connection = new SQLiteConnection(dbPath); // SQLite connection with relative path to db file in program execution folder
        _connection.CreateTables<Cow, Sheep>(); // Create tables if they do not already exist
    }
    public List<Livestock> ReadItems()
    {
        var livestock = new List<Livestock>();
        var lst1 = _connection.Table<Cow>().ToList(); // Create list from Cow
        livestock.AddRange(lst1); // Add Cow list to stores
        var lst2 = _connection.Table<Sheep>().ToList(); // Create list from Sheep
        livestock.AddRange(lst2); // Add Sheep list to stores
        return livestock;
    }

    public List<Cow> ReadCows()
    {
        List<Cow> cows = _connection.Table<Cow>().ToList(); // Create list from Cow
        return cows;
    }

    public List<Sheep> ReadSheep()
    {
        List<Sheep> sheep = _connection.Table<Sheep>().ToList(); // Create list from Sheep
        return sheep;
    }

    // Methods to insert, update, and delete rows below this

    // Insert Livestock instance
    public int InsertItem(Livestock item)
    {
        return _connection.Insert(item);
    }

    // Delete Livestock instance
    public int DeleteItem(Livestock item)
    {
        return _connection.Delete(item);
    }

    // Update Livestock instance
    public int UpdateItem(Livestock item)
    {
        return _connection.Update(item);
    }
}
