namespace LMS_Task_4.ViewModels;

public class MainViewModel
{
    public ObservableCollection<Livestock> LivestockOC { get; set; }
    public readonly Database _database;
    public double MilkPrice { get; set; }
    public double WoolPrice { get; set; }
    public double GovTax { get; set; }

    public MainViewModel()
    {
        _database = new();
        LivestockOC = new();
        List<Livestock> farmLS = _database.ReadItems();
        foreach (Livestock item in farmLS)
        {
            LivestockOC.Add(item);
        }
        MilkPrice = 9.4;
        WoolPrice = 6.2;
        GovTax = 0.2;
    }
}
