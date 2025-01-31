using FoodMacanoApp.ViewModels;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;

namespace FoodMacanoApp.Views.Informacion;

[QueryProperty(nameof(ProductoId), "id")]
public partial class InformacionView : ContentPage
{
    private readonly InformacionViewModel _viewModel;
    private int _productoId;

    public int ProductoId
    {
        get => _productoId;
        set
        {
            _productoId = value;
            LoadProducto(value);
        }
    }

    public InformacionView(IGenericService<Producto> productoService)
    {
        InitializeComponent();
        _viewModel = new InformacionViewModel(productoService);
        BindingContext = _viewModel;
    }

    private async void LoadProducto(int productoId)
    {
        await _viewModel.LoadProducto(productoId);
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}