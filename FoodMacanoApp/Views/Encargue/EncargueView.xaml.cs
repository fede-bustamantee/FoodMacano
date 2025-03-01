using FoodMacanoApp.ViewModels;
using FoodMacanoServices.Interfaces;
using Microsoft.Maui.Controls;
using FoodMacanoServices.Services.Orders;
using FoodMacanoServices.Services.FireAuth;

namespace FoodMacanoApp.Views.Encargue
{
    public partial class EncargueView : ContentPage
    {
        private readonly EncargueViewModel _viewModel;

        public EncargueView(MauiEncargueService encargueService, MauiFirebaseAuthService authService)
        {
            InitializeComponent();
            _viewModel = new EncargueViewModel(encargueService, authService);
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.CargarEncargues();
        }
        private async void OnVolverClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///InicioView");
        }
    }
}
