using System.Collections.ObjectModel;
using System.Windows.Input;
using FoodMacanoApp.Class;
using FoodMacanoApp.Views.Encargue;
using FoodMacanoServices.Services.Orders;
using FoodMacanoServices.Services.FireAuth;
using FoodMacanoServices.Models.Orders;

namespace FoodMacanoApp.ViewModels
{
    public class EncargueViewModel : NotificationObject
    {
        private readonly MauiEncargueService _encargueService;
        private readonly MauiFirebaseAuthService _authService;

        private bool _isRefreshing;
        private bool _isLoading;
        private string _errorMessage;

        private ObservableCollection<MauiEncargue> _encargues;

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    OnPropertyChanged();
                }
            }
        }

        // Propiedad que determina si hay un mensaje de error
        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

        // Propiedad para almacenar el mensaje de error
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(HasError)); // Notifica cambio también para la propiedad HasError
                }
            }
        }

        // Propiedad que maneja el estado de actualización (refreshing)
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                if (_isRefreshing != value)
                {
                    _isRefreshing = value;
                    OnPropertyChanged();
                }
            }
        }

        // Propiedad que almacena la lista de encargues
        public ObservableCollection<MauiEncargue> Encargues
        {
            get => _encargues;
            set
            {
                if (_encargues != value)
                {
                    _encargues = value;
                    OnPropertyChanged();
                }
            }
        }

        // Comandos para realizar acciones desde la interfaz de usuario
        public ICommand RefreshCommand { get; }
        public ICommand VerDetallesCommand { get; }

        // Constructor donde se inyectan los servicios necesarios
        public EncargueViewModel(MauiEncargueService encargueService, MauiFirebaseAuthService authService)
        {
            // Se aseguran de que los servicios no sean nulos
            _encargueService = encargueService ?? throw new ArgumentNullException(nameof(encargueService));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));

            // Inicializamos la colección de encargues
            Encargues = new ObservableCollection<MauiEncargue>();

            // Definimos los comandos que se usarán en la UI
            RefreshCommand = new Command(async () => await CargarEncargues());
            VerDetallesCommand = new Command<MauiEncargue>(async (encargue) => await MostrarDetallesEncargue(encargue));
        }

        // Método que carga los encargues desde el servicio
        public async Task CargarEncargues()
        {
            if (IsRefreshing || IsLoading) return; // Evita cargar si ya está en proceso

            try
            {
                // Indicamos que se está cargando
                IsLoading = true;
                IsRefreshing = true;
                ErrorMessage = string.Empty; // Limpiamos el mensaje de error

                // Obtenemos el usuario actual para loguearnos
                var currentUser = await _authService.GetCurrentUser();
                Console.WriteLine($"Current User LocalId: {currentUser?.LocalId}");
                Console.WriteLine($"Current User Email: {currentUser?.Email}");
                Console.WriteLine($"Current User Display Name: {currentUser?.DisplayName}");

                var userId = _authService.GetCurrentUserId();
                Console.WriteLine($"Current UserId from GetCurrentUserId(): {userId}");

                // Verificamos si el usuario está autenticado
                if (string.IsNullOrEmpty(userId))
                {
                    ErrorMessage = "Usuario no autenticado. Por favor, inicie sesión.";
                    return;
                }

                // Obtenemos los encargues asociados al usuario
                var encargues = await _encargueService.GetEncarguesAsync(userId);
                Console.WriteLine($"Encargues obtenidos: {encargues?.Count ?? 0}");

                // Actualizamos la interfaz de usuario en el hilo principal
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Encargues.Clear(); // Limpiamos la lista antes de agregar los nuevos encargues
                    if (encargues?.Any() == true)
                    {
                        // Agregamos los encargues en orden descendente según la fecha
                        foreach (var encargue in encargues.OrderByDescending(e => e.FechaEncargue))
                        {
                            Encargues.Add(encargue);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontraron encargues para este usuario.");
                    }
                });
            }
            catch (UnauthorizedAccessException ex) // Manejo de errores si no se está autenticado
            {
                Console.WriteLine($"Unauthorized Access Error: {ex.Message}");
                ErrorMessage = "Sesión expirada. Por favor, vuelva a iniciar sesión.";
            }
            catch (Exception ex) // Manejo de errores generales
            {
                Console.WriteLine($"Error detallado al cargar encargues: {ex}");
                Console.WriteLine($"Error Message: {ex.Message}");
                Console.WriteLine($"Error StackTrace: {ex.StackTrace}");

                ErrorMessage = "Error al cargar los encargues. Por favor, intenta más tarde.";
            }
            finally
            {
                IsLoading = false; // Indicamos que ya terminó el proceso de carga
                IsRefreshing = false; // Indicamos que la actualización ha terminado
            }
        }

        // Método para mostrar los detalles de un encargue
        private async Task MostrarDetallesEncargue(MauiEncargue encargue)
        {
            if (encargue == null) return; // Verificamos si el encargue es nulo

            try
            {
                // Navegamos a la vista de detalles pasando el encargue seleccionado
                await Shell.Current.Navigation.PushModalAsync(new EncargueDetalleView(encargue));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mostrar detalles: {ex}");
                // Si ocurre un error, mostramos un mensaje de alerta
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "No se pudieron cargar los detalles del encargue.",
                    "OK");
            }
        }
    }
}