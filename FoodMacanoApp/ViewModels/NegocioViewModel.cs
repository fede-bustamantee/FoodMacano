using FoodMacanoApp.Class;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models.Common;
using System.Collections.ObjectModel;

public class NegocioViewModel : NotificationObject
{
    private readonly IGenericService<Negocio> _negocioService;
    private ObservableCollection<Negocio> _negocios;

    public ObservableCollection<Negocio> Negocios
    {
        get => _negocios;
        set
        {
            _negocios = value;
            OnPropertyChanged();
        }
    }

    public NegocioViewModel(IGenericService<Negocio> negocioService)
    {
        _negocioService = negocioService;
        Negocios = new ObservableCollection<Negocio>();
    }

    // Método asincrónico para cargar la lista de negocios desde el servicio
    public async Task LoadNegocios()
    {
        try
        {
            var negocios = await _negocioService.GetAllAsync(); // Obtiene la lista de negocios desde el servicio

            // Verifica si la lista no está vacía antes de actualizar la colección
            if (negocios != null && negocios.Any())
            {
                Negocios = new ObservableCollection<Negocio>(negocios); // Asigna la nueva lista de negocios
            }
        }
        catch (Exception ex)
        {
            // Manejo de errores en caso de que la carga de datos falle
            Console.WriteLine($"Error al cargar los negocios: {ex.Message}");
        }
    }
}
