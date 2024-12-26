using FoodMacanoApp.Views.Inicio;

namespace FoodMacanoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Inicio());
        }
    }
}
