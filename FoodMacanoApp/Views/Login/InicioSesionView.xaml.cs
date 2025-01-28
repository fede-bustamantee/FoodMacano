using FoodMacanoApp.ViewModels;

namespace FoodMacanoApp.Views.Login
{
    public partial class InicioSesionView : ContentPage
    {
        public InicioSesionView()
        {
            InitializeComponent();
            BindingContext = new IniciarSesionViewModel();
        }
    }
}