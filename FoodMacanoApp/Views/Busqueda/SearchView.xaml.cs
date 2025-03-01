using FoodMacanoServices.Interfaces;
using FoodMacanoApp.ViewModels;
using FoodMacanoServices.Services.Carrito;
using FoodMacanoServices.Models.Common;

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

    // Método que se ejecuta cuando el texto de búsqueda cambia
    private void OnBusquedaTextChanged(object sender, TextChangedEventArgs e)
    {
        // Llama al método en el ViewModel para filtrar los productos por nombre
        _viewModel.FiltrarProductosPorNombre(e.NewTextValue);
    }

    // Método que se ejecuta cuando se hace clic en el botón "Agregar al Carrito"
    private async void OnAgregarAlCarritoClicked(object sender, EventArgs e)
    {
        try
        {
            var button = sender as Button;  // Obtiene el botón que fue clickeado
            var producto = button?.BindingContext as Producto;  // Obtiene el producto asociado al botón

            if (producto == null)  // Si no se pudo obtener el producto, mostramos un mensaje de error
            {
                await DisplayAlert("Error", "No se pudo obtener el producto", "OK");
                return;
            }

            // Llama al método en el ViewModel para agregar el producto al carrito
            await _viewModel.AgregarAlCarrito(producto);
        }
        catch (Exception ex)
        {
            // Si ocurre algún error, mostramos un mensaje de error
            await DisplayAlert("Error", $"No se pudo agregar el producto al carrito: {ex.Message}", "OK");
        }
    }

    // Método que se ejecuta cuando se hace clic en el botón "Información"
    private async void OnInformacionClicked(object sender, EventArgs e)
    {
        try
        {
            var button = sender as Button;  // Obtiene el botón que fue clickeado
            var producto = button?.BindingContext as Producto;  // Obtiene el producto asociado al botón

            if (producto != null)  // Si el producto no es nulo, navega a la vista de información del producto
            {
                await Shell.Current.GoToAsync($"InformacionView?id={producto.Id}");
            }
        }
        catch (Exception ex)
        {
            // Si ocurre algún error, mostramos un mensaje de error
            await DisplayAlert("Error", $"No se pudo abrir la información del producto: {ex.Message}", "OK");
        }
    }

    // Método que se ejecuta cuando se hace clic en el botón "Volver"
    private async void OnVolverClicked(object sender, EventArgs e)
    {
        // Navega a la vista de inicio
        await Shell.Current.GoToAsync("///InicioView");
    }
}
