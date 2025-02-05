using FoodMacanoApp.ViewModels;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;

namespace FoodMacanoApp.Views.Negocios;

public partial class NegociosView : ContentPage
{
    private readonly NegocioViewModel _viewModel;

    public NegociosView(IGenericService<Negocio> negocioService)
    {
        InitializeComponent();
        _viewModel = new NegocioViewModel(negocioService);
        BindingContext = _viewModel;

        // Cargar los datos cuando se inicie la página
        LoadData();
    }

    private async void LoadData()
    {
        await _viewModel.LoadNegocio();
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnDireccionTapped(object sender, EventArgs e)
    {
        try
        {
            var direccion = ((Label)sender).Text;
            await Launcher.OpenAsync($"https://maps.google.com/?q={direccion}");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudo abrir el mapa", "OK");
        }
    }

    private async void OnFacebookTapped(object sender, EventArgs e)
    {
        try
        {
            var facebook = ((Label)sender).Text;
            await Launcher.OpenAsync(facebook);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudo abrir Facebook", "OK");
        }
    }

    private async void OnInstagramTapped(object sender, EventArgs e)
    {
        try
        {
            var instagram = ((Label)sender).Text;
            await Launcher.OpenAsync(instagram);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudo abrir Instagram", "OK");
        }
    }

    private async void OnWhatsAppTapped(object sender, EventArgs e)
    {
        try
        {
            var whatsapp = ((Label)sender).Text;
            await Launcher.OpenAsync($"https://wa.me/{whatsapp}");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudo abrir WhatsApp", "OK");
        }
    }
}