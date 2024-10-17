using FoodMacanoApp.ViewModels;

namespace FoodMacanoApp.Views.Carrito;

public partial class CarritoView : ContentPage
{
	public CarritoView()
	{
		InitializeComponent();
        BindingContext = new CarritoViewModel();
    }
    private async void VolverClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}