using FoodMacanoApp.Class;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FoodMacanoServices.Services.Common;
using FoodMacanoServices.Services.Carrito;
using FoodMacanoServices.Models.Cart;

namespace FoodMacanoApp.ViewModels
{
    public class CarritoViewModel : NotificationObject
	{
		private readonly MauiCarritoService _carritoService;
		private readonly ProductoService _productoService;

		public ObservableCollection<CarritoCompra> ProductosCarrito { get; set; } = new ObservableCollection<CarritoCompra>();

        // Propiedad para almacenar el precio total del carrito
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

        // Propiedad para mostrar el mensaje de estado (ej. cargando, error)
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

        // Propiedad para almacenar la dirección de envío
        private string _direccion;
        public string Direccion
        {
            get => _direccion;
            set
            {
                _direccion = value;
                OnPropertyChanged();
            }
        }

        // Comandos para las acciones del carrito: aumentar, disminuir cantidad, confirmar pedido, limpiar carrito
        public ICommand AumentarCantidadCommand { get; }
        public ICommand DisminuirCantidadCommand { get; }
        public ICommand ConfirmarCommand { get; }
        public ICommand LimpiarCarritoCommand { get; }

        // Constructor donde se inyectan los servicios necesarios
        public CarritoViewModel(
            MauiCarritoService carritoService,
            ProductoService productoService)
        {
            _carritoService = carritoService;
            _productoService = productoService;

            // Definimos los comandos que estarán disponibles en la UI
            AumentarCantidadCommand = new Command<CarritoCompra>(async (item) => await AumentarCantidad(item));
            DisminuirCantidadCommand = new Command<CarritoCompra>(async (item) => await DisminuirCantidad(item));
            ConfirmarCommand = new Command(async () => await Confirmar(Direccion));
            LimpiarCarritoCommand = new Command(() => LimpiarCarrito());

            // Cargamos los productos del carrito al iniciar el ViewModel
            Task.Run(async () => await CargarProductosCarrito());
        }

        // Método que carga los productos del carrito y los muestra en la UI
        private async Task CargarProductosCarrito()
        {
            try
            {
                MensajeEstado = "Cargando productos..."; // Indicamos que estamos cargando los productos
                var carritoItems = await _carritoService.GetCartItemsAsync(); // Obtenemos los artículos del carrito
                if (carritoItems != null && carritoItems.Any())
                {
                    var productos = await _productoService.GetAllAsync(); // Obtenemos todos los productos
                    ProductosCarrito.Clear(); // Limpiamos la lista actual

                    // Llenamos el carrito con los productos correspondientes
                    foreach (var item in carritoItems)
                    {
                        item.Producto = productos.FirstOrDefault(p => p.Id == item.ProductoId);
                        ProductosCarrito.Add(item);
                    }

                    // Calculamos el precio total del carrito
                    CalcularTotalPrecio();
                    MensajeEstado = $"Se cargaron {ProductosCarrito.Count} productos."; // Actualizamos el mensaje de estado
                }
                else
                {
                    MensajeEstado = "No se encontraron productos en el carrito."; // Mensaje si no hay productos
                }
            }
            catch (Exception ex)
            {
                MensajeEstado = $"Error al cargar productos: {ex.Message}"; // Manejo de errores
            }
        }

        // Método que aumenta la cantidad de un producto en el carrito
        private async Task AumentarCantidad(CarritoCompra item)
        {
            try
            {
                item.Cantidad++;  // Incrementamos la cantidad
                await _carritoService.UpdateCartItemAsync(item);  // Actualizamos el artículo en el carrito

                // Forzamos la actualización en la UI
                RefrescarItemEnLista(item);

                // Calculamos el precio total nuevamente
                CalcularTotalPrecio();
            }
            catch (Exception ex)
            {
                MensajeEstado = $"Error al aumentar cantidad: {ex.Message}"; // Manejo de errores
            }
        }

        // Método que disminuye la cantidad de un producto en el carrito
        private async Task DisminuirCantidad(CarritoCompra item)
        {
            try
            {
                if (item.Cantidad > 1)
                {
                    item.Cantidad--;  // Decrementamos la cantidad
                    await _carritoService.UpdateCartItemAsync(item);  // Actualizamos el artículo en el carrito

                    // Forzamos la actualización en la UI
                    RefrescarItemEnLista(item);
                }
                else
                {
                    // Si la cantidad es 1 y se quiere disminuir, eliminamos el producto del carrito
                    await _carritoService.RemoveFromCartAsync(item.Id);
                    ProductosCarrito.Remove(item);

                    // Limpiamos el artículo en el carrito
                    await _carritoService.ClearCartAsync(item.Id);
                    MensajeEstado = "Producto Limpiado"; // Mensaje de éxito
                }

                // Calculamos el precio total nuevamente
                CalcularTotalPrecio();
            }
            catch (Exception ex)
            {
                MensajeEstado = $"Error al disminuir cantidad: {ex.Message}"; // Manejo de errores
            }
        }

        // Método que refresca un artículo en la lista del carrito
        private void RefrescarItemEnLista(CarritoCompra item)
        {
            var index = ProductosCarrito.IndexOf(item);
            if (index != -1)
            {
                // Creamos un nuevo objeto con los mismos valores para forzar actualización
                var nuevoItem = new CarritoCompra
                {
                    ProductoId = item.ProductoId,
                    Cantidad = item.Cantidad,
                    Producto = item.Producto
                };

                // Reemplazamos el objeto en la colección
                ProductosCarrito[index] = nuevoItem;
                OnPropertyChanged(nameof(ProductosCarrito)); // Notificamos el cambio en la lista
            }
        }

        // Método que calcula el precio total del carrito
        private void CalcularTotalPrecio()
        {
            TotalPrecio = ProductosCarrito.Sum(item => item.Producto?.Precio * item.Cantidad ?? 0);
        }

        // Método que confirma el pedido y lo procesa
        private async Task Confirmar(string direccion)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(direccion)) // Verificamos si la dirección está vacía
                {
                    MensajeEstado = "Debe ingresar una dirección."; // Mostramos un error
                    return;
                }

                MensajeEstado = "Procesando pedido..."; // Indicamos que estamos procesando el pedido
                await _carritoService.CheckoutAsync(direccion); // Procesamos el pedido

                // Limpiamos el carrito después de la compra
                ProductosCarrito.Clear();
                TotalPrecio = 0;
                Direccion = string.Empty;
                MensajeEstado = "Pedido confirmado con éxito."; // Mensaje de éxito
            }
            catch (Exception ex)
            {
                MensajeEstado = $"Error al confirmar pedido: {ex.Message}"; // Manejo de errores
            }
        }

        // Método que limpia el carrito
        private async Task LimpiarCarrito()
        {
            try
            {
                // Limpiamos el carrito en el servicio
                await _carritoService.ClearCartAsync();

                // Limpiamos la colección local
                ProductosCarrito.Clear();
                TotalPrecio = 0;
                MensajeEstado = "Carrito limpiado"; // Mensaje de éxito
            }
            catch (Exception ex)
            {
                MensajeEstado = $"Error al limpiar el carrito: {ex.Message}"; // Manejo de errores
            }
        }
    }
}