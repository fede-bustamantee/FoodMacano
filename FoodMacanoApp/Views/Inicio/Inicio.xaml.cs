using FoodMacanoApp.ViewModels;

namespace FoodMacanoApp.Views.Inicio;

public partial class Inicio : ContentPage
{
	public Inicio()
	{
		InitializeComponent();
        BindingContext = new InicioViewModel();
    }
}