using FoodMacanoApp.Class;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models.Common;

namespace FoodMacanoApp.ViewModels
{
    public class InformacionViewModel : NotificationObject
    {
        private readonly IGenericService<Producto> _productoService;
        private Producto _producto;

        public Producto Producto
        {
            get => _producto;
            set
            {
                if (_producto != value)
                {
                    _producto = value;
                    OnPropertyChanged();
                }
            }
        }

        public InformacionViewModel(IGenericService<Producto> productoService)
        {
            _productoService = productoService; // Asignamos el servicio recibido
        }

        // Método asíncrono para cargar la información de un producto usando su ID
        public async Task LoadProducto(int productoId)
        {
            try
            {
                // Llamamos al servicio para obtener el producto con el ID especificado
                var producto = await _productoService.GetByIdAsync(productoId);

                if (producto != null) // Si el producto fue encontrado
                {
                    Producto = producto; // Asignamos el producto cargado a la propiedad Producto
                }
            }
            catch (Exception ex) // Si ocurre algún error, lo manejamos aquí
            {
                // Se captura el error y se imprime en la consola
                Console.WriteLine($"Error al cargar el producto: {ex.Message}");
                // Aquí podrías manejar el error como prefieras (mostrar un mensaje de error, etc.)
            }
        }
    }
}