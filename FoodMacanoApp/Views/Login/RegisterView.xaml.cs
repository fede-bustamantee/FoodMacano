using Firebase.Auth;
using FoodMacanoApp.ViewModels;
using System.Net.Http.Headers;

namespace FoodMacanoApp.Views.Login;

public partial class RegisterView : ContentPage
{
    public RegisterView()
    {
        InitializeComponent();
        BindingContext = new RegisterViewModel();
    }
    private async void OnVolverClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("LoginView");
    }
}