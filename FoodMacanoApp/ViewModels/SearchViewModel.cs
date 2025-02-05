using FoodMacanoApp.Class;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;
using FoodMacanoServices.Services;
using System.Collections.ObjectModel;

namespace FoodMacanoApp.ViewModels
{
    public class SearchViewModel : NotificationObject
    {
        private readonly IGenericService<Producto> _productoService;
        private readonly MauiCarritoService _carritoService;
        private ObservableCollection<Producto> _todosLosProductos;

        private ObservableCollection<Producto> _productosFiltrados;
        public ObservableCollection<Producto> ProductosFiltrados
        {
            get => _productosFiltrados;
            set
            {
                if (_productosFiltrados != value)
                {
                    _productosFiltrados = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _mensajeError;
        public string MensajeError
        {
            get => _mensajeError;
            set
            {
                if (_mensajeError != value)
                {
                    _mensajeError = value;
                    OnPropertyChanged();
                }
            }
        }

        public SearchViewModel(
            IGenericService<Producto> productoService,
            MauiCarritoService carritoService)
        {
            _productoService = productoService;
            _carritoService = carritoService;

            _todosLosProductos = new ObservableCollection<Producto>();
            ProductosFiltrados = new ObservableCollection<Producto>();

            Task.Run(async () => await CargarProductos());
        }

        private async Task CargarProductos()
        {
            try
            {
                var productos = await _productoService.GetAllAsync();
                if (productos != null)
                {
                    _todosLosProductos.Clear();
                    foreach (var producto in productos)
                    {
                        _todosLosProductos.Add(producto);
                    }
                }
                MensajeError = string.Empty;
            }
            catch (Exception ex)
            {
                MensajeError = $"Error al cargar productos: {ex.Message}";
                Console.WriteLine($"Error en CargarProductos: {ex}");
            }
        }

        public void FiltrarProductosPorNombre(string textoBusqueda)
        {
            if (string.IsNullOrWhiteSpace(textoBusqueda))
            {
                ProductosFiltrados.Clear();
                return;
            }

            var productosFiltrados = _todosLosProductos
                .Where(p => p.Nombre.Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase))
                .ToList();

            ProductosFiltrados.Clear();
            foreach (var producto in productosFiltrados)
            {
                ProductosFiltrados.Add(producto);
            }
        }

        public async Task AgregarAlCarrito(Producto producto)
        {
            try
            {
                await _carritoService.AddToCartAsync(producto);
                MensajeError = string.Empty;
            }
            catch (Exception ex)
            {
                MensajeError = $"Error al agregar al carrito: {ex.Message}";
                Console.WriteLine($"Error en AgregarAlCarrito: {ex}");
                throw;
            }
        }
    }
}