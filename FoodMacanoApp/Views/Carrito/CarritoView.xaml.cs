using FoodMacanoApp.ViewModels;
using FoodMacanoServices.Services;

namespace FoodMacanoApp.Views.Carrito;

public partial class CarritoView : ContentPage
{
	private readonly MauiCarritoService _carritoService;
	private readonly ProductoService _productoService;

	public CarritoView(MauiCarritoService carritoService, ProductoService productoService)
	{
		InitializeComponent();
		_carritoService = carritoService;
		_productoService = productoService;
		BindingContext = new CarritoViewModel(_carritoService, _productoService);
	}

	private async void VolverClicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
}
