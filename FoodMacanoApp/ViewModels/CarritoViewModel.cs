using FoodMacanoApp.Class;
using FoodMacanoServices.Models;
using FoodMacanoServices.Services;
using FoodMacanoServices.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FoodMacanoApp.ViewModels
{
	public class CarritoViewModel : NotificationObject
	{
		private readonly MauiCarritoService _carritoService;
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

        public ICommand AumentarCantidadCommand { get; }
		public ICommand DisminuirCantidadCommand { get; }
		public ICommand ConfirmarCommand { get; }
        public ICommand LimpiarCarritoCommand { get; }

        public CarritoViewModel(
			MauiCarritoService carritoService,
			ProductoService productoService)
		{
			_carritoService = carritoService;
			_productoService = productoService;

			AumentarCantidadCommand = new Command<CarritoCompra>(async (item) => await AumentarCantidad(item));
			DisminuirCantidadCommand = new Command<CarritoCompra>(async (item) => await DisminuirCantidad(item));
            ConfirmarCommand = new Command(async () => await Confirmar(Direccion));
            LimpiarCarritoCommand = new Command(() => LimpiarCarrito());

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
					ProductosCarrito.Clear();
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

        private async Task AumentarCantidad(CarritoCompra item)
        {
            try
            {
                item.Cantidad++;  // Incrementamos la cantidad
                await _carritoService.UpdateCartItemAsync(item);

                // Forzar actualización en la UI
                RefrescarItemEnLista(item);

                CalcularTotalPrecio();
            }
            catch (Exception ex)
            {
                MensajeEstado = $"Error al aumentar cantidad: {ex.Message}";
            }
        }
        private async Task DisminuirCantidad(CarritoCompra item)
        {
            try
            {
                if (item.Cantidad > 1)
                {
                    item.Cantidad--;  // Decrementamos la cantidad
                    await _carritoService.UpdateCartItemAsync(item);

                    // Forzar actualización en la UI
                    RefrescarItemEnLista(item);
                }
                else
                {
                    // Si la cantidad es 1 y se quiere disminuir, se elimina el producto del carrito
                    await _carritoService.RemoveFromCartAsync(item.Id);
                    ProductosCarrito.Remove(item);

                    // Si quieres llamar a `ClearCartAsync` para manejar la eliminación de productos específicos, puedes hacer algo así:
                    await _carritoService.ClearCartAsync(item.Id);  // Llamas a la versión modificada de `ClearCartAsync`
                    MensajeEstado = "Producto Limpiado";
                }

                CalcularTotalPrecio();
            }
            catch (Exception ex)
            {
                MensajeEstado = $"Error al disminuir cantidad: {ex.Message}";
            }
        }

        private void RefrescarItemEnLista(CarritoCompra item)
        {
            var index = ProductosCarrito.IndexOf(item);
            if (index != -1)
            {
                // Crear un nuevo objeto con los mismos valores para forzar actualización
                var nuevoItem = new CarritoCompra
                {
                    ProductoId = item.ProductoId,
                    Cantidad = item.Cantidad,
                    Producto = item.Producto
                };

                ProductosCarrito[index] = nuevoItem; // Reemplazamos el objeto en la colección
                OnPropertyChanged(nameof(ProductosCarrito)); // Notificar a la UI
            }
        }


        private void CalcularTotalPrecio()
		{
			TotalPrecio = ProductosCarrito.Sum(item => item.Producto?.Precio * item.Cantidad ?? 0);
		}

        private async Task Confirmar(string direccion)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(direccion))
                {
                    MensajeEstado = "Debe ingresar una dirección.";
                    return;
                }

                MensajeEstado = "Procesando pedido...";
                await _carritoService.CheckoutAsync(direccion);
                ProductosCarrito.Clear();
                TotalPrecio = 0;
                MensajeEstado = "Pedido confirmado con éxito.";
            }
            catch (Exception ex)
            {
                MensajeEstado = $"Error al confirmar pedido: {ex.Message}";
            }
        }
        private async Task LimpiarCarrito()
        {
            try
            {
                // Limpiar el carrito en el servicio
                await _carritoService.ClearCartAsync();

                // Limpiar la colección local
                ProductosCarrito.Clear();
                TotalPrecio = 0;
                MensajeEstado = "Carrito limpiado";
            }
            catch (Exception ex)
            {
                MensajeEstado = $"Error al limpiar el carrito: {ex.Message}";
            }
        }
    }
}