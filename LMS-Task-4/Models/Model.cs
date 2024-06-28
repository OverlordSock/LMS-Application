namespace LMS_Task_4.Models;

public class Livestock
{
    [PrimaryKey, AutoIncrement]
    // Shared table fields
    public int Id { get; set; }
    public double Cost { get; set; }
    public double Weight { get; set; }
    public string Colour { get; set; }

    public override string ToString()
    {
        // this.GetType().Name will return either Cow or Sheep
        return $"{this.GetType().Name,-15} {Id,-5} {Cost,-10} {Weight,-10} {Colour,-10}";
    }
}

[Table("Cow")]
public class Cow : Livestock
{
    public double Milk { get; set; } // Field specific to Cow
    public override string ToString()
    {
        return base.ToString() + $"{Milk}"; // Append type specific field to ToString()
    }
}

[Table("Sheep")]
public class Sheep : Livestock
{
    public double Wool { get; set; } // Field specific to Sheep
    public override string ToString()
    {
        return base.ToString() + $"{Wool}"; // Append type specific field to ToString()
    }
}
