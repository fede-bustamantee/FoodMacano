using FoodMacanoApp.Class;
using FoodMacanoServices.Models;
using FoodMacanoServices.Models.FoodMacanoServices.Models;
using FoodMacanoServices.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FoodMacanoApp.ViewModels
{
    public class CarritoViewModel : NotificationObject
    {
        private readonly CarritoComprasService _carritoService;
        private readonly ProductoService _productoService;

        public ObservableCollection<CarritoCompra> ProductosCarrito { get; set; } = new ObservableCollection<CarritoCompra>();

        private decimal _totalPrecio;
        public decimal TotalPrecio
        {
            get => _totalPrecio;
            set
            {
                if (_totalPrecio != value)
                {
                    _totalPrecio = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _mensajeEstado;
        public string MensajeEstado
        {
            get => _mensajeEstado;
            set
            {
                if (value != _mensajeEstado)
                {
                    _mensajeEstado = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AumentarCantidadCommand { get; }
        public ICommand DisminuirCantidadCommand { get; }
        public ICommand ConfirmarCommand { get; }

        public CarritoViewModel()
        {
            var httpClient = new HttpClient();

            var genericCarritoService = new GenericService<CarritoCompra>(httpClient);
            var genericEncargueService = new GenericService<Encargue>(httpClient);

            _carritoService = new CarritoComprasService(genericCarritoService, genericEncargueService, httpClient, null);
            _productoService = new ProductoService();

            AumentarCantidadCommand = new Command<CarritoCompra>(async (item) => await AumentarCantidad(item));
            DisminuirCantidadCommand = new Command<CarritoCompra>(async (item) => await DisminuirCantidad(item));
            ConfirmarCommand = new Command(async () => await Confirmar());

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
                    foreach (var item in carritoItems)
                    {
                        item.Producto = productos.FirstOrDefault(p => p.Id == item.ProductoId);
                        ProductosCarrito.Add(item);
                    }
                    CalcularTotalPrecio();
                    MensajeEstado = $"Se cargaron {ProductosCarrito.Count} productos.";
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
        private void ActualizarVista()
        {
            // Notificar que la colección ha cambiado
            OnPropertyChanged(nameof(ProductosCarrito));
        }
        private async Task AumentarCantidad(CarritoCompra item)
        {
            item.Cantidad++;
            await _carritoService.UpdateAsync(item);
            CalcularTotalPrecio();
        }

        private async Task DisminuirCantidad(CarritoCompra item)
        {
            if (item.Cantidad > 1)
            {
                item.Cantidad--;
                await _carritoService.UpdateAsync(item);
            }
            else
            {
                await _carritoService.RemoveFromCartAsync(item.Id);
                ProductosCarrito.Remove(item);
            }
            CalcularTotalPrecio();
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