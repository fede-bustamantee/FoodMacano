using FoodMacanoApp.Class;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;

namespace FoodMacanoApp.ViewModels
{
    public class NegocioViewModel : NotificationObject
    {
        private readonly IGenericService<Negocio> _negocioService;
        private Negocio _negocio;

        public Negocio Negocio
        {
            get => _negocio;
            set
            {
                if (_negocio != value)
                {
                    _negocio = value;
                    OnPropertyChanged();
                }
            }
        }

        public NegocioViewModel(IGenericService<Negocio> negocioService)
        {
            _negocioService = negocioService;
        }

        public async Task LoadNegocio()
        {
            try
            {
                // Aquí asumimos que solo hay un negocio y tomamos el primero
                var negocios = await _negocioService.GetAllAsync();
                if (negocios != null && negocios.Any())
                {
                    Negocio = negocios.First();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar el negocio: {ex.Message}");
                // Aquí podrías manejar el error como prefieras
            }
        }
    }
}