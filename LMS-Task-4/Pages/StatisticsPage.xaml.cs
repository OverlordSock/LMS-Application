namespace LMS_Task_4.Pages;

public partial class StatisticsPage : ContentPage
{
    MainViewModel vm;
    private double totalLivestock = 0;

    public StatisticsPage(MainViewModel vm)
    {
        InitializeComponent();
        this.vm = vm;
        FarmDailyProfit();
    }

    public void FarmDailyProfit()
    {
        // Cow variables
        double cowTotalIncome = 0;
        double cowTotalCost = 0;
        double cowTotalWeight = 0;
        double cowCount = 0;
        // Sheep variables
        double sheepTotalIncome = 0;
        double sheepTotalCost = 0;
        double sheepTotalWeight = 0;
        double sheepCount = 0;
        foreach (var ls in vm.LivestockOC)
        {
            // Calculation section for Cows
            if (ls is Cow cow)
            {
                cowTotalIncome += cow.Milk * vm.MilkPrice;
                cowTotalCost += cow.Cost;
                cowTotalWeight += cow.Weight;
                cowCount++;
            }
            // Calculation section for Sheep
            else if (ls is Sheep sheep)
            {
                sheepTotalIncome += sheep.Wool * vm.WoolPrice;
                sheepTotalCost += sheep.Cost;
                sheepTotalWeight += sheep.Weight;
                sheepCount++;
            }
        }
        // Assigning calculations to variables to set in GUI
        double allCowProfit = RoundTwoDP(cowTotalIncome - cowTotalCost - (cowTotalWeight * vm.GovTax));
        double allSheepProfit = RoundTwoDP(sheepTotalIncome - sheepTotalCost - (sheepTotalWeight * vm.GovTax));
        double totalProfit = RoundTwoDP(allCowProfit + allSheepProfit);
        double totalLivestockWeight = RoundTwoDP(cowTotalWeight + sheepTotalWeight);
        double totalLivestockCount = RoundTwoDP(cowCount + sheepCount);
        double avgWeight = RoundTwoDP(totalLivestockWeight / totalLivestockCount);
        double govTax = RoundTwoDP((totalLivestockWeight * vm.GovTax) * 30);
        double cowAvgProfit = RoundTwoDP(allCowProfit / cowCount);
        double sheepAvgProfit = RoundTwoDP(allSheepProfit / sheepCount);

        totalLivestock = totalLivestockCount;

        // Setting fields in GUI
        DayGovTax.Text = "$" + govTax;
        DailyProfit.Text = "$" + totalProfit;
        AvgWeight.Text = avgWeight + "kg";
        CowAvgProfit.Text = "$" + cowAvgProfit;
        SheepAvgProfit.Text = "$" + sheepAvgProfit;
        CowTotalProfit.Text = "$" + allCowProfit;
        SheepTotalProfit.Text = "$" + allSheepProfit;
    }

    private void SearchConfirm_click(object sender, EventArgs e)
    {
        double lsTotalProfit = 0;
        double lsTotalWeight = 0;
        double lsCount = 0;
        double lsProduce = 0;

        // Check if type ok
        string type = LSType.Text;
        if (string.IsNullOrWhiteSpace(type) || (type != "cow" && type != "Cow" && type != "sheep" && type != "Sheep"))
        {
            DisplayAlert("Error", "Invalid type", "OK");
            return;
        }
        // Check if colour ok
        string colour = LSColour.Text;
        if (string.IsNullOrWhiteSpace(colour) || (colour != "all" && colour != "All" && colour != "red" && colour != "Red" && colour != "white" && colour != "White"
            && colour != "black" && colour != "Black"))
        {
            DisplayAlert("Error", "Invalid colour", "OK");
            return;
        }
        foreach (var ls in vm.LivestockOC)
        {
            if (ls is Cow cow && (type == "cow" || type == "Cow"))
            {
                // Calculation section for cows
                if ((colour == "red" || colour == "Red") && cow.Colour == "Red")
                {
                    lsTotalProfit += (cow.Milk * vm.MilkPrice) + (cow.Weight * vm.GovTax) - cow.Cost;
                    lsTotalWeight += cow.Weight;
                    lsProduce += cow.Milk;
                    lsCount++;
                }
                else if ((colour == "black" || colour == "Black") && cow.Colour == "Black")
                {
                    lsTotalProfit += (cow.Milk * vm.MilkPrice) + (cow.Weight * vm.GovTax) - cow.Cost;
                    lsTotalWeight += cow.Weight;
                    lsProduce += cow.Milk;
                    lsCount++;
                }
                else if ((colour == "white" || colour == "White") && cow.Colour == "White")
                {
                    lsTotalProfit += (cow.Milk * vm.MilkPrice) + (cow.Weight * vm.GovTax) - cow.Cost;
                    lsTotalWeight += cow.Weight;
                    lsProduce += cow.Milk;
                    lsCount++;
                }
                else if (colour == "all" || colour == "All")
                {
                    lsTotalProfit += (cow.Milk * vm.MilkPrice) + (cow.Weight * vm.GovTax) - cow.Cost;
                    lsTotalWeight += cow.Weight;
                    lsProduce += cow.Milk;
                    lsCount++;
                }
            }
            // Calculation section for Sheep
            else if (ls is Sheep sheep && (type == "sheep" || type == "Sheep"))
            {
                if ((colour == "red" || colour == "Red") && sheep.Colour == "Red")
                {
                    lsTotalProfit += (sheep.Wool * vm.WoolPrice) + (sheep.Weight * vm.GovTax) - sheep.Cost;
                    lsTotalWeight += sheep.Weight;
                    lsProduce += sheep.Wool;
                    lsCount++;
                }
                else if ((colour == "black" || colour == "Black") && sheep.Colour == "Black")
                {
                    lsTotalProfit += (sheep.Wool * vm.WoolPrice) + (sheep.Weight * vm.GovTax) - sheep.Cost;
                    lsTotalWeight += sheep.Weight;
                    lsProduce += sheep.Wool;
                    lsCount++;
                }
                else if ((colour == "white" || colour == "White") && sheep.Colour == "White")
                {
                    lsTotalProfit += (sheep.Wool * vm.WoolPrice) + (sheep.Weight * vm.GovTax) - sheep.Cost;
                    lsTotalWeight += sheep.Weight;
                    lsProduce += sheep.Wool;
                    lsCount++;
                }
                else if (colour == "all" || colour == "All")
                {
                    lsTotalProfit += (sheep.Wool * vm.WoolPrice) + (sheep.Weight * vm.GovTax) - sheep.Cost;
                    lsTotalWeight += sheep.Weight;
                    lsProduce += sheep.Wool;
                    lsCount++;
                }
            }
        }
        double lsAvgWeight = RoundTwoDP(lsTotalWeight / lsCount);
        double lsTax = RoundTwoDP(lsTotalWeight * vm.GovTax);
        double lsPercent = RoundTwoDP((lsCount / totalLivestock) * 100);
        lsProduce = RoundTwoDP(lsProduce);
        lsTotalProfit = RoundTwoDP(lsTotalProfit);

        LSNum.Text = lsCount.ToString();
        LSPercent.Text = lsPercent + "%";
        LSTax.Text = "$" + lsTax;
        LSProfit.Text = "$" + lsTotalProfit;
        LSWeight.Text = lsAvgWeight + "kg";
        LSProduct.Text = lsProduce + "kg";
    }

    private void SearchReset_click(object sender, EventArgs e)
    {
        LSType.Text = "";
        LSColour.Text = "";
        LSNum.Text = "...";
        LSPercent.Text = "...";
        LSTax.Text = "...";
        LSProfit.Text = "...";
        LSWeight.Text = "...";
        LSProduct.Text = "...";
    }

    private void InvestConfirm_click(object sender, EventArgs e)
    {
        string lsType = FIType.Text;
        if (string.IsNullOrWhiteSpace(lsType) || (lsType != "cow" && lsType != "Cow" && lsType != "sheep" && lsType != "Sheep"))
        {
            DisplayAlert("Error", "Invalid type", "OK");
            return;
        }
        string quantity = LSType.Text;
        double lsNum;
        if (string.IsNullOrWhiteSpace(quantity) || !Double.TryParse(quantity, out double result) || result < 1)
        {
            DisplayAlert("Error", "Invalid quantity", "OK");
            return;
        }
        else
        {
            lsNum = result;
        }

        double cowTotalProfit = 0;
        double cowCount = 0;
        double sheepTotalProfit = 0;
        double sheepCount = 0;

        foreach (var ls in vm.LivestockOC)
        {
            // Calculation section for Cows
            if (ls is Cow cow && (lsType == "cow" || lsType == "Cow"))
            {
                cowTotalProfit += (cow.Milk * vm.MilkPrice) - cow.Cost - (cow.Weight * vm.GovTax);
                cowCount++;
            }
            // Calculation section for Sheep
            else if (ls is Sheep sheep && (lsType == "sheep" || lsType == "Sheep"))
            {
                sheepTotalProfit += (sheep.Wool * vm.WoolPrice) - sheep.Cost - (sheep.Weight * vm.GovTax);
                sheepCount++;
            }
        }

        double investAvgProfit = 0;
        if(lsType == "cow" || lsType == "Cow")
        {
            investAvgProfit = (cowTotalProfit / cowCount) * lsNum;
            FIResult.Text = "$" + investAvgProfit;
        }
        else if(lsType == "sheep" || lsType == "Sheep")
        {
            investAvgProfit = (sheepTotalProfit / sheepCount) * lsNum;
            FIResult.Text = "$" + investAvgProfit;
        }
    }

    private void InvestReset_click(object sender, EventArgs e)
    {
        FIType.Text = "";
        FIQuantity.Text = "";
        FIResult.Text = "...";
    }

    private static double RoundTwoDP(double value)
    {
        return Math.Round(value, 2);
    }
}