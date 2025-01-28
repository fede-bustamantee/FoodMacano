using FoodMacanoApp.Views.Inicio;
using FoodMacanoApp.Views.Login;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace FoodMacanoApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

}