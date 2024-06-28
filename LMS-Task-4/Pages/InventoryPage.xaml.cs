namespace LMS_Task_4.Pages;

public partial class InventoryPage : ContentPage
{
	MainViewModel vm;
	public InventoryPage(MainViewModel vm)
	{
		InitializeComponent();
		this.vm = vm;
		BindingContext = vm;
	}
}