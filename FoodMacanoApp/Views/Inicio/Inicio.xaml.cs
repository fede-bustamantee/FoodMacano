using FoodMacanoApp.ViewModels;
using FoodMacanoApp.Views.Carrito;
using FoodMacanoServices.Models;
using Microsoft.Maui.Graphics;
using System.Globalization;


namespace FoodMacanoApp.Views.Inicio;

public partial class Inicio : ContentPage
{
    private Frame _marcoSeleccionadoActualmente;
    private InicioViewModel _viewModel;

    public Inicio()
    {
        InitializeComponent();
        _viewModel = new InicioViewModel();
        BindingContext = _viewModel;
        _viewModel.DatosCargados += OnDatosCargados;
    }
    public class IntToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int intValue)
            {
                return intValue > 0;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
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
    private async void OnDatosCargados(object sender, EventArgs e)
    {
        // Asegurarse de que este código se ejecute en el hilo principal
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            // Seleccionar la primera categoría si hay categorías disponibles
            if (_viewModel.Categorias.Any())
            {
                var collectionView = categoriasCollectionView;
                if (collectionView != null)
                {
                    // Obtener el primer contenedor visual
                    var container = collectionView.GetVisualTreeDescendants()
                        .OfType<Frame>()
                        .FirstOrDefault();

                    if (container != null)
                    {
                        // Simular un tap en la primera categoría
                        container.BackgroundColor = Colors.Orange;
                        _marcoSeleccionadoActualmente = container;

                        // Filtrar productos
                        var primeraCategoria = _viewModel.Categorias.First();
                        _viewModel.FiltrarProductosPorCategoria(primeraCategoria);
                    }
                }
            }
        });
    }

    private void OnCategoriaTapped(object sender, EventArgs e)
    {
        var marco = sender as Frame;
        var categoria = marco?.BindingContext as Categoria;
        if (categoria != null)
        {
            // Restablecer el color del marco previamente seleccionado
            if (_marcoSeleccionadoActualmente != null)
            {
                _marcoSeleccionadoActualmente.BackgroundColor = Colors.Gray;
            }

            // Cambiar el color del marco recién seleccionado
            marco.BackgroundColor = Colors.Orange;
            _marcoSeleccionadoActualmente = marco;

            // Filtrar productos
            _viewModel.FiltrarProductosPorCategoria(categoria);
        }
    }

    private async void CarritoClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CarritoView());
    }
}