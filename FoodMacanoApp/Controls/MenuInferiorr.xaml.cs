using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace FoodMacanoApp.Controls
{
    public partial class MenuInferiorr : ContentView
    {
        public static readonly BindableProperty ColorInicioProperty =
            BindableProperty.Create(
                propertyName: nameof(ColorInicio),
                returnType: typeof(Color),
                declaringType: typeof(MenuInferiorr),
                defaultValue: Colors.Black);

        public static readonly BindableProperty ColorEncarguesProperty =
            BindableProperty.Create(
                propertyName: nameof(ColorEncargues),
                returnType: typeof(Color),
                declaringType: typeof(MenuInferiorr),
                defaultValue: Colors.Black);

        public static readonly BindableProperty ColorHorariosProperty =
            BindableProperty.Create(
                propertyName: nameof(ColorHorarios),
                returnType: typeof(Color),
                declaringType: typeof(MenuInferiorr),
                defaultValue: Colors.Black);

        public static readonly BindableProperty ColorPerfilProperty =
            BindableProperty.Create(
                propertyName: nameof(ColorPerfil),
                returnType: typeof(Color),
                declaringType: typeof(MenuInferiorr),
                defaultValue: Colors.Black);

        public Color ColorInicio
        {
            get => (Color)GetValue(ColorInicioProperty);
            set => SetValue(ColorInicioProperty, value);
        }

        public Color ColorEncargues
        {
            get => (Color)GetValue(ColorEncarguesProperty);
            set => SetValue(ColorEncarguesProperty, value);
        }

        public Color ColorHorarios
        {
            get => (Color)GetValue(ColorHorariosProperty);
            set => SetValue(ColorHorariosProperty, value);
        }

        public Color ColorPerfil
        {
            get => (Color)GetValue(ColorPerfilProperty);
            set => SetValue(ColorPerfilProperty, value);
        }

        public MenuInferiorr()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private async void OnInicioClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///InicioView");
        }

        private async void OnEncargueClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("EncargueView");
        }

        private async void OnHorariosClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("NegocioView");
        }

        private async void OnPerfilClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("PerfilView");
        }
    }
}