using FoodMacanoApp.ViewModels;
using FoodMacanoServices.Interfaces;

namespace FoodMacanoApp.Views.Perfil;

public partial class PerfilView : ContentPage
{
    private readonly PerfilViewModel _viewModel;

    public PerfilView(IAuthService authService)
    {
        InitializeComponent();
        _viewModel = new PerfilViewModel(authService);
        BindingContext = _viewModel;
    }

    private async void OnVolverClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///InicioView");
    }

    private async void OnCerrarSesionClicked(object sender, EventArgs e)
    {
        bool confirmacion = await DisplayAlert("Cerrar Sesi�n", "�Est�s seguro de que deseas cerrar sesi�n?", "S�", "No");
        if (confirmacion)
        {
            _viewModel.CerrarSesion();
            var appShell = (AppShell)App.Current.MainPage;
            appShell.DisableAppAfterLogin();
        }
    }
}