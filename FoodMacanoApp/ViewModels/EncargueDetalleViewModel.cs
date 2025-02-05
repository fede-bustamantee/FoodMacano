using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FoodMacanoServices.Models;

namespace FoodMacanoApp.ViewModels
{
    public partial class EncargueDetalleViewModel : ObservableObject
    {
        [ObservableProperty]
        private MauiEncargue _encargue;

        public ICommand CerrarCommand { get; }

        public EncargueDetalleViewModel(MauiEncargue encargue)
        {
            _encargue = encargue;
            CerrarCommand = new RelayCommand(async () => await CerrarVista());
        }

        private async Task CerrarVista()
        {
            await Shell.Current.GoToAsync("EncargueView");
        }
    }
}