using FoodMacanoApp.ViewModels;
using FoodMacanoServices.Services;
using FoodMacanoServices.Interfaces;
using Microsoft.Maui.Controls;

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
    }
}
