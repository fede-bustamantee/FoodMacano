using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;
using FoodMacanoServices.Services;
using FoodMacanoApp.ViewModels;

namespace FoodMacanoApp.Views.Busqueda;

public partial class SearchView : ContentPage
{
    private readonly SearchViewModel _viewModel;

    public SearchView(IGenericService<Producto> productoService, MauiCarritoService carritoService)
    {
        InitializeComponent();
        _viewModel = new SearchViewModel(productoService, carritoService);
        BindingContext = _viewModel;
    }

    private void OnBusquedaTextChanged(object sender, TextChangedEventArgs e)
    {
        _viewModel.FiltrarProductosPorNombre(e.NewTextValue);
    }

    private async void OnAgregarAlCarritoClicked(object sender, EventArgs e)
    {
        try
        {
            var button = sender as Button;
            var producto = button?.BindingContext as Producto;
            if (producto == null)
            {
                await DisplayAlert("Error", "No se pudo obtener el producto", "OK");
                return;
            }

            await _viewModel.AgregarAlCarrito(producto);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"No se pudo agregar el producto al carrito: {ex.Message}", "OK");
        }
    }

    private async void OnInformacionClicked(object sender, EventArgs e)
    {
        try
        {
            var button = sender as Button;
            var producto = button?.BindingContext as Producto;
            if (producto != null)
            {
                await Shell.Current.GoToAsync($"InformacionView?id={producto.Id}");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"No se pudo abrir la información del producto: {ex.Message}", "OK");
        }
    }

    private async void OnVolverClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///InicioView");
    }
}