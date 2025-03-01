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

    // M�todo que se ejecuta cuando el texto de b�squeda cambia
    private void OnBusquedaTextChanged(object sender, TextChangedEventArgs e)
    {
        // Llama al m�todo en el ViewModel para filtrar los productos por nombre
        _viewModel.FiltrarProductosPorNombre(e.NewTextValue);
    }

    // M�todo que se ejecuta cuando se hace clic en el bot�n "Agregar al Carrito"
    private async void OnAgregarAlCarritoClicked(object sender, EventArgs e)
    {
        try
        {
            var button = sender as Button;  // Obtiene el bot�n que fue clickeado
            var producto = button?.BindingContext as Producto;  // Obtiene el producto asociado al bot�n

            if (producto == null)  // Si no se pudo obtener el producto, mostramos un mensaje de error
            {
                await DisplayAlert("Error", "No se pudo obtener el producto", "OK");
                return;
            }

            // Llama al m�todo en el ViewModel para agregar el producto al carrito
            await _viewModel.AgregarAlCarrito(producto);
        }
        catch (Exception ex)
        {
            // Si ocurre alg�n error, mostramos un mensaje de error
            await DisplayAlert("Error", $"No se pudo agregar el producto al carrito: {ex.Message}", "OK");
        }
    }

    // M�todo que se ejecuta cuando se hace clic en el bot�n "Informaci�n"
    private async void OnInformacionClicked(object sender, EventArgs e)
    {
        try
        {
            var button = sender as Button;  // Obtiene el bot�n que fue clickeado
            var producto = button?.BindingContext as Producto;  // Obtiene el producto asociado al bot�n

            if (producto != null)  // Si el producto no es nulo, navega a la vista de informaci�n del producto
            {
                await Shell.Current.GoToAsync($"InformacionView?id={producto.Id}");
            }
        }
        catch (Exception ex)
        {
            // Si ocurre alg�n error, mostramos un mensaje de error
            await DisplayAlert("Error", $"No se pudo abrir la informaci�n del producto: {ex.Message}", "OK");
        }
    }

    // M�todo que se ejecuta cuando se hace clic en el bot�n "Volver"
    private async void OnVolverClicked(object sender, EventArgs e)
    {
        // Navega a la vista de inicio
        await Shell.Current.GoToAsync("///InicioView");
    }
}
