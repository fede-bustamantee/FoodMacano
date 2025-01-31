using FoodMacanoApp.Class;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;

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
            _productoService = productoService;
        }

        public async Task LoadProducto(int productoId)
        {
            try
            {
                var producto = await _productoService.GetByIdAsync(productoId);
                if (producto != null)
                {
                    Producto = producto;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar el producto: {ex.Message}");
                // Aquí podrías manejar el error como prefieras
            }
        }
    }
}