using FoodMacanoApp.ViewModels;
using FoodMacanoServices.Models.Orders;

namespace FoodMacanoApp.Views.Encargue;

public partial class EncargueDetalleView : ContentPage
{
    public EncargueDetalleView(MauiEncargue encargue)
    {
        InitializeComponent();
        BindingContext = new EncargueDetalleViewModel(encargue);
    }

}