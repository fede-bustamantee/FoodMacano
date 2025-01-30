using FoodMacanoServices.Models;
using FoodMacanoServices.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FoodMacanoApp.Class;
using System.Text;

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

        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(HasError));
                }
            }
        }

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

        public ICommand RefreshCommand { get; }
        public ICommand VerDetallesCommand { get; }

        public EncargueViewModel(MauiEncargueService encargueService, MauiFirebaseAuthService authService)
        {
            _encargueService = encargueService ?? throw new ArgumentNullException(nameof(encargueService));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            Encargues = new ObservableCollection<MauiEncargue>();

            RefreshCommand = new Command(async () => await CargarEncargues());
            VerDetallesCommand = new Command<MauiEncargue>(async (encargue) => await MostrarDetallesEncargue(encargue));
        }

        public async Task CargarEncargues()
        {
            if (IsRefreshing || IsLoading) return;

            try
            {
                IsLoading = true;
                IsRefreshing = true;
                ErrorMessage = string.Empty;

                var userId = _authService.GetCurrentUserId();
                Console.WriteLine($"Current UserId: {userId}");

                if (string.IsNullOrEmpty(userId))
                {
                    ErrorMessage = "Usuario no autenticado. Por favor, inicie sesión.";
                    return;
                }

                var encargues = await _encargueService.GetEncarguesConDetallesAsync(userId);
                Console.WriteLine($"Encargues obtenidos: {encargues?.Count ?? 0}");

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Encargues.Clear();
                    if (encargues?.Any() == true)
                    {
                        foreach (var encargue in encargues.OrderByDescending(e => e.FechaEncargue))
                        {
                            Encargues.Add(encargue);
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general: {ex}");
                ErrorMessage = "Error al cargar los encargues. Por favor, intenta más tarde.";
            }
            finally
            {
                IsLoading = false;
                IsRefreshing = false;
            }
        }

        private async Task MostrarDetallesEncargue(MauiEncargue encargue)
        {
            if (encargue == null) return;

            try
            {
                var detallesEncargue = await _encargueService.GetEncargueConDetallesAsync(encargue.Id);
                var detallesTexto = new StringBuilder();

                detallesTexto.AppendLine($"Encargue #{detallesEncargue.Id}");
                detallesTexto.AppendLine($"Fecha: {detallesEncargue.FechaEncargue:dd/MM/yyyy HH:mm}");
                detallesTexto.AppendLine($"Estado: {detallesEncargue.Estado}");
                detallesTexto.AppendLine("\nProductos:");

                foreach (var detalle in detallesEncargue.Detalles)
                {
                    detallesTexto.AppendLine($"- {detalle.NombreProducto}");
                    detallesTexto.AppendLine($"  Cantidad: {detalle.Cantidad}");
                    detallesTexto.AppendLine($"  Precio unitario: ${detalle.PrecioUnitario:N2}");
                    detallesTexto.AppendLine($"  Subtotal: ${detalle.Subtotal:N2}");
                }

                detallesTexto.AppendLine($"\nTotal: ${detallesEncargue.Total:N2}");

                await Application.Current.MainPage.DisplayAlert(
                    "Detalles del Encargue",
                    detallesTexto.ToString(),
                    "Cerrar");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mostrar detalles: {ex}");
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "No se pudieron cargar los detalles del encargue.",
                    "OK");
            }
        }
    }
}