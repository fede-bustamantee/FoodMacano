using FoodMacanoApp.Class;
using FoodMacanoServices.Models;
using FoodMacanoServices.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FoodMacanoApp.ViewModels
{
    public class InicioViewModel : NotificationObject
    {
        private readonly GenericService<Producto> _productoService; // Use GenericService for fetching products

        // ObservableCollection for binding
        private ObservableCollection<Producto> _ofertasEspeciales;
        public ObservableCollection<Producto> OfertasEspeciales
        {
            get => _ofertasEspeciales;
            set
            {
                _ofertasEspeciales = value;
                OnPropertyChanged(); // Notify view
            }
        }

        public InicioViewModel()
        {
            _productoService = new GenericService<Producto>(); // Initialize the service
            OfertasEspeciales = new ObservableCollection<Producto>();
            Task.Run(async () => await CargarOfertasAleatorias());
        }

        private async Task CargarOfertasAleatorias()
        {
            // Fetch 8 random products
            var ofertas = await _productoService.GetRandomAsync(8);
            if (ofertas != null)
            {
                OfertasEspeciales.Clear(); // Clear previous items
                foreach (var oferta in ofertas)
                {
                    OfertasEspeciales.Add(oferta); // Add to the ObservableCollection
                }
            }
        }

    }
}

