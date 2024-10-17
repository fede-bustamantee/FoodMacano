using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using FoodMacanoApp.Class;
using FoodMacanoServices.Models;
using FoodMacanoServices.Services;

namespace FoodMacanoApp.ViewModels
{
    public class CarritoViewModel : NotificationObject
    {
        private readonly CarritoComprasService _carritoService;
        private readonly ProductoService _productoService;

        private ObservableCollection<CarritoCompra> _productosCarrito;
        public ObservableCollection<CarritoCompra> ProductosCarrito
        {
            get => _productosCarrito;
            set
            {
                _productosCarrito = value;
                OnPropertyChanged();
            }
        }

        private decimal _totalPrecio;
        public decimal TotalPrecio
        {
            get => _totalPrecio;
            set
            {
                _totalPrecio = value;
                OnPropertyChanged();
            }
        }

        private string _mensajeEstado;
        public string MensajeEstado
        {
            get => _mensajeEstado;
            set
            {
                _mensajeEstado = value;
                OnPropertyChanged();
            }
        }

        public ICommand CargarProductosCarritoCommand { get; private set; }
        public ICommand AumentarCantidadCommand { get; private set; }
        public ICommand DisminuirCantidadCommand { get; private set; }
        public ICommand ConfirmarCommand { get; private set; }

        public CarritoViewModel()
        {
            var httpClient = new HttpClient();
            var genericCarritoService = new GenericService<CarritoCompra>(httpClient);
            var genericEncargueService = new GenericService<Encargue>(httpClient);
            _carritoService = new CarritoComprasService(genericCarritoService, genericEncargueService, httpClient, null);
            _productoService = new ProductoService(); // Uso del constructor sin parámetros

            ProductosCarrito = new ObservableCollection<CarritoCompra>();

            CargarProductosCarritoCommand = new Command(async () => await CargarProductosCarrito());
            AumentarCantidadCommand = new Command<CarritoCompra>(async (item) => await AumentarCantidad(item));
            DisminuirCantidadCommand = new Command<CarritoCompra>(async (item) => await DisminuirCantidad(item));
            ConfirmarCommand = new Command(async () => await Confirmar());

            // Cargar productos al inicializar el ViewModel
            Task.Run(async () => await CargarProductosCarrito());
        }

        private async Task CargarProductosCarrito()
        {
            try
            {
                MensajeEstado = "Cargando productos...";
                var carritoItems = await _carritoService.GetCartItemsAsync();
                if (carritoItems != null && carritoItems.Any())
                {
                    var productos = await _productoService.GetAllAsync();
                    var productosCarrito = carritoItems.Select(item =>
                    {
                        item.Producto = productos.FirstOrDefault(p => p.Id == item.ProductoId);
                        return item;
                    }).ToList();

                    ProductosCarrito = new ObservableCollection<CarritoCompra>(productosCarrito);
                    CalcularTotalPrecio();
                    MensajeEstado = $"Se cargaron {productosCarrito.Count} productos.";
                }
                else
                {
                    MensajeEstado = "No se encontraron productos en el carrito.";
                }
            }
            catch (Exception ex)
            {
                MensajeEstado = $"Error al cargar productos: {ex.Message}";
            }
        }

        private async Task AumentarCantidad(CarritoCompra item)
        {
            item.Cantidad++;
            await ActualizarItem(item);
        }

        private async Task DisminuirCantidad(CarritoCompra item)
        {
            if (item.Cantidad > 1)
            {
                item.Cantidad--;
                await ActualizarItem(item);
            }
            else
            {
                await EliminarDelCarrito(item);
            }
        }

        private async Task ActualizarItem(CarritoCompra item)
        {
            try
            {
                await _carritoService.UpdateAsync(item);
                CalcularTotalPrecio();
            }
            catch (Exception ex)
            {
                MensajeEstado = $"Error al actualizar item: {ex.Message}";
            }
        }

        private async Task EliminarDelCarrito(CarritoCompra item)
        {
            try
            {
                await _carritoService.RemoveFromCartAsync(item.Id);
                ProductosCarrito.Remove(item);
                CalcularTotalPrecio();
            }
            catch (Exception ex)
            {
                MensajeEstado = $"Error al eliminar item: {ex.Message}";
            }
        }

        private void CalcularTotalPrecio()
        {
            TotalPrecio = ProductosCarrito.Sum(item => item.Producto.Precio * item.Cantidad);
        }

        private async Task Confirmar()
        {
            try
            {
                await _carritoService.CheckoutAsync();
                ProductosCarrito.Clear();
                TotalPrecio = 0;
                MensajeEstado = "Pedido confirmado con éxito";
            }
            catch (Exception ex)
            {
                MensajeEstado = $"Error al confirmar pedido: {ex.Message}";
            }
        }
    }
}
