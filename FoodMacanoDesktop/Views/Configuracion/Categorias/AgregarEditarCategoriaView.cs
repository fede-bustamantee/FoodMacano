using FoodMacanoServices.Models.Common;
using FoodMacanoServices.Services.Common;

namespace FoodMacanoDesktop.Views.Configuracion.Categorias
{
    public partial class AgregarEditarCategoriaView : Form
    {
        CategoriaService categoriaService = new CategoriaService();
        Categoria categoria;

        // Constructor para agregar
        public AgregarEditarCategoriaView()
        {
            InitializeComponent();
            categoria = new Categoria();
        }

        // Constructor para editar
        public AgregarEditarCategoriaView(Categoria categoria)
        {
            InitializeComponent();
            this.categoria = categoria;
            txtNombre.Text = categoria.Nombre;
            txtIconUrl.Text = categoria.IconUrl;
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnGuardar_Click_1(object sender, EventArgs e)
        {
            categoria.Nombre = txtNombre.Text;
            categoria.IconUrl = txtIconUrl.Text;

            if (categoria.Id == 0) // Modo agregar
            {
                await categoriaService.AddAsync(categoria);
            }
            else // Modo editar
            {
                await categoriaService.UpdateAsync(categoria);
            }

            this.Close();
        }
    }
}
