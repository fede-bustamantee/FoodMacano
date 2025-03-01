namespace FoodMacanoDesktop.Views.Informaciones
{
    public partial class InformacionesView : Form
    {
        public InformacionesView(string nombre, string imagenUrl, string descripcionLarga)
        {
            InitializeComponent();
            CargarInformacionProducto(nombre, imagenUrl, descripcionLarga);
        }
        private void CargarInformacionProducto(string nombre, string imagenUrl, string descripcionLarga)
        {
            // Asigna el nombre del producto
            lblNombre.Text = nombre;

            // Verifica si la URL de la imagen no está vacía o nula.
            if (!string.IsNullOrEmpty(imagenUrl))
                // Si la URL es válida, carga la imagen desde la URL proporcionada en el control picImagen (PictureBox).
                picImagen.Load(imagenUrl);

            // Asigna la descripción larga del producto al control txtDescripcion (TextBox).
            txtDescripcion.Text = descripcionLarga;
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}