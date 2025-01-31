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
}