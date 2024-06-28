namespace LMS_Task_4.Pages;

public partial class ManagementPage : ContentPage
{
	MainViewModel vm;
	public ManagementPage(MainViewModel vm)
	{
		InitializeComponent();
		this.vm = vm;
	}

	private void InsertConfirm_click(object sender, EventArgs e)
	{
        string type = null;
        double cost = 0;
        double weight = 0;
        string colour = null;
        double produce = 0;

        #region InputChecking
        string typeEntry = LEType.Text;
        if (string.IsNullOrWhiteSpace(typeEntry) || (typeEntry != "cow" && typeEntry != "Cow" && typeEntry != "sheep" && typeEntry != "Sheep"))
        {
            DisplayAlert("Error", "Invalid type", "OK");
            return;
        }
        else
        {
            if (typeEntry == "cow" || typeEntry == "Cow")
            {
                type = "Cow";
            }
            else if (typeEntry == "sheep" || typeEntry == "Sheep")
            {
                type = "Sheep";
            }
        }
        string costEntry = LECost.Text;
        if (string.IsNullOrWhiteSpace(costEntry) || !Double.TryParse(costEntry, out double costResult) || costResult < 0)
        {
            DisplayAlert("Error", "Invalid cost", "OK");
            return;
        }
        else
        {
            cost = costResult;
        }
        string weightEntry = LEWeight.Text;
        if (string.IsNullOrWhiteSpace(weightEntry) || !Double.TryParse(weightEntry, out double weightResult) || weightResult < 0)
        {
            DisplayAlert("Error", "Invalid weight", "OK");
            return;
        }
        else
        {
            weight = weightResult;
        }
        string colourEntry = LEColour.Text;
        if (string.IsNullOrWhiteSpace(colourEntry) || (colourEntry != "red" && colourEntry != "Red" && colourEntry != "white" && colourEntry != "White" 
            && colourEntry != "black" && colourEntry != "Black"))
        {
            DisplayAlert("Error", "Invalid colour", "OK");
            return;
        }
        else
        {
            if (colourEntry == "red" || colourEntry == "Red")
            {
                colour = "Red";
            }
            else if (colourEntry == "white" || colourEntry == "White")
            {
                colour = "White";
            }
            else if (colourEntry == "black" || colourEntry == "Black")
            {
                colour = "Black";
            }
        }
        string produceEntry = LEProduct.Text;
        if (string.IsNullOrWhiteSpace(produceEntry) || !Double.TryParse(produceEntry, out double produceResult) || produceResult < 0)
        {
            DisplayAlert("Error", "Invalid amount", "OK");
            return;
        }
        else
        {
            produce = produceResult;
        }
        #endregion

        Livestock entry = null;

        if(type == "Cow")
        {
            Cow cow = new Cow
            {
                Cost = cost,
                Weight = weight,
                Colour = colour,
                Milk = produce
            };
            entry = cow;
        }
        else if (type == "Sheep")
        {
            Sheep sheep = new Sheep
            {
                Cost = cost,
                Weight = weight,
                Colour = colour,
                Wool = produce
            };
            entry = sheep;
        }

        if (vm._database.InsertItem(entry) == 1)
        {
            LEResult.Text = "Successful";
            vm.LivestockOC.Add(entry);
        }
        else
        {
            LEResult.Text = "Failed";
        }
    }

    private void InsertReset_click(object sender, EventArgs e)
    {
        LEType.Text = "";
        LECost.Text = "";
        LEWeight.Text = "";
        LEColour.Text = "";
        LEProduct.Text = "";
        LEResult.Text = "...";
    }

    private void UpdateConfirm_click(object sender, EventArgs e)
    {
        int id;
        string type = null;
        double cost = 0;
        double weight = 0;
        string colour = null;
        double produce = 0;

        #region InputChecking
        string idEntry = LUID.Text;
        if (string.IsNullOrWhiteSpace(idEntry) || !int.TryParse(idEntry, out int idResult) || idResult < 0)
        {
            DisplayAlert("Error", "Invalid ID", "OK");
            return;
        }
        else
        {
            id = idResult;
        }

        bool match = false;
        Livestock original = null;
        foreach (var ls in vm.LivestockOC)
        {
            // Calculation section for Cows
            if (ls is Cow cow && id == cow.Id)
            {
                type = "Cow";
                cost = cow.Cost;
                weight = cow.Weight;
                colour = cow.Colour;
                produce = cow.Milk;
                match = true;
                original = cow;
            }
            // Calculation section for Sheep
            else if (ls is Sheep sheep && id == sheep.Id)
            {
                type = "Sheep";
                cost = sheep.Cost;
                weight = sheep.Weight;
                colour = sheep.Colour;
                produce = sheep.Wool;
                match = true;
                original = sheep;
            }
        }
        if (!match)
        {
            DisplayAlert("Error", "ID Has No Matching Entry", "OK");
            return;
        }

        string costEntry = LUCost.Text;
        if(costEntry == "")
        {
            // Intentionally empty, do nothing
        }
        else if (!Double.TryParse(costEntry, out double costResult) || costResult < 0)
        {
            DisplayAlert("Error", "Invalid cost", "OK");
            return;
        }
        else
        {
            cost = costResult;
        }

        string weightEntry = LUWeight.Text;
        if (weightEntry == "")
        {
            // Intentionally empty, do nothing
        }
        else if (!Double.TryParse(weightEntry, out double weightResult) || weightResult < 0)
        {
            DisplayAlert("Error", "Invalid weight", "OK");
            return;
        }
        else
        {
            weight = weightResult;
        }

        string colourEntry = LUColour.Text;
        if (colourEntry == "")
        {
            // Intentionally empty, do nothing
        }
        else if (colourEntry != "red" && colourEntry != "Red" && colourEntry != "white" && colourEntry != "White"
            && colourEntry != "black" && colourEntry != "Black")
        {
            DisplayAlert("Error", "Invalid colour", "OK");
            return;
        }
        else
        {
            if (colourEntry == "red" || colourEntry == "Red")
            {
                colour = "Red";
            }
            else if (colourEntry == "white" || colourEntry == "White")
            {
                colour = "White";
            }
            else if (colourEntry == "black" || colourEntry == "Black")
            {
                colour = "Black";
            }
        }

        string produceEntry = LUProduct.Text;
        if (produceEntry == "")
        {
            // Intentionally empty, do nothing
        }
        else if (!Double.TryParse(produceEntry, out double produceResult) || produceResult < 0)
        {
            DisplayAlert("Error", "Invalid amount", "OK");
            return;
        }
        else
        {
            produce = produceResult;
        }
        #endregion

        Livestock entry = null;

        if (type == "Cow")
        {
            Cow cow = new Cow
            {
                Id = id,
                Cost = cost,
                Weight = weight,
                Colour = colour,
                Milk = produce
            };
            entry = cow;
        }
        else if (type == "Sheep")
        {
            Sheep sheep = new Sheep
            {
                Id = id,
                Cost = cost,
                Weight = weight,
                Colour = colour,
                Wool = produce
            };
            entry = sheep;
        }

        if (vm._database.UpdateItem(entry) == 1)
        {
            LUResult.Text = "Successful";
            vm.LivestockOC.Remove(original);
            vm.LivestockOC.Add(entry);
        }
        else
        {
            LUResult.Text = "Failed";
        }
    }

    private void UpdateReset_click(object sender, EventArgs e)
    {
        LUID.Text = "";
        LUCost.Text = "";
        LUWeight.Text = "";
        LUColour.Text = "";
        LUProduct.Text = "";
        LUResult.Text = "...";
    }

    private void DeleteConfirm_click(object sender, EventArgs e)
    {
        int id;
        string idEntry = LDID.Text;
        if (string.IsNullOrWhiteSpace(idEntry) || !int.TryParse(idEntry, out int idResult) || idResult < 0)
        {
            DisplayAlert("Error", "Invalid ID", "OK");
            return;
        }
        else
        {
            id = idResult;
        }

        bool match = false;
        Livestock target = null;
        foreach (var ls in vm.LivestockOC)
        {
            // Calculation section for Cows
            if (ls is Cow cow && id == cow.Id)
            {
                target = cow;
                match = true;
            }
            // Calculation section for Sheep
            else if (ls is Sheep sheep && id == sheep.Id)
            {
                target = sheep;
                match = true;
            }
        }
        if (!match)
        {
            DisplayAlert("Error", "ID Has No Matching Entry", "OK");
            return;
        }

        if (vm._database.DeleteItem(target) == 1)
        {
            LDResult.Text = "Successful";
            vm.LivestockOC.Remove(target);
        }
        else
        {
            LDResult.Text = "Failed";
        }
    }

    private void DeleteReset_click(object sender, EventArgs e)
    {
        LDID.Text = "";
        LDResult.Text = "...";
    }
}